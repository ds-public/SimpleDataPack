using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.IO ;
using System.Linq ;
using System.Reflection ;

using UnityEngine ;

public partial class SimpleDataPack
{
	//--------------------------------------------------------------------------------------------
	// 純粋な C# 環境用のコード生成メソッド

	/// <summary>
	/// アセンブリファイル(XXX.DLL)を指定して高速処理用コードを生成する
	/// </summary>
	/// <param name="assemblyPath"></param>
	/// <param name="outputPath"></param>
	/// <returns></returns>
	public static ( string, string ) GenerateCode( string assemblyPath, string  outputPath, string objectName = "SimpleDataPackAdapter" )
	{
		if( File.Exists( assemblyPath ) == false )
		{
			Debug.LogError( "Bad AssemblyPath : " + assemblyPath ) ;
			return ( null, null ) ;
		}

		if( Directory.Exists( outputPath ) == false )
		{
			Debug.LogError( "Bad OutputPath : " + outputPath ) ;
			return ( null, null ) ;
		}

		//-----------------------------------

		Assembly assembly = Assembly.Load( assemblyPath ) ;
		if( assembly == null )
		{
			Debug.LogError( "Could not load Assembly : " + assemblyPath ) ;
			return ( null, null ) ;
		}

		//-----------------------------------------------------------

		Type[] assemblyTypes = assembly.GetTypes() ;
		if( assemblyTypes == null && assemblyTypes.Length == 0 )
		{
			Debug.LogError( "Bad Assembly" ) ;
			return ( null, null ) ;
		}

		var types = new List<Type>() ;
		foreach( var assemblyType in assemblyTypes )
		{
#if false
			Debug.Log
			(
				$"名前:{assemblyType.Name}" + "\n" +
				$"名前空間:{assemblyType.Namespace}" + "\n" +
				$"完全限定名:{assemblyType.FullName}" + "\n" + 
				$"このメンバを宣言するクラス:{assemblyType.DeclaringType}" + "\n" +
				$"直接の継承元:{assemblyType.BaseType}" + "\n" +
				$"属性:{assemblyType.Attributes}"
			) ;
#endif
			//	対象となるオブジェクト定義のみを抽出する
			var c = assemblyType.GetCustomAttribute<SimpleDataPackObjectAttribute>() ;
			if( c != null )
			{
				// 対象となるオブジェクト定義
				types.Add( assemblyType ) ;
			}

			var i = assemblyType.GetCustomAttributes<SimpleDataPackUnionAttribute>() ;
			if( i != null && i.Count() >  0 )
			{
				// 対象となるオブジェクト定義
				types.Add( assemblyType ) ;
			}
		}

		if( types.Count == 0 )
		{
			Debug.LogError( "Not found target" ) ;
			return ( null, null ) ;
		}

		return GenerateCode( objectName, types.ToArray(), outputPath ) ;
	}

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// 高速処理用コードを生成して保存する
	/// </summary>
	/// <param name="types"></param>
	/// <param name="outputPath"></param>
	/// <returns></returns>
	public static ( string, string ) GenerateCode( string objectName, Type[] types, string outputPath )
	{
		// 生成
		( string objectDispatcherCode, string objectExtensionsCode ) = GenerateCode( objectName, types ) ;

		if( string.IsNullOrEmpty( objectDispatcherCode ) == true || string.IsNullOrEmpty( objectExtensionsCode ) == true )
		{
			// エラー
			return ( null, null ) ;
		}

		//-----------------------------------------------------------

		outputPath = outputPath.Replace( "\\", "/" ).TrimEnd( '/' ) ;

		if( Directory.Exists( outputPath ) == false )
		{
			// フォルダを生成する
			Directory.CreateDirectory( outputPath ) ;
		}

		//-----------------------------------

		// 保存
		string objectDispatcherPath = outputPath + "/SimpleDataPack_ObjectDispatcher.cs" ;
		string objectExtensionsPath = outputPath + "/SimpleDataPack_ObjectExtensions.cs" ;

		File.WriteAllText( objectDispatcherPath, objectDispatcherCode ) ;
		File.WriteAllText( objectExtensionsPath, objectExtensionsCode ) ;

		return ( objectExtensionsCode, objectDispatcherCode ) ;
	}

	/// <summary>
	/// 高速処理用コードを生成する
	/// </summary>
	/// <param name="types"></param>
	/// <returns></returns>
	public static ( string, string ) GenerateCode( string objectName, Type[] types )
	{
		var objectDispatcher = new CodeGenerator_ObjectDispatcher() ;
		string objectDispatcherCode = objectDispatcher.GenerateCode( objectName, types ) ;

		var objectExtensions = new CodeGenerator_ObjectExtensions() ;
		string objectExtensionsCode = objectExtensions.GenerateCode( types ) ;

//		Debug.Log( objectExtensionsCode ) ;
//		Debug.Log( objectDispatcherCode ) ;

		return( objectDispatcherCode, objectExtensionsCode ) ;
	}
}
