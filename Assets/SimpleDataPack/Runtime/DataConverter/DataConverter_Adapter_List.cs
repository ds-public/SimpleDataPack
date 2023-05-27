#if UNITY_2019_4_OR_NEWER
#define UNITY
#endif

using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// データ変換処理
	/// </summary>
	partial class DataConverter
	{
#if ( !UNITY || ( UNITY && ( UNITY_EDITOR || ENABLE_MONO ) ) )
		// Mono 版

		public IAdapter GetListAdapter( Type objectType )
		{
			IAdapter adapter  ;

			// objectType は List 型である事に注意
			var types = objectType.GenericTypeArguments ;
			if( types == null || types.Length != 1 )
			{
				// 複数のジェネリックの場合はスルーされる
				throw new Exception( message:"Only one argument of list type is valid." ) ;
			}

			var elementType = types[ 0 ] ;

			if( elementType.IsArray == true )
			{
				// Array

				// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
				if( ActiveAdapterCache.ContainsKey( elementType ) == false )
				{
					ActiveAdapterCache.Add( elementType, GetArrayAdapter( elementType ) ) ;
				}

				adapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( elementType ) ) ;
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

					adapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( elementType ) ) ;
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

					adapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( elementType ) ) ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// Nullable<>

					var innerElementType = Nullable.GetUnderlyingType( elementType ) ;

					if( innerElementType.IsEnum == true )
					{
						// Enum ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
						adapter = ( IAdapter )Activator.CreateInstance( typeof( ListEnumNAdapter<> ).MakeGenericType( elementType ) ) ;
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

						// 基本的にここに来る事は無い(事前にヒットしたビルトインが使用される)
						throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
					}
					else
					{
						// class? struct?

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( elementType ) == true )
						{
							// Struct の場合、IL2CPP ビルドで処理を変える必要がある
							adapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( elementType ) ) ;
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
				adapter = ( IAdapter )Activator.CreateInstance( typeof( ListEnumAdapter<> ).MakeGenericType( elementType ) ) ;
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

				// 基本的にここに来る事は無い(事前にヒットしたビルトインが使用される)
				throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
			}
			else
			{
				// class struct

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( elementType ) == true )
				{
					// Struct の場合、IL2CPP ビルドで処理を変える必要がある
					adapter = ( IAdapter )Activator.CreateInstance( typeof( ListGenericAdapter<> ).MakeGenericType( elementType ) ) ;
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
#else
		// IL2CPP 版(IL2CPP ビルドでリフレクションを使用するケース)

		public IAdapter GetListAdapter( Type objectType )
		{
			IAdapter adapter  ;

			// objectType は List 型である事に注意
			var types = objectType.GenericTypeArguments ;
			if( types == null || types.Length != 1 )
			{
				// 複数のジェネリックの場合はスルーされる
				throw new Exception( message:"Only one argument of list type is valid." ) ;
			}

			var elementType = types[ 0 ] ;

			if( elementType.IsArray == true )
			{
				// Array

				// 入れ子関係なので element のアダプターが未生成・未登録であれば先に再生・登録する
				if( ActiveAdapterCache.ContainsKey( elementType ) == false )
				{
					ActiveAdapterCache.Add( elementType, GetArrayAdapter( elementType ) ) ;
				}

				adapter = ( IAdapter )( new ListGenericVersatileAdapter( objectType, elementType ) ) ;
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

					adapter = ( IAdapter )( new ListGenericVersatileAdapter( objectType, elementType ) ) ;
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

					adapter = ( IAdapter )( new ListGenericVersatileAdapter( objectType, elementType ) ) ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// Nullable<>

					var innerElementType = Nullable.GetUnderlyingType( elementType ) ;

					if( innerElementType.IsEnum == true )
					{
						// Enum ※IL2CPP では ValueType を Generic 対象にしたクラスのインスタンスが生成できない事に注意
						adapter = ( IAdapter )( new ListEnumNVersatileAdapter( objectType, elementType ) ) ;
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

						// 基本的にここに来る事は無い(事前にヒットしたビルトインが使用される)
						throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
					}
					else
					{
						// class? struct?

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( elementType ) == true )
						{
							// Struct の場合、IL2CPP ビルドで処理を変える必要がある
							adapter = ( IAdapter )( new ListGenericVersatileAdapter( objectType, elementType ) ) ;
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
				adapter = ( IAdapter )( new ListEnumVersatileAdapter( objectType, elementType ) ) ;
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

				// 基本的にここに来る事は無い(事前にヒットしたビルトインが使用される)
				throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
			}
			else
			{
				// class struct

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( elementType ) == true )
				{
					// Struct の場合、IL2CPP ビルドで処理を変える必要がある
					adapter = ( IAdapter )( new ListGenericVersatileAdapter( objectType, elementType ) ) ;
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
#endif
}
