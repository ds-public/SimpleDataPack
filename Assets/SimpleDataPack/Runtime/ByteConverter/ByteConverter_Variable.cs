using System ;
using System.IO ;
using System.Text ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// 逆順
	public class ByteConverter_Variable : IByteConverter
	{
		// マルチスレッド対応のためワークエリアはスレッドごとに独立させる
		private readonly byte[] m_Work = new byte[ 256 ] ;

		public void SetEndian( bool isBigEndian )
		{
			if( isBigEndian != BitConverter.IsLittleEndian )
			{
				PutSingle_Dispatcher	= PutSingle_Inner ;
				PutSingleN_Dispatcher	= PutSingleN_Inner ;

				PutDouble_Dispatcher	= PutDouble_Inner ;
				PutDoubleN_Dispatcher	= PutDoubleN_Inner ;

				//---

				GetSingle_Dispatcher	= GetSingle_Inner ;
				GetSingleN_Dispatcher	= GetSingleN_Inner ;

				GetDouble_Dispatcher	= GetDouble_Inner ;
				GetDoubleN_Dispatcher	= GetDoubleN_Inner ;
			}
			else
			{
				PutSingle_Dispatcher	= PutSingle_Inner_Reverse ;
				PutSingleN_Dispatcher	= PutSingleN_Inner_Reverse ;

				PutDouble_Dispatcher	= PutDouble_Inner_Reverse ;
				PutDoubleN_Dispatcher	= PutDoubleN_Inner_Reverse ;

				//---

				GetSingle_Dispatcher	= GetSingle_Inner_Reverse ;
				GetSingleN_Dispatcher	= GetSingleN_Inner_Reverse ;

				GetDouble_Dispatcher	= GetDouble_Inner_Reverse ;
				GetDoubleN_Dispatcher	= GetDoubleN_Inner_Reverse ;
			}
		}

		private Action<System.Single,MemoryStream>			PutSingle_Dispatcher ;
		private Action<System.Single?,MemoryStream>			PutSingleN_Dispatcher ;

		private Action<System.Double,MemoryStream>			PutDouble_Dispatcher ;
		private Action<System.Double?,MemoryStream>			PutDoubleN_Dispatcher ;

		private Func<ByteStream,System.Single>				GetSingle_Dispatcher ;
		private Func<ByteStream,System.Single?>				GetSingleN_Dispatcher ;

		private Func<ByteStream,System.Double>				GetDouble_Dispatcher ;
		private Func<ByteStream,System.Double?>				GetDoubleN_Dispatcher ;

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

		//---------------

		public void PutByte( System.Byte value, MemoryStream ms )
			=> ms.WriteByte( value ) ;

		public void PutByteN( System.Byte? value, MemoryStream ms )
			=> PutVUInt09( value, ms ) ;	// 1 + 8 = 9 bit

		public void PutByteT( System.Byte value, MemoryStream ms )
			=> PutVUInt09T( value, ms ) ;	// 1 + 8 = 9 bit

		//---------------

		public void PutSByte( System.SByte value, MemoryStream ms )
			=> ms.WriteByte( ( System.Byte )value ) ;

		public void PutSByteN( System.SByte? value, MemoryStream ms )
			=> PutVUInt09( ( System.Byte? )value, ms ) ;	// 1 + 8 = 9 bit

		public void PutSByteT( System.SByte value, MemoryStream ms )
			=> PutVUInt09T( ( System.Byte )value, ms ) ;	// 1 + 8 = 9 bit

		//---------------

		public void PutChar( System.Char value, MemoryStream ms )
			=> PutVUInt16( ( System.UInt16 )value, ms ) ;	// 7 + 1 + 7 + 1 + 2 = 18 bit

		public void PutCharN( System.Char? value, MemoryStream ms )
			=> PutVUInt17( ( System.UInt16? )( ( System.Char? )value ), ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		//---------------

		public void PutInt16( System.Int16 value, MemoryStream ms )
			=> PutVUInt16( ( System.UInt16 )value, ms ) ;	// 7 + 1 + 7 + 1 + 2 = 18 bit

		public void PutInt16N( System.Int16? value, MemoryStream ms )
			=> PutVUInt17( ( System.UInt16? )value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		public void PutInt16T( System.Int16 value, MemoryStream ms )
			=> PutVUInt17T( ( System.UInt16 )value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		//---------------

		public void PutUInt16( System.UInt16 value, MemoryStream ms )
			=> PutVUInt16( value, ms ) ;	// 7 + 1 + 7 + 1 + 2 = 18 bit

		public void PutUInt16N( System.UInt16? value, MemoryStream ms )
			=> PutVUInt17( value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		public void PutUInt16T( System.UInt16 value, MemoryStream ms )
			=> PutVUInt17T( value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		//---------------

		public void PutInt32( System.Int32 value, MemoryStream ms )
			=> PutVUInt32( ( System.UInt32 )value, ms ) ;	// 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 8 = 36 bit

		public void PutInt32N( System.Int32? value, MemoryStream ms )
			=> PutVUInt33( ( System.UInt32? )value, ms ) ;	// 1 + 32 bit

		public void PutInt32T( System.Int32 value, MemoryStream ms )
			=> PutVUInt33T( ( System.UInt32 )value, ms ) ;	// 1 + 32 bit

		//---------------

		public void PutUInt32( System.UInt32 value, MemoryStream ms )
			=> PutVUInt32( value, ms ) ;	// 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 8 = 36 bit

		public void PutUInt32N( System.UInt32? value, MemoryStream ms )
			=> PutVUInt33( value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		public void PutUInt32T( System.UInt32 value, MemoryStream ms )
			=> PutVUInt33T( value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		//---------------

		public void PutInt64( System.Int64 value, MemoryStream ms )
			=> PutVUInt64( ( System.UInt64 )value, ms ) ;	// 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 8 = 64 bit(9byte)

		public void PutInt64N( System.Int64? value, MemoryStream ms )
			=> PutVUInt65( ( System.UInt64? )value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		public void PutInt64T( System.Int64 value, MemoryStream ms )
			=> PutVUInt65T( ( System.UInt64 )value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		//---------------

		public void PutUInt64( System.UInt64 value, MemoryStream ms )
			=> PutVUInt64( ( System.UInt64 )value, ms ) ;	// 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 7 + 1 + 8 = 64 bit(9byte)

		public void PutUInt64N( System.UInt64? value, MemoryStream ms )
			=> PutVUInt65( value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		public void PutUInt64T( System.UInt64 value, MemoryStream ms )
			=> PutVUInt65T( value, ms ) ;	// 1 + 7 + 1 + 7 + 1 + 2 = 19 bit

		//---------------

		public void PutSingle( System.Single value, MemoryStream ms )
			=> PutSingle_Dispatcher( value, ms ) ;

		public void PutSingleN( System.Single? value, MemoryStream ms )
			=> PutSingleN_Dispatcher( value, ms ) ;

		//-----

		private void PutSingle_Inner( System.Single value, MemoryStream ms )
		{
			ms.Write( BitConverter.GetBytes( value ), 0, 4 ) ;
		}
		private void PutSingleN_Inner( System.Single? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				ms.Write( BitConverter.GetBytes( value.Value ), 0, 4 ) ;
			}
		}

		//-----

		private void PutSingle_Inner_Reverse( System.Single value, MemoryStream ms )
		{
			byte[] b = BitConverter.GetBytes( value ) ;
			m_Work[ 0 ] = b[ 3 ] ; m_Work[ 1 ] = b[ 2 ] ; m_Work[ 2 ] = b[ 1 ] ; m_Work[ 3 ] = b[ 0 ] ;
			ms.Write( m_Work, 0, 4 ) ;
		}
		private void PutSingleN_Inner_Reverse( System.Single? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				byte[] b = BitConverter.GetBytes( ( System.Single )value ) ;
				m_Work[ 0 ] = b[ 3 ] ; m_Work[ 1 ] = b[ 2 ] ; m_Work[ 2 ] = b[ 1 ] ; m_Work[ 3 ] = b[ 0 ] ;
				ms.Write( m_Work, 0, 4 ) ;
			}
		}

		//---------------

		public void PutDouble( System.Double value, MemoryStream ms )
			=> PutDouble_Dispatcher( value, ms ) ;

		public void PutDoubleN( System.Double? value, MemoryStream ms )
			=> PutDoubleN_Dispatcher( value, ms ) ;

		//-----

		private void PutDouble_Inner( System.Double value, MemoryStream ms )
		{
			ms.Write( BitConverter.GetBytes( value ), 0, 8 ) ;
		}
		private void PutDoubleN_Inner( System.Double? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				ms.Write( BitConverter.GetBytes( value.Value ), 0, 8 ) ;
			}
		}

		//-----

		private void PutDouble_Inner_Reverse( System.Double value, MemoryStream ms )
		{
			byte[] b = BitConverter.GetBytes( value ) ;
			m_Work[ 0 ] = b[ 7 ] ; m_Work[ 1 ] = b[ 6 ] ; m_Work[ 2 ] = b[ 5 ] ; m_Work[ 3 ] = b[ 4 ] ; m_Work[ 4 ] = b[ 3 ] ; m_Work[ 5 ] = b[ 2 ] ; m_Work[ 6 ] = b[ 1 ] ; m_Work[ 7 ] = b[ 0 ] ;
			ms.Write( m_Work, 0, 8 ) ;
		}
		private void PutDoubleN_Inner_Reverse( System.Double? value, MemoryStream ms )
		{
			if( value == null )
			{
				ms.WriteByte( 0 ) ;
			}
			else
			{
				ms.WriteByte( 1 ) ;
				byte[] b = BitConverter.GetBytes( ( System.Double ) value ) ;
				m_Work[ 0 ] = b[ 7 ] ; m_Work[ 1 ] = b[ 6 ] ; m_Work[ 2 ] = b[ 5 ] ; m_Work[ 3 ] = b[ 4 ] ; m_Work[ 4 ] = b[ 3 ] ; m_Work[ 5 ] = b[ 2 ] ; m_Work[ 6 ] = b[ 1 ] ; m_Work[ 7 ] = b[ 0 ] ;
				ms.Write( m_Work, 0, 8 ) ;
			}
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
				byte[] b = Encoding.UTF8.GetBytes( value.Value.ToString() ) ;
				ms.WriteByte( ( System.Byte )b.Length ) ;
				ms.Write( b, 0, b.Length ) ;
			}
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
					PutVUInt33( ( System.UInt32 )b.Length, ms ) ;
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
				PutInt64( ( System.Int64 )value.Value.Ticks, ms ) ;
			}
		}

		//-----------------------------------------------------------

		public void PutVUInt09( System.Byte? value08, MemoryStream ms )	// Max 2 byte ( 9(8+1) bit )
		{
			if( value08 == null )
			{
				// null
				ms.WriteByte( 0 ) ;
				return ;
			}

			//----------------------------------

			System.UInt16 value = ( System.UInt16 )( ( value08 << 1 ) | 1 ) ;

			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;				// +0(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )value ) ;							// +1(2(1+1))
			}
		}

		public void PutVUInt09T( System.Byte value08, MemoryStream ms )	// Max 2 byte ( 9(8+1) bit )
		{
			System.UInt16 value = ( System.UInt16 )( ( value08 << 1 ) | 1 ) ;

			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;				// +0(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )value ) ;							// +1(2(1+1))
			}
		}

		public void PutVUInt16( System.UInt16 value, MemoryStream ms )	// Max 3 byte ( 16 bit )
		{
			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;		// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
					value >>= 7 ;

					ms.WriteByte( ( byte )value ) ;				// +2(2)
				}
			}
		}

		private void PutVUInt17( System.UInt16? value16, MemoryStream ms )	// Max 3 byte ( 17(16+1) bit )
		{
			if( value16 == null )
			{
				// null ;
				ms.WriteByte( 0 ) ;
				return ;
			}

			//----------------------------------

			System.UInt32 value = ( System.UInt32 )( ( value16 << 1 ) | 1 ) ;

			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;		// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
					value >>= 7 ;

					ms.WriteByte( ( byte )value ) ;				// +2(3(2+1))
				}
			}
		}

		private void PutVUInt17T( System.UInt16 value16, MemoryStream ms )	// Max 3 byte ( 17(16+1) bit )
		{
			System.UInt32 value = ( System.UInt32 )( ( value16 << 1 ) | 1 ) ;

			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;		// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
					value >>= 7 ;

					ms.WriteByte( ( byte )value ) ;				// +2(3(2+1))
				}
			}
		}

		public void PutVUInt32( System.UInt32 value, MemoryStream ms )	// Max 5 byte ( 32 bit )
		{
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

							ms.WriteByte( ( byte )value ) ;				// +4(4)
						}
					}
				}
			}
		}

		public void PutVUInt33( System.UInt32? value32, MemoryStream ms )	// Max 5 byte ( 33 bit )
		{
			if( value32 == null )
			{
				// null
				ms.WriteByte( 0 ) ;
				return ;
			}

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

		// null bit 無しの 64 bit 値
		private void PutVUInt64( System.UInt64 value, MemoryStream ms )	// Max 10 byte ( 64 bit )
		{
			if( value <  128 )
			{
				ms.WriteByte( ( byte )value ) ;
			}
			else
			{
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;									// +0(7)
				value >>= 7 ;

				if( value <  128 )
				{
					ms.WriteByte( ( byte )value ) ;
				}
				else
				{
					ms.WriteByte( ( byte )( value | 0x80 ) ) ;								// +1(7)
					value >>= 7 ;

					if( value <  128 )
					{
						ms.WriteByte( ( byte )value ) ;
					}
					else
					{
						ms.WriteByte( ( byte )( value | 0x80 ) ) ;							// +2(7)
						value >>= 7 ;

						if( value <  128 )
						{
							ms.WriteByte( ( byte )value ) ;
						}
						else
						{
							ms.WriteByte( ( byte )( value | 0x80 ) ) ;						// +3(7)
							value >>= 7 ;

							if( value <  128 )
							{
								ms.WriteByte( ( byte )value ) ;
							}
							else
							{
								ms.WriteByte( ( byte )( value | 0x80 ) ) ;					// +4(7)
								value >>= 7 ;

								if( value <  128 )
								{
									ms.WriteByte( ( byte )value ) ;
								}
								else
								{
									ms.WriteByte( ( byte )( value | 0x80 ) ) ;				// +5(7)
									value >>= 7 ;

									if( value <  128 )
									{
										ms.WriteByte( ( byte )value ) ;
									}
									else
									{
										ms.WriteByte( ( byte )( value | 0x80 ) ) ;			// +6(7)
										value >>= 7 ;

										if( value <  128 )
										{
											ms.WriteByte( ( byte )value ) ;
										}
										else
										{
											ms.WriteByte( ( byte )( value | 0x80 ) ) ;		// +7(7)
											value >>= 7 ;

											if( value <  128 )
											{
												ms.WriteByte( ( byte )value ) ;
											}
											else
											{
												ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +8(7)
												value >>= 7 ;

												ms.WriteByte( ( byte )value ) ;				// +9(1)
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// null bit 有りの 64 bit 値
		private void PutVUInt65( System.UInt64? value, MemoryStream ms )	// Max 10 byte ( 65 bit )
		{
			if( value == null )
			{
				// null
				ms.WriteByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// 最上位１ビットを退避する
			byte upperBit = ( byte )( ( System.UInt64 )value >> 63 ) ;

			value = ( value << 1 ) | 1 ;	// notNull ビット追加

			if( upperBit == 0 )
			{
				// 最上位１ビットは無い
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

								if( value <  128 )
								{
									ms.WriteByte( ( byte )value ) ;
								}
								else
								{
									ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +4(7)
									value >>= 7 ;

									if( value <  128 )
									{
										ms.WriteByte( ( byte )value ) ;
									}
									else
									{
										ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +5(7)
										value >>= 7 ;

										if( value <  128 )
										{
											ms.WriteByte( ( byte )value ) ;
										}
										else
										{
											ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +6(7)
											value >>= 7 ;

											if( value <  128 )
											{
												ms.WriteByte( ( byte )value ) ;
											}
											else
											{
												ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +7(7)
												value >>= 7 ;

												if( value <  128 )
												{
													ms.WriteByte( ( byte )value ) ;
												}
												else
												{
													ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +8(7)
													value >>= 7 ;

													ms.WriteByte( ( byte )value ) ;				// +9(1)
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				// 最上位ビットが有る
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +0(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +2(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +3(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +4(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +5(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +6(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +7(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +8(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( ( ( byte )value | ( upperBit << 1 ) ) ) ) ;	// +9(2)
			}
		}

		private void PutVUInt65T( System.UInt64 value, MemoryStream ms )	// Max 10 byte ( 65 bit )
		{
			// 最上位１ビットを退避する
			byte upperBit = ( byte )( value >> 63 ) ;

			value = ( value << 1 ) | 1 ;	// notNull ビット追加

			if( upperBit == 0 )
			{
				// 最上位１ビットは無い
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

								if( value <  128 )
								{
									ms.WriteByte( ( byte )value ) ;
								}
								else
								{
									ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +4(7)
									value >>= 7 ;

									if( value <  128 )
									{
										ms.WriteByte( ( byte )value ) ;
									}
									else
									{
										ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +5(7)
										value >>= 7 ;

										if( value <  128 )
										{
											ms.WriteByte( ( byte )value ) ;
										}
										else
										{
											ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +6(7)
											value >>= 7 ;

											if( value <  128 )
											{
												ms.WriteByte( ( byte )value ) ;
											}
											else
											{
												ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +7(7)
												value >>= 7 ;

												if( value <  128 )
												{
													ms.WriteByte( ( byte )value ) ;
												}
												else
												{
													ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +8(7)
													value >>= 7 ;

													ms.WriteByte( ( byte )value ) ;				// +9(1)
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				// 最上位ビットが有る
				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +0(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +1(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +2(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +3(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +4(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +5(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +6(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +7(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( value | 0x80 ) ) ;	// +8(7)
				value >>= 7 ;

				ms.WriteByte( ( byte )( ( ( byte )value | ( upperBit << 1 ) ) ) ) ;	// +9(2)
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
			=> GetVUInt09( ms ) ;

		//---------------

		public System.SByte GetSByte( ByteStream ms )
		{
			var v = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.SByte )v ;
		}
		public System.SByte? GetSByteN( ByteStream ms )
			=> ( System.SByte? )GetVUInt09( ms ) ;

		//---------------

		public System.Char GetChar( ByteStream ms )
			=> ( System.Char )GetVUInt16( ms ) ;

		public System.Char? GetCharN( ByteStream ms )
			=> ( System.Char ? )GetVUInt17( ms ) ;

		//---------------

		public System.Int16 GetInt16( ByteStream ms )
			=> ( System.Int16 )GetVUInt16( ms ) ;

		public System.Int16? GetInt16N( ByteStream ms )
			=> ( System.Int16 ? )GetVUInt17( ms ) ;

		//---------------

		public System.UInt16 GetUInt16( ByteStream ms )
			=> GetVUInt16( ms ) ;

		public System.UInt16? GetUInt16N( ByteStream ms )
			=> GetVUInt17( ms ) ;

		//---------------

		public System.Int32 GetInt32( ByteStream ms )
			=> ( System.Int32 )GetVUInt32( ms ) ;

		public System.Int32? GetInt32N( ByteStream ms )
			=> ( System.Int32? )GetVUInt33( ms ) ;

		//---------------

		public System.UInt32 GetUInt32( ByteStream ms )
			=> GetVUInt32( ms ) ;

		public System.UInt32? GetUInt32N( ByteStream ms )
			=> GetVUInt33( ms ) ;

		//---------------

		public System.Int64 GetInt64( ByteStream ms )
			=> ( System.Int64 )GetVUInt64( ms ) ;

		public System.Int64? GetInt64N( ByteStream ms )
			=> ( System.Int64? )GetVUInt65( ms ) ;

		//---------------

		public System.UInt64 GetUInt64( ByteStream ms )
			=> GetVUInt64( ms ) ;

		public System.UInt64? GetUInt64N( ByteStream ms )
			=> GetVUInt65( ms ) ;

		//---------------

		public System.Single GetSingle( ByteStream ms )
			=> GetSingle_Dispatcher( ms ) ;

		public System.Single? GetSingleN( ByteStream ms )
			=> GetSingleN_Dispatcher( ms ) ;

		//-----

		private System.Single GetSingle_Inner( ByteStream ms )
		{
			var v = BitConverter.ToSingle( ms.Data, ms.Step ) ; ms.Step += 4 ;
			return v ;
		}
		private System.Single? GetSingleN_Inner( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = BitConverter.ToSingle( ms.Data, ms.Step ) ; ms.Step += 4 ;
			return v ;
		}

		//-----

		private System.Single GetSingle_Inner_Reverse( ByteStream ms )
		{
			m_Work[ 0 ] = ms.Data[ ms.Step + 3 ] ; m_Work[ 1 ] = ms.Data[ ms.Step + 2 ] ; m_Work[ 2 ] = ms.Data[ ms.Step + 1 ] ; m_Work[ 3 ] = ms.Data[ ms.Step ] ; ms.Step += 4 ;
			return BitConverter.ToSingle( m_Work, 0 ) ;
		}
		private System.Single? GetSingleN_Inner_Reverse( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			m_Work[ 0 ] = ms.Data[ ms.Step + 3 ] ; m_Work[ 1 ] = ms.Data[ ms.Step + 2 ] ; m_Work[ 2 ] = ms.Data[ ms.Step + 1 ] ; m_Work[ 3 ] = ms.Data[ ms.Step ] ; ms.Step += 4 ;
			return BitConverter.ToSingle( m_Work, 0 ) ;
		}

		//---------------

		public System.Double GetDouble( ByteStream ms )
			=> GetDouble_Dispatcher( ms ) ;

		public System.Double? GetDoubleN( ByteStream ms )
			=> GetDoubleN_Dispatcher( ms ) ;

		//-----

		private System.Double GetDouble_Inner( ByteStream ms )
		{
			var v = BitConverter.ToDouble( ms.Data, ms.Step ) ; ms.Step += 8 ;
			return v ;
		}
		private System.Double? GetDoubleN_Inner( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			var v = BitConverter.ToDouble( ms.Data, ms.Step ) ; ms.Step += 8 ;
			return v ;
		}

		//-----

		private System.Double GetDouble_Inner_Reverse( ByteStream ms )
		{
			m_Work[ 0 ] = ms.Data[ ms.Step + 7 ] ; m_Work[ 1 ] = ms.Data[ ms.Step + 6 ] ; m_Work[ 2 ] = ms.Data[ ms.Step + 5 ] ; m_Work[ 3 ] = ms.Data[ ms.Step + 4 ] ; m_Work[ 4 ] = ms.Data[ ms.Step + 3 ] ; m_Work[ 5 ] = ms.Data[ ms.Step + 2 ] ; m_Work[ 6 ] = ms.Data[ ms.Step + 1 ] ; m_Work[ 7 ] = ms.Data[ ms.Step ] ; ms.Step += 8 ;
			return BitConverter.ToDouble( m_Work, 0 ) ;
		}
		private System.Double? GetDoubleN_Inner_Reverse( ByteStream ms )
		{
			var n = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( n == 0 )
			{
				return null ;
			}
			m_Work[ 0 ] = ms.Data[ ms.Step + 7 ] ; m_Work[ 1 ] = ms.Data[ ms.Step + 6 ] ; m_Work[ 2 ] = ms.Data[ ms.Step + 5 ] ; m_Work[ 3 ] = ms.Data[ ms.Step + 4 ] ; m_Work[ 4 ] = ms.Data[ ms.Step + 3 ] ; m_Work[ 5 ] = ms.Data[ ms.Step + 2 ] ; m_Work[ 6 ] = ms.Data[ ms.Step + 1 ] ; m_Work[ 7 ] = ms.Data[ ms.Step ] ; ms.Step += 8 ;
			return BitConverter.ToDouble( m_Work, 0 ) ;
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

		public System.Byte? GetVUInt09( ByteStream ms )			// Max 2 byte (  8( 9-1) bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 == 0 )
			{
				return null ;
			}
			if( b0 <  128 )
			{
				return ( System.Byte )( b0 >> 1 ) ;				//  6( 7-1) bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.Byte )(								//  8( 9-1) bit
					( b1 <<  6 ) |								// +1(2(1+1))
					( b0 >>  1 )								// +0(7)
			) ;													// 最下位ビットを削る
		}

		public System.UInt16 GetVUInt16( ByteStream ms )			// Max 3 byte ( 16 bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 <  128 )
			{
				return b0 ;
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt16 )(
					( b1 <<  7 ) |					// +1(7)
					  b0							// +0(7)
				) ;
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt16 )(
					( b2 << 14 ) |					// +2(2)
					( b1 <<  7 ) |					// +1(7)
					  b0							// +0(7)
			) ;
		}

		private System.UInt16? GetVUInt17( ByteStream ms )			// Max 3 byte ( 16(17-1) bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 == 0 )
			{
				return null ;
			}
			if( b0 <  128 )
			{
				return ( System.UInt16 )( b0 >> 1 ) ;				//  6( 7-1) bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt16 )( 							// 13(14-1) bit
						( b1 <<  6 ) |								// +1(7)
						( b0 >>  1 )								// +0(7)
				) ;													// 最下位ビットを削る
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt16 )(								// 16(17-1) bit
					( b2 << 13 ) |									// +2(3(2+1))
					( b1 <<  6 ) |									// +1(7)
					( b0 >>  1 )									// +0(7)
			) ;														// 最下位ビットを削る
		}
		
		public System.UInt32 GetVUInt32( ByteStream ms )			// Max 5 byte ( 32 bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 <  128 )
			{
				return b0 ;											//  7 bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt32 )(							// 14 bit
					( b1 <<  7 ) |									// +1(7)
					  b0											// +0(7)
				) ;
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b2 <  128 )
			{
				return ( System.UInt32 )(							// 21 bit
					( b2 << 14 ) |									// +2(7)
					( b1 <<  7 ) |									// +1(7)
					  b0											// +0(7)
				) ;
			}
			b2 &= 0x7F ;

			byte b3 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b3 <  128 )
			{
				return ( System.UInt32 )(							// 28 bit
					( b3 << 21 ) |									// +3(7)
					( b2 << 14 ) |									// +2(7)
					( b1 <<  7 ) |									// +1(7)
					  b0											// +0(7)
				) ;
			}
			b3 &= 0x7F ;

			byte b4 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt32 )(								// 32 bit
				( b4 << 28 ) |										// +4(4)
				( b3 << 21 ) |										// +3(7)
				( b2 << 14 ) |										// +2(7)
				( b1 <<  7 ) |										// +1(7)
				  b0												// +0(7)
			) ;
		}

		public System.UInt32? GetVUInt33( ByteStream ms )			// Max 5 byte ( 32(33-1) bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 == 0 )
			{
				return null ;
			}
			if( b0 <  128 )
			{
				return ( System.UInt32 )( b0 >> 1 ) ;				//  6(7-1) bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt32 )(							// 13(14-1) bit
					( b1 <<  6 ) |									// +1(7)
					( b0 >>  1 )									// +0(7)
				) ;													// 最下位ビットを削る
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b2 <  128 )
			{
				return ( System.UInt32 )(							// 20(21-1) bit
					( b2 << 13 ) |									// +2(7)
					( b1 <<  6 ) |									// +1(7)
					( b0 >>  1 )									// +0(7)
				) ;													// 最下位ビットを削る
			}
			b2 &= 0x7F ;

			byte b3 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b3 <  128 )
			{
				return ( System.UInt32 )(							// 27(28-1) bit
					( b3 << 20 ) |									// +3(7)
					( b2 << 13 ) |									// +2(7)
					( b1 <<  6 ) |									// +1(7)
					( b0 >>  1 )									// +0(7)
				) ;													// 最下位ビットを削る
			}
			b3 &= 0x7F ;

			byte b4 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt32 )(								// 32(33-1) bit
				( b4 << 27 ) |										// +5(5(4+1))
				( b3 << 20 ) |										// +3(7)
				( b2 << 13 ) |										// +2(7)
				( b1 <<  6 ) |										// +1(7)
				( b0 >>  1 )										// +0(7)
			) ;														// 最下位ビットを削る
		}

		// null bit 無しの 64 bit 値
		private System.UInt64 GetVUInt64( ByteStream ms )			// Max 10 byte ( 64 bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ; ;
			if( b0 <  128 )
			{
				return b0 ;											//  7 bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt64 )(							// 14 bit
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b2 <  128 )
			{
				return ( System.UInt64 )(							// 21 bit
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b2 &= 0x7F ;

			byte b3 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b3 <  128 )
			{
				return ( System.UInt64 )(							// 28 bit
					( ( System.UInt64 )b3 << 21 ) |					// +3(7)
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b3 &= 0x7F ;

			byte b4 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b4 <  128 )
			{
				return ( System.UInt64 )(							// 35 bit
					( ( System.UInt64 )b4 << 28 ) |					// +4(7)
					( ( System.UInt64 )b3 << 21 ) |					// +3(7)
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b4 &= 0x7F ;

			byte b5 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b5 <  128 )
			{
				return ( System.UInt64 )(							// 42 bit
					( ( System.UInt64 )b5 << 35 ) |					// +5(7)
					( ( System.UInt64 )b4 << 28 ) |					// +4(7)
					( ( System.UInt64 )b3 << 21 ) |					// +3(7)
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b5 &= 0x7F ;

			byte b6 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b6 <  128 )
			{
				return ( System.UInt64 )(							// 49 bit
					( ( System.UInt64 )b6 << 42 ) |					// +6(7)
					( ( System.UInt64 )b5 << 35 ) |					// +5(7)
					( ( System.UInt64 )b4 << 28 ) |					// +4(7)
					( ( System.UInt64 )b3 << 21 ) |					// +3(7)
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b6 &= 0x7F ;

			byte b7 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b7 <  128 )
			{
				return ( System.UInt64 )(							// 56 bit
					( ( System.UInt64 )b7 << 49 ) |					// +7(7)
					( ( System.UInt64 )b6 << 42 ) |					// +6(7)
					( ( System.UInt64 )b5 << 35 ) |					// +5(7)
					( ( System.UInt64 )b4 << 28 ) |					// +4(7)
					( ( System.UInt64 )b3 << 21 ) |					// +3(7)
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b7 &= 0x7F ;

			byte b8 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b8 <  128 )
			{
				return ( System.UInt64 )(							// 63 bit
					( ( System.UInt64 )b8 << 56 ) |					// +8(7)
					( ( System.UInt64 )b7 << 49 ) |					// +7(7)
					( ( System.UInt64 )b6 << 42 ) |					// +6(7)
					( ( System.UInt64 )b5 << 35 ) |					// +5(7)
					( ( System.UInt64 )b4 << 28 ) |					// +4(7)
					( ( System.UInt64 )b3 << 21 ) |					// +3(7)
					( ( System.UInt64 )b2 << 14 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  7 ) |					// +1(7)
					  ( System.UInt64 )b0							// +0(7)
				) ;
			}
			b8 &= 0x7F ;

			byte b9 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt64 )(								// 64 bit
				( ( System.UInt64 )b9 << 63 ) |						// +9(1)
				( ( System.UInt64 )b8 << 56 ) |						// +8(7)
				( ( System.UInt64 )b7 << 49 ) |						// +7(7)
				( ( System.UInt64 )b6 << 42 ) |						// +6(7)
				( ( System.UInt64 )b5 << 35 ) |						// +5(7)
				( ( System.UInt64 )b4 << 28 ) |						// +4(7)
				( ( System.UInt64 )b3 << 21 ) |						// +3(7)
				( ( System.UInt64 )b2 << 14 ) |						// +2(7)
				( ( System.UInt64 )b1 <<  7 ) |						// +1(7)
				  ( System.UInt64 )b0								// +0(7)
			) ;
		}

		// null bit 有りの 64 bit 値
		private System.UInt64? GetVUInt65( ByteStream ms )			// Max 10 byte ( 64 bit )
		{
			byte b0 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b0 == 0 )
			{
				return null ;
			}
			if( b0 <  128 )
			{
				return ( System.UInt64 )( b0 >> 1 ) ;				//  6( 7-1) bit
			}
			b0 &= 0x7F ;

			byte b1 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b1 <  128 )
			{
				return ( System.UInt64 )(							// 13(14-1) bit
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b1 &= 0x7F ;

			byte b2 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b2 <  128 )
			{
				return ( System.UInt64 )(							// 20(21-1) bit
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1	)					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b2 &= 0x7F ;

			byte b3 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b3 <  128 )
			{
				return ( System.UInt64 )(							// 27(28-1) bit
					( ( System.UInt64 )b3 << 20 ) |					// +3(7)
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b3 &= 0x7F ;

			byte b4 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b4 <  128 )
			{
				return ( System.UInt64 )(							// 34(35-1) bit
					( ( System.UInt64 )b4 << 27 ) |					// +4(7)
					( ( System.UInt64 )b3 << 20 ) |					// +3(7)
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b4 &= 0x7F ;

			byte b5 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b5 <  128 )
			{
				return ( System.UInt64 )(							// 41(42-1) bit
					( ( System.UInt64 )b5 << 34 ) |					// +5(7)
					( ( System.UInt64 )b4 << 27 ) |					// +4(7)
					( ( System.UInt64 )b3 << 20 ) |					// +3(7)
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ; 												// 最下位ビットを削除
			}
			b5 &= 0x7F ;

			byte b6 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b6 <  128 )
			{
				return ( System.UInt64 )(							// 48(49-1) bit
					( ( System.UInt64 )b6 << 41 ) |					// +6(7)
					( ( System.UInt64 )b5 << 34 ) |					// +5(7)
					( ( System.UInt64 )b4 << 27 ) |					// +4(7)
					( ( System.UInt64 )b3 << 20 ) |					// +3(7)
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b6 &= 0x7F ;

			byte b7 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b7 <  128 )
			{
				return ( System.UInt64 )(							// 55(56-1) bit
					( ( System.UInt64 )b7 << 48 ) |					// +7(7)
					( ( System.UInt64 )b6 << 41 ) |					// +6(7)
					( ( System.UInt64 )b5 << 34 ) |					// +5(7)
					( ( System.UInt64 )b4 << 27 ) |					// +4(7)
					( ( System.UInt64 )b3 << 20 ) |					// +3(7)
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b7 &= 0x7F ;

			byte b8 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			if( b8 <  128 )
			{
				return ( System.UInt64 )(							// 62(63-1) bit
					( ( System.UInt64 )b8 << 55 ) |					// +8(7)
					( ( System.UInt64 )b7 << 48 ) |					// +7(7)
					( ( System.UInt64 )b6 << 41 ) |					// +6(7)
					( ( System.UInt64 )b5 << 34 ) |					// +5(7)
					( ( System.UInt64 )b4 << 27 ) |					// +4(7)
					( ( System.UInt64 )b3 << 20 ) |					// +3(7)
					( ( System.UInt64 )b2 << 13 ) |					// +2(7)
					( ( System.UInt64 )b1 <<  6 ) |					// +1(7)
					( ( System.UInt64 )b0 >>  1 )					// +0(6(7-1))
				) ;													// 最下位ビットを削除
			}
			b8 &= 0x7F ;

			byte b9 = ms.Data[ ms.Step ] ; ms.Step ++ ;
			return ( System.UInt64 )(								// 64(65-1) bit
				( ( System.UInt64 )b9 << 61 ) |						// +9(2)
				( ( System.UInt64 )b8 << 55 ) |						// +8(7)
				( ( System.UInt64 )b7 << 48 ) |						// +7(7)
				( ( System.UInt64 )b6 << 41 ) |						// +6(7)
				( ( System.UInt64 )b5 << 34 ) |						// +5(7)
				( ( System.UInt64 )b4 << 27 ) |						// +4(7)
				( ( System.UInt64 )b3 << 20 ) |						// +3(7)
				( ( System.UInt64 )b2 << 13 ) |						// +2(7)
				( ( System.UInt64 )b1 <<  6 ) |						// +1(7)
				( ( System.UInt64 )b0 >>  1 )						// +0(6(7-1))
			) ;														// 最下位ビットを削除(１ビット空きが足りないため先に最下位ビットを削除する必要がある)
		}
	}
}
