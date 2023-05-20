using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// アレイ(Boolean)
	public class Array1DBooleanAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Boolean[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutBoolean( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Boolean[ 0 ] ;
			}

			var elements = new System.Boolean[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetBoolean() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Boolean[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutBoolean( elements[ index_0 ] ) ;
			}
		}

		public System.Boolean[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Boolean[ 0 ] ;
			}

			var elements = new System.Boolean[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetBoolean() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Boolean?)
	public class Array1DBooleanNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Boolean?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutBooleanN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Boolean?[ 0 ] ;
			}

			var elements = new System.Boolean?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetBooleanN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Boolean?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutBooleanN( elements[ index_0 ] ) ;
			}
		}

		public System.Boolean?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Boolean?[ 0 ] ;
			}

			var elements = new System.Boolean?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetBooleanN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Byte)
	public class Array1DByteAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Byte[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutByte( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Byte[ 0 ] ;
			}

			var elements = new System.Byte[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetByte() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Byte[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutByte( elements[ index_0 ] ) ;
			}
		}

		public System.Byte[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Byte[ 0 ] ;
			}

			var elements = new System.Byte[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetByte() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Byte?)
	public class Array1DByteNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Byte?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutByteN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Byte?[ 0 ] ;
			}

			var elements = new System.Byte?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetByteN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Byte?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutByteN( elements[ index_0 ] ) ;
			}
		}

		public System.Byte?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Byte?[ 0 ] ;
			}

			var elements = new System.Byte?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetByteN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(SByte)
	public class Array1DSByteAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.SByte[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSByte( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.SByte[ 0 ] ;
			}

			var elements = new System.SByte[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSByte() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.SByte[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSByte( elements[ index_0 ] ) ;
			}
		}

		public System.SByte[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.SByte[ 0 ] ;
			}

			var elements = new System.SByte[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSByte() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(SByte?)
	public class Array1DSByteNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.SByte?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSByteN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.SByte?[ 0 ] ;
			}

			var elements = new System.SByte?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSByteN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.SByte?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSByteN( elements[ index_0 ] ) ;
			}
		}

		public System.SByte?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.SByte?[ 0 ] ;
			}

			var elements = new System.SByte?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSByteN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Char)
	public class Array1DCharAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Char[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutChar( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Char[ 0 ] ;
			}

			var elements = new System.Char[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetChar() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Char[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutChar( elements[ index_0 ] ) ;
			}
		}

		public System.Char[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Char[ 0 ] ;
			}

			var elements = new System.Char[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetChar() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Char?)
	public class Array1DCharNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Char?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutCharN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Char?[ 0 ] ;
			}

			var elements = new System.Char?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetCharN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Char?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutCharN( elements[ index_0 ] ) ;
			}
		}

		public System.Char?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Char?[ 0 ] ;
			}

			var elements = new System.Char?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetCharN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Int16)
	public class Array1DInt16Adapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Int16[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt16( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Char[ 0 ] ;
			}

			var elements = new System.Int16[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt16() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int16[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt16( elements[ index_0 ] ) ;
			}
		}

		public System.Int16[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int16[ 0 ] ;
			}

			var elements = new System.Int16[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt16() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Int16?)
	public class Array1DInt16NAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Int16?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt16N( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int16?[ 0 ] ;
			}

			var elements = new System.Int16?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt16N() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int16?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt16N( elements[ index_0 ] ) ;
			}
		}

		public System.Int16?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int16?[ 0 ] ;
			}

			var elements = new System.Int16?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt16N() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(UInt16)
	public class Array1DUInt16Adapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.UInt16[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt16( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt16[ 0 ] ;
			}

			var elements = new System.UInt16[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt16() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt16[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt16( elements[ index_0 ] ) ;
			}
		}

		public System.UInt16[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt16[ 0 ] ;
			}

			var elements = new System.UInt16[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt16() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(UInt16?)
	public class Array1DUInt16NAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.UInt16?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt16N( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt16?[ 0 ] ;
			}

			var elements = new System.UInt16?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt16N() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt16?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt16N( elements[ index_0 ] ) ;
			}
		}

		public System.UInt16?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt16?[ 0 ] ;
			}

			var elements = new System.UInt16?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt16N() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Int32)
	public class Array1DInt32Adapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Int32[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt32( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int32[ 0 ] ;
			}

			var elements = new System.Int32[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt32() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int32[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt32( elements[ index_0 ] ) ;
			}
		}

		public System.Int32[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int32[ 0 ] ;
			}

			var elements = new System.Int32[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt32() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Int32?)
	public class Array1DInt32NAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Int32?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt32N( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int32?[ 0 ] ;
			}

			var elements = new System.Int32?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt32N() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int32?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt32N( elements[ index_0 ] ) ;
			}
		}

		public System.Int32?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int32?[ 0 ] ;
			}

			var elements = new System.Int32?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt32N() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(UInt32)
	public class Array1DUInt32Adapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.UInt32[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt32( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt32[ 0 ] ;
			}

			var elements = new System.UInt32[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt32() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt32[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt32( elements[ index_0 ] ) ;
			}
		}

		public System.UInt32[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt32[ 0 ] ;
			}

			var elements = new System.UInt32[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt32() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(UInt32?)
	public class Array1DUInt32NAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.UInt32?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt32N( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt32?[ 0 ] ;
			}

			var elements = new System.UInt32?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt32N() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt32?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt32N( elements[ index_0 ] ) ;
			}
		}

		public System.UInt32?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt32?[ 0 ] ;
			}

			var elements = new System.UInt32?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt32N() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Int64)
	public class Array1DInt64Adapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Int64[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt64( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int64[ 0 ] ;
			}

			var elements = new System.Int64[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt64() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int64[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt64( elements[ index_0 ] ) ;
			}
		}

		public System.Int64[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int64[ 0 ] ;
			}

			var elements = new System.Int64[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt64() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Int64?)
	public class Array1DInt64NAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Int64?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt64N( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int64?[ 0 ] ;
			}

			var elements = new System.Int64?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt64N() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Int64?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt64N( elements[ index_0 ] ) ;
			}
		}

		public System.Int64?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Int64?[ 0 ] ;
			}

			var elements = new System.Int64?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt64N() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(UInt64)
	public class Array1DUInt64Adapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.UInt64[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt64( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt64[ 0 ] ;
			}

			var elements = new System.UInt64[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt64() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt64[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt64( elements[ index_0 ] ) ;
			}
		}

		public System.UInt64[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt64[ 0 ] ;
			}

			var elements = new System.UInt64[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt64() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(UInt64?)
	public class Array1DUInt64NAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.UInt64?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt64N( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt64?[ 0 ] ;
			}

			var elements = new System.UInt64?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt64N() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.UInt64?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt64N( elements[ index_0 ] ) ;
			}
		}

		public System.UInt64?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.UInt64?[ 0 ] ;
			}

			var elements = new System.UInt64?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt64N() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Single)
	public class Array1DSingleAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Single[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSingle( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Single[ 0 ] ;
			}

			var elements = new System.Single[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSingle() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Single[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSingle( elements[ index_0 ] ) ;
			}
		}

		public System.Single[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Single[ 0 ] ;
			}

			var elements = new System.Single[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSingle() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Single?)
	public class Array1DSingleNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Single?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSingleN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Single?[ 0 ] ;
			}

			var elements = new System.Single?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSingleN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Single?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSingleN( elements[ index_0 ] ) ;
			}
		}

		public System.Single?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Single?[ 0 ] ;
			}

			var elements = new System.Single?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSingleN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Double)
	public class Array1DDoubleAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Double[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDouble( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Double[ 0 ] ;
			}

			var elements = new System.Double[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDouble() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Double[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDouble( elements[ index_0 ] ) ;
			}
		}

		public System.Double[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Double[ 0 ] ;
			}

			var elements = new System.Double[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDouble() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Double?)
	public class Array1DDoubleNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Double?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDoubleN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Double?[ 0 ] ;
			}

			var elements = new System.Double?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDoubleN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Double?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDoubleN( elements[ index_0 ] ) ;
			}
		}

		public System.Double?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Double?[ 0 ] ;
			}

			var elements = new System.Double?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDoubleN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(Decimal)
	public class Array1DDecimalAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Decimal[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDecimal( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Decimal[ 0 ] ;
			}

			var elements = new System.Decimal[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDecimal() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Decimal[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDecimal( elements[ index_0 ] ) ;
			}
		}

		public System.Decimal[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Decimal[ 0 ] ;
			}

			var elements = new System.Decimal[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDecimal() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(Decimal?)
	public class Array1DDecimalNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.Decimal?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDecimalN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Decimal?[ 0 ] ;
			}

			var elements = new System.Decimal?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDecimalN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.Decimal?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDecimalN( elements[ index_0 ] ) ;
			}
		}

		public System.Decimal?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.Decimal?[ 0 ] ;
			}

			var elements = new System.Decimal?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDecimalN() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(String)
	public class Array1DStringAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.String[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutString( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.String[ 0 ] ;
			}

			var elements = new System.String[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetString() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.String[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutString( elements[ index_0 ] ) ;
			}
		}

		public System.String[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.String[ 0 ] ;
			}

			var elements = new System.String[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetString() ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// アレイ(DateTime)
	public class Array1DDateTimeAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.DateTime[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDateTime( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.DateTime[ 0 ] ;
			}

			var elements = new System.DateTime[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDateTime() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.DateTime[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDateTime( elements[ index_0 ] ) ;
			}
		}

		public System.DateTime[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.DateTime[ 0 ] ;
			}

			var elements = new System.DateTime[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDateTime() ;
			}

			return elements ;
		}
	}

	//---------------

	// アレイ(DateTime?)
	public class Array1DDateTimeNAdapter : IAdapter
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

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			var elements = entity as System.DateTime?[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDateTimeN( elements[ index_0 ] ) ;
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

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.DateTime?[ 0 ] ;
			}

			var elements = new System.DateTime?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDateTimeN() ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( System.DateTime?[] elements, ByteStream writer )
		{
			if( elements == null )
			{
				// rank を 0 扱いで終了
				writer.PutByte( 0 ) ;
				return ;
			}

			//----------------------------------

			// ランクは 1 限定
			writer.PutByte( 1 ) ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDateTimeN( elements[ index_0 ] ) ;
			}
		}

		public System.DateTime?[] DeserializeT( ByteStream reader )
		{
			// 次元数を取得する
			if( reader.GetByte() == 0 )
			{
				// 終了
				return null ;
			}

			//---------------------------------

			// １次元限定
			int length_0 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 )
			{
				// 空配列
				return new System.DateTime?[ 0 ] ;
			}

			var elements = new System.DateTime?[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDateTimeN() ;
			}

			return elements ;
		}
	}

}
