using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// Ｎ次元

	/// <summary>
	/// Enum[...] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ArrayNDEnumAdapter<T> : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Type	enumType ;
		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDEnumAdapter( int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//----------------------------------

			enumType			= typeof( T ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutByte( ( System.Byte )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetByte() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSByte( ( System.SByte )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetSByte() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt16( ( System.Int16 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetInt16() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt16( ( System.UInt16 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetUInt16() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt32( ( System.Int32 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetInt32() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt32( ( System.UInt32 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetUInt32() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt64( ( System.Int64 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetInt64() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt64( ( System.UInt64 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( ( T )Enum.ToObject( enumType, reader.GetUInt64() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
			}
		}

		// インデックスを増加させる
		private void Increase()
		{
			int d, u = 1 ;

			for( d  = m_Limit ; d >  0 ; d -- )
			{
				m_Indices[ d ] += u ;

				u = m_Indices[ d ] / m_Lengths[ d ] ;
				m_Indices[ d ] %= m_Lengths[ d ] ;
			}
			m_Indices[ d ] += u ;
		}

		//-----------------------------------------------------------

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

			// 次元数を格納
			writer.PutVUInt32( ( System.UInt32 )Rank ) ;

			//----------------------------------

			// アレイ取得
			Array elements = entity as Array ;

			// 各次元の要素数を格納する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++ )
			{
				m_Lengths[ d ] = elements.GetLength( d ) ;
				writer.PutVUInt32( ( System.UInt32 )m_Lengths[ d ] ) ;

				m_Indices[ d ] = 0 ;
			}

			//--------------

			int length = elements.Length ;

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return ;
			}

			//--------------

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
			// 次元数を取得
			if( reader.GetVUInt32() == 0 )
			{
				return default ;
			}

			//----------------------------------

			// 各次元の要素数を取得する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++  )
			{
				m_Lengths[ d ] = ( System.Int32 )reader.GetVUInt32() ;

				m_Indices[ 0 ] = 0 ;
			}

			// アレイ生成
			Array elements = Array.CreateInstance( typeof( T ), m_Lengths ) ;

			//--------------

			int length = elements.Length ;

			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return elements ;
			}

			//--------------

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// Enum?[...] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ArrayNDEnumNAdapter<T> : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Type	enumType ;
		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDEnumNAdapter( int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//----------------------------------

			enumType			= Nullable.GetUnderlyingType( typeof( T ) ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutByteN( ( System.Byte? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Byte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetByteN() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSByteN( ( System.SByte? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.SByte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetSByteN() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt16N( ( System.Int16? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt16N() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt16N( ( System.UInt16? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt16N() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt32N( ( System.Int32? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt32N() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt32N( ( System.UInt32? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt32N() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt64N( ( System.Int64? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt64N() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt64N( ( System.UInt64? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt64N() ;
							elements.SetValue( value == null ? default : ( T )Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
			}
		}

		// インデックスを増加させる
		private void Increase()
		{
			int d, u = 1 ;

			for( d  = m_Limit ; d >  0 ; d -- )
			{
				m_Indices[ d ] += u ;

				u = m_Indices[ d ] / m_Lengths[ d ] ;
				m_Indices[ d ] %= m_Lengths[ d ] ;
			}
			m_Indices[ d ] += u ;
		}

		//-----------------------------------------------------------

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

			// 次元数を格納
			writer.PutVUInt32( ( System.UInt32 )Rank ) ;

			//----------------------------------

			// アレイ取得
			Array elements = entity as Array ;

			// 各次元の要素数を格納する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++ )
			{
				m_Lengths[ d ] = elements.GetLength( d ) ;
				writer.PutVUInt32( ( System.UInt32 )m_Lengths[ d ] ) ;

				m_Indices[ d ] = 0 ;
			}

			//--------------

			int length = elements.Length ;

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return ;
			}

			//--------------

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
			// 次元数を取得
			if( reader.GetVUInt32() == 0 )
			{
				return default ;
			}

			//----------------------------------

			// 各次元の要素数を取得する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++  )
			{
				m_Lengths[ d ] = ( System.Int32 )reader.GetVUInt32() ;

				m_Indices[ 0 ] = 0 ;
			}

			// アレイ生成
			Array elements = Array.CreateInstance( typeof( T ), m_Lengths ) ;

			//--------------

			int length = elements.Length ;

			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return elements ;
			}

			//--------------

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	/// <summary>
	/// Enum[...] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ArrayNDEnumVersatileAdapter : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Type							m_ObjectType ;
		private readonly Type							enumType ;
		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDEnumVersatileAdapter( Type objectType, Type elementType, int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//----------------------------------

			m_ObjectType			= objectType ;
			enumType				= elementType ;
			var enumTypeCode		= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutByte( ( System.Byte )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetByte() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSByte( ( System.SByte )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetSByte() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt16( ( System.Int16 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetInt16() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt16( ( System.UInt16 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetUInt16() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt32( ( System.Int32 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetInt32() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt32( ( System.UInt32 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetUInt32() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutInt64( ( System.Int64 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetInt64() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutUInt64( ( System.UInt64 )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( Enum.ToObject( enumType, reader.GetUInt64() ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
			}
		}

		// インデックスを増加させる
		private void Increase()
		{
			int d, u = 1 ;

			for( d  = m_Limit ; d >  0 ; d -- )
			{
				m_Indices[ d ] += u ;

				u = m_Indices[ d ] / m_Lengths[ d ] ;
				m_Indices[ d ] %= m_Lengths[ d ] ;
			}
			m_Indices[ d ] += u ;
		}

		//-----------------------------------------------------------

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

			// 次元数を格納
			writer.PutVUInt32( ( System.UInt32 )Rank ) ;

			//----------------------------------

			// アレイ取得
			Array elements = entity as Array ;

			// 各次元の要素数を格納する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++ )
			{
				m_Lengths[ d ] = elements.GetLength( d ) ;
				writer.PutVUInt32( ( System.UInt32 )m_Lengths[ d ] ) ;

				m_Indices[ d ] = 0 ;
			}

			//--------------

			int length = elements.Length ;

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return ;
			}

			//--------------

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
			// 次元数を取得
			if( reader.GetVUInt32() == 0 )
			{
				return default ;
			}

			//----------------------------------

			// 各次元の要素数を取得する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++  )
			{
				m_Lengths[ d ] = ( System.Int32 )reader.GetVUInt32() ;

				m_Indices[ 0 ] = 0 ;
			}

			// アレイ生成
			var elements = Array.CreateInstance( enumType, m_Lengths ) ;

			//--------------

			int length = elements.Length ;

			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return elements ;
			}

			//--------------

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

	/// <summary>
	/// Enum?[...] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ArrayNDEnumNVersatileAdapter : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Type							m_ObjectType ;
		private readonly Type							nullableEnumType ;
		private readonly Type							enumType ;
		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDEnumNVersatileAdapter( Type objectType, Type elementType, int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//----------------------------------

			m_ObjectType			= objectType ;
			nullableEnumType		= elementType ;
			enumType				= Nullable.GetUnderlyingType( nullableEnumType ) ;
			var enumTypeCode		= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Byte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetByteN() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.SByte? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetSByteN() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt16N() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt16? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt16N() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt32N() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt32? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt32N() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.Int64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetInt64N() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; System.Object value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
							value = elements.GetValue( m_Indices ) ;
							if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )value ) ; }
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; System.UInt64? value ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							value = reader.GetUInt64N() ;
							elements.SetValue( value == null ? default : Enum.ToObject( enumType, value ), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
			}
		}

		// インデックスを増加させる
		private void Increase()
		{
			int d, u = 1 ;

			for( d  = m_Limit ; d >  0 ; d -- )
			{
				m_Indices[ d ] += u ;

				u = m_Indices[ d ] / m_Lengths[ d ] ;
				m_Indices[ d ] %= m_Lengths[ d ] ;
			}
			m_Indices[ d ] += u ;
		}

		//-----------------------------------------------------------

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

			// 次元数を格納
			writer.PutVUInt32( ( System.UInt32 )Rank ) ;

			//----------------------------------

			// アレイ取得
			Array elements = entity as Array ;

			// 各次元の要素数を格納する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++ )
			{
				m_Lengths[ d ] = elements.GetLength( d ) ;
				writer.PutVUInt32( ( System.UInt32 )m_Lengths[ d ] ) ;

				m_Indices[ d ] = 0 ;
			}

			//--------------

			int length = elements.Length ;

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return ;
			}

			//--------------

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
			// 次元数を取得
			if( reader.GetVUInt32() == 0 )
			{
				return default ;
			}

			//----------------------------------

			// 各次元の要素数を取得する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++  )
			{
				m_Lengths[ d ] = ( System.Int32 )reader.GetVUInt32() ;

				m_Indices[ 0 ] = 0 ;
			}

			// アレイ生成
			var elements = Array.CreateInstance( nullableEnumType, m_Lengths ) ;

			//--------------

			int length = elements.Length ;

			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return elements ;
			}

			//--------------

			GetValue( elements, length, reader ) ;

			return elements ;
		}
	}

}
