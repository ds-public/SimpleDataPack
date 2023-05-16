using System ;
using System.Text ;

using UnityEngine ;

public partial class SimpleDataPack
{
	// Ｊｓｏｎ変換処理用
	private static readonly JsonConverter m_JsonConverter = new JsonConverter() ;

	//--------------------------------------------------------------------------------------------

	/// <summary>
	/// Ｊｓｏｎ変換
	/// </summary>
	partial class JsonConverter
	{
		//-----------------------------------------------------------
		// ユーティリティ

		// Json 用のテキストのエスケープ実行
		private string EncodeTextEscape( string text, StringBuilder sb )
		{
#if false
			string o = "ABCDEあいうえお :\t: \\t \\u3042 \" \\\" / \\/" ;
			Debug.Log( "<color=#FFFF00>文字列:" + o + "</color>" ) ;
			Debug.Log( "文字数:" + o.Length ) ;

			string e = EncodeTextEscape( o ) ;
			Debug.Log( "<color=#FF7F00>文字列:" + e + "</color>" ) ;
			Debug.Log( "文字数:" + e.Length ) ;

			string d = DecodeTextEscape( e ) ;
			Debug.Log( "<color=#00FF00>文字列:" + d + "</color>" ) ;
			Debug.Log( "文字数:" + d.Length ) ;
#endif
			//-----------------------------------------------------------

			if( string.IsNullOrEmpty( text ) == true )
			{
				return text ;
			}

			//-----------------------------------------------------------

			sb.Clear() ;

			int i, l = text.Length ;
			for( i  = 0 ; i <  l ; i ++ )
			{
				Char c = text[ i ] ;

				if( c == '"' )
				{
					// ダブルクォーテーション
					sb.Append( "\\\"" ) ;
				}
				else
				if( c == '\\' )
				{
					// バックスラッシュ
					sb.Append( @"\\" ) ;
				}
				else
				if( c == '/' )
				{
					// スラッシュ
					sb.Append( @"\/" ) ;
				}
				else
				if( c == '\b' )
				{
					// バックスペース
					sb.Append( @"\b" ) ;
				}
				else
				if( c == '\f' )
				{
					// 改ページ
					sb.Append( @"\f" ) ;
				}
				else
				if( c == '\n' )
				{
					// キャリッジリターン(改行)
					sb.Append( @"\n" ) ;
				}
				else
				if( c == '\r' )
				{
					// ラインフィード
					sb.Append( @"\r" ) ;
				}
				else
				if( c == '\t' )
				{
					// タブ
					sb.Append( @"\t" ) ;
				}
				else
				if( c >= 0x80 )
				{
					// コード表記
					sb.Append( @"\u" + ( ( System.UInt16 )c ).ToString( "X4" ) ) ;
				}
				else
				{
					// 変換無し
					sb.Append( c ) ;
				}
			}

			return sb.ToString() ;
		}



		//-------------------------------------------------------------------------------------------



	}
}
