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
		//-------------------------------------------------------------------------------------------
		// Deserialize 関係

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <param name="type"></param>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( Type objectType, ByteStream reader )
		{
			//----------------------------------------------------------

			if( SimpleDataPack.ExternalAdapterEnabled == false || SimpleDataPack.ExternalAdapterDisabled == true )
			{
				// リフレクション版を使用する

				// プリミティブ型、すなわち Enum Boolean ～ DateTime 型の場合はオブジェクト解析は実行しない
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
					m_ObjectDefinitionCache.Add( objectType, true ) ;
				}
			}
//			else
//			{
//#if UNITY_EDITOR
//				Debug.Log( "<color=#FFFF00>[Deserialize]高速展開が有効</color>" ) ;
//#endif
//			}
			//----------------------------------------------------------

			// 実際の値を取得する
			return GetAnyObject( objectType, reader ) ;
		}

		//-------------------------------------------------------------------------------------------
		// 全てのデータを取得する(objectType は Nullable の内部のタイプ)
		public System.Object GetAnyObject( Type objectType, ByteStream reader )
		{
			return ( ( IAdapter )GetAdapter( objectType ) ).Deserialize( reader ) ;
		}
	}
}
