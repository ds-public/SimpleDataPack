using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// ビルトインアダプター
	/// </summary>
	public partial class BuiltInAdapter
	{
		public BuiltInAdapter()
		{
			// プリミティブ型のアダプター生成

			Primitive_Boolean			= new PrimitiveAdapter_Boolean()	;
			Primitive_BooleanN			= new PrimitiveAdapter_BooleanN()	;
			Primitive_Byte				= new PrimitiveAdapter_Byte()		;
			Primitive_ByteN				= new PrimitiveAdapter_ByteN()		;
			Primitive_SByte				= new PrimitiveAdapter_SByte()		;
			Primitive_SByteN			= new PrimitiveAdapter_SByteN()		;
			Primitive_Char				= new PrimitiveAdapter_Char()		;
			Primitive_CharN				= new PrimitiveAdapter_CharN()		;
			Primitive_Int16				= new PrimitiveAdapter_Int16()		;
			Primitive_Int16N			= new PrimitiveAdapter_Int16N()		;
			Primitive_UInt16			= new PrimitiveAdapter_UInt16()		;
			Primitive_UInt16N			= new PrimitiveAdapter_UInt16N()	;
			Primitive_Int32				= new PrimitiveAdapter_Int32()		;
			Primitive_Int32N			= new PrimitiveAdapter_Int32N()		;
			Primitive_UInt32			= new PrimitiveAdapter_UInt32()		;
			Primitive_UInt32N			= new PrimitiveAdapter_UInt32N()	;
			Primitive_Int64				= new PrimitiveAdapter_Int64()		;
			Primitive_Int64N			= new PrimitiveAdapter_Int64N()		;
			Primitive_UInt64			= new PrimitiveAdapter_UInt64()		;
			Primitive_UInt64N			= new PrimitiveAdapter_UInt64N()	;
			Primitive_Single			= new PrimitiveAdapter_Single()		;
			Primitive_SingleN			= new PrimitiveAdapter_SingleN()	;
			Primitive_Double			= new PrimitiveAdapter_Double()		;
			Primitive_DoubleN			= new PrimitiveAdapter_DoubleN()	;
			Primitive_Decimal			= new PrimitiveAdapter_Decimal()	;
			Primitive_DecimalN			= new PrimitiveAdapter_DecimalN()	;
			Primitive_String			= new PrimitiveAdapter_String()		;
			Primitive_DateTime			= new PrimitiveAdapter_DateTime()	;
			Primitive_DateTimeN			= new PrimitiveAdapter_DateTimeN()	;


			// アレイ型のアダプター生成

			// １次元
			Array1DBoolean				= new Array1DBooleanAdapter()		;
			Array1DBooleanN				= new Array1DBooleanNAdapter()		;
			Array1DByte					= new Array1DByteAdapter()			;
			Array1DByteN				= new Array1DByteNAdapter()			;
			Array1DSByte				= new Array1DSByteAdapter()			;
			Array1DSByteN				= new Array1DSByteNAdapter()		;
			Array1DChar					= new Array1DCharAdapter()			;
			Array1DCharN				= new Array1DCharNAdapter()			;
			Array1DInt16				= new Array1DInt16Adapter()			;
			Array1DInt16N				= new Array1DInt16NAdapter()		;
			Array1DUInt16				= new Array1DUInt16Adapter()		;
			Array1DUInt16N				= new Array1DUInt16NAdapter()		;
			Array1DInt32				= new Array1DInt32Adapter()			;
			Array1DInt32N				= new Array1DInt32NAdapter()		;
			Array1DUInt32				= new Array1DUInt32Adapter()		;
			Array1DUInt32N				= new Array1DUInt32NAdapter()		;
			Array1DInt64				= new Array1DInt64Adapter()			;
			Array1DInt64N				= new Array1DInt64NAdapter()		;
			Array1DUInt64				= new Array1DUInt64Adapter()		;
			Array1DUInt64N				= new Array1DUInt64NAdapter()		;
			Array1DSingle				= new Array1DSingleAdapter()		;
			Array1DSingleN				= new Array1DSingleNAdapter()		;
			Array1DDouble				= new Array1DDoubleAdapter()		;
			Array1DDoubleN				= new Array1DDoubleNAdapter()		;
			Array1DDecimal				= new Array1DDecimalAdapter()		;
			Array1DDecimalN				= new Array1DDecimalNAdapter()		;
			Array1DString				= new Array1DStringAdapter()		;
			Array1DDateTime				= new Array1DDateTimeAdapter()		;
			Array1DDateTimeN			= new Array1DDateTimeNAdapter()		;

			// ２次元
			Array2DBoolean				= new Array2DBooleanAdapter()		;
			Array2DBooleanN				= new Array2DBooleanNAdapter()		;
			Array2DByte					= new Array2DByteAdapter()			;
			Array2DByteN				= new Array2DByteNAdapter()			;
			Array2DSByte				= new Array2DSByteAdapter()			;
			Array2DSByteN				= new Array2DSByteNAdapter()		;
			Array2DChar					= new Array2DCharAdapter()			;
			Array2DCharN				= new Array2DCharNAdapter()			;
			Array2DInt16				= new Array2DInt16Adapter()			;
			Array2DInt16N				= new Array2DInt16NAdapter()		;
			Array2DUInt16				= new Array2DUInt16Adapter()		;
			Array2DUInt16N				= new Array2DUInt16NAdapter()		;
			Array2DInt32				= new Array2DInt32Adapter()			;
			Array2DInt32N				= new Array2DInt32NAdapter()		;
			Array2DUInt32				= new Array2DUInt32Adapter()		;
			Array2DUInt32N				= new Array2DUInt32NAdapter()		;
			Array2DInt64				= new Array2DInt64Adapter()			;
			Array2DInt64N				= new Array2DInt64NAdapter()		;
			Array2DUInt64				= new Array2DUInt64Adapter()		;
			Array2DUInt64N				= new Array2DUInt64NAdapter()		;
			Array2DSingle				= new Array2DSingleAdapter()		;
			Array2DSingleN				= new Array2DSingleNAdapter()		;
			Array2DDouble				= new Array2DDoubleAdapter()		;
			Array2DDoubleN				= new Array2DDoubleNAdapter()		;
			Array2DDecimal				= new Array2DDecimalAdapter()		;
			Array2DDecimalN				= new Array2DDecimalNAdapter()		;
			Array2DString				= new Array2DStringAdapter()		;
			Array2DDateTime				= new Array2DDateTimeAdapter()		;
			Array2DDateTimeN			= new Array2DDateTimeNAdapter()		;

			// ３次元
			Array3DPrimitive_Boolean	= new Array3DPrimitiveAdapter_Boolean()		;
			Array3DPrimitive_BooleanN	= new Array3DPrimitiveAdapter_BooleanN()	;
			Array3DPrimitive_Byte		= new Array3DPrimitiveAdapter_Byte()		;
			Array3DPrimitive_ByteN		= new Array3DPrimitiveAdapter_ByteN()		;
			Array3DPrimitive_SByte		= new Array3DPrimitiveAdapter_SByte()		;
			Array3DPrimitive_SByteN		= new Array3DPrimitiveAdapter_SByteN()		;
			Array3DPrimitive_Char		= new Array3DPrimitiveAdapter_Char()		;
			Array3DPrimitive_CharN		= new Array3DPrimitiveAdapter_CharN()		;
			Array3DPrimitive_Int16		= new Array3DPrimitiveAdapter_Int16()		;
			Array3DPrimitive_Int16N		= new Array3DPrimitiveAdapter_Int16N()		;
			Array3DPrimitive_UInt16		= new Array3DPrimitiveAdapter_UInt16()		;
			Array3DPrimitive_UInt16N	= new Array3DPrimitiveAdapter_UInt16N()		;
			Array3DPrimitive_Int32		= new Array3DPrimitiveAdapter_Int32()		;
			Array3DPrimitive_Int32N		= new Array3DPrimitiveAdapter_Int32N()		;
			Array3DPrimitive_UInt32		= new Array3DPrimitiveAdapter_UInt32()		;
			Array3DPrimitive_UInt32N	= new Array3DPrimitiveAdapter_UInt32N()		;
			Array3DPrimitive_Int64		= new Array3DPrimitiveAdapter_Int64()		;
			Array3DPrimitive_Int64N		= new Array3DPrimitiveAdapter_Int64N()		;
			Array3DPrimitive_UInt64		= new Array3DPrimitiveAdapter_UInt64()		;
			Array3DPrimitive_UInt64N	= new Array3DPrimitiveAdapter_UInt64N()		;
			Array3DPrimitive_Single		= new Array3DPrimitiveAdapter_Single()		;
			Array3DPrimitive_SingleN	= new Array3DPrimitiveAdapter_SingleN()		;
			Array3DPrimitive_Double		= new Array3DPrimitiveAdapter_Double()		;
			Array3DPrimitive_DoubleN	= new Array3DPrimitiveAdapter_DoubleN()		;
			Array3DPrimitive_Decimal	= new Array3DPrimitiveAdapter_Decimal()		;
			Array3DPrimitive_DecimalN	= new Array3DPrimitiveAdapter_DecimalN()	;
			Array3DPrimitive_String		= new Array3DPrimitiveAdapter_String()		;
			Array3DPrimitive_DateTime	= new Array3DPrimitiveAdapter_DateTime()	;
			Array3DPrimitive_DateTimeN	= new Array3DPrimitiveAdapter_DateTimeN()	;

			// ４次元
			Array4DPrimitive_Boolean	= new Array4DPrimitiveAdapter_Boolean()		;
			Array4DPrimitive_BooleanN	= new Array4DPrimitiveAdapter_BooleanN()	;
			Array4DPrimitive_Byte		= new Array4DPrimitiveAdapter_Byte()		;
			Array4DPrimitive_ByteN		= new Array4DPrimitiveAdapter_ByteN()		;
			Array4DPrimitive_SByte		= new Array4DPrimitiveAdapter_SByte()		;
			Array4DPrimitive_SByteN		= new Array4DPrimitiveAdapter_SByteN()		;
			Array4DPrimitive_Char		= new Array4DPrimitiveAdapter_Char()		;
			Array4DPrimitive_CharN		= new Array4DPrimitiveAdapter_CharN()		;
			Array4DPrimitive_Int16		= new Array4DPrimitiveAdapter_Int16()		;
			Array4DPrimitive_Int16N		= new Array4DPrimitiveAdapter_Int16N()		;
			Array4DPrimitive_UInt16		= new Array4DPrimitiveAdapter_UInt16()		;
			Array4DPrimitive_UInt16N	= new Array4DPrimitiveAdapter_UInt16N()		;
			Array4DPrimitive_Int32		= new Array4DPrimitiveAdapter_Int32()		;
			Array4DPrimitive_Int32N		= new Array4DPrimitiveAdapter_Int32N()		;
			Array4DPrimitive_UInt32		= new Array4DPrimitiveAdapter_UInt32()		;
			Array4DPrimitive_UInt32N	= new Array4DPrimitiveAdapter_UInt32N()		;
			Array4DPrimitive_Int64		= new Array4DPrimitiveAdapter_Int64()		;
			Array4DPrimitive_Int64N		= new Array4DPrimitiveAdapter_Int64N()		;
			Array4DPrimitive_UInt64		= new Array4DPrimitiveAdapter_UInt64()		;
			Array4DPrimitive_UInt64N	= new Array4DPrimitiveAdapter_UInt64N()		;
			Array4DPrimitive_Single		= new Array4DPrimitiveAdapter_Single()		;
			Array4DPrimitive_SingleN	= new Array4DPrimitiveAdapter_SingleN()		;
			Array4DPrimitive_Double		= new Array4DPrimitiveAdapter_Double()		;
			Array4DPrimitive_DoubleN	= new Array4DPrimitiveAdapter_DoubleN()		;
			Array4DPrimitive_Decimal	= new Array4DPrimitiveAdapter_Decimal()		;
			Array4DPrimitive_DecimalN	= new Array4DPrimitiveAdapter_DecimalN()	;
			Array4DPrimitive_String		= new Array4DPrimitiveAdapter_String()		;
			Array4DPrimitive_DateTime	= new Array4DPrimitiveAdapter_DateTime()	;
			Array4DPrimitive_DateTimeN	= new Array4DPrimitiveAdapter_DateTimeN()	;

			// リスト型のアダプター生成

			ListPrimitive_Boolean		= new ListPrimitiveAdapter_Boolean()		;
			ListPrimitive_BooleanN		= new ListPrimitiveAdapter_BooleanN()		;
			ListPrimitive_Byte			= new ListPrimitiveAdapter_Byte()			;
			ListPrimitive_ByteN			= new ListPrimitiveAdapter_ByteN()			;
			ListPrimitive_SByte			= new ListPrimitiveAdapter_SByte()			;
			ListPrimitive_SByteN		= new ListPrimitiveAdapter_SByteN()			;
			ListPrimitive_Char			= new ListPrimitiveAdapter_Char()			;
			ListPrimitive_CharN			= new ListPrimitiveAdapter_CharN()			;
			ListPrimitive_Int16			= new ListPrimitiveAdapter_Int16()			;
			ListPrimitive_Int16N		= new ListPrimitiveAdapter_Int16N()			;
			ListPrimitive_UInt16		= new ListPrimitiveAdapter_UInt16()			;
			ListPrimitive_UInt16N		= new ListPrimitiveAdapter_UInt16N()		;
			ListPrimitive_Int32			= new ListPrimitiveAdapter_Int32()			;
			ListPrimitive_Int32N		= new ListPrimitiveAdapter_Int32N()			;
			ListPrimitive_UInt32		= new ListPrimitiveAdapter_UInt32()			;
			ListPrimitive_UInt32N		= new ListPrimitiveAdapter_UInt32N()		;
			ListPrimitive_Int64			= new ListPrimitiveAdapter_Int64()			;
			ListPrimitive_Int64N		= new ListPrimitiveAdapter_Int64N()			;
			ListPrimitive_UInt64		= new ListPrimitiveAdapter_UInt64()			;
			ListPrimitive_UInt64N		= new ListPrimitiveAdapter_UInt64N()		;
			ListPrimitive_Single		= new ListPrimitiveAdapter_Single()			;
			ListPrimitive_SingleN		= new ListPrimitiveAdapter_SingleN()		;
			ListPrimitive_Double		= new ListPrimitiveAdapter_Double()			;
			ListPrimitive_DoubleN		= new ListPrimitiveAdapter_DoubleN()		;
			ListPrimitive_Decimal		= new ListPrimitiveAdapter_Decimal()		;
			ListPrimitive_DecimalN		= new ListPrimitiveAdapter_DecimalN()		;
			ListPrimitive_String		= new ListPrimitiveAdapter_String()			;
			ListPrimitive_DateTime		= new ListPrimitiveAdapter_DateTime()		;
			ListPrimitive_DateTimeN		= new ListPrimitiveAdapter_DateTimeN()		;
		}

		/// <summary>
		/// アダプター(内部)に登録する
		/// </summary>
		public void AddTo( Dictionary<Type,IAdapter> dapterCahce )
		{
			// プリミティブ
			dapterCahce.Add( typeof( System.Boolean ),				Primitive_Boolean )		;
			dapterCahce.Add( typeof( System.Boolean? ),				Primitive_BooleanN )	;
			dapterCahce.Add( typeof( System.Byte ),					Primitive_Byte )		;
			dapterCahce.Add( typeof( System.Byte?	),				Primitive_ByteN )		;
			dapterCahce.Add( typeof( System.SByte ),				Primitive_SByte )		;
			dapterCahce.Add( typeof( System.SByte? ),				Primitive_SByteN )		;
			dapterCahce.Add( typeof( System.Char ),					Primitive_Char )		;
			dapterCahce.Add( typeof( System.Char? ),				Primitive_CharN )		;
			dapterCahce.Add( typeof( System.Int16 ),				Primitive_Int16 )		;
			dapterCahce.Add( typeof( System.Int16? ),				Primitive_Int16N )		;
			dapterCahce.Add( typeof( System.UInt16 ),				Primitive_UInt16 )		;
			dapterCahce.Add( typeof( System.UInt16? ),				Primitive_UInt16N )		;
			dapterCahce.Add( typeof( System.Int32 ),				Primitive_Int32 )		;
			dapterCahce.Add( typeof( System.Int32? ),				Primitive_Int32N )		;
			dapterCahce.Add( typeof( System.UInt32 ),				Primitive_UInt32 )		;
			dapterCahce.Add( typeof( System.UInt32? ),				Primitive_UInt32N )		;
			dapterCahce.Add( typeof( System.Int64 ),				Primitive_Int64 )		;
			dapterCahce.Add( typeof( System.Int64? ),				Primitive_Int64N )		;
			dapterCahce.Add( typeof( System.UInt64 ),				Primitive_UInt64 )		;
			dapterCahce.Add( typeof( System.UInt64? ),				Primitive_UInt64N )		;
			dapterCahce.Add( typeof( System.Single ),				Primitive_Single )		;
			dapterCahce.Add( typeof( System.Single? ),				Primitive_SingleN )		;
			dapterCahce.Add( typeof( System.Double ),				Primitive_Double )		;
			dapterCahce.Add( typeof( System.Double? ),				Primitive_DoubleN )		;
			dapterCahce.Add( typeof( System.Decimal ),				Primitive_Decimal )		;
			dapterCahce.Add( typeof( System.Decimal? ),				Primitive_DecimalN )	;
			dapterCahce.Add( typeof( System.String ),				Primitive_String )		;
			dapterCahce.Add( typeof( System.DateTime ),				Primitive_DateTime )	;
			dapterCahce.Add( typeof( System.DateTime? ),			Primitive_DateTimeN )	;


			// アレイ型のアダプター登録

			// １次元
			dapterCahce.Add( typeof( System.Boolean[] ),			Array1DBoolean )		;
			dapterCahce.Add( typeof( System.Boolean?[] ),			Array1DBooleanN )		;
			dapterCahce.Add( typeof( System.Byte[] ),				Array1DByte )			;
			dapterCahce.Add( typeof( System.Byte?[] ),				Array1DByteN )			;
			dapterCahce.Add( typeof( System.SByte[] ),				Array1DSByte )			;
			dapterCahce.Add( typeof( System.SByte?[] ),				Array1DSByteN )			;
			dapterCahce.Add( typeof( System.Char[] ),				Array1DChar )			;
			dapterCahce.Add( typeof( System.Char?[] ),				Array1DCharN )			;
			dapterCahce.Add( typeof( System.Int16[] ),				Array1DInt16 )			;
			dapterCahce.Add( typeof( System.Int16?[] ),				Array1DInt16N )			;
			dapterCahce.Add( typeof( System.UInt16[] ),				Array1DUInt16 )			;
			dapterCahce.Add( typeof( System.UInt16?[] ),			Array1DUInt16N )		;
			dapterCahce.Add( typeof( System.Int32[] ),				Array1DInt32 )			;
			dapterCahce.Add( typeof( System.Int32?[] ),				Array1DInt32N )			;
			dapterCahce.Add( typeof( System.UInt32[] ),				Array1DUInt32 )			;
			dapterCahce.Add( typeof( System.UInt32?[] ),			Array1DUInt32N )		;
			dapterCahce.Add( typeof( System.Int64[] ),				Array1DInt64 )			;
			dapterCahce.Add( typeof( System.Int64?[] ),				Array1DInt64N )			;
			dapterCahce.Add( typeof( System.UInt64[] ),				Array1DUInt64 )			;
			dapterCahce.Add( typeof( System.UInt64?[] ),			Array1DUInt64N )		;
			dapterCahce.Add( typeof( System.Single[] ),				Array1DSingle )			;
			dapterCahce.Add( typeof( System.Single?[] ),			Array1DSingleN )		;
			dapterCahce.Add( typeof( System.Double[] ),				Array1DDouble )			;
			dapterCahce.Add( typeof( System.Double?[] ),			Array1DDoubleN )		;
			dapterCahce.Add( typeof( System.Decimal[] ),			Array1DDecimal )		;
			dapterCahce.Add( typeof( System.Decimal?[] ),			Array1DDecimalN )		;
			dapterCahce.Add( typeof( System.String[] ),				Array1DString )			;
			dapterCahce.Add( typeof( System.DateTime[] ),			Array1DDateTime )		;
			dapterCahce.Add( typeof( System.DateTime?[] ),			Array1DDateTimeN )		;

			// ２次元
			dapterCahce.Add( typeof( System.Boolean[,] ),			Array2DBoolean )		;
			dapterCahce.Add( typeof( System.Boolean?[,] ),			Array2DBooleanN )		;
			dapterCahce.Add( typeof( System.Byte[,] ),				Array2DByte )			;
			dapterCahce.Add( typeof( System.Byte?[,] ),				Array2DByteN )			;
			dapterCahce.Add( typeof( System.SByte[,] ),				Array2DSByte )			;
			dapterCahce.Add( typeof( System.SByte?[,] ),			Array2DSByteN )			;
			dapterCahce.Add( typeof( System.Char[,] ),				Array2DChar )			;
			dapterCahce.Add( typeof( System.Char?[,] ),				Array2DCharN )			;
			dapterCahce.Add( typeof( System.Int16[,] ),				Array2DInt16 )			;
			dapterCahce.Add( typeof( System.Int16?[,] ),			Array2DInt16N )			;
			dapterCahce.Add( typeof( System.UInt16[,] ),			Array2DUInt16 )			;
			dapterCahce.Add( typeof( System.UInt16?[,] ),			Array2DUInt16N )		;
			dapterCahce.Add( typeof( System.Int32[,] ),				Array2DInt32 )			;
			dapterCahce.Add( typeof( System.Int32?[,] ),			Array2DInt32N )			;
			dapterCahce.Add( typeof( System.UInt32[,] ),			Array2DUInt32 )			;
			dapterCahce.Add( typeof( System.UInt32?[,] ),			Array2DUInt32N )		;
			dapterCahce.Add( typeof( System.Int64[,] ),				Array2DInt64 )			;
			dapterCahce.Add( typeof( System.Int64?[,] ),			Array2DInt64N )			;
			dapterCahce.Add( typeof( System.UInt64[,] ),			Array2DUInt64 )			;
			dapterCahce.Add( typeof( System.UInt64?[,] ),			Array2DUInt64N )		;
			dapterCahce.Add( typeof( System.Single[,] ),			Array2DSingle )			;
			dapterCahce.Add( typeof( System.Single?[,] ),			Array2DSingleN )		;
			dapterCahce.Add( typeof( System.Double[,] ),			Array2DDouble )			;
			dapterCahce.Add( typeof( System.Double?[,] ),			Array2DDoubleN )		;
			dapterCahce.Add( typeof( System.Decimal[,] ),			Array2DDecimal )		;
			dapterCahce.Add( typeof( System.Decimal?[,] ),			Array2DDecimalN )		;
			dapterCahce.Add( typeof( System.String[,] ),			Array2DString )			;
			dapterCahce.Add( typeof( System.DateTime[,] ),			Array2DDateTime )		;
			dapterCahce.Add( typeof( System.DateTime?[,] ),			Array2DDateTimeN )		;

			// ３次元
			dapterCahce.Add( typeof( System.Boolean[,,] ),			Array3DPrimitive_Boolean )		;
			dapterCahce.Add( typeof( System.Boolean?[,,] ),			Array3DPrimitive_BooleanN )		;
			dapterCahce.Add( typeof( System.Byte[,,] ),				Array3DPrimitive_Byte )			;
			dapterCahce.Add( typeof( System.Byte?[,,] ),			Array3DPrimitive_ByteN )		;
			dapterCahce.Add( typeof( System.SByte[,,] ),			Array3DPrimitive_SByte )		;
			dapterCahce.Add( typeof( System.SByte?[,,] ),			Array3DPrimitive_SByteN )		;
			dapterCahce.Add( typeof( System.Char[,,] ),				Array3DPrimitive_Char )			;
			dapterCahce.Add( typeof( System.Char?[,,] ),			Array3DPrimitive_CharN )		;
			dapterCahce.Add( typeof( System.Int16[,,] ),			Array3DPrimitive_Int16 )		;
			dapterCahce.Add( typeof( System.Int16?[,,] ),			Array3DPrimitive_Int16N )		;
			dapterCahce.Add( typeof( System.UInt16[,,] ),			Array3DPrimitive_UInt16 )		;
			dapterCahce.Add( typeof( System.UInt16?[,,] ),			Array3DPrimitive_UInt16N )		;
			dapterCahce.Add( typeof( System.Int32[,,] ),			Array3DPrimitive_Int32 )		;
			dapterCahce.Add( typeof( System.Int32?[,,] ),			Array3DPrimitive_Int32N )		;
			dapterCahce.Add( typeof( System.UInt32[,,] ),			Array3DPrimitive_UInt32 )		;
			dapterCahce.Add( typeof( System.UInt32?[,,] ),			Array3DPrimitive_UInt32N )		;
			dapterCahce.Add( typeof( System.Int64[,,] ),			Array3DPrimitive_Int64 )		;
			dapterCahce.Add( typeof( System.Int64?[,,] ),			Array3DPrimitive_Int64N )		;
			dapterCahce.Add( typeof( System.UInt64[,,] ),			Array3DPrimitive_UInt64 )		;
			dapterCahce.Add( typeof( System.UInt64?[,,] ),			Array3DPrimitive_UInt64N )		;
			dapterCahce.Add( typeof( System.Single[,,] ),			Array3DPrimitive_Single )		;
			dapterCahce.Add( typeof( System.Single?[,,] ),			Array3DPrimitive_SingleN )		;
			dapterCahce.Add( typeof( System.Double[,,] ),			Array3DPrimitive_Double )		;
			dapterCahce.Add( typeof( System.Double?[,,] ),			Array3DPrimitive_DoubleN )		;
			dapterCahce.Add( typeof( System.Decimal[,,] ),			Array3DPrimitive_Decimal )		;
			dapterCahce.Add( typeof( System.Decimal?[,,] ),			Array3DPrimitive_DecimalN )		;
			dapterCahce.Add( typeof( System.String[,,] ),			Array3DPrimitive_String )		;
			dapterCahce.Add( typeof( System.DateTime[,,] ),			Array3DPrimitive_DateTime )		;
			dapterCahce.Add( typeof( System.DateTime?[,,] ),		Array3DPrimitive_DateTimeN )	;

			// ４次元
			dapterCahce.Add( typeof( System.Boolean[,,,] ),			Array4DPrimitive_Boolean )		;
			dapterCahce.Add( typeof( System.Boolean?[,,,] ),		Array4DPrimitive_BooleanN )		;
			dapterCahce.Add( typeof( System.Byte[,,,] ),			Array4DPrimitive_Byte )			;
			dapterCahce.Add( typeof( System.Byte?[,,,] ),			Array4DPrimitive_ByteN )		;
			dapterCahce.Add( typeof( System.SByte[,,,] ),			Array4DPrimitive_SByte )		;
			dapterCahce.Add( typeof( System.SByte?[,,,] ),			Array4DPrimitive_SByteN )		;
			dapterCahce.Add( typeof( System.Char[,,,] ),			Array4DPrimitive_Char )			;
			dapterCahce.Add( typeof( System.Char?[,,,] ),			Array4DPrimitive_CharN )		;
			dapterCahce.Add( typeof( System.Int16[,,,] ),			Array4DPrimitive_Int16 )		;
			dapterCahce.Add( typeof( System.Int16?[,,,] ),			Array4DPrimitive_Int16N )		;
			dapterCahce.Add( typeof( System.UInt16[,,,] ),			Array4DPrimitive_UInt16 )		;
			dapterCahce.Add( typeof( System.UInt16?[,,,] ),			Array4DPrimitive_UInt16N )		;
			dapterCahce.Add( typeof( System.Int32[,,,] ),			Array4DPrimitive_Int32 )		;
			dapterCahce.Add( typeof( System.Int32?[,,,] ),			Array4DPrimitive_Int32N )		;
			dapterCahce.Add( typeof( System.UInt32[,,,] ),			Array4DPrimitive_UInt32 )		;
			dapterCahce.Add( typeof( System.UInt32?[,,,] ),			Array4DPrimitive_UInt32N )		;
			dapterCahce.Add( typeof( System.Int64[,,,] ),			Array4DPrimitive_Int64 )		;
			dapterCahce.Add( typeof( System.Int64?[,,,] ),			Array4DPrimitive_Int64N )		;
			dapterCahce.Add( typeof( System.UInt64[,,,] ),			Array4DPrimitive_UInt64 )		;
			dapterCahce.Add( typeof( System.UInt64?[,,,] ),			Array4DPrimitive_UInt64N )		;
			dapterCahce.Add( typeof( System.Single[,,,] ),			Array4DPrimitive_Single )		;
			dapterCahce.Add( typeof( System.Single?[,,,] ),			Array4DPrimitive_SingleN )		;
			dapterCahce.Add( typeof( System.Double[,,,] ),			Array4DPrimitive_Double )		;
			dapterCahce.Add( typeof( System.Double?[,,,] ),			Array4DPrimitive_DoubleN )		;
			dapterCahce.Add( typeof( System.Decimal[,,,] ),			Array4DPrimitive_Decimal )		;
			dapterCahce.Add( typeof( System.Decimal?[,,,] ),		Array4DPrimitive_DecimalN )		;
			dapterCahce.Add( typeof( System.String[,,,] ),			Array4DPrimitive_String )		;
			dapterCahce.Add( typeof( System.DateTime[,,,] ),		Array4DPrimitive_DateTime )		;
			dapterCahce.Add( typeof( System.DateTime?[,,,] ),		Array4DPrimitive_DateTimeN )	;


			// リスト型のアダプター生成

			dapterCahce.Add( typeof( List<System.Boolean> ),		ListPrimitive_Boolean )			;
			dapterCahce.Add( typeof( List<System.Boolean?> ),		ListPrimitive_BooleanN )		;
			dapterCahce.Add( typeof( List<System.Byte> ),			ListPrimitive_Byte )			;
			dapterCahce.Add( typeof( List<System.Byte?> ),			ListPrimitive_ByteN )			;
			dapterCahce.Add( typeof( List<System.SByte> ),			ListPrimitive_SByte )			;
			dapterCahce.Add( typeof( List<System.SByte?> ),			ListPrimitive_SByteN )			;
			dapterCahce.Add( typeof( List<System.Char> ),			ListPrimitive_Char )			;
			dapterCahce.Add( typeof( List<System.Char?> ),			ListPrimitive_CharN )			;
			dapterCahce.Add( typeof( List<System.Int16> ),			ListPrimitive_Int16 )			;
			dapterCahce.Add( typeof( List<System.Int16?> ),			ListPrimitive_Int16N )			;
			dapterCahce.Add( typeof( List<System.UInt16> ),			ListPrimitive_UInt16 )			;
			dapterCahce.Add( typeof( List<System.UInt16?> ),		ListPrimitive_UInt16N )			;
			dapterCahce.Add( typeof( List<System.Int32> ),			ListPrimitive_Int32 )			;
			dapterCahce.Add( typeof( List<System.Int32?> ),			ListPrimitive_Int32N )			;
			dapterCahce.Add( typeof( List<System.UInt32> ),			ListPrimitive_UInt32 )			;
			dapterCahce.Add( typeof( List<System.UInt32?> ),		ListPrimitive_UInt32N )			;
			dapterCahce.Add( typeof( List<System.Int64> ),			ListPrimitive_Int64 )			;
			dapterCahce.Add( typeof( List<System.Int64?> ),			ListPrimitive_Int64N )			;
			dapterCahce.Add( typeof( List<System.UInt64> ),			ListPrimitive_UInt64 )			;
			dapterCahce.Add( typeof( List<System.UInt64?> ),		ListPrimitive_UInt64N )			;
			dapterCahce.Add( typeof( List<System.Single> ),			ListPrimitive_Single )			;
			dapterCahce.Add( typeof( List<System.Single?> ),		ListPrimitive_SingleN )			;
			dapterCahce.Add( typeof( List<System.Double> ),			ListPrimitive_Double )			;
			dapterCahce.Add( typeof( List<System.Double?> ),		ListPrimitive_DoubleN )			;
			dapterCahce.Add( typeof( List<System.Decimal> ),		ListPrimitive_Decimal )			;
			dapterCahce.Add( typeof( List<System.Decimal?> ),		ListPrimitive_DecimalN )		;
			dapterCahce.Add( typeof( List<System.String> ),			ListPrimitive_String )			;
			dapterCahce.Add( typeof( List<System.DateTime> ),		ListPrimitive_DateTime )		;
			dapterCahce.Add( typeof( List<System.DateTime?> ),		ListPrimitive_DateTimeN )		;
		}

		//-------------------------------------------------------------------------------------------
		// インスタンス定義

		// プリミティブ
		public static PrimitiveAdapter_Boolean				Primitive_Boolean{ get ; private set ; }
		public static PrimitiveAdapter_BooleanN				Primitive_BooleanN{ get ; private set ; }
		public static PrimitiveAdapter_Byte					Primitive_Byte{ get ; private set ; }
		public static PrimitiveAdapter_ByteN				Primitive_ByteN{ get ; private set ; }
		public static PrimitiveAdapter_SByte				Primitive_SByte{ get ; private set ; }
		public static PrimitiveAdapter_SByteN				Primitive_SByteN{ get ; private set ; }
		public static PrimitiveAdapter_Char					Primitive_Char{ get ; private set ; }
		public static PrimitiveAdapter_CharN				Primitive_CharN{ get ; private set ; }
		public static PrimitiveAdapter_Int16				Primitive_Int16{ get ; private set ; }
		public static PrimitiveAdapter_Int16N				Primitive_Int16N{ get ; private set ; }
		public static PrimitiveAdapter_UInt16				Primitive_UInt16{ get ; private set ; }
		public static PrimitiveAdapter_UInt16N				Primitive_UInt16N{ get ; private set ; }
		public static PrimitiveAdapter_Int32				Primitive_Int32{ get ; private set ; }
		public static PrimitiveAdapter_Int32N				Primitive_Int32N{ get ; private set ; }
		public static PrimitiveAdapter_UInt32				Primitive_UInt32{ get ; private set ; }
		public static PrimitiveAdapter_UInt32N				Primitive_UInt32N{ get ; private set ; }
		public static PrimitiveAdapter_Int64				Primitive_Int64{ get ; private set ; }
		public static PrimitiveAdapter_Int64N				Primitive_Int64N{ get ; private set ; }
		public static PrimitiveAdapter_UInt64				Primitive_UInt64{ get ; private set ; }
		public static PrimitiveAdapter_UInt64N				Primitive_UInt64N{ get ; private set ; }
		public static PrimitiveAdapter_Single				Primitive_Single{ get ; private set ; }
		public static PrimitiveAdapter_SingleN				Primitive_SingleN{ get ; private set ; }
		public static PrimitiveAdapter_Double				Primitive_Double{ get ; private set ; }
		public static PrimitiveAdapter_DoubleN				Primitive_DoubleN{ get ; private set ; }
		public static PrimitiveAdapter_Decimal				Primitive_Decimal{ get ; private set ; }
		public static PrimitiveAdapter_DecimalN				Primitive_DecimalN{ get ; private set ; }
		public static PrimitiveAdapter_String				Primitive_String{ get ; private set ; }
		public static PrimitiveAdapter_DateTime				Primitive_DateTime{ get ; private set ; }
		public static PrimitiveAdapter_DateTimeN			Primitive_DateTimeN{ get ; private set ; }

		// アレイ

		// １次元
		public static Array1DBooleanAdapter					Array1DBoolean{ get ; private set ; }
		public static Array1DBooleanNAdapter				Array1DBooleanN{ get ; private set ; }
		public static Array1DByteAdapter					Array1DByte{ get ; private set ; }
		public static Array1DByteNAdapter					Array1DByteN{ get ; private set ; }
		public static Array1DSByteAdapter					Array1DSByte{ get ; private set ; }
		public static Array1DSByteNAdapter					Array1DSByteN{ get ; private set ; }
		public static Array1DCharAdapter					Array1DChar{ get ; private set ; }
		public static Array1DCharNAdapter					Array1DCharN{ get ; private set ; }
		public static Array1DInt16Adapter					Array1DInt16{ get ; private set ; }
		public static Array1DInt16NAdapter					Array1DInt16N{ get ; private set ; }
		public static Array1DUInt16Adapter					Array1DUInt16{ get ; private set ; }
		public static Array1DUInt16NAdapter					Array1DUInt16N{ get ; private set ; }
		public static Array1DInt32Adapter					Array1DInt32{ get ; private set ; }
		public static Array1DInt32NAdapter					Array1DInt32N{ get ; private set ; }
		public static Array1DUInt32Adapter					Array1DUInt32{ get ; private set ; }
		public static Array1DUInt32NAdapter					Array1DUInt32N{ get ; private set ; }
		public static Array1DInt64Adapter					Array1DInt64{ get ; private set ; }
		public static Array1DInt64NAdapter					Array1DInt64N{ get ; private set ; }
		public static Array1DUInt64Adapter					Array1DUInt64{ get ; private set ; }
		public static Array1DUInt64NAdapter					Array1DUInt64N{ get ; private set ; }
		public static Array1DSingleAdapter					Array1DSingle{ get ; private set ; }
		public static Array1DSingleNAdapter					Array1DSingleN{ get ; private set ; }
		public static Array1DDoubleAdapter					Array1DDouble{ get ; private set ; }
		public static Array1DDoubleNAdapter					Array1DDoubleN{ get ; private set ; }
		public static Array1DDecimalAdapter					Array1DDecimal{ get ; private set ; }
		public static Array1DDecimalNAdapter				Array1DDecimalN{ get ; private set ; }
		public static Array1DStringAdapter					Array1DString{ get ; private set ; }
		public static Array1DDateTimeAdapter				Array1DDateTime{ get ; private set ; }
		public static Array1DDateTimeNAdapter				Array1DDateTimeN{ get ; private set ; }

		// ２次元
		public static Array2DBooleanAdapter					Array2DBoolean{ get ; private set ; }
		public static Array2DBooleanNAdapter				Array2DBooleanN{ get ; private set ; }
		public static Array2DByteAdapter					Array2DByte{ get ; private set ; }
		public static Array2DByteNAdapter					Array2DByteN{ get ; private set ; }
		public static Array2DSByteAdapter					Array2DSByte{ get ; private set ; }
		public static Array2DSByteNAdapter					Array2DSByteN{ get ; private set ; }
		public static Array2DCharAdapter					Array2DChar{ get ; private set ; }
		public static Array2DCharNAdapter					Array2DCharN{ get ; private set ; }
		public static Array2DInt16Adapter					Array2DInt16{ get ; private set ; }
		public static Array2DInt16NAdapter					Array2DInt16N{ get ; private set ; }
		public static Array2DUInt16Adapter					Array2DUInt16{ get ; private set ; }
		public static Array2DUInt16NAdapter					Array2DUInt16N{ get ; private set ; }
		public static Array2DInt32Adapter					Array2DInt32{ get ; private set ; }
		public static Array2DInt32NAdapter					Array2DInt32N{ get ; private set ; }
		public static Array2DUInt32Adapter					Array2DUInt32{ get ; private set ; }
		public static Array2DUInt32NAdapter					Array2DUInt32N{ get ; private set ; }
		public static Array2DInt64Adapter					Array2DInt64{ get ; private set ; }
		public static Array2DInt64NAdapter					Array2DInt64N{ get ; private set ; }
		public static Array2DUInt64Adapter					Array2DUInt64{ get ; private set ; }
		public static Array2DUInt64NAdapter					Array2DUInt64N{ get ; private set ; }
		public static Array2DSingleAdapter					Array2DSingle{ get ; private set ; }
		public static Array2DSingleNAdapter					Array2DSingleN{ get ; private set ; }
		public static Array2DDoubleAdapter					Array2DDouble{ get ; private set ; }
		public static Array2DDoubleNAdapter					Array2DDoubleN{ get ; private set ; }
		public static Array2DDecimalAdapter					Array2DDecimal{ get ; private set ; }
		public static Array2DDecimalNAdapter				Array2DDecimalN{ get ; private set ; }
		public static Array2DStringAdapter					Array2DString{ get ; private set ; }
		public static Array2DDateTimeAdapter				Array2DDateTime{ get ; private set ; }
		public static Array2DDateTimeNAdapter				Array2DDateTimeN{ get ; private set ; }

		// ３次元
		public static Array3DPrimitiveAdapter_Boolean		Array3DPrimitive_Boolean{ get ; private set ; }
		public static Array3DPrimitiveAdapter_BooleanN		Array3DPrimitive_BooleanN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Byte			Array3DPrimitive_Byte{ get ; private set ; }
		public static Array3DPrimitiveAdapter_ByteN			Array3DPrimitive_ByteN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_SByte			Array3DPrimitive_SByte{ get ; private set ; }
		public static Array3DPrimitiveAdapter_SByteN		Array3DPrimitive_SByteN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Char			Array3DPrimitive_Char{ get ; private set ; }
		public static Array3DPrimitiveAdapter_CharN			Array3DPrimitive_CharN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Int16			Array3DPrimitive_Int16{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Int16N		Array3DPrimitive_Int16N{ get ; private set ; }
		public static Array3DPrimitiveAdapter_UInt16		Array3DPrimitive_UInt16{ get ; private set ; }
		public static Array3DPrimitiveAdapter_UInt16N		Array3DPrimitive_UInt16N{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Int32			Array3DPrimitive_Int32{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Int32N		Array3DPrimitive_Int32N{ get ; private set ; }
		public static Array3DPrimitiveAdapter_UInt32		Array3DPrimitive_UInt32{ get ; private set ; }
		public static Array3DPrimitiveAdapter_UInt32N		Array3DPrimitive_UInt32N{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Int64			Array3DPrimitive_Int64{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Int64N		Array3DPrimitive_Int64N{ get ; private set ; }
		public static Array3DPrimitiveAdapter_UInt64		Array3DPrimitive_UInt64{ get ; private set ; }
		public static Array3DPrimitiveAdapter_UInt64N		Array3DPrimitive_UInt64N{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Single		Array3DPrimitive_Single{ get ; private set ; }
		public static Array3DPrimitiveAdapter_SingleN		Array3DPrimitive_SingleN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Double		Array3DPrimitive_Double{ get ; private set ; }
		public static Array3DPrimitiveAdapter_DoubleN		Array3DPrimitive_DoubleN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_Decimal		Array3DPrimitive_Decimal{ get ; private set ; }
		public static Array3DPrimitiveAdapter_DecimalN		Array3DPrimitive_DecimalN{ get ; private set ; }
		public static Array3DPrimitiveAdapter_String		Array3DPrimitive_String{ get ; private set ; }
		public static Array3DPrimitiveAdapter_DateTime		Array3DPrimitive_DateTime{ get ; private set ; }
		public static Array3DPrimitiveAdapter_DateTimeN		Array3DPrimitive_DateTimeN{ get ; private set ; }

		// ４次元
		public static Array4DPrimitiveAdapter_Boolean		Array4DPrimitive_Boolean{ get ; private set ; }
		public static Array4DPrimitiveAdapter_BooleanN		Array4DPrimitive_BooleanN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Byte			Array4DPrimitive_Byte{ get ; private set ; }
		public static Array4DPrimitiveAdapter_ByteN			Array4DPrimitive_ByteN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_SByte			Array4DPrimitive_SByte{ get ; private set ; }
		public static Array4DPrimitiveAdapter_SByteN		Array4DPrimitive_SByteN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Char			Array4DPrimitive_Char{ get ; private set ; }
		public static Array4DPrimitiveAdapter_CharN			Array4DPrimitive_CharN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Int16			Array4DPrimitive_Int16{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Int16N		Array4DPrimitive_Int16N{ get ; private set ; }
		public static Array4DPrimitiveAdapter_UInt16		Array4DPrimitive_UInt16{ get ; private set ; }
		public static Array4DPrimitiveAdapter_UInt16N		Array4DPrimitive_UInt16N{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Int32			Array4DPrimitive_Int32{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Int32N		Array4DPrimitive_Int32N{ get ; private set ; }
		public static Array4DPrimitiveAdapter_UInt32		Array4DPrimitive_UInt32{ get ; private set ; }
		public static Array4DPrimitiveAdapter_UInt32N		Array4DPrimitive_UInt32N{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Int64			Array4DPrimitive_Int64{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Int64N		Array4DPrimitive_Int64N{ get ; private set ; }
		public static Array4DPrimitiveAdapter_UInt64		Array4DPrimitive_UInt64{ get ; private set ; }
		public static Array4DPrimitiveAdapter_UInt64N		Array4DPrimitive_UInt64N{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Single		Array4DPrimitive_Single{ get ; private set ; }
		public static Array4DPrimitiveAdapter_SingleN		Array4DPrimitive_SingleN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Double		Array4DPrimitive_Double{ get ; private set ; }
		public static Array4DPrimitiveAdapter_DoubleN		Array4DPrimitive_DoubleN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_Decimal		Array4DPrimitive_Decimal{ get ; private set ; }
		public static Array4DPrimitiveAdapter_DecimalN		Array4DPrimitive_DecimalN{ get ; private set ; }
		public static Array4DPrimitiveAdapter_String		Array4DPrimitive_String{ get ; private set ; }
		public static Array4DPrimitiveAdapter_DateTime		Array4DPrimitive_DateTime{ get ; private set ; }
		public static Array4DPrimitiveAdapter_DateTimeN		Array4DPrimitive_DateTimeN{ get ; private set ; }

		// リスト

		public static ListPrimitiveAdapter_Boolean			ListPrimitive_Boolean{ get ; private set ; }
		public static ListPrimitiveAdapter_BooleanN			ListPrimitive_BooleanN{ get ; private set ; }
		public static ListPrimitiveAdapter_Byte				ListPrimitive_Byte{ get ; private set ; }
		public static ListPrimitiveAdapter_ByteN			ListPrimitive_ByteN{ get ; private set ; }
		public static ListPrimitiveAdapter_SByte			ListPrimitive_SByte{ get ; private set ; }
		public static ListPrimitiveAdapter_SByteN			ListPrimitive_SByteN{ get ; private set ; }
		public static ListPrimitiveAdapter_Char				ListPrimitive_Char{ get ; private set ; }
		public static ListPrimitiveAdapter_CharN			ListPrimitive_CharN{ get ; private set ; }
		public static ListPrimitiveAdapter_Int16			ListPrimitive_Int16{ get ; private set ; }
		public static ListPrimitiveAdapter_Int16N			ListPrimitive_Int16N{ get ; private set ; }
		public static ListPrimitiveAdapter_UInt16			ListPrimitive_UInt16{ get ; private set ; }
		public static ListPrimitiveAdapter_UInt16N			ListPrimitive_UInt16N{ get ; private set ; }
		public static ListPrimitiveAdapter_Int32			ListPrimitive_Int32{ get ; private set ; }
		public static ListPrimitiveAdapter_Int32N			ListPrimitive_Int32N{ get ; private set ; }
		public static ListPrimitiveAdapter_UInt32			ListPrimitive_UInt32{ get ; private set ; }
		public static ListPrimitiveAdapter_UInt32N			ListPrimitive_UInt32N{ get ; private set ; }
		public static ListPrimitiveAdapter_Int64			ListPrimitive_Int64{ get ; private set ; }
		public static ListPrimitiveAdapter_Int64N			ListPrimitive_Int64N{ get ; private set ; }
		public static ListPrimitiveAdapter_UInt64			ListPrimitive_UInt64{ get ; private set ; }
		public static ListPrimitiveAdapter_UInt64N			ListPrimitive_UInt64N{ get ; private set ; }
		public static ListPrimitiveAdapter_Single			ListPrimitive_Single{ get ; private set ; }
		public static ListPrimitiveAdapter_SingleN			ListPrimitive_SingleN{ get ; private set ; }
		public static ListPrimitiveAdapter_Double			ListPrimitive_Double{ get ; private set ; }
		public static ListPrimitiveAdapter_DoubleN			ListPrimitive_DoubleN{ get ; private set ; }
		public static ListPrimitiveAdapter_Decimal			ListPrimitive_Decimal{ get ; private set ; }
		public static ListPrimitiveAdapter_DecimalN			ListPrimitive_DecimalN{ get ; private set ; }
		public static ListPrimitiveAdapter_String			ListPrimitive_String{ get ; private set ; }
		public static ListPrimitiveAdapter_DateTime			ListPrimitive_DateTime{ get ; private set ; }
		public static ListPrimitiveAdapter_DateTimeN		ListPrimitive_DateTimeN{ get ; private set ; }
	}

	//--------------------------------------------------------------------------------------------
}
