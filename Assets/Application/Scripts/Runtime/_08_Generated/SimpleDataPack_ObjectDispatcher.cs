#define UNITY

#if UNITY
using UnityEngine ;
#endif

using System ;
using System.Collections.Generic ;

public class SimpleDataPackAdapter : SimpleDataPack.IExternalAdapter
{
#if UNITY
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void SetExternalAdapter()
	{
		SimpleDataPack.SetExternalAdapter( new SimpleDataPackAdapter() ) ;
	}
#endif

	public void AddToExternalAdapterCache()
	{
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_B ), new ObjectAdapter_DSW_MyData_MyStruct_B() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_B[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_B>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyStruct_B> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_B>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_B? ), new ObjectAdapter_DSW_MyData_MyStruct_B_Nullable() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_B?[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_B?>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyStruct_B?> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_B?>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySample_B ), new ObjectAdapter_DSW_MyData_MySample_B() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySample_B[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySample_B>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MySample_B> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MySample_B>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySampleSub_B ), new ObjectAdapter_DSW_MyData_MySampleSub_B() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySampleSub_B[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_B>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MySampleSub_B> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_B>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W ), new ObjectAdapter_DSW_MyData_MyStruct_W() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyStruct_W> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W? ), new ObjectAdapter_DSW_MyData_MyStruct_W_Nullable() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W?[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_W?>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyStruct_W?> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_W?>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyObject_W ), new ObjectAdapter_DSW_MyData_MyObject_W() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyObject_W[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyObject_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyObject_W> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyObject_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySampleSub_W ), new ObjectAdapter_DSW_MyData_MySampleSub_W() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySampleSub_W[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MySampleSub_W> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_W>() ) ;
	}

	class ObjectAdapter_DSW_MyData_MyStruct_B : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			( ( DSW.MyData.MyStruct_B )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			var entity = new DSW.MyData.MyStruct_B() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MyStruct_B_Nullable : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MyStruct_B )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MyStruct_B() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MySample_B : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MySample_B )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MySample_B() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MySampleSub_B : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MySampleSub_B )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MySampleSub_B() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MyStruct_W : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			( ( DSW.MyData.MyStruct_W )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			var entity = new DSW.MyData.MyStruct_W() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MyStruct_W_Nullable : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MyStruct_W )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MyStruct_W() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MyObject_W : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MyObject_W )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MyObject_W() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MySampleSub_W : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MySampleSub_W )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MySampleSub_W() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
}
