using System ;
using System.Collections.Generic ;
using System.IO ;

using UnityEditor ;
using UnityEngine ;

using DSW ;

/// <summary>
/// アプリケーションのバッチビルド用クラス:設定
/// </summary>
public partial class Build_Application
{
	//--------------------------------------------------------------------------------------------
	// 設定

	//------------------------------------
	// Windows64用

	private const string	m_Path_Windows64								= "SDP/sdp.exe" ;

	private static string	VersionName_Windows64
	{
		get
		{
			( string versionName, _ ) = GetVersion( PlatformTypes.Windows64 ) ;
			return versionName ;
		}
	}

	private const string	m_ProductName_Windows64_Release					= "SDP" ;
	private const string	m_ProductName_Windows64_Staging					= "SDP(S)" ;
	private const string	m_ProductName_Windows64_Development				= "SDP(D)" ;
	private const string	m_ProductName_Windows64_Profiler				= "SDP(P)" ;

	private const string	m_Identifier_Windows64_Release					= "com.sdp" ;
	private const string	m_Identifier_Windows64_Staging					= "com.sdp" ;
	private const string	m_Identifier_Windows64_Development				= "com.sdp" ;
	private const string	m_Identifier_Windows64_Profiler					= "com.sdp" ;

	//------------------------------------
	// OSX用

	private const string	m_Path_OSX										= "SDP/sdp.app" ;

	private static string	VersionName_OSX
	{
		get
		{
			( string versionName, _ ) = GetVersion( PlatformTypes.OSX ) ;
			return versionName ;
		}
	}

	private const string	m_ProductName_OSX_Release						= "SDP" ;
	private const string	m_ProductName_OSX_Staging						= "SDP(S)" ;
	private const string	m_ProductName_OSX_Development					= "SDP(D)" ;
	private const string	m_ProductName_OSX_Profiler						= "SDP(P)" ;

	private const string	m_Identifier_OSX_Release						= "com.sdp" ;
	private const string	m_Identifier_OSX_Staging						= "com.dsp" ;
	private const string	m_Identifier_OSX_Development					= "com.dsp" ;
	private const string	m_Identifier_OSX_Profiler						= "comsdp" ;

	private const string	m_DevelopmentTeam_OSX							= "ABCDEFGHIJ" ;
	private const string	m_CodeSignIdentity_OSX							= "iPhone Distribution: SDP Co.,Ltd." ;
	private const string	m_ProvisioningProfileSpecifier_OSX				= "SDP_Enterprise" ;

	//------------------------------------
	// Android用

	private const string	m_Path_Android									= "sdp.apk" ;

	private static string	VersionName_Android
	{
		get
		{
			( string versionName, _ ) = GetVersion( PlatformTypes.Android ) ;
			return versionName ;
		}
	}
	private static int VersionCode_Android
	{
		get
		{
			( _, int versionCode ) = GetVersion( PlatformTypes.Android ) ;
			return versionCode ;
		}
	}

	//----------------

	private const string	m_ProductName_Android_Release					= "SDP" ;
	private const string	m_ProductName_Android_Review					= "SDP(R)" ;
	private const string	m_ProductName_Android_Staging					= "SDP(S)" ;
	private const string	m_ProductName_Android_Development				= "SDP(D)" ;
	private const string	m_ProductName_Android_Profiler					= "SDP(P)" ;

	private const string	m_Identifier_Android_Release					= "com.sdp" ;
	private const string	m_Identifier_Android_Review						= "com.sdp" ;
	private const string	m_Identifier_Android_Staging					= "com.sdp" ;
	private const string	m_Identifier_Android_Development				= "com.sdp" ;
	private const string	m_Identifier_Android_Profiler					= "com.sdp" ;

	//----------------

	private const string	m_KeyStorePath_Android							= "Build/Android/dbs.keystore" ;
	private const string	m_KeyStorePassword_Android						= "dbs_2020" ;
	private const string	m_KeyStoreAlias_Android							= "dbs_alias" ;
	private const string	m_KeyStoreAliasPassword_Android					= "dbs_2020" ;

	//------------------------------------
	// iOS用

	private const string m_Path_iOS = "Xcode" ;

	private static string VersionName_iOS
	{
		get
		{
			( string versionName, _ ) = GetVersion( PlatformTypes.iOS ) ;
			return versionName ;
		}
	}

	private static int VersionCode_iOS
	{
		get
		{
			( _, int versionCode ) = GetVersion( PlatformTypes.iOS ) ;
			return versionCode ;
		}
	}

	private const string m_ProductName_iOS_Release		= "SDP" ;
	private const string m_ProductName_iOS_Review		= "SDP_R" ;
	private const string m_ProductName_iOS_Staging		= "SDP_S" ;
	private const string m_ProductName_iOS_Development	= "SDP_D" ;
	private const string m_ProductName_iOS_Profiler		= "SDP_P" ;

	//TODO: デフォルトのIdentifier
	private const string m_Identifier_iOS_Release		= "com.sdp" ;
	private const string m_Identifier_iOS_Review		= "com.sdp" ;
	private const string m_Identifier_iOS_Staging		= "com.sdp" ;
	private const string m_Identifier_iOS_Development	= "com.sdp" ;
	private const string m_Identifier_iOS_Profiler		= "com.sdp" ;
}
