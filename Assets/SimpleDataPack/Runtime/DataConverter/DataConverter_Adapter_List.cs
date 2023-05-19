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
#if UNITY_EDITOR || ENABLE_MONO
						// Mono
						adapter = ( IAdapter )Activator.CreateInstance( typeof( ListEnumNAdapter<> ).MakeGenericType( elementType ) ) ;
#else
						adapter = ( IAdapter )Activator.CreateInstance( typeof( ListSEnumNAdapter<> ).MakeGenericType( objectType ), innerElementType ) ;
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

						// 基本的にここに来る事は無い(事前にヒットしたビルトインが使用される)
//						adapter = ( IAdapter )Activator.CreateInstance( typeof( ListPrimitiveNAdapter<> ).MakeGenericType( elementType ) ) ;
						throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
					}
					else
					{
						// class? struct?

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( elementType ) == true )
						{
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
#if UNITY_EDITOR || ENABLE_MONO
				// Mono
				adapter = ( IAdapter )Activator.CreateInstance( typeof( ListEnumAdapter<> ).MakeGenericType( elementType ) ) ;
#else
				// IL2CPP
				adapter = ( IAdapter )Activator.CreateInstance( typeof( ListSEnumAdapter<> ).MakeGenericType( objectType ), elementType ) ;
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

				// 基本的にここに来る事は無い(事前にヒットしたビルトインが使用される)
//				adapter = ( IAdapter )Activator.CreateInstance( typeof( ListPrimitiveAdapter<> ).MakeGenericType( elementType ) ) ;
				throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
			}
			else
			{
				// class struct

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( elementType ) == true )
				{
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
}
