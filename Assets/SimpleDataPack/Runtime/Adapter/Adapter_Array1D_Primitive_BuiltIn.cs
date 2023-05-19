using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// アレイの基底クラス
	public class Array1DPrimitiveAdapterBase<T> : IAdapter
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

			T[] elements = entity as T[] ;

			int length_0 = elements.Length ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;

			if( length_0 == 0 )
			{
				return ;
			}

			//---------------------------------------------------------
			// ループで格納

			SetValue( elements, length_0, writer ) ;
		}

		protected virtual void SetValue( T[] elements, int length_0, ByteStream writer ){}

		//------------------------------------------------------------------------------------------

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
				return new T[ 0 ] ;
			}

			T[] elements = new T[ length_0 ] ;

			//---------------------------------------------------------
			// ループで取得

			GetValue( elements, length_0, reader ) ;

			return elements ;
		}

		protected virtual void GetValue( T[] elements, int length_0, ByteStream reader ){}
	}

	//===================================================================================================================

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
	public class Array1DPrimitiveAdapter_Char : Array1DPrimitiveAdapterBase<System.Char>
	{
		protected override void SetValue( System.Char[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutChar( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Char[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetChar() ;
			}
		}
	}

	//---------------

	// アレイ(Char?)
	public class Array1DPrimitiveAdapter_CharN : Array1DPrimitiveAdapterBase<System.Char?>
	{
		protected override void SetValue( System.Char?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutCharN( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Char?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetCharN() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(Int16)
	public class Array1DPrimitiveAdapter_Int16 : Array1DPrimitiveAdapterBase<System.Int16>
	{
		protected override void SetValue( System.Int16[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt16( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Int16[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt16() ;
			}
		}
	}

	//---------------

	// アレイ(Int16?)
	public class Array1DPrimitiveAdapter_Int16N : Array1DPrimitiveAdapterBase<System.Int16?>
	{
		protected override void SetValue( System.Int16?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt16N( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Int16?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt16N() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(UInt16)
	public class Array1DPrimitiveAdapter_UInt16 : Array1DPrimitiveAdapterBase<System.UInt16>
	{
		protected override void SetValue( System.UInt16[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt16( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.UInt16[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt16() ;
			}
		}
	}

	//---------------

	// アレイ(UInt16?)
	public class Array1DPrimitiveAdapter_UInt16N : Array1DPrimitiveAdapterBase<System.UInt16?>
	{
		protected override void SetValue( System.UInt16?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt16N( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.UInt16?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt16N() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(Int32)
	public class Array1DPrimitiveAdapter_Int32 : Array1DPrimitiveAdapterBase<System.Int32>
	{
		protected override void SetValue( System.Int32[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt32( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Int32[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt32() ;
			}
		}
	}

	//---------------

	// アレイ(Int32?)
	public class Array1DPrimitiveAdapter_Int32N : Array1DPrimitiveAdapterBase<System.Int32?>
	{
		protected override void SetValue( System.Int32?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt32N( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Int32?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt32N() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(UInt32)
	public class Array1DPrimitiveAdapter_UInt32 : Array1DPrimitiveAdapterBase<System.UInt32>
	{
		protected override void SetValue( System.UInt32[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt32( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.UInt32[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt32() ;
			}
		}
	}

	//---------------

	// アレイ(UInt32?)
	public class Array1DPrimitiveAdapter_UInt32N : Array1DPrimitiveAdapterBase<System.UInt32?>
	{
		protected override void SetValue( System.UInt32?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt32N( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.UInt32?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt32N() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(Int64)
	public class Array1DPrimitiveAdapter_Int64 : Array1DPrimitiveAdapterBase<System.Int64>
	{
		protected override void SetValue( System.Int64[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt64( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Int64[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt64() ;
			}
		}
	}

	//---------------

	// アレイ(Int64?)
	public class Array1DPrimitiveAdapter_Int64N : Array1DPrimitiveAdapterBase<System.Int64?>
	{
		protected override void SetValue( System.Int64?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutInt64N( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Int64?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetInt64N() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(UInt64)
	public class Array1DPrimitiveAdapter_UInt64 : Array1DPrimitiveAdapterBase<System.UInt64>
	{
		protected override void SetValue( System.UInt64[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt64( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.UInt64[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt64() ;
			}
		}
	}

	//---------------

	// アレイ(UInt64?)
	public class Array1DPrimitiveAdapter_UInt64N : Array1DPrimitiveAdapterBase<System.UInt64?>
	{
		protected override void SetValue( System.UInt64?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutUInt64N( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.UInt64?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetUInt64N() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(Single)
	public class Array1DPrimitiveAdapter_Single : Array1DPrimitiveAdapterBase<System.Single>
	{
		protected override void SetValue( System.Single[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSingle( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Single[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSingle() ;
			}
		}
	}

	//---------------

	// アレイ(Single?)
	public class Array1DPrimitiveAdapter_SingleN : Array1DPrimitiveAdapterBase<System.Single?>
	{
		protected override void SetValue( System.Single?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutSingleN( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Single?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetSingleN() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(Double)
	public class Array1DPrimitiveAdapter_Double : Array1DPrimitiveAdapterBase<System.Double>
	{
		protected override void SetValue( System.Double[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDouble( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Double[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDouble() ;
			}
		}
	}

	//---------------

	// アレイ(Double?)
	public class Array1DPrimitiveAdapter_DoubleN : Array1DPrimitiveAdapterBase<System.Double?>
	{
		protected override void SetValue( System.Double?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDoubleN( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Double?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDoubleN() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(Decimal)
	public class Array1DPrimitiveAdapter_Decimal : Array1DPrimitiveAdapterBase<System.Decimal>
	{
		protected override void SetValue( System.Decimal[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDecimal( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Decimal[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDecimal() ;
			}
		}
	}

	//---------------

	// アレイ(Decimal?)
	public class Array1DPrimitiveAdapter_DecimalN : Array1DPrimitiveAdapterBase<System.Decimal?>
	{
		protected override void SetValue( System.Decimal?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDecimalN( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.Decimal?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDecimalN() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(String)
	public class Array1DPrimitiveAdapter_String : Array1DPrimitiveAdapterBase<System.String>
	{
		protected override void SetValue( System.String[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutString( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.String[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetString() ;
			}
		}
	}

	//-----------------------------------

	// アレイ(DateTime)
	public class Array1DPrimitiveAdapter_DateTime : Array1DPrimitiveAdapterBase<System.DateTime>
	{
		protected override void SetValue( System.DateTime[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDateTime( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.DateTime[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDateTime() ;
			}
		}
	}

	//---------------

	// アレイ(DateTime?)
	public class Array1DPrimitiveAdapter_DateTimeN : Array1DPrimitiveAdapterBase<System.DateTime?>
	{
		protected override void SetValue( System.DateTime?[] elements, int length_0, ByteStream writer )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				writer.PutDateTimeN( elements[ index_0 ] ) ;
			}
		}

		protected override void GetValue( System.DateTime?[] elements, int length_0, ByteStream reader )
		{
			int index_0 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				elements[ index_0 ] = reader.GetDateTimeN() ;
			}
		}
	}
}
