using System ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	public partial class CodeGenerator_ObjectExtensions
	{
		// ネームスペースごとに分類
		class TypeCategory
		{
			public string		NameSpace ;
			public List<Type>	Types ;
		}

		/// <summary>
		/// 全オブジェクトのコードを生成する
		/// </summary>
		/// <param name="types"></param>
		public string GenerateCode( Type[] types )
		{
			ExStringBuilder sb = new ExStringBuilder() ;

			// お約束を加える
			sb += "using System ;\n" ;
			sb += "using System.Collections.Generic ;\n" ;
			sb += "\n" ;

			Dictionary<string,List<Type>> typeCategories = new Dictionary<string, List<Type>>() ;

			foreach( var type in types )
			{
				if( typeCategories.ContainsKey( type.Namespace ) == false )
				{
					// 新たなネームスペース
					List<Type> typeCategory = new List<Type>() ;

					typeCategories.Add( type.Namespace, typeCategory ) ;
					typeCategory.Add( type ) ;
				}
				else
				{
					// 既存のネームスペース
					typeCategories[ type.Namespace ].Add( type ) ;
				}
			}

			//-------------------------------------------------------------------------------------------
			// 大ループはネームスペース

			int i0 = 0, l0 = typeCategories.Count ;
			foreach( var typeCategory in typeCategories )
			{
				sb += "namespace " + typeCategory.Key + "\n{\n" ;

				//----------------------------------------------------------
				// 小ループはクラス

				int i1 = 0, l1 = typeCategory.Value.Count ;
				foreach( var type in typeCategory.Value )
				{
					// １オブジェクトのコードを生成する
					PutObjectExtensions( type, sb ) ;

					if( i1 <  ( l1 - 1 ) )
					{
						sb += "\n" ;
					}
					i1 ++ ;
				}

				sb += "}\n" ;

				if( i0 <  ( l0 - 1 ) )
				{
					sb += "\n" ;
				}
				i0 ++ ;
			}

			return sb.ToString() ;
		}

		// １オブジェクトのコードを生成する
		private void PutObjectExtensions( Type type, ExStringBuilder sb )
		{
			string objectCategoryName ;
			if( type.IsClass == true )
			{
				objectCategoryName = "class" ;
			}
			else
			if( type.IsValueType == true && type.IsPrimitive == false && type.IsEnum == false )
			{
				objectCategoryName = "struct" ;
			}
			else
			{
				throw new Exception( message:"Unusable type. Possible types are class or struct." ) ;
			}

			sb += $"\tpublic partial {objectCategoryName} {type.Name}\n" ;
			sb += "\t{\n" ;

			//----------------------------------------------------------

			// オブジェクトの定義情報を取得する(Unity の Editor モードで実行される可能性があるためキャッシュに貯めない)
			var objectDefinition = m_ObjectDefinitionCache.Create( type ) ;

			// シリアライザを出力する
			PutSerializer( objectDefinition, ref sb ) ;

			// デシリアライザを出力する
			PutDeserializer( objectDefinition, ref sb ) ;

			sb += "\t}\n" ;
		}
	}
}
