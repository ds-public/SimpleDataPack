using System ;
using System.IO ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// バイトストリーム
	/// </summary>
	public class ByteStream
	{
		private IByteConverter	m_BC ;
		private MemoryStream	m_MS ;

		public byte[]			Data ;
		public int				Step ;

		//-----------------------------------------------------------

		// 共通の設定
		public void Initialize( ReadOnlySpan<byte> data, bool isBigEndian, PriorityTypes priorityType )
//		public void Initialize( byte[] data, bool isBigEndian, PriorityTypes priorityType )
		{
			if( data == null )
			{
				// Writer Mode
				m_MS = new MemoryStream( 4096 ) ;
			}
			else
			{
				// Reader Mode
				Data = data.ToArray() ;
				Step = 0 ;
			}

			//----------------------------------

			// マルチスレッド対応のためコンバーターを生成する(内部のワークエリアをスレッドごとに独立させる)
			if( priorityType == PriorityTypes.Speed )
			{
				// スピード重視(固定バイト長)
				Debug.Log( "<color=#FF7FFF>[Serialize]スピード重視で動作</color>" ) ;
				if( isBigEndian != BitConverter.IsLittleEndian )
				{
					m_BC = new ByteConverter() ;
				}
				else
				{
					m_BC = new ByteConverter_Reverse() ;
				}
			}
			else
			{
				// サイズ重視(可変バイト長)
				Debug.Log( "<color=#FF7FFF>[Serialize]サイズ重視で動作</color>" ) ;
				m_BC = new ByteConverter_Variable() ;
				m_BC.SetEndian( isBigEndian ) ;
			}

			//----------------------------------
#if UNITY_EDITOR
			// スピード重視(固定バイト長)
			if( isBigEndian != BitConverter.IsLittleEndian )
			{
				Debug.Log( "<color=#FF00FF>[Serialize]リトルエンディアンで動作</color>" ) ;
			}
			else
			{
				Debug.Log( "<color=#FF00FF>[Serialize]ビッグエンディアンで動作</color>" ) ;
			}
#endif
		}

		//-----------------------------------------------------------

		/// <summary>
		/// 取得する
		/// </summary>
		/// <returns></returns>
		public byte[] GetData()
		{
			if( m_MS != null )
			{
				// Writer Mode
				m_MS.Flush() ;

				return m_MS.ToArray() ;
			}
			else
			{
				// Reader Mode
				return Data ;
			}
		}

		/// <summary>
		/// 破棄する
		/// </summary>
		public void Dispose()
		{
			if( m_MS != null )
			{
				m_MS.Close() ;
				m_MS.Dispose() ;
			}
		}

#if false
		/// <summary>
		/// 位置の設定
		/// </summary>
		/// <param name="offset"></param>
		public void SetOffset( System.Int64 offset )
		{
//			if( m_MS != null && m_MS.CanSeek == true )
//			{
				m_MS.Seek( offset, SeekOrigin.Begin ) ;
//			}
		}
#endif
		/// <summary>
		/// スキップ
		/// </summary>
		/// <param name="skip"></param>
		public void Skip( int skip )
		{
			if( m_MS != null )
			{
				// Writer Mode
				m_MS.Seek( skip, SeekOrigin.Current ) ;
			}
			else
			{
				// Reader Mode
				Step += skip ;
			}
		}

		/// <summary>
		/// オフセット
		/// </summary>
		public System.Int64 Offset
		{
			get
			{
				if( m_MS != null )
				{
					// Writer Mode
					return m_MS.Position ;
				}
				else
				{
					// Reader Mode
					return Step ;
				}
			}
		}

		/// <summary>
		/// サイズ
		/// </summary>
		public System.Int64 Length
		{
			get
			{
				if( m_MS != null )
				{
					// Writer Mode
					return m_MS.Length ;
				}
				else
				{
					// Reader Mode
					return Data.Length ;
				}
			}
		}

		//-----------------------------------------------------------

		public void						PutBoolean( System.Boolean value )										=> m_BC.PutBoolean( value, m_MS ) ;
		public void						PutBooleanN( System.Boolean? value )									=> m_BC.PutBooleanN( value, m_MS ) ;
		public void						PutBooleanT( System.Boolean value )										=> m_BC.PutBooleanT( value, m_MS ) ;

		public void						PutByte( System.Byte value )											=> m_BC.PutByte( value, m_MS ) ;
		public void						PutByteN( System.Byte? value )											=> m_BC.PutByteN( value, m_MS ) ;
		public void						PutByteT( System.Byte value )											=> m_BC.PutByteT( value, m_MS ) ;

		public void						PutSByte( System.SByte value )											=> m_BC.PutSByte( value, m_MS ) ;
		public void						PutSByteN( System.SByte? value )										=> m_BC.PutSByteN( value, m_MS ) ;
		public void						PutSByteT( System.SByte value )											=> m_BC.PutSByteT( value, m_MS ) ;

		public void						PutChar( System.Char value )											=> m_BC.PutChar( value, m_MS ) ;
		public void						PutCharN( System.Char? value )											=> m_BC.PutCharN( value, m_MS ) ;
		public void						PutCharT( System.Char value )											=> m_BC.PutCharT( value, m_MS ) ;

		public void						PutInt16( System.Int16 value )											=> m_BC.PutInt16( value, m_MS ) ;
		public void						PutInt16N( System.Int16? value )										=> m_BC.PutInt16N( value, m_MS ) ;
		public void						PutInt16T( System.Int16 value )											=> m_BC.PutInt16T( value, m_MS ) ;

		public void						PutUInt16( System.UInt16 value )										=> m_BC.PutUInt16( value, m_MS ) ;
		public void						PutUInt16N( System.UInt16? value )										=> m_BC.PutUInt16N( value, m_MS ) ;
		public void						PutUInt16T( System.UInt16 value )										=> m_BC.PutUInt16T( value, m_MS ) ;

		public void						PutInt32( System.Int32 value )											=> m_BC.PutInt32( value, m_MS ) ;
		public void						PutInt32N( System.Int32? value )										=> m_BC.PutInt32N( value, m_MS ) ;
		public void						PutInt32T( System.Int32 value )											=> m_BC.PutInt32T( value, m_MS ) ;

		public void						PutUInt32( System.UInt32 value )										=> m_BC.PutUInt32( value, m_MS ) ;
		public void						PutUInt32N( System.UInt32? value )										=> m_BC.PutUInt32N( value, m_MS ) ;
		public void						PutUInt32T( System.UInt32 value )										=> m_BC.PutUInt32T( value, m_MS ) ;

		public void						PutInt64( System.Int64 value )											=> m_BC.PutInt64( value, m_MS ) ;
		public void						PutInt64N( System.Int64? value )										=> m_BC.PutInt64N( value, m_MS ) ;
		public void						PutInt64T( System.Int64 value )											=> m_BC.PutInt64T( value, m_MS ) ;

		public void						PutUInt64( System.UInt64 value )										=> m_BC.PutUInt64( value, m_MS ) ;
		public void						PutUInt64N( System.UInt64? value )										=> m_BC.PutUInt64N( value, m_MS ) ;
		public void						PutUInt64T( System.UInt64 value )										=> m_BC.PutUInt64T( value, m_MS ) ;

		public void						PutSingle( System.Single value )										=> m_BC.PutSingle( value, m_MS ) ;
		public void						PutSingleN( System.Single? value )										=> m_BC.PutSingleN( value, m_MS ) ;
		public void						PutSingleT( System.Single value )										=> m_BC.PutSingleT( value, m_MS ) ;

		public void						PutDouble( System.Double value )										=> m_BC.PutDouble( value, m_MS ) ;
		public void						PutDoubleN( System.Double? value )										=> m_BC.PutDoubleN( value, m_MS ) ;
		public void						PutDoubleT( System.Double value )										=> m_BC.PutDoubleT( value, m_MS ) ;

		public void						PutDecimal( System.Decimal value )										=> m_BC.PutDecimal( value, m_MS ) ;
		public void						PutDecimalN( System.Decimal? value )									=> m_BC.PutDecimalN( value, m_MS ) ;
		public void						PutDecimalT( System.Decimal value )										=> m_BC.PutDecimalT( value, m_MS ) ;

		public void						PutString( System.String value )										=> m_BC.PutString( value, m_MS ) ;

		public void						PutDateTime( System.DateTime value )									=> m_BC.PutDateTime( value, m_MS ) ;
		public void						PutDateTimeN( System.DateTime? value )									=> m_BC.PutDateTimeN( value, m_MS ) ;
		public void						PutDateTimeT( System.DateTime value )									=> m_BC.PutDateTimeT( value, m_MS ) ;

		//---------------

		public void						PutVUInt32( System.UInt32 value )										=> m_BC.PutVUInt32( value, m_MS ) ;
		public void						PutVUInt33( System.UInt32? value )										=> m_BC.PutVUInt33( value, m_MS ) ;
		public void						PutVUInt33T( System.UInt32 value )										=> m_BC.PutVUInt33T( value, m_MS ) ;

		//-----------------------------------------------------------

		public System.Boolean			GetBoolean()															=> m_BC.GetBoolean( this ) ;
		public System.Boolean?			GetBooleanN()															=> m_BC.GetBooleanN( this ) ;

		public System.Byte				GetByte()																=> m_BC.GetByte( this ) ;
		public System.Byte?				GetByteN()																=> m_BC.GetByteN( this ) ;

		public System.SByte				GetSByte()																=> m_BC.GetSByte( this ) ;
		public System.SByte?			GetSByteN()																=> m_BC.GetSByteN( this ) ;

		public System.Char				GetChar()																=> m_BC.GetChar( this ) ;
		public System.Char?				GetCharN()																=> m_BC.GetCharN( this ) ;

		public System.Int16				GetInt16()																=> m_BC.GetInt16( this ) ;
		public System.Int16?			GetInt16N()																=> m_BC.GetInt16N( this ) ;

		public System.UInt16			GetUInt16()																=> m_BC.GetUInt16( this ) ;
		public System.UInt16?			GetUInt16N()															=> m_BC.GetUInt16N( this ) ;

		public System.Int32				GetInt32()																=> m_BC.GetInt32( this ) ;
		public System.Int32?			GetInt32N()																=> m_BC.GetInt32N( this ) ;

		public System.UInt32			GetUInt32()																=> m_BC.GetUInt32( this ) ;
		public System.UInt32?			GetUInt32N()															=> m_BC.GetUInt32N( this ) ;

		public System.Int64				GetInt64()																=> m_BC.GetInt64( this ) ;
		public System.Int64?			GetInt64N()																=> m_BC.GetInt64N( this ) ;

		public System.UInt64			GetUInt64()																=> m_BC.GetUInt64( this ) ;
		public System.UInt64?			GetUInt64N()															=> m_BC.GetUInt64N( this ) ;

		public System.Single			GetSingle()																=> m_BC.GetSingle( this ) ;
		public System.Single?			GetSingleN()															=> m_BC.GetSingleN( this ) ;

		public System.Double			GetDouble()																=> m_BC.GetDouble( this ) ;
		public System.Double?			GetDoubleN()															=> m_BC.GetDoubleN( this ) ;

		public System.Decimal			GetDecimal()															=> m_BC.GetDecimal( this ) ;
		public System.Decimal?			GetDecimalN()															=> m_BC.GetDecimalN( this ) ;

		public System.String			GetString()																=> m_BC.GetString( this ) ;

		public System.DateTime			GetDateTime()															=> m_BC.GetDateTime( this ) ;
		public System.DateTime?			GetDateTimeN()															=> m_BC.GetDateTimeN( this ) ;

		//---------------

		public System.UInt32			GetVUInt32()															=> m_BC.GetVUInt32( this ) ;
		public System.UInt32?			GetVUInt33()															=> m_BC.GetVUInt33( this ) ;
	}
}
