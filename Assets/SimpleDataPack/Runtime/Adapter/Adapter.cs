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

	//----------------
	// External

	public static Dictionary<Type,IAdapter>	ExternalAdapterCache { get ; private set ; }

	//------------------------------------
	// Active

	public static Dictionary<Type,IAdapter>	ActiveAdapterCache { get ; private set ; }

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// アダプターを追加する(内部のみ)
	/// </summary>
	/// <param name="type"></param>
	/// <param name="adapter"></param>
	public static void AddToInternalAdapterCache( Type type, IAdapter adapter )
	{
		InternalAdapterCache.Add( type, adapter ) ;
	}

	//------------------------------------

	/// <summary>
	/// アダプターを追加する(外部のみ)
	/// </summary>
	/// <param name="type"></param>
	/// <param name="adapter"></param>
	public static void AddToExternalAdapterCache( Type type, IAdapter adapter )
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
		void AddToExternalAdapterCache() ;
	}

	//--------------------------------------------------------------------------------------------
	// 自動生成コードからの呼び出し用

	public static void PutAnyObject( System.Object entity, Type objectType, ByteStream writer )
		=> m_DataConverter.PutAnyObject( entity, objectType, writer ) ;

	//----------------

	public static System.Object GetAnyObject( Type objectType, ByteStream reader )
		=> m_DataConverter.GetAnyObject( objectType, reader ) ;
}
