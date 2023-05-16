using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// ３次元

	/// <summary>
	/// Enum[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array3DEnumAdapter<T> : IAdapter
	{
		private readonly Type enumType ;
		private readonly Action<T[,,],int,int,int,ByteStream>	SetValue ;
		private readonly Action<T[,,],int,int,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array3DEnumAdapter()
		{
			enumType			= typeof( T ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutByte( ( System.Byte )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetByte() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutSByte( ( System.SByte )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetSByte() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt16( ( System.Int16 )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetInt16() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt16( ( System.UInt16 )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetUInt16() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt32( ( System.Int32 )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetInt32() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt32( ( System.UInt32 )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetUInt32() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt64( ( System.Int64 )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetInt64() ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt64( ( System.UInt64 )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements[ index_0, index_1, index_2 ] = ( T )Enum.ToObject( enumType, reader.GetUInt64() ) ;
								}
							}
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
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 3 限定
			writer.PutByte( 3 ) ;

			T[,,] elements = entity as T[,,] ;

			int length_0 = elements.Length ;
			int length_1 = elements.Length ;
			int length_2 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_2 ) ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, length_1, length_2, writer ) ;
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

			// ランクは 3 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 )
			{
				return new T[ 0, 0, 0 ] ;
			}

			T[,,] elements = new T[ length_0, length_1, length_2 ] ;

			GetValue( elements, length_0, length_1, length_2, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// Enum[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array3DEnumNAdapter<T> : IAdapter
	{
		private readonly Type enumType ;
		private readonly Action<T[,,],int,int,int,ByteStream>	SetValue ;
		private readonly Action<T[,,],int,int,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array3DEnumNAdapter()
		{
			enumType			= Nullable.GetUnderlyingType( typeof( T ) ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutByteN( ( System.Byte? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Byte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetByteN() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutSByteN( ( System.SByte? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.SByte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetSByteN() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt16N( ( System.Int16? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Int16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetInt16N() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt16N( ( System.UInt16? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.UInt16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetUInt16N() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt32N( ( System.Int32? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Int32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetInt32N() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt32N( ( System.UInt32? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.UInt32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetUInt32N() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt64N( ( System.Int64? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Int64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetInt64N() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt64N( ( System.UInt64? )( ( System.Object )elements[ index_0, index_1, index_2 ] ) ) ;
								}
							}
						}
					} ;
					GetValue = ( T[,,] elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.UInt64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetUInt64N() ;
									elements[ index_0, index_1, index_2 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
								}
							}
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
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 3 限定
			writer.PutByte( 3 ) ;

			T[,,] elements = entity as T[,,] ;

			int length_0 = elements.Length ;
			int length_1 = elements.Length ;
			int length_2 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_2 ) ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, length_1, length_2, writer ) ;
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

			// ランクは 3 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 )
			{
				return new T[ 0, 0, 0 ] ;
			}

			T[,,] elements = new T[ length_0, length_1, length_2 ] ;

			GetValue( elements, length_0, length_1, length_2, reader ) ;

			return elements ;
		}
	}
}
