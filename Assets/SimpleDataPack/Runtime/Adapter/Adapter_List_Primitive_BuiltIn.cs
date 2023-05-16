using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// リストの基底クラス
	public class ListPrimitiveAdapterBase<T> : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			List<T> elements = entity as List<T> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			SetValue( elements, length, writer ) ;
		}

		protected virtual void SetValue( List<T> elements, int length, ByteStream writer ){}

		//------------------------------------------------------------------------------------------

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? uint32 = reader.GetVUInt33() ;
			if( uint32 == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )uint32 ;

			if( length == 0 )
			{
				return new List<T>() ;
			}

			List<T> elements = new List<T>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			GetValue( elements, length, reader ) ;

			return elements ;
		}

		protected virtual void GetValue( List<T> elements, int length, ByteStream reader ){}
	}

	//===================================================================================================================

	// リスト(Boolean)
	public class ListPrimitiveAdapter_Boolean : ListPrimitiveAdapterBase<System.Boolean>
	{
		protected override void SetValue( List<System.Boolean> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutBoolean( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Boolean> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetBoolean() ) ;
			}
		}
	}

	//---------------

	// リスト(Boolean?)
	public class ListPrimitiveAdapter_BooleanN : ListPrimitiveAdapterBase<System.Boolean?>
	{
		protected override void SetValue( List<System.Boolean?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutBooleanN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Boolean?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetBooleanN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Byte)
	public class ListPrimitiveAdapter_Byte : ListPrimitiveAdapterBase<System.Byte>
	{
		protected override void SetValue( List<System.Byte> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutByte( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Byte> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetByte() ) ;
			}
		}
	}

	//---------------

	// リスト(Byte?)
	public class ListPrimitiveAdapter_ByteN : ListPrimitiveAdapterBase<System.Byte?>
	{
		protected override void SetValue( List<System.Byte?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutByteN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Byte?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetByteN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(SByte)
	public class ListPrimitiveAdapter_SByte : ListPrimitiveAdapterBase<System.SByte>
	{
		protected override void SetValue( List<System.SByte> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSByte( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.SByte> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSByte() ) ;
			}
		}
	}

	//---------------

	// リスト(SByte?)
	public class ListPrimitiveAdapter_SByteN : ListPrimitiveAdapterBase<System.SByte?>
	{
		protected override void SetValue( List<System.SByte?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSByteN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.SByte?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSByteN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Char)
	public class ListPrimitiveAdapter_Char : ListPrimitiveAdapterBase<System.Char>
	{
		protected override void SetValue( List<System.Char> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutChar( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Char> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetChar() ) ;
			}
		}
	}

	//---------------

	// リスト(Char?)
	public class ListPrimitiveAdapter_CharN : ListPrimitiveAdapterBase<System.Char?>
	{
		protected override void SetValue( List<System.Char?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutCharN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Char?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetCharN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Int16)
	public class ListPrimitiveAdapter_Int16 : ListPrimitiveAdapterBase<System.Int16>
	{
		protected override void SetValue( List<System.Int16> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt16( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Int16> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt16() ) ;
			}
		}
	}

	//---------------

	// リスト(Int16?)
	public class ListPrimitiveAdapter_Int16N : ListPrimitiveAdapterBase<System.Int16?>
	{
		protected override void SetValue( List<System.Int16?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt16N( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Int16?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt16N() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(UInt16)
	public class ListPrimitiveAdapter_UInt16 : ListPrimitiveAdapterBase<System.UInt16>
	{
		protected override void SetValue( List<System.UInt16> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt16( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.UInt16> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt16() ) ;
			}
		}
	}

	//---------------

	// リスト(UInt16?)
	public class ListPrimitiveAdapter_UInt16N : ListPrimitiveAdapterBase<System.UInt16?>
	{
		protected override void SetValue( List<System.UInt16?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt16N( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.UInt16?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt16N() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Int32)
	public class ListPrimitiveAdapter_Int32 : ListPrimitiveAdapterBase<System.Int32>
	{
		protected override void SetValue( List<System.Int32> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt32( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Int32> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt32() ) ;
			}
		}
	}

	//---------------

	// リスト(Int32?)
	public class ListPrimitiveAdapter_Int32N : ListPrimitiveAdapterBase<System.Int32?>
	{
		protected override void SetValue( List<System.Int32?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt32N( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Int32?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt32N() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(UInt32)
	public class ListPrimitiveAdapter_UInt32 : ListPrimitiveAdapterBase<System.UInt32>
	{
		protected override void SetValue( List<System.UInt32> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt32( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.UInt32> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt32() ) ;
			}
		}
	}

	//---------------

	// リスト(UInt32?)
	public class ListPrimitiveAdapter_UInt32N : ListPrimitiveAdapterBase<System.UInt32?>
	{
		protected override void SetValue( List<System.UInt32?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt32N( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.UInt32?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt32N() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Int64)
	public class ListPrimitiveAdapter_Int64 : ListPrimitiveAdapterBase<System.Int64>
	{
		protected override void SetValue( List<System.Int64> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt64( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Int64> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt64() ) ;
			}
		}
	}

	//---------------

	// リスト(Int64?)
	public class ListPrimitiveAdapter_Int64N : ListPrimitiveAdapterBase<System.Int64?>
	{
		protected override void SetValue( List<System.Int64?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt64N( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Int64?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt64N() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(UInt64)
	public class ListPrimitiveAdapter_UInt64 : ListPrimitiveAdapterBase<System.UInt64>
	{
		protected override void SetValue( List<System.UInt64> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt64( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.UInt64> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt64() ) ;
			}
		}
	}

	//---------------

	// リスト(UInt64?)
	public class ListPrimitiveAdapter_UInt64N : ListPrimitiveAdapterBase<System.UInt64?>
	{
		protected override void SetValue( List<System.UInt64?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt64N( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.UInt64?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt64N() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Single)
	public class ListPrimitiveAdapter_Single : ListPrimitiveAdapterBase<System.Single>
	{
		protected override void SetValue( List<System.Single> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSingle( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Single> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSingle() ) ;
			}
		}
	}

	//---------------

	// リスト(Single?)
	public class ListPrimitiveAdapter_SingleN : ListPrimitiveAdapterBase<System.Single?>
	{
		protected override void SetValue( List<System.Single?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSingleN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Single?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSingleN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Double)
	public class ListPrimitiveAdapter_Double : ListPrimitiveAdapterBase<System.Double>
	{
		protected override void SetValue( List<System.Double> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDouble( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Double> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDouble() ) ;
			}
		}
	}

	//---------------

	// リスト(Double?)
	public class ListPrimitiveAdapter_DoubleN : ListPrimitiveAdapterBase<System.Double?>
	{
		protected override void SetValue( List<System.Double?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDoubleN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Double?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDoubleN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(Decimal)
	public class ListPrimitiveAdapter_Decimal : ListPrimitiveAdapterBase<System.Decimal>
	{
		protected override void SetValue( List<System.Decimal> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDecimal( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Decimal> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDecimal() ) ;
			}
		}
	}

	//---------------

	// リスト(Decimal?)
	public class ListPrimitiveAdapter_DecimalN : ListPrimitiveAdapterBase<System.Decimal?>
	{
		protected override void SetValue( List<System.Decimal?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDecimalN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.Decimal?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDecimalN() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(String)
	public class ListPrimitiveAdapter_String : ListPrimitiveAdapterBase<System.String>
	{
		protected override void SetValue( List<System.String> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutString( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.String> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetString() ) ;
			}
		}
	}

	//-----------------------------------

	// リスト(DateTime)
	public class ListPrimitiveAdapter_DateTime : ListPrimitiveAdapterBase<System.DateTime>
	{
		protected override void SetValue( List<System.DateTime> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDateTime( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.DateTime> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDateTime() ) ;
			}
		}
	}

	//---------------

	// リスト(DateTime?)
	public class ListPrimitiveAdapter_DateTimeN : ListPrimitiveAdapterBase<System.DateTime?>
	{
		protected override void SetValue( List<System.DateTime?> elements, int length, ByteStream writer )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDateTimeN( elements[ index ] ) ;
			}
		}

		protected override void GetValue( List<System.DateTime?> elements, int length, ByteStream reader )
		{
			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDateTimeN() ) ;
			}
		}
	}
}
