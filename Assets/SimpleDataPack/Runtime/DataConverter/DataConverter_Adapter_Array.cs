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
		public IAdapter GetArrayAdapter( Type objectType )
		{
			IAdapter adapter ;

			int rank = objectType.GetArrayRank() ;

			var elementType = objectType.GetElementType() ;

			if( elementType.IsArray == true )
			{
				// Array

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
					// List<>

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
					// Dictionary<,>

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
						// Enum? ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
#if UNITY_EDITOR || ENABLE_MONO
						// Mono
						adapter = rank switch
						{
							1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DEnumNAdapter<> ).MakeGenericType( elementType ) ),
							_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDEnumNAdapter<> ).MakeGenericType( elementType ), rank ),
						} ;
#else
						// IL2CPP
						adapter = ( IAdapter )( new Array1DsEnumNAdapter( elementType ) ) ;
#endif
					}
					else
					if
					(
						( innerElementType.IsClass == false && innerElementType.IsValueType == true && innerElementType.IsPrimitive == true  ) ||	// Primitive
						innerElementType == typeof( System.String ) ||
						innerElementType == typeof( System.Decimal ) || innerElementType == typeof( System.DateTime )
					)
					{
						// Primitive?

						// ５次元以上を必要に応じて生成する必要がある
						// １次元～４次元は実際は使用されない(ビルトインがヒットする)
						adapter = ( IAdapter )Activator.CreateInstance( typeof( ArrayNDPrimitiveNAdapter<> ).MakeGenericType( elementType ), rank ) ;
					}
					else
					{
						// class? struct?

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
				// Enum ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
#if UNITY_EDITOR || ENABLE_MONO
				// Mono
				adapter = rank switch
				{
					1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DEnumAdapter<> ).MakeGenericType( elementType ) ),
					2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DEnumAdapter<> ).MakeGenericType( elementType ) ),
					3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DEnumAdapter<> ).MakeGenericType( elementType ) ),
					4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DEnumAdapter<> ).MakeGenericType( elementType ) ),
					_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDEnumAdapter<> ).MakeGenericType( elementType ), rank ),
				} ;
#else
				// IL2CPP
				adapter = ( IAdapter )( new Array1DsEnumAdapter( elementType ) ) ;
#endif
			}
			else
			if
			(
				( elementType.IsClass == false && elementType.IsValueType == true && elementType.IsPrimitive == true  ) ||	// Primitive
				elementType == typeof( System.String ) ||
				elementType == typeof( System.Decimal ) || elementType == typeof( System.DateTime )
			)
			{
				// Primitive

				// ５次元以上を必要に応じて生成する必要がある
				// １次元～４次元は実際は使用されない(ビルトインがヒットする)
				adapter = ( IAdapter )Activator.CreateInstance( typeof( ArrayNDPrimitiveAdapter<> ).MakeGenericType( elementType ), rank ) ;
//				{
//					1 => ( IAdapter )Activator.CreateInstance( typeof( Array1DPrimitiveAdapter<> ).MakeGenericType( elementType ) ),
//					2 => ( IAdapter )Activator.CreateInstance( typeof( Array2DPrimitiveAdapter<> ).MakeGenericType( elementType ) ),
//					3 => ( IAdapter )Activator.CreateInstance( typeof( Array3DPrimitiveAdapter<> ).MakeGenericType( elementType ) ),
//					4 => ( IAdapter )Activator.CreateInstance( typeof( Array4DPrimitiveAdapter<> ).MakeGenericType( elementType ) ),
//					_ => ( IAdapter )Activator.CreateInstance( typeof( ArrayNDPrimitiveAdapter<> ).MakeGenericType( elementType ), rank ),
//				} ;
			}
			else
			{
				// class struct

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

			return adapter ;
		}
	}
}
