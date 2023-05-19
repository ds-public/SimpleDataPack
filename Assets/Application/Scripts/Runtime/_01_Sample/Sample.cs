using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Text ;

using UnityEngine ;

using Cysharp.Threading.Tasks ;

using uGUIHelper ;

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

#if NET_STANDARD_2_1 && ENABLE_MONO
			LOG( "<color=#FFFFFF>MONOが有効です</color>" ) ;
#endif
			//--------------------------------------------------------------------------
			// SimpleDataPack のテスト

			int si, sl = 1 ;

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
			var o1 = await RunDebug( o0 ) ;

			await Yield() ;
		}

		//--------------------------------------------------------------------------------------------

		public async UniTask<T> RunDebug<T>( T o1 )// where T : class,new()
		{
			LOG( "<color=#7F7FFF>==================== SimpleDataPack 検証 ====================</color>" ) ;

			//----------------------------------------------------------

			int i ;

			// 高速アダプター設定
//			SimpleDataPack.SetAdapter( new SimpleDataPackAdapter() ) ;


	#if false
			byte[,,] a = new byte[ 2, 3, 4 ]
			{
				{
					{  0,  1,  2,  3 },
					{  4,  5,  6,  7 },
					{  8,  9, 10, 11 }
				},
				{
					{ 12, 13, 14, 15 },
					{ 16, 17, 18, 19 },
					{ 20, 21, 22, 23 }
				},
			} ;


			Debug.Log( "L0 : " + a.GetLength( 0 ) + " L1 : " + a.GetLength( 1 ) + " L2 : " + a.GetLength( 2 ) ) ;

			Debug.Log( "Length : " + a.Length ) ;
			Debug.Log( "V:" + a.GetValue( new int[]{ 0, 1, 0 } ) ) ;


			Type t = typeof( Array ) ;

			Debug.Log( "Name : " + t.Name ) ;
			Debug.Log( "IsClass : " + t.IsClass ) ;
			Debug.Log( "IsValueType : " + t.IsValueType ) ;
			Debug.Log( "IsPremtive : " + t.IsPrimitive ) ;
			Debug.Log( "IsEnum : " + t.IsEnum ) ;
	#endif

			// ビッグエンディアン
//			SimpleDataPack.IsBigEndian = true ;

			// 高速展開用アダプターの使用を制限する
//			SimpleDataPack.ExternalAdapterDisabled = true ;

			SimpleDataPack.PriorityTypes priorityType = SimpleDataPack.PriorityTypes.Speed ;

			if( SimpleDataPack.ExternalAdapterEnabled == true && SimpleDataPack.ExternalAdapterDisabled == false )
			{
				LOG( "<color=#DFFF3F>自動生成コードによる高速処理が有効</color>" ) ;
			}
			else
			{
				LOG( "<color=#DFDFDF>リフレクションによる通常処理</color>" ) ;
			}

			LOG( "<color=#7FFFDF>優先 : " + priorityType + "</color>" ) ;

			SimpleDataPack.Clear() ;


			await WaitForSeconds( 0.1f ) ;

			//------------------------------------------------------------------------------------------

//			o1[ sl - 1 ].P5 = 12345 ;
//			o1[ sl - 1 ].Modify_1() ;
//			Debug.Log( "-----設定変えました？ : " + o1[ sl - 1 ].P5 ) ;

			//----------------------------------------------------------
	/*
			byte[] wb = new byte[ 4 ] ;
	//			int cv = -12345678 ;
			uint cv =  12345678 ;

			wb[ 0 ] = ( byte )  cv ;
			wb[ 1 ] = ( byte )( cv >>  8 ) ;
			wb[ 2 ] = ( byte )( cv >> 16 ) ;
			wb[ 3 ] = ( byte )( cv >> 24 ) ;

			uint dv = ( uint )( wb[ 0 ] | ( wb[ 1 ] <<  8 ) | ( wb[ 2 ] << 16 ) | ( wb[ 3 ] << 24 ) ) ;

			Debug.Log( "-----dv値 : " + dv ) ;
	*/
	/*
			System.SByte s0 = -120 ;
			System.UInt16 s1 = ( System.Byte )s0 ;
			Debug.Log( "キャストチェック1 : " + s1 ) ;
			System.UInt16 s2 = ( System.UInt16 )s0 ;
			Debug.Log( "キャストチェック2 : " + s2 ) ;

			System.SByte s3 = ( System.SByte )s1 ;
			Debug.Log( "キャストチェック3 : " + s3 ) ;

			System.SByte s4 = ( System.SByte )s2 ;
			Debug.Log( "キャストチェック4 : " + s4 ) ;
	*/


	//			o1.Modify_1() ;

	/*
			Type t105 = o1.P105.GetType() ;
			Debug.Log( "------------タイプ名 P105 : " + SimpleDataPack.GetTypeName( t105 ) ) ;

			Type t107 = o1.P107.GetType() ;
			Debug.Log( "------------タイプ名 P107 : " + SimpleDataPack.GetTypeName( t107 ) ) ;

			Type t108 = o1.P108.GetType() ;
			Debug.Log( "------------タイプ名 P108 : " + SimpleDataPack.GetTypeName( t108 ) ) ;

			Type t109= o1.P109.GetType() ;
			Debug.Log( "------------タイプ名 P109 : " + SimpleDataPack.GetTypeName( t109 ) ) ;

			Type t110= o1.P110.GetType() ;
			Debug.Log( "------------タイプ名 P110 : " + SimpleDataPack.GetTypeName( t110 ) ) ;

			Type t111= o1.P111.GetType() ;
			Debug.Log( "------------タイプ名 P111 : " + SimpleDataPack.GetTypeName( t111 ) ) ;

			Type t112= o1.P112.GetType() ;
			Debug.Log( "------------タイプ名 P112 : " + SimpleDataPack.GetTypeName( t112 ) ) ;

			Type t113= o1.P113.GetType() ;
			Debug.Log( "------------タイプ名 P113 : " + SimpleDataPack.GetTypeName( t113 ) ) ;

			Type t114 = o1.P114.GetType() ;
			Debug.Log( "------------タイプ名 P114 : " + SimpleDataPack.GetTypeName( t114 ) ) ;


	/*			o1.P104[ 0 ].C_Param = "うんぽこぴー" ;
			o1.P104[ 1 ].C_Param = "ちょりそーん" ;*/

	//			MyData.MyStruct s = new MyData.MyStruct( 99 ) ;
	//			s.A_Param = 55555 ;
	//			s.C_Param = "ぽややん" ;


			//------------------------------------------------------------------------------------------
			// Json 比較
	/*
			float jpt1 = Time.realtimeSinceStartup ;
			byte[] json_dummy = SimpleDataPack.Serialize( o1, true, true ) ;
			if( json_dummy != null && json_dummy.Length >  0 )
			{
				Debug.Log( "<color=#FF7FFF>Json のシリアライズにかかった時間(プライマル:1) : " + ( Time.realtimeSinceStartup - jpt1 ) + "</color>" ) ;
				Debug.Log( "サイズ:" + json_dummy.Length ) ;

				Debug.Log( "Json(P)----------\n" + Encoding.UTF8.GetString( json_dummy ) ) ;
			}

			await Yield() ;

			float jpt2 = Time.realtimeSinceStartup ;
			string json_label = JsonUtility.ToJson( o1, true ) ;
			if( string.IsNullOrEmpty( json_label ) == false )
			{
				Debug.Log( "<color=#FF7FFF>Json のシリアライズにかかった時間(ユーティル:1) : " + ( Time.realtimeSinceStartup - jpt2 ) + "</color>" ) ;
				Debug.Log( "サイズ:" + json_label.Length ) ;

				Debug.Log( "Json(U)----------\n" + json_label) ;
			}

			await Yield() ;
	*/
	/*
			jpt1 = Time.realtimeSinceStartup ;
			json_dummy = SimpleDataPack.Serialize( o1, true, true ) ;
			if( json_dummy != null && json_dummy.Length >  0 )
			{
				Debug.Log( "<color=#FF7FFF>Json のシリアライズにかかった時間(プライマル:2) : " + ( Time.realtimeSinceStartup - jpt1 ) + "</color>" ) ;
				Debug.Log( "サイズ:" + json_dummy.Length ) ;

				Debug.Log( "Json(P)----------\n" + Encoding.UTF8.GetString( json_dummy ) ) ;
			}

			await Yield() ;

			jpt2 = Time.realtimeSinceStartup ;
			json_label = JsonUtility.ToJson( o1, true ) ;
			if( string.IsNullOrEmpty( json_label ) == false )
			{
				Debug.Log( "<color=#FF7FFF>Json のシリアライズにかかった時間(ユーティル:2) : " + ( Time.realtimeSinceStartup - jpt2 ) + "</color>" ) ;
				Debug.Log( "サイズ:" + json_label.Length ) ;

				Debug.Log( "Json(U)----------\n" + json_label) ;
			}

			await Yield() ;
	*/
			//------------------------------------------------------------------------------------------
			// 以下、シリアライズ関係

			float t1 ;

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

	/*
			t1 = Time.realtimeSinceStartup ;
			byte[] m_data1 = MessagePackSerializer.Serialize( o1, MessagePackSerializer.DefaultOptions ) ;
			Debug.Log( "<color=#00FF00>[MessagePack]シリアライズ時間(１回目) = " + ( Time.realtimeSinceStartup - t1 ) + "</color>" ) ;

			if( m_data1 == null )
			{
				Debug.LogWarning( "[MessagePack]シリアライズに失敗しました(１回目)" ) ;
			}
			else
			{
				Debug.Log( "<color=#00FF7F>★★★[MessagePack]シリアライズに成功しました(１回目) : Size = " + m_data1.Length + "★★★</color>" ) ;

	//				StorageAccessor.Save( "Pack.bin", data ) ;
			}
	*/
			await Yield() ;



#if false
			//--------------

	//			MyData.MySample o2 = new MyData.MySample() ;
			MyData.MySampleSub o2 = new MyData.MySampleSub() ;
	//			o2.Modify_2() ;

			t2 = Time.realtimeSinceStartup ;
			byte[] data2 = SimpleDataPack.Serialize( o2 ) ;
			Debug.Log( "<color=#00FF00>[SimpledataPack]シリアライズ時間(２回目) = " + ( Time.realtimeSinceStartup - t2 ) + "</color>" ) ;

			if( data2 == null )
			{
				Debug.LogWarning( "[SimpleDataPack]シリアライズに失敗しました(２回目)" ) ;
			}
			else
			{
				Debug.Log( "<color=#00FF7F>★★★[SimpleDataPack]シリアライズに成功しました(２回目) : Size = " + data2.Length + "★★★</color>" ) ;

	//				StorageAccessor.Save( "Pack.bin", data ) ;
			}

			await Yield() ;

			t2 = Time.realtimeSinceStartup ;
			byte[] m_data2 = MessagePackSerializer.Serialize( o2, MessagePackSerializer.DefaultOptions ) ;
			Debug.Log( "<color=#00FF00>[MessagePack]シリアライズ時間(２回目) = " + ( Time.realtimeSinceStartup - t2 ) + "</color>" ) ;

			if( m_data2 == null )
			{
				Debug.LogWarning( "[MessagePack]シリアライズに失敗しました(２回目)" ) ;
			}
			else
			{
				Debug.Log( "<color=#00FF7F>★★★[MessagePack]シリアライズに成功しました(２回目) : Size = " + m_data2.Length + "★★★</color>" ) ;

	//				StorageAccessor.Save( "Pack.bin", data ) ;
			}

			await Yield() ;
#endif
//------------------------------------------------------------------------------------------
// Json 関係
/*
			float tje = Time.realtimeSinceStartup ;

			byte[] json = SimpleDataPack.Serialize( o1, true, true, SimpleDataPack.PriorityTypes.Speed ) ;
			if( json != null && json.Length >  0 )
			{
				Debug.Log( "<color=#FF7FFF>Json のシリアライズにかかった時間 : " + ( Time.realtimeSinceStartup - tje ) + "</color>" ) ;

				Debug.Log( "Json --------------------------\n" + Encoding.UTF8.GetString( json ) ) ;
			}

			await Yield() ;
*/
//-----------------------------------------------------------
// 元に戻すテスト
#if false
			Debug.Log( "<color=#FF7FFF>-----------------------------------</color>" ) ;

			float tjd = Time.realtimeSinceStartup ;

			var dj = SimpleDataPack.Deserialize<MyData.MySample>( json, true ) ;
			if( dj != null )
			{
				Debug.Log( "<color=#FF7FFF>Json のデシリアライズにかかった時間 : " + ( Time.realtimeSinceStartup - tjd ) + "</color>" ) ;

				Debug.Log( "Json からの復帰成功" ) ;
				Debug.Log( "Json - P10:" + dj.P10 + " vs " + o1.P10 + " : " + ( o1.P10 == dj.P10 ) ) ;
	/*
				Debug.Log( "[JSON]Z_Struct.A_Param : " + dj.Z_Struct.A_Param ) ;
				Debug.Log( "[JSON]Z_Struct.B_Param : " + dj.Z_Struct.B_Param.ToString() ) ;

				Debug.Log( "[JSON]Z_Struct_C_param : " + dj.Z_Struct.C_Param ) ;
	*/


				var data9 = SimpleDataPack.Serialize( dj ) ;

				int l0 = data1.Length ;
				int l1 = data9.Length ;

				Debug.Log( "サイズ比較 L0 = " + l0 + " L1 = " + l1 ) ;
				if( l0 == l1 )
				{
					int i ;
					for( i  = 0 ; i <  l0 ; i ++ )
					{
						if( data1[ i ] != data9[ i ] )
						{
							Debug.Log( "<color=#FFFF00>値が異なる : o = " + i + " v0 = " + data1[ i ] + " v1 = " + data9[ i ] + "</color>" ) ;
						}
					}

					if( i == l0 )
					{
						Debug.Log( "<color=#00FFFF>★★★[JSONのEncode・Decode]サイズもデータも全て同一★★★ : Size = " + l0 + "</color>" ) ;
					}
				}
			}
			else
			{
				Debug.Log( "<color=#FF3F00>Json からの復帰に失敗しました</color>" ) ;
			}

			await Yield() ;
#endif
//------------------------------------------------------------------------------------------
// 以下、デシリアライズ

// アダプターキャッシュクリア
//			SimpleDataPack.Clear() ;

//#if false
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

	//				MyData.MySample_W w = sd1 as MyData.MySample_W ;

	//				var a = sd1 as MyData.MySample_W[] ;
	//				Debug.Log( $"<color=#FFFF00>本当に展開できたのか確認する [ {sl-1} ].P5 = " + a[ sl - 1 ].P5 + "</color>" ) ;				
	//				Debug.Log( $"<color=#FFFF00>本当に展開できたのか確認する [ {sl-1} ].P114 = " + a[ sl - 1 ].P114[ 1 ][ 1, 2 ] + "</color>" ) ;				

//				var b = sd1 as MyData.MyStruct_W[] ;
//				Debug.Log( $"<color=#FFFF00>本当に展開できたのか確認する [ {sl-1} ].A_param = " + b[ sl - 1 ].A_Param + " B_param = " + b[ sl - 1 ].B_Param + " C_Param = " + b[ sl - 1 ].C_Param  + "</color>" ) ;				


	//				Debug.Log( "sd1.P0 : " + w.P0 ) ;

				
	//				Debug.Log( "sd1.P13 : " + w.P13 ) ;
	/*				Debug.Log( "sd1.P14 : " + w.P14.ToShortDateString() ) ;
				Debug.Log( "sd1.P34 : " + w.P34.Length + " " + w.P34[ 0 ] + " " + w.P34[ 1 ] ) ;
				Debug.Log( "sd1.P35 : " + w.P35.Length + " " + w.P35[ 0 ] + " " + w.P35[ 1 ] ) ;
				Debug.Log( "sd1.P36 : " + w.P36.Length + " " + w.P36[ 0 ] + " " + w.P36[ 1 ] ) ;
				Debug.Log( "sd1.P37 : " + w.P37.Length + " " + w.P37[ 0 ] + " " + w.P37[ 1 ] ) ;
				Debug.Log( "sd1.P38 : " + w.P38.Length + " " + w.P38[ 0 ] + " " + w.P38[ 1 ]) ;

				Debug.Log( "sd1.P45 : " + w.P45.Length + " " + w.P45[ 0 ] + " " + w.P45[ 1 ]) ;
				Debug.Log( "sd1.P46 : " + w.P46.Length + " " + w.P46[ 0 ] + " " + w.P46[ 1 ]) ;
	*/
	//				Debug.Log( "sd1.P92 : " + w.P92.Count + " " + w.P92[ 0 ] + " " + w.P92[ 1 ]) ;


	/*				Debug.Log( "sd1.P30 : " + sd1.P30 ) ;
				Debug.Log( "sd1.P47 : " + sd1.P47[ 0 ] + " " + sd1.P47[ 1 ] ) ;
				Debug.Log( "sd1.P50 : " + sd1.P50[ 0 ] + " " + sd1.P50[ 1 ] ) ;
				Debug.Log( "sd1.P51 : " + sd1.P51[ 0 ] + " " + sd1.P51[ 1 ] ) ;
				Debug.Log( "sd1.P52 : " + sd1.P52[ 0 ] + " " + sd1.P52[ 1 ] ) ;
				Debug.Log( "sd1.P53 : " + sd1.P53[ 0 ] + " " + sd1.P53[ 1 ] ) ;
				Debug.Log( "sd1.P54 : " + sd1.P54[ 0 ] + " " + sd1.P54[ 1 ] ) ;
				Debug.Log( "sd1.P55 : " + sd1.P55[ 0 ] + " " + sd1.P55[ 1 ] ) ;

				Debug.Log( "sd1.P67 : " + sd1.P67[ 0 ] + " " + sd1.P67[ 1 ] ) ;
				Debug.Log( "sd1.P68 : " + sd1.P68[ 0 ] + " " + sd1.P68[ 1 ] ) ;

				Debug.Log( "sd1.P101 : " + sd1.P101[ 0 ] + " " + sd1.P101[ 1 ] + " " + sd1.P101[ 2 ] ) ;

				Debug.Log( "sd1.P102 : " + sd1.P102.C_Param ) ;
				Debug.Log( "sd1.P103 : " + sd1.P103.Value.C_Param ) ;
				Debug.Log( "sd1.P104 : " + sd1.P104[ 0 ].C_Param + " " + sd1.P104[ 1 ].C_Param ) ;



				Debug.Log( "sd1.P105 : " + sd1.P105[ 0 ].Value.C_Param + " " + sd1.P105[ 0 ].Value.A_Param + " " + sd1.P105[ 1 ] + " : " ) ;

				Debug.Log( "sd1.P106 : " + sd1.P106[ 0 ].C_Param ) ;
				

				Debug.Log( "sd1.P107 : " + sd1.P107[ 0 ].Value.A_Param + " " + sd1.P107[ 1 ] ) ;


				Debug.Log( "sd1.P108 : " + sd1.P108[ 0 ][ 0 ] + " " + sd1.P108[ 0 ][ 1 ] + " " + sd1.P108[ 0 ][ 2 ] ) ;
	*/
	//				Debug.Log( "sd1.P109 : " + w.P109[ 254 ] + " " + w.P109[ 255 ] ) ;
	//				Debug.Log( "sd1.P110 : " + w.P110[ 1, 2, 3 ] ) ;
	//				Debug.Log( "sd1.P111 : " + w.P111[ 0 ][ 0 ] + " " + w.P111[ 0 ][ 1 ] + " " + w.P111[ 0 ][ 2 ] ) ;
	/*				Debug.Log( "sd1.P112 : " + sd1.P112[ 1 ][ 2 ] ) ;

				Debug.Log( "sd1.P113 : " + sd1.P113[ 0 ][ 0, 0 ] ) ;
				Debug.Log( "sd1.P114 : " + sd1.P114[ 0 ][ 0, 0 ] ) ;*/
			}

			await Yield() ;
	/*
			t1 = Time.realtimeSinceStartup ;
			var md1 = MessagePackSerializer.Deserialize<T>( m_data1, MessagePackSerializer.DefaultOptions ) ;
			Debug.Log( "<color=#00FFFF>[MessagePack]デシリアライズ時間(１回目) = " + ( Time.realtimeSinceStartup - t1 ) + "</color>" ) ;

			if( md1 == null )
			{
				Debug.Log( "<color=#FF7F00>[MessagePack]デシリアライズに失敗しました(１回目)</color>" ) ;
			}
			else
			{
				Debug.Log( "<color=#00FFFF>[MessagePack]★★★デシリアライズに成功しました(１回目)★★★</color>" ) ;

	//				Debug.Log( "md1.P104 : " + md1.P104[ 0 ].C_Param + " " + md1.P104[ 1 ].C_Param ) ;

			}
	*/
			await Yield() ;
//#endif

#if false




			t2 = Time.realtimeSinceStartup ;
	//			var d2 = SimpleDataPack.Deserialize<MyData.MySample>( data2 ) ;
			var d2 = SimpleDataPack.Deserialize<MyData.MySampleSub>( data2 ) ;
			Debug.Log( "<color=#00FF00>[SimpleDataPack]デシリアライズ時間(２回目) = " + ( Time.realtimeSinceStartup - t2 ) + "</color>" ) ;

			if( d2 == null )
			{
				Debug.Log( "<color=#FF7F00>[SimpleDataPack]デシリアライズに失敗しました(２回目)</color>" ) ;
			}
			else
			{
				Debug.Log( "<color=#00FF00>[SimpleDataPack]★★★デシリアライズに成功しました(２回目)★★★</color>" ) ;
	/*
				Debug.Log( "Z_Struct.A_Param : " + d2.Z_Struct.A_Param ) ;
				Debug.Log( "Z_Struct.B_Param : " + d2.Z_Struct.B_Param.ToString() ) ;

				Debug.Log( "Z_Struct_C_param : " + d2.Z_Struct.C_Param ) ;*/
			}

			await Yield() ;



			t2 = Time.realtimeSinceStartup ;
	//			var md2 = MessagePackSerializer.Deserialize<MyData.MySample>( m_data2, MessagePackSerializer.DefaultOptions ) ;
			var md2 = MessagePackSerializer.Deserialize<MyData.MySampleSub>( m_data2, MessagePackSerializer.DefaultOptions ) ;
			Debug.Log( "<color=#00FF00>[MessagePack]デシリアライズ時間(２回目) = " + ( Time.realtimeSinceStartup - t2 ) + "</color>" ) ;

			if( md2 == null )
			{
				Debug.Log( "<color=#FF7F00>[MessagePack]デシリアライズに失敗しました(2２回目)</color>" ) ;
			}
			else
			{
				Debug.Log( "<color=#00FF00>[MessagePack]★★★デシリアライズに成功しました(２回目)★★★</color>" ) ;
			}

			await Yield() ;


#endif
//------------------------------------------------------------------------------------------
#if false
			float tjd = Time.realtimeSinceStartup ;

			var dj = SimpleDataPack.Deserialize<T>( json, true ) ;
			if( dj != null )
			{
				Debug.Log( "<color=#FF7FFF>Json のデシリアライズにかかった時間 : " + ( Time.realtimeSinceStartup - tjd ) + "</color>" ) ;

	/*				Debug.Log( "dj.P0 : " + dj.P0 ) ;
				Debug.Log( "dj.P13 : " + dj.P13 ) ;
				Debug.Log( "dj.P14 : " + dj.P14 ) ;
				Debug.Log( "dj.P30 : " + dj.P30 ) ;
				Debug.Log( "dj.P33 : " + dj.P33.Value ) ;
	*/
	//				Debug.Log( "dj.P34 : " + dj.P34[ 0 ] ) ;

	/*
				Debug.Log( "dj.P47 : " + dj.P47[ 0 ] ) ;
				Debug.Log( "dj.P50 : " + dj.P50[ 0 ] ) ;
				Debug.Log( "dj.P64 : " + dj.P64[ 1 ] ) ;
				Debug.Log( "dj.P67 : " + dj.P67[ 1 ].Value ) ;
				Debug.Log( "dj.P81 : " + dj.P81[ 0 ] ) ;
				Debug.Log( "dj.P84 : " + dj.P84[ 0 ] ) ;
				Debug.Log( "dj.P98 : " + dj.P98[ 1 ] ) ;
				Debug.Log( "dj.P101 : " + dj.P101[ 0 ].Value ) ;
				Debug.Log( "dj.P107 : " + dj.P107[ 0 ].Value.C_Param ) ;

				Debug.Log( "dj.P110 : " + dj.P110[ 0, 0, 1 ] + " " + o1.P110[ 0, 0, 1 ] ) ;
				Debug.Log( "dj.P111 : " + dj.P111[ 1 ][ 2 ] ) ;
				Debug.Log( "dj.P112 : " + dj.P112[ 1 ][ 2 ] ) ;

				Debug.Log( "dj.P114 : " + dj.P114[ 1 ][ 0, 0 ] ) ;
	*/
				//-----------------------------------------------------------------------------------------

				// Json から復号したオブジェクトをシリアライズして、直接オブジェクトをシリアライズしたものと一致するか確認

				SimpleDataPack.ExternalAdapterDisabled = true ;

				var data9 = SimpleDataPack.Serialize( dj, priorityType:priorityType ) ;

				int l0 = data1.Length ;
				int l1 = data9.Length ;

				Debug.Log( "サイズ比較 : L0 = " + l0 + " ・ L1 = " + l1 ) ;
				if( l0 == l1 )
				{
					for( i  = 0 ; i <  l0 ; i ++ )
					{
						if( data1[ i ] != data9[ i ] )
						{
							Debug.Log( "<color=#FFFF00>値が異なる : o = " + i + " v0 = " + data1[ i ] + " v1 = " + data9[ i ] + "</color>" ) ;
							break ;
						}
					}

					if( i == l0 )
					{
						Debug.Log( "<color=#00FFFF>★★★[JSONのEncode・Decode]サイズもデータも全て同一★★★ : Size = " + l0 + "</color>" ) ;
					}
					else
					{
						Debug.Log( "<color=#FF7F00>★★★[JSONのEncode・Decode]データが異なる箇所がある★★★ : Size = " + l0 + "</color>" ) ;
					}
				}
				else
				{
					Debug.Log( "<color=#FF7F00>★★★[JSONのEncode・Decode]データサイズが異なる★★★ : Size = " + l0 + " != " + l1 + "</color>" ) ;

				}
			}
			else
			{
				Debug.Log( "<color=#FF7F00>Json のデシリアライズに失敗しました</color>" ) ;
			}
#endif

//			return sd1 ;
			return default ;
		}

		//-------------------------------------------------------------------------------------------

		private StringBuilder m_SB = new StringBuilder() ;

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

