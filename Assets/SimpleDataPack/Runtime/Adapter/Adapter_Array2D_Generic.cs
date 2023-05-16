using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// ２次元

	/// <summary>
	/// T が確定値のアレイアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array2DGenericAdapter<T> : IAdapter
	{
		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			// ランクは 2 限定
			writer.PutByte( 2 ) ;

			//--------------

			T[,] elements = entity as T[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得

			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ typeof( T ) ].Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					serialize( elements[ index_0, index_1 ], writer ) ;
				}
			}
		}

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public System.Object Deserialize( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return default ;
			}

			// ランクは 2 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				// 基本的にはありえない
				return new T[ 0, 0 ] ;
			}

			T[,] elements = new T[ length_0, length_1 ] ;

			//----------------------------------

			// 高速化のためにデリゲート取得

			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ typeof( T ) ].Deserialize ;

//			float t = Time.realtimeSinceStartup ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = ( T )deserialize( reader ) ;
				}
			}

//			Debug.Log( "<color=#FFFF00>展開時間 : " + ( Time.realtimeSinceStartup - t ) + "</color>" ) ;

			return elements ;
		}
	}
}
