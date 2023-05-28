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


		private readonly Action<System.Object,ByteStream>	SetKey ;
		private readonly Func<ByteStream,System.Object>		GetKey ;

		//---------------

		private readonly Type				valueType ;

		private readonly IAdapter			valueAdapter ;

		private readonly Action<System.Object,ByteStream>	SetValue ;
		private readonly Func<ByteStream,System.Object>		GetValue ;


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

			var elements = entity as Dictionary<TK,TV> ;

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

			var elements = new Dictionary<TK,TV>( length ) ;

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

	//============================================================================================
	// IL2CPP ビルドでリフレクションを使用するケース

	public class DictionaryGenericVersatileAdapter : IAdapter
	{
		private readonly Type				m_ObjectType ;

		private readonly Type				m_KeyType ;

		private readonly IAdapter			keyAdapter ;


		private readonly Action<System.Object,ByteStream>	SetKey ;
		private readonly Func<ByteStream,System.Object>		GetKey ;

		//---------------

		private readonly Type				m_ValueType ;

		private readonly IAdapter			valueAdapter ;

		private readonly Action<System.Object,ByteStream>	SetValue ;
		private readonly Func<ByteStream,System.Object>		GetValue ;


		//-----------------------------------------------------------

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DictionaryGenericVersatileAdapter( Type objectType, Type keyType, Type valueType )
		{
			m_ObjectType	= objectType ;

			//----------------------------------
			// Key

			m_KeyType		= keyType ;
			TypeCode		keyTypeCode = Type.GetTypeCode( m_KeyType ) ;

			if( m_KeyType.IsEnum == true )
			{
				// Enum

				if( ActiveAdapterCache.ContainsKey( m_KeyType ) == true )
				{
					keyAdapter = ActiveAdapterCache[ m_KeyType ] ;
				}
				else
				{
					keyAdapter = ( IAdapter )( new EnumVersatileAdapter( m_KeyType ) ) ;
					ActiveAdapterCache.Add( m_KeyType, keyAdapter ) ;
				}
				SetKey = keyAdapter.Serialize ;
				GetKey = keyAdapter.Deserialize ;
			}
			else
			{
				// Primitive

				if( ActiveAdapterCache.ContainsKey( m_KeyType ) == true )
				{
					// 基本的にこちらにくる(ビルトインにヒットするため)
					keyAdapter = ActiveAdapterCache[ m_KeyType ] ;
				}
				else
				{
					throw new Exception( message:"This type is not supported : " + m_KeyType.Name ) ;
				}
				SetKey = keyAdapter.Serialize ;
				GetKey = keyAdapter.Deserialize ;
			}

			//----------------------------------------------------------
			// Value

			m_ValueType = valueType ;

			if( m_ValueType.IsArray == true )
			{
				// Array
				if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
				{
					valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
				}
				else
				{
					valueAdapter = m_DataConverter.GetArrayAdapter( m_ValueType ) ;
					ActiveAdapterCache.Add( m_ValueType, valueAdapter ) ;
				}
				SetValue = valueAdapter.Serialize ;
				GetValue = valueAdapter.Deserialize ;
			}
			else
			if( m_ValueType.IsGenericType == true )
			{
				// Generic
				var genericType = m_ValueType.GetGenericTypeDefinition() ;

				if( genericType == typeof( List<> ) )
				{
					// List<>
					if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
					{
						valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
					}
					else
					{
						valueAdapter = m_DataConverter.GetListAdapter( m_ValueType ) ;
						ActiveAdapterCache.Add( m_ValueType, valueAdapter ) ;
					}
					SetValue = valueAdapter.Serialize ;
					GetValue = valueAdapter.Deserialize ;
				}
				else
				if( genericType == typeof( Dictionary<,> ) )
				{
					// Dictionary<,>
					if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
					{
						valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
					}
					else
					{
						valueAdapter = m_DataConverter.GetDictionaryAdapter( m_ValueType ) ;
						ActiveAdapterCache.Add( m_ValueType, valueAdapter ) ;
					}
					SetValue = valueAdapter.Serialize ;
					GetValue = valueAdapter.Deserialize ;
				}
				else
				if( m_ValueType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					// Nullable<>

					var innerValueType = Nullable.GetUnderlyingType( m_ValueType ) ;

					if( innerValueType.IsEnum == true )
					{
						// Enum?

						if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
						{
							valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
						}
						else
						{
							valueAdapter = ( IAdapter )( new EnumNVersatileAdapter( m_ValueType ) ) ;
							ActiveAdapterCache.Add( m_ValueType, valueAdapter ) ;
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
						if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
						{
							// 基本的にこちらにくる(ビルトインにヒットするため)
							valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
						}
						else
						{
							throw new Exception( message:"This type is not supported : " + valueType.Name ) ;
						}
						SetValue = valueAdapter.Serialize ;
						GetValue = valueAdapter.Deserialize ;
					}
					else
					{
						// class? struct?

						// 登録済みでなければ例外となる
						if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
						{
							valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
							SetValue = valueAdapter.Serialize ;
							GetValue = valueAdapter.Deserialize ;
						}
						else
						{
							// その他の型は許容していない
							throw new Exception( message:"This type is not supported : " + m_ValueType.Name ) ;
						}

					}
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + m_ValueType.Name ) ;
				}
			}
			else
			if( m_ValueType.IsEnum == true )
			{
				// Enum

				if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
				{
					valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
				}
				else
				{
					valueAdapter = ( IAdapter )( new EnumVersatileAdapter( m_ValueType ) ) ;
					ActiveAdapterCache.Add( m_ValueType, valueAdapter ) ;
				}
				SetValue = valueAdapter.Serialize ;
				GetValue = valueAdapter.Deserialize ;
			}
			else
			if
			(
				( m_ValueType.IsClass == false && m_ValueType.IsValueType == true && m_ValueType.IsPrimitive == true  ) ||	// Primitive
				m_ValueType == typeof( System.String ) ||
				m_ValueType == typeof( System.Decimal ) || m_ValueType == typeof( System.DateTime )
			)
			{
				// Primitive
				if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
				{
					// 基本的にこちらにくる(ビルトインにヒットするため)
					valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
				}
				else
				{
					throw new Exception( message:"This type is not supported : " + m_ValueType.Name ) ;
				}
				SetValue = valueAdapter.Serialize ;
				GetValue = valueAdapter.Deserialize ;
			}
			else
			{
				// class struct

				// 登録済みでなければ例外となる
				if( ActiveAdapterCache.ContainsKey( m_ValueType ) == true )
				{
					valueAdapter = ActiveAdapterCache[ m_ValueType ] ;
					SetValue = valueAdapter.Serialize ;
					GetValue = valueAdapter.Deserialize ;
				}
				else
				{
					// その他の型は許容していない
					throw new Exception( message:"This type is not supported : " + m_ValueType.Name ) ;
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

			var elements = ( IDictionary )Activator.CreateInstance( m_ObjectType ) ;

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

			System.Object[] keys = new System.Object[ length ] ;
			elements.Keys.CopyTo( keys, 0 ) ;

			int index ; System.Object key ;
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
				return Activator.CreateInstance( m_ObjectType ) ;
			}

			var elements = ( IDictionary )Activator.CreateInstance( m_ObjectType ) ;

			//----------------------------------
			// ループで取得

			int index ; System.Object key ;
			for( index  = 0 ; index <  length ; index ++ )
			{
				key = GetKey( reader ) ;
				elements.Add( key, GetValue( reader ) ) ;
			}

			return elements ;
		}
	}

}
