using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// アレイ(Boolean)
	public class Array2DBooleanAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Boolean[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutBoolean( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				// 空配列
				return new System.Boolean[ 0, 0 ] ;
			}

			var elements = new System.Boolean[ length_0, length_1 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetBoolean() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Boolean[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutBoolean( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Boolean[,] DeserializeT( ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Boolean[ 0, 0 ] ;
			}

			var elements = new System.Boolean[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetBoolean() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Boolean?)
	public class Array2DBooleanNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Boolean?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutBooleanN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Boolean?[ 0, 0 ] ;
			}

			var elements = new System.Boolean?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetBooleanN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Boolean?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutBooleanN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Boolean?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Boolean?[ 0, 0 ] ;
			}

			var elements = new System.Boolean?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetBooleanN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Byte)
	public class Array2DByteAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Byte[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutByte( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Byte[ 0, 0 ] ;
			}

			var elements = new System.Byte[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetByte() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Byte[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutByte( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Byte[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Byte[ 0, 0 ] ;
			}

			var elements = new System.Byte[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetByte() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Byte?)
	public class Array2DByteNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Byte?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutByteN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Byte?[ 0, 0 ] ;
			}

			var elements = new System.Byte?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetByteN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Byte?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutByteN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Byte?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Byte?[ 0, 0 ] ;
			}

			var elements = new System.Byte?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetByteN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(SByte)
	public class Array2DSByteAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.SByte[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSByte( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.SByte[ 0, 0 ] ;
			}

			var elements = new System.SByte[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSByte() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.SByte[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSByte( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.SByte[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.SByte[ 0, 0 ] ;
			}

			var elements = new System.SByte[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSByte() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(SByte?)
	public class Array2DSByteNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.SByte?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSByteN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.SByte?[ 0, 0 ] ;
			}

			var elements = new System.SByte?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSByteN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.SByte?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSByteN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.SByte?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.SByte?[ 0, 0 ] ;
			}

			var elements = new System.SByte?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSByteN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Char)
	public class Array2DCharAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Char[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutChar( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Char[ 0, 0 ] ;
			}

			var elements = new System.Char[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetChar() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Char[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutChar( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Char[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Char[ 0, 0 ] ;
			}

			var elements = new System.Char[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetChar() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Char?)
	public class Array2DCharNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Char?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutCharN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Char?[ 0, 0 ] ;
			}

			var elements = new System.Char?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetCharN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Char?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutCharN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Char?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Char?[ 0, 0 ] ;
			}

			var elements = new System.Char?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetCharN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Int16)
	public class Array2DInt16Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Int16[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt16( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int16[ 0, 0 ] ;
			}

			var elements = new System.Int16[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt16() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int16[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt16( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Int16[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int16[ 0, 0 ] ;
			}

			var elements = new System.Int16[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt16() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Int16?)
	public class Array2DInt16NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Int16?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt16N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int16?[ 0, 0 ] ;
			}

			var elements = new System.Int16?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt16N() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int16?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt16N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Int16?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int16?[ 0, 0 ] ;
			}

			var elements = new System.Int16?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt16N() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(UInt16)
	public class Array2DUInt16Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.UInt16[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt16( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt16[ 0, 0 ] ;
			}

			var elements = new System.UInt16[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt16() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt16[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt16( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.UInt16[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt16[ 0, 0 ] ;
			}

			var elements = new System.UInt16[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt16() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(UInt16?)
	public class Array2DUInt16NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.UInt16?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt16N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt16?[ 0, 0 ] ;
			}

			var elements = new System.UInt16?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt16N() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt16?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt16N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.UInt16?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt16?[ 0, 0 ] ;
			}

			var elements = new System.UInt16?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt16N() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Int32)
	public class Array2DInt32Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Int32[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt32( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int32[ 0, 0 ] ;
			}

			var elements = new System.Int32[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt32() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int32[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt32( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Int32[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int32[ 0, 0 ] ;
			}

			var elements = new System.Int32[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt32() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Int32?)
	public class Array2DInt32NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Int32?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt32N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int32?[ 0, 0 ] ;
			}

			var elements = new System.Int32?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt32N() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int32?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt32N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Int32?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int32?[ 0, 0 ] ;
			}

			var elements = new System.Int32?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt32N() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(UInt32)
	public class Array2DUInt32Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.UInt32[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt32( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt32[ 0, 0 ] ;
			}

			var elements = new System.UInt32[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt32() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt32[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt32( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.UInt32[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt32[ 0, 0 ] ;
			}

			var elements = new System.UInt32[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt32() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(UInt32?)
	public class Array2DUInt32NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.UInt32?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt32N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt32?[ 0, 0 ] ;
			}

			var elements = new System.UInt32?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt32N() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt32?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt32N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.UInt32?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt32?[ 0, 0 ] ;
			}

			var elements = new System.UInt32?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt32N() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Int64)
	public class Array2DInt64Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Int64[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt64( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int64[ 0, 0 ] ;
			}

			var elements = new System.Int64[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt64() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int64[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt64( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Int64[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int64[ 0, 0 ] ;
			}

			var elements = new System.Int64[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt64() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Int64?)
	public class Array2DInt64NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Int64?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt64N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int64?[ 0, 0 ] ;
			}

			var elements = new System.Int64?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt64N() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int64?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutInt64N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Int64?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Int64?[ 0, 0 ] ;
			}

			var elements = new System.Int64?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetInt64N() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(UInt64)
	public class Array2DUInt64Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.UInt64[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt64( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt64[ 0, 0 ] ;
			}

			var elements = new System.UInt64[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt64() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt64[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt64( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.UInt64[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt64[ 0, 0 ] ;
			}

			var elements = new System.UInt64[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt64() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(UInt64?)
	public class Array2DUInt64NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.UInt64?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt64N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt64?[ 0, 0 ] ;
			}

			var elements = new System.UInt64?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt64N() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt64?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutUInt64N( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.UInt64?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.UInt64?[ 0, 0 ] ;
			}

			var elements = new System.UInt64?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetUInt64N() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Single)
	public class Array2DSingleAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Single[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSingle( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Single[ 0, 0 ] ;
			}

			var elements = new System.Single[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSingle() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Single[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSingle( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Single[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Single[ 0, 0 ] ;
			}

			var elements = new System.Single[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSingle() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Single?)
	public class Array2DSingleNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Single?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSingleN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Single?[ 0, 0 ] ;
			}

			var elements = new System.Single?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSingleN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Single?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutSingleN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Single?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Single?[ 0, 0 ] ;
			}

			var elements = new System.Single?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetSingleN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Double)
	public class Array2DDoubleAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Double[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDouble( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Double[ 0, 0 ] ;
			}

			var elements = new System.Double[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDouble() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Double[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDouble( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Double[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Double[ 0, 0 ] ;
			}

			var elements = new System.Double[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDouble() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Double?)
	public class Array2DDoubleNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Double?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDoubleN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Double?[ 0, 0 ] ;
			}

			var elements = new System.Double?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDoubleN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Double?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDoubleN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Double?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Double?[ 0, 0 ] ;
			}

			var elements = new System.Double?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDoubleN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Decimal)
	public class Array2DDecimalAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Decimal[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDecimal( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Decimal[ 0, 0 ] ;
			}

			var elements = new System.Decimal[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDecimal() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Decimal[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDecimal( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Decimal[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Decimal[ 0, 0 ] ;
			}

			var elements = new System.Decimal[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDecimal() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Decimal?)
	public class Array2DDecimalNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.Decimal?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDecimalN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Decimal?[ 0, 0 ] ;
			}

			var elements = new System.Decimal?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDecimalN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Decimal?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDecimalN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Decimal?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.Decimal?[ 0, 0 ] ;
			}

			var elements = new System.Decimal?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDecimalN() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(String)
	public class Array2DStringAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.String[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutString( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.String[ 0, 0 ] ;
			}

			var elements = new System.String[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetString() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.String[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutString( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.String[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.String[ 0, 0 ] ;
			}

			var elements = new System.String[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetString() ;
				}
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(DateTime)
	public class Array2DDateTimeAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.DateTime[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDateTime( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.DateTime[ 0, 0 ] ;
			}

			var elements = new System.DateTime[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDateTime() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.DateTime[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDateTime( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.DateTime[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.DateTime[ 0, 0 ] ;
			}

			var elements = new System.DateTime[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDateTime() ;
				}
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(DateTime?)
	public class Array2DDateTimeNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			var elements = entity as System.DateTime?[,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDateTimeN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.DateTime?[ 0, 0 ] ;
			}

			var elements = new System.DateTime?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_0 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDateTimeN() ;
				}
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.DateTime?[,] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			writer.PutByte( 2 ) ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return ;
			}

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					writer.PutDateTimeN( elements[ index_0, index_1 ] ) ;
				}
			}
		}

		public System.DateTime?[,] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 )
			{
				return new System.DateTime?[ 0, 0 ] ;
			}

			var elements = new System.DateTime?[ length_0, length_1 ] ;

			int index_0, index_1 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					elements[ index_0, index_1 ] = reader.GetDateTimeN() ;
				}
			}

			return elements ;
		}
	}

}
