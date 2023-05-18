#if UNITY_2019_4_OR_NEWER
#define UNITY
#endif

using System ;

public partial class SimpleDataPack
{
	public class CodeGenerator_ObjectDispatcher
	{
		/// <summary>
		/// 全オブジェクトのコードを生成する
		/// </summary>
		/// <param name="types"></param>
		public string GenerateCode( string objectName, Type[] types )
		{
			ExStringBuilder sb = new ExStringBuilder() ;

			//----------------------------------
#if UNITY
			// プリプロセッサ部を加える
			PutPreprocessor( ref sb ) ;
			sb += "\n" ;
#endif
			//----------------------------------

			// お約束を加える
			sb += "using System ;\n" ;
			sb += "using System.Collections.Generic ;\n" ;
			sb += "\n" ;

			//----------------------------------

			sb += $"public class {objectName} : SimpleDataPack.IExternalAdapter\n" ;
			sb += "{\n" ;

			//----------------------------------------------------------
#if UNITY
			// Unity 用の最速自動実行メソッドの生成
			PutSetAdapter( objectName, ref sb ) ;

			sb += "\n" ;
#endif
			//----------------------------------------------------------

			// アダプター登録メソッド生成
			PutRegister( types, ref sb ) ;

			sb += "\n" ;

			// アダプター定義クラス群生成
			PutAllAdapters( types, ref sb ) ;

			//----------------------------------------------------------

			sb += "}\n" ;

			return sb.ToString() ;
		}

		//-------------------------------------------------------------------------------------------
		// プリプロセッサーの生成
#if UNITY
		private void PutPreprocessor( ref ExStringBuilder sb )
		{
//			sb += "#if UNITY_2019_4_OR_NEWER\n" ;
			sb += "#define UNITY\n" ;
//			sb += "#endif\n" ;
			sb += "\n" ;
			sb += "#if UNITY\n" ;
			sb += "using UnityEngine ;\n" ;
			sb += "#endif\n" ;
		}

		// アダプター設定の生成
		private void PutSetAdapter( string objectName, ref ExStringBuilder sb )
		{
			sb += "#if UNITY\n" ;
			sb += "\t"  + "[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]\n" ; 
			sb += "\t"  + $"public static void SetExternalAdapter()\n" ;
			sb += "\t"  + "{\n" ;
			sb += "\t\t" + $"SimpleDataPack.SetExternalAdapter( new {objectName}() ) ;\n" ;
			sb += "\t"  + "}\n" ;
			sb += "#endif\n" ;
		}
#endif
		//-----------------------------------------------------------

		// アダプター登録メソッド生成
		private void PutRegister( Type[] types, ref ExStringBuilder sb )
		{
			sb += "\t" + $"public void AddToExternalAdapterCache()\n" ;
			sb += "\t" + "{\n" ;

			//----------------------------------------------------------

			foreach( var type in types )
			{
				// 後で Nullable フラグは除去する

				//---------------------------------------------------------
				// シリアライズ

				string methodName = type.FullName.Replace( ".", "_" ) ;

				if( type.IsClass == true )
				{
					// class

					// スカラ
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( {type.FullName} ), new ObjectAdapter_{methodName}() ) ;\n" ;

					// アレイ
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( {type.FullName}[] ), new SimpleDataPack.Array1DGenericAdapter<{type.FullName}>() ) ;\n" ;

					// リスト
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( List<{type.FullName}> ), new SimpleDataPack.ListGenericAdapter<{type.FullName}>() ) ;\n" ;
				}
				else
				{
					// struct

					// スカラ
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( {type.FullName} ), new ObjectAdapter_{methodName}() ) ;\n" ;

					// アレイ
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( {type.FullName}[] ), new SimpleDataPack.Array1DGenericAdapter<{type.FullName}>() ) ;\n" ;

					// リスト
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( List<{type.FullName}> ), new SimpleDataPack.ListGenericAdapter<{type.FullName}>() ) ;\n" ;

					// struct?

					// スカラ
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( {type.FullName}? ), new ObjectAdapter_{methodName}_Nullable() ) ;\n" ;

					// アレイ
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( {type.FullName}?[] ), new SimpleDataPack.Array1DGenericAdapter<{type.FullName}?>() ) ;\n" ;

					// リスト
					sb += "\t\t" + $"SimpleDataPack.AddToExternalAdapterCache( typeof( List<{type.FullName}?> ), new SimpleDataPack.ListGenericAdapter<{type.FullName}?>() ) ;\n" ;
				}
			}

			//----------------------------------------------------------

			sb += "\t" + "}\n" ;
		}


		//-----------------------------------------------------------


		// アダプター定義クラス群生成
		private void PutAllAdapters( Type[] types, ref ExStringBuilder sb )
		{
			foreach( var type in types )
			{
				// 後で Nullable フラグは除去する

				//---------------------------------------------------------
				// シリアライズ

				if( type.IsClass == true )
				{
					// class
					PutAdapter( type, true, string.Empty, ref sb ) ;
				}
				else
				{
					// struct
					PutAdapter( type, false, string.Empty, ref sb ) ;

					// struct?
					PutAdapter( type, true, "_Nullable", ref sb ) ;
				}
			}
		}

		private void PutAdapter( Type type, bool isNullable, string signature, ref ExStringBuilder sb )
		{
			string methodName = type.FullName.Replace( ".", "_" ) ;

			sb += "\t" + $"class ObjectAdapter_{methodName}{signature} : SimpleDataPack.IAdapter\n" ;
			sb += "\t" + "{" + "\n" ;

			//--------------

			// Serialize
			sb += "\t\t" + "public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )\n" ;
			sb += "\t\t" + "{\n" ;

			if( isNullable == true )
			{
				sb += "\t\t\t" + "if( entity == null )\n" ;
				sb += "\t\t\t" + "{\n" ;
				sb += "\t\t\t\t" + "writer.PutByte( 0 ) ;\n" ;
				sb += "\t\t\t\t" + "return ;\n" ;
				sb += "\t\t\t" + "}\n" ;
				sb += "\t\t\t" + "writer.PutByte( 1 ) ;\n" ;
			}

			sb += "\t\t\t" + $"( ( {type.FullName} )entity ).Serialize__SimpleDataPack( writer ) ;\n" ;
			sb += "\t\t" + "}\n" ;

			// Deserialize
			sb += "\t\t" + "public System.Object Deserialize( SimpleDataPack.ByteStream reader )\n" ;
			sb += "\t\t" + "{\n" ;

			if( isNullable == true )
			{
				sb += "\t\t\t" + "if( reader.GetByte() == 0 )\n" ;
				sb += "\t\t\t" + "{\n" ;
				sb += "\t\t\t\t" + "return null ;\n" ;
				sb += "\t\t\t" + "}\n" ;
			}

			sb += "\t\t\t" + $"var entity = new {type.FullName}() ;\n" ;
			sb += "\t\t\t" + "entity.Deserialize__SimpleDataPack( reader ) ;\n" ;
			sb += "\t\t\t" + "return entity ;\n" ;
			sb += "\t\t" + "}\n" ;

			//--------------

			sb += "\t" + "}\n" ;
		}
	}
}
