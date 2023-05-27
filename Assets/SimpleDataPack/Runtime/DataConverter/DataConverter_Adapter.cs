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
				{
					// class struct は登録済みでなければ例外となる
					throw new Exception( message:"This type is not supported : " + objectType.Name ) ;
				}
			}

			// 登録
			ActiveAdapterCache.Add( objectType, adapter ) ;

			return adapter ;
		}
#else
		// IL2CPP 版(IL2CPP ビルドでリフレクションを使用するケース)

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
						adapter = ( IAdapter )( new EnumNVersatileAdapter( objectType ) ) ;
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
					adapter = ( IAdapter )( new EnumVersatileAdapter( objectType ) ) ;
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
#endif
	}
}
