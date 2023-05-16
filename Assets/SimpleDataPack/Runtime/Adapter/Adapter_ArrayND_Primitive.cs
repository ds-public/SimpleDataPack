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
	public class ArrayNDPrimitiveAdapter<T> : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDPrimitiveAdapter( int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//----------------------------------

			var primitiveType = typeof( T ) ;
			var primitiveTypeCode = Type.GetTypeCode( primitiveType ) ;

			switch( primitiveTypeCode )
			{
				case TypeCode.Boolean :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutBoolean( ( System.Boolean )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetBoolean(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
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
							elements.SetValue( reader.GetByte(), m_Indices ) ;
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
							elements.SetValue( reader.GetSByte(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Char :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutChar( ( System.Char )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetChar(), m_Indices ) ;
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
							elements.SetValue( reader.GetInt16(), m_Indices ) ;
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
							elements.SetValue( reader.GetUInt16(), m_Indices ) ;
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
							elements.SetValue( reader.GetInt32(), m_Indices ) ;
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
							elements.SetValue( reader.GetUInt32(), m_Indices ) ;
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
							elements.SetValue( reader.GetInt64(), m_Indices ) ;
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
							elements.SetValue( reader.GetUInt64(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Single :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSingle( ( System.Single )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetSingle(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Double :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutDouble( ( System.Double )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetDouble(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Decimal :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutDecimal( ( System.Decimal )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetDecimal(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.String :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutString( ( System.String )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetString(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.DateTime :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutDateTime( ( System.DateTime )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetDateTime(), m_Indices ) ;
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
	public class ArrayNDPrimitiveNAdapter<T> : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Action<Array,int,ByteStream>	SetValue ;
		private readonly Action<Array,int,ByteStream>	GetValue ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDPrimitiveNAdapter( int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//----------------------------------

			var enumType = Nullable.GetUnderlyingType( typeof( T ) ) ;
			var enumTypeCode = Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Boolean :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutBooleanN( ( System.Boolean? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetBooleanN(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetByteN(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetInt16N(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Char :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutCharN( ( System.Char? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetCharN(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetInt16N(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetUInt16N(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetInt32N(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetUInt32N(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetInt64N(), m_Indices ) ;
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
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetUInt64N(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Single :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutSingleN( ( System.Single? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetSingleN(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Double :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutDoubleN( ( System.Double? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetDoubleN(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.Decimal :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutDecimalN( ( System.Decimal? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetDecimalN(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.String :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutString( ( System.String )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetString(), m_Indices ) ;
							Increase() ;
						}
					} ;
				break ;
				case TypeCode.DateTime :
					SetValue = ( Array elements, int length, ByteStream writer ) =>
					{
						int index ; 
						for( index  = 0 ; index <  length ; index ++ )
						{
							writer.PutDateTimeN( ( System.DateTime? )elements.GetValue( m_Indices ) ) ;
							Increase() ;
						}
					} ;
					GetValue = ( Array elements, int length, ByteStream reader ) =>
					{
						int index ;
						for( index  = 0 ; index <  length ; index ++ )
						{
							elements.SetValue( reader.GetDateTimeN(), m_Indices ) ;
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
}
