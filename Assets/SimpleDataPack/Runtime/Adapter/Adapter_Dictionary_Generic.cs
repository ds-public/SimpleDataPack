using System ;
using System.Collections ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	public class DictionaryGenericAdapter<TK,TV> : IAdapter
	{
		private readonly Type				keyType ;

		private readonly IAdapter			keyAdapter ;


		Action<System.Object,ByteStream>	SetKey ;
		Func<ByteStream,System.Object>		GetKey ;

		//---------------

		private readonly Type				valueType ;

		private readonly IAdapter			valueAdapter ;

		Action<System.Object,ByteStream>	SetValue ;
		Func<ByteStream,System.Object>		GetValue ;


		//-----------------------------------------------------------

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DictionaryGenericAdapter()
		{
			//----------------------------------
			// Key

			keyType		= typeof( TK ) ;
			TypeCode	keyTypeCode = Type.GetTypeCode( keyType ) ;

			if( keyType.IsEnum == true )
			{
				// Enum

				if( ActiveAdapterCache.ContainsKey( keyType ) == true )
				{
					keyAdapter = ActiveAdapterCache[ keyType ] ;
				}
				else
				{
					keyAdapter = ( IAdapter )Activator.CreateInstance( typeof( EnumAdapter<> ).MakeGenericType( keyType ) ) ;
					ActiveAdapterCache.Add( keyType, keyAdapter ) ;
				}
				SetKey = keyAdapter.Serialize ;
				GetKey = keyAdapter.Deserialize ;
			}
			else
			{
				// Primitive

				if( ActiveAdapterCache.ContainsKey( keyType ) == true )
				{
					// 基本的にこちらにくる(ビルトインにヒットするため)
					keyAdapter = ActiveAdapterCache[ keyType ] ;
				}
				else
				{
					throw new Exception( message:"This type is not supported : " + valueType.Name ) ;

//					keyAdapter = ( IAdapter )Activator.CreateInstance( typeof( PrimitiveAdapter<> ).MakeGenericType( keyType ) ) ;
//					ActiveAdapterCache.Add( keyType, keyAdapter ) ;
				}
				SetKey = keyAdapter.Serialize ;
				GetKey = keyAdapter.Deserialize ;
			}

			//----------------------------------------------------------
			// Value

			valueType = typeof( TV ) ;

			if( valueType.IsArray == true )
			{
				// Array
				if( ActiveAdapterCache.ContainsKey( valueType ) == true )
				{
					valueAdapter = ActiveAdapterCache[ valueType ] ;
				}
				else
				{
					valueAdapter = m_DataConverter.GetArrayAdapter( valueType ) ;
					ActiveAdapterCache.Add( valueType, valueAdapter ) ;
				}
				SetValue = valueAdapter.Serialize ;
				GetValue = valueAdapter.Deserialize ;
			}
			else
			if( valueType.IsGenericType == true )
			{
				// Generic
				var genericType = valueType.GetGenericTypeDefinition() ;

				if( genericType == typeof( List<> ) )
				{
					// List<>
					if( ActiveAdapterCache.ContainsKey( valueType ) == true )
					{
						valueAdapter = ActiveAdapterCache[ valueType ] ;
					}
					else
					{
						valueAdapter = m_DataConverter.GetListAdapter( valueType ) ;
						ActiveAdapterCache.Add( valueType, valueAdapter ) ;
					}
					SetValue = valueAdapter.Serialize ;
					GetValue = valueAdapter.Deserialize ;
				}
				else
				if( genericType == typeof( Dictionary<,> ) )
				{
					// Dictionary<,>
					if( ActiveAdapterCache.ContainsKey( valueType ) == true )
					{
						valueAdapter = ActiveAdapterCache[ valueType ] ;
					}
					else
					{
						valueAdapter = m_DataConverter.GetDictionaryAdapter( valueType ) ;
						ActiveAdapterCache.Add( valueType, valueAdapter ) ;
					}
					SetValue = valueAdapter.Serialize ;
					GetValue = valueAdapter.Deserialize ;
				}
				else
				if( valueType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// Nullable<>

					var innerValueType = Nullable.GetUnderlyingType( valueType ) ;

					if( innerValueType.IsEnum == true )
					{
						// Enum?

						if( ActiveAdapterCache.ContainsKey( valueType ) == true )
						{
							valueAdapter = ActiveAdapterCache[ valueType ] ;
						}
						else
						{
							valueAdapter = ( IAdapter )Activator.CreateInstance( typeof( EnumNAdapter<> ).MakeGenericType( valueType ) ) ;
							ActiveAdapterCache.Add( valueType, valueAdapter ) ;
						}
						SetValue = valueAdapter.Serialize ;
						GetValue = valueAdapter.Deserialize ;
					}
					else
					if
					(
						( innerValueType.IsClass == false && innerValueType.IsValueType == true && innerValueType.IsPrimitive == true  ) ||	// Primitive
						innerValueType == typeof( System.String ) ||
						innerValueType == typeof( System.Decimal ) || innerValueType == typeof( System.DateTime )
					)
					{
						// Primitive?
						if( ActiveAdapterCache.ContainsKey( valueType ) == true )
						{
							// 基本的にこちらにくる(ビルトインにヒットするため)
							valueAdapter = ActiveAdapterCache[ valueType ] ;
						}
						else
						{
							throw new Exception( message:"This type is not supported : " + valueType.Name ) ;

//							valueAdapter = ( IAdapter )Activator.CreateInstance( typeof( PrimitiveNAdapter<> ).MakeGenericType( valueType ) ) ;
//							ActiveAdapterCache.Add( valueType, valueAdapter ) ;
						}
						SetValue = valueAdapter.Serialize ;
						GetValue = valueAdapter.Deserialize ;
					}
					else
					{
						// class? struct?

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( valueType ) == true )
						{
							valueAdapter = ActiveAdapterCache[ valueType ] ;
							SetValue = valueAdapter.Serialize ;
							GetValue = valueAdapter.Deserialize ;
						}
						else
						{
							// その他の型は許容していない
							throw new Exception( message:"This type is not supported : " + valueType.Name ) ;
						}

					}
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + valueType.Name ) ;
				}
			}
			else
			if( valueType.IsEnum == true )
			{
				// Enum

				if( ActiveAdapterCache.ContainsKey( valueType ) == true )
				{
					valueAdapter = ActiveAdapterCache[ valueType ] ;
				}
				else
				{
					valueAdapter = ( IAdapter )Activator.CreateInstance( typeof( EnumAdapter<> ).MakeGenericType( valueType ) ) ;
					ActiveAdapterCache.Add( valueType, valueAdapter ) ;
				}
				SetValue = valueAdapter.Serialize ;
				GetValue = valueAdapter.Deserialize ;
			}
			else
			if
			(
				( valueType.IsClass == false && valueType.IsValueType == true && valueType.IsPrimitive == true  ) ||	// Primitive
				valueType == typeof( System.String ) ||
				valueType == typeof( System.Decimal ) || valueType == typeof( System.DateTime )
			)
			{
				// Primitive
				if( ActiveAdapterCache.ContainsKey( valueType ) == true )
				{
					// 基本的にこちらにくる(ビルトインにヒットするため)
					valueAdapter = ActiveAdapterCache[ valueType ] ;
				}
				else
				{
					throw new Exception( message:"This type is not supported : " + valueType.Name ) ;

//					valueAdapter = ( IAdapter )Activator.CreateInstance( typeof( PrimitiveAdapter<> ).MakeGenericType( valueType ) ) ;
//					ActiveAdapterCache.Add( valueType, valueAdapter ) ;
				}
				SetValue = valueAdapter.Serialize ;
				GetValue = valueAdapter.Deserialize ;
			}
			else
			{
				// class struct

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( valueType ) == true )
				{
					valueAdapter = ActiveAdapterCache[ valueType ] ;
					SetValue = valueAdapter.Serialize ;
					GetValue = valueAdapter.Deserialize ;
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + valueType.Name ) ;
				}
			}
		}

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
				// null 且つ length = 0
				writer.PutByte( 0 ) ;
				return ;
			}

			Dictionary<TK,TV> elements = entity as Dictionary<TK,TV> ;

			int length = elements.Count ;

			if( length == 0 )
			{
				// 空リスト
				writer.PutByte( 0 ) ;	// null ではない
				return ;
			}

			// 要素数を格納
			writer.PutVUInt33( ( System.UInt32? )length ) ;

			//----------------------------------
			// ループで格納

			TK[] keys = new TK[ length ] ;
			elements.Keys.CopyTo( keys, 0 ) ;

			int index ; TK key ;
			for( index  = 0 ; index <  length ; index ++ )
			{
				key = keys[ index ] ;
				SetKey( key, writer ) ;
				SetValue( elements[ key ], writer ) ;
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
			System.UInt32? _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}

			int length = ( int )_ ;

			if( length == 0 )
			{
				// 空リスト
				return new Dictionary<TK,TV>() ;
			}

			Dictionary<TK,TV> elements = new Dictionary<TK,TV>( length ) ;

			//----------------------------------
			// ループで取得

			int index ; TK key ;
			for( index  = 0 ; index <  length ; index ++ )
			{
				key = ( TK )GetKey( reader ) ;
				elements.Add( key, ( TV )GetValue( reader ) ) ;
			}

			return elements ;
		}
	}
}
