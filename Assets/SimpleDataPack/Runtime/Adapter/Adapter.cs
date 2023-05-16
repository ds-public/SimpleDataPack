using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Reflection.Emit ;

using System.Runtime.CompilerServices ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// アダプター
	/// </summary>
	public interface IAdapter
	{
		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="writer"></param>
		void Serialize( System.Object entity, ByteStream writer ) ;

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		System.Object Deserialize( ByteStream reader ) ;
	}

	//--------------------------------------------------------------------------------------------

	//----------------
	// Internal

	public static Dictionary<Type,IAdapter>	InternalAdapterCache { get ; private set ; }
//	public static Dictionary<Type,System.Object>	InternalAdapterCache { get ; private set ; }

	//----------------
	// External

	public static Dictionary<Type,IAdapter>	ExternalAdapterCache { get ; private set ; }
//	public static Dictionary<Type,System.Object>	ExternalAdapterCache { get ; private set ; }

	//------------------------------------
	// Active

	public static Dictionary<Type,IAdapter>	ActiveAdapterCache { get ; private set ; }
//	public static Dictionary<Type,System.Object>	ActiveAdapterCache { get ; private set ; }

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// アダプターを追加する(内部のみ)
	/// </summary>
	/// <param name="type"></param>
	/// <param name="adapter"></param>
	public static void AddToInternalAdapters( Type type, IAdapter adapter )
//	public static void AddToInternalAdapters( Type type, System.Object adapter )
	{
		// 内部
//		if( InternalDelegate_Serialize.ContainsKey( type ) == true )
//		{
//			Debug.Log( "既に登録済みのタイプ:" + type.Name ) ;
//		}

//		if( type == typeof( Byte[,]) )
//		{
//			Debug.Log( "Byte[,]を登録するよ:" + adapter ) ;
//		}

		InternalAdapterCache.Add( type, adapter ) ;
	}

	//------------------------------------

	/// <summary>
	/// アダプターを追加する(外部のみ)
	/// </summary>
	/// <param name="type"></param>
	/// <param name="adapter"></param>
	public static void AddToExternalAdapters( Type type, IAdapter adapter )
//	public static void AddToExternalAdapters( Type type, System.Object adapter )
	{
		ExternalAdapterCache.Add( type, adapter ) ;
	}



//		[MethodImpl(MethodImplOptions.AggressiveInlining)]


	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// 外部アダプターのインターフェース定義
	/// </summary>
	public interface IExternalAdapter
	{
		void AddToExternal() ;
	}

	//--------------------------------------------------------------------------------------------
	// 自動生成コードからの呼び出し用

	public static void PutAnyObject( System.Object entity, Type objectType, ByteStream writer )
		=> m_DataConverter.PutAnyObject( entity, objectType, writer ) ;

//	public static void PutArray( System.Object entity, Type objectType, ByteStream writer )
//		=> m_DataConverter.PutArray( entity, objectType, writer ) ;

//	public static void PutList( System.Object entity, Type objectType, ByteStream writer )
//		=> m_DataConverter.PutList( entity, objectType, writer ) ;

	//----------------

	public static System.Object GetAnyObject( Type objectType, ByteStream reader )
		=> m_DataConverter.GetAnyObject( objectType, reader ) ;

//	public static System.Object GetArray( Type objectType, ByteStream writer )
//		=> m_DataConverter.GetArray( objectType, writer ) ;

//	public static System.Object GetList( Type objectType, ByteStream writer )
//		=> m_DataConverter.GetList( objectType, writer ) ;
}
