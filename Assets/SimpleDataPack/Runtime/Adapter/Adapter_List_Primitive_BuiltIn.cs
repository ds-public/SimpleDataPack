using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// リスト(Boolean)
	public class ListBooleanAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Boolean> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutBoolean( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Boolean>() ;
			}

			var elements = new List<System.Boolean>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetBoolean() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Boolean> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutBoolean( elements[ index ] ) ;
			}
		}

		public List<System.Boolean> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Boolean>() ;
			}

			var elements = new List<System.Boolean>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetBoolean() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Boolean?)
	public class ListBooleanNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Boolean?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutBooleanN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Boolean?>() ;
			}

			var elements = new List<System.Boolean?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetBooleanN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Boolean?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutBooleanN( elements[ index ] ) ;
			}
		}

		public List<System.Boolean?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Boolean?>() ;
			}

			var elements = new List<System.Boolean?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetBooleanN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Byte)
	public class ListByteAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Byte> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutByte( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Byte>() ;
			}

			var elements = new List<System.Byte>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetByte() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Byte> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutByte( elements[ index ] ) ;
			}
		}

		public List<System.Byte> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Byte>() ;
			}

			var elements = new List<System.Byte>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetByte() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Byte?)
	public class ListByteNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Byte?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutByteN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _== null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Byte?>() ;
			}

			var elements = new List<System.Byte?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetByteN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Byte?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutByteN( elements[ index ] ) ;
			}
		}

		public List<System.Byte?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Byte?>() ;
			}

			var elements = new List<System.Byte?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetByteN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(SByte)
	public class ListSByteAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.SByte> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSByte( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.SByte>() ;
			}

			var elements = new List<System.SByte>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSByte() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.SByte> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSByte( elements[ index ] ) ;
			}
		}

		public List<System.SByte> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.SByte>() ;
			}

			var elements = new List<System.SByte>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSByte() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(SByte?)
	public class ListSByteNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.SByte?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSByteN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.SByte?>() ;
			}

			var elements = new List<System.SByte?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSByteN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.SByte?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSByteN( elements[ index ] ) ;
			}
		}

		public List<System.SByte?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.SByte?>() ;
			}

			var elements = new List<System.SByte?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSByteN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Char)
	public class ListCharAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Char> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutChar( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Char>() ;
			}

			var elements = new List<System.Char>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetChar() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Char> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutChar( elements[ index ] ) ;
			}
		}

		public List<System.Char> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Char>() ;
			}

			var elements = new List<System.Char>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetChar() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Char?)
	public class ListCharNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Char?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutCharN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Char?>() ;
			}

			var elements = new List<System.Char?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetCharN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Char?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutCharN( elements[ index ] ) ;
			}
		}

		public List<System.Char?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Char?>() ;
			}

			var elements = new List<System.Char?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetCharN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Int16)
	public class ListInt16Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Int16> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt16( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int16>() ;
			}

			var elements = new List<System.Int16>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt16() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Int16> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt16( elements[ index ] ) ;
			}
		}

		public List<System.Int16> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int16>() ;
			}

			var elements = new List<System.Int16>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt16() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Int16?)
	public class ListInt16NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Int16?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt16N( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int16?>() ;
			}

			var elements = new List<System.Int16?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt16N() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Int16?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt16N( elements[ index ] ) ;
			}
		}

		public List<System.Int16?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int16?>() ;
			}

			var elements = new List<System.Int16?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt16N() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(UInt16)
	public class ListUInt16Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.UInt16> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt16( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt16>() ;
			}

			var elements = new List<System.UInt16>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt16() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.UInt16> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt16( elements[ index ] ) ;
			}
		}

		public List<System.UInt16> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt16>() ;
			}

			var elements = new List<System.UInt16>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt16() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(UInt16?)
	public class ListUInt16NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.UInt16?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt16N( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt16?>() ;
			}

			var elements = new List<System.UInt16?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt16N() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.UInt16?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt16N( elements[ index ] ) ;
			}
		}

		public List<System.UInt16?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt16?>() ;
			}

			var elements = new List<System.UInt16?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt16N() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Int32)
	public class ListInt32Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Int32> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt32( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int32>() ;
			}

			var elements = new List<System.Int32>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt32() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Int32> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt32( elements[ index ] ) ;
			}
		}

		public List<System.Int32> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int32>() ;
			}

			var elements = new List<System.Int32>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt32() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Int32?)
	public class ListInt32NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Int32?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt32N( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int32?>() ;
			}

			var elements = new List<System.Int32?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt32N() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Int32?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt32N( elements[ index ] ) ;
			}
		}

		public List<System.Int32?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int32?>() ;
			}

			var elements = new List<System.Int32?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt32N() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(UInt32)
	public class ListUInt32Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.UInt32> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt32( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt32>() ;
			}

			var elements = new List<System.UInt32>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt32() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.UInt32> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt32( elements[ index ] ) ;
			}
		}

		public List<System.UInt32> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt32>() ;
			}

			var elements = new List<System.UInt32>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt32() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(UInt32?)
	public class ListUInt32NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.UInt32?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt32N( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt32?>() ;
			}

			var elements = new List<System.UInt32?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt32N() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.UInt32?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt32N( elements[ index ] ) ;
			}
		}

		public List<System.UInt32?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt32?>() ;
			}

			var elements = new List<System.UInt32?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt32N() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Int64)
	public class ListInt64Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Int64> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt64( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int64>() ;
			}

			var elements = new List<System.Int64>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt64() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Int64> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt64( elements[ index ] ) ;
			}
		}

		public List<System.Int64> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int64>() ;
			}

			var elements = new List<System.Int64>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt64() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Int64?)
	public class ListInt64NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Int64?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt64N( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int64?>() ;
			}

			var elements = new List<System.Int64?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt64N() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Int64?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutInt64N( elements[ index ] ) ;
			}
		}

		public List<System.Int64?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Int64?>() ;
			}

			var elements = new List<System.Int64?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetInt64N() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(UInt64)
	public class ListUInt64Adapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.UInt64> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt64( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt64>() ;
			}

			var elements = new List<System.UInt64>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt64() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.UInt64> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt64( elements[ index ] ) ;
			}
		}

		public List<System.UInt64> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt64>() ;
			}

			var elements = new List<System.UInt64>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt64() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(UInt64?)
	public class ListUInt64NAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.UInt64?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt64N( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt64?>() ;
			}

			var elements = new List<System.UInt64?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt64N() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.UInt64?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutUInt64N( elements[ index ] ) ;
			}
		}

		public List<System.UInt64?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.UInt64?>() ;
			}

			var elements = new List<System.UInt64?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetUInt64N() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Single)
	public class ListSingleAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Single> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSingle( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Single>() ;
			}

			var elements = new List<System.Single>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSingle() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Single> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSingle( elements[ index ] ) ;
			}
		}

		public List<System.Single> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Single>() ;
			}

			var elements = new List<System.Single>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSingle() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Single?)
	public class ListSingleNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Single?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSingleN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Single?>() ;
			}

			var elements = new List<System.Single?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSingleN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Single?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutSingleN( elements[ index ] ) ;
			}
		}

		public List<System.Single?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Single?>() ;
			}

			var elements = new List<System.Single?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetSingleN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Double)
	public class ListDoubleAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Double> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDouble( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Double>() ;
			}

			var elements = new List<System.Double>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDouble() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Double> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDouble( elements[ index ] ) ;
			}
		}

		public List<System.Double> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Double>() ;
			}

			var elements = new List<System.Double>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDouble() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Double?)
	public class ListDoubleNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Double?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDoubleN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Double?>() ;
			}

			var elements = new List<System.Double?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDoubleN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Double?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDoubleN( elements[ index ] ) ;
			}
		}

		public List<System.Double?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Double?>() ;
			}

			var elements = new List<System.Double?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDoubleN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(Decimal)
	public class ListDecimalAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Decimal> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDecimal( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Decimal>() ;
			}

			var elements = new List<System.Decimal>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDecimal() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Decimal> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDecimal( elements[ index ] ) ;
			}
		}

		public List<System.Decimal> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Decimal>() ;
			}

			var elements = new List<System.Decimal>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDecimal() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(Decimal?)
	public class ListDecimalNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.Decimal?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDecimalN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Decimal?>() ;
			}

			var elements = new List<System.Decimal?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDecimalN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.Decimal?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDecimalN( elements[ index ] ) ;
			}
		}

		public List<System.Decimal?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.Decimal?>() ;
			}

			var elements = new List<System.Decimal?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDecimalN() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(String)
	public class ListStringAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.String> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutString( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.String>() ;
			}

			var elements = new List<System.String>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetString() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.String> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutString( elements[ index ] ) ;
			}
		}

		public List<System.String> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.String>() ;
			}

			var elements = new List<System.String>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetString() ) ;
			}

			return elements ;
		}
	}

	//-----------------------------------

	// リスト(DateTime)
	public class ListDateTimeAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.DateTime> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDateTime( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.DateTime>() ;
			}

			var elements = new List<System.DateTime>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDateTime() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.DateTime> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDateTime( elements[ index ] ) ;
			}
		}

		public List<System.DateTime> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.DateTime>() ;
			}

			var elements = new List<System.DateTime>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDateTime() ) ;
			}

			return elements ;
		}
	}

	//---------------

	// リスト(DateTime?)
	public class ListDateTimeNAdapter : IAdapter
	{
		public void Serialize( System.Object entity, ByteStream writer )
		{
			if( entity == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			var elements = entity as List<System.DateTime?> ;

			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDateTimeN( elements[ index ] ) ;
			}
		}

		public System.Object Deserialize( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.DateTime?>() ;
			}

			var elements = new List<System.DateTime?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDateTimeN() ) ;
			}

			return elements ;
		}

		//-------------------------------------------------------------------------------------------
		// 自動生成コード用

		public void SerializeT( List<System.DateTime?> elements, ByteStream writer )
		{
			if( elements == null )
			{
				// null & 要素数を 0 で終了
				writer.PutByte( 0 ) ;
				return ;
			}
						
			int length = elements.Count ;

			// 要素数を格納する(0もある)
			if( length == 0 )
			{
				// 要素が無い場合は以下の無駄な処理はしない
				// 最下位ビットを not null で 1 とする
				writer.PutByte( 1 ) ;	// null ではない
				return ;
			}

			// 要素数は最大で 28 ビットとなる
			// 最下位ビットを not null で 1 とする
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//---------------------------------------------------------
			// ループで格納

			for( int index  = 0 ; index <  length ; index ++ )
			{
				writer.PutDateTimeN( elements[ index ] ) ;
			}
		}

		public List<System.DateTime?> DeserializeT( ByteStream reader )
		{
			// null フラグと配列要素数を取得
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			System.Int32 length = ( System.Int32 )_ ;

			if( length == 0 )
			{
				return new List<System.DateTime?>() ;
			}

			var elements = new List<System.DateTime?>( length ) ;

			//---------------------------------------------------------
			// ループで取得

			for( int index  = 0 ; index <  length ; index ++ )
			{
				elements.Add( reader.GetDateTimeN() ) ;
			}

			return elements ;
		}
	}

}
