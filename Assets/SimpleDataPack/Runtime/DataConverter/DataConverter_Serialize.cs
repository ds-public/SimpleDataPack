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
		//-------------------------------------------------------------------------------------------
		// Serialize 関係

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize<T>( T entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null(sruct は null は無い)
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------------------------------

			// ※entity から GetType() でタイプを取得してはいけない。Nullable 型で、実体がある場合は Nullable 型ではなくなってしまう。
			Type type = typeof( T ) ;

			//----------------------------------------------------------

			if( SimpleDataPack.ExternalAdapterEnabled == false || SimpleDataPack.ExternalAdapterDisabled == true )
			{
				// リフレクション版を使用する


//				DebugScreen.Out( "オブジェクト定義登録-開始" ) ;

				// プリミティブ型、すなわち Enum Boolean ～ DateTime 型の場合はオブジェクト解析は実行しない
				if
				(
					(
						( type.IsEnum == true ) ||	// Enum
						( type.IsClass == false && type.IsValueType == true && type.IsPrimitive == true  ) ||	// Primitive
						type == typeof( System.String ) ||
						type == typeof( System.Decimal ) || type == typeof( System.DateTime )
					) == false	// プリミティブではない(= Aray List Dictionary class struct)
				)
				{
					// 問題があれば例外が発生する
					m_ObjectDefinitionCache.Add( type, true ) ;
				}

//				DebugScreen.Out( "オブジェクト定義登録-終了" ) ;
			}
//#if UNITY_EDITOR
//			else
//			{
//				Debug.Log( "<color=#FFFF00>[Serialize]高速展開が有効</color>" ) ;
//			}
//#endif
			//----------------------------------------------------------

			// 実際の値を格納する
			PutAnyObject( entity, type, writer ) ;
		}

		//-------------------------------------------------------------------------------------------

		// 全てのデータを格納する(objectType は Nullable の内部のタイプ)　※<T> を使うと entity.GetType() になってしまう
		public void PutAnyObject( System.Object entity, Type objectType, ByteStream writer )
		{
//			DebugScreen.Out( "シリアライズ-開始" ) ;

			( ( IAdapter )GetAdapter( objectType ) ).Serialize( entity, writer ) ;

//			DebugScreen.Out( "シリアライズ-終了" ) ;
		}
	}
}
