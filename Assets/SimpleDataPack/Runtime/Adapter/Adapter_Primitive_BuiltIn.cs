using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// プリミティブ(Boolean)
	public class PrimitiveAdapter_Boolean : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutBoolean( ( System.Boolean )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetBoolean() ;
		}
	}

	//---------------

	// プリミティブ(Boolean?)
	public class PrimitiveAdapter_BooleanN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutBooleanN( ( System.Boolean? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetBooleanN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Byte)
	public class PrimitiveAdapter_Byte : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutByte( ( System.Byte )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetByte() ;
		}
	}

	//---------------

	// プリミティブ(Byte?)
	public class PrimitiveAdapter_ByteN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutByteN( ( System.Byte? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetByteN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(SByte)
	public class PrimitiveAdapter_SByte : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutSByte( ( System.SByte )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetSByte() ;
		}
	}

	//---------------

	// プリミティブ(SByte?)
	public class PrimitiveAdapter_SByteN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutSByteN( ( System.SByte? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetSByteN() ;
		}
	}


	//-----------------------------------

	// プリミティブ(Char)
	public class PrimitiveAdapter_Char : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutChar( ( System.Char )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetChar() ;
		}
	}

	//---------------

	// プリミティブ(Char?)
	public class PrimitiveAdapter_CharN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutCharN( ( System.Char? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetCharN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Int16)
	public class PrimitiveAdapter_Int16 : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutInt16( ( System.Int16 )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetInt16() ;
		}
	}

	//---------------

	// プリミティブ(Int16?)
	public class PrimitiveAdapter_Int16N : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutInt16N( ( System.Int16? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetInt16N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(UInt16)
	public class PrimitiveAdapter_UInt16 : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutUInt16( ( System.UInt16 )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetUInt16() ;
		}
	}

	//---------------

	// プリミティブ(UInt16?)
	public class PrimitiveAdapter_UInt16N : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutUInt16N( ( System.UInt16? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetUInt16N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Int32)
	public class PrimitiveAdapter_Int32 : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutInt32( ( System.Int32 )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetInt32() ;
		}
	}

	//---------------

	// プリミティブ(Int32?)
	public class PrimitiveAdapter_Int32N : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutInt32N( ( System.Int32? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetInt32N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(UInt32)
	public class PrimitiveAdapter_UInt32 : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutUInt32( ( System.UInt32 )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetUInt32() ;
		}
	}

	//---------------

	// プリミティブ(UInt32?)
	public class PrimitiveAdapter_UInt32N : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutUInt32N( ( System.UInt32? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetUInt32N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Int64)
	public class PrimitiveAdapter_Int64 : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutInt64( ( System.Int64 )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetInt64() ;
		}
	}

	//---------------

	// プリミティブ(Int64?)
	public class PrimitiveAdapter_Int64N : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutInt64N( ( System.Int64? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetInt64N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(UInt64)
	public class PrimitiveAdapter_UInt64 : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutUInt64( ( System.UInt64 )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetUInt64() ;
		}
	}

	//---------------

	// プリミティブ(UInt64?)
	public class PrimitiveAdapter_UInt64N : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutUInt64N( ( System.UInt64? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetUInt64N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Single)
	public class PrimitiveAdapter_Single : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutSingle( ( System.Single )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetSingle() ;
		}
	}

	//---------------

	// プリミティブ(Single?)
	public class PrimitiveAdapter_SingleN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutSingleN( ( System.Single? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetSingleN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Double)
	public class PrimitiveAdapter_Double : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutDouble( ( System.Double )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetDouble() ;
		}
	}

	//---------------

	// プリミティブ(Double?)
	public class PrimitiveAdapter_DoubleN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutDoubleN( ( System.Double? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetDoubleN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Decimal)
	public class PrimitiveAdapter_Decimal : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutDecimal( ( System.Decimal )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetDecimal() ;
		}
	}

	//---------------

	// プリミティブ(Decimal?)
	public class PrimitiveAdapter_DecimalN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutDecimalN( ( System.Decimal? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetDecimalN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(String)
	public class PrimitiveAdapter_String : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutString( ( System.String )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetString() ;
		}
	}

	//-----------------------------------

	// プリミティブ(DateTime)
	public class PrimitiveAdapter_DateTime : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutDateTime( ( System.DateTime )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetDateTime() ;
		}
	}

	//---------------

	// プリミティブ(DateTime?)
	public class PrimitiveAdapter_DateTimeN : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			writer.PutDateTimeN( ( System.DateTime? )entity ) ;
		}

		public System.Object Deserialize( ByteStream reader )
		{
			return reader.GetDateTimeN() ;
		}
	}



#if false
	// プリミティブ(Boolean)
	public class PrimitiveAdapter_Boolean : IAdapter<System.Booloean>
	{
		public void Serialize( System.Boolean entity, ByteStream writer )
		{
			writer.PutBoolean( entity ) ;
		}

		public Boolean Deserialize( ByteStream reader )
		{
			return reader.GetBoolean() ;
		}
	}

	//---------------

	// プリミティブ(Boolean?)
	public class PrimitiveAdapter_BooleanN : IAdapter<System.Boolean?>
	{
		public void Serialize( System.Boolean? entity, ByteStream writer )
		{
			writer.PutBooleanN( entity ) ;
		}

		public System.Boolean? Deserialize( ByteStream reader )
		{
			return reader.GetBooleanN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Byte)
	public class PrimitiveAdapter_Byte : IAdapter<System.Byte>
	{
		public void Serialize( System.Byte entity, ByteStream writer )
		{
			writer.PutByte( entity ) ;
		}

		public System.Byte Deserialize( ByteStream reader )
		{
			return reader.GetByte() ;
		}
	}

	//---------------

	// プリミティブ(Byte?)
	public class PrimitiveAdapter_ByteN : IAdapter<System.Byte?>
	{
		public void Serialize( System.Byte? entity, ByteStream writer )
		{
			writer.PutByteN( entity ) ;
		}

		public System.Byte? Deserialize( ByteStream reader )
		{
			return reader.GetByteN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(SByte)
	public class PrimitiveAdapter_SByte : IAdapter<System.SByte>
	{
		public void Serialize( System.SByte entity, ByteStream writer )
		{
			writer.PutSByte( entity ) ;
		}

		public System.SByte Deserialize( ByteStream reader )
		{
			return reader.GetSByte() ;
		}
	}

	//---------------

	// プリミティブ(SByte?)
	public class PrimitiveAdapter_SByteN : IAdapter<System.SByte?>
	{
		public void Serialize( System.SByte? entity, ByteStream writer )
		{
			writer.PutSByteN( entity ) ;
		}

		public System.SByte? Deserialize( ByteStream reader )
		{
			return reader.GetSByteN() ;
		}
	}


	//-----------------------------------

	// プリミティブ(Char)
	public class PrimitiveAdapter_Char : IAdapter<System.Char>
	{
		public void Serialize( System.Char entity, ByteStream writer )
		{
			writer.PutChar( entity ) ;
		}

		public System.Char Deserialize( ByteStream reader )
		{
			return reader.GetChar() ;
		}
	}

	//---------------

	// プリミティブ(Char?)
	public class PrimitiveAdapter_CharN : IAdapter<System.Char?>
	{
		public void Serialize( System.Char? entity, ByteStream writer )
		{
			writer.PutCharN( entity ) ;
		}

		public System.Char? Deserialize( ByteStream reader )
		{
			return reader.GetCharN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Int16)
	public class PrimitiveAdapter_Int16 : IAdapter<System.Int16>
	{
		public void Serialize( System.Int16 entity, ByteStream writer )
		{
			writer.PutInt16( entity ) ;
		}

		public System.Int16 Deserialize( ByteStream reader )
		{
			return reader.GetInt16() ;
		}
	}

	//---------------

	// プリミティブ(Int16?)
	public class PrimitiveAdapter_Int16N : IAdapter<System.Int16?>
	{
		public void Serialize( System.Int16? entity, ByteStream writer )
		{
			writer.PutInt16N( entity ) ;
		}

		public System.Int16? Deserialize( ByteStream reader )
		{
			return reader.GetInt16N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(UInt16)
	public class PrimitiveAdapter_UInt16 : IAdapter<System.UInt16>
	{
		public void Serialize( System.UInt16 entity, ByteStream writer )
		{
			writer.PutUInt16( entity ) ;
		}

		public System.UInt16 Deserialize( ByteStream reader )
		{
			return reader.GetUInt16() ;
		}
	}

	//---------------

	// プリミティブ(UInt16?)
	public class PrimitiveAdapter_UInt16N : IAdapter<System.UInt16?>
	{
		public void Serialize( System.UInt16? entity, ByteStream writer )
		{
			writer.PutUInt16N( entity ) ;
		}

		public System.UInt16? Deserialize( ByteStream reader )
		{
			return reader.GetUInt16N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Int32)
	public class PrimitiveAdapter_Int32 : IAdapter<System.Int32>
	{
		public void Serialize( System.Int32 entity, ByteStream writer )
		{
			writer.PutInt32( entity ) ;
		}

		public System.Int32 Deserialize( ByteStream reader )
		{
			return reader.GetInt32() ;
		}
	}

	//---------------

	// プリミティブ(Int32?)
	public class PrimitiveAdapter_Int32N : IAdapter<System.Int32?>
	{
		public void Serialize( System.Int32? entity, ByteStream writer )
		{
			writer.PutInt32N( entity ) ;
		}

		public System.Int32? Deserialize( ByteStream reader )
		{
			return reader.GetInt32N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(UInt32)
	public class PrimitiveAdapter_UInt32 : IAdapter<System.UInt32>
	{
		public void Serialize( System.UInt32 entity, ByteStream writer )
		{
			writer.PutUInt32( entity ) ;
		}

		public System.UInt32 Deserialize( ByteStream reader )
		{
			return reader.GetUInt32() ;
		}
	}

	//---------------

	// プリミティブ(UInt32?)
	public class PrimitiveAdapter_UInt32N : IAdapter<System.UInt32?>
	{
		public void Serialize( System.UInt32? entity, ByteStream writer )
		{
			writer.PutUInt32N( entity ) ;
		}

		public System.UInt32? Deserialize( ByteStream reader )
		{
			return reader.GetUInt32N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Int64)
	public class PrimitiveAdapter_Int64 : IAdapter<System.Int64>
	{
		public void Serialize( System.Int64 entity, ByteStream writer )
		{
			writer.PutInt64( entity ) ;
		}

		public System.Int64 Deserialize( ByteStream reader )
		{
			return reader.GetInt64() ;
		}
	}

	//---------------

	// プリミティブ(Int64?)
	public class PrimitiveAdapter_Int64N : IAdapter<System.Int64?>
	{
		public void Serialize( System.Int64? entity, ByteStream writer )
		{
			writer.PutInt64N( entity ) ;
		}

		public System.Int64? Deserialize( ByteStream reader )
		{
			return reader.GetInt64N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(UInt64)
	public class PrimitiveAdapter_UInt64 : IAdapter<System.UInt64>
	{
		public void Serialize( System.UInt64 entity, ByteStream writer )
		{
			writer.PutUInt64( entity ) ;
		}

		public System.UInt64 Deserialize( ByteStream reader )
		{
			return reader.GetUInt64() ;
		}
	}

	//---------------

	// プリミティブ(UInt64?)
	public class PrimitiveAdapter_UInt64N : IAdapter<System.UInt64?>
	{
		public void Serialize( System.UInt64? entity, ByteStream writer )
		{
			writer.PutUInt64N( entity ) ;
		}

		public System.UInt64? Deserialize( ByteStream reader )
		{
			return reader.GetUInt64N() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Single)
	public class PrimitiveAdapter_Single : IAdapter<System.Single>
	{
		public void Serialize( System.Single entity, ByteStream writer )
		{
			writer.PutSingle( entity ) ;
		}

		public System.Single Deserialize( ByteStream reader )
		{
			return reader.GetSingle() ;
		}
	}

	//---------------

	// プリミティブ(Single?)
	public class PrimitiveAdapter_SingleN : IAdapter<System.Single?>
	{
		public void Serialize( System.Single? entity, ByteStream writer )
		{
			writer.PutSingleN( entity ) ;
		}

		public System.Single? Deserialize( ByteStream reader )
		{
			return reader.GetSingleN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Double)
	public class PrimitiveAdapter_Double : IAdapter<System.Double>
	{
		public void Serialize( System.Double entity, ByteStream writer )
		{
			writer.PutDouble( entity ) ;
		}

		public System.Double Deserialize( ByteStream reader )
		{
			return reader.GetDouble() ;
		}
	}

	//---------------

	// プリミティブ(Double?)
	public class PrimitiveAdapter_DoubleN : IAdapter<System.Double?>
	{
		public void Serialize( System.Double? entity, ByteStream writer )
		{
			writer.PutDoubleN( entity ) ;
		}

		public System.Double? Deserialize( ByteStream reader )
		{
			return reader.GetDoubleN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(Decimal)
	public class PrimitiveAdapter_Decimal : IAdapter<System.Decimal>
	{
		public void Serialize( System.Decimal entity, ByteStream writer )
		{
			writer.PutDecimal( entity ) ;
		}

		public System.Decimal Deserialize( ByteStream reader )
		{
			return reader.GetDecimal() ;
		}
	}

	//---------------

	// プリミティブ(Decimal?)
	public class PrimitiveAdapter_DecimalN : IAdapter<System.Decimal?>
	{
		public void Serialize( System.Decimal? entity, ByteStream writer )
		{
			writer.PutDecimalN( entity ) ;
		}

		public System.Decimal? Deserialize( ByteStream reader )
		{
			return reader.GetDecimalN() ;
		}
	}

	//-----------------------------------

	// プリミティブ(String)
	public class PrimitiveAdapter_String : IAdapter<System.String>
	{
		public void Serialize( System.String entity, ByteStream writer )
		{
			writer.PutString( entity ) ;
		}

		public System.String Deserialize( ByteStream reader )
		{
			return reader.GetString() ;
		}
	}

	//-----------------------------------

	// プリミティブ(DateTime)
	public class PrimitiveAdapter_DateTime : IAdapter<System.DateTime>
	{
		public void Serialize( System.DateTime entity, ByteStream writer )
		{
			writer.PutDateTime( entity ) ;
		}

		public System.DateTime Deserialize( ByteStream reader )
		{
			return reader.GetDateTime() ;
		}
	}

	//---------------

	// プリミティブ(DateTime?)
	public class PrimitiveAdapter_DateTimeN : IAdapter<System.DateTime?>
	{
		public void Serialize( System.DateTime? entity, ByteStream writer )
		{
			writer.PutDateTimeN( entity ) ;
		}

		public System.DateTime? Deserialize( ByteStream reader )
		{
			return reader.GetDateTimeN() ;
		}
	}
#endif
}
