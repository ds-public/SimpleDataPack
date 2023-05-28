//#define MESSAGE_PACK_ENABLED
//#define MESSAGE_PACK_IL2CPP

using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Text ;

using UnityEngine ;

using Cysharp.Threading.Tasks ;

using MessagePack ;

using uGUIHelper ;

using DSW.MyData ;

namespace DSW.Screens
{
	/// <summary>
	/// テンプレートスクリーンのコントロールクラス
	/// </summary>
	public class Sample : ExMonoBehaviour
	{
		[SerializeField]
		protected UIScrollView	m_ScrollView ;

		[SerializeField]
		protected UITextMesh	m_Log ;

		//-----------------------------------------------------------

		internal async UniTask Start()
		{
			// 実機用の簡易デバッグログ表示を有効にする
			DebugScreen.Create( 0xFFFFFF, 36, 48, 1 ) ;

			//----------------------------------------------------------

#if ( NET_STANDARD_2_1 || NET_4_6 ) && ENABLE_MONO
			LOG( "<color=#FFFFFF>★★★MONO(DynamicMethod ILGenerator)が有効です★★★</color>" ) ;
#endif

		//------------------------------------------------------------------------------------------
		// MessagePack の設定

#if MESSAGE_PACK_ENABLED

#if MESSAGE_PACK_IL2CPP
			// IL2CPP 用コード
			Debug.Log( "[IL2CPP用の自動生成コードを使用する]" ) ;

			MessagePack.Resolvers.StaticCompositeResolver.Instance.Register
			(
				MessagePack.Resolvers.GeneratedResolver.Instance,
				MessagePack.Unity.UnityResolver.Instance,
				MessagePack.Unity.Extension.UnityBlitWithPrimitiveArrayResolver.Instance,
				MessagePack.Resolvers.StandardResolver.Instance
			) ;

			MessagePackSerializerOptions option = MessagePackSerializerOptions.Standard.WithResolver( MessagePack.Resolvers.StaticCompositeResolver.Instance ) ;
			MessagePackSerializer.DefaultOptions = option ;
#else
			// 汎用コード

			// Private アクセスは常に許可
			MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.StandardResolverAllowPrivate.Options ;
#endif

#endif

			//------------------------------------------------------------------------------------------



			//--------------------------------------------------------------------------
			// SimpleDataPack のテスト

			int si, sl = 1000 ;

//			var o1 = new T() ;
//			var o1 = new List<MyData.MySample_W>() ;
			var o0 = new MyData.MyObject_W[ sl ]  ;
//			var o0 = new MyData.MyStruct_W[ sl ]  ;

			for( si  = 0 ; si <  sl ; si ++ )
			{
//				o1.Add( new MyData.MySample_W() ) ;
				o0[ si ] = new MyData.MyObject_W() ;
//				o0[ si ] = new MyData.MyStruct_W() ;
			}

//			await RunDebug<List<MyData.MySample_W>>() ;
//			await RunDebug<MyData.MySample_W[]>() ;
			var r = await RunDebug( o0 ) ;
/*
			LOG( "P120 : " + r[ sl - 1 ].P120.GetType().Name ) ;
			LOG( "P121 : " + r[ sl - 1 ].P121.GetType().Name ) ;
			LOG( "P122 : " + r[ sl - 1 ].P122[ 0 ].GetType().Name ) ;
			LOG( "P123 : " + r[ sl - 1 ].P123[ 1 ].GetType().Name ) ;
*/
			//----------------------------------------------------------
/*
			List<IMyInterface> o1 = new List<IMyInterface>() ;

			int si, sl = 100 ;
			for( si  = 0 ; si <  sl ; si ++ )
			{
				int st = si % 2 ;
				switch( st )
				{
					case 0: o1.Add( new MyInterface_Type0() ) ; break ;
					case 1: o1.Add( new MyInterface_Type1() ) ; break ;
				}
			}


			Debug.Log( "[S]Count : " + o1.Count ) ;

//			var o1 = new MyInterface_Type2() ;
//			await RunDebug( ( IMyInterface )o1 ) ;
			var r = await RunDebug( o1 ) ;

			Debug.Log( "[D]Count : " + r.Count ) ;
			Debug.Log( "T0 : " + r[ sl - 2 ].GetType().Name ) ;
			Debug.Log( "T1 : " + r[ sl - 1 ].GetType().Name ) ;
*/

			await Yield() ;
		}

		//-------------------------------------------------------------------------------------------


		public async UniTask<T> RunDebug<T>( T o1 )// where T : class,new()
		{
			LOG( "<color=#7F7FFF>==================== SimpleDataPack 検証 ====================</color>" ) ;

			Type objectType = typeof( T ) ;
			LOG( "<color=#FFDF3F>対象 : " + objectType.Name + "</color>" ) ;
			if( objectType.IsArray == true )
			{
				Array ato = ( Array )( ( System.Object )o1 ) ;
				LOG( "<color=#FFDF3F>Array 型 : 件数 = " + ato.Length + "</color>" ) ;
			}
			else
			if( objectType.IsGenericType == true && objectType.GetGenericTypeDefinition() == typeof( List<> ) )
			{
				IList lto = ( IList )( ( System.Object )o1 ) ;
				LOG( "<color=#FFDF3F>List 型 : 件数 = " + lto.Count + "</color>" ) ;
			}
			else
			if( objectType.IsGenericType == true && objectType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
			{
				IDictionary dto = ( IDictionary )( ( System.Object )o1 ) ;
				LOG( "<color=#FFDF3F>Dictionary 型 : 件数 = " + dto.Count + "</color>" ) ;
			}

			//----------------------------------

			// ビッグエンディアン
//			SimpleDataPack.IsBigEndian = true ;

			// 高速展開用アダプターの使用を制限する
//			SimpleDataPack.ExternalAdapterDisabled = true ;

			SimpleDataPack.PriorityTypes priorityType = SimpleDataPack.PriorityTypes.Speed ;

			if( SimpleDataPack.ExternalAdapterEnabled == true && SimpleDataPack.ExternalAdapterDisabled == false )
			{
				LOG( "<color=#DFFF3F>☆☆☆自動生成コードによる高速処理が有効☆☆☆</color>" ) ;
			}
			else
			{
				LOG( "<color=#DFDFDF>★★★リフレクションによる通常処理が有効★★★</color>" ) ;
			}

			LOG( "<color=#7FFFDF>優先 : " + priorityType + "</color>" ) ;

			SimpleDataPack.Clear() ;


			//------------------------------------------------------------------------------------------
			// 以下、シリアライズ関係

			float t1 ;

			// SimpleDataPack
			t1 = Time.realtimeSinceStartup ;
			byte[] data1 = SimpleDataPack.Serialize( o1, priorityType:priorityType ) ;
			t1 = Time.realtimeSinceStartup - t1 ;

			LOG( "<color=#00FF00>[SimpleDataPack]シリアライズ時間(１回目) = " + t1 + "</color>" ) ;

			if( data1 == null )
			{
				LOG( "[SimpleDataPack]シリアライズに失敗しました(１回目)" ) ;
			}
			else
			{
				LOG( "<color=#00FF7F>[SimpledataPack]★★★シリアライズに成功しました(１回目) : Size = " + data1.Length + "★★★</color>" ) ;

//				StorageAccessor.Save( "Pack.bin", data1 ) ;
			}

			await Yield() ;

			//----------------------------------
#if MESSAGE_PACK_ENABLED
			// MessagePack 
			t1 = Time.realtimeSinceStartup ;
			byte[] m_data1 = MessagePackSerializer.Serialize( o1, MessagePackSerializer.DefaultOptions ) ;

//			var mo = new DummyData() ;
//			byte[] m_data1 = MessagePackSerializer.Serialize( mo ) ;
			LOG( "<color=#00FF00>[MessagePack]シリアライズ時間(１回目) = " + ( Time.realtimeSinceStartup - t1 ) + "</color>" ) ;

			if( m_data1 == null )
			{
				LOG( "[MessagePack]シリアライズに失敗しました(１回目)" ) ;
			}
			else
			{
				LOG( "<color=#00FF7F>★★★[MessagePack]シリアライズに成功しました(１回目) : Size = " + m_data1.Length + "★★★</color>" ) ;

//				StorageAccessor.Save( "Pack.bin", data ) ;
			}

			await Yield() ;
#endif
			//------------------------------------------------------------------------------------------
			// 以下、デシリアライズ

			// アダプターキャッシュクリア
//			SimpleDataPack.Clear() ;

			// SimpleDataPack
			t1 = Time.realtimeSinceStartup ;
			var sd1 = SimpleDataPack.Deserialize<T>( data1 ) ;
			t1 = Time.realtimeSinceStartup - t1 ;

			LOG( "<color=#00FFFF>[SimpleDataPack]デシリアライズ時間(１回目) = " + t1 + "</color>" ) ;

			if( sd1 == null )
			{
				LOG( "<color=#FF7F00>[SimpleDataPack]デシリアライズに失敗しました(１回目)</color>" ) ;
			}
			else
			{
				LOG( "<color=#00FFFF>[SimpleDataPack]★★★デシリアライズに成功しました(１回目)★★★</color>" ) ;

			}

			await Yield() ;

			//----------------------------------
#if MESSAGE_PACK_ENABLED
			// MessagePack
			t1 = Time.realtimeSinceStartup ;
			var md1 = MessagePackSerializer.Deserialize<T>( m_data1, MessagePackSerializer.DefaultOptions ) ;
			LOG( "<color=#00FFFF>[MessagePack]デシリアライズ時間(１回目) = " + ( Time.realtimeSinceStartup - t1 ) + "</color>" ) ;

			if( md1 == null )
			{
				LOG( "<color=#FF7F00>[MessagePack]デシリアライズに失敗しました(１回目)</color>" ) ;
			}
			else
			{
				LOG( "<color=#00FFFF>[MessagePack]★★★デシリアライズに成功しました(１回目)★★★</color>" ) ;
			}

			await Yield() ;
#endif
			//------------------------------------------------------------------------------------------
			// Json のシリアライズ
/*
			float tjs = Time.realtimeSinceStartup ;
			byte[] json_t = SimpleDataPack.Serialize( o1, true, true, SimpleDataPack.PriorityTypes.Speed ) ;
			if( json_t != null && json_t.Length >  0 )
			{
				LOG( "<color=#FF7FFF>Json のシリアライズにかかった時間 : " + ( Time.realtimeSinceStartup - tjs ) + "</color>" ) ;
				Debug.Log( "Json --------------------------\n" + Encoding.UTF8.GetString( json_t ) ) ;
			}

			await Yield() ;
*/

			//------------------------------------------------------------------------------------------
			// JSON のデシリアライズ
/*
			float tjd = Time.realtimeSinceStartup ;
			var json_o = SimpleDataPack.Deserialize<T>( json_t, true ) ;
			if( json_o != null )
			{
				LOG( "<color=#FF7FFF>Json のデシリアライズにかかった時間 : " + ( Time.realtimeSinceStartup - tjd ) + "</color>" ) ;

				//-----------------------------------------------------------------------------------------

				// Json から復号したオブジェクトをシリアライズして、直接オブジェクトをシリアライズしたものと一致するか確認

//				SimpleDataPack.ExternalAdapterDisabled = true ;

				var data9 = SimpleDataPack.Serialize( json_o, priorityType:priorityType ) ;

				int l0 = data1.Length ;
				int l1 = data9.Length ;

				LOG( "サイズ比較 : L0 = " + l0 + " ・ L1 = " + l1 ) ;
				if( l0 == l1 )
				{
					int i ;
					for( i  = 0 ; i <  l0 ; i ++ )
					{
						if( data1[ i ] != data9[ i ] )
						{
							LOG( "<color=#FFFF00>値が異なる : o = " + i + " v0 = " + data1[ i ] + " v1 = " + data9[ i ] + "</color>" ) ;
							break ;
						}
					}

					if( i == l0 )
					{
						LOG( "<color=#FF9FFF>★★★[JSONのEncode・Decode]サイズもデータも全て同一★★★ : Size = " + l0 + "</color>" ) ;
					}
					else
					{
						LOG( "<color=#FF7F00>★★★[JSONのEncode・Decode]データが異なる箇所がある★★★ : Size = " + l0 + "</color>" ) ;
					}
				}
				else
				{
					LOG( "<color=#FF7F00>★★★[JSONのEncode・Decode]データサイズが異なる★★★ : Size = " + l0 + " != " + l1 + "</color>" ) ;
				}
			}
			else
			{
				LOG( "<color=#FF7F00>Json のデシリアライズに失敗しました</color>" ) ;
			}
*/
			return sd1 ;
		}

		//===================================================================================================================
		// ログ表示

		private readonly StringBuilder m_SB = new StringBuilder() ;

		private void LOG( string log )
		{
			m_SB.Append( log ) ;
			m_SB.Append( "\n" ) ;

			m_Log.Text = m_SB.ToString() ;

			m_ScrollView.ContentSize = m_Log.Height ;

			float y = m_ScrollView.ContentSize - m_ScrollView.ViewSize ;
			if( y <  0 )
			{
				y  = 0 ;
			}
			m_ScrollView.ContentPosition = y ;

			//----------------------------------
			Debug.Log( log ) ;
		}
	}
}

//---------------------------------------------------------------------------------------------

#if !MESSAGE_PACK_ENABLED

//---------------------------------------------------------------------------------------------
// MessagePack のためのダミー記述

namespace MessagePack
{
	public class MessagePackObjectAttribute : Attribute
	{
		public MessagePackObjectAttribute( bool keyAsPropertyName = false )
		{
		}
	}

	public class KeyAttribute : Attribute
	{
		public KeyAttribute( int index )
		{
		}
	}

	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
	public class UnionAttribute : Attribute
	{
		public UnionAttribute( int index, Type type )
		{
		}
	}
}

#endif
