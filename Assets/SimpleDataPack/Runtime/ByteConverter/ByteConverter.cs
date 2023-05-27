using System ;
using System.IO ;
using System.Text ;

using UnityEngine ;

public partial class SimpleDataPack
{
	public interface IByteConverter
	{
		public void SetEndian( bool isLittleEndian ) ;

		//-----------------------------------------------------------

		public void						PutBoolean( System.Boolean value, MemoryStream ms ) ;
		public void						PutBooleanN( System.Boolean? value, MemoryStream ms ) ;
		public void						PutBooleanT( System.Boolean value, MemoryStream ms ) ;

		public void						PutByte( System.Byte value, MemoryStream ms ) ;
		public void						PutByteN( System.Byte? value, MemoryStream ms ) ;
		public void						PutByteT( System.Byte value, MemoryStream ms ) ;

		public void						PutSByte( System.SByte value, MemoryStream ms ) ;
		public void						PutSByteN( System.SByte? value, MemoryStream ms ) ;
		public void						PutSByteT( System.SByte value, MemoryStream ms ) ;

		public void						PutChar( System.Char value, MemoryStream ms ) ;
		public void						PutCharN( System.Char? value, MemoryStream ms ) ;
		public void						PutCharT( System.Char value, MemoryStream ms ) ;

		public void						PutInt16( System.Int16 value, MemoryStream ms ) ;
		public void						PutInt16N( System.Int16? value, MemoryStream ms ) ;
		public void						PutInt16T( System.Int16 value, MemoryStream ms ) ;

		public void						PutUInt16( System.UInt16 value, MemoryStream ms ) ;
		public void						PutUInt16N( System.UInt16? value, MemoryStream ms ) ;
		public void						PutUInt16T( System.UInt16 value, MemoryStream ms ) ;

		public void						PutInt32( System.Int32 value, MemoryStream ms ) ;
		public void						PutInt32N( System.Int32? value, MemoryStream ms ) ;
		public void						PutInt32T( System.Int32 value, MemoryStream ms ) ;

		public void						PutUInt32( System.UInt32 value, MemoryStream ms ) ;
		public void						PutUInt32N( System.UInt32? value, MemoryStream ms ) ;
		public void						PutUInt32T( System.UInt32 value, MemoryStream ms ) ;

		public void						PutInt64( System.Int64 value, MemoryStream ms ) ;
		public void						PutInt64N( System.Int64? value, MemoryStream ms ) ;
		public void						PutInt64T( System.Int64 value, MemoryStream ms ) ;

		public void						PutUInt64( System.UInt64 value, MemoryStream ms ) ;
		public void						PutUInt64N( System.UInt64? value, MemoryStream ms ) ;
		public void						PutUInt64T( System.UInt64 value, MemoryStream ms ) ;

		public void						PutSingle( System.Single value, MemoryStream ms ) ;
		public void						PutSingleN( System.Single? value, MemoryStream ms ) ;
		public void						PutSingleT( System.Single value, MemoryStream ms ) ;

		public void						PutDouble( System.Double value, MemoryStream ms ) ;
		public void						PutDoubleN( System.Double? value, MemoryStream ms ) ;
		public void						PutDoubleT( System.Double value, MemoryStream ms ) ;

		public void						PutDecimal( System.Decimal value, MemoryStream ms ) ;
		public void						PutDecimalN( System.Decimal? value, MemoryStream ms ) ;
		public void						PutDecimalT( System.Decimal value, MemoryStream ms ) ;

		public void						PutString( System.String value, MemoryStream ms ) ;

		public void						PutDateTime( System.DateTime value, MemoryStream ms ) ;
		public void						PutDateTimeN( System.DateTime? value, MemoryStream ms ) ;
		public void						PutDateTimeT( System.DateTime value, MemoryStream ms ) ;

		//---------------

		public void						PutVUInt32( System.UInt32 value, MemoryStream ms ) ;
		public void						PutVUInt33( System.UInt32? value, MemoryStream ms ) ;
		public void						PutVUInt33T( System.UInt32 value, MemoryStream ms ) ;

		//-----------------------------------------------------------

		public System.Boolean			GetBoolean( ByteStream ms ) ;
		public System.Boolean?			GetBooleanN( ByteStream ms ) ;

		public System.Byte				GetByte( ByteStream ms ) ;
		public System.Byte?				GetByteN( ByteStream ms ) ;

		public System.SByte				GetSByte( ByteStream ms ) ;
		public System.SByte?			GetSByteN( ByteStream ms ) ;

		public System.Char				GetChar( ByteStream ms ) ;
		public System.Char?				GetCharN( ByteStream ms ) ;

		public System.Int16				GetInt16( ByteStream ms ) ;
		public System.Int16?			GetInt16N( ByteStream ms ) ;

		public System.UInt16			GetUInt16( ByteStream ms ) ;
		public System.UInt16?			GetUInt16N( ByteStream ms ) ;

		public System.Int32				GetInt32( ByteStream ms ) ;
		public System.Int32?			GetInt32N( ByteStream ms ) ;

		public System.UInt32			GetUInt32( ByteStream ms ) ;
		public System.UInt32?			GetUInt32N( ByteStream ms ) ;

		public System.Int64				GetInt64( ByteStream ms ) ;
		public System.Int64?			GetInt64N( ByteStream ms ) ;

		public System.UInt64			GetUInt64( ByteStream ms ) ;
		public System.UInt64?			GetUInt64N( ByteStream ms ) ;

		public System.Single			GetSingle( ByteStream ms ) ;
		public System.Single?			GetSingleN( ByteStream ms ) ;

		public System.Double			GetDouble( ByteStream ms ) ;
		public System.Double?			GetDoubleN( ByteStream ms ) ;

		public System.Decimal			GetDecimal( ByteStream ms ) ;
		public System.Decimal?			GetDecimalN( ByteStream ms ) ;

		public System.String			GetString( ByteStream ms ) ;

		public System.DateTime			GetDateTime( ByteStream ms ) ;
		public System.DateTime?			GetDateTimeN( ByteStream ms ) ;

		//---------------

		public System.UInt32			GetVUInt32( ByteStream ms ) ;
		public System.UInt32?			GetVUInt33( ByteStream ms ) ;
	}

	//--------------------------------------------------------------------------------------------
	// ※work 領域はマルチスレッド対応のためコンバート処理ごとに生成したものを渡して使用する

	// 通常
	public class ByteConverter : IByteConverter
	{
		// マルチスレッド対応のためワークエリアはスレッドごとに独立させる
		private readonly byte[] m_Work = new byte[ 256 ] ;

		// ダミー
		public void SetEndian( bool isLittleEndian ){}

		//-------------------------------------------------------------------------------------------

		public void PutBoolean( System.Boolean value, MemoryStream ms )
		{
			ms.WriteByte( value == false ? ( byte )0 : ( byte )1 ) ;
		}
		public void PutBooleanN( System.Boolean? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( ( System.Boolean )value == false ? ( byte )2 : ( byte )3 ) ;
			}
		}
		public void PutBooleanT( System.Boolean value, MemoryStream ms )
		{
			ms.WriteByte( value == false ? ( byte )2 : ( byte )3 ) ;
		}

		//---------------

		public void PutByte( System.Byte value, MemoryStream ms )
		{
			ms.WriteByte( value ) ;
		}
		public void PutByteN( System.Byte? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				ms.WriteByte( ( System.Byte )value ) ;
			}
		}
		public void PutByteT( System.Byte value, MemoryStream ms )
		{
			ms.WriteByte( 1 ) ;
			ms.WriteByte( ( System.Byte )value ) ;
		}

		//---------------

		public void PutSByte( System.SByte value, MemoryStream ms )
		{
			ms.WriteByte( ( System.Byte )value ) ;
		}
		public void PutSByteN( System.SByte? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				ms.WriteByte( ( System.Byte )( ( System.SByte )value ) ) ;
			}
		}
		public void PutSByteT( System.SByte value, MemoryStream ms )
		{
			ms.WriteByte( 1 ) ;
			ms.WriteByte( ( System.Byte )value ) ;
		}

		//---------------

		public void PutChar( System.Char value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )( value      ) ;
			m_Work[ 1 ] = ( System.Byte )( value >> 8 ) ;
			ms.Write( m_Work, 0, 2 ) ;
		}
		public void PutCharN( System.Char? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.Char )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v      ) ;
				m_Work[ 2 ] = ( System.Byte )( v >> 8 ) ;
				ms.Write( m_Work, 0, 3 ) ;
			}
		}
		public void PutCharT( System.Char value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value      ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 8 ) ;
			ms.Write( m_Work, 0, 3 ) ;
		}

		//---------------

		public void PutInt16( System.Int16 value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )( value      ) ;
			m_Work[ 1 ] = ( System.Byte )( value >> 8 ) ;
			ms.Write( m_Work, 0, 2 ) ;
		}
		public void PutInt16N( System.Int16? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.Int16 )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v      ) ;
				m_Work[ 2 ] = ( System.Byte )( v >> 8 ) ;
				ms.Write( m_Work, 0, 3 ) ;
			}
		}
		public void PutInt16T( System.Int16 value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value      ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 8 ) ;
			ms.Write( m_Work, 0, 3 ) ;
		}

		//---------------

		public void PutUInt16( System.UInt16 value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )( value      ) ;
			m_Work[ 1 ] = ( System.Byte )( value >> 8 ) ;
			ms.Write( m_Work, 0, 2 ) ;
		}
		public void PutUInt16N( System.UInt16? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.UInt16 )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v      ) ;
				m_Work[ 2 ] = ( System.Byte )( v >> 8 ) ;
				ms.Write( m_Work, 0, 3 ) ;
			}
		}
		public void PutUInt16T( System.UInt16 value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value      ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 8 ) ;
			ms.Write( m_Work, 0, 3 ) ;
		}

		//---------------

		public void PutInt32( System.Int32 value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )( value       ) ;
			m_Work[ 1 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 24 ) ;
			ms.Write( m_Work, 0, 4 ) ;
		}
		public void PutInt32N( System.Int32? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.Int32 )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v       ) ;
				m_Work[ 2 ] = ( System.Byte )( v >>  8 ) ;
				m_Work[ 3 ] = ( System.Byte )( v >> 16 ) ;
				m_Work[ 4 ] = ( System.Byte )( v >> 24 ) ;
				ms.Write( m_Work, 0, 5 ) ;
			}
		}
		public void PutInt32T( System.Int32 value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value       ) ;
			m_Work[ 2 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 4 ] = ( System.Byte )( value >> 24 ) ;
			ms.Write( m_Work, 0, 5 ) ;
		}

		//---------------

		public void PutUInt32( System.UInt32 value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )  value         ;
			m_Work[ 1 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 24 ) ;

			ms.Write( m_Work, 0, 4 ) ;
		}
		public void PutUInt32N( System.UInt32? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.UInt32 )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v       ) ;
				m_Work[ 2 ] = ( System.Byte )( v >>  8 ) ;
				m_Work[ 3 ] = ( System.Byte )( v >> 16 ) ;
				m_Work[ 4 ] = ( System.Byte )( v >> 24 ) ;
				ms.Write( m_Work, 0, 5 ) ;
			}
		}
		public void PutUInt32T( System.UInt32 value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value       ) ;
			m_Work[ 2 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 4 ] = ( System.Byte )( value >> 24 ) ;
			ms.Write( m_Work, 0, 5 ) ;
		}

		//---------------

		public void PutInt64( System.Int64 value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )( value       ) ;
			m_Work[ 1 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 24 ) ;
			m_Work[ 4 ] = ( System.Byte )( value >> 32 ) ;
			m_Work[ 5 ] = ( System.Byte )( value >> 40 ) ;
			m_Work[ 6 ] = ( System.Byte )( value >> 48 ) ;
			m_Work[ 7 ] = ( System.Byte )( value >> 56 ) ;
			ms.Write( m_Work, 0, 8 ) ;
		}
		public void PutInt64N( System.Int64? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.Int64 )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v       ) ;
				m_Work[ 2 ] = ( System.Byte )( v >>  8 ) ;
				m_Work[ 3 ] = ( System.Byte )( v >> 16 ) ;
				m_Work[ 4 ] = ( System.Byte )( v >> 24 ) ;
				m_Work[ 5 ] = ( System.Byte )( v >> 32 ) ;
				m_Work[ 6 ] = ( System.Byte )( v >> 40 ) ;
				m_Work[ 7 ] = ( System.Byte )( v >> 48 ) ;
				m_Work[ 8 ] = ( System.Byte )( v >> 56 ) ;
				ms.Write( m_Work, 0, 9 ) ;
			}
		}
		public void PutInt64T( System.Int64 value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value       ) ;
			m_Work[ 2 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 4 ] = ( System.Byte )( value >> 24 ) ;
			m_Work[ 5 ] = ( System.Byte )( value >> 32 ) ;
			m_Work[ 6 ] = ( System.Byte )( value >> 40 ) ;
			m_Work[ 7 ] = ( System.Byte )( value >> 48 ) ;
			m_Work[ 8 ] = ( System.Byte )( value >> 56 ) ;
			ms.Write( m_Work, 0, 9 ) ;
		}

		//---------------

		public void PutUInt64( System.UInt64 value, MemoryStream ms )
		{
			m_Work[ 0 ] = ( System.Byte )( value       ) ;
			m_Work[ 1 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 2 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 24 ) ;
			m_Work[ 4 ] = ( System.Byte )( value >> 32 ) ;
			m_Work[ 5 ] = ( System.Byte )( value >> 40 ) ;
			m_Work[ 6 ] = ( System.Byte )( value >> 48 ) ;
			m_Work[ 7 ] = ( System.Byte )( value >> 56 ) ;
			ms.Write( m_Work, 0, 8 ) ;
		}
		public void PutUInt64N( System.UInt64? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				var v = ( System.UInt64 )value ;
				m_Work[ 0 ] = 1 ;
				m_Work[ 1 ] = ( System.Byte )( v      ) ;
				m_Work[ 2 ] = ( System.Byte )( v >>  8 ) ;
				m_Work[ 3 ] = ( System.Byte )( v >> 16 ) ;
				m_Work[ 4 ] = ( System.Byte )( v >> 24 ) ;
				m_Work[ 5 ] = ( System.Byte )( v >> 32 ) ;
				m_Work[ 6 ] = ( System.Byte )( v >> 40 ) ;
				m_Work[ 7 ] = ( System.Byte )( v >> 48 ) ;
				m_Work[ 8 ] = ( System.Byte )( v >> 56 ) ;
				ms.Write( m_Work, 0, 9 ) ;
			}
		}
		public void PutUInt64T( System.UInt64 value, MemoryStream ms )
		{
			m_Work[ 0 ] = 1 ;
			m_Work[ 1 ] = ( System.Byte )( value      ) ;
			m_Work[ 2 ] = ( System.Byte )( value >>  8 ) ;
			m_Work[ 3 ] = ( System.Byte )( value >> 16 ) ;
			m_Work[ 4 ] = ( System.Byte )( value >> 24 ) ;
			m_Work[ 5 ] = ( System.Byte )( value >> 32 ) ;
			m_Work[ 6 ] = ( System.Byte )( value >> 40 ) ;
			m_Work[ 7 ] = ( System.Byte )( value >> 48 ) ;
			m_Work[ 8 ] = ( System.Byte )( value >> 56 ) ;
			ms.Write( m_Work, 0, 9 ) ;
		}

		//---------------

		public void PutSingle( System.Single value, MemoryStream ms )
		{
			ms.Write( BitConverter.GetBytes( value ), 0, 4 ) ;
		}
		public void PutSingleN( System.Single? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				ms.Write( BitConverter.GetBytes( ( System.Single )value ), 0, 4 ) ;
			}
		}
		public void PutSingleT( System.Single value, MemoryStream ms )
		{
			ms.WriteByte( 1 ) ;
			ms.Write( BitConverter.GetBytes( value ), 0, 4 ) ;
		}

		//---------------

		public void PutDouble( System.Double value, MemoryStream ms )
		{
			ms.Write( BitConverter.GetBytes( value ), 0, 8 ) ;
		}
		public void PutDoubleN( System.Double? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				ms.Write( BitConverter.GetBytes( ( System.Double )value ), 0, 8 ) ;
			}
		}
		public void PutDoubleT( System.Double value, MemoryStream ms )
		{
			ms.WriteByte( 1 ) ;
			ms.Write( BitConverter.GetBytes( value ), 0, 8 ) ;
		}

		//---------------

		public void PutDecimal( System.Decimal value, MemoryStream ms )
		{
			byte[] b = Encoding.UTF8.GetBytes( value.ToString() ) ;
			ms.WriteByte( ( System.Byte )b.Length ) ;
			ms.Write( b, 0, b.Length ) ;
		}
		public void PutDecimalN( System.Decimal? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				byte[] b = Encoding.UTF8.GetBytes( ( ( System.Decimal )value ).ToString() ) ;
				ms.WriteByte( ( System.Byte )b.Length ) ;
				ms.Write( b, 0, b.Length ) ;
			}
		}
		public void PutDecimalT( System.Decimal value, MemoryStream ms )
		{
			byte[] b = Encoding.UTF8.GetBytes( value.ToString() ) ;
			ms.WriteByte( ( System.Byte )b.Length ) ;
			ms.Write( b, 0, b.Length ) ;
		}

		//---------------

		public void PutString( System.String value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				if( value.Length == 0 )
				{
					// Null ではなく空文字
					ms.WriteByte( 1 ) ;
				}
				else
				{
					byte[] b = Encoding.UTF8.GetBytes( value ) ;
					PutVUInt33( ( System.UInt32? )b.Length, ms ) ;
					ms.Write( b, 0, b.Length ) ;
				}
			}
		}

		//---------------

		public void PutDateTime( System.DateTime value, MemoryStream ms )
		{
			PutInt64( ( System.Int64 )value.Ticks, ms ) ;
		}
		public void PutDateTimeN( System.DateTime? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				PutInt64( ( System.Int64 )( ( ( System.DateTime )value ).Ticks ), ms ) ;
			}
		}
		public void PutDateTimeT( System.DateTime value, MemoryStream ms )
		{
			ms.WriteByte( 1 ) ;
			PutInt64( ( System.Int64 )( value.Ticks ), ms ) ;
		}

		//-----------------------------------------------------------

		public void PutVUInt32( System.UInt32 value, MemoryStream ms )	// Max 5 byte ( 32 bit )
		{
			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
					value >>= 7 ;

					if( value <  128 )
					{
						ms.WriteByte( ( byte )value ) ;
					}
					else
					{
						ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +2(7)
						value >>= 7 ;

						if( value <  128 )
						{
							ms.WriteByte( ( byte )value ) ;
						}
						else
						{
							ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +3(7)
							value >>= 7 ;

							ms.WriteByte( ( byte )value ) ;				// +4(4)
						}
					}
				}
			}
		}

		public void PutVUInt33( System.UInt32? value32, MemoryStream ms )	// Max 5 byte ( 33(32+1) bit )
		{
			if( value32 == null )
			{
				// null
				ms.WriteByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// 最下位ビットに１を加える
			System.UInt64 value = ( ( System.UInt64 )value32 << 1 ) | 1 ;

			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
					value >>= 7 ;

					if( value <  128 )
					{
						ms.WriteByte( ( byte )value ) ;
					}
					else
					{
						ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +2(7)
						value >>= 7 ;

						if( value <  128 )
						{
							ms.WriteByte( ( byte )value ) ;
						}
						else
						{
							ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +3(7)
							value >>= 7 ;

							ms.WriteByte( ( byte )value ) ;				// +4(5(4+1))
						}
					}
				}
			}
		}

		public void PutVUInt33T( System.UInt32 value32, MemoryStream ms )	// Max 5 byte ( 33 bit )
		{
			//----------------------------------
			// ６４ビット値はキャストが無いとビットが消えてしまう

			System.UInt64 value = ( System.UInt64 )( ( ( System.UInt64 )value32 << 1 ) | 1 ) ;

			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;				// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;			// +1(7)
					value >>= 7 ;

					if( value <  128 )
					{
						ms.WriteByte( ( byte )value ) ;
					}
					else
					{
						ms.WriteByte( ( byte )( value | 0x80 ) ) ;		// +2(7)
						value >>= 7 ;

						if( value <  128 )
						{
							ms.WriteByte( ( byte )value ) ;
						}
						else
						{
							ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +3(7)
							value >>= 7 ;

							ms.WriteByte( ( byte )value ) ;				// +4(4+1)
						}
					}
				}
			}
		}

		//-------------------------------------------------------------------------------------------

		public System.Boolean GetBoolean( ByteStream ms )
		{
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ; 
			return ( v != 0 ) ;
		}
		public System.Boolean? GetBooleanN( ByteStream ms )
		{
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ; 
			switch( v )
			{
				case 0 : return null ;
				case 2 : return false ;
				case 3 : return true ;
				default : break ;
			}
			throw new Exception( message:"Unknown code"  ) ;
		}

		//---------------

		public System.Byte GetByte( ByteStream ms )
		{
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return v ;
		}
		public System.Byte? GetByteN( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return v ;
		}

		//---------------

		public System.SByte GetSByte( ByteStream ms )
		{
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.SByte )v ;
		}
		public System.SByte? GetSByteN( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.SByte )v ;
		}

		//---------------

		public System.Char GetChar( ByteStream ms )
		{
			var v = ( System.Char )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] << 8 ) ) ; ms.Step += 2 ;
			return v ;
		}
		public System.Char? GetCharN( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( System.Char )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] << 8 ) ) ; ms.Step += 2 ;
			return v ;
		}

		//---------------

		public System.Int16 GetInt16( ByteStream ms )
		{
			var v = ( System.Int16 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] << 8 ) ) ; ms.Step += 2 ;
			return v ;
		}
		public System.Int16? GetInt16N( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( System.Int16 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] << 8 ) ) ; ms.Step += 2 ;
			return v ;
		}

		//---------------

		public System.UInt16 GetUInt16( ByteStream ms )
		{
			var v = ( System.UInt16 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] << 8 ) ) ; ms.Step += 2 ;
			return v ;
		}
		public System.UInt16? GetUInt16N( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( System.UInt16 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] << 8 ) ) ; ms.Step += 2 ;
			return v ;
		}

		//---------------

		public System.Int32 GetInt32( ByteStream ms )
		{
			var v = ( System.Int32 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] <<  8 ) | ( ms.Data[ ms.Step + 2 ] << 16 ) | ( ms.Data[ ms.Step + 3 ] << 24 ) ) ; ms.Step += 4 ;
			return v ;
		}
		public System.Int32? GetInt32N( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( System.Int32 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] <<  8 ) | ( ms.Data[ ms.Step + 2 ] << 16 ) | ( ms.Data[ ms.Step + 3 ] << 24 ) ) ; ms.Step += 4 ;
			return v ;
		}

		//---------------

		public System.UInt32 GetUInt32( ByteStream ms )
		{
			var v = ( System.UInt32 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] <<  8 ) | ( ms.Data[ ms.Step + 2 ] << 16 ) | ( ms.Data[ ms.Step + 3 ] << 24 ) ) ; ms.Step += 4 ;
			return v ;
		}
		public System.UInt32? GetUInt32N( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( System.UInt32 )( ms.Data[ ms.Step ] | ( ms.Data[ ms.Step + 1 ] <<  8 ) | ( ms.Data[ ms.Step + 2 ] << 16 ) | ( ms.Data[ ms.Step + 3 ] << 24 ) ) ; ms.Step += 4 ;
			return v ;
		}

		//---------------
		// ※ 64 bit 値の場合は Byte → UInt64 キャストしてからのシフト演算が必要

		public System.Int64 GetInt64( ByteStream ms )
		{
			var v = ( System.Int64 )( ( System.UInt64 )ms.Data[ ms.Step ] | ( ( System.UInt64 )ms.Data[ ms.Step + 1 ] <<  8 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 2 ] << 16 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 3 ] << 24 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 4 ] << 32 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 5 ] << 40 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 6 ] << 48 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 7 ] << 56 ) ) ; ms.Step += 8 ;
			return v ;
		}
		public System.Int64? GetInt64N( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( System.Int64 )( ( System.UInt64 )ms.Data[ ms.Step ] | ( ( System.UInt64 )ms.Data[ ms.Step + 1 ] <<  8 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 2 ] << 16 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 3 ] << 24 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 4 ] << 32 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 5 ] << 40 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 6 ] << 48 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 7 ] << 56 ) ) ; ms.Step += 8 ;
			return v ;
		}

		//---------------

		public System.UInt64 GetUInt64( ByteStream ms )
		{
			var v = ( ( System.UInt64 )ms.Data[ ms.Step ] | ( ( System.UInt64 )ms.Data[ ms.Step + 1 ] <<  8 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 2 ] << 16 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 3 ] << 24 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 4 ] << 32 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 5 ] << 40 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 6 ] << 48 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 7 ] << 56 ) ) ; ms.Step += 8 ;
			return v ;
		}
		public System.UInt64? GetUInt64N( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = ( ( System.UInt64 )ms.Data[ ms.Step ] | ( ( System.UInt64 )ms.Data[ ms.Step + 1 ] <<  8 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 2 ] << 16 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 3 ] << 24 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 4 ] << 32 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 5 ] << 40 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 6 ] << 48 ) | ( ( System.UInt64 )ms.Data[ ms.Step + 7 ] << 56 ) ) ; ms.Step += 8 ;
			return v ;
		}

		//---------------

		public System.Single GetSingle( ByteStream ms )
		{
			var v = BitConverter.ToSingle( ms.Data, ms.Step ) ; ms.Step += 4 ;
			return v ;
		}
		public System.Single? GetSingleN( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = BitConverter.ToSingle( ms.Data, ms.Step ) ; ms.Step += 4 ;
			return v ;
		}

		//---------------

		public System.Double GetDouble( ByteStream ms )
		{
			var v = BitConverter.ToDouble( ms.Data, ms.Step ) ; ms.Step += 8 ;
			return v ;
		}
		public System.Double? GetDoubleN( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = BitConverter.ToDouble( ms.Data, ms.Step ) ; ms.Step += 8 ;
			return v ;
		}

		//---------------

		public System.Decimal GetDecimal( ByteStream ms )
		{
			System.Int32 length = ms.Data[ ms.Step ] ; ms.Step ++ ;
			var s = Encoding.UTF8.GetString( ms.Data, ms.Step, length ) ; ms.Step += length ;
			return System.Decimal.Parse( s ) ;
		}
		public System.Decimal? GetDecimalN( ByteStream ms )
		{
			System.Int32 length = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( length == 0 )
			{
				return null ;
			}
			var s = Encoding.UTF8.GetString( ms.Data, ms.Step, length ) ; ms.Step += length ;
			return System.Decimal.Parse( s ) ;
		}

		//---------------

		public System.String GetString( ByteStream ms )
		{
			// 文字数
			System.UInt32? value = GetVUInt33( ms ) ;
			if( value == null )
			{
				// null
				return null ;
			}

			System.Int32 length = ( System.Int32 )value ;
			if( length == 0 )
			{
				// 空文字
				return string.Empty ;
			}

			var s = Encoding.UTF8.GetString( ms.Data, ms.Step, length ) ; ms.Step += length ;
			return s ;
		}

		//---------------

		public System.DateTime GetDateTime( ByteStream ms )
		{
			return new DateTime( ticks:GetInt64( ms ) ) ;
		}
		public System.DateTime? GetDateTimeN( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			return new DateTime( ticks:GetInt64( ms ) ) ;
		}

		//-----------------------------------------------------------

		/// <summary>
		/// 可変長３２ビット値を取得する
		/// </summary>
		/// <param name="ms"></param>
		/// <returns></returns>
		public System.UInt32 GetVUInt32( ByteStream ms )				// Max 5 byte ( 32 bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 <  128 )
			{
				return b0 ;												//  7 bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt32 )(								// 14 bit
					( b1 <<  7 ) |										// +1(7)
					  b0												// +0(7)
				) ;
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b2 <  128 )
			{
				return ( System.UInt32 )(								// 21 bit
					( b2 << 14 ) |										// +2(7)
					( b1 <<  7 ) |										// +1(7)
					  b0												// +0(7)
				) ;
			}
			b2 &= 0x7F ;

			byte b3 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b3 <  128 )
			{
				return ( System.UInt32 )(								// 28 bit
					( b3 << 21 ) |										// +3(7)
					( b2 << 14 ) |										// +2(7)
					( b1 <<  7 ) |										// +1(7)
					  b0												// +0(7)
				) ;
			}
			b3 &= 0x7F ;

			byte b4 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt32 )(									// 32 bit
				( b4 << 28 ) |											// +4(4)
				( b3 << 21 ) |											// +3(7)
				( b2 << 14 ) |											// +2(7)
				( b1 <<  7 ) |											// +1(7)
				  b0													// +0(7)
			) ;
		}

		/// <summary>
		/// Nullable ビット付きの可変長３３ビット値を取得する
		/// </summary>
		/// <param name="ms"></param>
		/// <returns></returns>
		public System.UInt32? GetVUInt33( ByteStream ms )				// Max 5 byte ( 32(33-1) bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 == 0 )
			{
				return null ;
			}
			if( b0 <  128 )
			{
				return ( System.UInt32 )( b0 >> 1 ) ;					//  6(7-1) bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt32 )(								// 13(14-1) bit
					( b1 <<  6 ) |										// +1(7)
					( b0 >>  1 )										// +0(6(7-1))
				) ;														// 最下位ビットを削る
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b2 <  128 )
			{
				return ( System.UInt32 )(								// 20(21-1) bit
					( b2 << 13 ) |										// +2(7)
					( b1 <<  6 ) |										// +1(7)
					( b0 >>  1 )										// +0(6(7-1))
				) ;														// 最下位ビットを削る
			}
			b2 &= 0x7F ;

			byte b3 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b3 <  128 )
			{
				return ( System.UInt32 )(								// 27(28-1) bit
					( b3 << 20 ) |										// +3(7)
					( b2 << 13 ) |										// +2(7)
					( b1 <<  6 ) |										// +1(7)
					( b0 >>  1 )										// +0(6(7-1))
				) ;														// 最下位ビットを削る
			}
			b3 &= 0x7F ;

			byte b4 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt32 )(									// 32(33-1) bit
				( b4 << 27 ) |											// +5(5)
				( b3 << 20 ) |											// +3(7)
				( b2 << 13 ) |											// +2(7)
				( b1 <<  6 ) |											// +1(7)
				( b0 >>  1 )											// +0(6(7-1))
			) ;															// 最下位ビットを削る
		}
	}
}
