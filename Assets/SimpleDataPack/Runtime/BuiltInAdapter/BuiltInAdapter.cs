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
			Array3DBoolean				= new Array3DBooleanAdapter()		;
			Array3DBooleanN				= new Array3DBooleanNAdapter()		;
			Array3DByte					= new Array3DByteAdapter()			;
			Array3DByteN				= new Array3DByteNAdapter()			;
			Array3DSByte				= new Array3DSByteAdapter()			;
			Array3DSByteN				= new Array3DSByteNAdapter()		;
			Array3DChar					= new Array3DCharAdapter()			;
			Array3DCharN				= new Array3DCharNAdapter()			;
			Array3DInt16				= new Array3DInt16Adapter()			;
			Array3DInt16N				= new Array3DInt16NAdapter()		;
			Array3DUInt16				= new Array3DUInt16Adapter()		;
			Array3DUInt16N				= new Array3DUInt16NAdapter()		;
			Array3DInt32				= new Array3DInt32Adapter()			;
			Array3DInt32N				= new Array3DInt32NAdapter()		;
			Array3DUInt32				= new Array3DUInt32Adapter()		;
			Array3DUInt32N				= new Array3DUInt32NAdapter()		;
			Array3DInt64				= new Array3DInt64Adapter()			;
			Array3DInt64N				= new Array3DInt64NAdapter()		;
			Array3DUInt64				= new Array3DUInt64Adapter()		;
			Array3DUInt64N				= new Array3DUInt64NAdapter()		;
			Array3DSingle				= new Array3DSingleAdapter()		;
			Array3DSingleN				= new Array3DSingleNAdapter()		;
			Array3DDouble				= new Array3DDoubleAdapter()		;
			Array3DDoubleN				= new Array3DDoubleNAdapter()		;
			Array3DDecimal				= new Array3DDecimalAdapter()		;
			Array3DDecimalN				= new Array3DDecimalNAdapter()		;
			Array3DString				= new Array3DStringAdapter()		;
			Array3DDateTime				= new Array3DDateTimeAdapter()		;
			Array3DDateTimeN			= new Array3DDateTimeNAdapter()		;
			
			// ４次元
			Array4DBoolean				= new Array4DBooleanAdapter()		;
			Array4DBooleanN				= new Array4DBooleanNAdapter()		;
			Array4DByte					= new Array4DByteAdapter()			;
			Array4DByteN				= new Array4DByteNAdapter()			;
			Array4DSByte				= new Array4DSByteAdapter()			;
			Array4DSByteN				= new Array4DSByteNAdapter()		;
			Array4DChar					= new Array4DCharAdapter()			;
			Array4DCharN				= new Array4DCharNAdapter()			;
			Array4DInt16				= new Array4DInt16Adapter()			;
			Array4DInt16N				= new Array4DInt16NAdapter()		;
			Array4DUInt16				= new Array4DUInt16Adapter()		;
			Array4DUInt16N				= new Array4DUInt16NAdapter()		;
			Array4DInt32				= new Array4DInt32Adapter()			;
			Array4DInt32N				= new Array4DInt32NAdapter()		;
			Array4DUInt32				= new Array4DUInt32Adapter()		;
			Array4DUInt32N				= new Array4DUInt32NAdapter()		;
			Array4DInt64				= new Array4DInt64Adapter()			;
			Array4DInt64N				= new Array4DInt64NAdapter()		;
			Array4DUInt64				= new Array4DUInt64Adapter()		;
			Array4DUInt64N				= new Array4DUInt64NAdapter()		;
			Array4DSingle				= new Array4DSingleAdapter()		;
			Array4DSingleN				= new Array4DSingleNAdapter()		;
			Array4DDouble				= new Array4DDoubleAdapter()		;
			Array4DDoubleN				= new Array4DDoubleNAdapter()		;
			Array4DDecimal				= new Array4DDecimalAdapter()		;
			Array4DDecimalN				= new Array4DDecimalNAdapter()		;
			Array4DString				= new Array4DStringAdapter()		;
			Array4DDateTime				= new Array4DDateTimeAdapter()		;
			Array4DDateTimeN			= new Array4DDateTimeNAdapter()		;

			// リスト型のアダプター生成

			ListBoolean			= new ListBooleanAdapter()		;
			ListBooleanN		= new ListBooleanNAdapter()		;
			ListByte			= new ListByteAdapter()			;
			ListByteN			= new ListByteNAdapter()		;
			ListSByte			= new ListSByteAdapter()		;
			ListSByteN			= new ListSByteNAdapter()		;
			ListChar			= new ListCharAdapter()			;
			ListCharN			= new ListCharNAdapter()		;
			ListInt16			= new ListInt16Adapter()		;
			ListInt16N			= new ListInt16NAdapter()		;
			ListUInt16			= new ListUInt16Adapter()		;
			ListUInt16N			= new ListUInt16NAdapter()		;
			ListInt32			= new ListInt32Adapter()		;
			ListInt32N			= new ListInt32NAdapter()		;
			ListUInt32			= new ListUInt32Adapter()		;
			ListUInt32N			= new ListUInt32NAdapter()		;
			ListInt64			= new ListInt64Adapter()		;
			ListInt64N			= new ListInt64NAdapter()		;
			ListUInt64			= new ListUInt64Adapter()		;
			ListUInt64N			= new ListUInt64NAdapter()		;
			ListSingle			= new ListSingleAdapter()		;
			ListSingleN			= new ListSingleNAdapter()		;
			ListDouble			= new ListDoubleAdapter()		;
			ListDoubleN			= new ListDoubleNAdapter()		;
			ListDecimal			= new ListDecimalAdapter()		;
			ListDecimalN		= new ListDecimalNAdapter()		;
			ListString			= new ListStringAdapter()		;
			ListDateTime		= new ListDateTimeAdapter()		;
			ListDateTimeN		= new ListDateTimeNAdapter()	;
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
			dapterCahce.Add( typeof( System.Boolean[,,] ),			Array3DBoolean )		;
			dapterCahce.Add( typeof( System.Boolean?[,,] ),			Array3DBooleanN )		;
			dapterCahce.Add( typeof( System.Byte[,,] ),				Array3DByte )			;
			dapterCahce.Add( typeof( System.Byte?[,,] ),			Array3DByteN )			;
			dapterCahce.Add( typeof( System.SByte[,,] ),			Array3DSByte )			;
			dapterCahce.Add( typeof( System.SByte?[,,] ),			Array3DSByteN )			;
			dapterCahce.Add( typeof( System.Char[,,] ),				Array3DChar )			;
			dapterCahce.Add( typeof( System.Char?[,,] ),			Array3DCharN )			;
			dapterCahce.Add( typeof( System.Int16[,,] ),			Array3DInt16 )			;
			dapterCahce.Add( typeof( System.Int16?[,,] ),			Array3DInt16N )			;
			dapterCahce.Add( typeof( System.UInt16[,,] ),			Array3DUInt16 )			;
			dapterCahce.Add( typeof( System.UInt16?[,,] ),			Array3DUInt16N )		;
			dapterCahce.Add( typeof( System.Int32[,,] ),			Array3DInt32 )			;
			dapterCahce.Add( typeof( System.Int32?[,,] ),			Array3DInt32N )			;
			dapterCahce.Add( typeof( System.UInt32[,,] ),			Array3DUInt32 )			;
			dapterCahce.Add( typeof( System.UInt32?[,,] ),			Array3DUInt32N )		;
			dapterCahce.Add( typeof( System.Int64[,,] ),			Array3DInt64 )			;
			dapterCahce.Add( typeof( System.Int64?[,,] ),			Array3DInt64N )			;
			dapterCahce.Add( typeof( System.UInt64[,,] ),			Array3DUInt64 )			;
			dapterCahce.Add( typeof( System.UInt64?[,,] ),			Array3DUInt64N )		;
			dapterCahce.Add( typeof( System.Single[,,] ),			Array3DSingle )			;
			dapterCahce.Add( typeof( System.Single?[,,] ),			Array3DSingleN )		;
			dapterCahce.Add( typeof( System.Double[,,] ),			Array3DDouble )			;
			dapterCahce.Add( typeof( System.Double?[,,] ),			Array3DDoubleN )		;
			dapterCahce.Add( typeof( System.Decimal[,,] ),			Array3DDecimal )		;
			dapterCahce.Add( typeof( System.Decimal?[,,] ),			Array3DDecimalN )		;
			dapterCahce.Add( typeof( System.String[,,] ),			Array3DString )			;
			dapterCahce.Add( typeof( System.DateTime[,,] ),			Array3DDateTime )		;
			dapterCahce.Add( typeof( System.DateTime?[,,] ),		Array3DDateTimeN )		;

			// ４次元
			dapterCahce.Add( typeof( System.Boolean[,,,] ),			Array4DBoolean )		;
			dapterCahce.Add( typeof( System.Boolean?[,,,] ),		Array4DBooleanN )		;
			dapterCahce.Add( typeof( System.Byte[,,,] ),			Array4DByte )			;
			dapterCahce.Add( typeof( System.Byte?[,,,] ),			Array4DByteN )			;
			dapterCahce.Add( typeof( System.SByte[,,,] ),			Array4DSByte )			;
			dapterCahce.Add( typeof( System.SByte?[,,,] ),			Array4DSByteN )			;
			dapterCahce.Add( typeof( System.Char[,,,] ),			Array4DChar )			;
			dapterCahce.Add( typeof( System.Char?[,,,] ),			Array4DCharN )			;
			dapterCahce.Add( typeof( System.Int16[,,,] ),			Array4DInt16 )			;
			dapterCahce.Add( typeof( System.Int16?[,,,] ),			Array4DInt16N )			;
			dapterCahce.Add( typeof( System.UInt16[,,,] ),			Array4DUInt16 )			;
			dapterCahce.Add( typeof( System.UInt16?[,,,] ),			Array4DUInt16N )		;
			dapterCahce.Add( typeof( System.Int32[,,,] ),			Array4DInt32 )			;
			dapterCahce.Add( typeof( System.Int32?[,,,] ),			Array4DInt32N )			;
			dapterCahce.Add( typeof( System.UInt32[,,,] ),			Array4DUInt32 )			;
			dapterCahce.Add( typeof( System.UInt32?[,,,] ),			Array4DUInt32N )		;
			dapterCahce.Add( typeof( System.Int64[,,,] ),			Array4DInt64 )			;
			dapterCahce.Add( typeof( System.Int64?[,,,] ),			Array4DInt64N )			;
			dapterCahce.Add( typeof( System.UInt64[,,,] ),			Array4DUInt64 )			;
			dapterCahce.Add( typeof( System.UInt64?[,,,] ),			Array4DUInt64N )		;
			dapterCahce.Add( typeof( System.Single[,,,] ),			Array4DSingle )			;
			dapterCahce.Add( typeof( System.Single?[,,,] ),			Array4DSingleN )		;
			dapterCahce.Add( typeof( System.Double[,,,] ),			Array4DDouble )			;
			dapterCahce.Add( typeof( System.Double?[,,,] ),			Array4DDoubleN )		;
			dapterCahce.Add( typeof( System.Decimal[,,,] ),			Array4DDecimal )		;
			dapterCahce.Add( typeof( System.Decimal?[,,,] ),		Array4DDecimalN )		;
			dapterCahce.Add( typeof( System.String[,,,] ),			Array4DString )			;
			dapterCahce.Add( typeof( System.DateTime[,,,] ),		Array4DDateTime )		;
			dapterCahce.Add( typeof( System.DateTime?[,,,] ),		Array4DDateTimeN )		;


			// リスト型のアダプター生成

			dapterCahce.Add( typeof( List<System.Boolean> ),		ListBoolean )		;
			dapterCahce.Add( typeof( List<System.Boolean?> ),		ListBooleanN )		;
			dapterCahce.Add( typeof( List<System.Byte> ),			ListByte )			;
			dapterCahce.Add( typeof( List<System.Byte?> ),			ListByteN )			;
			dapterCahce.Add( typeof( List<System.SByte> ),			ListSByte )			;
			dapterCahce.Add( typeof( List<System.SByte?> ),			ListSByteN )		;
			dapterCahce.Add( typeof( List<System.Char> ),			ListChar )			;
			dapterCahce.Add( typeof( List<System.Char?> ),			ListCharN )			;
			dapterCahce.Add( typeof( List<System.Int16> ),			ListInt16 )			;
			dapterCahce.Add( typeof( List<System.Int16?> ),			ListInt16N )		;
			dapterCahce.Add( typeof( List<System.UInt16> ),			ListUInt16 )		;
			dapterCahce.Add( typeof( List<System.UInt16?> ),		ListUInt16N )		;
			dapterCahce.Add( typeof( List<System.Int32> ),			ListInt32 )			;
			dapterCahce.Add( typeof( List<System.Int32?> ),			ListInt32N )		;
			dapterCahce.Add( typeof( List<System.UInt32> ),			ListUInt32 )		;
			dapterCahce.Add( typeof( List<System.UInt32?> ),		ListUInt32N )		;
			dapterCahce.Add( typeof( List<System.Int64> ),			ListInt64 )			;
			dapterCahce.Add( typeof( List<System.Int64?> ),			ListInt64N )		;
			dapterCahce.Add( typeof( List<System.UInt64> ),			ListUInt64 )		;
			dapterCahce.Add( typeof( List<System.UInt64?> ),		ListUInt64N )		;
			dapterCahce.Add( typeof( List<System.Single> ),			ListSingle )		;
			dapterCahce.Add( typeof( List<System.Single?> ),		ListSingleN )		;
			dapterCahce.Add( typeof( List<System.Double> ),			ListDouble )		;
			dapterCahce.Add( typeof( List<System.Double?> ),		ListDoubleN )		;
			dapterCahce.Add( typeof( List<System.Decimal> ),		ListDecimal )		;
			dapterCahce.Add( typeof( List<System.Decimal?> ),		ListDecimalN )		;
			dapterCahce.Add( typeof( List<System.String> ),			ListString )		;
			dapterCahce.Add( typeof( List<System.DateTime> ),		ListDateTime )		;
			dapterCahce.Add( typeof( List<System.DateTime?> ),		ListDateTimeN )		;
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
		public static Array3DBooleanAdapter					Array3DBoolean{ get ; private set ; }
		public static Array3DBooleanNAdapter				Array3DBooleanN{ get ; private set ; }
		public static Array3DByteAdapter					Array3DByte{ get ; private set ; }
		public static Array3DByteNAdapter					Array3DByteN{ get ; private set ; }
		public static Array3DSByteAdapter					Array3DSByte{ get ; private set ; }
		public static Array3DSByteNAdapter					Array3DSByteN{ get ; private set ; }
		public static Array3DCharAdapter					Array3DChar{ get ; private set ; }
		public static Array3DCharNAdapter					Array3DCharN{ get ; private set ; }
		public static Array3DInt16Adapter					Array3DInt16{ get ; private set ; }
		public static Array3DInt16NAdapter					Array3DInt16N{ get ; private set ; }
		public static Array3DUInt16Adapter					Array3DUInt16{ get ; private set ; }
		public static Array3DUInt16NAdapter					Array3DUInt16N{ get ; private set ; }
		public static Array3DInt32Adapter					Array3DInt32{ get ; private set ; }
		public static Array3DInt32NAdapter					Array3DInt32N{ get ; private set ; }
		public static Array3DUInt32Adapter					Array3DUInt32{ get ; private set ; }
		public static Array3DUInt32NAdapter					Array3DUInt32N{ get ; private set ; }
		public static Array3DInt64Adapter					Array3DInt64{ get ; private set ; }
		public static Array3DInt64NAdapter					Array3DInt64N{ get ; private set ; }
		public static Array3DUInt64Adapter					Array3DUInt64{ get ; private set ; }
		public static Array3DUInt64NAdapter					Array3DUInt64N{ get ; private set ; }
		public static Array3DSingleAdapter					Array3DSingle{ get ; private set ; }
		public static Array3DSingleNAdapter					Array3DSingleN{ get ; private set ; }
		public static Array3DDoubleAdapter					Array3DDouble{ get ; private set ; }
		public static Array3DDoubleNAdapter					Array3DDoubleN{ get ; private set ; }
		public static Array3DDecimalAdapter					Array3DDecimal{ get ; private set ; }
		public static Array3DDecimalNAdapter				Array3DDecimalN{ get ; private set ; }
		public static Array3DStringAdapter					Array3DString{ get ; private set ; }
		public static Array3DDateTimeAdapter				Array3DDateTime{ get ; private set ; }
		public static Array3DDateTimeNAdapter				Array3DDateTimeN{ get ; private set ; }

		// ４次元
		public static Array4DBooleanAdapter					Array4DBoolean{ get ; private set ; }
		public static Array4DBooleanNAdapter				Array4DBooleanN{ get ; private set ; }
		public static Array4DByteAdapter					Array4DByte{ get ; private set ; }
		public static Array4DByteNAdapter					Array4DByteN{ get ; private set ; }
		public static Array4DSByteAdapter					Array4DSByte{ get ; private set ; }
		public static Array4DSByteNAdapter					Array4DSByteN{ get ; private set ; }
		public static Array4DCharAdapter					Array4DChar{ get ; private set ; }
		public static Array4DCharNAdapter					Array4DCharN{ get ; private set ; }
		public static Array4DInt16Adapter					Array4DInt16{ get ; private set ; }
		public static Array4DInt16NAdapter					Array4DInt16N{ get ; private set ; }
		public static Array4DUInt16Adapter					Array4DUInt16{ get ; private set ; }
		public static Array4DUInt16NAdapter					Array4DUInt16N{ get ; private set ; }
		public static Array4DInt32Adapter					Array4DInt32{ get ; private set ; }
		public static Array4DInt32NAdapter					Array4DInt32N{ get ; private set ; }
		public static Array4DUInt32Adapter					Array4DUInt32{ get ; private set ; }
		public static Array4DUInt32NAdapter					Array4DUInt32N{ get ; private set ; }
		public static Array4DInt64Adapter					Array4DInt64{ get ; private set ; }
		public static Array4DInt64NAdapter					Array4DInt64N{ get ; private set ; }
		public static Array4DUInt64Adapter					Array4DUInt64{ get ; private set ; }
		public static Array4DUInt64NAdapter					Array4DUInt64N{ get ; private set ; }
		public static Array4DSingleAdapter					Array4DSingle{ get ; private set ; }
		public static Array4DSingleNAdapter					Array4DSingleN{ get ; private set ; }
		public static Array4DDoubleAdapter					Array4DDouble{ get ; private set ; }
		public static Array4DDoubleNAdapter					Array4DDoubleN{ get ; private set ; }
		public static Array4DDecimalAdapter					Array4DDecimal{ get ; private set ; }
		public static Array4DDecimalNAdapter				Array4DDecimalN{ get ; private set ; }
		public static Array4DStringAdapter					Array4DString{ get ; private set ; }
		public static Array4DDateTimeAdapter				Array4DDateTime{ get ; private set ; }
		public static Array4DDateTimeNAdapter				Array4DDateTimeN{ get ; private set ; }

		// リスト

		public static ListBooleanAdapter					ListBoolean{ get ; private set ; }
		public static ListBooleanNAdapter					ListBooleanN{ get ; private set ; }
		public static ListByteAdapter						ListByte{ get ; private set ; }
		public static ListByteNAdapter						ListByteN{ get ; private set ; }
		public static ListSByteAdapter						ListSByte{ get ; private set ; }
		public static ListSByteNAdapter						ListSByteN{ get ; private set ; }
		public static ListCharAdapter						ListChar{ get ; private set ; }
		public static ListCharNAdapter						ListCharN{ get ; private set ; }
		public static ListInt16Adapter						ListInt16{ get ; private set ; }
		public static ListInt16NAdapter						ListInt16N{ get ; private set ; }
		public static ListUInt16Adapter						ListUInt16{ get ; private set ; }
		public static ListUInt16NAdapter					ListUInt16N{ get ; private set ; }
		public static ListInt32Adapter						ListInt32{ get ; private set ; }
		public static ListInt32NAdapter						ListInt32N{ get ; private set ; }
		public static ListUInt32Adapter						ListUInt32{ get ; private set ; }
		public static ListUInt32NAdapter					ListUInt32N{ get ; private set ; }
		public static ListInt64Adapter						ListInt64{ get ; private set ; }
		public static ListInt64NAdapter						ListInt64N{ get ; private set ; }
		public static ListUInt64Adapter						ListUInt64{ get ; private set ; }
		public static ListUInt64NAdapter					ListUInt64N{ get ; private set ; }
		public static ListSingleAdapter						ListSingle{ get ; private set ; }
		public static ListSingleNAdapter					ListSingleN{ get ; private set ; }
		public static ListDoubleAdapter						ListDouble{ get ; private set ; }
		public static ListDoubleNAdapter					ListDoubleN{ get ; private set ; }
		public static ListDecimalAdapter					ListDecimal{ get ; private set ; }
		public static ListDecimalNAdapter					ListDecimalN{ get ; private set ; }
		public static ListStringAdapter						ListString{ get ; private set ; }
		public static ListDateTimeAdapter					ListDateTime{ get ; private set ; }
		public static ListDateTimeNAdapter					ListDateTimeN{ get ; private set ; }
	}

	//--------------------------------------------------------------------------------------------
}
