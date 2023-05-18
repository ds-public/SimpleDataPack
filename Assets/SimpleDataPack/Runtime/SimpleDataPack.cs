using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

/// <summary>
/// SimpleDataPack Version 2023/05/09
/// </summary>
public partial class SimpleDataPack
{
	/// <summary>
	/// バイトオーダーはビッグエンディアンかどうか
	/// </summary>
	public static bool IsBigEndian
	{
		get
		{
			return m_IsBigEndian ;
		}
		set
		{
			m_IsBigEndian  = value ;
		}
	}

	// バイトオーダーはビッグエンディアンかどうか
	private static bool m_IsBigEndian = false ;

	//----------------

	/// <summary>
	/// 高速展開用のアダプタを有効化するか
	/// </summary>
	public static bool ExternalAdapterDisabled
	{
		get
		{
			return m_ExternalAdapterDisabled ;
		}
		set
		{
			if( m_ExternalAdapterDisabled != value )
			{
				m_ExternalAdapterDisabled  = value ;

				if( m_ExternalAdapterDisabled == false )
				{
					// 外部アダプターは有効
					if( m_ExternalAdapter != null )
					{
						ActiveAdapterCache = ExternalAdapterCache ;
					}
					else
					{
						ActiveAdapterCache = InternalAdapterCache ;
					}
				}
				else
				{
					// 外部アダプターは無効
					ActiveAdapterCache = InternalAdapterCache ;
				}
			}
		}
	}

	// 高速展開用のアダプタを無効化するか
	private static bool m_ExternalAdapterDisabled = false ;


	private static IExternalAdapter	m_ExternalAdapter ;

	/// <summary>
	/// アダプターが有効になっているかどうか
	/// </summary>
	public static bool	ExternalAdapterEnabled => ( m_ExternalAdapter != null ) ;

	//------------------------------------

	// オブジェクト定義情報のキャッシュ
	private static ObjectDefinitionCache	m_ObjectDefinitionCache ;

	// データ変換処理
	private static DataConverter			m_DataConverter ;

	private static BuiltInAdapter			m_BuiltInAdapter ;

	//--------------------------------------------------------------------------------------------
	// 列挙子

	/// <summary>
	/// 動作の優先すべきもの
	/// </summary>
	public enum PriorityTypes : byte
	{
		/// <summary>
		/// スピード
		/// </summary>
		Speed = 0,

		/// <summary>
		/// サイズ
		/// </summary>
		Size = 1,
	}

	/// <summary>
	/// メンバーの型(５ビット)
	/// </summary>
	public enum ValueTypes : byte
	{
		Enum		=  0,
		Boolean		=  1,
		Byte		=  2,
		SByte		=  3,
		Char		=  4,
		Int16		=  5,
		UInt16		=  6,
		Int32		=  7,
		UInt32		=  8,
		Int64		=  9,
		UInt64		= 10,
		Single		= 11,
		Double		= 12,
		Decimal		= 13,
		String		= 14,
		DateTime	= 15,

		Object		= 16,

		Array		= 18,
		List		= 19,
		Dictionary	= 20,
	}

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// スタティックコンストラクタ
	/// </summary>
	static SimpleDataPack()
	{
		Initialize() ;
	}

	/// <summary>
	/// 初期化を実行する
	/// </summary>
	public static void Initialize()
	{
		InternalAdapterCache				= new Dictionary<Type,IAdapter>() ;
		ExternalAdapterCache				= new Dictionary<Type,IAdapter>() ;

		//-----

		// デフォルトで内部デリゲートを使用する
		ActiveAdapterCache					= InternalAdapterCache ;

		//-----------------------------------

		m_ObjectDefinitionCache			= new ObjectDefinitionCache() ;

		m_DataConverter					= new DataConverter() ;	// データ変換処理

		m_BuiltInAdapter				= new BuiltInAdapter() ;
		m_BuiltInAdapter.AddTo( InternalAdapterCache ) ;
		m_BuiltInAdapter.AddTo( ExternalAdapterCache ) ;
	}


	/// <summary>
	/// アダプターを設定する
	/// </summary>
	/// <param name="adapter"></param>
	public static void SetExternalAdapter( IExternalAdapter externalAdapter )
	{
		m_ExternalAdapter = externalAdapter ;

		// この前に SimpleDataPack のスタティックコンストラクタが実行されているはずである

		m_ExternalAdapter.AddToExternalAdapterCache() ;

		//-----------------------------------

		ActiveAdapterCache	= ExternalAdapterCache ;
	}

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// オブジェクトをシリアライズしバイト配列を取得する
	/// </summary>
	/// <param name="target"></param>
	/// <returns></returns>
	public static byte[] Serialize<T>( T entity, bool toJson = false, bool prettyPrint = false, PriorityTypes priorityType = PriorityTypes.Speed )
	{
		byte[] data ;

		if( toJson == false )
		{
			data = Serialize_ToBinary( entity, priorityType ) ;
		}
		else
		{
			data = m_JsonConverter.Encode( entity, prettyPrint ) ;
		}

		return data ;
	}

	private static byte[] Serialize_ToBinary<T>( T entity, PriorityTypes priorityType )
	{
		bool isBigEndian = m_IsBigEndian ;

		//-----------------------------------

		// バイトストリームを生成する
		var writer = new ByteStream() ;
		writer.Initialize( null, isBigEndian, priorityType ) ;

		//-----------------------------------

		// シグネチャを記録する
		writer.PutByte( ( System.Byte )'S' ) ;
		writer.PutByte( ( System.Byte )'D' ) ;
		writer.PutByte( ( System.Byte )'P' ) ;

		//-----------------------------------

		// モード情報を設定する

		// エンディアンを記録する
		byte mode = isBigEndian ? ( byte )1 : ( byte )0 ;

		mode |= ( byte )( ( byte )priorityType << 1 ) ;

		writer.PutByte( mode ) ;		// エンディアンとプライオリティの情報

		//-----------------------------------------------------------
		// ＋４バイト目以降が実際のデータ部になる

		m_DataConverter.Serialize( entity, writer ) ;

		byte[] data = writer.GetData() ;

		writer.Dispose() ;

		//-------------------------------------------------------------------------------------------

		return data ;
	}

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// オブジェクトをシリアライズしバイト配列を取得する
	/// </summary>
	/// <param name="target"></param>
	/// <returns></returns>
	public static T Deserialize<T>( ReadOnlySpan<byte> data, bool fromJson = false )
//	public static T Deserialize<T>( byte[] data, bool fromJson = false )
	{
		if( fromJson == false )
		{
			return ( T )Deserialize_ToObject( typeof( T ), data )  ;
		}
		else
		{
			return ( T )m_JsonConverter.Decode( typeof( T ), data ) ;
		}
	}

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// オブジェクトをシリアライズしバイト配列を取得する
	/// </summary>
	/// <param name="target"></param>
	/// <returns></returns>
	private static System.Object Deserialize_ToObject( Type type, ReadOnlySpan<byte> data )
//	private static System.Object Deserialize_ToObject( Type type, byte[] data )
	{
		if( data == null || data.Length <  4 )
		{
			// 失敗
			throw new Exception( message:"Insufficient data size." ) ;
		}

		//-----------------------------------

		// シグネチャの確認
		if( ( data[ 0 ] == 'S' && data[ 1 ] == 'D' && data[ 2 ] == 'P' ) == false )
		{
			// 失敗
			throw new Exception( message:"No signature found." ) ;
		}

		//-----------------------------------
		// モード情報の取得と確認

		byte mode = data[ 3 ] ;

		// ビッグエンディアンのデータかどうか
		bool isBigEndian = ( ( mode & 0x01 ) != 0 ) ;

		PriorityTypes priorityType = ( PriorityTypes )( mode >> 1 ) ;

		//-----------------------------------

		// バイトストリームを生成する(ちょっと重い。0.3 ms 程かかっている)
		var reader = new ByteStream() ;
		reader.Initialize( data, isBigEndian, priorityType ) ;

		//-----------------------------------

		// シグネチャとリトルエンディアン部分を飛ばす
		reader.Skip( 4 ) ;

		System.Object entity = m_DataConverter.Deserialize( type, reader ) ;

		reader.Dispose() ;

		return entity ;
	}

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// オブジェクト定義情報のキャッシュを消去する
	/// </summary>
	public static void Clear()
	{
		// 内部アダプターの初期化

		m_ObjectDefinitionCache.Clear() ;

		InternalAdapterCache.Clear() ;
		m_BuiltInAdapter.AddTo( InternalAdapterCache ) ;

		//-----------------------------------

		// 外部アダプターの初期化
		ExternalAdapterCache.Clear() ;
		m_BuiltInAdapter.AddTo( ExternalAdapterCache ) ;

		if( ExternalAdapterEnabled == true )
		{
			m_ExternalAdapter.AddToExternalAdapterCache() ;	// 後で ↓ に変える
		}
	}

	//-------------------------------------------------------------------------------------------
	// ユーティリティ

	// タイプ名を取得する
	public static string GetTypeName( Type type, bool notNull = false )
	{
		string typeName ;

		// Nullable なら一旦削除
		bool isNullable = false ;
		if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			// Nullable
			isNullable = true ;
			type = Nullable.GetUnderlyingType( type ) ;
		}

		//----------------------------------

		if( type.IsArray == false )
		{
			if( type.IsGenericType == false )
			{
				TypeCode typeCode = Type.GetTypeCode( type ) ;
				if
				(
					( typeCode != TypeCode.Object && type.IsEnum == false ) ||
					type == typeof( System.Decimal ) || type == typeof( System.String ) || type == typeof( System.DateTime )
				)
				{
					// プリミティブ
					typeName = type.Name ;
				}
				else
				{
					// 任意
					typeName = type.Namespace + "." + type.Name ;
				}
			}
			else
			{
				if( type.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					typeName = GetListTypeName( type, false ) ;
				}
				else
				if( type.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					typeName = GetDictionaryTypeName( type, false ) ;
				}
				else
				{
					throw new Exception( message:"Invalid type. : Type = " + type.Name ) ;
				}
			}
		}
		else
		{
			typeName = GetArrayTypeName( type, false ) ;
		}

		if( isNullable == true && notNull == false )
		{
			typeName += "?" ;
		}

		return typeName ;
	}

	// アレイ型のタイプ名を取得する
	private static string GetArrayTypeName( Type type, bool notNull )
	{
		// アレイの場合は入れ子も全て同じ型となる

		// アレイ自体の Nullable を除去(ワーニングである)
		bool isNullable = false ;
		if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			// Nullable
			isNullable = true ;
			type = Nullable.GetUnderlyingType( type ) ;
		}

		//----------------------------------------------------------

		string totalDimension = string .Empty ;

		var elementType = type ;

		for( ; ; )
		{
			string dimension = "[" ;
			int i, l = elementType.GetArrayRank() ;
			for( i  = 0 ; i <  ( l - 1 ) ; i ++ )
			{
				dimension += "," ;
			}
			dimension += "]" ;

			totalDimension += dimension ;

			elementType = elementType.GetElementType() ;

			if( elementType.IsArray == false )
			{
				break ;
			}
		}

		//----------------------------------

		string elementName ;

		// アレイエレメントの Nullable を除去
		bool isElementNullable = false ;
		if( elementType.IsGenericType == true && elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			// Nullable
			isElementNullable = true ;
			elementType = Nullable.GetUnderlyingType( elementType ) ;
		}

		if( elementType.IsGenericType == false )
		{
			TypeCode typeCode = Type.GetTypeCode( elementType ) ;
			if
			(
				( typeCode != TypeCode.Object && elementType.IsEnum == false ) ||
				elementType == typeof( System.Decimal ) || elementType == typeof( System.String ) || elementType == typeof( System.DateTime )
			)
			{
				// プリミティブ
				elementName = elementType.Name ;
			}
			else
			{
				// 任意
				elementName = elementType.Namespace + "." + elementType.Name ;
			}
		}
		else
		{
			// ジェネリック
			if( elementType.GetGenericTypeDefinition() == typeof( List<> ) )
			{
				elementName = GetListTypeName( elementType, false ) ;
			}
			else
			if( elementType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
			{
				elementName = GetDictionaryTypeName( elementType, false ) ;
			}
			else
			{
				throw new Exception( message:"Invalid type. : Type = " + elementType.Name ) ;
			}
		}

		if( isElementNullable == true )
		{
			elementName += "?" ;
		}

		string typeName = elementName + totalDimension ;

		if( isNullable == true && notNull == false )
		{
			typeName += "?" ;
		}

		return typeName ;
	}

	// リスト型のタイプ名を取得する
	public static string GetListTypeName( Type type, bool notNull )
	{
		// リスト自体の Nullable を削除(ワーニングである)
		bool isNullable = false ;
		if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			// Nullable
			isNullable = true ;
			type = Nullable.GetUnderlyingType( type ) ;
		}

		//----------------------------------------------------------

		var types = type.GenericTypeArguments ;
		if( types == null || types.Length != 1 )
		{
			// 複数のジェネリックの場合はスルーされる
			throw new Exception( message:"Only one argument of list type is valid." ) ;
		}

		var elementType = types[ 0 ] ;

		// リストエレメントの Nullable を削除
		bool isElementNullable = false ;
		if( elementType.IsGenericType == true && elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			// Nullable
			isElementNullable = true ;
			elementType = Nullable.GetUnderlyingType( elementType ) ;
		}

		//----------------------------------------------------------

		string elementName ;

		if( elementType.IsArray == false )
		{
			if( elementType.IsGenericType == false )
			{
				TypeCode typeCode = Type.GetTypeCode( elementType ) ;
				if
				(
					( typeCode != TypeCode.Object && elementType.IsEnum == false )  ||
					elementType == typeof( System.Decimal ) || elementType == typeof( System.String ) || elementType == typeof( System.DateTime )
				)
				{
					// プリミティブ
					elementName = elementType.Name ;
				}
				else
				{
					// 任意
					elementName = elementType.Namespace + "." + elementType.Name ;
				}
			}
			else
			{
				// ジェネリック
				if( elementType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					elementName = GetListTypeName( elementType, false ) ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					elementName = GetDictionaryTypeName( elementType, false ) ;
				}
				else
				{
					throw new Exception( message:"Invalid type. : Type = " + elementType.Name ) ;
				}
			}
		}
		else
		{
			elementName = GetArrayTypeName( elementType, false ) ;
		}

		if( isElementNullable == true )
		{
			elementName += "?" ;
		}

		string typeName = "List<" + elementName + ">" ;

		if( isNullable == true && notNull == false )
		{
			typeName += "?" ;
		}

		return typeName ;
	}

	// リスト型のタイプ名を取得する
	public static string GetDictionaryTypeName( Type type, bool notNull )
	{
		// ディクショナリ自体の Nullable を削除(ワーニングである)
		bool isNullable = false ;
		if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			// Nullable
			isNullable = true ;
			type = Nullable.GetUnderlyingType( type ) ;
		}

		//----------------------------------------------------------

		// objectType は Dictionary 型である事に注意
		var types = type.GenericTypeArguments ;
		if( types == null || types.Length != 2 )
		{
			// 複数のジェネリックの場合はスルーされる
			throw new Exception( message:"Only two argument of dictionary type is valid." ) ;
		}

		var keyType   = types[ 0 ] ;
		var valueType = types[ 1 ] ;

		if( keyType.IsGenericType == true )
		{
			// キータイプにジェネリックは全面的に不可(Nullable も含まれる)
			throw new Exception( message:"Generic is not allowed for key type." + keyType.Name ) ;
		}

		// キータイプに関してはプリミティブ以外は許容しない
		if
		(
			(
				( keyType.IsEnum == true ) ||	// Enum
				( keyType.IsClass == false && keyType.IsValueType == true && keyType.IsPrimitive == true ) ||	// Primitive
				( keyType == typeof( System.Decimal ) ) ||
				( keyType == typeof( System.String ) ) ||
				( keyType == typeof( System.DateTime ) )
			) == false
		)
		{
			throw new Exception( message:"Only primitive types are allowed for key types." + keyType.Name ) ;
		}

		// ValueType の Nullable 確認
		bool isValueNullable = false ;
		if( valueType.IsGenericType == true && valueType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
		{
			isValueNullable = true ;
			valueType = Nullable.GetUnderlyingType( valueType ) ;
		}

		//----------------------------------

		string keyTypeName = keyType.Name ;

		if( keyType.IsEnum == true )
		{
			keyTypeName = keyType.Namespace + "." + keyTypeName ;
		}

		string valueTypeName ;

		if( valueType.IsArray == false )
		{
			if( valueType.IsGenericType == false )
			{
				TypeCode typeCode = Type.GetTypeCode( valueType ) ;
				if
				(
					( typeCode != TypeCode.Object && valueType.IsEnum == false ) ||
					valueType == typeof( System.Decimal ) || valueType == typeof( System.String ) || valueType == typeof( System.DateTime )
				)
				{
					// プリミティブ(Boolean ～ DateTime)
					valueTypeName = valueType.Name ;
				}
				else
				{
					// 任意(Enum Class Struct)
					valueTypeName = valueType.Namespace + "." + valueType.Name ;
				}
			}
			else
			{
				// ジェネリック
				if( valueType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					valueTypeName = GetListTypeName( valueType, false ) ;
				}
				else
				if( valueType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					valueTypeName = GetDictionaryTypeName( valueType, false ) ;
				}
				else
				{
					throw new Exception( message:"Invalid type. : Type = " + valueType.Name ) ;
				}
			}
		}
		else
		{
			valueTypeName = GetArrayTypeName( valueType, false ) ;
		}

		if( isValueNullable == true )
		{
			valueTypeName += "?" ;
		}

		string typeName = "Dictionary<" + keyTypeName + "," + valueTypeName + ">" ;

		if( isNullable == true && notNull == false )
		{
			typeName += "?" ;
		}

		return typeName ;
	}

}

