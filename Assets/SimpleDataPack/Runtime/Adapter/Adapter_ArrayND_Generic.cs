using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//============================================================================================
	// Ｎ次元

	/// <summary>
	/// T[...] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ArrayNDGenericAdapter<T> : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDGenericAdapter( int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;
		}

		// インデックスを増加させる
		private void Increase()
		{
			int d, u = 1 ;

			for( d  = m_Limit ; d >  0 ; d -- )
			{
				m_Indices[ d ] += u ;

				u = m_Indices[ d ] / m_Lengths[ d ] ;
				m_Indices[ d ] %= m_Lengths[ d ] ;
			}
			m_Indices[ d ] += u ;
		}

		//-----------------------------------------------------------

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

			// 次元数を格納
			writer.PutVUInt32( ( System.UInt32 )Rank ) ;

			//----------------------------------

			// アレイ取得
			Array elements = entity as Array ;

			// 各次元の要素数を格納する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++ )
			{
				m_Lengths[ d ] = elements.GetLength( d ) ;
				writer.PutVUInt32( ( System.UInt32 )m_Lengths[ d ] ) ;

				m_Indices[ d ] = 0 ;
			}

			//--------------

			int length = elements.Length ;

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ typeof( T ) ].Serialize ;

			int index ; 
			for( index  = 0 ; index <  length ; index ++ )
			{
				serialize( elements.GetValue( m_Indices ), writer ) ;
				Increase() ;
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
			// 次元数を取得
			if( reader.GetVUInt32() == 0 )
			{
				return default ;
			}

			//----------------------------------

			// 各次元の要素数を取得する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++  )
			{
				m_Lengths[ d ] = ( System.Int32 )reader.GetVUInt32() ;

				m_Indices[ 0 ] = 0 ;
			}

			// アレイ生成
			Array elements = Array.CreateInstance( typeof( T ), m_Lengths ) ;

			//--------------

			int length = elements.Length ;

			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return elements ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ typeof( T ) ].Deserialize ;

			int index ; 
			for( index  = 0 ; index <  length ; index ++ )
			{
				elements.SetValue( deserialize( reader ), m_Indices ) ;
				Increase() ;
			}

			return elements ;
		}
	}

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	/// <summary>
	/// T[...] アダプター
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ArrayNDGenericVersatileAdapter : IAdapter
	{
		public readonly int		Rank ;

		private readonly int[]	m_Lengths ;
		private readonly int[]	m_Indices ;
		private readonly int	m_Limit ;

		private readonly Type			m_ObjectType ;
		private readonly Type			m_ElementType ;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ArrayNDGenericVersatileAdapter( Type objectType, Type elementType, int rank )
		{
			// 次元数を保存する
			Rank = rank ;

			m_Lengths = new int[ Rank ] ;
			m_Indices = new int[ Rank ] ;

			m_Limit = Rank - 1 ;

			//--------------

			m_ObjectType	= objectType ;
			m_ElementType	= elementType ;
		}

		// インデックスを増加させる
		private void Increase()
		{
			int d, u = 1 ;

			for( d  = m_Limit ; d >  0 ; d -- )
			{
				m_Indices[ d ] += u ;

				u = m_Indices[ d ] / m_Lengths[ d ] ;
				m_Indices[ d ] %= m_Lengths[ d ] ;
			}
			m_Indices[ d ] += u ;
		}

		//-----------------------------------------------------------

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

			// 次元数を格納
			writer.PutVUInt32( ( System.UInt32 )Rank ) ;

			//----------------------------------

			// アレイ取得
			Array elements = entity as Array ;

			// 各次元の要素数を格納する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++ )
			{
				m_Lengths[ d ] = elements.GetLength( d ) ;
				writer.PutVUInt32( ( System.UInt32 )m_Lengths[ d ] ) ;

				m_Indices[ d ] = 0 ;
			}

			//--------------

			int length = elements.Length ;

			// 多次元配列の要素数は全次元をかけ合わせたものである事に注意する
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			Action<System.Object,ByteStream> serialize = ActiveAdapterCache[ m_ElementType ].Serialize ;

			int index ; 
			for( index  = 0 ; index <  length ; index ++ )
			{
				serialize( elements.GetValue( m_Indices ), writer ) ;
				Increase() ;
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
			// 次元数を取得
			if( reader.GetVUInt32() == 0 )
			{
				return default ;
			}

			//----------------------------------

			// 各次元の要素数を取得する　※最初の方が高次元
			for( int d  = 0 ; d <  Rank ; d ++  )
			{
				m_Lengths[ d ] = ( System.Int32 )reader.GetVUInt32() ;

				m_Indices[ 0 ] = 0 ;
			}

			// アレイ生成
			Array elements = Array.CreateInstance( m_ElementType, m_Lengths ) ;

			//--------------

			int length = elements.Length ;

			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				return elements ;
			}

			//----------------------------------

			// 高速化のためにデリゲート取得
			Func<ByteStream,System.Object> deserialize = ActiveAdapterCache[ m_ElementType ].Deserialize ;

			int index ; 
			for( index  = 0 ; index <  length ; index ++ )
			{
				elements.SetValue( deserialize( reader ), m_Indices ) ;
				Increase() ;
			}

			return elements ;
		}
	}
}
