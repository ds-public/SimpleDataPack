using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

using uGUIHelper ;

public partial class SimpleDataPack
{
	//============================================================================================
	// １次元

	/// <summary>
	/// Enum[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DEnumAdapter<T> : IAdapter
	{
		private readonly Type	enumType ;

		private readonly Action<T[],int,ByteStream>	SetValue ;
		private readonly Action<T[],int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array1DEnumAdapter()
		{
			enumType			= typeof( T ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutByte( ( System.Byte )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetByte() ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutSByte( ( System.SByte )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetSByte() ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutInt16( ( System.Int16 )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetInt16() ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutUInt16( ( System.UInt16 )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetUInt16() ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutInt32( ( System.Int32 )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetInt32() ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutUInt32( ( System.UInt32 )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetUInt32() ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutInt64( ( System.Int64 )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetInt64() ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutUInt64( ( System.UInt64 )( ( System.Object )elements[ index_0 ] ) ) ;
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements[ index_0 ] = ( T )Enum.ToObject( enumType, reader.GetUInt64() ) ;
						}
					} ;
				break ;
			}
		}

		//-------------------------------------------------------------------------------------------
		
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			T[] elements = entity as T[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, writer ) ;
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

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( T[] elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array1DEnumAdapter<T> adapter ;

			Type type = typeof( T[] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array1DEnumAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array1DEnumAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static T[] GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array1DEnumAdapter<T> adapter ;

			Type type = typeof( T[] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array1DEnumAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array1DEnumAdapter<T>() ;
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

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, writer ) ;
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

			// ランクは 1 限定

			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				return new T[ 0 ] ;
			}

			T[] elements = new T[ length_0 ] ;

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// Enum?[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DEnumNAdapter<T> : IAdapter
	{
		private readonly Type	enumType ;

		private readonly Action<T[],int,ByteStream>	SetValue ;
		private readonly Action<T[],int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array1DEnumNAdapter()
		{
			enumType			= Nullable.GetUnderlyingType( typeof( T ) ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Byte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetByteN() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.SByte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetSByteN() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Int16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetInt16N() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.UInt16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetUInt16N() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Int32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetInt32N() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.UInt32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetUInt32N() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Int64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetInt64N() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( T[] elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							if( elements[ index_0 ] == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )( ( System.Object )elements[ index_0 ] ) ) ; }
						}
					} ;
					GetValue = ( T[] elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.UInt64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetUInt64N() ;
							elements[ index_0 ] = value == null ? default : ( T )Enum.ToObject( enumType, value ) ;
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			T[] elements = entity as T[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, writer ) ;
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

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( T[] elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array1DEnumNAdapter<T> adapter ;

			Type type = typeof( T[] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array1DEnumNAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array1DEnumNAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static T[] GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array1DEnumNAdapter<T> adapter ;

			Type type = typeof( T[] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array1DEnumNAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array1DEnumNAdapter<T>() ;
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

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, writer ) ;
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

			// ランクは 1 限定

			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				return new T[ 0 ] ;
			}

			T[] elements = new T[ length_0 ] ;

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}
	}


	//============================================================================================
	// IL2CPP 用

	/// <summary>
	/// Enum[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DEnumReflectionAdapter : IAdapter
	{
		private readonly Type	enumType ;

		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array1DEnumReflectionAdapter( Type elementType )
		{
			enumType			= elementType ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutByte( ( System.Byte )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetByte() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutSByte( ( System.SByte )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetSByte() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutInt16( ( System.Int16 )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetInt16() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutUInt16( ( System.UInt16 )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetUInt16() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutInt32( ( System.Int32 )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetInt32() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutUInt32( ( System.UInt32 )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetUInt32() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutInt64( ( System.Int64 )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetInt64() ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; 
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							writer.PutUInt64( ( System.UInt64 )elements.GetValue( index_0 ) ) ;
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetUInt64() ), index_0 ) ;
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as Array ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, writer ) ;
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
				return ( System.Object )Array.CreateInstance( enumType, 0 ) ;
			}

			Array elements = Array.CreateInstance( enumType, length_0 ) ;

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// Enum?[] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DEnumNReflectionAdapter : IAdapter
	{
		private readonly Type	nullableEnumType ;
		private readonly Type	enumType ;

		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Array1DEnumNReflectionAdapter( Type elementType )
		{
			nullableEnumType	= elementType ;
			enumType			= Nullable.GetUnderlyingType( nullableEnumType ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Byte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetByteN() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.Byte )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.SByte? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetSByteN() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.SByte )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Int16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetInt16N() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.Int16 )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.UInt16? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetUInt16N() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.UInt16 )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Int32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetInt32N() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.Int32 )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.UInt32? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetUInt32N() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.UInt32 )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.Int64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetInt64N() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.Int64 )value ), index_0 ) ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length_0, ByteStream writer ) =>
					{
						int index_0 ; System.Object value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( index_0 ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )value ) ; }
						}
					} ;
					GetValue = ( Array elements, int length_0, ByteStream reader ) =>
					{
						int index_0 ; System.UInt64? value ;
						for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
						{
							value = reader.GetUInt64N() ;
							elements.SetValue( value == null ? null : Enum.ToObject( enumType, ( System.UInt64 )value ), index_0 ) ;
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as Array ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			SetValue( elements, length_0, writer ) ;
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
				return Array.CreateInstance( nullableEnumType, 0 ) ;
			}

			var elements = Array.CreateInstance( nullableEnumType, length_0 ) ;

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}
	}


}
