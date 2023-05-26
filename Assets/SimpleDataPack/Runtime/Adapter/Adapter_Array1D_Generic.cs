using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// １次元

	/// <summary>
	/// T が確定値のアレイアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DGenericAdapter<T> : IAdapter
	{
		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			//--------------

			T[] elements = entity as T[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得

			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ typeof( T ) ].Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				serialize( elements[ index_0 ], writer ) ;
			}
		}

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}

			// ランクは 1 限定

			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				return new T[ 0 ] ;
			}

			T[] elements = new T[ length_0 ] ;

			//----------------------------------

			// 高速化のためにデリゲート取得

			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ typeof( T ) ].Deserialize ;

//			float t = Time.realtimeSinceStartup ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = ( T )deserialize( reader ) ;
			}

//			Debug.Log( "<color=#FFFF00>展開時間 : " + ( Time.realtimeSinceStartup - t ) + " " + typeof( T ) + "</color>" ) ;

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( T[] elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array1DGenericAdapter<T> adapter ;

			Type type = typeof( T[] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array1DGenericAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array1DGenericAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static T[] GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array1DGenericAdapter<T> adapter ;

			Type type = typeof( T[] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array1DGenericAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array1DGenericAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			return adapter.DeserializeT( reader ) ;
		}

		//-----------------------------------

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void SerializeT( T[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------
			// ランクは 1 限定

			writer.PutByte( 1 ) ;

			//--------------

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得

			IAdapter adapter = m_DataConverter.GetAdapter( typeof( T ) ) ;
			Action<System.Object,ByteStream> serialize = adapter.Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				serialize( elements[ index_0 ], writer ) ;
			}
		}

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public T[] DeserializeT( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}

			//----------------------------------
			// ランクは 1 限定

			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				return new T[ 0 ] ;
			}

			T[] elements = new T[ length_0 ] ;

			//----------------------------------

			// 高速化のためにデリゲート取得

			IAdapter adapter = m_DataConverter.GetAdapter( typeof( T ) ) ;
			Func<ByteStream,System.Object> deserialize = adapter.Deserialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = ( T )deserialize( reader ) ;
			}

			return elements ;
		}
	}

	//============================================================================================
	// IL2CPP ビルド時のリフレクション版用

	/// <summary>
	/// T が確定値のアレイアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DGenericReflectionAdapter : IAdapter
	{
		private readonly Type	m_ObjectType ;
		private readonly Type	m_ElementType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="elementType"></param>
		public Array1DGenericReflectionAdapter( Type objectType, Type elementType )
		{
			m_ObjectType	= objectType ;
			m_ElementType	= elementType ;
		}

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			//--------------

			var elements = entity as Array ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得

			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ m_ElementType ].Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				serialize( elements.GetValue( index_0 ), writer ) ;
			}
		}

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}

			// ランクは 1 限定

			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				return ( System.Object )Array.CreateInstance( m_ElementType, 0 ) ; ;
			}

			var elements = Array.CreateInstance( m_ElementType, length_0 ) ;

			//----------------------------------

			// 高速化のためにデリゲート取得

			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ m_ElementType ].Deserialize ;

//			float t = Time.realtimeSinceStartup ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements.SetValue( deserialize( reader ), index_0 ) ;
			}

//			Debug.Log( "<color=#FFFF00>展開時間 : " + ( Time.realtimeSinceStartup - t ) + " " + typeof( T ) + "</color>" ) ;

			return elements ;
		}
	}
}
