using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// T が確定値のリストアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListGenericAdapter<T> : IAdapter
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
				// null 且つ length = 0
				writer.PutByte( 0 ) ;
				return ;
			}

			var elements = entity as List<T> ;

			int length = elements.Count ;

			if( length == 0 )
			{
				// 空リスト
				writer.PutByte( 0 ) ;	// null ではない
				return ;
			}

			// 要素数を格納
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			Action<System.Object,ByteStream> serialize = ( ( IAdapter )ActiveAdapterCache[ typeof( T ) ] ).Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			for( int index  = 0 ; index <  length ; index ++ )
			{
				serialize( elements[ index ], writer ) ;
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
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			int length = ( int )_ ;

			if( length == 0 )
			{
				// 空リスト
				return new List<T>() ;
			}

			var elements = new List<T>( length ) ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			Func<ByteStream,System.Object> deserialize = ( ( IAdapter )ActiveAdapterCache[ typeof( T ) ] ).Deserialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( ( T )deserialize( reader ) ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( List<T> elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			ListGenericAdapter<T> adapter ;

			Type type = typeof( List<T> ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( ListGenericAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new ListGenericAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static List<T> GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			ListGenericAdapter<T> adapter ;

			Type type = typeof( List<T> ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( ListGenericAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new ListGenericAdapter<T>() ;
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
		public void SerializeT( List<T> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null 且つ length = 0
				writer.PutByte( 0 ) ;
				return ;
			}

			int length = elements.Count ;

			if( length == 0 )
			{
				// 空リスト
				writer.PutByte( 0 ) ;	// null ではない
				return ;
			}

			// 要素数を格納
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			IAdapter adapter = m_DataConverter.GetAdapter( typeof( T ) ) ;
			Action<System.Object,ByteStream> serialize = adapter.Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			for( int index  = 0 ; index <  length ; index ++ )
			{
				serialize( elements[ index ], writer ) ;
			}
		}

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public List<T> DeserializeT( ByteStream reader )
		{
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			int length = ( int )_ ;

			if( length == 0 )
			{
				// 空リスト
				return new List<T>() ;
			}

			var elements = new List<T>( length ) ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			IAdapter adapter = m_DataConverter.GetAdapter( typeof( T ) ) ;
			Func<ByteStream,System.Object> deserialize = adapter.Deserialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( ( T )deserialize( reader ) ) ;
			}

			return elements ;
		}
	}

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	/// <summary>
	/// T が確定値のリストアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListGenericVersatileAdapter : IAdapter
	{
		private readonly Type	m_ObjectType ;
		private readonly Type	m_ElementType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="elementType"></param>
		public ListGenericVersatileAdapter( Type objectType, Type elementType )
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
				// null 且つ length = 0
				writer.PutByte( 0 ) ;
				return ;
			}

			var elements = entity as IList ;

			int length = elements.Count ;

			if( length == 0 )
			{
				// 空リスト
				writer.PutByte( 0 ) ;	// null ではない
				return ;
			}

			// 要素数を格納
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			Action<System.Object,ByteStream> serialize = ( ( IAdapter )ActiveAdapterCache[ m_ElementType ] ).Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			for( int index  = 0 ; index <  length ; index ++ )
			{
				serialize( elements[ index ], writer ) ;
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
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			int length = ( int )_ ;

			var elements = ( IList )Activator.CreateInstance( m_ObjectType ) ;

			if( length == 0 )
			{
				// 空リスト
				return elements ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			Func<ByteStream,System.Object> deserialize = ( ( IAdapter )ActiveAdapterCache[ m_ElementType ] ).Deserialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( deserialize( reader ) ) ;
			}

			return elements ;
		}
	}



}
