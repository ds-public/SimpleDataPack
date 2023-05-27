using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// List<Enum> アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListEnumAdapter<T> : IAdapter
	{
		private readonly Type enumType ;

		private readonly Action<List<T>,int,ByteStream>	SetValue ;
		private readonly Action<List<T>,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListEnumAdapter()
		{
			enumType			= typeof( T ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutByte( ( System.Byte )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetByte() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSByte( ( System.SByte )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetSByte() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt16( ( System.Int16 )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetInt16() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt16( ( System.UInt16 )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetUInt16() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt32( ( System.Int32 )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetInt32() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt32( ( System.UInt32 )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetUInt32() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt64( ( System.Int64 )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetInt64() ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt64( ( System.UInt64 )( ( System.Object )elements[ index ] ) ) ;
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( ( T )( Enum.ToObject( enumType, reader.GetUInt64() ) ) ) ;
						}
					} ;
				break ;
			}
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

			List<T> elements = entity as List<T> ;

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

			SetValue( elements, length, writer ) ;
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

			GetValue( elements, length, reader ) ;

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( List<T> elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			ListEnumAdapter<T> adapter ;

			Type type = typeof( List<T> ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( ListEnumAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new ListEnumAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static List<T> GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			ListEnumAdapter<T> adapter ;

			Type type = typeof( List<T> ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( ListEnumAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new ListEnumAdapter<T>() ;
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

			SetValue( elements, length, writer ) ;
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

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	//------------------------------------------------------------

	/// <summary>
	/// List<Enum?> アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListEnumNAdapter<T> : IAdapter
	{
		private readonly Type enumType ;

		private readonly Action<List<T>,int,ByteStream>	SetValue ;
		private readonly Action<List<T>,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListEnumNAdapter()
		{
			enumType			= Nullable.GetUnderlyingType( typeof( T ) ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.Byte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetByteN() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.SByte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetSByteN() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt16N() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt16N() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt32N() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt32N() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt64N() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( List<T> elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )( ( System.Object )elements[ index ] ) ) ; }
						}
					} ;
					GetValue = ( List<T> elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt64N() ;
							elements.Add( value == null ? default : ( T )( Enum.ToObject( enumType, value ) ) ) ;
						}
					} ;
				break ;
			}
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

			List<T> elements = entity as List<T> ;

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

			SetValue( elements, length, writer ) ;
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

			GetValue( elements, length, reader ) ;

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( List<T> elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			ListEnumNAdapter<T> adapter ;

			Type type = typeof( List<T> ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( ListEnumNAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new ListEnumNAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static List<T> GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			ListEnumNAdapter<T> adapter ;

			Type type = typeof( List<T> ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( ListEnumNAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new ListEnumNAdapter<T>() ;
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

			SetValue( elements, length, writer ) ;
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

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	/// <summary>
	/// List<Enum> アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListEnumVersatileAdapter : IAdapter
	{
		private readonly Type	m_ObjectType ;
		private readonly Type	enumType ;

		private readonly Action<IList,int,ByteStream>	SetValue ;
		private readonly Action<IList,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListEnumVersatileAdapter( Type objectType, Type elememtType )
		{
			m_ObjectType		= objectType ;
			enumType			= elememtType ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutByte( ( System.Byte )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetByte() ) ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSByte( ( System.SByte )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetSByte() ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt16( ( System.Int16 )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetInt16() ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt16( ( System.UInt16 )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetUInt16() ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt32( ( System.Int32 )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetInt32() ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt32( ( System.UInt32 )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetUInt32() ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt64( ( System.Int64 )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetInt64() ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt64( ( System.UInt64 )elements[ index ] ) ;
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.Add( Enum.ToObject( enumType, reader.GetUInt64() ) ) ;
						}
					} ;
				break ;
			}
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

			SetValue( elements, length, writer ) ;
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

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// List<Enum?> アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListEnumNVersatileAdapter : IAdapter
	{
		private readonly Type							m_ObjectType ;
		private readonly Type							nullableEnumType ;
		private readonly Type							enumType ;

		private readonly Action<IList,int,ByteStream>	SetValue ;
		private readonly Action<IList,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListEnumNVersatileAdapter( Type objectType, Type elementType )
		{
			m_ObjectType		= objectType ;

			nullableEnumType	= elementType ;
			enumType			= Nullable.GetUnderlyingType( nullableEnumType ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.Byte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetByteN() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.SByte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetSByteN() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt16N() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt16N() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt32N() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt32N() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt64N() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( IList elements, int length, ByteStream writer ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )elements[ index ] ) ; }
						}
					} ;
					GetValue = ( IList elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt64N() ;
							elements.Add( value == null ? null : Enum.ToObject( enumType, value ) ) ;
						}
					} ;
				break ;
			}
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

			SetValue( elements, length, writer ) ;
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

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}
}
