using System ;

//using UnityEngine ;

/// <summary>
/// シンプルメッセージパックの対象にするクラスに付与する属性
/// </summary>
public class SimpleDataPackObjectAttribute : Attribute
{
	public readonly bool KeyAsCode		= false ;

	public SimpleDataPackObjectAttribute( bool keyAsCode = false )
	{
		this.KeyAsCode		= keyAsCode ;
	}
}

/// <summary>
/// シンプルメッセージパックの対象にするフィールドに付与する属性
/// </summary>
public class SimpleDataPackMemberAttribute : Attribute
{
	public readonly bool	IsMember	= true ;	// デフォルトは使用定義すれば使用扱いになる
	public readonly int		Code		= 0 ;

	public SimpleDataPackMemberAttribute()
	{
		this.IsMember	= true ;
		this.Code		= 0 ;
	}

	public SimpleDataPackMemberAttribute( bool isMember )
	{
		this.IsMember	= isMember ;
	}

	public SimpleDataPackMemberAttribute( int code, bool isMember = true )
	{
		this.IsMember	= isMember ;
		this.Code		= code ;
	}
}
