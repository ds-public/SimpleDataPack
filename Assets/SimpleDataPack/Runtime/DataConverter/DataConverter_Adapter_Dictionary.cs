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
		public IAdapter  GetDictionaryAdapter( Type objectType )
		{
			IAdapter adapter  ;

			//----------------------------------------------------------

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

			//----------------------------------------------------------

			adapter = ( IAdapter )Activator.CreateInstance( typeof( DictionaryGenericAdapter<,> ).MakeGenericType( keyType, valueType ) ) ;

			return adapter ;
		}
	}
}
