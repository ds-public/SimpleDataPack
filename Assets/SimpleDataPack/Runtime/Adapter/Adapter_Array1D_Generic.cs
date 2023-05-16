using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// １次元


	/// <summary>
	/// T が確定値のアレイアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array1DGenericAdapter<T> : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			//--------------

			T[] elements = entity as T[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得

			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ typeof( T ) ].Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				serialize( elements[ index_0 ], writer ) ;
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
				return null ;
			}

			// ランクは 1 限定

			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				return new T[ 0 ] ;
			}

			T[] elements = new T[ length_0 ] ;

			//----------------------------------

			// 高速化のためにデリゲート取得

			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ typeof( T ) ].Deserialize ;

//			float t = Time.realtimeSinceStartup ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = ( T )deserialize( reader ) ;
			}

//			Debug.Log( "<color=#FFFF00>展開時間 : " + ( Time.realtimeSinceStartup - t ) + " " + typeof( T ) + "</color>" ) ;

			return elements ;
		}
	}
}
