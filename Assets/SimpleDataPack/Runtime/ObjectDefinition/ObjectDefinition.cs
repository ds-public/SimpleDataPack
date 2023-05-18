#if UNITY_2019_4_OR_NEWER
#define UNITY
#endif

using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Reflection ;
using System.Reflection.Emit ;

#if UNITY
using UnityEngine ;
#endif

public partial class SimpleDataPack
{
	/// <summary>
	/// オブジェクト定義
	/// </summary>
	public class ObjectDefinition
	{
		/// <summary>
		/// // class または struct (Nullable Array List Dictionary という事は無い)
		/// </summary>
		public Type						ObjectType ;

		/// <summary>
		/// 並び順にコード値を使用するかどうか
		/// </summary>
		public bool						KeyAsCode ;

		/// <summary>
		/// クラス内のシリアライズ対象のメンバー情報群
		/// </summary>
		public MemberDefinition[]		Members ;

		//-------------------------------------------------------------------------------------------

		// 対象メンバーの管理用のクラス
		public class MemberDefinition
		{
			/// <summary>
			/// 識別名
			/// </summary>
			public string			Name ;

			/// <summary>
			/// コード
			/// </summary>
			public System.UInt16	Code ;

			//----------------------------------------------------------

			/// <summary>
			/// タイプ(IsArray IsList IsNullable も含む全体的な型)
			/// </summary>
			public Type				Type ;

			/// <summary>
			/// フィールドの場合のインスタンス
			/// </summary>
			public FieldInfo		Field ;

			/// <summary>
			/// プロパティの場合のインスタンス
			/// </summary>
			public PropertyInfo		Property ;

			//--------------

			/// <summary>
			/// Ｎｕｌｌ許容型かどうか
			/// </summary>
			public bool				IsNullable ;

			//--------------

			/// <summary>
			/// オブジェクトであった場合のタイプ(Array List Dictionary clas struct)
			/// </summary>
			public Type				ObjectType ;

			/// <summary>
			/// オブジェクトがクラスかどうか
			/// </summary>
			public bool				ObjectIsClass ;

			/// <summary>
			/// オブジェクトのタイプコード
			/// </summary>
			public TypeCode			ObjectTypeCode ;

			//--------------

			/// <summary>
			/// メンバーの値タイプ
			/// </summary>
			public ValueTypes		ValueType ;

			//----------------------------------------------------------

			/// <summary>
			/// アクセサのインターフェース
			/// </summary>
			public interface IAccessor
			{
				System.Object GetValue( System.Object entity ) ;
				void SetValue( System.Object entity, System.Object value ) ;
			}

#if ( NET_STANDARD_2_1 || NET_4_6 ) && ENABLE_MONO
			/// <summary>
			/// フィールドのアクセサ
			/// </summary>
			/// <typeparam name="TO"></typeparam>
			/// <typeparam name="TM"></typeparam>
			public class FieldAccessor<TO,TM> : IAccessor
			{
				private readonly	Func<TO,TM>		getter ;
				private readonly	Action<TO,TM>	setter ;

				/// <summary>
				/// コンストラクタ
				/// </summary>
				/// <param name="fi"></param>
				public FieldAccessor( FieldInfo fi )
				{
					//--------------------------------
					// Getter

					string getterMethodName = fi.ReflectedType.FullName + ".get_" + fi.Name ;
					var getterMethod = new DynamicMethod( getterMethodName, typeof( TM ), new Type[]{ typeof( TO ) }, true ) ;
					ILGenerator getterMethodILG = getterMethod.GetILGenerator() ;

					getterMethodILG.Emit( OpCodes.Ldarg_0 ) ;
					getterMethodILG.Emit( OpCodes.Ldfld, fi ) ;
					getterMethodILG.Emit( OpCodes.Ret ) ;

					getter = ( Func<TO,TM> )getterMethod.CreateDelegate( typeof( Func<TO,TM> ) ) ;

					//--------------------------------
					// Setter

					string setterMethodName = fi.ReflectedType.FullName + ".set_" + fi.Name ;
					var setterMethod = new DynamicMethod( setterMethodName, null, new Type[]{ typeof( TO ), typeof( TM ) }, true ) ;
					ILGenerator setterMethodILG = setterMethod.GetILGenerator() ;

					setterMethodILG.Emit( OpCodes.Ldarg_0 ) ;
					setterMethodILG.Emit( OpCodes.Ldarg_1 ) ;
					setterMethodILG.Emit( OpCodes.Stfld, fi ) ;
					setterMethodILG.Emit( OpCodes.Ret ) ;

					setter = ( Action<TO,TM> )setterMethod.CreateDelegate( typeof( Action<TO,TM> ) ) ;
				}

				//---------------------------------

				/// <summary>
				/// メンバー値を取得する(インターフェース)
				/// </summary>
				/// <param name="entity"></param>
				/// <returns></returns>
				public System.Object GetValue( System.Object entity )
				{
					return getter( ( TO )entity ) ;
				}

				/// <summary>
				/// メンバー値を設定する(インターフェース)
				/// </summary>
				/// <param name="entity"></param>
				/// <param name="value"></param>
				public void SetValue( System.Object entity, System.Object value )
				{
					setter( ( TO )entity, ( TM )value ) ;
				}
			}
#endif

			/// <summary>
			/// プロパティのアクセサ
			/// </summary>
			/// <typeparam name="TO"></typeparam>
			/// <typeparam name="TM"></typeparam>
			public class PropertyAccessor<TO,TM> : IAccessor
			{
				private readonly	Func<TO,TM>		getter ;
				private readonly	Action<TO,TM>	setter ;

				/// <summary>
				/// デストラクタ
				/// </summary>
				/// <param name="pi"></param>
				public PropertyAccessor( PropertyInfo pi )
				{
					//--------------------------------
					// Getter

					Type getterType = typeof( Func<,> ).MakeGenericType( pi.DeclaringType, pi.PropertyType ) ;
					getter = ( Func<TO,TM> )Delegate.CreateDelegate( getterType, pi.GetMethod ) ;	// GetGetMethod() は使っていはいけない private get だと null が変える

					//--------------------------------
					// Setter

					Type setterType = typeof( Action<,> ).MakeGenericType( pi.DeclaringType, pi.PropertyType ) ;
					setter = ( Action<TO,TM> )Delegate.CreateDelegate( setterType, pi.SetMethod ) ;	// GetSetMethod() は使っていはいけない private set だと null が変える
				}

				//---------------------------------

				/// <summary>
				/// メンバー値を取得する(インターフェース)
				/// </summary>
				/// <param name="entity"></param>
				/// <returns></returns>
				public System.Object GetValue( System.Object entity )
				{
					return getter( ( TO )entity ) ;
				}

				/// <summary>
				/// メンバー値を設定する(インターフェース)
				/// </summary>
				/// <param name="entity"></param>
				/// <param name="value"></param>
				public void SetValue( System.Object entity, System.Object value )
				{
					setter( ( TO )entity, ( TM )value ) ;
				}
			}

			//----------------------------------------------------------

			/// <summary>
			/// メンバーアクセサを生成する
			/// </summary>
			/// <param name="entityType"></param>
			public void  MakeAccessor( Type entityType )
			{
				if( Field != null )
				{
					// フィールドが対象

					if( entityType.IsClass == false )
					{
						// 遅い版(struct)
						GetValue = Field.GetValue ;
						SetValue = Field.SetValue ;
					}
					else
					{
						// 速い版(class)

#if ( NET_STANDARD_2_1 || NET_4_6 ) && ENABLE_MONO
						var fieldAccessor = ( IAccessor )Activator.CreateInstance( typeof( FieldAccessor<,> ).MakeGenericType( entityType, Type ), Field ) ;
						GetValue = fieldAccessor.GetValue ;
						SetValue = fieldAccessor.SetValue ;
#else
						// 未対応なので遅い版
						GetValue = Field.GetValue ;
						SetValue = Field.SetValue ;
#endif
					}
				}
				else
				{
					// プロパティが対象

					if( entityType.IsClass == false )
					{
						// 遅い版(struct)
						GetValue = Property.GetValue ;
						SetValue = Property.SetValue ;
					}
					else
					{
						// 速い版
#if ( NET_STANDARD_2_1 || NET_4_6 ) && ENABLE_MONO
						var propertyAccessor = ( IAccessor )Activator.CreateInstance( typeof( PropertyAccessor<,> ).MakeGenericType( entityType, Type ), Property ) ;
						GetValue = propertyAccessor.GetValue ;
						SetValue = propertyAccessor.SetValue ;
#else
						// 未対応なので遅い版
						GetValue = Property.GetValue ;
						SetValue = Property.SetValue ;
#endif
					}
				}

				//------------

				switch( ValueType )
				{
					case ValueTypes.Enum :
						switch( ObjectTypeCode )
						{
							case TypeCode.Byte :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_Byte ;
									Deserialize	= Deserialize_Enum_Byte ;
								}
								else
								{
									Serialize	= Serialize_Enum_ByteN ;
									Deserialize	= Deserialize_Enum_ByteN ;
								}
							break ;
							case TypeCode.SByte :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_SByte ;
									Deserialize	= Deserialize_Enum_SByte ;
								}
								else
								{
									Serialize	= Serialize_Enum_SByteN ;
									Deserialize	= Deserialize_Enum_SByteN ;
								}
							break ;
							case TypeCode.Int16 :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_Int16 ;
									Deserialize	= Deserialize_Enum_Int16 ;
								}
								else
								{
									Serialize	= Serialize_Enum_Int16N ;
									Deserialize	= Deserialize_Enum_Int16N ;
								}
							break ;
							case TypeCode.UInt16 :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_UInt16 ;
									Deserialize	= Deserialize_Enum_UInt16 ;
								}
								else
								{
									Serialize	= Serialize_Enum_UInt16N ;
									Deserialize	= Deserialize_Enum_UInt16N ;
								}
							break ;
							case TypeCode.Int32 :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_Int32 ;
									Deserialize	= Deserialize_Enum_Int32 ;
								}
								else
								{
									Serialize	= Serialize_Enum_Int32N ;
									Deserialize	= Deserialize_Enum_Int32N ;
								}
							break ;
							case TypeCode.UInt32 :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_UInt32 ;
									Deserialize	= Deserialize_Enum_UInt32 ;
								}
								else
								{
									Serialize	= Serialize_Enum_UInt32N ;
									Deserialize	= Deserialize_Enum_UInt32N ;
								}
							break ;
							case TypeCode.Int64 :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_Int64 ;
									Deserialize	= Deserialize_Enum_Int64 ;
								}
								else
								{
									Serialize	= Serialize_Enum_Int64N ;
									Deserialize	= Deserialize_Enum_Int64N ;
								}
							break ;
							case TypeCode.UInt64 :
								if( IsNullable == false )
								{
									Serialize	= Serialize_Enum_UInt64 ;
									Deserialize	= Deserialize_Enum_UInt64 ;
								}
								else
								{
									Serialize	= Serialize_Enum_UInt64N ;
									Deserialize	= Deserialize_Enum_UInt64N ;
								}
							break ;
						}
					break ;
					case ValueTypes.Boolean	:
						if( IsNullable == false )
						{
							Serialize	= Serialize_Boolean ;
							Deserialize	= Deserialize_Boolean ;
						}
						else
						{
							Serialize	= Serialize_BooleanN ;
							Deserialize	= Deserialize_BooleanN ;
						}
					break ;
					case ValueTypes.Byte :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Byte ;
							Deserialize	= Deserialize_Byte ;
						}
						else
						{
							Serialize	= Serialize_ByteN ;
							Deserialize	= Deserialize_ByteN ;
						}
					break ;
					case ValueTypes.SByte :
						if( IsNullable == false )
						{
							Serialize	= Serialize_SByte ;
							Deserialize	= Deserialize_SByte ;
						}
						else
						{
							Serialize	= Serialize_SByteN ;
							Deserialize	= Deserialize_SByteN ;
						}
					break ;
					case ValueTypes.Char :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Char ;
							Deserialize	= Deserialize_Char ;
						}
						else
						{
							Serialize	= Serialize_CharN ;
							Deserialize	= Deserialize_CharN ;
						}
					break ;
					case ValueTypes.Int16 :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Int16 ;
							Deserialize	= Deserialize_Int16 ;
						}
						else
						{
							Serialize	= Serialize_Int16N ;
							Deserialize	= Deserialize_Int16N ;
						}
					break ;
					case ValueTypes.UInt16 :
						if( IsNullable == false )
						{
							Serialize	= Serialize_UInt16 ;
							Deserialize	= Deserialize_UInt16 ;
						}
						else
						{
							Serialize	= Serialize_UInt16N ;
							Deserialize	= Deserialize_UInt16N ;
						}
					break ;
					case ValueTypes.Int32 :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Int32 ;
							Deserialize	= Deserialize_Int32 ;
						}
						else
						{
							Serialize	= Serialize_Int32N ;
							Deserialize	= Deserialize_Int32N ;
						}
					break ;
					case ValueTypes.UInt32 :
						if( IsNullable == false )
						{
							Serialize	= Serialize_UInt32 ;
							Deserialize	= Deserialize_UInt32 ;
						}
						else
						{
							Serialize	= Serialize_UInt32N ;
							Deserialize	= Deserialize_UInt32N ;
						}
					break ;
					case ValueTypes.Int64 :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Int64 ;
							Deserialize	= Deserialize_Int64 ;
						}
						else
						{
							Serialize	= Serialize_Int64N ;
							Deserialize	= Deserialize_Int64N ;
						}
					break ;
					case ValueTypes.UInt64 :
						if( IsNullable == false )
						{
							Serialize	= Serialize_UInt64 ;
							Deserialize	= Deserialize_UInt64 ;
						}
						else
						{
							Serialize	= Serialize_UInt64N ;
							Deserialize	= Deserialize_UInt64N ;
						}
					break ;
					case ValueTypes.Single :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Single ;
							Deserialize	= Deserialize_Single ;
						}
						else
						{
							Serialize	= Serialize_SingleN ;
							Deserialize	= Deserialize_SingleN ;
						}
					break ;
					case ValueTypes.Double :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Double ;
							Deserialize	= Deserialize_Double ;
						}
						else
						{
							Serialize	= Serialize_DoubleN ;
							Deserialize	= Deserialize_DoubleN ;
						}
					break ;
					case ValueTypes.Decimal :
						if( IsNullable == false )
						{
							Serialize	= Serialize_Decimal ;
							Deserialize	= Deserialize_Decimal ;
						}
						else
						{
							Serialize	= Serialize_DecimalN ;
							Deserialize	= Deserialize_DecimalN ;
						}
					break ;
					case ValueTypes.String :
						Serialize	= Serialize_String ;
						Deserialize	= Deserialize_String ;
					break ;
					case ValueTypes.DateTime :
						if( IsNullable == false )
						{
							Serialize	= Serialize_DateTime ;
							Deserialize	= Deserialize_DateTime ;
						}
						else
						{
							Serialize	= Serialize_DateTimeN ;
							Deserialize	= Deserialize_DateTimeN ;
						}
					break ;
					case ValueTypes.Object :
					case ValueTypes.Array :
					case ValueTypes.List :
					case ValueTypes.Dictionary :
						Serialize	= Serialize_AnyObject ;
						Deserialize	= Deserialize_AnyObject ;
					break ;
					default :
						throw new Exception( message:"Unknown error. : " + ValueType ) ;
				}
			}

			//----------------------------------------------------------
			// 共通情報

			//---------------------------------
			// メンバーへのリフレクションを使ったアクセス

			public Func<System.Object,System.Object>	GetValue ;
			public Action<System.Object,System.Object>	SetValue ;

			//----------------------------------
			// 各種型ごとに応じたアクセス

			public Action<System.Object,ByteStream>		Serialize ;
			public Action<System.Object,ByteStream>		Deserialize ;

			//---

			// Enum - Byte
			private void Serialize_Enum_Byte( System.Object entity, ByteStream writer )
			{
				writer.PutByte( ( System.Byte )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Byte( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetByte() ) ) ;
			}

			// Enum - Byte?
			private void Serialize_Enum_ByteN( System.Object entity, ByteStream writer )
			{
				writer.PutByteN( ( System.Byte? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_ByteN( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetByteN() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.Byte )_ ) ) ;
			}

			// Enum - SByte
			private void Serialize_Enum_SByte( System.Object entity, ByteStream writer )
			{
				writer.PutSByte( ( System.SByte )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_SByte( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetSByte() ) ) ;
			}

			// Enum - SByte?
			private void Serialize_Enum_SByteN( System.Object entity, ByteStream writer )
			{
				writer.PutSByteN( ( System.SByte? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_SByteN( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetSByteN() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.SByte )_ ) ) ;
			}

			// Enum - Int16
			private void Serialize_Enum_Int16( System.Object entity, ByteStream writer )
			{
				writer.PutInt16( ( System.Int16 )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Int16( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetInt16() ) ) ;
			}

			// Enum - Int16?
			private void Serialize_Enum_Int16N( System.Object entity, ByteStream writer )
			{
				writer.PutInt16N( ( System.Int16? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Int16N( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetInt16N() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.Int16 )_ ) ) ;
			}

			// Enum - UInt16
			private void Serialize_Enum_UInt16( System.Object entity, ByteStream writer )
			{
				writer.PutUInt16( ( System.UInt16 )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_UInt16( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetUInt16() ) ) ;
			}

			// Enum - UInt16?
			private void Serialize_Enum_UInt16N( System.Object entity, ByteStream writer )
			{
				writer.PutUInt16N( ( System.UInt16? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_UInt16N( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetUInt16N() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.UInt16 )_ ) ) ;
			}

			// Enum - Int32
			private void Serialize_Enum_Int32( System.Object entity, ByteStream writer )
			{
				writer.PutInt32( ( System.Int32 )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Int32( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetInt32() ) ) ;
			}

			// Enum - Int32?
			private void Serialize_Enum_Int32N( System.Object entity, ByteStream writer )
			{
				writer.PutInt32N( ( System.Int32? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Int32N( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetInt32N() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.Int32 )_ ) ) ;
			}

			// Enum - UInt32
			private void Serialize_Enum_UInt32( System.Object entity, ByteStream writer )
			{
				writer.PutUInt32( ( System.UInt32 )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_UInt32( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetUInt32() ) ) ;
			}

			// Enum - UInt32?
			private void Serialize_Enum_UInt32N( System.Object entity, ByteStream writer )
			{
				writer.PutUInt32N( ( System.UInt32? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_UInt32N( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetUInt32N() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.UInt32 )_ ) ) ;
			}

			// Enum - Int64
			private void Serialize_Enum_Int64( System.Object entity, ByteStream writer )
			{
				writer.PutInt64( ( System.Int64 )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Int64( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetInt64() ) ) ;
			}

			// Enum - Int64?
			private void Serialize_Enum_Int64N( System.Object entity, ByteStream writer )
			{
				writer.PutInt64N( ( System.Int64? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_Int64N( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetInt64N() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.Int64 )_ ) ) ;
			}

			// Enum - UInt64
			private void Serialize_Enum_UInt64( System.Object entity, ByteStream writer )
			{
				writer.PutUInt64( ( System.UInt64 )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_UInt64( System.Object entity, ByteStream reader )
			{
				SetValue( entity, Enum.ToObject( ObjectType, reader.GetUInt64() ) ) ;
			}

			// Enum - UInt64?
			private void Serialize_Enum_UInt64N( System.Object entity, ByteStream writer )
			{
				writer.PutUInt64N( ( System.UInt64? )GetValue( entity ) ) ;
			}

			private void Deserialize_Enum_UInt64N( System.Object entity, ByteStream reader )
			{
				var _ = reader.GetUInt64N() ;
				SetValue( entity, _ == null ? null : Enum.ToObject( ObjectType, ( System.UInt64 )_ ) ) ;
			}

			//---

			// Boolean
			private void Serialize_Boolean( System.Object entity, ByteStream writer )
				=> writer.PutBoolean( ( System.Boolean )GetValue( entity ) ) ;

			private void Deserialize_Boolean( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetBoolean() ) ;

			// Boolean?
			private void Serialize_BooleanN( System.Object entity, ByteStream writer )
				=> writer.PutBooleanN( ( System.Boolean? )GetValue( entity ) ) ;

			private void Deserialize_BooleanN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetBooleanN() ) ;

			//---

			// Byte
			private void Serialize_Byte( System.Object entity, ByteStream writer )
				=> writer.PutByte( ( System.Byte )GetValue( entity ) ) ;

			private void Deserialize_Byte( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetByte() ) ;

			// Byte?
			private void Serialize_ByteN( System.Object entity, ByteStream writer )
				=> writer.PutByteN( ( System.Byte? )GetValue( entity ) ) ;

			private void Deserialize_ByteN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetByteN() ) ;

			//---

			// SByte
			private void Serialize_SByte( System.Object entity, ByteStream writer )
				=> writer.PutSByte( ( System.SByte )GetValue( entity ) ) ;

			private void Deserialize_SByte( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetSByte() ) ;

			// SByte?
			private void Serialize_SByteN( System.Object entity, ByteStream writer )
				=> writer.PutSByteN( ( System.SByte? )GetValue( entity ) ) ;

			private void Deserialize_SByteN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetSByteN() ) ;

			//---

			// Char
			private void Serialize_Char( System.Object entity, ByteStream writer )
				=> writer.PutChar( ( System.Char )GetValue( entity ) ) ;

			private void Deserialize_Char( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetChar() ) ;

			// Char?
			private void Serialize_CharN( System.Object entity, ByteStream writer )
				=> writer.PutCharN( ( System.Char? )GetValue( entity ) ) ;

			private void Deserialize_CharN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetCharN() ) ;

			//---

			// Int16
			private void Serialize_Int16( System.Object entity, ByteStream writer )
				=> writer.PutInt16( ( System.Int16 )GetValue( entity ) ) ;

			private void Deserialize_Int16( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetInt16() ) ;

			// Int16?
			private void Serialize_Int16N( System.Object entity, ByteStream writer )
				=> writer.PutInt16N( ( System.Int16? )GetValue( entity ) ) ;

			private void Deserialize_Int16N( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetInt16N() ) ;

			//---

			// UInt16
			private void Serialize_UInt16( System.Object entity, ByteStream writer )
				=> writer.PutUInt16( ( System.UInt16 )GetValue( entity ) ) ;

			private void Deserialize_UInt16( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetUInt16() ) ;

			// UInt16?
			private void Serialize_UInt16N( System.Object entity, ByteStream writer )
				=> writer.PutUInt16N( ( System.UInt16? )GetValue( entity ) ) ;

			private void Deserialize_UInt16N( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetUInt16N() ) ;

			//---

			// Int32
			private void Serialize_Int32( System.Object entity, ByteStream writer )
				=> writer.PutInt32( ( System.Int32 )GetValue( entity ) ) ;

			private void Deserialize_Int32( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetInt32() ) ;

			// Int32?
			private void Serialize_Int32N( System.Object entity, ByteStream writer )
				=> writer.PutInt32N( ( System.Int32? )GetValue( entity ) ) ;

			private void Deserialize_Int32N( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetInt32N() ) ;

			//---

			// UInt32
			private void Serialize_UInt32( System.Object entity, ByteStream writer )
				=> writer.PutUInt32( ( System.UInt32 )GetValue( entity ) ) ;

			private void Deserialize_UInt32( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetUInt32() ) ;

			// UInt32?
			private void Serialize_UInt32N( System.Object entity, ByteStream writer )
				=> writer.PutUInt32N( ( System.UInt32? )GetValue( entity ) ) ;

			private void Deserialize_UInt32N( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetUInt32N() ) ;

			//---

			// Int64
			private void Serialize_Int64( System.Object entity, ByteStream writer )
				=> writer.PutInt64( ( System.Int64 )GetValue( entity ) ) ;

			private void Deserialize_Int64( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetInt64() ) ;

			// Int64?
			private void Serialize_Int64N( System.Object entity, ByteStream writer )
				=> writer.PutInt64N( ( System.Int64? )GetValue( entity ) ) ;

			private void Deserialize_Int64N( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetInt64N() ) ;

			//---

			// UInt64
			private void Serialize_UInt64( System.Object entity, ByteStream writer )
				=> writer.PutUInt64( ( System.UInt64 )GetValue( entity ) ) ;

			private void Deserialize_UInt64( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetUInt64() ) ;

			// UInt64?
			private void Serialize_UInt64N( System.Object entity, ByteStream writer )
				=> writer.PutUInt64N( ( System.UInt64? )GetValue( entity ) ) ;

			private void Deserialize_UInt64N( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetUInt64N() ) ;

			//---

			// Single
			private void Serialize_Single( System.Object entity, ByteStream writer )
				=> writer.PutSingle( ( System.Single )GetValue( entity ) ) ;

			private void Deserialize_Single( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetSingle() ) ;

			// Single?
			private void Serialize_SingleN( System.Object entity, ByteStream writer )
				=> writer.PutSingleN( ( System.Single? )GetValue( entity ) ) ;

			private void Deserialize_SingleN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetSingleN() ) ;

			//---

			// Double
			private void Serialize_Double( System.Object entity, ByteStream writer )
				=> writer.PutDouble( ( System.Double )GetValue( entity ) ) ;

			private void Deserialize_Double( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetDouble() ) ;

			// Double?
			private void Serialize_DoubleN( System.Object entity, ByteStream writer )
				=> writer.PutDoubleN( ( System.Double? )GetValue( entity ) ) ;

			private void Deserialize_DoubleN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetDoubleN() ) ;

			//---

			// Decimal
			private void Serialize_Decimal( System.Object entity, ByteStream writer )
				=> writer.PutDecimal( ( System.Decimal )GetValue( entity ) ) ;

			private void Deserialize_Decimal( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetDecimal() ) ;

			// Decimal?
			private void Serialize_DecimalN( System.Object entity, ByteStream writer )
				=> writer.PutDecimalN( ( System.Decimal? )GetValue( entity ) ) ;

			private void Deserialize_DecimalN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetDecimalN() ) ;

			//---

			// String
			private void Serialize_String( System.Object entity, ByteStream writer )
				=> writer.PutString( ( System.String )GetValue( entity ) ) ;

			private void Deserialize_String( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetString() ) ;

			//---

			// DateTime
			private void Serialize_DateTime( System.Object entity, ByteStream writer )
				=> writer.PutDateTime( ( System.DateTime )GetValue( entity ) ) ;

			private void Deserialize_DateTime( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetDateTime() ) ;

			// dateTime?
			private void Serialize_DateTimeN( System.Object entity, ByteStream writer )
				=> writer.PutDateTimeN( ( System.DateTime? )GetValue( entity ) ) ;

			private void Deserialize_DateTimeN( System.Object entity, ByteStream reader )
				=> SetValue( entity, reader.GetDateTimeN() ) ;

			//---

			// Other
			private void Serialize_AnyObject( System.Object entity, ByteStream writer )
				=> m_DataConverter.GetAdapter( Type ).Serialize( GetValue( entity ), writer ) ;

			private void Deserialize_AnyObject( System.Object entity, ByteStream reader )
				=> m_DataConverter.GetAdapter( Type ).Deserialize( reader ) ;
		}

		//-----------------------------------------------------------

		//-------------------------------------------------------------------------------------------

		// Null がありえる(class struct?)
		public class InternalObjectAdapter : IAdapter
		{
			// class または struct (Nullable Array List Dictionary という事は無い)
			private readonly Type				m_ObjectType ;
			private readonly MemberDefinition[]	m_Members ;

			//------------------------------------------------------------------------------------------

			public InternalObjectAdapter( ObjectDefinition objectDefinition )
			{
				m_ObjectType		= objectDefinition.ObjectType ;
				m_Members			= objectDefinition.Members ;
			}

			//----------------------------------------------------------

			/// <summary>
			/// シリアライズを実行する
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="writer"></param>
			public void Serialize( System.Object entity, ByteStream writer )
			{
				if( entity == null )
				{
					writer.PutByte( 0 ) ;
					return ;
				}

				//---------------------------------

				writer.PutByte( 1 ) ;

				//---------------------------------

				foreach( var member in m_Members )
				{
					member.Serialize( entity, writer ) ;
				}
			}

			/// <summary>
			/// デシリアライズを実行する
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public System.Object Deserialize( ByteStream reader )
			{
				if( reader.GetByte() == 0 )
				{
					return default ;
				}

				//---------------------------------

				var entity = Activator.CreateInstance( m_ObjectType ) ;

				//---------------------------------

				foreach( var member in m_Members )
				{
//					Debug.Log( "メンバー:" + member.Name ) ;
					member.Deserialize( entity, reader ) ;
				}

				return entity ;
			}
		}

		// Null はありえない(struct)
		public class InternalObjectAdapter_NotNullable : IAdapter
		{
			private readonly Type				m_ObjectType ;
			private readonly MemberDefinition[]	m_Members ;

			//------------------------------------------------------------------------------------------

			public InternalObjectAdapter_NotNullable( ObjectDefinition objectDefinition )
			{
				m_ObjectType		= objectDefinition.ObjectType ;
				m_Members			= objectDefinition.Members ;
			}

			//----------------------------------------------------------

			/// <summary>
			/// シリアライズを実行する
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="writer"></param>
			public void Serialize( System.Object entity, ByteStream writer )
			{
				foreach( var member in m_Members )
				{
					member.Serialize( entity, writer ) ;
				}
			}

			/// <summary>
			/// デシリアライズを実行する
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public System.Object Deserialize( ByteStream reader )
			{
				var entity = Activator.CreateInstance( m_ObjectType ) ;

				foreach( var member in m_Members )
				{
					member.Deserialize( entity, reader ) ;
				}

				return entity ;
			}
		}

		//-------------------------------------------------------------------------------------------

		// アダプターを生成する(Internal用)
		public void CreateAdapter()
		{
			if( ObjectType.IsClass == true )
			{
				// class

				// スカラ
				var adapter = ( IAdapter )( new InternalObjectAdapter( this ) ) ;
//				var adapter = ( IAdapter )Activator.CreateInstance( typeof( InternalObjectAdapter<> ).MakeGenericType( ObjectType ), this ) ;
				AddToInternalAdapterCache( ObjectType, adapter ) ;

				// アレイ(１次元)
				var arrayAdapter = ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( ObjectType ) ) ;
				AddToInternalAdapterCache( ObjectType.MakeArrayType(), arrayAdapter ) ;

				// リスト
				var listAdapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( ObjectType ) ) ;
				AddToInternalAdapterCache( typeof( List<> ).MakeGenericType( ObjectType ), listAdapter ) ;
			}
			else
			{
				// struct
				var adapter_NotNullable = ( IAdapter )( new InternalObjectAdapter_NotNullable( this ) ) ;
//				var adapter_NotNullable = ( IAdapter )Activator.CreateInstance( typeof( InternalObjectAdapter_NotNullable<> ).MakeGenericType( ObjectType ), this ) ;
				AddToInternalAdapterCache( ObjectType, adapter_NotNullable ) ;

				// アレイ(１次元)
				var arrayAdapter_NotNullable = ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( ObjectType ) ) ;
				AddToInternalAdapterCache( ObjectType.MakeArrayType(), arrayAdapter_NotNullable ) ;

				// リスト
				var listAdapter_NotNullable = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( ObjectType ) ) ;
				AddToInternalAdapterCache( typeof( List<> ).MakeGenericType( ObjectType ), listAdapter_NotNullable ) ;

				//-------------
				// struct?

				Type nullableObjectType = typeof( Nullable<> ).MakeGenericType( ObjectType ) ;

				var adapter = ( IAdapter )( new InternalObjectAdapter( this ) ) ;
//				var adapter = ( IAdapter )Activator.CreateInstance( typeof( InternalObjectAdapter<> ).MakeGenericType( nullableObjectType ), this ) ;
				AddToInternalAdapterCache( nullableObjectType, adapter ) ;

				// アレイ(１次元)
				var arrayAdapter = ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( nullableObjectType ) ) ;
				AddToInternalAdapterCache( nullableObjectType.MakeArrayType(), arrayAdapter ) ;

				// リスト
				var listAdapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( nullableObjectType ) ) ;
				AddToInternalAdapterCache( typeof( List<> ).MakeGenericType( nullableObjectType ), listAdapter ) ;
			}
		}
	}

	//--------------------------------------------------------------------------------------------

}
