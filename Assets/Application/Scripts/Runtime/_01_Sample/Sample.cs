using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Text.RegularExpressions ;
using UnityEngine ;

using Cysharp.Threading.Tasks ;

using uGUIHelper ;

namespace DSW.Screens
{
	/// <summary>
	/// テンプレートスクリーンのコントロールクラス
	/// </summary>
	public class Sample : ExMonoBehaviour
	{
		internal async UniTask Start()
		{
			//----------------------------------------------------------

			//--------------------------------------------------------------------------
			// SimpleDataPack のテスト

			var sdpt = new SimpleDataPackTester( this ) ;
//			await sdpt.RunDebug<List<MyData.MySample_W>>() ;
//			await sdpt.RunDebug<MyData.MySample_W[]>() ;
			await sdpt.RunDebug<MyData.MyStruct_W[]>() ;

			await Yield() ;
		}
	}


	//--------------------------------------------------------------------------------------------
}

