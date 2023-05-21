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

	public partial class MyObject_B
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
			if( P33 == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( Byte )P33 ) ; }
			SimpleDataPack.BuiltInAdapter.Array1DBoolean.SerializeT( P34, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DByte.SerializeT( P35, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSByte.SerializeT( P36, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DChar.SerializeT( P37, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt16.SerializeT( P38, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt16.SerializeT( P39, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt32.SerializeT( P40, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt32.SerializeT( P41, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt64.SerializeT( P42, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt64.SerializeT( P43, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSingle.SerializeT( P44, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDouble.SerializeT( P45, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDecimal.SerializeT( P46, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DString.SerializeT( P47, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDateTime.SerializeT( P48, writer ) ;
			SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_B>.PutObject( P49, writer ) ;
			SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_B>.PutObject( P50, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DBooleanN.SerializeT( P51, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DByteN.SerializeT( P52, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSByteN.SerializeT( P53, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DCharN.SerializeT( P54, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt16N.SerializeT( P55, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt16N.SerializeT( P56, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt32N.SerializeT( P57, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt32N.SerializeT( P58, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt64N.SerializeT( P59, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt64N.SerializeT( P60, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSingleN.SerializeT( P61, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDoubleN.SerializeT( P62, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDecimalN.SerializeT( P63, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DString.SerializeT( P64, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDateTimeN.SerializeT( P65, writer ) ;
			SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_B>.PutObject( P66, writer ) ;
			SimpleDataPack.Array1DEnumNAdapter<DSW.MyData.Status_B?>.PutObject( P67, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListBoolean.SerializeT( P68, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListByte.SerializeT( P69, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSByte.SerializeT( P70, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListChar.SerializeT( P71, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt16.SerializeT( P72, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt16.SerializeT( P73, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt32.SerializeT( P74, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt32.SerializeT( P75, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt64.SerializeT( P76, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt64.SerializeT( P77, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSingle.SerializeT( P78, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDouble.SerializeT( P79, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDecimal.SerializeT( P80, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListString.SerializeT( P81, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDateTime.SerializeT( P82, writer ) ;
			SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_B>.PutObject( P83, writer ) ;
			SimpleDataPack.ListEnumAdapter<DSW.MyData.Status_B>.PutObject( P84, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListBooleanN.SerializeT( P85, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListByteN.SerializeT( P86, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSByteN.SerializeT( P87, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListCharN.SerializeT( P88, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt16N.SerializeT( P89, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt16N.SerializeT( P90, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt32N.SerializeT( P91, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt32N.SerializeT( P92, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt64N.SerializeT( P93, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt64N.SerializeT( P94, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSingleN.SerializeT( P95, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDoubleN.SerializeT( P96, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDecimalN.SerializeT( P97, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListString.SerializeT( P98, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDateTimeN.SerializeT( P99, writer ) ;
			SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_B>.PutObject( P100, writer ) ;
			SimpleDataPack.ListEnumNAdapter<DSW.MyData.Status_B?>.PutObject( P101, writer ) ;
			P102.Serialize__SimpleDataPack( writer ) ;
			SimpleDataPack.PutAnyObject( P103, typeof( DSW.MyData.MyStruct_B? ), writer ) ;
			SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_B>.PutObject( P104, writer ) ;
			SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_B?>.PutObject( P105, writer ) ;
			SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_B>.PutObject( P106, writer ) ;
			SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_B?>.PutObject( P107, writer ) ;
			SimpleDataPack.ListGenericAdapter<List<Byte>>.PutObject( P108, writer ) ;
			SimpleDataPack.PutAnyObject( P109, typeof( Dictionary<Byte,String> ), writer ) ;
			SimpleDataPack.BuiltInAdapter.Array3DByte.SerializeT( P110, writer ) ;
			SimpleDataPack.Array1DGenericAdapter<Byte[]>.PutObject( P111, writer ) ;
			SimpleDataPack.ListGenericAdapter<Byte[]>.PutObject( P112, writer ) ;
			SimpleDataPack.ListGenericAdapter<Byte[,]>.PutObject( P113, writer ) ;
			SimpleDataPack.Array1DGenericAdapter<Byte[,]>.PutObject( P114, writer ) ;
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
			P34 = SimpleDataPack.BuiltInAdapter.Array1DBoolean.DeserializeT( reader ) ;
			P35 = SimpleDataPack.BuiltInAdapter.Array1DByte.DeserializeT( reader ) ;
			P36 = SimpleDataPack.BuiltInAdapter.Array1DSByte.DeserializeT( reader ) ;
			P37 = SimpleDataPack.BuiltInAdapter.Array1DChar.DeserializeT( reader ) ;
			P38 = SimpleDataPack.BuiltInAdapter.Array1DInt16.DeserializeT( reader ) ;
			P39 = SimpleDataPack.BuiltInAdapter.Array1DUInt16.DeserializeT( reader ) ;
			P40 = SimpleDataPack.BuiltInAdapter.Array1DInt32.DeserializeT( reader ) ;
			P41 = SimpleDataPack.BuiltInAdapter.Array1DUInt32.DeserializeT( reader ) ;
			P42 = SimpleDataPack.BuiltInAdapter.Array1DInt64.DeserializeT( reader ) ;
			P43 = SimpleDataPack.BuiltInAdapter.Array1DUInt64.DeserializeT( reader ) ;
			P44 = SimpleDataPack.BuiltInAdapter.Array1DSingle.DeserializeT( reader ) ;
			P45 = SimpleDataPack.BuiltInAdapter.Array1DDouble.DeserializeT( reader ) ;
			P46 = SimpleDataPack.BuiltInAdapter.Array1DDecimal.DeserializeT( reader ) ;
			P47 = SimpleDataPack.BuiltInAdapter.Array1DString.DeserializeT( reader ) ;
			P48 = SimpleDataPack.BuiltInAdapter.Array1DDateTime.DeserializeT( reader ) ;
			P49 = SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_B>.GetObject( reader ) ;
			P50 = SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_B>.GetObject( reader ) ;
			P51 = SimpleDataPack.BuiltInAdapter.Array1DBooleanN.DeserializeT( reader ) ;
			P52 = SimpleDataPack.BuiltInAdapter.Array1DByteN.DeserializeT( reader ) ;
			P53 = SimpleDataPack.BuiltInAdapter.Array1DSByteN.DeserializeT( reader ) ;
			P54 = SimpleDataPack.BuiltInAdapter.Array1DCharN.DeserializeT( reader ) ;
			P55 = SimpleDataPack.BuiltInAdapter.Array1DInt16N.DeserializeT( reader ) ;
			P56 = SimpleDataPack.BuiltInAdapter.Array1DUInt16N.DeserializeT( reader ) ;
			P57 = SimpleDataPack.BuiltInAdapter.Array1DInt32N.DeserializeT( reader ) ;
			P58 = SimpleDataPack.BuiltInAdapter.Array1DUInt32N.DeserializeT( reader ) ;
			P59 = SimpleDataPack.BuiltInAdapter.Array1DInt64N.DeserializeT( reader ) ;
			P60 = SimpleDataPack.BuiltInAdapter.Array1DUInt64N.DeserializeT( reader ) ;
			P61 = SimpleDataPack.BuiltInAdapter.Array1DSingleN.DeserializeT( reader ) ;
			P62 = SimpleDataPack.BuiltInAdapter.Array1DDoubleN.DeserializeT( reader ) ;
			P63 = SimpleDataPack.BuiltInAdapter.Array1DDecimalN.DeserializeT( reader ) ;
			P64 = SimpleDataPack.BuiltInAdapter.Array1DString.DeserializeT( reader ) ;
			P65 = SimpleDataPack.BuiltInAdapter.Array1DDateTimeN.DeserializeT( reader ) ;
			P66 = SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_B>.GetObject( reader ) ;
			P67 = SimpleDataPack.Array1DEnumNAdapter<DSW.MyData.Status_B?>.GetObject( reader ) ;
			P68 = SimpleDataPack.BuiltInAdapter.ListBoolean.DeserializeT( reader ) ;
			P69 = SimpleDataPack.BuiltInAdapter.ListByte.DeserializeT( reader ) ;
			P70 = SimpleDataPack.BuiltInAdapter.ListSByte.DeserializeT( reader ) ;
			P71 = SimpleDataPack.BuiltInAdapter.ListChar.DeserializeT( reader ) ;
			P72 = SimpleDataPack.BuiltInAdapter.ListInt16.DeserializeT( reader ) ;
			P73 = SimpleDataPack.BuiltInAdapter.ListUInt16.DeserializeT( reader ) ;
			P74 = SimpleDataPack.BuiltInAdapter.ListInt32.DeserializeT( reader ) ;
			P75 = SimpleDataPack.BuiltInAdapter.ListUInt32.DeserializeT( reader ) ;
			P76 = SimpleDataPack.BuiltInAdapter.ListInt64.DeserializeT( reader ) ;
			P77 = SimpleDataPack.BuiltInAdapter.ListUInt64.DeserializeT( reader ) ;
			P78 = SimpleDataPack.BuiltInAdapter.ListSingle.DeserializeT( reader ) ;
			P79 = SimpleDataPack.BuiltInAdapter.ListDouble.DeserializeT( reader ) ;
			P80 = SimpleDataPack.BuiltInAdapter.ListDecimal.DeserializeT( reader ) ;
			P81 = SimpleDataPack.BuiltInAdapter.ListString.DeserializeT( reader ) ;
			P82 = SimpleDataPack.BuiltInAdapter.ListDateTime.DeserializeT( reader ) ;
			P83 = SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_B>.GetObject( reader ) ;
			P84 = SimpleDataPack.ListEnumAdapter<DSW.MyData.Status_B>.GetObject( reader ) ;
			P85 = SimpleDataPack.BuiltInAdapter.ListBooleanN.DeserializeT( reader ) ;
			P86 = SimpleDataPack.BuiltInAdapter.ListByteN.DeserializeT( reader ) ;
			P87 = SimpleDataPack.BuiltInAdapter.ListSByteN.DeserializeT( reader ) ;
			P88 = SimpleDataPack.BuiltInAdapter.ListCharN.DeserializeT( reader ) ;
			P89 = SimpleDataPack.BuiltInAdapter.ListInt16N.DeserializeT( reader ) ;
			P90 = SimpleDataPack.BuiltInAdapter.ListUInt16N.DeserializeT( reader ) ;
			P91 = SimpleDataPack.BuiltInAdapter.ListInt32N.DeserializeT( reader ) ;
			P92 = SimpleDataPack.BuiltInAdapter.ListUInt32N.DeserializeT( reader ) ;
			P93 = SimpleDataPack.BuiltInAdapter.ListInt64N.DeserializeT( reader ) ;
			P94 = SimpleDataPack.BuiltInAdapter.ListUInt64N.DeserializeT( reader ) ;
			P95 = SimpleDataPack.BuiltInAdapter.ListSingleN.DeserializeT( reader ) ;
			P96 = SimpleDataPack.BuiltInAdapter.ListDoubleN.DeserializeT( reader ) ;
			P97 = SimpleDataPack.BuiltInAdapter.ListDecimalN.DeserializeT( reader ) ;
			P98 = SimpleDataPack.BuiltInAdapter.ListString.DeserializeT( reader ) ;
			P99 = SimpleDataPack.BuiltInAdapter.ListDateTimeN.DeserializeT( reader ) ;
			P100 = SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_B>.GetObject( reader ) ;
			P101 = SimpleDataPack.ListEnumNAdapter<DSW.MyData.Status_B?>.GetObject( reader ) ;
			P102.Deserialize__SimpleDataPack( reader ) ;
			P103 = ( DSW.MyData.MyStruct_B? )SimpleDataPack.GetAnyObject( typeof( DSW.MyData.MyStruct_B? ), reader ) ;
			P104 = SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_B>.GetObject( reader ) ;
			P105 = SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_B?>.GetObject( reader ) ;
			P106 = SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_B>.GetObject( reader ) ;
			P107 = SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_B?>.GetObject( reader ) ;
			P108 = SimpleDataPack.ListGenericAdapter<List<Byte>>.GetObject( reader ) ;
			P109 = ( Dictionary<Byte,String> )SimpleDataPack.GetAnyObject( typeof( Dictionary<Byte,String> ), reader ) ;
			P110 = SimpleDataPack.BuiltInAdapter.Array3DByte.DeserializeT( reader ) ;
			P111 = SimpleDataPack.Array1DGenericAdapter<Byte[]>.GetObject( reader ) ;
			P112 = SimpleDataPack.ListGenericAdapter<Byte[]>.GetObject( reader ) ;
			P113 = SimpleDataPack.ListGenericAdapter<Byte[,]>.GetObject( reader ) ;
			P114 = SimpleDataPack.Array1DGenericAdapter<Byte[,]>.GetObject( reader ) ;
		}
	}

	public partial class MySampleSub_B
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutByte( STR ) ;
			writer.PutByte( INT ) ;
			if( Special == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( Byte )Special ) ; }
			writer.PutByteN( Dummy ) ;
			SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_W>.PutObject( Dummys, writer ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			STR = reader.GetByte() ;
			INT = reader.GetByte() ;
			{ var _ = reader.GetByteN() ; Special = _ == null ? null : ( DSW.MyData.Status_W? )Enum.ToObject( typeof( DSW.MyData.Status_W ), ( Byte )_ ) ; }
			Dummy = reader.GetByteN() ;
			Dummys = SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_W>.GetObject( reader ) ;
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

	public partial class MyObject_W
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutBoolean( P0 ) ;
			writer.PutByte( P1 ) ;
			writer.PutSByte( P2 ) ;
			writer.PutChar( P3 ) ;
			writer.PutInt16( P4 ) ;
			writer.PutInt32( P5 ) ;
			writer.PutInt32( P6 ) ;
			writer.PutUInt32( P7 ) ;
			writer.PutInt64( P8 ) ;
			writer.PutUInt64( P9 ) ;
			writer.PutSingle( P10 ) ;
			writer.PutDouble( P11 ) ;
			writer.PutDecimal( P12 ) ;
			writer.PutString( P13 ) ;
			writer.PutDateTime( P14 ) ;
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
			if( P33 == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( Byte )P33 ) ; }
			SimpleDataPack.BuiltInAdapter.Array1DBoolean.SerializeT( P34, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DByte.SerializeT( P35, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSByte.SerializeT( P36, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DChar.SerializeT( P37, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt16.SerializeT( P38, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt16.SerializeT( P39, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt32.SerializeT( P40, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt32.SerializeT( P41, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt64.SerializeT( P42, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt64.SerializeT( P43, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSingle.SerializeT( P44, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDouble.SerializeT( P45, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDecimal.SerializeT( P46, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DString.SerializeT( P47, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDateTime.SerializeT( P48, writer ) ;
			SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_W>.PutObject( P50, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DBooleanN.SerializeT( P51, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DByteN.SerializeT( P52, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSByteN.SerializeT( P53, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DCharN.SerializeT( P54, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt16N.SerializeT( P55, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt16N.SerializeT( P56, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt32N.SerializeT( P57, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt32N.SerializeT( P58, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DInt64N.SerializeT( P59, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DUInt64N.SerializeT( P60, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DSingleN.SerializeT( P61, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDoubleN.SerializeT( P62, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDecimalN.SerializeT( P63, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DString.SerializeT( P64, writer ) ;
			SimpleDataPack.BuiltInAdapter.Array1DDateTimeN.SerializeT( P65, writer ) ;
			SimpleDataPack.Array1DEnumNAdapter<DSW.MyData.Status_W?>.PutObject( P67, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListBoolean.SerializeT( P68, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListByte.SerializeT( P69, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSByte.SerializeT( P70, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListChar.SerializeT( P71, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt16.SerializeT( P72, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt16.SerializeT( P73, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt32.SerializeT( P74, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt32.SerializeT( P75, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt64.SerializeT( P76, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt64.SerializeT( P77, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSingle.SerializeT( P78, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDouble.SerializeT( P79, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDecimal.SerializeT( P80, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListString.SerializeT( P81, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDateTime.SerializeT( P82, writer ) ;
			SimpleDataPack.ListEnumAdapter<DSW.MyData.Status_W>.PutObject( P84, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListBooleanN.SerializeT( P85, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListByteN.SerializeT( P86, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSByteN.SerializeT( P87, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListCharN.SerializeT( P88, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt16N.SerializeT( P89, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt16N.SerializeT( P90, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt32N.SerializeT( P91, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt32N.SerializeT( P92, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListInt64N.SerializeT( P93, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListUInt64N.SerializeT( P94, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListSingleN.SerializeT( P95, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDoubleN.SerializeT( P96, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDecimalN.SerializeT( P97, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListString.SerializeT( P98, writer ) ;
			SimpleDataPack.BuiltInAdapter.ListDateTimeN.SerializeT( P99, writer ) ;
			SimpleDataPack.ListEnumNAdapter<DSW.MyData.Status_W?>.PutObject( P101, writer ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			P0 = reader.GetBoolean() ;
			P1 = reader.GetByte() ;
			P2 = reader.GetSByte() ;
			P3 = reader.GetChar() ;
			P4 = reader.GetInt16() ;
			P5 = reader.GetInt32() ;
			P6 = reader.GetInt32() ;
			P7 = reader.GetUInt32() ;
			P8 = reader.GetInt64() ;
			P9 = reader.GetUInt64() ;
			P10 = reader.GetSingle() ;
			P11 = reader.GetDouble() ;
			P12 = reader.GetDecimal() ;
			P13 = reader.GetString() ;
			P14 = reader.GetDateTime() ;
			P16 = ( DSW.MyData.Status_W )Enum.ToObject( typeof( DSW.MyData.Status_W ), reader.GetByte() ) ; 
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
			{ var _ = reader.GetByteN() ; P33 = _ == null ? null : ( DSW.MyData.Status_W? )Enum.ToObject( typeof( DSW.MyData.Status_W ), ( Byte )_ ) ; }
			P34 = SimpleDataPack.BuiltInAdapter.Array1DBoolean.DeserializeT( reader ) ;
			P35 = SimpleDataPack.BuiltInAdapter.Array1DByte.DeserializeT( reader ) ;
			P36 = SimpleDataPack.BuiltInAdapter.Array1DSByte.DeserializeT( reader ) ;
			P37 = SimpleDataPack.BuiltInAdapter.Array1DChar.DeserializeT( reader ) ;
			P38 = SimpleDataPack.BuiltInAdapter.Array1DInt16.DeserializeT( reader ) ;
			P39 = SimpleDataPack.BuiltInAdapter.Array1DUInt16.DeserializeT( reader ) ;
			P40 = SimpleDataPack.BuiltInAdapter.Array1DInt32.DeserializeT( reader ) ;
			P41 = SimpleDataPack.BuiltInAdapter.Array1DUInt32.DeserializeT( reader ) ;
			P42 = SimpleDataPack.BuiltInAdapter.Array1DInt64.DeserializeT( reader ) ;
			P43 = SimpleDataPack.BuiltInAdapter.Array1DUInt64.DeserializeT( reader ) ;
			P44 = SimpleDataPack.BuiltInAdapter.Array1DSingle.DeserializeT( reader ) ;
			P45 = SimpleDataPack.BuiltInAdapter.Array1DDouble.DeserializeT( reader ) ;
			P46 = SimpleDataPack.BuiltInAdapter.Array1DDecimal.DeserializeT( reader ) ;
			P47 = SimpleDataPack.BuiltInAdapter.Array1DString.DeserializeT( reader ) ;
			P48 = SimpleDataPack.BuiltInAdapter.Array1DDateTime.DeserializeT( reader ) ;
			P50 = SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_W>.GetObject( reader ) ;
			P51 = SimpleDataPack.BuiltInAdapter.Array1DBooleanN.DeserializeT( reader ) ;
			P52 = SimpleDataPack.BuiltInAdapter.Array1DByteN.DeserializeT( reader ) ;
			P53 = SimpleDataPack.BuiltInAdapter.Array1DSByteN.DeserializeT( reader ) ;
			P54 = SimpleDataPack.BuiltInAdapter.Array1DCharN.DeserializeT( reader ) ;
			P55 = SimpleDataPack.BuiltInAdapter.Array1DInt16N.DeserializeT( reader ) ;
			P56 = SimpleDataPack.BuiltInAdapter.Array1DUInt16N.DeserializeT( reader ) ;
			P57 = SimpleDataPack.BuiltInAdapter.Array1DInt32N.DeserializeT( reader ) ;
			P58 = SimpleDataPack.BuiltInAdapter.Array1DUInt32N.DeserializeT( reader ) ;
			P59 = SimpleDataPack.BuiltInAdapter.Array1DInt64N.DeserializeT( reader ) ;
			P60 = SimpleDataPack.BuiltInAdapter.Array1DUInt64N.DeserializeT( reader ) ;
			P61 = SimpleDataPack.BuiltInAdapter.Array1DSingleN.DeserializeT( reader ) ;
			P62 = SimpleDataPack.BuiltInAdapter.Array1DDoubleN.DeserializeT( reader ) ;
			P63 = SimpleDataPack.BuiltInAdapter.Array1DDecimalN.DeserializeT( reader ) ;
			P64 = SimpleDataPack.BuiltInAdapter.Array1DString.DeserializeT( reader ) ;
			P65 = SimpleDataPack.BuiltInAdapter.Array1DDateTimeN.DeserializeT( reader ) ;
			P67 = SimpleDataPack.Array1DEnumNAdapter<DSW.MyData.Status_W?>.GetObject( reader ) ;
			P68 = SimpleDataPack.BuiltInAdapter.ListBoolean.DeserializeT( reader ) ;
			P69 = SimpleDataPack.BuiltInAdapter.ListByte.DeserializeT( reader ) ;
			P70 = SimpleDataPack.BuiltInAdapter.ListSByte.DeserializeT( reader ) ;
			P71 = SimpleDataPack.BuiltInAdapter.ListChar.DeserializeT( reader ) ;
			P72 = SimpleDataPack.BuiltInAdapter.ListInt16.DeserializeT( reader ) ;
			P73 = SimpleDataPack.BuiltInAdapter.ListUInt16.DeserializeT( reader ) ;
			P74 = SimpleDataPack.BuiltInAdapter.ListInt32.DeserializeT( reader ) ;
			P75 = SimpleDataPack.BuiltInAdapter.ListUInt32.DeserializeT( reader ) ;
			P76 = SimpleDataPack.BuiltInAdapter.ListInt64.DeserializeT( reader ) ;
			P77 = SimpleDataPack.BuiltInAdapter.ListUInt64.DeserializeT( reader ) ;
			P78 = SimpleDataPack.BuiltInAdapter.ListSingle.DeserializeT( reader ) ;
			P79 = SimpleDataPack.BuiltInAdapter.ListDouble.DeserializeT( reader ) ;
			P80 = SimpleDataPack.BuiltInAdapter.ListDecimal.DeserializeT( reader ) ;
			P81 = SimpleDataPack.BuiltInAdapter.ListString.DeserializeT( reader ) ;
			P82 = SimpleDataPack.BuiltInAdapter.ListDateTime.DeserializeT( reader ) ;
			P84 = SimpleDataPack.ListEnumAdapter<DSW.MyData.Status_W>.GetObject( reader ) ;
			P85 = SimpleDataPack.BuiltInAdapter.ListBooleanN.DeserializeT( reader ) ;
			P86 = SimpleDataPack.BuiltInAdapter.ListByteN.DeserializeT( reader ) ;
			P87 = SimpleDataPack.BuiltInAdapter.ListSByteN.DeserializeT( reader ) ;
			P88 = SimpleDataPack.BuiltInAdapter.ListCharN.DeserializeT( reader ) ;
			P89 = SimpleDataPack.BuiltInAdapter.ListInt16N.DeserializeT( reader ) ;
			P90 = SimpleDataPack.BuiltInAdapter.ListUInt16N.DeserializeT( reader ) ;
			P91 = SimpleDataPack.BuiltInAdapter.ListInt32N.DeserializeT( reader ) ;
			P92 = SimpleDataPack.BuiltInAdapter.ListUInt32N.DeserializeT( reader ) ;
			P93 = SimpleDataPack.BuiltInAdapter.ListInt64N.DeserializeT( reader ) ;
			P94 = SimpleDataPack.BuiltInAdapter.ListUInt64N.DeserializeT( reader ) ;
			P95 = SimpleDataPack.BuiltInAdapter.ListSingleN.DeserializeT( reader ) ;
			P96 = SimpleDataPack.BuiltInAdapter.ListDoubleN.DeserializeT( reader ) ;
			P97 = SimpleDataPack.BuiltInAdapter.ListDecimalN.DeserializeT( reader ) ;
			P98 = SimpleDataPack.BuiltInAdapter.ListString.DeserializeT( reader ) ;
			P99 = SimpleDataPack.BuiltInAdapter.ListDateTimeN.DeserializeT( reader ) ;
			P101 = SimpleDataPack.ListEnumNAdapter<DSW.MyData.Status_W?>.GetObject( reader ) ;
		}
	}

	public partial class MySampleSub_W
	{
		public void Serialize__SimpleDataPack( SimpleDataPack.ByteStream writer )
		{
			writer.PutByte( STR ) ;
			writer.PutByte( INT ) ;
			if( Special == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( Byte )Special ) ; }
			writer.PutByteN( Dummy ) ;
			SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_W>.PutObject( Dummys, writer ) ;
		}
		public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )
		{
			STR = reader.GetByte() ;
			INT = reader.GetByte() ;
			{ var _ = reader.GetByteN() ; Special = _ == null ? null : ( DSW.MyData.Status_W? )Enum.ToObject( typeof( DSW.MyData.Status_W ), ( Byte )_ ) ; }
			Dummy = reader.GetByteN() ;
			Dummys = SimpleDataPack.Array1DEnumAdapter<DSW.MyData.Status_W>.GetObject( reader ) ;
		}
	}
}
