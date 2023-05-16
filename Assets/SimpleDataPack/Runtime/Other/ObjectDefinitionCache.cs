#if UNITY_2019_4_OR_NEWER
#define UNITY
#endif

using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;
using System.Reflection ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// リフレクションのバインドフラグ
	private static readonly BindingFlags m_BindingFlags = ( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance ) ;

	/// <summary>
	/// オブジェクト定義情報のキャッシュ
	/// </summary>
	public class ObjectDefinitionCache
	{
		private readonly Dictionary<Type,ObjectDefinition>	m_ObjectDefinitions = new Dictionary<Type, ObjectDefinition>() ;

		/// <summary>
		/// 指定したオブジェクトに該当するオブジェクト定義を取得する
		/// </summary>
		/// <param name="objectType"></param>
		/// <returns></returns>
		public ObjectDefinition GetByType( Type objectType )
			=> m_ObjectDefinitions[ objectType ] ;

		/// <summary>
		/// インデクサ(オブジェクトタイプ)
		/// </summary>
		/// <param name="classType"></param>
		/// <returns></returns>
		public ObjectDefinition this[ Type objectType ]
			=> m_ObjectDefinitions[ objectType ] ;

		/// <summary>
		/// オブジェクト定義の登録数
		/// </summary>
		public System.Int16 Count	=> ( System.Int16 )m_ObjectDefinitions.Count ;

		/// <summary>
		/// キャッシュを初期化する
		/// </summary>
		public void Clear()
		{
			m_ObjectDefinitions.Clear() ;
		}

		/// <summary>
		/// キャッシュに登録済みか確認する
		/// </summary>
		/// <param name="objectType"></param>
		/// <returns></returns>
		public bool ContainsKey( Type objectType )	=> m_ObjectDefinitions.ContainsKey( objectType ) ;

		//-------------------------------------------------------------------------------------------

		// クラス定義を追加する
		public void Add( Type type, bool disallowPrimitives )
		{
			var objectDefinition = CheckAndCreate( type, disallowPrimitives ) ;

			// 問題が起きていればこの前に例外が発生する

			// ignoreException = true の場合 null がありえる( false の場合は、問題があれば例外が発生してここにはこない)
			// または既に当ログ済みでも null になる
			if( objectDefinition != null )
			{
				// 新しいオブジェクト定義を追加する
				m_ObjectDefinitions.Add( objectDefinition.ObjectType, objectDefinition ) ;

				//----------------------------------------------------------

				// アダプターを生成する
				objectDefinition.CreateAdapter() ;

				//----------------------------------------------------------

				// メンバーの中にオブジェクトがあれば追加する

				foreach( var member in objectDefinition.Members )
				{
					// メンバーアクセサーを生成する(ランタイム実行時でないとダイナミックメソッド生成でエラーになってしまうので注意)
					member.MakeAccessor( objectDefinition.ObjectType ) ;

					// プリミティブ以外のメンバーでオブジェクトを持つものがあればオブジェクト定義情報を登録する
					switch( member.ValueType )
					{
						case ValueTypes.Array :
						case ValueTypes.List :
						case ValueTypes.Dictionary :
						case ValueTypes.Object :

							// 再帰的に辿って追加する(プリミティブは無視する)
							Add( member.Type, false ) ;
						break ;
					}
				}
			}
		}

		//-------------------------------------------------------------------------------------------

		// アレイ・リスト・Null許容であれば実際のオブジェクト型を抽出する
		private ObjectDefinition CheckAndCreate( Type type, bool disallowPrimitives )
		{
			if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				// Nullable
				type = Nullable.GetUnderlyingType( type ) ;
			}

			//----------------------------------

			if( type.IsArray == true )
			{
				// アレイ型
				return CheckAndCreate( type.GetElementType(), disallowPrimitives ) ;
			}
			else
			if( type.IsGenericType == true )
			{
				// ジェネリック

				if( type.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// リスト型
					var types = type.GenericTypeArguments ;
					if( types != null && types.Length == 1 )
					{
						return CheckAndCreate( types[ 0 ], disallowPrimitives ) ;
					}
					else
					{
						// 複数のジェネリックの場合はスルーされる
						throw new Exception( message:"Only one argument of list type is valid." ) ;
					}
				}
				else
				if( type.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// ディクショナリ型(ただし値のみ)

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

					return CheckAndCreate( valueType, disallowPrimitives ) ;
				}
				else
				{
					// その他のジェネリックは許容していない
					throw new Exception( message:"This type is not supported : " + type.Name ) ;
				}
			}
			else
			{
				if
				(
					(
						// class
						type.IsClass == true  &&
						type != typeof( System.String ) )
					||
					(
						// struct
						type.IsClass == false &&
						type.IsValueType == true &&
						type.IsPrimitive == false &&
						type.IsEnum == false &&
						type != typeof( System.Decimal ) &&
						type != typeof( System.DateTime )
					)
				)
				{
					// class または struct

					// 既に登録済みか確認する
					if( m_ObjectDefinitions.ContainsKey( type ) == true )
					{
						// 既に登録済み
						return null ;
					}

					// アトリビュートの設定の確認を行う
					if
					(
						type.GetCustomAttribute<SimpleDataPackObjectAttribute>()	!= null ||
						type.GetCustomAttribute<System.SerializableAttribute>()		!= null
					)
					{
						// 有効なオブジェクトの型
						return Create( type ) ;
					}
					else
					{
						throw new Exception( message:"Missing attribute description. : " + type.Name ) ;
					}
				}
				else
				{
					if( disallowPrimitives == true )
					{
						// プリミティブ型(Enum Boolean ～ DateTime)は不可
						throw new Exception( message:"Unusable type. Possible types are class or struct. : " + type.Name ) ;
					}
				}
			}

			// プリミティブ型(Enum Boolean ～ DateTime)のスルーの場合はここに来る
			return null ;
		}

		//-------------------------------------------------------------------------------------------

		// クラス定義を生成する(このメソッドが呼び出される時点で対象のオブジェクト型である事は確定している)
		public ObjectDefinition Create( Type objectType )
		{
			bool keyAsCode = false ;

			// Serializable も対応しているので SimpleDataPackObject の記述が無い場合がある
			var customAttribute = objectType.GetCustomAttribute<SimpleDataPackObjectAttribute>() ;
			if( customAttribute != null )
			{
				keyAsCode = customAttribute.KeyAsCode ;
			}

			//----------------------------------------------------------

			// 新しいオブジェクト定義を生成する
			ObjectDefinition objectDefinition = new ObjectDefinition()
			{
				ObjectType	= objectType,
				KeyAsCode	= keyAsCode
			} ;

			//----------------------------------------------------------

			// 対象メンバー情報
			List<ObjectDefinition.MemberDefinition> members = new List<ObjectDefinition.MemberDefinition>() ;

			MemberInfo[] memberInfos = objectType.GetMembers( m_BindingFlags ) ;

			// メンバーごとに処理を行う
			foreach( MemberInfo memberInfo in memberInfos )
			{
				Type			type		= null ;
				System.UInt16	code		= 0 ;

				FieldInfo		field		= null ;
				PropertyInfo	property	= null ;

				if( memberInfo.MemberType == MemberTypes.Field )
				{
					// フィールド

					field = objectType.GetField( memberInfo.Name, m_BindingFlags ) ;
					var memberAttribute = field.GetCustomAttribute<SimpleDataPackMemberAttribute>() ;

					//------------
#if UNITY
					// Unity 環境の場合は SerializeField にも対応する
					bool isSerializeField	= ( field.GetCustomAttribute<SerializeField>() != null ) ;
#endif
					//------------

					bool isNonSerialized	= ( field.GetCustomAttribute<System.NonSerializedAttribute>() != null ) ;

					//------------

					if( keyAsCode == false )
					{
						// メンバー並び順にコード値を使用しない
						if
						(
							(
#if UNITY
								isSerializeField == true										||
#endif
								( memberAttribute != null && memberAttribute.IsMember == true ) ||
								( memberAttribute == null && field.IsPublic			  == true )
							) &&
							isNonSerialized == false 
						)
						{
							// 有効なメンバー
							type = field.FieldType ;
						}
					}
					else
					{
						// メンバー並び順にコード値を使用する => SimpleDataPackMember(code) 必須
						if( memberAttribute != null && memberAttribute.IsMember == true )
						{
							// 有効なメンバー
							code = ( System.UInt16 )memberAttribute.Code ;
							type = field.FieldType ;
						}
					}
				}
				else
				if( memberInfo.MemberType == MemberTypes.Property )
				{
					// プロパティ

					property = objectType.GetProperty( memberInfo.Name, m_BindingFlags ) ;
					var memberAttribute = property.GetCustomAttribute<SimpleDataPackMemberAttribute>() ;

					// getter が public かどうか

					bool isRemainGetter = false ;
					bool isPublicGetter = false ;
					bool isRemainSetter = false ;

					// Getter の確認
					var getter = property.GetMethod ;
					if( getter != null && property.CanRead == true )
					{
						isRemainGetter = true ;
						isRemainGetter = getter.IsPublic ;
					}

					var setter = property.SetMethod ;
					if( setter != null && property.CanWrite == true )
					{
						isRemainSetter = true ;
					}

					//------------
#if UNITY
					// Unity 環境の場合は SerializeField にも対応する
					bool isSerializeField	= ( property.GetCustomAttribute<SerializeField>() != null ) ;
#endif
					//------------

					if( keyAsCode == false )
					{
						// メンバー並び順にコード値を使用しない

						// アトリビュートの記述が有るなら対象メンバーとするには Getter と Setter の存在が必要
						// アトリビュートの指定が無いなら対象メンバーとするには Public の Getter と Setter の存在が必要
						if
						(
#if UNITY
							// Unity 環境の場合は SerializeField があれば Getter と Setter が有れば良い(public で無くても構わない)
							( isSerializeField == true                                    && isRemainGetter == true && isRemainSetter == true ) ||
#endif
							( memberAttribute != null && memberAttribute.IsMember == true && isRemainGetter == true && isRemainSetter == true ) ||
							( memberAttribute == null &&                                     isPublicGetter == true && isRemainSetter == true )
						)
						{
							// 有効なメンバー
							type = property.PropertyType ;
						}
					}
					else
					{
						// メンバー並び順にコード値を使用する

						// アトリビュートの記述が必須且つ対象メンバーとするには Getter と Setter の存在が必要
						if( memberAttribute != null && memberAttribute.IsMember == true && isRemainGetter == true && isRemainSetter == true )
						{
							// 有効なメンバー
							code = ( System.UInt16 )memberAttribute.Code ;
							type = property.PropertyType ;
						}
					}
				}

				// 例外を出さずに無視するケースが存在するため type が null になる可能性がある(null チェックが必要)
				if( type != null )
				{
					// フィールドとプロパティだけで見たら対象となっている(まだ対象して確定した訳ではない)

					ObjectDefinition.MemberDefinition member = new ObjectDefinition.MemberDefinition()
					{
						// 識別名
						Name			= memberInfo.Name,
						Code			= code,

						Field			= field,
						Property		= property,

						Type			= type,
					} ;

					// メンバーを追加する
					members.Add( member ) ;

					//--------------------------------------------------------
					// 処理を高速化するために固定情報を抽出・格納する

					if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
					{
						// IsNullable
						member.IsNullable = true ;

						type = Nullable.GetUnderlyingType( type ) ;
					}

					//--------------------------------

					// Nullable であった場合はその内部のタイプ
					member.ObjectType		= type ;

					// IsClsss
					member.ObjectIsClass	= type.IsClass ;

					// ObjectTypeCode
					member.ObjectTypeCode	= Type.GetTypeCode( type ) ;

					//------------
					
					if( type.IsArray == true )
					{
						// アレイ型
						member.ValueType = ValueTypes.Array ;
					}
					else
					if( type.IsGenericType == true )
					{
						// ジェネリック

						if( type.GetGenericTypeDefinition() == typeof( List<> ) )
						{
							// リスト型
							member.ValueType = ValueTypes.List ;
						}
						else
						if( type.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
						{
							// ディクショナリ型
							member.ValueType = ValueTypes.Dictionary ;
						}
						else
						{
							// その他のジェネリックは許容していない
							throw new Exception( message:"This type is not supported : " + type.Name ) ;
						}
					}
					else
					{
						if
						(
							(
								// class
								type.IsClass == true  &&
								type != typeof( System.String )		// 除外
							)
							||
							(
								// struct
								type.IsClass == false &&
								type.IsValueType == true &&
								type.IsPrimitive == false &&
								type.IsEnum == false &&
								type != typeof( System.Decimal ) &&	// 除外
								type != typeof( System.DateTime )	// 除外
							)
						)
						{
							// class または struct ※メンバーが存在する
							member.ValueType = ValueTypes.Object ;
						}
						else
						{
							// プリミティブ

							if( type.IsEnum == true )
							{
								// Enum
								member.ValueType = ValueTypes.Enum ;
							}
							else
							{
								switch( member.ObjectTypeCode )
								{
									case TypeCode.Boolean	: member.ValueType = ValueTypes.Boolean		; break ;
									case TypeCode.Byte		: member.ValueType = ValueTypes.Byte		; break ;
									case TypeCode.SByte		: member.ValueType = ValueTypes.SByte		; break ;
									case TypeCode.Char		: member.ValueType = ValueTypes.Char		; break ;
									case TypeCode.Int16		: member.ValueType = ValueTypes.Int16		; break ;
									case TypeCode.UInt16	: member.ValueType = ValueTypes.UInt16		; break ;
									case TypeCode.Int32		: member.ValueType = ValueTypes.Int32		; break ;
									case TypeCode.UInt32	: member.ValueType = ValueTypes.UInt32		; break ;
									case TypeCode.Int64		: member.ValueType = ValueTypes.Int64		; break ;
									case TypeCode.UInt64	: member.ValueType = ValueTypes.UInt64		; break ;
									case TypeCode.Single	: member.ValueType = ValueTypes.Single		; break ;
									case TypeCode.Double	: member.ValueType = ValueTypes.Double		; break ;
									case TypeCode.Decimal	: member.ValueType = ValueTypes.Decimal		; break ;	// struct
									case TypeCode.String	: member.ValueType = ValueTypes.String		; break ;	// class
									case TypeCode.DateTime	: member.ValueType = ValueTypes.DateTime	; break ;	// struct
								}
							}
						}
					}

					//--------------------------------------------------------

					// 最後にアクセサを生成する(ただしランタイム限定)
//					member.MakeAccessor( objectType ) ;
				}
			}

			if( members.Count == 0 )
			{
				// 対象のメンバーが存在しない
				throw new Exception( message:"Member is empty. : " + objectType.Name ) ;
			}

			if( members.Count >= 2 )
			{
				// ソートが必要
				if( keyAsCode == false )
				{
					// 識別名でソート
					objectDefinition.Members = members.OrderBy( _ => _.Name ).ToArray() ;
				}
				else
				{
					// コードでソート(コード値が同じ場合は名前でソート)
					objectDefinition.Members = members.OrderBy( _ => _.Code ).ThenBy( _ => _.Name ).ToArray() ;
				}
			}
			else
			{
				objectDefinition.Members = members.ToArray() ;
			}

			return objectDefinition ;
		}
	}
}
