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

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;

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

			//----------------------------------
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

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( T[,,] elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array3DEnumAdapter<T> adapter ;

			Type type = typeof( T[,,] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array3DEnumAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array3DEnumAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static T[,,] GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array3DEnumAdapter<T> adapter ;

			Type type = typeof( T[,,] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array3DEnumAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array3DEnumAdapter<T>() ;
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
		public void SerializeT( T[,,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------
			// ランクは 3 限定

			writer.PutByte( 3 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;

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
		public T[,,] DeserializeT( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}

			//----------------------------------
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

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;

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

			//----------------------------------
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

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( T[,,] elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array3DEnumNAdapter<T> adapter ;

			Type type = typeof( T[,,] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array3DEnumNAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array3DEnumNAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static T[,,] GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array3DEnumNAdapter<T> adapter ;

			Type type = typeof( T[,,] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array3DEnumNAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array3DEnumNAdapter<T>() ;
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
		public void SerializeT( T[,,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------
			// ランクは 3 限定

			writer.PutByte( 3 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;

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
		public T[,,] DeserializeT( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}

			//----------------------------------
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

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	/// <summary>
	/// Enum[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array3DEnumVersatileAdapter : IAdapter
	{
		private readonly Type									m_ObjectType ;
		private readonly Type									enumType ;
		private readonly Action<Array,int,int,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,int,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array3DEnumVersatileAdapter( Type objectType, Type elementType )
		{
			m_ObjectType			= objectType ;
			enumType				= elementType ;
			var enumTypeCode		= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutByte( ( System.Byte )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetByte() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutSByte( ( System.SByte )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetSByte() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt16( ( System.Int16 )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetInt16() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt16( ( System.UInt16 )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetUInt16() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt32( ( System.Int32 )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetInt32() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt32( ( System.UInt32 )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetUInt32() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutInt64( ( System.Int64 )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetInt64() ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									writer.PutUInt64( ( System.UInt64 )elements.GetValue( index_0, index_1, index_2 ) ) ;
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									elements.SetValue( Enum.ToObject( enumType, reader.GetUInt64() ), index_0, index_1, index_2 ) ;
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

			Array elements = entity as Array ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;

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

			//----------------------------------
			// ランクは 3 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 )
			{
				return Array.CreateInstance( enumType, length_0, length_1, length_2 ) ;
			}

			var elements = Array.CreateInstance( enumType, length_0, length_1, length_2 ) ;

			GetValue( elements, length_0, length_1, length_2, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// Enum[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array3DEnumNVersatileAdapter : IAdapter
	{
		private readonly Type									m_ObjectType ;
		private readonly Type									nullableEnumType ;
		private readonly Type									enumType ;
		private readonly Action<Array,int,int,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,int,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array3DEnumNVersatileAdapter( Type objectType, Type elementType )
		{
			m_ObjectType			= objectType ;
			nullableEnumType		= elementType ;
			enumType				= Nullable.GetUnderlyingType( nullableEnumType ) ;
			var enumTypeCode		= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Byte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetByteN() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.SByte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetSByteN() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Int16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetInt16N() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.UInt16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetUInt16N() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Int32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetInt32N() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.UInt32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetUInt32N() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.Int64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetInt64N() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
								}
							}
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream writer ) =>
					{
						int index_0, index_1, index_2 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
									value = elements.GetValue( index_0, index_1, index_2 ) ;
									if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )value ) ; }
								}
							}
						}
					} ;
					GetValue = ( Array elements, int length_0, int length_1, int length_2, ByteStream reader ) =>
					{
						int index_0, index_1, index_2 ; System.UInt64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
							{
								for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
								{
									value = reader.GetUInt64N() ;
									elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), index_0, index_1, index_2 ) ;
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

			var elements = entity as Array ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;

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

			//----------------------------------
			// ランクは 3 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 )
			{
				return Array.CreateInstance( nullableEnumType, length_0, length_1, length_2 ) ;
			}

			var elements = Array.CreateInstance( nullableEnumType, length_0, length_1, length_2 ) ;

			GetValue( elements, length_0, length_1, length_2, reader ) ;

			return elements ;
		}
	}
}
