using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Text ;
using System.Reflection ;

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
		public byte[] Encode( System.Object entity, bool prettyPrint )
		{
			// マルチスレッドに対応するためインスタンスの共有はしない
			ExStringBuilder json = new ExStringBuilder() ;

			if( entity == null )
			{
				json += "null" ;
			}
			else
			{
				Type objectType = entity.GetType() ;

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
					// 問題があれば例外が発生する
					m_ObjectDefinitionCache.Add( objectType, true ) ;
				}

				string indent = "\n" ;

				// 実際の値を格納する
				PutAllObjects( objectType, isNullable, entity, ref json, ref indent, prettyPrint ) ;
			}

			return Encoding.UTF8.GetBytes( json.ToString() ) ;
		}

		//-------------------------------------------------------------------------------------------

		// 全ての値を格納する
		private void PutAllObjects( Type objectType, bool isNullable, System.Object entity, ref ExStringBuilder json, ref string indent, bool prettyPrint )
		{
			if( objectType.IsArray == true )
			{
				// アレイ型
				PutArray( objectType, entity, ref json, ref indent, prettyPrint ) ;
			}
			else
			if( objectType.IsGenericType == true )
			{
				// ジェネリック

				if( objectType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// リスト型
					PutList( objectType, entity, ref json, ref indent, prettyPrint ) ;
				}
				else
				if( objectType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// ディクショナリ型
					PutDictionary( objectType, entity, ref json, ref indent, prettyPrint ) ;
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
					PutObject( objectType, isNullable, entity, ref json, indent, prettyPrint ) ;
				}
				else
				{
					// プリミティブ(トップレベルからの直接呼び出しでないとここには来ない)
					// entity が null である事は無い

					TypeCode typeCode = Type.GetTypeCode( objectType ) ;

					if( objectType.IsEnum == true )
					{
						// Enum
						json += "\"" + entity.ToString() + "\"" ;
					}
					else
					{
						switch( typeCode )
						{
							case TypeCode.Boolean :
								json += entity.ToString().ToLower() ;
							break ;
							case TypeCode.Char :
								json += ( ( System.UInt16 )( ( System.Char )entity ) ).ToString() ;
							break ;
							case TypeCode.Byte :
							case TypeCode.SByte :
							case TypeCode.Int16 :
							case TypeCode.UInt16 :
							case TypeCode.Int32 :
							case TypeCode.UInt32 :
							case TypeCode.Int64 :
							case TypeCode.UInt64 :
							case TypeCode.Single :
							case TypeCode.Double :
							case TypeCode.Decimal :
								json += entity.ToString() ;
							break ;
							case TypeCode.String :
								json += "\"" + EncodeTextEscape( entity.ToString(), json.Escape ) + "\"" ;
							break ;	// class 
							case TypeCode.DateTime :
								json += "\"" + EncodeTextEscape( ( ( System.DateTime )entity ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;
							break ;	// struct
						}
					}
				}
			}
		}

		// アレイを出力する
		private void PutArray( Type objectType, System.Object entity, ref ExStringBuilder json, ref string indent, bool prettyPrint )
		{
			if( entity == null )
			{
				json += "null" ;
				return ;
			}

			//----------------------------------

			Array elements = entity as Array ;

			// 次元数を格納する
			int rank = elements.Rank ;
			if( rank == 0 )
			{
				// 基本的にありえないが終了
				json += "null" ;
				return ;
			}

			// 各次元の要素数を取得(格納)する　最初の方が高次元
			int[] lengths = new int[ rank ] ;
			int d, i, l = elements.Length ;
			for( d  = 0 ; d <  rank ; d ++ )
			{
				lengths[ d ] = elements.GetLength( d ) ;
			}

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( l == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				json += "[]" ;
				return ;
			}

			// objectType は Array 型である事に注意
			var elementType = objectType.GetElementType() ;

			//----------------------------------

			var primitiveType = elementType ;

			// 要素の Nullable 確認
			bool isPrimitiveNullable = false ;
			if( primitiveType.IsGenericType == true && primitiveType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				isPrimitiveNullable = true ;
				primitiveType = Nullable.GetUnderlyingType( primitiveType ) ;
			}

			//----------------------------------------------------------

			if( rank == 1 )
			{
				// １次元の場合は高速処理を行う
				
				json += "[" ;
				indent += "\t" ;

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
							for( i  = 0 ; i <  l ; i ++ )
							{
								if( prettyPrint == true ){ json += indent ; }

								json += "\"" + elements.GetValue( i ).ToString() + "\"" ;

								if( i <  ( l - 1 ) ){ json += "," ; }
							}
						}
						else
						{
							for( i  = 0 ; i <  l ; i ++ )
							{
								if( prettyPrint == true ){ json += indent ; }

								if( elements.GetValue( i ) == null )
								{
									json += "null" ;
								}
								else
								{
									json += "\"" + elements.GetValue( i ).ToString() + "\"" ;
								}

								if( i <  ( l - 1 ) ){ json += "," ; }
							}
						}
					}
					else
					{
						switch( typeCode )
						{
							case TypeCode.Boolean :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										json += elements.GetValue( i ).ToString().ToLower() ;
										
										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( i ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += elements.GetValue( i ).ToString().ToLower() ;
										}

										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
							break ;
							case TypeCode.Char :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										json += ( ( System.UInt16 )( ( System.Char )elements.GetValue( i ) ) ).ToString() ;
										
										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( i ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += ( ( System.UInt16 )( ( System.Char )elements.GetValue( i ) ) ).ToString() ;
										}

										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
							break ;
							case TypeCode.Byte :
							case TypeCode.SByte :
							case TypeCode.Int16 :
							case TypeCode.UInt16 :
							case TypeCode.Int32 :
							case TypeCode.UInt32 :
							case TypeCode.Int64 :
							case TypeCode.UInt64 :
							case TypeCode.Single :
							case TypeCode.Double :
							case TypeCode.Decimal :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										json += elements.GetValue( i ).ToString() ;
										
										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( i ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += elements.GetValue( i ).ToString() ;
										}

										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
							break ;
							case TypeCode.String :
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									if( elements.GetValue( i ) == null )
									{
										json += "null" ;
									}
									else
									{
										json += "\"" + EncodeTextEscape( elements.GetValue( i ).ToString(), json.Escape ) + "\"" ;
									}

									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							break ;
							case TypeCode.DateTime :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										json += "\"" + EncodeTextEscape( ( ( System.DateTime )elements.GetValue( i ) ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;

										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( i ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += "\"" + EncodeTextEscape( ( ( System.DateTime )elements.GetValue( i ) ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;
										}

										if( i <  ( l - 1 ) ){ json += "," ; }
									}
								}
							break ;
						}
					}
				}
				else
				{
					// プリミティブではない(Array List Dictionary class struct)
					for( i  = 0 ; i <  l ; i ++ )
					{
						if( prettyPrint == true ){ json += indent ; }

						PutAllObjects( primitiveType, isPrimitiveNullable, elements.GetValue( i ), ref json, ref indent, prettyPrint ) ;

						if( i <  ( l - 1 ) ){ json += "," ; }
					}
				}

				indent = indent.Substring( 0, indent.Length - 1 ) ;	// \n や \t に対しての TrimEnd() は正しく動作しない
				if( prettyPrint == true ){ json += indent ; }
				json += "]" ;
			}
			else
			{
				// ２次元以上

				int[] indices = new int[ rank ] ;
				int r = rank - 1 ;

				void CheckHead( ref ExStringBuilder json, ref string indent )
				{
					for( d  = r ; d >= 0 ; d -- )
					{
						if( indices[ d ] == 0 )
						{
							// 最初
							if( d <  r )
							{
								json += indent ;
							}

							json +=	"[" ;
							indent += "\t" ;
						}
						else
						{
							break ;
						}
					}
				}

				void CheckTail( ref ExStringBuilder json, ref string indent )
				{
					for( d  = r ; d >= 0 ; d -- )
					{
						if( indices[ d ] == ( lengths[ d ] - 1 ) )
						{
							// 最後
							indent = indent.Substring( 0, indent.Length - 1 ) ;	// \n や \t に対しての TrimEnd() は正しく動作しない
							if( prettyPrint == true ){ json += indent ; }
							json += "]" ;

							if( d >  0 )
							{
								if( indices[ d - 1 ] <  ( lengths[ d - 1 ] - 1 ) )
								{
									json += "," ;
									if( prettyPrint == true ){ json += indent ; }
								}
							}
						}
						else
						{
							if( d == r )
							{
								json += "," ;
							}
							break ;
						}
					}
				}

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

				//---------------------------------

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

					// null 許容でない
					if( primitiveType.IsEnum == true )
					{
						if( isPrimitiveNullable == false )
						{
							for( i  = 0 ; i <  l ; i ++ )
							{
								CheckHead( ref json, ref indent ) ;
								if( prettyPrint == true ){ json += indent ; }

								json += "\"" + elements.GetValue( indices ).ToString() + "\"" ;

//								if( i <  ( l - 1 ) ){ json += "," ; }
								CheckTail( ref json, ref indent ) ;
								Increase() ;
							}
						}
						else
						{
							for( i  = 0 ; i <  l ; i ++ )
							{
								CheckHead( ref json, ref indent ) ;
								if( prettyPrint == true ){ json += indent ; }

								if( elements.GetValue( indices ) == null )
								{
									json += "null" ;
								}
								else
								{
									json += "\"" + elements.GetValue( indices ).ToString() + "\"" ;
								}

//								if( i <  ( l - 1 ) ){ json += "," ; }
								CheckTail( ref json, ref indent ) ;
								Increase() ;
							}
						}
					}
					else
					{
						switch( typeCode )
						{
							case TypeCode.Boolean :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										json += elements.GetValue( indices ).ToString().ToLower() ;
										
//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( indices ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += elements.GetValue( indices ).ToString().ToLower() ;
										}

//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
							break ;
							case TypeCode.Char :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										json += ( ( System.UInt16 )( ( System.Char )elements.GetValue( indices ) ) ).ToString() ;
										
//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( indices ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += ( ( System.UInt16 )( ( System.Char )elements.GetValue( indices ) ) ).ToString() ;
										}

//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
							break ;
							case TypeCode.Byte :
							case TypeCode.SByte :
							case TypeCode.Int16 :
							case TypeCode.UInt16 :
							case TypeCode.Int32 :
							case TypeCode.UInt32 :
							case TypeCode.Int64 :
							case TypeCode.UInt64 :
							case TypeCode.Single :
							case TypeCode.Double :
							case TypeCode.Decimal :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										json += elements.GetValue( indices ).ToString() ;
										
//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( indices ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += elements.GetValue( indices ).ToString() ;
										}

//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
							break ;
							case TypeCode.String :
								for( i  = 0 ; i <  l ; i ++ )
								{
									CheckHead( ref json, ref indent ) ;
									if( prettyPrint == true ){ json += indent ; }

									if( elements.GetValue( indices ) == null )
									{
										json += "null" ;
									}
									else
									{
										json += "\"" + EncodeTextEscape( elements.GetValue( indices ).ToString(), json.Escape ) + "\"" ;
									}

//									if( i <  ( l - 1 ) ){ json += "," ; }
									CheckTail( ref json, ref indent ) ;
									Increase() ;
								}
							break ;
							case TypeCode.DateTime :
								if( isPrimitiveNullable == false )
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										json += "\"" + EncodeTextEscape( ( ( System.DateTime )elements.GetValue( indices ) ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;

//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
								else
								{
									for( i  = 0 ; i <  l ; i ++ )
									{
										CheckHead( ref json, ref indent ) ;
										if( prettyPrint == true ){ json += indent ; }

										if( elements.GetValue( indices ) == null )
										{
											json += "null" ;
										}
										else
										{
											json += "\"" + EncodeTextEscape( ( ( System.DateTime )elements.GetValue( indices ) ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;
										}

//										if( i <  ( l - 1 ) ){ json += "," ; }
										CheckTail( ref json, ref indent ) ;
										Increase() ;
									}
								}
							break ;
						}
					}
				}
				else
				{
					// プリミティブではない(Array List Dictionary class struct)
					for( i  = 0 ; i <  l ; i ++ )
					{
						CheckHead( ref json, ref indent ) ;
						if( prettyPrint == true ){ json += indent ; }

						PutAllObjects( primitiveType, isPrimitiveNullable, elements.GetValue( indices ), ref json, ref indent, prettyPrint ) ;

//						if( i <  ( l - 1 ) ){ json += "," ; }
						CheckTail( ref json, ref indent ) ;
						Increase() ;
					}
				}
			}
		}

		// リストを出力する
		private void PutList( Type objectType, System.Object entity, ref ExStringBuilder json, ref string indent, bool prettyPrint )
		{
			if( entity == null )
			{
				// null 件要素数を 0 で終了
				json += "null" ;
				return ;
			}

			//----------------------------------

			IList elements = entity as IList ;

			int i, l = elements.Count ;

			// 要素数を格納する(0もある)
			if( l == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				json += "[]" ;	// null ではない
				return ;
			}

			//--------------

			// objectType は List 型である事に注意
			var types = objectType.GenericTypeArguments ;
			if( types == null || types.Length != 1 )
			{
				// 複数のジェネリックの場合はスルーされる
				throw new Exception( message:"Only one argument of list type is valid." ) ;
			}

			var elementType = types[ 0 ] ;

			//----------------------------------

			var primitiveType = elementType ;

			// Nullable 確認
			bool isPrimitiveNullable = false ;
			if( primitiveType.IsGenericType == true && primitiveType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				isPrimitiveNullable = true ;
				primitiveType = Nullable.GetUnderlyingType( primitiveType ) ;
			}

			json += "[" ;
			indent += "\t" ;

			// プリミティブに分類される場合は高速処理を行う
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
						for( i  = 0 ; i <  l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }

							json += "\"" + elements[ i ].ToString() + "\"" ;

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					}
					else
					{
						for( i  = 0 ; i <  l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }

							if( elements[ i ] == null )
							{
								json += "null" ;
							}
							else
							{
								json += "\"" + elements[ i ].ToString() + "\"" ;
							}

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					}
				}
				else
				{
					switch( typeCode )
					{
						case TypeCode.Boolean :
							if( isPrimitiveNullable == false )
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									json += elements[ i ].ToString().ToLower() ;
										
									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
							else
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									if( elements[ i ] == null )
									{
										json += "null" ;
									}
									else
									{
										json += elements[ i ].ToString().ToLower() ;
									}

									if( i <  ( l - 1 ) ){ json += "," ; }
								}								
							}
						break ;
						case TypeCode.Char :
							if( isPrimitiveNullable == false )
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									json += ( ( System.UInt16 )( ( System.Char )elements[ i ] ) ).ToString() ;
										
									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
							else
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									if( elements[ i ] == null )
									{
										json += "null" ;
									}
									else
									{
										json += ( ( System.UInt16 )( ( System.Char )elements[ i ] ) ).ToString() ;
									}

									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
						break ;
						case TypeCode.Byte :
						case TypeCode.SByte :
						case TypeCode.Int16 :
						case TypeCode.UInt16 :
						case TypeCode.Int32 :
						case TypeCode.UInt32 :
						case TypeCode.Int64 :
						case TypeCode.UInt64 :
						case TypeCode.Single :
						case TypeCode.Double :
						case TypeCode.Decimal :
							if( isPrimitiveNullable == false )
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									json += elements[ i ].ToString() ;
										
									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
							else
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									if( elements[ i ] == null )
									{
										json += "null" ;
									}
									else
									{
										json += elements[ i ].ToString() ;
									}

									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
						break ;
						case TypeCode.String :
							for( i  = 0 ; i <  l ; i ++ )
							{
								if( prettyPrint == true ){ json += indent ; }

								if( elements[ i ] == null )
								{
									json += "null" ;
								}
								else
								{
									json += "\"" + EncodeTextEscape( elements[ i ].ToString(), json.Escape ) + "\"" ;
								}

								if( i <  ( l - 1 ) ){ json += "," ; }
							}
						break ;
						case TypeCode.DateTime :
							if( isPrimitiveNullable == false )
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									json += "\"" + EncodeTextEscape( ( ( System.DateTime )elements[ i ] ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;

									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
							else
							{
								for( i  = 0 ; i <  l ; i ++ )
								{
									if( prettyPrint == true ){ json += indent ; }

									if( elements[ i ] == null )
									{
										json += "null" ;
									}
									else
									{
										json += "\"" + EncodeTextEscape( ( ( System.DateTime )elements[ i ] ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;
									}

									if( i <  ( l - 1 ) ){ json += "," ; }
								}
							}
						break ;
					}
				}
			}
			else
			{
				// プリミティブではない(Array List Dictionary class struct)
				for( i  = 0 ; i <  l ; i ++ )
				{
					if( prettyPrint == true ){ json += indent ; }

					PutAllObjects( primitiveType, isPrimitiveNullable, elements[ i ], ref json, ref indent, prettyPrint ) ;

					if( i <  ( l - 1 ) ){ json += "," ; }
				}
			}

			indent = indent.Substring( 0, indent.Length - 1 ) ;	// \n や \t に対しての TrimEnd() は正しく動作しない
			if( prettyPrint == true ){ json += indent ; }
			json += "]" ;
		}

		// ディクショナリを出力する
		private void PutDictionary( Type objectType, System.Object entity, ref ExStringBuilder json, ref string indent, bool prettyPrint )
		{
			if( entity == null )
			{
				// null 件要素数を 0 で終了
				json += "null" ;
				return ;
			}

			//----------------------------------

			IDictionary elements = entity as IDictionary ;

			int i, l = elements.Count ;

			// 要素数を格納する(0もある)
			if( l == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				json += "[]" ;	// null ではない
				return ;
			}

			//----------------------------------

			// objectType は Dictionary 型である事に注意
			var types = objectType.GenericTypeArguments ;
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

			List<System.Object> keys	= new List<object>() ;
			List<System.Object> values	= new List<object>() ; 

			foreach( var _ in elements.Keys )
			{
				keys.Add( _ ) ;
			}
			foreach( var _ in elements.Values )
			{
				values.Add( _ ) ;
			}

			//----------------------------------
			// 格納

			json += "[" ;
			indent += "\t" ;

			TypeCode typeCode = Type.GetTypeCode( keyType ) ;

			if( keyType.IsEnum == true )
			{
				for( i  = 0 ; i < l ; i ++ )
				{
					if( prettyPrint == true ){ json += indent ; }
					json += "[" ;
					indent += "\t" ;

					if( prettyPrint == true ){ json += indent ; }
					json += "\"" + keys[ i ].ToString() + "\"" ;	// Key
					json += "," ;

					if( prettyPrint == true ){ json += indent ; }
					PutAllObjects( valueType, isValueNullable, values[ i ], ref json, ref indent, prettyPrint ) ;	// Value

					indent = indent.Substring( 0, indent.Length - 1 ) ;
					if( prettyPrint == true ){ json += indent ; }
					json += "]" ;

					if( i <  ( l - 1 ) ){ json += "," ; }
				}
			}
			else
			{
				switch( typeCode )
				{
					case TypeCode.Boolean :
						for( i  = 0 ; i < l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }
							json += "[" ;
							indent += "\t" ;

							if( prettyPrint == true ){ json += indent ; }
							json += keys[ i ].ToString().ToLower() ;	// Key
							json += "," ;

							if( prettyPrint == true ){ json += indent ; }
							PutAllObjects( valueType, isValueNullable, values[ i ], ref json, ref indent, prettyPrint ) ;	// Value

							indent = indent.Substring( 0, indent.Length - 1 ) ;
							if( prettyPrint == true ){ json += indent ; }
							json += "]" ;

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					break ;
					case TypeCode.Char :
						for( i  = 0 ; i < l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }
							json += "[" ;
							indent += "\t" ;

							if( prettyPrint == true ){ json += indent ; }
							json += ( ( System.UInt16 )( ( System.Char )keys[ i ] ) ).ToString() ;	// Key
							json += "," ;

							if( prettyPrint == true ){ json += indent ; }
							PutAllObjects( valueType, isValueNullable, values[ i ], ref json, ref indent, prettyPrint ) ;	// Value

							indent = indent.Substring( 0, indent.Length - 1 ) ;
							if( prettyPrint == true ){ json += indent ; }
							json += "]" ;

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					break ;
					case TypeCode.Byte :
					case TypeCode.SByte	:
					case TypeCode.Int16	:
					case TypeCode.UInt16 :
					case TypeCode.Int32	:
					case TypeCode.UInt32 :
					case TypeCode.Int64	:
					case TypeCode.UInt64 :
					case TypeCode.Single :
					case TypeCode.Double :
					case TypeCode.Decimal :
						for( i  = 0 ; i < l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }
							json += "[" ;
							indent += "\t" ;

							if( prettyPrint == true ){ json += indent ; }
							json += keys[ i ].ToString() ;	// Key
							json += "," ;

							if( prettyPrint == true ){ json += indent ; }
							PutAllObjects( valueType, isValueNullable, values[ i ], ref json, ref indent, prettyPrint ) ;	// Value

							indent = indent.Substring( 0, indent.Length - 1 ) ;
							if( prettyPrint == true ){ json += indent ; }
							json += "]" ;

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					break ;
					case TypeCode.String :
						for( i  = 0 ; i < l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }
							json += "[" ;
							indent += "\t" ;

							if( prettyPrint == true ){ json += indent ; }
							if( keys[ i ] == null )	// Key
							{
								json += "null" ;
							}
							else
							{
								json += "\"" + EncodeTextEscape( keys[ i ].ToString(), json.Escape ) + "\"" ;
							}
							json += "," ;

							if( prettyPrint == true ){ json += indent ; }
							PutAllObjects( valueType, isValueNullable, values[ i ], ref json, ref indent, prettyPrint ) ;	// Value

							indent = indent.Substring( 0, indent.Length - 1 ) ;
							if( prettyPrint == true ){ json += indent ; }
							json += "]" ;

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					break ;
					case TypeCode.DateTime :
						for( i  = 0 ; i < l ; i ++ )
						{
							if( prettyPrint == true ){ json += indent ; }
							json += "[" ;
							indent += "\t" ;

							if( prettyPrint == true ){ json += indent ; }
							json += "\"" + EncodeTextEscape( ( ( System.DateTime )keys[ i ] ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;	// Key
							json += "," ;

							if( prettyPrint == true ){ json += indent ; }
							PutAllObjects( valueType, isValueNullable, values[ i ], ref json, ref indent, prettyPrint ) ;	// Value

							indent = indent.Substring( 0, indent.Length - 1 ) ;
							if( prettyPrint == true ){ json += indent ; }
							json += "]" ;

							if( i <  ( l - 1 ) ){ json += "," ; }
						}
					break ;
				}
			}

			indent = indent.Substring( 0, indent.Length - 1 ) ;	// \n や \t に対しての TrimEnd() は正しく動作しない
			if( prettyPrint == true ){ json += indent ; }
			json += "]" ;
		}

		// １オブジェクト分を追加する
		private void PutObject( Type objectType, bool isNullable, System.Object entity, ref ExStringBuilder json, string indent, bool prettyPrint )
		{
			if( isNullable == true || objectType.IsClass == true )
			{
				// null がありえる

				if( entity == null )
				{
					// null
					json += "null" ;
					return ;
				}
			}

			//----------------------------------

			var objectDefinition = m_ObjectDefinitionCache[ objectType ] ;

			//----------------------------------------------------------

			int mi, ml = objectDefinition.Members.Length ;

			// 保険
			if( ml == 0 )
			{
				// このオブジェクトにメンバー定義が存在しない(基本的にここに来ることは無い)
				json += "null" ;
				return ;
			}

			//--------------

			json += "{" ;
			indent += "\t" ;

			for( mi  = 0 ; mi <  ml ; mi ++ )
			{
				if( prettyPrint == true ){ json += indent ; }

				var member = objectDefinition.Members[ mi ] ;

				// メンバーの識別は文字で行う
				json += "\"" + EncodeTextEscape( member.Name, json.Escape ) + "\":" ;

				// フィールドかプロパティか
				System.Object value ;

				if( member.Field != null )
				{
					// フィールド
					value = member.Field.GetValue( entity ) ;
				}
				else
				{
					// プロパティ
					value = member.Property.GetValue( entity ) ;
				}

				//----------------------------------

				// ここだけ少し高速に処理する

				// member.ObjectType は Nullable ではない

				switch( member.ValueType )
				{
					// PutAllObjects の呼び出し(内部の型判定)を省略する
					case ValueTypes.Array :
						if( prettyPrint == true ){ json += indent ; }
						PutArray( member.ObjectType, value, ref json, ref indent, prettyPrint ) ;
					break ;
					case ValueTypes.List :
						if( prettyPrint == true ){ json += indent ; }
						PutList( member.ObjectType, value, ref json, ref indent, prettyPrint ) ;
					break ;
					case ValueTypes.Dictionary :
						if( prettyPrint == true ){ json += indent ; }
						PutDictionary( member.ObjectType, value, ref json, ref indent, prettyPrint ) ;
					break ;
					case ValueTypes.Object :
						if( prettyPrint == true ){ json += indent ; }
						PutObject( member.ObjectType, member.IsNullable, value, ref json, indent, prettyPrint ) ;
					break ;

					// 以下はプリミティブ
					case ValueTypes.Enum :
						if( member.IsNullable == false )
						{
							json += "\"" + value.ToString() + "\"" ;
						}
						else
						{
							if( value == null )
							{
								json += "null" ;
							}
							else
							{
								json += "\"" + value.ToString() + "\"" ;
							}
						}
					break ;
					case ValueTypes.Boolean :
						if( member.IsNullable == false )
						{
							json += value.ToString().ToLower() ;
						}
						else
						{
							if( value == null )
							{
								json += "null" ;
							}
							else
							{
								json += value.ToString().ToLower() ;
							}
						}
					break ;
					case ValueTypes.Char :
						if( member.IsNullable == false )
						{
							json += ( ( System.UInt16 )( ( System.Char )value ) ).ToString() ;	// そのままだと文字になってしまうので数値にキャストが必要
						}
						else
						{
							if( value == null )
							{
								json += "null" ;
							}
							else
							{
								json += ( ( System.UInt16 )( ( System.Char )value ) ).ToString() ;	// そのままだと文字になってしまうので数値にキャストが必要
							}
						}
					break ;
					case ValueTypes.Byte :
					case ValueTypes.SByte :
					case ValueTypes.Int16 :
					case ValueTypes.UInt16 :
					case ValueTypes.Int32 :
					case ValueTypes.UInt32 :
					case ValueTypes.Int64 :
					case ValueTypes.UInt64 :
					case ValueTypes.Single :
					case ValueTypes.Double :
					case ValueTypes.Decimal :
						if( member.IsNullable == false )
						{
							json += value.ToString() ;
						}
						else
						{
							if( value == null )
							{
								json += "null" ;
							}
							else
							{
								json += value.ToString() ;
							}
						}
					break ;
					case ValueTypes.String :
						if( value == null )
						{
							json += "null" ;
						}
						else
						{
							json += "\"" + EncodeTextEscape( value.ToString(), json.Escape ) + "\"" ;
						}
					break ;
					case ValueTypes.DateTime :
						if( member.IsNullable == false )
						{
							json += "\"" + EncodeTextEscape( ( ( System.DateTime )value ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;
						}
						else
						{
							if( value == null )
							{
								json += "null" ;
							}
							else
							{
								json += "\"" + EncodeTextEscape( ( ( System.DateTime )value ).ToString( "yyyy/MM/dd HH:mm:ss.fffffff" ), json.Escape ) + "\"" ;
							}
						}
					break ;
				}

				if( mi <  ( ml - 1 ) ){ json += "," ; }
			}

			if( indent.Length >  1 ){ indent = indent.Substring( 0, indent.Length - 1 ) ; } ;	// \n や \t に対しての TrimEnd() は正しく動作しない
//			indent = indent.Substring( 0, indent.Length - 1 ) ;	// \n や \t に対しての TrimEnd() は正しく動作しない
			if( prettyPrint == true ){ json += indent ; }
			json += "}" ;
		}
	}
}
