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
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyObject_W ), new ObjectAdapter_DSW_MyData_MyObject_W() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyObject_W[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyObject_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyObject_W> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyObject_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySampleSub_W ), new ObjectAdapter_DSW_MyData_MySampleSub_W() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MySampleSub_W[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MySampleSub_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MySampleSub_W> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MySampleSub_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W ), new ObjectAdapter_DSW_MyData_MyStruct_W() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyStruct_W> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_W>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W? ), new ObjectAdapter_DSW_MyData_MyStruct_W_Nullable() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyStruct_W?[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyStruct_W?>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyStruct_W?> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyStruct_W?>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyInterface_Type0 ), new ObjectAdapter_DSW_MyData_MyInterface_Type0() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyInterface_Type0[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyInterface_Type0>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyInterface_Type0> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyInterface_Type0>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyInterface_Type1 ), new ObjectAdapter_DSW_MyData_MyInterface_Type1() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyInterface_Type1[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyInterface_Type1>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyInterface_Type1> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyInterface_Type1>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyInterface_Type2 ), new ObjectAdapter_DSW_MyData_MyInterface_Type2() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.MyInterface_Type2[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.MyInterface_Type2>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.MyInterface_Type2> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.MyInterface_Type2>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.IMyInterface ), new ObjectAdapter_DSW_MyData_IMyInterface() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( DSW.MyData.IMyInterface[] ), new SimpleDataPack.Array1DGenericAdapter<DSW.MyData.IMyInterface>() ) ;
		SimpleDataPack.AddToExternalAdapterCache( typeof( List<DSW.MyData.IMyInterface> ), new SimpleDataPack.ListGenericAdapter<DSW.MyData.IMyInterface>() ) ;
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
	class ObjectAdapter_DSW_MyData_MyInterface_Type0 : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MyInterface_Type0 )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MyInterface_Type0() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MyInterface_Type1 : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MyInterface_Type1 )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MyInterface_Type1() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_MyInterface_Type2 : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			writer.PutByte( 1 ) ;
			( ( DSW.MyData.MyInterface_Type2 )entity ).Serialize__SimpleDataPack( writer ) ;
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			if( reader.GetByte() == 0 )
			{
				return null ;
			}
			var entity = new DSW.MyData.MyInterface_Type2() ;
			entity.Deserialize__SimpleDataPack( reader ) ;
			return entity ;
		}
	}
	class ObjectAdapter_DSW_MyData_IMyInterface : SimpleDataPack.IAdapter
	{
		public void Serialize( System.Object entity, SimpleDataPack.ByteStream writer )
		{
			if( entity == null )
			{
				writer.PutByte( 0 ) ;
				return ;
			}
			var _ = entity.GetType() ;
			if( _ == typeof( DSW.MyData.MyInterface_Type0 ) ){  writer.PutVUInt33T( 0 ) ; writer.PutByte( 1 ) ; ( ( DSW.MyData.MyInterface_Type0 )entity ).Serialize__SimpleDataPack( writer ) ; }
			if( _ == typeof( DSW.MyData.MyInterface_Type1 ) ){  writer.PutVUInt33T( 1 ) ; writer.PutByte( 1 ) ; ( ( DSW.MyData.MyInterface_Type1 )entity ).Serialize__SimpleDataPack( writer ) ; }
			if( _ == typeof( DSW.MyData.MyInterface_Type2 ) ){  writer.PutVUInt33T( 2 ) ; writer.PutByte( 1 ) ; ( ( DSW.MyData.MyInterface_Type2 )entity ).Serialize__SimpleDataPack( writer ) ; }
		}
		public System.Object Deserialize( SimpleDataPack.ByteStream reader )
		{
			var _ = reader.GetVUInt33() ;
			if( _ == null )
			{
				return null ;
			}
			var i = ( System.UInt32 )_ ;
			System.Object entity = null ;
			switch( i )
			{
				case 0 : reader.GetByte() ; { var o = new DSW.MyData.MyInterface_Type0() ; o.Deserialize__SimpleDataPack( reader ) ; entity = o ; } break ;
				case 1 : reader.GetByte() ; { var o = new DSW.MyData.MyInterface_Type1() ; o.Deserialize__SimpleDataPack( reader ) ; entity = o ; } break ;
				case 2 : reader.GetByte() ; { var o = new DSW.MyData.MyInterface_Type2() ; o.Deserialize__SimpleDataPack( reader ) ; entity = o ; } break ;
			}
			return entity ;
		}
	}
}
