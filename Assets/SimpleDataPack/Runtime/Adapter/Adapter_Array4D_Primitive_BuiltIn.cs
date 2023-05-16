using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// アレイの基底クラス
	public class Array4DPrimitiveAdapterBase<T> : IAdapter
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

			// ランクは 4 限定
			writer.PutByte( 4 ) ;

			T[,,,] elements = entity as T[,,,] ;

			int length_0 = elements.GetLength( 0 ) ;
			int length_1 = elements.GetLength( 1 ) ;
			int length_2 = elements.GetLength( 2 ) ;
			int length_3 = elements.GetLength( 2 ) ;

			writer.PutVUInt32( ( System.UInt32 )length_0 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_1 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_2 ) ;
			writer.PutVUInt32( ( System.UInt32 )length_3 ) ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 || length_3 == 0 )
			{
				return ;
			}

			//---------------------------------------------------------
			// ループで格納

			SetValue( elements, length_0, length_1, length_2, length_3, writer ) ;
		}

		protected virtual void SetValue( T[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer ){}

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

			int length_0 = ( int )reader.GetVUInt32() ;
			int length_1 = ( int )reader.GetVUInt32() ;
			int length_2 = ( int )reader.GetVUInt32() ;
			int length_3 = ( int )reader.GetVUInt32() ;

			if( length_0 == 0 || length_1 == 0 || length_2 == 0 || length_3 == 0 )
			{
				// 空配列(基本的にありえない)
				return new T[ 0, 0, 0, 0 ] ;
			}

			T[,,,] elements = new T[ length_0, length_1, length_2, length_3 ] ;

			//---------------------------------------------------------
			// ループで取得

			GetValue( elements, length_0, length_1, length_2, length_3, reader ) ;

			return elements ;
		}

		protected virtual void GetValue( T[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader ){}
	}

	//===================================================================================================================

	// アレイ(Boolean)
	public class Array4DPrimitiveAdapter_Boolean : Array4DPrimitiveAdapterBase<System.Boolean>
	{
		protected override void SetValue( System.Boolean[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutBoolean( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Boolean[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetBoolean() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Boolean?)
	public class Array4DPrimitiveAdapter_BooleanN : Array4DPrimitiveAdapterBase<System.Boolean?>
	{
		protected override void SetValue( System.Boolean?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutBooleanN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Boolean?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetBooleanN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Byte)
	public class Array4DPrimitiveAdapter_Byte : Array4DPrimitiveAdapterBase<System.Byte>
	{
		protected override void SetValue( System.Byte[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutByte( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Byte[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetByte() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Byte?)
	public class Array4DPrimitiveAdapter_ByteN : Array4DPrimitiveAdapterBase<System.Byte?>
	{
		protected override void SetValue( System.Byte?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutByteN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Byte?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetByteN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(SByte)
	public class Array4DPrimitiveAdapter_SByte : Array4DPrimitiveAdapterBase<System.SByte>
	{
		protected override void SetValue( System.SByte[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutSByte( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.SByte[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetSByte() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(SByte?)
	public class Array4DPrimitiveAdapter_SByteN : Array4DPrimitiveAdapterBase<System.SByte?>
	{
		protected override void SetValue( System.SByte?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutSByteN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.SByte?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetSByteN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Char)
	public class Array4DPrimitiveAdapter_Char : Array4DPrimitiveAdapterBase<System.Char>
	{
		protected override void SetValue( System.Char[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutChar( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Char[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetChar() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Char?)
	public class Array4DPrimitiveAdapter_CharN : Array4DPrimitiveAdapterBase<System.Char?>
	{
		protected override void SetValue( System.Char?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutCharN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Char?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetCharN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Int16)
	public class Array4DPrimitiveAdapter_Int16 : Array4DPrimitiveAdapterBase<System.Int16>
	{
		protected override void SetValue( System.Int16[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutInt16( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Int16[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetInt16() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Int16?)
	public class Array4DPrimitiveAdapter_Int16N : Array4DPrimitiveAdapterBase<System.Int16?>
	{
		protected override void SetValue( System.Int16?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutInt16N( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Int16?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetInt16N() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(UInt16)
	public class Array4DPrimitiveAdapter_UInt16 : Array4DPrimitiveAdapterBase<System.UInt16>
	{
		protected override void SetValue( System.UInt16[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutUInt16( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.UInt16[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetUInt16() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(UInt16?)
	public class Array4DPrimitiveAdapter_UInt16N : Array4DPrimitiveAdapterBase<System.UInt16?>
	{
		protected override void SetValue( System.UInt16?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutUInt16N( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.UInt16?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetUInt16N() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Int32)
	public class Array4DPrimitiveAdapter_Int32 : Array4DPrimitiveAdapterBase<System.Int32>
	{
		protected override void SetValue( System.Int32[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutInt32( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Int32[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetInt32() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Int32?)
	public class Array4DPrimitiveAdapter_Int32N : Array4DPrimitiveAdapterBase<System.Int32?>
	{
		protected override void SetValue( System.Int32?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutInt32N( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Int32?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetInt32N() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(UInt32)
	public class Array4DPrimitiveAdapter_UInt32 : Array4DPrimitiveAdapterBase<System.UInt32>
	{
		protected override void SetValue( System.UInt32[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutUInt32( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.UInt32[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetUInt32() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(UInt32?)
	public class Array4DPrimitiveAdapter_UInt32N : Array4DPrimitiveAdapterBase<System.UInt32?>
	{
		protected override void SetValue( System.UInt32?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutUInt32N( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.UInt32?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetUInt32N() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Int64)
	public class Array4DPrimitiveAdapter_Int64 : Array4DPrimitiveAdapterBase<System.Int64>
	{
		protected override void SetValue( System.Int64[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutInt64( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Int64[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetInt64() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Int64?)
	public class Array4DPrimitiveAdapter_Int64N : Array4DPrimitiveAdapterBase<System.Int64?>
	{
		protected override void SetValue( System.Int64?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutInt64N( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Int64?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetInt64N() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(UInt64)
	public class Array4DPrimitiveAdapter_UInt64 : Array4DPrimitiveAdapterBase<System.UInt64>
	{
		protected override void SetValue( System.UInt64[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutUInt64( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.UInt64[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetUInt64() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(UInt64?)
	public class Array4DPrimitiveAdapter_UInt64N : Array4DPrimitiveAdapterBase<System.UInt64?>
	{
		protected override void SetValue( System.UInt64?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutUInt64N( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.UInt64?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetUInt64N() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Single)
	public class Array4DPrimitiveAdapter_Single : Array4DPrimitiveAdapterBase<System.Single>
	{
		protected override void SetValue( System.Single[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutSingle( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Single[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetSingle() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Single?)
	public class Array4DPrimitiveAdapter_SingleN : Array4DPrimitiveAdapterBase<System.Single?>
	{
		protected override void SetValue( System.Single?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutSingleN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Single?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetSingleN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Double)
	public class Array4DPrimitiveAdapter_Double : Array4DPrimitiveAdapterBase<System.Double>
	{
		protected override void SetValue( System.Double[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutDouble( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Double[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetDouble() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Double?)
	public class Array4DPrimitiveAdapter_DoubleN : Array4DPrimitiveAdapterBase<System.Double?>
	{
		protected override void SetValue( System.Double?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutDoubleN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Double?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetDoubleN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(Decimal)
	public class Array4DPrimitiveAdapter_Decimal : Array4DPrimitiveAdapterBase<System.Decimal>
	{
		protected override void SetValue( System.Decimal[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutDecimal( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Decimal[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetDecimal() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(Decimal?)
	public class Array4DPrimitiveAdapter_DecimalN : Array4DPrimitiveAdapterBase<System.Decimal?>
	{
		protected override void SetValue( System.Decimal?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutDecimalN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.Decimal?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetDecimalN() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(String)
	public class Array4DPrimitiveAdapter_String : Array4DPrimitiveAdapterBase<System.String>
	{
		protected override void SetValue( System.String[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutString( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.String[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetString() ;
						}
					}
				}
			}
		}
	}

	//-----------------------------------

	// アレイ(DateTime)
	public class Array4DPrimitiveAdapter_DateTime : Array4DPrimitiveAdapterBase<System.DateTime>
	{
		protected override void SetValue( System.DateTime[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutDateTime( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.DateTime[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetDateTime() ;
						}
					}
				}
			}
		}
	}

	//---------------

	// アレイ(DateTime?)
	public class Array4DPrimitiveAdapter_DateTimeN : Array4DPrimitiveAdapterBase<System.DateTime?>
	{
		protected override void SetValue( System.DateTime?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream writer )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							writer.PutDateTimeN( elements[ index_0, index_1, index_2, index_3 ] ) ;
						}
					}
				}
			}
		}

		protected override void GetValue( System.DateTime?[,,,] elements, int length_0, int length_1, int length_2, int length_3, ByteStream reader )
		{
			int index_0, index_1, index_2, index_3 ;
			for( index_0  = 0 ; index_0 <  length_0 ; index_0 ++ )
			{
				for( index_1  = 0 ; index_1 <  length_1 ; index_1 ++ )
				{
					for( index_2  = 0 ; index_2 <  length_2 ; index_2 ++ )
					{
						for( index_3  = 0 ; index_3 <  length_3 ; index_3 ++ )
						{
							elements[ index_0, index_1, index_2, index_3 ] = reader.GetDateTimeN() ;
						}
					}
				}
			}
		}
	}
}
