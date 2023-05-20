using System ;
using System.Collections.Generic ;

using UnityEngine ;

public partial class SimpleDataPack
{
	public partial class CodeGenerator_ObjectExtensions
	{
		//-------------------------------------------------------------------------------------------
		// デシリアライズ関係

		// デシリアライズのコードを生成する
		private void PutDeserializer( ObjectDefinition objectDefinition, ref ExStringBuilder sb )
		{
			sb += "\t\t" + "public void Deserialize__SimpleDataPack( SimpleDataPack.ByteStream reader )\n" ;
			sb += "\t\t" + "{\n" ;

			foreach( var member in objectDefinition.Members )
			{
				string originTypeName	= GetTypeName( member.Type, notNull:false ) ;
				string typeName			= GetTypeName( member.ObjectType, notNull:true ) ;
				string N = member.IsNullable == false ? string.Empty : "N" ;
				string Q = member.IsNullable == false ? string.Empty : "?" ; 

				switch( member.ValueType )
				{
					case ValueTypes.Array :
						// ビルトインアダプターへのショートカットを行うためコード生成には専用のメソッドを用いる
						PutDeserializer_Array( member.Name, member.Type, ref sb ) ;
					break ;

					case ValueTypes.List :
						// ビルトインアダプターへのショートカットを行うためコード生成には専用のメソッドを用いる
						PutDeserializer_List( member.Name, member.Type, ref sb ) ;
					break ;

					case ValueTypes.Dictionary :
						// 汎用を使用(ビルトインアダプターにヒットする可能性があるため)
						sb += "\t\t\t" + $"{member.Name} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					break ;

					//------------

					case ValueTypes.Object :
						// 少しだけ処理を削減　※ SimpledataPacker.PutObject( {member.Name} ) ; でも結果として同じ処理にはなる
						if( member.ObjectIsClass == true || member.IsNullable == true )
						{
							// class or struct?
							sb += "\t\t\t" + $"{member.Name} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
						}
						else
						{
							// struct ※常な存在するので new は不要
							sb += "\t\t\t" + $"{member.Name}.Deserialize__SimpleDataPack( reader ) ;\n" ;
						}
					break ;

					//------------

					case ValueTypes.Enum :
						// 注意 : Nullable<Enum> は Enum.ToObject が使用できない
						if( member.IsNullable == false )
						{
							sb += "\t\t\t" + $"{member.Name} = ( {originTypeName} )Enum.ToObject( typeof( {originTypeName} ), reader.Get{member.ObjectTypeCode}() ) ; \n" ;
						}
						else
						{
							sb += "\t\t\t" + "{ " + $"var _ = reader.Get{member.ObjectTypeCode}{N}() ; {member.Name} = _ == null ? null : ( {originTypeName} )Enum.ToObject( typeof( {typeName} ), ( {member.ObjectTypeCode} )_ ) ; " + "}\n" ;
						}
					break ;
					case ValueTypes.Boolean :
					case ValueTypes.Byte :
					case ValueTypes.SByte :
					case ValueTypes.Char :
					case ValueTypes.Int16 :
					case ValueTypes.UInt16 :
					case ValueTypes.Int32 :
					case ValueTypes.UInt32 :
					case ValueTypes.Int64 :
					case ValueTypes.UInt64 :
					case ValueTypes.Single :
					case ValueTypes.Double :
					case ValueTypes.Decimal :
					case ValueTypes.DateTime :
						sb += "\t\t\t" + $"{member.Name} = reader.Get{member.ValueType}{N}() ;\n" ;
					break ;
					case ValueTypes.String :
							sb += "\t\t\t" + $"{member.Name} = reader.Get{member.ValueType}() ;\n" ;
					break ;
				}
			}

			sb += "\t\t" + "}\n" ;
		}

		//-------------------------------------------------------------------------------------------
		// デシリアライズ・アレイ

		private void PutDeserializer_Array( string memberName, Type type, ref ExStringBuilder sb )
		{
			// Nullable 除去前のタイプ名を取得する
			string originTypeName = GetTypeName( type, notNull:false ) ;

			// 不要な Nullable があれば除去する
			if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				type = Nullable.GetUnderlyingType( type ) ;
			}

			//----------------------------------------------------------

			var	elementOriginType	= type.GetElementType() ;
			var elementType			= elementOriginType ;

			bool isElementNullable = false ;
			if( elementType.IsGenericType == true && elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				isElementNullable = true ;
				elementType = Nullable.GetUnderlyingType( elementType ) ;
			}

			string elementOriginTypeName = GetTypeName( elementOriginType ) ;

			int rank = type.GetArrayRank() ;

			string rankCode = "N" ;
			if( rank <= 4 )
			{
				rankCode = rank.ToString() ;
			}

			TypeCode elementTypeCode = Type.GetTypeCode( elementType ) ;
			string N = isElementNullable == false ? string.Empty : "N" ;

			//----------------------------------------------------------

			if( elementType.IsArray == true )
			{
				// 要素がアレイ型は汎用(ビルトインアダプターにヒットする可能性があるため)
//				sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
				sb += "\t\t\t" + $"{memberName} = SimpleDataPack.Array{rankCode}DGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
			}
			else
			if( elementType.IsGenericType == true )
			{
				// ジェネリック

				if( elementType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// 要素がリスト型は汎用(ビルトインアダプターにヒットする可能性があるため)
//					sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					sb += "\t\t\t" + $"{memberName} = SimpleDataPack.Array{rankCode}DGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// 要素がディクショナリ型は汎用(ビルトインアダプターにヒットする可能性があるため)
//					sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					sb += "\t\t\t" + $"{memberName} = SimpleDataPack.Array{rankCode}DGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
				}
				else
				{
					// その他のジェネリックは許容していない
					throw new Exception( message:"This type is not supported : " + elementType.Name ) ;
				}
			}
			else
			{
				// １次元の場合はビルトインアダプターを使用して高速化
					
				if
				(
					(
						// class
						elementType.IsClass == true  &&
						elementType != typeof( System.String )		// 除外
					)
					||
					(
						// struct
						elementType.IsClass == false &&
						elementType.IsValueType == true &&
						elementType.IsPrimitive == false &&
						elementType.IsEnum == false &&
						elementType != typeof( System.Decimal ) &&	// 除外
						elementType != typeof( System.DateTime )	// 除外
					)
				)
				{
					// 要素がオブジェクト(class struct? struct ※メンバーが存在するもの)

//					sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					sb += "\t\t\t" + $"{memberName} = SimpleDataPack.Array{rankCode}DGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;

					// ※１次元であれば任意のオブジェクト型も高速処理が可能
				}
				else
				{
					// プリミティブ(トップレベルからの直接呼び出しでないとここには来ない)
					// entity が null である事は無い

					if( elementType.IsEnum == true )
					{
						// 列挙子(列挙子はアダプターにヒットしないため別処理を施す必要がある)
//						sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
						sb += "\t\t\t" + $"{memberName} = SimpleDataPack.Array{rankCode}DEnum{N}Adapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
					}
					else
					{
						// プリミティブ

						sb += "\t\t\t" + $"{memberName} = SimpleDataPack.BuiltInAdapter.Array{rankCode}D{elementTypeCode}{N}.DeserializeT( reader ) ;\n" ;
					}
				}
			}
		}

		//-------------------------------------------------------------------------------------------
		// デシリアライズ・リスト

		private void PutDeserializer_List( string memberName, Type type, ref ExStringBuilder sb )
		{
			// Nullable 除去前のタイプ名を取得する
			string originTypeName = GetTypeName( type, notNull:false ) ;

			// 不要な Nullable があれば除去する
			if( type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				type = Nullable.GetUnderlyingType( type ) ;
			}

			//----------------------------------------------------------

			// objectType は List 型である事に注意
			var types = type.GenericTypeArguments ;
			if( types == null || types.Length != 1 )
			{
				// 複数のジェネリックの場合はスルーされる
				throw new Exception( message:"Only one argument of list type is valid." ) ;
			}

			var elementOriginType	= types[ 0 ] ;
			var elementType			= elementOriginType ;

			bool isElementNullable = false ;
			if( elementType.IsGenericType == true && elementType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
			{
				isElementNullable = true ;
				elementType = Nullable.GetUnderlyingType( elementType ) ;
			}

			string elementOriginTypeName	= GetTypeName( elementOriginType ) ;

			TypeCode elementTypeCode = Type.GetTypeCode( elementType ) ;
			string N = isElementNullable == false ? string.Empty : "N" ;

			//----------------------------------------------------------

			if( elementType.IsArray == true )
			{
				// 要素がアレイ型は汎用(ビルトインアダプターにヒットする可能性があるため)
//				sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
				sb += "\t\t\t" + $"{memberName} = SimpleDataPack.ListGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
			}
			else
			if( elementType.IsGenericType == true )
			{
				// ジェネリック

				if( elementType.GetGenericTypeDefinition() == typeof( List<> ) )
				{
					// 要素がリスト型は汎用(ビルトインアダプターにヒットする可能性があるため)
//					sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					sb += "\t\t\t" + $"{memberName} = SimpleDataPack.ListGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
				}
				else
				if( elementType.GetGenericTypeDefinition() == typeof( Dictionary<,> ) )
				{
					// 要素がディクショナリ型は汎用(ビルトインアダプターにヒットする可能性があるため)
//					sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					sb += "\t\t\t" + $"{memberName} = SimpleDataPack.ListGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
				}
				else
				{
					// その他のジェネリックは許容していない
					throw new Exception( message:"This type is not supported : " + elementType.Name ) ;
				}
			}
			else
			{
				if
				(
					(
						// class
						elementType.IsClass == true  &&
						elementType != typeof( System.String )		// 除外
					)
					||
					(
						// struct
						elementType.IsClass == false &&
						elementType.IsValueType == true &&
						elementType.IsPrimitive == false &&
						elementType.IsEnum == false &&
						elementType != typeof( System.Decimal ) &&	// 除外
						elementType != typeof( System.DateTime )	// 除外
					)
				)
				{
					// 要素がオブジェクト(class struct? struct ※メンバーが存在するもの)

//					sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
					sb += "\t\t\t" + $"{memberName} = SimpleDataPack.ListGenericAdapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;

					// ※１次元であれば任意のオブジェクト型も高速処理が可能
				}
				else
				{
					// プリミティブ(トップレベルからの直接呼び出しでないとここには来ない)
					// entity が null である事は無い

					if( elementType.IsEnum == true )
					{
						// 列挙子(列挙子はアダプターにヒットしないため別処理を施す必要がある)
//						sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.GetAnyObject( typeof( {originTypeName} ), reader ) ;\n" ;
						sb += "\t\t\t" + $"{memberName} = SimpleDataPack.ListEnum{N}Adapter<{elementOriginTypeName}>.GetObject( reader ) ;\n" ;
					}
					else
					{
						// プリミティブ

						sb += "\t\t\t" + $"{memberName} = ( {originTypeName} )SimpleDataPack.BuiltInAdapter.ListPrimitive_{elementTypeCode}{N}.Deserialize( reader ) ;\n" ;
					}
				}
			}
		}
	}
}
