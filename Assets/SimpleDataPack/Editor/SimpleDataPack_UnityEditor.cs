using System ;
using System.Collections.Generic ;
using System.IO ;
using System.Linq ;

using UnityEngine ;
using UnityEditor ;

public class SimpleDataPack_UnityEditor : EditorWindow
{
	/// <summary>
	/// View 生成
	/// </summary>
	[ MenuItem( "SimpleDataPack/GenerateCode" ) ]
	protected static void OpenWindow()
	{
		var window = EditorWindow.GetWindow<SimpleDataPack_UnityEditor>( false, "SimpleDataPack", true ) ;
		window.minSize = new Vector2( 480, 240 ) ;
	}

	//-------------------------------------------------------------------------------------------

	private string	m_OutputPath = "Assets/" ;

	private string	m_ObjectName = "SimpleDataPackAdapter" ;

	//--------------------------------------------------------------------------------------------

	// レイアウトを描画する
	internal void OnGUI()
	{
		EditorGUILayout.HelpBox( GetMessage( "Output Path" ), MessageType.Info ) ;

		// 保存先のパスの設定
		GUILayout.BeginHorizontal() ;
		{
			// 保存パスを選択する
			if( GUILayout.Button( "Output Path", GUILayout.Width( 80f ) ) == true )
			{
				if( Selection.objects != null && Selection.objects.Length == 0 && Selection.activeObject == null )
				{
					// ルート
					m_OutputPath = "Assets/" ;
				}
				else
				if( Selection.objects != null && Selection.objects.Length == 1 && Selection.activeObject != null )
				{
					string path = AssetDatabase.GetAssetPath( Selection.activeObject.GetInstanceID() ) ;
					if( Directory.Exists( path ) == true )
					{
						// フォルダを指定しています
						
						// ファイルかどうか判別するには System.IO.File.Exists
						
						// 有効なフォルダ
						path = path.Replace( "\\", "/" ) ;
						m_OutputPath = path + "/" ;
					}
					else
					{
						// ファイルを指定しています
						path = path.Replace( "\\", "/" ) ;
						m_OutputPath = path ;

						// 拡張子を見てアセットバンドルであればファイル名まで置き変える
						// ただしこれを読み出して含まれるファイルの解析などは行わない
						// なぜなら違うプラットフォームの場合は読み出せずにエラーになってしまうから
						
						// 最後のフォルダ区切り位置を取得する
						int index = m_OutputPath.LastIndexOf( '/' ) ;
						if( index >= 0 )
						{
							m_OutputPath = m_OutputPath.Substring( 0, index ) + "/" ;
						}
					}
				}
			}
			
			// 保存パス
			m_OutputPath = EditorGUILayout.TextField( m_OutputPath ) ;
		}
		GUILayout.EndHorizontal() ;

		//-----------------------------------------------------------

		// コンバートツールのパスを設定する
		EditorGUILayout.HelpBox( GetMessage( "Object Name" ), MessageType.Info ) ;
		m_ObjectName = EditorGUILayout.TextField( m_ObjectName ) ;

		//-------------------------------------------------------------------------------------------

		bool execute = false ;

		if( string.IsNullOrEmpty( m_OutputPath ) == false && Directory.Exists( m_OutputPath ) == true && string.IsNullOrEmpty( m_ObjectName ) == false )
		{
			EditorGUILayout.Separator() ;
			
			GUI.backgroundColor = Color.green ;
			execute = GUILayout.Button( "GENERATE" ) ;
			GUI.backgroundColor = Color.white ;

			EditorGUILayout.HelpBox( GetMessage( "For Exsample" ) + "\n" + $"SimpleDataPack.SetAdapter( new {m_ObjectName}() ) ;", MessageType.Info ) ;
		}

		//-------------------------------------------------------------------------------------------

		if( execute == true )
		{
			GenerateCode( m_OutputPath ) ;
		}
	}

	internal void OnSelectionChange() 
	{
		Repaint() ;
	}
	
	//--------------------------------------------------------------------------

	private readonly Dictionary<string,string> m_Japanese_Message = new Dictionary<string, string>()
	{
		{ "Output Path",		"保存先のフォルダを設定してください" },
		{ "Object Name",		"自動生成コードのオブジェクト名を設定してください" },
		{ "For Exsample",		"以下のコードをプログラムに追加してください" },			
	} ;
	private readonly Dictionary<string,string> m_English_Message = new Dictionary<string, string>()
	{
		{ "Output Path",		"Please set the destination folder." },
		{ "Object Name",		"Set object name for auto-generated code." },
		{ "For Exsample",		"Add the following code to your program." },			
	} ;

	private string GetMessage( string label )
	{
		if( Application.systemLanguage == SystemLanguage.Japanese )
		{
			if( m_Japanese_Message.ContainsKey( label ) == false )
			{
				return "指定のラベル名が見つかりません" ;
			}
			return m_Japanese_Message[ label ] ;
		}
		else
		{
			if( m_English_Message.ContainsKey( label ) == false )
			{
				return "Specifying the label name can not be found" ;
			}
			return m_English_Message[ label ] ;
		}
	}

	/// <summary>
	/// 高速処理版の自動生成コードを出力する(コマンドライン用)
	/// </summary>
	public static void GenerateCode()
	{
		string[] args = Environment.GetCommandLineArgs() ;

		if( args == null || args.Length <  2 )
		{
			Debug.LogWarning( "[Argument Error] The following description is required : --o <Output Path>" ) ;
			return ;
		}

		if( args[ 0 ] != "--o" )
		{
			Debug.LogWarning( "[Argument Error] The following description is required : --o <Output Path>" ) ;
			return ;
		}

		string outputPath = args[ 1 ] ;

		//-----------------------------------

		string objectName = "SimpleDataPackAdapter" ;
		if( args != null && args.Length >= 4 )
		{
			if( args[ 2 ] == "--n" )
			{
				objectName = args[ 3 ] ;
			}
		}

		//-----------------------------------

		GenerateCode( outputPath, objectName ) ;
	}

	/// <summary>
	/// 指定したパスに対して高速処理版の自動生成コードを出力する
	/// </summary>
	/// <param name="outputPath"></param>
	public static void GenerateCode( string outputPath, string objectName = "SimpleDataPackAdapter" )
	{
		List<Type> types = new List<Type>() ;

		// 指定したアトリビュートが付いている型を取得
		var c_types = TypeCache.GetTypesWithAttribute<SimpleDataPackObjectAttribute>() ;
		if( c_types.Count >  0 )
		{
			types.AddRange( c_types.ToArray() ) ;
		}

		var i_types = TypeCache.GetTypesWithAttribute<SimpleDataPackUnionAttribute>() ;
		if( i_types.Count >  0 )
		{
			types.AddRange( i_types.ToArray() ) ;
		}

#if false
		foreach( var type in types )
		{
			Debug.Log
			(
				$"名前:{type.Name}" + "\n" +
				$"名前空間:{type.Namespace}" + "\n" +
				$"完全限定名:{type.FullName}" + "\n" + 
				$"このメンバを宣言するクラス:{type.DeclaringType}" + "\n" +
				$"直接の継承元:{type.BaseType}" + "\n" +
				$"属性:{type.Attributes}"
			) ;
		}
#endif
		SimpleDataPack.GenerateCode( objectName, types.ToArray(), outputPath ) ;

		AssetDatabase.SaveAssets() ;
		AssetDatabase.Refresh() ;
	}

	//--------------------------------------------------------------------------------------------
	// 参考

#if false
	// 指定したアトリビュートが付いているプロパティを取得
	TypeCache.GetMethodsWithAttribute<FooAttribute>();

	// 指定したアトリビュートが付いているフィールドを取得（2020.1a19から）
	TypeCache.GetFieldsWithAttribute<FooAttribute>();

	// 指定したアトリビュートが付いている型を取得
	TypeCache.GetTypesWithAttribute<FooAttribute>();

	// 指定した型を継承またはまたはインターフェースを実装している型を取得
	TypeCache.GetTypesDerivedFrom<FooAttribute>();
#endif
}
