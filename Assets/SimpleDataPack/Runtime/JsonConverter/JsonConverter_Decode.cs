using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// Ｊｓｏｎ変換
	/// </summary>
	partial class JsonConverter
	{
		/// <summary>
		/// データパックをＪｓｏｎに変換する
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public System.Object Decode( Type type, ReadOnlySpan<byte> data )
		{
			if( data == null )
			{
				return null ;
			}

			//----------------------------------

			// マルチスレッドに対応するためメソッドごとにインスタンスを別にする
			var json = new JsonParser( data ) ;

			if( json.IsNull() == true )
			{
				// null
				return null ;
			}

			//----------------------------------

			Type objectType = type ;

			bool isNullable = false ;
			if( objectType.IsGenericType == true && objectType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				// Nullable
				isNullable = true ;

				objectType = Nullable.GetUnderlyingType( objectType ) ;
			}

			//----------------------------------------------------------

			if
			(
				(
					( objectType.IsEnum == true ) ||	// Enum
					( objectType.IsClass == false && objectType.IsValueType == true && objectType.IsPrimitive == true  ) ||	// Primitive
					objectType == typeof( System.String ) ||
					objectType == typeof( System.Decimal ) || objectType == typeof( System.DateTime )
				) == false	// プリミティブではない(= Aray List Dictionary class struct)
			)
			{
				// 問題があれば例外が発生する(プリミティブ型は許可しない)
				m_ObjectDefinitionCache.Add( type, true ) ;
			}

			//----------------------------------------------------------

			// 実際の値を取得する
			return GetAllObjects( objectType, isNullable, json ) ;
		}

		//-------------------------------------------------------------------------------------------

		// 全てのオブジェクトを取得する
		private System.Object GetAllObjects( Type objectType, bool isNullable, JsonParser json )
		{
			System.Object entity = null ;

			if( objectType.IsArray == true )
			{
				// アレイ型
				entity = GetArray( objectType, json ) ;
			}
			else
			if( objectType.IsGenericType == true )
			{
				// ジェネリック

				if( objectType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// リスト型
					entity = GetList( objectType, json ) ;
				}
				else
				if( objectType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// ディクショナリ型
					entity = GetDictionary( objectType, json ) ;
				}
				else
				{
					// その他のジェネリックは許容していない
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}
			else
			{
				if
				(
					(
						// class
						objectType.IsClass == true  &&
						objectType != typeof( System.String )		// 除外
					)
					||
					(
						// struct
						objectType.IsClass == false &&
						objectType.IsValueType == true &&
						objectType.IsPrimitive == false &&
						objectType.IsEnum == false &&
						objectType != typeof( System.Decimal ) &&	// 除外
						objectType != typeof( System.DateTime )	// 除外
					)
				)
				{
					// オブジェクト(class または struct ※メンバーが存在するもの)
					entity = GetObject( objectType, isNullable, json ) ;
				}
				else
				{
					// プリミティブ(トップレベルからの直接呼び出しでないとここには来ない)
					if( isNullable == true || objectType.IsClass == true )	// IsClass チェックは String 用
					{
						// null がありえる
						if( json.IsNull() == true )
						{
							// null
							return null ;
						}
					}

					//--------------------------------

					TypeCode typeCode = Type.GetTypeCode( objectType ) ;

					if( objectType.IsEnum == true )
					{
						// Enum
						entity = System.Enum.Parse( objectType, json.GetString() ) ;
					}
					else
					{
						switch( typeCode )
						{
							case TypeCode.Boolean	: entity = json.GetBoolean()	; break ;
							case TypeCode.Byte		: entity = json.GetByte()		; break ;
							case TypeCode.SByte		: entity = json.GetSByte()		; break ;
							case TypeCode.Char		: entity = json.GetChar()		; break ;
							case TypeCode.Int16		: entity = json.GetInt16()		; break ;
							case TypeCode.UInt16	: entity = json.GetUInt16()		; break ;
							case TypeCode.Int32		: entity = json.GetInt32()		; break ;
							case TypeCode.UInt32	: entity = json.GetUInt32()		; break ;
							case TypeCode.Int64		: entity = json.GetInt64()		; break ;
							case TypeCode.UInt64	: entity = json.GetUInt64()		; break ;
							case TypeCode.Single	: entity = json.GetSingle()		; break ;
							case TypeCode.Double	: entity = json.GetDouble()		; break ;
							case TypeCode.Decimal	: entity = json.GetDecimal()	; break ;	// struct
							case TypeCode.String	: entity = json.GetString()		; break ;	// class 
							case TypeCode.DateTime	: entity = json.GetDateTime()	; break ;	// struct
						}
					}
				}
			}

			return entity ;
		}

		//-------------------------------------------------------------------------------------------

		// アレイを取得する
		private System.Object GetArray( Type objectType, JsonParser json )
		{
			if( json.IsNull() == true )
			{
				// null
				return null ;
			}

			//----------------------------------
			// 各次元の要素数がわからないので解析する

			int maxRank = objectType.GetArrayRank() ;	// 最大次元数
			
			char c ;
			int rank ;

			// 各次元の要素数
			List<int> lengths = new List<int>() ;
			List<int> classes = new List<int>() ;

			// objectType は Array 型である事に注意
			var elementType = objectType.GetElementType() ;

			// 次元数・要素数がわからないので一時的に格納をリストを生成する(１次元)
			var listType = typeof( List<> ).MakeGenericType( elementType ) ;
			var list = ( IList )Activator.CreateInstance( listType ) ;

			// Nullable の場合は内部の型を取得する
			var primitiveType = elementType ;

			// 要素の Nullable 確認
			bool isPrimitiveNullable = false ;
			if( primitiveType.IsGenericType == true && primitiveType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				isPrimitiveNullable = true ;
				primitiveType = Nullable.GetUnderlyingType( primitiveType ) ;
			}

			// 要素取得用のコールバックを取得する
			Func<Type,bool,JsonParser,System.Object> GetArrayValue = GetCallback( primitiveType, isPrimitiveNullable ) ;

			//----------------------------------------------------------

			c = json.GetCode() ;
			if( c != '[' )
			{
				// 異常
				throw new Exception( "message:Invalid json text." ) ;
			}

			// ０次元の要素数
			rank = 0 ;
			lengths.Add( 0 ) ;	// 要素数
			classes.Add( 0 ) ;	// 種別(初期化)

			// １次元分の情報を取得するメソッド定義(再帰的に使用する)
			void GetDimension()
			{
				for( ; ; )
				{
					c = json.GetCode( false ) ;	// オフセットが増加しない事に注意
					if( c == ']' )
					{
						// 終了
						json.Increase() ;
						break ;
					}
					else
					if( c == ',' )
					{
						if( lengths[ rank ] == 0 )
						{
							// 異常(要素の前に出現)
							throw new Exception( "message:Invalid json text." ) ;
						}

						json.Increase() ;

						//-----------

						c = json.GetCode( false ) ;	// オフセットが増加しない事に注意

						if( c == ']' )
						{
							// 終了(最後の要素も , が付いていた場合の対策)
							json.Increase() ;
							break ;
						}
					}

					if( c == '[' && ( rank <  ( maxRank - 1 ) ) )	// 最大次元数で制限がかかる事に注意する
					{
						// 次の次元へ
						json.Increase() ;

						//-----------

						if( classes[ rank ] == 0 )
						{
							classes[ rank ]  = 1 ;
						}
						else
						if( classes[ rank ] != 1 )
						{
							// 値が配列が設定されようとした
							throw new Exception( "message:Invalid json text." ) ;
						}

						//-----------

						// 次元を上げる
						rank ++ ;

						if( lengths.Count <  ( rank + 1 ) )
						{
							// 新規の次元なので次元を追加する
							lengths.Add( 0 ) ;	// 要素数
							classes.Add( 0 ) ;	// 種別(初期化)
						}
						else
						{
							// 既存の次元なので要素数を初期化する
							lengths[ rank ] = 0 ;
						}

						// 再帰的に次の次元を取得する
						GetDimension() ;

						// 次元を下げる
						rank -- ;

						// 現在の次元の要素数増加
						lengths[ rank ] ++ ;
					}
					else
					{
						if( classes[ rank ] == 0 )
						{
							classes[ rank ]  = 2 ;
						}
						else
						if( classes[ rank ] != 2 )
						{
							// 配列に値が設定されようとした
							throw new Exception( "message:Invalid json text." ) ;
						}

						//-----------

						// 流石にこのループを全展開するとコードが多すぎるので typeCode に応じたコールバックで対処する
						list.Add( GetArrayValue( primitiveType, isPrimitiveNullable, json ) ) ;

						// 現在の次元の要素数増加
						lengths[ rank ] ++ ;
					}
				}
			}

			// １次元分の情報を取得する
			GetDimension() ;

			//----------------------------------------------------------

			// ランク数
			rank = lengths.Count ;

			//----------------------------------

			// 次元に応じたアレイを生成して値を格納する

			// アレイを生成する
			var elements = Array.CreateInstance( elementType, lengths.ToArray() ) ;

			if( list.Count == 0 )
			{
				// 要素は無し
				return elements ;
			}

			//--------------

			if( rank == 1 )
			{
				// １次元の場合は高速処理
				list.CopyTo( elements, 0 ) ;
			}
			else
			{
				// ２次元以上はきちんと処理する

				int[] indices = new int[ rank ] ;
				int d, r = rank - 1 ;

				// インデックスを増加させる
				void Increase()
				{
					int u = 1 ;

					for( d  = r ; d >  0 ; d -- )
					{
						indices[ d ] += u ;

						u = indices[ d ] / lengths[ d ] ;
						indices[ d ] %= lengths[ d ] ;
					}
					indices[ d ] += u ;
				}

				int i, l = list.Count ;
				for( i  = 0 ; i <  l ; i ++ )
				{
					elements.SetValue( list[ i ], indices ) ;
					Increase() ;
				}
			}

			return elements ;
		}

		// アレイを取得する
		private System.Object GetList( Type objectType, JsonParser json )
		{
			if( json.IsNull() == true )
			{
				// null
				return null ;
			}

			//----------------------------------

			// 次元数・要素数がわからないので解析する

			char c ;

			// objectType は List 型である事に注意
			var types = objectType.GenericTypeArguments ;
			if( types == null || types.Length != 1 )
			{
				// 複数のジェネリックの場合はスルーされる
				throw new Exception( message:"Only one argument of list type is valid." ) ;
			}

			var elementType = types[ 0 ] ;

			// 次元数・要素数がわからないので一時的に格納をリストを生成する(１次元)
			var listType = typeof( List<> ).MakeGenericType( elementType ) ;
			var elements = ( IList )Activator.CreateInstance( listType ) ;

			// Nullable の場合は内部の型を取得する
			var primitiveType = elementType ;

			// 要素の Nullable 確認
			bool isPrimitiveNullable = false ;
			if( primitiveType.IsGenericType == true && primitiveType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				isPrimitiveNullable = true ;
				primitiveType = Nullable.GetUnderlyingType( primitiveType ) ;
			}

			// 要素取得用のコールバックを取得する
			Func<Type,bool,JsonParser,System.Object> GetListValue = GetCallback( primitiveType, isPrimitiveNullable ) ;

			//----------------------------------------------------------

			c = json.GetCode() ;
			if( c != '[' )
			{
				// 異常
				throw new Exception( "message:Invalid json text." ) ;
			}

			for( ; ; )
			{
				c = json.GetCode( false ) ;	// オフセットが増加しない事に注意
				if( c == ']' )
				{
					// 終了
					json.Increase() ;
					break ;
				}
				else
				if( c == ',' )
				{
					if( elements.Count == 0 )
					{
						// 異常(要素の前に出現)
						throw new Exception( "message:Invalid json text." ) ;
					}

					json.Increase() ;

					//-----------

					c = json.GetCode( false ) ;	// オフセットが増加しない事に注意

					if( c == ']' )
					{
						// 終了(最後の要素も , が付いていた場合の対策)
						json.Increase() ;
						break ;
					}
				}

				// 要素を取得する
				elements.Add( GetListValue( primitiveType, isPrimitiveNullable, json ) ) ;
			}

			return elements ;
		}

		// ディクショナリを取得する
		private System.Object GetDictionary( Type objectType, JsonParser json )
		{
			if( json.IsNull() == true )
			{
				// null
				return null ;
			}

			//----------------------------------

			// 次元数・要素数がわからないので解析する

			char c ;

			// objectType は Dictionary 型である事に注意
			var types = objectType.GenericTypeArguments ;
			if( types == null || types.Length != 2 )
			{
				// 複数のジェネリックの場合はスルーされる
				throw new Exception( message:"Only two argument of dictionary type is valid." ) ;
			}

			var keyType		= types[ 0 ] ;
			var valueType	= types[ 1 ] ;

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

			// ディクショナリを生成する
			var dictionaryType = typeof( Dictionary<,> ).MakeGenericType( keyType, valueType ) ;
			var elements = ( IDictionary )Activator.CreateInstance( dictionaryType ) ;


			// キー取得用のコールバックを取得する
			Func<Type,bool,JsonParser,System.Object> GetKey = GetCallback( keyType, false ) ;

			// バリュー取得用のコールバックを取得する
			Func<Type,bool,JsonParser,System.Object> GetValue = GetCallback( valueType, isValueNullable ) ;

			//----------------------------------------------------------

			c = json.GetCode() ;
			if( c != '[' )
			{
				// 異常
				throw new Exception( "message:Invalid json text." ) ;
			}

			for( ; ; )
			{
				c = json.GetCode( false ) ;	// オフセットが増加しない事に注意
				if( c == ']' )
				{
					// 終了
					json.Increase() ;
					break ;
				}
				else
				if( c == ',' )
				{
					if( elements.Count == 0 )
					{
						// 異常(要素の前に出現)
						throw new Exception( "message:Invalid json text." ) ;
					}

					json.Increase() ;

					//------------

					c = json.GetCode( false ) ;	// オフセットが増加しない事に注意

					if( c == ']' )
					{
						// 終了(最後の要素も , が付いていた場合の対策)
						json.Increase() ;
						break ;
					}
				}

				if( c == '[' )
				{
					json.Increase() ;

					// キーを取得する
					var key		= GetKey( keyType, false, json ) ;

					c = json.GetCode() ;
					if( c != ',' )
					{
						throw new Exception( "message:Invalid json text." ) ;
					}

					// バリューを取得する
					var value	= GetValue( valueType, isValueNullable, json ) ;

					c = json.GetCode() ;
					if( c != ']' )
					{
						throw new Exception( "message:Invalid json text." ) ;
					}

					elements.Add( key, value ) ;
				}
				else
				{
					// 異常
					throw new Exception( "message:Invalid json text." ) ;
				}
			}

			return elements ;
		}

		// オブジェクト(class struct)を取得する
		private System.Object GetObject( Type objectType, bool isNullable, JsonParser json )
		{
			if( isNullable == true || objectType.IsClass == true )
			{
				// null がありえる

				if( json.IsNull() == true )
				{
					// null
					return null ;
				}
			}

			//---------------------------------------------

			char c ;

			c = json.GetCode() ;
			if( c != '{' )
			{
				// 取得不可
				throw new Exception( "message:Invalid json text." ) ;
			}

			//----------------------------------

			// 実体(オブジェクト)を生成する
			System.Object entity = Activator.CreateInstance( objectType ) ;

			// クラス型に該当するクラス定義を取得する
			var objectDefinition = m_ObjectDefinitionCache[ objectType ] ;

			//-----------------------------------------------------------

			int mi, ml = objectDefinition.Members.Length ;

			for( mi  = 0 ; mi <  ml ; mi ++)
			{
				var member = objectDefinition.Members[ mi ] ;

				// 名前が一致するか確認する
				if( member.Name != json.GetTokenName() )
				{
					// メンバー名が一致しない
					throw new Exception( "message:Invalid json text." ) ;
				}

//				Debug.Log( "MemberName:" + member.Name ) ; 
				//---------------------------------------------------------

				System.Object value = null ;

				switch( member.ValueType )
				{
					// PutAllObjects の呼び出し(内部の型判定)を省略する
					case ValueTypes.Array		: value = GetArray( member.ObjectType, json )						; break ;
					case ValueTypes.List		: value = GetList( member.ObjectType, json )						; break ;
					case ValueTypes.Dictionary	: value = GetDictionary( member.ObjectType, json )					; break ;
					case ValueTypes.Object		: value = GetObject( member.ObjectType,member.IsNullable, json )	; break ;

					// 以下はプリミティブ
					case ValueTypes.Enum :
						if( member.IsNullable == false )
						{
							value = System.Enum.Parse( member.ObjectType, json.GetString() ) ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = System.Enum.Parse( member.ObjectType, json.GetString() ) ;
							}
						}
					break ;
					case ValueTypes.Boolean :
						if( member.IsNullable == false )
						{
							value = json.GetBoolean() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetBoolean() ;
							}
						}
					break ;
					case ValueTypes.Byte :
						if( member.IsNullable == false )
						{
							value = json.GetByte() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetByte() ;
							}
						}
					break ;
					case ValueTypes.SByte :
						if( member.IsNullable == false )
						{
							value = json.GetSByte() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetSByte() ;
							}
						}
					break ;
					case ValueTypes.Char :
						if( member.IsNullable == false )
						{
							value = json.GetChar() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetChar() ;
							}
						}
					break ;
					case ValueTypes.Int16 :
						if( member.IsNullable == false )
						{
							value = json.GetInt16() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetInt16() ;
							}
						}
					break ;
					case ValueTypes.UInt16 :
						if( member.IsNullable == false )
						{
							value = json.GetUInt16() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetUInt16() ;
							}
						}
					break ;
					case ValueTypes.Int32 :
						if( member.IsNullable == false )
						{
							value = json.GetInt32() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetInt32() ;
							}
						}
					break ;
					case ValueTypes.UInt32 :
						if( member.IsNullable == false )
						{
							value = json.GetUInt32() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetUInt32() ;
							}
						}
					break ;
					case ValueTypes.Int64 :
						if( member.IsNullable == false )
						{
							value = json.GetInt64() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetInt64() ;
							}
						}
					break ;
					case ValueTypes.UInt64 :
						if( member.IsNullable == false )
						{
							value = json.GetUInt64() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetUInt64() ;
							}
						}
					break ;
					case ValueTypes.Single :
						if( member.IsNullable == false )
						{
							value = json.GetSingle() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetSingle() ;
							}
						}
					break ;
					case ValueTypes.Double :
						if( member.IsNullable == false )
						{
							value = json.GetDouble() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetDouble() ;
							}
						}
					break ;
					case ValueTypes.Decimal :
						if( member.IsNullable == false )
						{
							value = json.GetDecimal() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetDecimal() ;
							}
						}
					break ;
					case ValueTypes.String :
						if( json.IsNull() == false )
						{
							value = json.GetString() ;
						}
					break ;
					case ValueTypes.DateTime :
						if( member.IsNullable == false )
						{
							value = json.GetDateTime() ;
						}
						else
						{
							if( json.IsNull() == false )
							{
								value = json.GetDateTime() ;
							}
						}
					break ;
				}

				//---------------------------------------------------------

				if( member.Field != null )
				{
					// フィールド
					member.Field.SetValue( entity, value ) ;
				}
				else
				{
					// プロパティ
					member.Property.SetValue( entity, value ) ;
				}

				//---------------------------------------------------------

				if( mi <  ( ml - 1 ) )
				{
					c = json.GetCode() ;
					if( c != ',' )
					{
						throw new Exception( "message:Invalid json text." ) ;
					}
				}
			}

			//------------------------------------------------------------------------------------------

			c = json.GetCode() ;
			if( c != '}' )
			{
				// 取得不可
				throw new Exception( "message:Invalid json text." ) ;
			}

			return entity ;
		}

		//-------------------------------------------------------------------------------------------

		private Func<Type,bool,JsonParser,System.Object> GetCallback( Type primitiveType, bool isPrimitiveNullable )
		{
			Func<Type,bool,JsonParser,System.Object> getArrayValue = null ;

			// 要素がプリミティブに分類される場合は高速処理を行う
			if
			(
				( primitiveType.IsEnum == true ) ||	// Enum
				( primitiveType.IsClass == false && primitiveType.IsValueType == true && primitiveType.IsPrimitive == true  ) ||	// Primitive
				primitiveType == typeof( System.String ) ||
				primitiveType == typeof( System.Decimal ) || primitiveType == typeof( System.DateTime )
			)
			{
				var typeCode = Type.GetTypeCode( primitiveType ) ;

				if( primitiveType.IsEnum == true )
				{
					if( isPrimitiveNullable == false )
					{
						getArrayValue = ( _1, _2, _3 ) =>
						{
							string s = _3.GetString() ;
							return System.Enum.Parse( primitiveType, s ) ;
						} ;
					}
					else
					{
						getArrayValue = ( _1, _2, _3 ) =>
						{
							if( _3.IsNull() == true ){ return null ; }else
							{
								return System.Enum.Parse( primitiveType, _3.GetString() ) ;
							}
						} ;
					}
				}
				else
				{
					switch( typeCode )
					{
						case TypeCode.Boolean :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetBoolean() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetBoolean() ;
									}
								} ;
							}
						break ;
						case TypeCode.Byte :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetByte() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetByte() ;
									}
								} ;
							}
						break ;
						case TypeCode.SByte :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetSByte() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetSByte() ;
									}
								} ;
							}
						break ;
						case TypeCode.Char :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetChar() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetChar() ;
									}
								} ;
							}
						break ;
						case TypeCode.Int16 :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetInt16() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetInt16() ;
									}
								} ;
							}
						break ;
						case TypeCode.UInt16 :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetUInt16() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetUInt16() ;
									}
								} ;
							}
						break ;
						case TypeCode.Int32 :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetInt32() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetInt32() ;
									}
								} ;
							}
						break ;
						case TypeCode.UInt32 :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetUInt32() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetUInt32() ;
									}
								} ;
							}
						break ;
						case TypeCode.Int64 :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetInt64() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetInt64() ;
									}
								} ;
							}
						break ;
						case TypeCode.UInt64 :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetUInt64() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetUInt64() ;
									}
								} ;
							}
						break ;
						case TypeCode.Single :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetSingle() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetSingle() ;
									}
								} ;
							}
						break ;
						case TypeCode.Double :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetDouble() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetDouble() ;
									}
								} ;
							}
						break ;
						case TypeCode.Decimal :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetDecimal() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetDecimal() ;
									}
								} ;
							}
						break ;
						case TypeCode.String :
							getArrayValue = ( _1, _2, _3 ) =>
							{
								if( _3.IsNull() == true ){ return null ; }else
								{
									return _3.GetString() ;
								}
							} ;
						break ;
						case TypeCode.DateTime :
							if( isPrimitiveNullable == false )
							{
								getArrayValue = ( _1, _2, _3 ) =>{ return _3.GetDateTime() ; }	;
							}
							else
							{
								getArrayValue = ( _1, _2, _3 ) =>
								{
									if( _3.IsNull() == true ){ return null ; }else
									{
										return _3.GetDateTime() ;
									}
								} ;
							}
						break ;
					}
				}
			}
			else
			{
				// タイプは Array List Dictionary class struct のケース / Nullable は問わない
				getArrayValue = ( _1, _2, _3  ) => GetAllObjects( _1, _2, _3 ) ;
			}

			return getArrayValue ;
		}
	}
}

