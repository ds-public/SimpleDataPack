using System ;
using System.Text ;

using UnityEngine ;

public partial class SimpleDataPack
{
	/// <summary>
	/// Ｊｓｏｎ変換
	/// </summary>
	partial class JsonConverter
	{
		/// <summary>
		/// パーサー
		/// </summary>
		public class JsonParser
		{
			private string		m_Json ;
			private int			m_Offset ;

			private StringBuilder m_SB ;

			//----------------------------------------------------------

			public JsonParser( ReadOnlySpan<byte> data )
			{
				Initialize( Encoding.UTF8.GetString( data.ToArray() ) ) ;
			}

			public JsonParser( string json )
			{
				Initialize( json ) ;
			}

			private void Initialize( string json )
			{
				json = json.Replace( "\t", "" ) ;
				json = json.Replace( "\n", "" ) ;

				m_Json = json ;

				m_SB = new StringBuilder() ;
			}

			//----------------------------------------------------------


			// トークンの名前を取得する
			public string GetTokenName()
			{
				// トークンの名前を取得する(Null は不可)
				string name = GetString() ;

				//-----------------------------------
				// 名称が合致する

				char c = GetCode() ;
				if( c != ':' )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				return name ;
			}

			//-----------------------------------------------------------

			// ブール値を取得する
			public bool  GetBoolean()
			{
				if( IsMatch( "true", true ) == true )
				{
					// true
					return true ;
				}

				if( IsMatch( "false", true ) == true )
				{
					// false
					return false ;
				}

				// 取得不可
				throw new Exception( "Invalid json text." ) ;
			}

			public System.Byte GetByte()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Byte.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Byte : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.SByte GetSByte()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.SByte.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to SByte : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.Char GetChar()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				// 数値を Char にするには一旦 UInt16 にしてキャストする必要がある
				if( System.UInt16.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Char : numberString = " + numberString ) ;
				}
				return ( System.Char )value ;
			}

			public System.Int16 GetInt16()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Int16.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Int16 : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.UInt16 GetUInt16()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.UInt16.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to UInt16 : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.Int32 GetInt32()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Int32.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Int32 : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.UInt32 GetUInt32()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.UInt32.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to UInt32 : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.Int64 GetInt64()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Int64.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Int64 : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.UInt64 GetUInt64()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.UInt64.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to UInt64 : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.Single GetSingle()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Single.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Single : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.Double GetDouble()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Double.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Double : numberString = " + numberString ) ;
				}
				return value ;
			}

			public System.Decimal GetDecimal()
			{
				string numberString = GetNumberString() ;

				//-----------------------------------

				if( System.Decimal.TryParse( numberString, out var value ) == false )
				{
					throw new Exception( message:"Could not parse to Decimal : numberString = " + numberString ) ;
				}
				return value ;
			}

			// 数値部分の文字列を取得する
			private string GetNumberString()
			{
				int l = m_Json.Length ;

				if( m_Offset >= l )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				//----------------------------------

				char c ;

				c = m_Json[ m_Offset ] ;

				if( !( c >= '0' && c <= '9' || c == '+' || c == '-' || c == '.' ) )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				bool isSign = false ;
				bool isDecimal = false ;
				int  integerCount = 0 ;
				int  decimalCount = 0 ;

				int p, e = -1 ;
				for( p  = m_Offset ; p <  l ; p ++ )
				{
					c = m_Json[ p ] ;

					if( c == '+' || c == '-' )
					{
						if( p != m_Offset || isSign == true )
						{
							// 取得不可
							throw new Exception( "Invalid json text." ) ;
						}

						isSign = true ;
					}
					else
					if( c >= '0' && c <= '9' )
					{
						if( isDecimal == false )
						{
							integerCount ++ ;
						}
						else
						{
							decimalCount ++ ;
						}
					}
					else
					if( c == '.' )
					{
						if( isDecimal == true )
						{
							// 取得不可
							throw new Exception( "Invalid json text." ) ;
						}

						isDecimal = true ;
					}
					else
					{
						e = p ;
						break ;
					}
				}

				if( e <  0 || e == m_Offset )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				if( integerCount == 0 && decimalCount == 0 )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				string numberString = m_Json.Substring( m_Offset, e - m_Offset ) ;

				m_Offset = e ;

				if( m_Json[ m_Offset ] == 'f' || m_Json[ m_Offset ] == 'F' )
				{
					// 浮動小数
					m_Offset ++ ;
				}

				return numberString ;
			}

			// 文字列を取得する
			public string GetString()
			{
				int l = m_Json.Length ;

				if( m_Offset >= l )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				//----------------------------------------------------------

				char c ;

				c = m_Json[ m_Offset ] ;
				m_Offset ++ ;

				if( c != '"' )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				//-----------------------------------------------------------

				if( m_Offset >= l )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				// 終端部分を探す

				bool isEscaping = false ;

				int p, e = -1 ;
				for( p  = m_Offset ; p <  l ; p ++ )
				{
					c = m_Json[ p ] ;

					if( isEscaping == false )
					{
						// エスケープ中ではない
						if( c == '\\' )
						{
							// エスケープ中になる
							isEscaping = true ;
						}
						else
						if( c == '"' )
						{
							// 終端を発見した
							e = p ;
							break ;
						}
					}
					else
					{
						// エスケープ中である

						// エスケープを解除する(エスケープ中にダブルクォーテーションがあっても無視される)
						isEscaping = false ;
					}
				}

				if( e <  0 )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				if( ( m_Offset + 1 ) == e )
				{
					// 空文字(null の場合は null と記述される)
					return string.Empty ;
				}

				string word = m_Json.Substring( m_Offset, e - m_Offset ) ;
				word = DecodeTextEscape( word ) ;

				m_Offset = e + 1 ;

				// 取得
				return word ;
			}

			// 文字列を取得する
			public DateTime GetDateTime()
			{
				int l = m_Json.Length ;

				if( m_Offset >= l )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				//----------------------------------

				char c ;

				c = m_Json[ m_Offset ] ;
				m_Offset ++ ;

				if( c != '"' )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				//-----------------------------------------------------------

				if( m_Offset >= l )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				// 終端部分を探す

				bool isEscaping = false ;

				int p, e = -1 ;
				for( p  = m_Offset ; p <  l ; p ++ )
				{
					c = m_Json[ p ] ;

					if( isEscaping == false )
					{
						// エスケープ中ではない
						if( c == '\\' )
						{
							// エスケープ中になる
							isEscaping = true ;
						}
						else
						if( c == '"' )
						{
							// 終端を発見した
							e = p ;
							break ;
						}
					}
					else
					{
						// エスケープ中である

						// エスケープを解除する(エスケープ中にダブルクォーテーションがあっても無視される)
						isEscaping = false ;
					}
				}

				if( e <  0 )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				if( m_Offset == e )
				{
					// 空文字はエラー
					throw new Exception( "Invalid json text." ) ;
				}

				string word = m_Json.Substring( m_Offset, e - m_Offset ) ;
				word = DecodeTextEscape( word ) ;

				if( DateTime.TryParse( word, out DateTime dateTime ) == false )
				{
					// エラー
					throw new Exception( "Invalid json text." ) ;
				}

				m_Offset = e + 1 ;

				// 取得
				return dateTime ;
			}

			// Null かどうか
			public bool IsNull()
			{
				return IsMatch( "null", true ) ;
			}

			// 文字列のマッチを確認する(基本的に文字数検査は済んでいるので確認はしない)
			private bool IsMatch( string word, bool isMove = false )
			{
				int i, l = word.Length ;

				if( ( m_Offset + l ) >  m_Json.Length )
				{
					return false ;
				}

				for( i  = 0 ; i <  l ; i ++ )
				{
					if( word[ i ] != m_Json[ m_Offset + i ] )
					{
						return false ;
					}
				}

				if( isMove == true )
				{
					// マッチした際にオフセットを移動させる
					m_Offset += word.Length ;
				}

				return true ;
			}


			// １文字分のコードを取得する
			public char GetCode( bool isMove = true )
			{
				int l = m_Json.Length ;

				if( m_Offset >= l )
				{
					// 取得不可
					throw new Exception( "Invalid json text." ) ;
				}

				//---------------------------------

				if( isMove == true )
				{
					m_Offset ++ ;

					return m_Json[ m_Offset - 1 ] ;
				}
				else
				{
					return m_Json[ m_Offset ] ;
				}
			}

			/// <summary>
			/// オフセット位置を１つ移動させる
			/// </summary>
			public void Increase()
			{
				m_Offset ++ ;
			}

			//------------------------------------------------------------------------------------------

			// Json 用のテキストのエスケープ復帰
			private string DecodeTextEscape( string text )
			{
				if( string.IsNullOrEmpty( text ) == true )
				{
					return text ;
				}

				//-----------------------------------------------------------

				bool isEscaping = false ;

				m_SB.Clear() ;

				int i, l = text.Length ;
				for( i  = 0 ; i <  l ; i ++ )
				{
					Char c = text[ i ] ;

					if( isEscaping == false )
					{
						// エスケープ中ではない

						if( c != '\\' )
						{
							// エスケープではない
							m_SB.Append( c ) ;
						}
						else
						{
							// エスケープ中に移行する
							isEscaping = true ;
						}
					}
					else
					{
						// エスケープ中である

						if( c == '"' )
						{
							// ダブルクォーテーション
							m_SB.Append( c ) ;
						}
						else
						if( c == '\\' )
						{
							// バックスラッシュ
							m_SB.Append( c ) ;
						}
						else
						if( c == '/' )
						{
							// スラッシュ
							m_SB.Append( c ) ;
						}
						else
						if( c == 'b' )
						{
							// バックスペース
							m_SB.Append( "\b" ) ;
						}
						else
						if( c == 'f' )
						{
							// 改ページ
							m_SB.Append( "\f" ) ;
						}
						else
						if( c == 'n' )
						{
							// キャリッジリターン(改行)
							m_SB.Append( "\n" ) ;
						}
						else
						if( c == 'r' )
						{
							// ラインフィード
							m_SB.Append( "\r" ) ;
						}
						else
						if( c == 't' )
						{
							// タブ
							m_SB.Append( "\t" ) ;
						}
						else
						if( c == 'u' )
						{
							// コード表記

							int o = i + 1 ;
							if( ( o + 4 ) >  l )
							{
								// 異常
								return m_SB.ToString() ;
							}

							m_SB.Append( HexToChar( text, o ) ) ;

							i += 4 ;
						}

						// エスケープを解除する
						isEscaping = false ;
					}
				}

				return m_SB.ToString() ;
			}

			private char HexToChar( string text, int o )
			{
				int i, l = 4 ;
				char c ;

				System.UInt16 v = 0 ;
				System.UInt16 s = 0 ;

				for( i  = 0 ; i <  l ; i ++ )
				{
					c = text[ o + 3 - i ] ;
					if( c >= '0' && c <= '9' )
					{
						v += ( System.UInt16 )( ( System.UInt16 )( c - '0' ) << s ) ;
					}
					else
					if( c >= 'a' && c <= 'f' )
					{
						v += ( System.UInt16 )( ( System.UInt16 )( c - 'a' + 10 ) << s ) ;
					}
					else
					if( c >= 'A' && c <= 'F' )
					{
						v += ( System.UInt16 )( ( System.UInt16 )( c - 'A' + 10 ) << s ) ;
					}

					s += 4 ;
				}

				return ( char )v ;
			}

		}
	}
}
