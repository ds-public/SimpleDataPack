#if UNITY_2019_4_OR_NEWER
#define UNITY
#endif

using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;
using uGUIHelper ;

public partial class SimpleDataPack
{
	/// <summary>
	/// データ変換処理
	/// </summary>
	partial class DataConverter
	{
#if ( !UNITY || ( UNITY && ( UNITY_EDITOR || ENABLE_MONO ) ) )
		// Mono 版

		/// <summary>
		/// 対象が配列のケース
		/// </summary>
		/// <param name="objectType"></param>
		/// <returns></returns>
		public IAdapter GetArrayAdapter( Type objectType )
		{
			IAdapter adapter ;

			int rank = objectType.GetArrayRank() ;

			var elementType = objectType.GetElementType() ;

			if( elementType.IsArray == true )
			{
				// element - Arry : TO[TE[]]

				// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
				if( ActiveAdapterCache.ContainsKey( elementType ) == false )
				{
					ActiveAdapterCache.Add( elementType, GetArrayAdapter( elementType ) ) ;
				}

				adapter = rank switch
				{
					1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( elementType ) ),
					2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DGenericAdapter<> ).MakeGenericType( elementType ) ),
					3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DGenericAdapter<> ).MakeGenericType( elementType ) ),
					4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DGenericAdapter<> ).MakeGenericType( elementType ) ),
					_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDGenericAdapter<> ).MakeGenericType( elementType ), rank ),
				} ;
			}
			else
			if( elementType.IsGenericType == true )
			{
				// Generic
				if( elementType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// element - List<> : TO[List<TE>]

					// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
					if( ActiveAdapterCache.ContainsKey( elementType ) == false )
					{
						ActiveAdapterCache.Add( elementType, GetListAdapter( elementType ) ) ;
					}

					adapter = rank switch
					{
						1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( elementType ) ),
						2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DGenericAdapter<> ).MakeGenericType( elementType ) ),
						3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DGenericAdapter<> ).MakeGenericType( elementType ) ),
						4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DGenericAdapter<> ).MakeGenericType( elementType ) ),
						_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDGenericAdapter<> ).MakeGenericType( elementType ), rank ),
					} ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// element - Dictionary<,> : TO[Dictionary<TK,TV>]

					// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
					if( ActiveAdapterCache.ContainsKey( elementType ) == false )
					{
						ActiveAdapterCache.Add( elementType, GetDictionaryAdapter( elementType ) ) ;
					}

					adapter = rank switch
					{
						1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( elementType ) ),
						2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DGenericAdapter<> ).MakeGenericType( elementType ) ),
						3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DGenericAdapter<> ).MakeGenericType( elementType ) ),
						4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DGenericAdapter<> ).MakeGenericType( elementType ) ),
						_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDGenericAdapter<> ).MakeGenericType( elementType ), rank ),
					} ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// Nullable<>

					var innerElementType = Nullable.GetUnderlyingType( elementType ) ;
					if( innerElementType.IsEnum == true )
					{
						// element - Enum? : Enum?[] ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
						adapter = rank switch
						{
							1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDEnumNAdapter<> ).MakeGenericType( elementType ), rank ),
						} ;
					}
					else
					if
					(
						( innerElementType.IsClass == false && innerElementType.IsValueType == true && innerElementType.IsPrimitive == true  ) ||	// Primitive
						innerElementType == typeof( System.String ) ||
						innerElementType == typeof( System.Decimal ) || innerElementType == typeof( System.DateTime )
					)
					{
						// element - ValueType? : ValueType?[]

						// ５次元以上を必要に応じて生成する必要がある
						// １次元～４次元は実際は使用されない(ビルトインがヒットする)
						adapter = ( IAdapter )Activator.CreateInstance( typeof( ArrayNDPrimitiveNAdapter<> ).MakeGenericType( elementType ), rank ) ;
					}
					else
					{
						// element - class? struct? : class?[] struct?[]

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( elementType ) == true )
						{
							adapter = rank switch
							{
								1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( elementType ) ),
								2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DGenericAdapter<> ).MakeGenericType( elementType ) ),
								3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DGenericAdapter<> ).MakeGenericType( elementType ) ),
								4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DGenericAdapter<> ).MakeGenericType( elementType ) ),
								_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDGenericAdapter<> ).MakeGenericType( elementType ), rank ),
							} ;
						}
						else
						{
							// その他の型は許容していない
							throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
						}
					}
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}
			else
			if( elementType.IsEnum == true )
			{
				// element Enum : Enum[] ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
				adapter = rank switch
				{
					1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DEnumAdapter<> ).MakeGenericType( elementType ) ),
					2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DEnumAdapter<> ).MakeGenericType( elementType ) ),
					3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DEnumAdapter<> ).MakeGenericType( elementType ) ),
					4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DEnumAdapter<> ).MakeGenericType( elementType ) ),
					_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDEnumAdapter<> ).MakeGenericType( elementType ), rank ),
				} ;
			}
			else
			if
			(
				( elementType.IsClass == false && elementType.IsValueType == true && elementType.IsPrimitive == true  ) ||	// Primitive
				elementType == typeof( System.String ) ||
				elementType == typeof( System.Decimal ) || elementType == typeof( System.DateTime )
			)
			{
				// Pelement - ValueType : ValueType[]

				// ５次元以上を必要に応じて生成する必要がある
				// １次元～４次元は実際は使用されない(ビルトインがヒットする)
				adapter = ( IAdapter )Activator.CreateInstance( typeof( ArrayNDPrimitiveAdapter<> ).MakeGenericType( elementType ), rank ) ;
			}
			else
			{
				// element - class struct : class[] struct[]

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( elementType ) == true )
				{
					// Struct の場合、IL2CPP ビルドで処理を変える必要がある
					adapter = rank switch
					{
						1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DGenericAdapter<> ).MakeGenericType( elementType ) ),
						2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DGenericAdapter<> ).MakeGenericType( elementType ) ),
						3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DGenericAdapter<> ).MakeGenericType( elementType ) ),
						4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DGenericAdapter<> ).MakeGenericType( elementType ) ),
						_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDGenericAdapter<> ).MakeGenericType( elementType ), rank ),
					} ;
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}

			return adapter ;
		}

#else
		// IL2CPP 版(IL2CPP ビルドでリフレクションを使用するケース)

		/// <summary>
		/// 対象が配列のケース
		/// </summary>
		/// <param name="objectType"></param>
		/// <returns></returns>
		public IAdapter GetArrayAdapter( Type objectType )
		{
			IAdapter adapter ;

			int rank = objectType.GetArrayRank() ;

			var elementType = objectType.GetElementType() ;

			if( elementType.IsArray == true )
			{
				// element - Arry : TO[TE[]]

				// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
				if( ActiveAdapterCache.ContainsKey( elementType ) == false )
				{
					ActiveAdapterCache.Add( elementType, GetArrayAdapter( elementType ) ) ;
				}

				adapter = rank switch
				{
					1 => ( IAdapter )( new Array1DGenericVersatileAdapter( objectType, elementType ) ),
					2 => ( IAdapter )( new Array2DGenericVersatileAdapter( objectType, elementType ) ),
					3 => ( IAdapter )( new Array3DGenericVersatileAdapter( objectType, elementType ) ),
					4 => ( IAdapter )( new Array4DGenericVersatileAdapter( objectType, elementType ) ),
					_ => ( IAdapter )( new ArrayNDGenericVersatileAdapter( objectType, elementType, rank ) ),
				} ;
			}
			else
			if( elementType.IsGenericType == true )
			{
				// Generic
				if( elementType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// element - List<> : TO[List<TE>]

					// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
					if( ActiveAdapterCache.ContainsKey( elementType ) == false )
					{
						ActiveAdapterCache.Add( elementType, GetListAdapter( elementType ) ) ;
					}

					adapter = rank switch
					{
						1 => ( IAdapter )( new Array1DGenericVersatileAdapter( objectType, elementType ) ),
						2 => ( IAdapter )( new Array2DGenericVersatileAdapter( objectType, elementType ) ),
						3 => ( IAdapter )( new Array3DGenericVersatileAdapter( objectType, elementType ) ),
						4 => ( IAdapter )( new Array4DGenericVersatileAdapter( objectType, elementType ) ),
						_ => ( IAdapter )( new ArrayNDGenericVersatileAdapter( objectType, elementType, rank ) ),
					} ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// element - Dictionary<,> : TO[Dictionary<TK,TV>]

					// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
					if( ActiveAdapterCache.ContainsKey( elementType ) == false )
					{
						ActiveAdapterCache.Add( elementType, GetDictionaryAdapter( elementType ) ) ;
					}

					adapter = rank switch
					{
						1 => ( IAdapter )( new Array1DGenericVersatileAdapter( objectType, elementType ) ),
						2 => ( IAdapter )( new Array2DGenericVersatileAdapter( objectType, elementType ) ),
						3 => ( IAdapter )( new Array3DGenericVersatileAdapter( objectType, elementType ) ),
						4 => ( IAdapter )( new Array4DGenericVersatileAdapter( objectType, elementType ) ),
						_ => ( IAdapter )( new ArrayNDGenericVersatileAdapter( objectType, elementType, rank ) ),
					} ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// Nullable<>

					var innerElementType = Nullable.GetUnderlyingType( elementType ) ;
					if( innerElementType.IsEnum == true )
					{
						// element - Enum? : Enum?[] ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
						adapter = rank switch
						{
							1 => ( IAdapter )( new Array1DEnumNVersatileAdapter( objectType, elementType ) ),
							2 => ( IAdapter )( new Array2DEnumNVersatileAdapter( objectType, elementType ) ),
							3 => ( IAdapter )( new Array3DEnumNVersatileAdapter( objectType, elementType ) ),
							4 => ( IAdapter )( new Array4DEnumNVersatileAdapter( objectType, elementType ) ),
							_ => ( IAdapter )( new ArrayNDEnumNVersatileAdapter( objectType, elementType, rank ) )
						} ;
					}
					else
					if
					(
						( innerElementType.IsClass == false && innerElementType.IsValueType == true && innerElementType.IsPrimitive == true  ) ||	// Primitive
						innerElementType == typeof( System.String ) ||
						innerElementType == typeof( System.Decimal ) || innerElementType == typeof( System.DateTime )
					)
					{
						// element - ValueType? : ValueType?[]

						// ５次元以上を必要に応じて生成する必要がある
						// １次元～４次元は実際は使用されない(ビルトインがヒットする)
						adapter = ( IAdapter )( new ArrayNDPrimitiveNVersatileAdapter( objectType, elementType, rank ) ) ;
					}
					else
					{
						// element - class? struct? : class?[] struct?[]

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( elementType ) == true )
						{
							adapter = rank switch
							{
								1 => ( IAdapter )( new Array1DGenericVersatileAdapter( objectType, elementType ) ),
								2 => ( IAdapter )( new Array2DGenericVersatileAdapter( objectType, elementType ) ),
								3 => ( IAdapter )( new Array3DGenericVersatileAdapter( objectType, elementType ) ),
								4 => ( IAdapter )( new Array4DGenericVersatileAdapter( objectType, elementType ) ),
								_ => ( IAdapter )( new ArrayNDGenericVersatileAdapter( objectType, elementType, rank ) ),
							} ;
						}
						else
						{
							// その他の型は許容していない
							throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
						}
					}
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}
			else
			if( elementType.IsEnum == true )
			{
				// element Enum : Enum[] ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
				adapter = rank switch
				{
					1 => ( IAdapter )( new Array1DEnumVersatileAdapter( objectType, elementType ) ),
					2 => ( IAdapter )( new Array2DEnumVersatileAdapter( objectType, elementType ) ),
					3 => ( IAdapter )( new Array3DEnumVersatileAdapter( objectType, elementType ) ),
					4 => ( IAdapter )( new Array4DEnumVersatileAdapter( objectType, elementType ) ),
					_ => ( IAdapter )( new ArrayNDEnumVersatileAdapter( objectType, elementType, rank ) ),
				} ;
			}
			else
			if
			(
				( elementType.IsClass == false && elementType.IsValueType == true && elementType.IsPrimitive == true  ) ||	// Primitive
				elementType == typeof( System.String ) ||
				elementType == typeof( System.Decimal ) || elementType == typeof( System.DateTime )
			)
			{
				// Pelement - ValueType : ValueType[]

				// ５次元以上を必要に応じて生成する必要がある
				// １次元～４次元は実際は使用されない(ビルトインがヒットする)
				adapter = ( IAdapter )( new ArrayNDPrimitiveVersatileAdapter( objectType, elementType, rank ) ) ;
			}
			else
			{
				// element - class struct : class[] struct[]

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( elementType ) == true )
				{
					// Struct の場合、IL2CPP ビルドで処理を変える必要がある
					adapter = rank switch
					{
						1 => ( IAdapter )( new Array1DGenericVersatileAdapter( objectType, elementType ) ),
						2 => ( IAdapter )( new Array2DGenericVersatileAdapter( objectType, elementType ) ),
						3 => ( IAdapter )( new Array3DGenericVersatileAdapter( objectType, elementType ) ),
						4 => ( IAdapter )( new Array4DGenericVersatileAdapter( objectType, elementType ) ),
						_ => ( IAdapter )( new ArrayNDGenericVersatileAdapter( objectType, elementType, rank ) ),
					} ;
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}

			return adapter ;
		}


#endif
	}
}
