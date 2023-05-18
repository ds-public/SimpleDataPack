using System ;

//---------------------------------------------------------------------------------------------
// MessagePack のためのダミー記述

public class MessagePackObjectAttribute : Attribute
{
	public MessagePackObjectAttribute( bool keyAsPropertyName = false )
	{
	}
}

public class KeyAttribute : Attribute
{
	public KeyAttribute( int index )
	{
	}
}

