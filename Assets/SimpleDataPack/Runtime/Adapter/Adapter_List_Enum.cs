using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
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

			List<T> elements = new List<T>( length ) ;

			//----------------------------------

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	//------------------------------------------------------------

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
							writer.PutByteN( ( System.Byte? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutSByteN( ( System.SByte? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutInt16N( ( System.Int16? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutUInt16N( ( System.UInt16? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutInt32N( ( System.Int32? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutUInt32N( ( System.UInt32? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutInt64N( ( System.Int64? )( ( System.Object )elements[ index ] ) ) ;
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
							writer.PutUInt64N( ( System.UInt64? )( ( System.Object )elements[ index ] ) ) ;
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

			List<T> elements = new List<T>( length ) ;

			//----------------------------------

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}
}
