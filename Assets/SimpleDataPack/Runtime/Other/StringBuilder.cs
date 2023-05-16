using System.Text ;

using UnityEngine ;

public partial class SimpleDataPack
{
	public class ExStringBuilder
	{
		private readonly StringBuilder m_StringBuilder ;
		private readonly StringBuilder m_StringBuilderEscape ;

		public ExStringBuilder()
		{
			m_StringBuilder			= new StringBuilder() ;
			m_StringBuilderEscape	= new StringBuilder() ;
		}

		public int Length
		{
			get
			{
				return m_StringBuilder.Length ;
			}
		}

		public int Count
		{
			get
			{
				return m_StringBuilder.Length ;
			}
		}

		public void Clear()
		{
			m_StringBuilder.Clear() ;
		}

		public override string ToString()
		{
			return m_StringBuilder.ToString() ;
		}
		
		public void Append( string s )
		{
			m_StringBuilder.Append( s ) ;
		}

		// これを使いたいがためにラッパークラス化
		public static ExStringBuilder operator + ( ExStringBuilder sb, string s )
		{
			sb.Append( s ) ;
			return sb ;
		}

		public StringBuilder Escape	=> m_StringBuilderEscape ;
	}
}

