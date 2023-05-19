using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// ４次元

	/// <summary>
	/// T が確定値のアレイアダプター(T はスカラの class struct? struct 限定) ※T にアレイは不可
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Array4DGenericAdapter<T> : IAdapter
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

			//----------------------------------
			// ランクは 4 限定

			writer.PutByte( 4 ) ;

			//--------------

			T[,,,] elements = entity as T[,,,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;
			int length_3 = elements.GetLength( 3 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_2 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_3 ) ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 || length_3 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ typeof( T ) ].Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							serialize( elements[ index_0, index_1, index_2, index_3 ], writer ) ;
						}
					}
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
				return null ;
			}

			//----------------------------------
			// ランクは 4 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;
			int length_3 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 || length_3 == 0 )
			{
				// 基本的にはありえない
				return new T[ 0, 0, 0, 0 ] ;
			}

			T[,,,] elements = new T[ length_0, length_1, length_2, length_3 ] ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ typeof( T ) ].Deserialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = ( T )deserialize( reader ) ;
						}
					}
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コードからの直接実行

		public static void PutObject( T[,,,] elements, ByteStream writer )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array4DGenericAdapter<T> adapter ;

			Type type = typeof( T[,,,] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array4DGenericAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array4DGenericAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			adapter.SerializeT( elements, writer ) ;
		}

		public static T[,,,] GetObject( ByteStream reader )
		{
			// 既にアダプターが生成済みであればそれを使う
			Array4DGenericAdapter<T> adapter ;

			Type type = typeof( T[,,,] ) ;
			if( ActiveAdapterCache.ContainsKey( type ) == true )
			{
				// アダプターが有る
				adapter = ( Array4DGenericAdapter<T> )ActiveAdapterCache[ type ] ;
			}
			else
			{
				// アダプターが無い
				adapter = new Array4DGenericAdapter<T>() ;
				ActiveAdapterCache.Add( type, adapter ) ;
			}

			return adapter.DeserializeT( reader ) ;
		}

		//-----------------------------------

		/// <summary>
		/// シリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		public void SerializeT( T[,,,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// ランクを 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------
			// ランクは 4 限定

			writer.PutByte( 4 ) ;

			//--------------

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;
			int length_3 = elements.GetLength( 3 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_2 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_3 ) ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 || length_3 == 0 )
			{
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			IAdapter adapter = m_DataConverter.GetAdapter( typeof( T ) ) ;
			Action<System.Object,ByteStream> serialize = adapter.Serialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							serialize( elements[ index_0, index_1, index_2, index_3 ], writer ) ;
						}
					}
				}
			}
		}

		/// <summary>
		/// デシリアライズを実行する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader"></param>
		/// <returns></returns>
		public T[,,,] DeserializeT( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}

			//----------------------------------
			// ランクは 4 限定

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;
			int length_3 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 || length_3 == 0 )
			{
				// 基本的にはありえない
				return new T[ 0, 0, 0, 0 ] ;
			}

			T[,,,] elements = new T[ length_0, length_1, length_2, length_3 ] ;

			//----------------------------------

			// 高速化のためにデリゲート取得
			IAdapter adapter = m_DataConverter.GetAdapter( typeof( T ) ) ;
			Func<ByteStream,System.Object> deserialize = adapter.Deserialize ;

			// T のアダプターが登録済みなら直接デリゲートを呼ぶ(２倍以上高速)
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = ( T )deserialize( reader ) ;
						}
					}
				}
			}

			return elements ;
		}

	}
}
