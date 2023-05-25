using System ;

//using UnityEngine ;

/// <summary>
/// シンプルメッセージパックの対象にするクラスに付与する属性
/// </summary>
public class SimpleDataPackObjectAttribute : Attribute
{
	public SimpleDataPackObjectAttribute(){}
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

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class SimpleDataPackUnionAttribute : Attribute
{
	public readonly Type	GroupType ;
	public readonly	int		Code ;

	public SimpleDataPackUnionAttribute( Type groupType )
	{
		this.GroupType	= groupType ;
	}

	public SimpleDataPackUnionAttribute( int code, Type groupType )
	{
		this.GroupType	= groupType ;
		this.Code		= code ;
	}
}
