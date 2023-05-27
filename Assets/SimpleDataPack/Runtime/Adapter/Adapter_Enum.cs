using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// Enum アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EnumAdapter<T> : IAdapter
	{
		private readonly Type	enumType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public EnumAdapter()
		{
			enumType			= typeof( T ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutByte( ( System.Byte )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetByte() ) ;
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutSByte( ( System.SByte )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetSByte() ) ;
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutInt16( ( System.Int16 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetInt16() ) ;
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutUInt16( ( System.UInt16 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetUInt16() ) ;
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutInt32( ( System.Int32 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetInt32() ) ;
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutUInt32( ( System.UInt32 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetUInt32() ) ;
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutInt64( ( System.Int64 )value  ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetInt64() ) ;
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutUInt64( ( System.UInt64 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return ( T )Enum.ToObject( enumType, reader.GetUInt64() ) ;
					} ;
				break ;
			}
		}

		private readonly Action<System.Object,ByteStream>	SetValue ;
		private readonly Func<ByteStream,System.Object>		GetValue ;

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
			=> SetValue( entity, writer ) ;

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
			=> GetValue( reader ) ;
	}

	//------------------------------------------------------------

	/// <summary>
	/// Enum? アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EnumNAdapter<T> : IAdapter
	{
		private readonly Type	enumType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public EnumNAdapter()
		{
			enumType			= Nullable.GetUnderlyingType( typeof( T ) ) ;
			var enumTypeCode	= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetByteN() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.Byte )_ ) ;
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetSByteN() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.SByte )_ ) ;
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetInt16N() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.Int16 )_ ) ;
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetUInt16N() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.UInt16 )_ ) ;
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetInt32N() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.Int32 )_ ) ;
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetUInt32N() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.UInt32 )_ ) ;
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetInt64N() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.Int64 )_ ) ;
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetUInt64N() ; return _ == null ? default : ( T )Enum.ToObject( enumType, ( System.UInt64 )_ ) ;
					} ;
				break ;
			}
		}

		private readonly Action<System.Object,ByteStream>	SetValue ;
		private readonly Func<ByteStream,System.Object>		GetValue ;

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
			=> SetValue( entity, writer ) ;

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
			=> GetValue( reader ) ;
	}

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	/// <summary>
	/// Enum アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EnumVersatileAdapter : IAdapter
	{
		private readonly Type	enumType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public EnumVersatileAdapter( Type elementType )
		{
			enumType				= elementType ;
			var enumTypeCode		= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutByte( ( System.Byte )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetByte() ) ;
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutSByte( ( System.SByte )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetSByte() ) ;
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutInt16( ( System.Int16 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetInt16() ) ;
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutUInt16( ( System.UInt16 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetUInt16() ) ;
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutInt32( ( System.Int32 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetInt32() ) ;
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutUInt32( ( System.UInt32 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetUInt32() ) ;
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutInt64( ( System.Int64 )value  ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetInt64() ) ;
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						writer.PutUInt64( ( System.UInt64 )value ) ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						return Enum.ToObject( enumType, reader.GetUInt64() ) ;
					} ;
				break ;
			}
		}

		private readonly Action<System.Object,ByteStream>	SetValue ;
		private readonly Func<ByteStream,System.Object>		GetValue ;

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
			=> SetValue( entity, writer ) ;

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
			=> GetValue( reader ) ;
	}

	//------------------------------------------------------------

	/// <summary>
	/// Enum? アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EnumNVersatileAdapter : IAdapter
	{
		private readonly Type		nullableEnumType ;
		private readonly Type		enumType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public EnumNVersatileAdapter( Type elementType )
		{
			nullableEnumType		= elementType ;
			enumType				= Nullable.GetUnderlyingType( nullableEnumType ) ;
			var enumTypeCode		= Type.GetTypeCode( enumType ) ;

			switch( enumTypeCode )
			{
				case TypeCode.Byte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutByteT( ( System.Byte )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetByteN() ; return _ == null ? default : Enum.ToObject( enumType, ( System.Byte )_ ) ;
					} ;
				break ;
				case TypeCode.SByte :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutSByteT( ( System.SByte )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetSByteN() ; return _ == null ? default : Enum.ToObject( enumType, ( System.SByte )_ ) ;
					} ;
				break ;
				case TypeCode.Int16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt16T( ( System.Int16 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetInt16N() ; return _ == null ? default : Enum.ToObject( enumType, ( System.Int16 )_ ) ;
					} ;
				break ;
				case TypeCode.UInt16 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt16T( ( System.UInt16 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetUInt16N() ; return _ == null ? default : Enum.ToObject( enumType, ( System.UInt16 )_ ) ;
					} ;
				break ;
				case TypeCode.Int32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt32T( ( System.Int32 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetInt32N() ; return _ == null ? default : Enum.ToObject( enumType, ( System.Int32 )_ ) ;
					} ;
				break ;
				case TypeCode.UInt32 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt32T( ( System.UInt32 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetUInt32N() ; return _ == null ? default : Enum.ToObject( enumType, ( System.UInt32 )_ ) ;
					} ;
				break ;
				case TypeCode.Int64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutInt64T( ( System.Int64 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetInt64N() ; return _ == null ? default : Enum.ToObject( enumType, ( System.Int64 )_ ) ;
					} ;
				break ;
				case TypeCode.UInt64 :
					SetValue = ( System.Object value, ByteStream writer ) =>
					{
						// System.Enum? → System.ValueType? キャストはやってはいけない(危険・IL2CPPでは動かない)
						if( value == null ){ writer.PutByte( 0 ) ; }else{ writer.PutUInt64T( ( System.UInt64 )value ) ; } ;
					} ;
					GetValue = ( ByteStream reader ) =>
					{
						var _ = reader.GetUInt64N() ; return _ == null ? default : Enum.ToObject( enumType, ( System.UInt64 )_ ) ;
					} ;
				break ;
			}
		}

		private readonly Action<System.Object,ByteStream>	SetValue ;
		private readonly Func<ByteStream,System.Object>		GetValue ;

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
			=> SetValue( entity, writer ) ;

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
			=> GetValue( reader ) ;
	}
}
