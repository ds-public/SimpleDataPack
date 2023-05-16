using System ;
using System.Collections.Generic ;

namespace DSW.MyData
{
	public partial struct MyStruct_B
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutByte( A_Param ) ;
			writer.PutDateTime( B_Param ) ;
			writer.PutString( C_Param ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			A_Param = reader.GetByte() ;
			B_Param = reader.GetDateTime() ;
			C_Param = reader.GetString() ;
		}
	}

	public partial class MySample_B
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutBoolean( P0 ) ;
			writer.PutByte( P1 ) ;
			writer.PutSByte( P2 ) ;
			writer.PutChar( P3 ) ;
			writer.PutInt16( P4 ) ;
			writer.PutUInt16( P5 ) ;
			writer.PutInt32( P6 ) ;
			writer.PutUInt32( P7 ) ;
			writer.PutInt64( P8 ) ;
			writer.PutUInt64( P9 ) ;
			writer.PutSingle( P10 ) ;
			writer.PutDouble( P11 ) ;
			writer.PutDecimal( P12 ) ;
			writer.PutString( P13 ) ;
			writer.PutDateTime( P14 ) ;
			SimpleDataPack.PutAnyObject( P15, typeof( DSW.MyData.MySampleSub_B ), writer ) ;
			writer.PutByte( ( Byte )P16 ) ;
			writer.PutBooleanN( P17 ) ;
			writer.PutByteN( P18 ) ;
			writer.PutSByteN( P19 ) ;
			writer.PutCharN( P20 ) ;
			writer.PutInt16N( P21 ) ;
			writer.PutUInt16N( P22 ) ;
			writer.PutInt32N( P23 ) ;
			writer.PutUInt32N( P24 ) ;
			writer.PutInt64N( P25 ) ;
			writer.PutUInt64N( P26 ) ;
			writer.PutSingleN( P27 ) ;
			writer.PutDoubleN( P28 ) ;
			writer.PutDecimalN( P29 ) ;
			writer.PutString( P30 ) ;
			writer.PutDateTimeN( P31 ) ;
			SimpleDataPack.PutAnyObject( P32, typeof( DSW.MyData.MySampleSub_B ), writer ) ;
			writer.PutByteN( ( Byte? )P33 ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Boolean.Serialize( P34, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Byte.Serialize( P35, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_SByte.Serialize( P36, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Char.Serialize( P37, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int16.Serialize( P38, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt16.Serialize( P39, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int32.Serialize( P40, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt32.Serialize( P41, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int64.Serialize( P42, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt64.Serialize( P43, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Single.Serialize( P44, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Double.Serialize( P45, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Decimal.Serialize( P46, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_String.Serialize( P47, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DateTime.Serialize( P48, writer ) ;
			SimpleDataPack.PutAnyObject( P49, typeof( DSW.MyData.MySampleSub_B ), writer ) ;
			SimpleDataPack.PutAnyObject( P50, typeof( DSW.MyData.Status_B ), writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_BooleanN.Serialize( P51, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_ByteN.Serialize( P52, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_SByteN.Serialize( P53, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_CharN.Serialize( P54, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int16N.Serialize( P55, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt16N.Serialize( P56, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int32N.Serialize( P57, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt32N.Serialize( P58, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int64N.Serialize( P59, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt64N.Serialize( P60, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_SingleN.Serialize( P61, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DoubleN.Serialize( P62, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DecimalN.Serialize( P63, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_String.Serialize( P64, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DateTimeN.Serialize( P65, writer ) ;
			SimpleDataPack.PutAnyObject( P66, typeof( DSW.MyData.MySampleSub_B ), writer ) ;
			SimpleDataPack.PutAnyObject( P67, typeof( DSW.MyData.Status_B? ), writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Boolean.Serialize( P68, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Byte.Serialize( P69, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_SByte.Serialize( P70, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Char.Serialize( P71, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Int16.Serialize( P72, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt16.Serialize( P73, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Int32.Serialize( P74, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt32.Serialize( P75, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Int64.Serialize( P76, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt64.Serialize( P77, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Single.Serialize( P78, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Double.Serialize( P79, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Decimal.Serialize( P80, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_String.Serialize( P81, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_DateTime.Serialize( P82, writer ) ;
			SimpleDataPack.PutAnyObject( P83, typeof( DSW.MyData.MySampleSub_B ), writer ) ;
			SimpleDataPack.PutAnyObject( P84, typeof( DSW.MyData.Status_B ), writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_BooleanN.Serialize( P85, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_ByteN.Serialize( P86, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_SByteN.Serialize( P87, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_CharN.Serialize( P88, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Int16N.Serialize( P89, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt16N.Serialize( P90, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Int32N.Serialize( P91, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt32N.Serialize( P92, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_Int64N.Serialize( P93, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt64N.Serialize( P94, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_SingleN.Serialize( P95, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_DoubleN.Serialize( P96, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_DecimalN.Serialize( P97, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_String.Serialize( P98, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListPrimitive_DateTimeN.Serialize( P99, writer ) ;
			SimpleDataPack.PutAnyObject( P100, typeof( DSW.MyData.MySampleSub_B ), writer ) ;
			SimpleDataPack.PutAnyObject( P101, typeof( DSW.MyData.Status_B? ), writer ) ;
			P102.Serialize__SimpleDataPack( writer ) ;
			SimpleDataPack.PutAnyObject( P103, typeof( DSW.MyData.MyStruct_B? ), writer ) ;
			SimpleDataPack.PutAnyObject( P104, typeof( DSW.MyData.MyStruct_B ), writer ) ;
			SimpleDataPack.PutAnyObject( P105, typeof( DSW.MyData.MyStruct_B? ), writer ) ;
			SimpleDataPack.PutAnyObject( P106, typeof( DSW.MyData.MyStruct_B ), writer ) ;
			SimpleDataPack.PutAnyObject( P107, typeof( DSW.MyData.MyStruct_B? ), writer ) ;
			SimpleDataPack.PutAnyObject( P108, typeof( List<Byte> ), writer ) ;
			SimpleDataPack.PutAnyObject( P109, typeof( Dictionary<Byte,String> ), writer ) ;
			SimpleDataPack.BuiltInAdapter.Array3DPrimitive_Byte.Serialize( P110, writer ) ;
			SimpleDataPack.PutAnyObject( P111, typeof( Byte[] ), writer ) ;
			SimpleDataPack.PutAnyObject( P112, typeof( Byte[] ), writer ) ;
			SimpleDataPack.PutAnyObject( P113, typeof( Byte[,] ), writer ) ;
			SimpleDataPack.PutAnyObject( P114, typeof( Byte[,] ), writer ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			P0 = reader.GetBoolean() ;
			P1 = reader.GetByte() ;
			P2 = reader.GetSByte() ;
			P3 = reader.GetChar() ;
			P4 = reader.GetInt16() ;
			P5 = reader.GetUInt16() ;
			P6 = reader.GetInt32() ;
			P7 = reader.GetUInt32() ;
			P8 = reader.GetInt64() ;
			P9 = reader.GetUInt64() ;
			P10 = reader.GetSingle() ;
			P11 = reader.GetDouble() ;
			P12 = reader.GetDecimal() ;
			P13 = reader.GetString() ;
			P14 = reader.GetDateTime() ;
			P15 = ( DSW.MyData.MySampleSub_B )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MySampleSub_B ), reader ) ;
			P16 = ( DSW.MyData.Status_B )Enum.ToObject( typeof( DSW.MyData.Status_B ), reader.GetByte() ) ; 
			P17 = reader.GetBooleanN() ;
			P18 = reader.GetByteN() ;
			P19 = reader.GetSByteN() ;
			P20 = reader.GetCharN() ;
			P21 = reader.GetInt16N() ;
			P22 = reader.GetUInt16N() ;
			P23 = reader.GetInt32N() ;
			P24 = reader.GetUInt32N() ;
			P25 = reader.GetInt64N() ;
			P26 = reader.GetUInt64N() ;
			P27 = reader.GetSingleN() ;
			P28 = reader.GetDoubleN() ;
			P29 = reader.GetDecimalN() ;
			P30 = reader.GetString() ;
			P31 = reader.GetDateTimeN() ;
			P32 = ( DSW.MyData.MySampleSub_B )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MySampleSub_B ), reader ) ;
			{ var _ = reader.GetByteN() ; P33 = _ == null ? null : ( DSW.MyData.Status_B? )Enum.ToObject( typeof( DSW.MyData.Status_B ), ( Byte )_ ) ; }
			P34 = ( Boolean[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Boolean.Deserialize( reader ) ;
			P35 = ( Byte[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Byte.Deserialize( reader ) ;
			P36 = ( SByte[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_SByte.Deserialize( reader ) ;
			P37 = ( Char[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Char.Deserialize( reader ) ;
			P38 = ( Int16[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int16.Deserialize( reader ) ;
			P39 = ( UInt16[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt16.Deserialize( reader ) ;
			P40 = ( Int32[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int32.Deserialize( reader ) ;
			P41 = ( UInt32[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt32.Deserialize( reader ) ;
			P42 = ( Int64[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int64.Deserialize( reader ) ;
			P43 = ( UInt64[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt64.Deserialize( reader ) ;
			P44 = ( Single[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Single.Deserialize( reader ) ;
			P45 = ( Double[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Double.Deserialize( reader ) ;
			P46 = ( Decimal[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Decimal.Deserialize( reader ) ;
			P47 = ( String[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_String.Deserialize( reader ) ;
			P48 = ( DateTime[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DateTime.Deserialize( reader ) ;
			P49 = ( DSW.MyData.MySampleSub_B[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MySampleSub_B[] ), reader ) ;
			P50 = ( DSW.MyData.Status_B[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.Status_B[] ), reader ) ;
			P51 = ( Boolean?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_BooleanN.Deserialize( reader ) ;
			P52 = ( Byte?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_ByteN.Deserialize( reader ) ;
			P53 = ( SByte?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_SByteN.Deserialize( reader ) ;
			P54 = ( Char?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_CharN.Deserialize( reader ) ;
			P55 = ( Int16?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int16N.Deserialize( reader ) ;
			P56 = ( UInt16?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt16N.Deserialize( reader ) ;
			P57 = ( Int32?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int32N.Deserialize( reader ) ;
			P58 = ( UInt32?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt32N.Deserialize( reader ) ;
			P59 = ( Int64?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_Int64N.Deserialize( reader ) ;
			P60 = ( UInt64?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_UInt64N.Deserialize( reader ) ;
			P61 = ( Single?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_SingleN.Deserialize( reader ) ;
			P62 = ( Double?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DoubleN.Deserialize( reader ) ;
			P63 = ( Decimal?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DecimalN.Deserialize( reader ) ;
			P64 = ( String[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_String.Deserialize( reader ) ;
			P65 = ( DateTime?[] )SimpleDataPack.BuiltInAdapter.Array1DPrimitive_DateTimeN.Deserialize( reader ) ;
			P66 = ( DSW.MyData.MySampleSub_B[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MySampleSub_B[] ), reader ) ;
			P67 = ( DSW.MyData.Status_B?[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.Status_B?[] ), reader ) ;
			P68 = ( List<Boolean> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Boolean.Deserialize( reader ) ;
			P69 = ( List<Byte> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Byte.Deserialize( reader ) ;
			P70 = ( List<SByte> )SimpleDataPack.BuiltInAdapter.ListPrimitive_SByte.Deserialize( reader ) ;
			P71 = ( List<Char> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Char.Deserialize( reader ) ;
			P72 = ( List<Int16> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Int16.Deserialize( reader ) ;
			P73 = ( List<UInt16> )SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt16.Deserialize( reader ) ;
			P74 = ( List<Int32> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Int32.Deserialize( reader ) ;
			P75 = ( List<UInt32> )SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt32.Deserialize( reader ) ;
			P76 = ( List<Int64> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Int64.Deserialize( reader ) ;
			P77 = ( List<UInt64> )SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt64.Deserialize( reader ) ;
			P78 = ( List<Single> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Single.Deserialize( reader ) ;
			P79 = ( List<Double> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Double.Deserialize( reader ) ;
			P80 = ( List<Decimal> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Decimal.Deserialize( reader ) ;
			P81 = ( List<String> )SimpleDataPack.BuiltInAdapter.ListPrimitive_String.Deserialize( reader ) ;
			P82 = ( List<DateTime> )SimpleDataPack.BuiltInAdapter.ListPrimitive_DateTime.Deserialize( reader ) ;
			P83 = ( List<DSW.MyData.MySampleSub_B> )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MySampleSub_B ), reader ) ;
			P84 = ( List<DSW.MyData.Status_B> )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.Status_B ), reader ) ;
			P85 = ( List<Boolean?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_BooleanN.Deserialize( reader ) ;
			P86 = ( List<Byte?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_ByteN.Deserialize( reader ) ;
			P87 = ( List<SByte?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_SByteN.Deserialize( reader ) ;
			P88 = ( List<Char?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_CharN.Deserialize( reader ) ;
			P89 = ( List<Int16?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Int16N.Deserialize( reader ) ;
			P90 = ( List<UInt16?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt16N.Deserialize( reader ) ;
			P91 = ( List<Int32?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Int32N.Deserialize( reader ) ;
			P92 = ( List<UInt32?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt32N.Deserialize( reader ) ;
			P93 = ( List<Int64?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_Int64N.Deserialize( reader ) ;
			P94 = ( List<UInt64?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_UInt64N.Deserialize( reader ) ;
			P95 = ( List<Single?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_SingleN.Deserialize( reader ) ;
			P96 = ( List<Double?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_DoubleN.Deserialize( reader ) ;
			P97 = ( List<Decimal?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_DecimalN.Deserialize( reader ) ;
			P98 = ( List<String> )SimpleDataPack.BuiltInAdapter.ListPrimitive_String.Deserialize( reader ) ;
			P99 = ( List<DateTime?> )SimpleDataPack.BuiltInAdapter.ListPrimitive_DateTimeN.Deserialize( reader ) ;
			P100 = ( List<DSW.MyData.MySampleSub_B> )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MySampleSub_B ), reader ) ;
			P101 = ( List<DSW.MyData.Status_B?> )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.Status_B? ), reader ) ;
			P102.Deserialize__SimpleDataPack( reader ) ;
			P103 = ( DSW.MyData.MyStruct_B? )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MyStruct_B? ), reader ) ;
			P104 = ( DSW.MyData.MyStruct_B[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MyStruct_B[] ), reader ) ;
			P105 = ( DSW.MyData.MyStruct_B?[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MyStruct_B?[] ), reader ) ;
			P106 = ( List<DSW.MyData.MyStruct_B> )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MyStruct_B ), reader ) ;
			P107 = ( List<DSW.MyData.MyStruct_B?> )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MyStruct_B? ), reader ) ;
			P108 = ( List<List<Byte>> )SimpleDataPack.GetAnyObject( typeof( List<List<Byte>> ), reader ) ;
			P109 = ( Dictionary<Byte,String> )SimpleDataPack.GetAnyObject( typeof( Dictionary<Byte,String> ), reader ) ;
			P110 = ( Byte[,,] )SimpleDataPack.BuiltInAdapter.Array3DPrimitive_Byte.Deserialize( reader ) ;
			P111 = ( Byte[][] )SimpleDataPack.GetAnyObject( typeof( Byte[][] ), reader ) ;
			P112 = ( List<Byte[]> )SimpleDataPack.GetAnyObject( typeof( List<Byte[]> ), reader ) ;
			P113 = ( List<Byte[,]> )SimpleDataPack.GetAnyObject( typeof( List<Byte[,]> ), reader ) ;
			P114 = ( Byte[][,] )SimpleDataPack.GetAnyObject( typeof( Byte[][,] ), reader ) ;
		}
	}

	public partial class MySampleSub_B
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutByte( STR ) ;
			writer.PutByte( INT ) ;
			writer.PutByteN( ( Byte? )Special ) ;
			writer.PutByteN( Dummy ) ;
			SimpleDataPack.PutAnyObject( Dummys, typeof( DSW.MyData.Status_W ), writer ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			STR = reader.GetByte() ;
			INT = reader.GetByte() ;
			{ var _ = reader.GetByteN() ; Special = _ == null ? null : ( DSW.MyData.Status_W? )Enum.ToObject( typeof( DSW.MyData.Status_W ), ( Byte )_ ) ; }
			Dummy = reader.GetByteN() ;
			Dummys = ( DSW.MyData.Status_W[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.Status_W[] ), reader ) ;
		}
	}

	public partial struct MyStruct_W
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutByte( A_Param ) ;
			writer.PutDateTime( B_Param ) ;
			writer.PutString( C_Param ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			A_Param = reader.GetByte() ;
			B_Param = reader.GetDateTime() ;
			C_Param = reader.GetString() ;
		}
	}

	public partial class MySample_W
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutBoolean( P0 ) ;
			writer.PutByte( P1 ) ;
			writer.PutSByte( P2 ) ;
			writer.PutChar( P3 ) ;
			writer.PutInt16( P4 ) ;
			writer.PutInt32( P5 ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			P0 = reader.GetBoolean() ;
			P1 = reader.GetByte() ;
			P2 = reader.GetSByte() ;
			P3 = reader.GetChar() ;
			P4 = reader.GetInt16() ;
			P5 = reader.GetInt32() ;
		}
	}

	public partial class MySampleSub_W
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutByte( STR ) ;
			writer.PutByte( INT ) ;
			writer.PutByteN( ( Byte? )Special ) ;
			writer.PutByteN( Dummy ) ;
			SimpleDataPack.PutAnyObject( Dummys, typeof( DSW.MyData.Status_W ), writer ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			STR = reader.GetByte() ;
			INT = reader.GetByte() ;
			{ var _ = reader.GetByteN() ; Special = _ == null ? null : ( DSW.MyData.Status_W? )Enum.ToObject( typeof( DSW.MyData.Status_W ), ( Byte )_ ) ; }
			Dummy = reader.GetByteN() ;
			Dummys = ( DSW.MyData.Status_W[] )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.Status_W[] ), reader ) ;
		}
	}
}
