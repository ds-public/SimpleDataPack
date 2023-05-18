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
		/// <summary>
		/// アダプターを(存在しなければ生成して)取得する
		/// </summary>
		/// <param name="objectType"></param>
		/// <returns></returns>
		public IAdapter GetAdapter( Type objectType )
		{
			if( ActiveAdapterCache.ContainsKey( objectType ) == true )
			{
				// ビルトインアダプターにヒットする
				return ActiveAdapterCache[ objectType ] ;
			}

			//----------------------------------------------------------
			// アダプターを生成する

			IAdapter adapter ;

			if( objectType.IsArray == true )
			{
				// Array
				adapter = GetArrayAdapter( objectType ) ;
			}
			else
			if( objectType.IsGenericType == true )
			{
				// Generic

				if( objectType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// リスト型
					// 列挙子ではアダプターにヒットしないので別処理が必要
					adapter = GetListAdapter( objectType ) ;
				}
				else
				if( objectType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// ディクショナリ型
					adapter = GetDictionaryAdapter( objectType ) ;
				}
				else
				if( objectType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// null 許容型
					var innerObjectType = Nullable.GetUnderlyingType( objectType ) ;
					if( innerObjectType.IsEnum == true )
					{
						// Enum?
						adapter = ( IAdapter )Activator.CreateInstance( typeof( EnumNAdapter<> ).MakeGenericType( objectType ) ) ;
					}
					else
					if
					(
						( innerObjectType.IsClass == false && innerObjectType.IsValueType == true && innerObjectType.IsPrimitive == true  ) ||	// Primitive
						innerObjectType == typeof( System.String ) ||
						innerObjectType == typeof( System.Decimal ) || innerObjectType == typeof( System.DateTime )
					)
					{
						// Primitive?

						// 基本的にここに来る事は無いが保険
//						adapter = ( IAdapter )Activator.CreateInstance( typeof( PrimitiveNAdapter<> ).MakeGenericType( objectType ) ) ;
						throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
					}
					else
					{
						// class? struct? は登録済みでなければ例外となる
						throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
					}
				}
				else
				{
					// その他のジェネリックは許容していない
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}
			else
			{
				// 列挙子単体ではアダプターにヒットしないので別処理が必要

				if( objectType.IsEnum == true )
				{
					// Enum
					adapter = ( IAdapter )Activator.CreateInstance( typeof( EnumAdapter<> ).MakeGenericType( objectType ) ) ;
				}
				else
				if
				(
					( objectType.IsClass == false && objectType.IsValueType == true && objectType.IsPrimitive == true  ) ||	// Primitive
					objectType == typeof( System.String ) ||
					objectType == typeof( System.Decimal ) || objectType == typeof( System.DateTime )
				)
				{
					// Primitive

					// 基本的にここに来る事は無いが保険
//					adapter = ( IAdapter )Activator.CreateInstance( typeof( PrimitiveAdapter<> ).MakeGenericType( objectType ) ) ;
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
				else
				{
					// class struct は登録済みでなければ例外となる
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}

			// 登録
			ActiveAdapterCache.Add( objectType, adapter ) ;

			return adapter ;
		}
	}
}
