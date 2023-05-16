using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Text ;

using UnityEngine ;

using Cysharp.Threading.Tasks ;

//using MessagePack ;

using uGUIHelper ;

using StorageHelper ;


namespace DSW.MyData
{
	//--------------------------------------------------------------------------------------------
	// 手動生成

	public enum Status_W : byte
	{
		Strength		= 251,
		Intelligence	= 252,
		Mind			= 253,
		Agility			= 254,
		Vitality		= 255,
	}


	[SimpleDataPackObject(keyAsCode:true)][MessagePackObject][Serializable]
	public partial struct MyStruct_W
	{
		// コンストラクタ
		public MyStruct_W( byte a_param )
		{
			A_Param = a_param ;
			B_Param = DateTime.Now ;
			C_Param = "あいうえお" ;
		}


/*
		[SimpleDataPackMember(0)][Key(0)]
		public byte A_Param ;

		[SimpleDataPackMember(1)][Key(1)]
		public DateTime B_Param ;

		[SimpleDataPackMember(2)][Key(2)]
		public string C_Param ;
*/
		[SimpleDataPackMember(0)][Key(0)]
		public byte A_Param{ get ; private set ; }

		[SimpleDataPackMember(1)][Key(1)]
		public DateTime B_Param{ get ; private set ; }

		[SimpleDataPackMember(2)][Key(2)]
		public string C_Param{ get ; private set ; }

		//-----------------------------------

		public void Modify_1()
		{
			A_Param = 111 ;
			B_Param = DateTime.Now ;
			C_Param = "うんちょ" ;
		}
	}



	[SimpleDataPackObject(keyAsCode:true)][MessagePackObject(keyAsPropertyName:false)][Serializable]
	public partial class MySample_W
	{
		// コンストラクタ
		public MySample_W()
		{
/*			int i, l = P000.Length ;
			for( i  = 0 ; i <  l ; i ++ )
			{
				P000[ i ] = 0xFFFFFFFF ;
			}

			l = 100 ;
			for( i  = 0 ; i <  l ; i ++ )
			{
				P001.Add( 0xFFFFFFFF ) ;
			}
*/
/*			int i, l = P115.Length ;
			for( i  = 0 ; i <  l ; i ++ )
			{
				P115[ i ] = 0xFFFFFFFF ;
			}

			l = 1000000 ;
			for( i  = 0 ; i <  l ; i ++ )
			{
				P116.Add( 0xFFFFFFFF ) ;
			}*/
		}



/*		[SimpleDataPackMember(0)][Key(0)][SerializeField]
		public System.UInt32[] P000 = new System.UInt32[ 100 ] ;

		[SimpleDataPackMember(1)][Key(1)][SerializeField]
		public List<System.UInt32?> P001 = new List<System.UInt32?>() ; 
*/




		//-----------------------------------------------------------

		[SimpleDataPackMember(0)][Key(0)][SerializeField]
//		public bool P0 = false ;
		public bool P0{ get ; private set ; } = false ;

		[SimpleDataPackMember(1)][Key(1)][SerializeField]
//		public byte P1 = 255 ; 
		public byte P1{ get ; private set ; } = 255 ; 

		[SimpleDataPackMember(2)][Key(2)][SerializeField]
//		public sbyte P2 = -128 ; 
		public sbyte P2{ get ; private set ; } = -128 ; 

		[SimpleDataPackMember(3)][Key(3)][SerializeField]
//		public char P3 = 'あ' ; 
		public char P3{ get ; private set ; } = 'あ' ; 

		[SimpleDataPackMember(4)][Key(4)][SerializeField]
//		public short P4 = -32768 ; 
		public short P4{ get ; private set ; } = -32768 ; 

		[SimpleDataPackMember(5)][Key(5)][SerializeField]
//		public int P5 = 65535 ; 
		public int P5{ get ; private set ; } = 65535 ; 

		[SimpleDataPackMember(6)][Key(6)][SerializeField]
//		public int P6 = -1000000000 ; 
		public int P6{ get ; private set ; } = -1000000000 ; 

		[SimpleDataPackMember(7)][Key(7)][SerializeField]
//		public uint P7 = 1000000000 ; 
		public uint P7{ get ; private set ; } = 1000000000 ; 

		[SimpleDataPackMember(8)][Key(8)][SerializeField]
//		public long P8 = -1000000000000000000 ; 
		public long P8{ get ; private set ; } = -1000000000000000000 ; 

		[SimpleDataPackMember(9)][Key(9)][SerializeField]
//		public ulong P9 = 10000000000000000000 ; 
		public ulong P9{ get ; private set ; } = 10000000000000000000 ; 


		[SimpleDataPackMember(10)][Key(10)][SerializeField]
//		public float P10 = 12345.68f ;					// 丸め誤差に注意
		public float P10{ get ; private set ; } = 12345.68f ;					// 丸め誤差に注意

		[SimpleDataPackMember(11)][Key(11)][SerializeField]
//		public double P11 = 123456789012.123 ;		// 丸め誤差に注意
		public double P11{ get ; private set ; } = 123456789012.123 ;		// 丸め誤差に注意

		[SimpleDataPackMember(12)][Key(12)][SerializeField]
//		public decimal P12 = 123456789012.12345M ; 
		public decimal P12{ get ; private set ; } = 123456789012.12345M ; 

		[SimpleDataPackMember(13)][Key(13)][SerializeField]
//		public string P13 = "あいうえおかきくけこさしすせそたちつてと" ;
		public string P13{ get ; private set ; } = "あいうえおかきくけこさしすせそたちつてと" ;

		[SimpleDataPackMember(14)][Key(14)][SerializeField]
//		public DateTime P14 = DateTime.Now ;
		public DateTime P14{ get ; private set ; } = DateTime.Now ;



//		[SimpleDataPackMember(15)][Key(15)][SerializeField]
//		protected MySampleSub_W P15 = new MySampleSub_W() ;

		[SimpleDataPackMember(16)][Key(16)][SerializeField]
//		public Status_W P16 = Status_W.Strength ;
		public Status_W P16{ get ; private set ; } = Status_W.Strength ;


		//-----------------------------------------------------------
/*
		[SimpleDataPackMember(17)][Key(17)][SerializeField]
		protected bool? P17 = true ; 

		[SimpleDataPackMember(18)][Key(18)][SerializeField]
		protected byte? P18 = 255 ; 

		[SimpleDataPackMember(19)][Key(19)][SerializeField]
		protected sbyte? P19 = -128 ; 

		[SimpleDataPackMember(20)][Key(20)][SerializeField]
		protected char? P20 = '0' ; 

		[SimpleDataPackMember(21)][Key(21)][SerializeField]
		protected short? P21 = -32768 ; 

		[SimpleDataPackMember(22)][Key(22)][SerializeField]
		protected ushort? P22 = 65535 ; 

		[SimpleDataPackMember(23)][Key(23)][SerializeField]
		protected int? P23 = -1000000000 ; 

		[SimpleDataPackMember(24)][Key(24)][SerializeField]
		protected uint? P24 = 1000000000 ; 

		[SimpleDataPackMember(25)][Key(25)][SerializeField]
		protected long? P25 = -1000000000000000000 ; 

		[SimpleDataPackMember(26)][Key(26)][SerializeField]
		protected ulong? P26 = 10000000000000000000 ; 


		[SimpleDataPackMember(27)][Key(27)][SerializeField]
		public float? P27 = 12345.68f ;					// 丸め誤差に注意

		[SimpleDataPackMember(28)][Key(28)][SerializeField]
		protected double? P28 = 123456789012.123 ;		// 丸め誤差に注意

		[SimpleDataPackMember(29)][Key(29)][SerializeField]
		protected decimal? P29 = 123456789012.12345M ; 


		[SimpleDataPackMember(30)][Key(30)][SerializeField]
		public string? P30 = "あいうえおかきくけこさしすせそ" ;

		[SimpleDataPackMember(31)][Key(31)][SerializeField]
		protected DateTime? P31 = DateTime.Now ;


		[SimpleDataPackMember(32)][Key(32)][SerializeField]
		protected MySampleSub_W? P32 = new MySampleSub_W() ;

		[SimpleDataPackMember(33)][Key(33)][SerializeField]
		public Status_W? P33 = Status_W.Strength ;

		//-----------------------------------------------------------

		[SimpleDataPackMember(34)][Key(34)][SerializeField]
		public bool[] P34 = { true, false } ; 

		[SimpleDataPackMember(35)][Key(35)][SerializeField]
		public byte[] P35 = { 255, 255 } ; 

		[SimpleDataPackMember(36)][Key(36)][SerializeField]
		public sbyte[] P36 = { -128, -128 } ; 

		[SimpleDataPackMember(37)][Key(37)][SerializeField]
		public char[] P37 = { 'あ', 'ア' } ; 

		[SimpleDataPackMember(38)][Key(38)][SerializeField]
		public short[] P38 = { -32768, -32768 } ; 

		[SimpleDataPackMember(39)][Key(39)][SerializeField]
		protected ushort[] P39 = { 65535, 65535 } ; 

		[SimpleDataPackMember(40)][Key(40)][SerializeField]
		protected int[] P40 = { -1000000000, -1000000001 } ; 

		[SimpleDataPackMember(41)][Key(41)][SerializeField]
		protected uint[] P41 = { 1000000000, 1000000001 } ; 

		[SimpleDataPackMember(42)][Key(42)][SerializeField]
		protected long[] P42 = { -1000000000000000000, -1000000000000000001 } ; 

		[SimpleDataPackMember(43)][Key(43)][SerializeField]
		protected ulong[] P43 = { 10000000000000000000, 10000000000000000001 } ; 


		[SimpleDataPackMember(44)][Key(44)][SerializeField]
		public float[] P44 = { 12345.68f, 12345.68f } ;					// 丸め誤差に注意

		[SimpleDataPackMember(45)][Key(45)][SerializeField]
		public double[] P45 = { 123456789012.123, 123456789012.123 } ;		// 丸め誤差に注意

		[SimpleDataPackMember(46)][Key(46)][SerializeField]
		public decimal[] P46 = { 123456789012.12345M, 123456789012.12345M } ; 


		[SimpleDataPackMember(47)][Key(47)][SerializeField]
		public string[] P47 = { "あいうえおかきくけこさしすせそ", "たちつてのなにぬねのはひふへほ", null, "" } ;

		[SimpleDataPackMember(48)][Key(48)][SerializeField]
		public DateTime[] P48 = { DateTime.Now, DateTime.Now } ;


		[SimpleDataPackMember(49)][Key(49)][SerializeField]
		protected MySampleSub_W[] P49 = { null, new MySampleSub_W(), new MySampleSub_W() } ;


		[SimpleDataPackMember(50)][Key(50)][SerializeField]
		public Status_W[] P50 = { Status_W.Strength, Status_W.Intelligence } ;

		//-----------------------------------------------------------

		[SimpleDataPackMember(51)][Key(51)][SerializeField]
		public bool?[] P51 = { true, null } ; 

		[SimpleDataPackMember(52)][Key(52)][SerializeField]
		public byte?[] P52 = { 255, null } ; 

		[SimpleDataPackMember(53)][Key(53)][SerializeField]
		public sbyte?[] P53 = { -128, null } ; 

		[SimpleDataPackMember(54)][Key(54)][SerializeField]
		public char?[] P54 = { null, 'あ' } ; 

		[SimpleDataPackMember(55)][Key(55)][SerializeField]
		public short?[] P55 = { -32768, null } ; 

		[SimpleDataPackMember(56)][Key(56)][SerializeField]
		protected ushort?[] P56 = { 65535, null } ; 

		[SimpleDataPackMember(57)][Key(57)][SerializeField]
		protected int?[] P57 = { null, -1000000001 } ; 

		[SimpleDataPackMember(58)][Key(58)][SerializeField]
		protected uint?[] P58 = { null, 1000000001 } ; 

		[SimpleDataPackMember(59)][Key(59)][SerializeField]
		protected long?[] P59 = { -1000000000000000000, null } ; 

		[SimpleDataPackMember(60)][Key(60)][SerializeField]
		protected ulong?[] P60 = { null, 10000000000000000001 } ; 


		[SimpleDataPackMember(61)][Key(61)][SerializeField]
		public float?[] P61 = { null, 12345.68f } ;					// 丸め誤差に注意

		[SimpleDataPackMember(62)][Key(62)][SerializeField]
		protected double?[] P62 = { 123456789012.123, null } ;		// 丸め誤差に注意

		[SimpleDataPackMember(63)][Key(63)][SerializeField]
		protected decimal?[] P63 = { null, 123456789012.12345M } ; 


		[SimpleDataPackMember(64)][Key(64)][SerializeField]
		public string?[] P64 = { null, "たちつてのなにぬねのはひふへほ" } ;

		[SimpleDataPackMember(65)][Key(65)][SerializeField]
		protected DateTime?[] P65 = { null, DateTime.Now } ;


		[SimpleDataPackMember(66)][Key(66)][SerializeField]
		protected MySampleSub_W?[] P66 = { new MySampleSub_W(), null } ;

		[SimpleDataPackMember(67)][Key(67)][SerializeField]
		public Status_W?[] P67 = { Status_W.Strength, Status_W.Intelligence, null } ;


		//-----------------------------------------------------------


		[SimpleDataPackMember(68)][Key(68)][SerializeField]
		public List<bool> P68 = new List<bool>(){ true, false } ; 


		[SimpleDataPackMember(69)][Key(69)][SerializeField]
		protected List<byte> P69 = new List<byte>(){ 255, 255 } ; 

		[SimpleDataPackMember(70)][Key(70)][SerializeField]
		protected List<sbyte> P70 = new List<sbyte>{ -128, -128 } ; 

		[SimpleDataPackMember(71)][Key(71)][SerializeField]
		protected List<char> P71 = new List<char>{ '0', 'あ' } ; 

		[SimpleDataPackMember(72)][Key(72)][SerializeField]
		protected List<short> P72 = new List<short>(){ -32768, -32768 } ; 

		[SimpleDataPackMember(73)][Key(73)][SerializeField]
		protected List<ushort> P73 = new List<ushort>{ 65535, 65535 } ; 

		[SimpleDataPackMember(74)][Key(74)][SerializeField]
		protected List<int> P74 = new List<int>{ -1000000000, -1000000001 } ; 

		[SimpleDataPackMember(75)][Key(75)][SerializeField]
		protected List<uint> P75 = new List<uint>(){ 1000000000, 1000000001 } ; 

		[SimpleDataPackMember(76)][Key(76)][SerializeField]
		protected List<long> P76 = new List<long>{ -1000000000000000000, -1000000000000000001 } ; 

		[SimpleDataPackMember(77)][Key(77)][SerializeField]
		protected List<ulong> P77 = new List<ulong>{ 10000000000000000000, 10000000000000000001 } ; 


		[SimpleDataPackMember(78)][Key(78)][SerializeField]
		public List<float> P78 = new List<float>{ 12345.68f, 12345.68f } ;					// 丸め誤差に注意

		[SimpleDataPackMember(79)][Key(79)][SerializeField]
		protected List<double> P79 = new List<double>{ 123456789012.123, 123456789012.123 } ;		// 丸め誤差に注意

		[SimpleDataPackMember(80)][Key(80)][SerializeField]
		protected List<decimal> P80 = new List<decimal>{ 123456789012.12345M, 123456789012.12345M } ; 


		[SimpleDataPackMember(81)][Key(81)][SerializeField]
		public List<string> P81 = new List<string>{ "あいうえおかきくけこさしすせそ", "たちつてのなにぬねのはひふへほ", null, "" } ;

		[SimpleDataPackMember(82)][Key(82)][SerializeField]
		protected List<DateTime> P82 = new List<DateTime>{ DateTime.Now, DateTime.Now } ;


		[SimpleDataPackMember(83)][Key(83)][SerializeField]
		protected List<MySampleSub_W> P83 = new List<MySampleSub_W>{ null, new MySampleSub_W(), new MySampleSub_W() } ;

		[SimpleDataPackMember(84)][Key(84)][SerializeField]
		public List<Status_W> P84 = new List<Status_W>{ Status_W.Strength, Status_W.Intelligence } ;

		//-----------------------------------------------------------

		[SimpleDataPackMember(85)][Key(85)][SerializeField]
		protected List<bool?> P85 = new List<bool?>{ true, null } ; 

		[SimpleDataPackMember(86)][Key(86)][SerializeField]
		protected List<byte?> P86 = new List<byte?>{ 255, null } ; 

		[SimpleDataPackMember(87)][Key(87)][SerializeField]
		protected List<sbyte?> P87 = new List<sbyte?>{ -128, null } ; 

		[SimpleDataPackMember(88)][Key(88)][SerializeField]
		protected List<char?> P88 = new List<char?>{ null, 'あ' } ; 

		[SimpleDataPackMember(89)][Key(89)][SerializeField]
		protected List<short?> P89 = new List<short?>{ -32768, null } ; 

		[SimpleDataPackMember(90)][Key(90)][SerializeField]
		protected List<ushort?> P90 = new List<ushort?>{ 65535, null } ; 

		[SimpleDataPackMember(91)][Key(91)][SerializeField]
		protected List<int?> P91 = new List<int?>{ null, -1000000001 } ; 

		[SimpleDataPackMember(92)][Key(92)][SerializeField]
		public List<uint?> P92 = new List<uint?>{ null, 1000000001 } ; 

		[SimpleDataPackMember(93)][Key(93)][SerializeField]
		public List<long?> P93 = new List<long?>{ -1000000000000000000, null } ; 

		[SimpleDataPackMember(94)][Key(94)][SerializeField]
		protected List<ulong?> P94 = new List<ulong?>{ null, 10000000000000000001 } ; 


		[SimpleDataPackMember(95)][Key(95)][SerializeField]
		public List<float?> P95 = new List<float?>{ null, 12345.68f } ;					// 丸め誤差に注意

		[SimpleDataPackMember(96)][Key(96)][SerializeField]
		protected List<double?> P96 = new List<double?>{ 123456789012.123, null } ;		// 丸め誤差に注意

		[SimpleDataPackMember(97)][Key(97)][SerializeField]
		protected List<decimal?> P97 = new List<decimal?>{ null, 123456789012.12345M } ; 


		[SimpleDataPackMember(98)][Key(98)][SerializeField]
		public List<string?> P98 = new List<string?>{ null, "たちつてのなにぬねのはひふへほ" } ;

		[SimpleDataPackMember(99)][Key(99)][SerializeField]
		protected List<DateTime?> P99 = new List<DateTime?>{ null, DateTime.Now } ;


		[SimpleDataPackMember(100)][Key(100)][SerializeField]
		protected List<MySampleSub_W?> P100 = new List<MySampleSub_W?>{ new MySampleSub_W(), null } ;

		[SimpleDataPackMember(101)][Key(101)][SerializeField]
		public List<Status_W?> P101 = new List<Status_W?>{ Status_W.Strength, Status_W.Intelligence, null } ;
*/
		//-----------------------------------------------------------
		// Struct 系
/*
		[SimpleDataPackMember(102)][Key(102)][SerializeField]
		public MyStruct_W P102 = new MyStruct_W( 255 ) ;

		[SimpleDataPackMember(103)][Key(103)][SerializeField]
		public MyStruct_W? P103 = new MyStruct_W( 255 ) ;


		[SimpleDataPackMember(104)][Key(104)][SerializeField]
		public MyStruct_W[] P104 = new MyStruct_W[]{ new MyStruct_W( 255 ), new MyStruct_W( 255 ) } ;


		[SimpleDataPackMember(105)][Key(105)][SerializeField]
		public MyStruct_W?[] P105 = new MyStruct_W?[]{ new MyStruct_W( 255 ), null } ;


//		[SimpleDataPackMember(106)][Key(106)][SerializeField]
//		public List<MyStruct_W> P106 = new List<MyStruct_W>{ new MyStruct_W( 255 ), new MyStruct_W( 255 ) } ;

		[SimpleDataPackMember(107)][Key(107)][SerializeField]
		public List<MyStruct_W?> P107 = new List<MyStruct_W?>{ new MyStruct_W( 255 ), null } ;
*/		
		//-----------------------------------------------------------
		// 非対応クラス系
/*
		[SimpleDataPackMember(108)][Key(108)][SerializeField]
		public List<List<byte>> P108 = new List<List<byte>>{ new List<byte>(){ 255, 255, 255 }, null } ;

		[SimpleDataPackMember(109)][Key(109)][SerializeField]
		public Dictionary<byte,string> P109 = new Dictionary<byte, string>()
		{
			{ 254, "あいうえお" },
			{ 255, "かきくけこ" },
		} ;

		[SimpleDataPackMember(110)][Key(110)][SerializeField]
		public byte[,,] P110 = new byte[2,3,4]
		{
			{
				{  0,  1,  2,  3 },
				{  4,  5,  6,  7 },
				{  8,  9, 10, 11 }
			},
			{
				{ 12, 13, 14, 15 },
				{ 16, 17, 18, 19 },
				{ 20, 21, 22, 23 }
			}
		} ;


		[SimpleDataPackMember(111)][Key(111)][SerializeField]
		public byte[][] P111 = new byte[][]
		{
			new byte[]{ 1, 2, 4 }, new byte[]{ 32, 48, 56 }
		} ;


		[SimpleDataPackMember(112)][Key(112)][SerializeField]
		public List<byte[]> P112 = new List<byte[]>
		{
			new byte[]{ 1, 2, 4 }, new byte[]{ 32, 48, 56 }
		} ;

		[SimpleDataPackMember(113)][Key(113)][SerializeField]
		public List<byte[,]> P113 = new List<byte[,]>
		{
			new byte[,]
			{
				{  0,  1,  2 },
				{  3,  4,  5 }
			},
			new byte[,]
			{
				{  6,  7,  8 },
				{  9, 10, 11 }
			}
		} ;

		[SimpleDataPackMember(114)][Key(114)][SerializeField]
		public byte[][,] P114 = new byte[][,]
		{
			new byte[,]
			{
				{  0,  1,  2 },
				{  3,  4,  5 }
			},
			new byte[,]
			{
				{  6,  7,  8 },
				{  9, 10, 11 }
			}
		} ;
*/
		//-----------------------------------
		// 極端に大きなアレイとリスト
/*
		[SimpleDataPackMember(115)][Key(115)][SerializeField]
		public System.UInt32[] P115 = new System.UInt32[ 1000000 ] ;

		[SimpleDataPackMember(116)][Key(116)][SerializeField]
		public List<System.UInt32?> P116 = new List<System.UInt32?>() ; 
*/


//		[SimpleDataPackMember(110)][Key(110)][SerializeField]
//		protected IgnoreMySample P110 = new IgnoreMySample() ;

		//-------------------------------------------------------------------------------------------








		public void Modify_1()
		{
//			P5 = 12345 ;
//			P114[1][1,2] = 250 ;
		}

		public void Modify_2()
		{
		}

	}


	[SimpleDataPackObject(keyAsCode:true)][MessagePackObject(keyAsPropertyName:false)][Serializable]
	public partial class MySampleSub_W
	{
		[SimpleDataPackMember(0)][Key(0)]
		public byte STR = 255 ;

		[SimpleDataPackMember(1)][Key(1)]
		public byte INT = 255 ;

		[SimpleDataPackMember(2)][Key(2)]
		public Nullable<Status_W> Special = Status_W.Agility ;

		[SimpleDataPackMember(3)][Key(3)]
		public byte? Dummy = 255 ;

		[SimpleDataPackMember(4)][Key(4)]
		public Status_W[]		Dummys = new Status_W[]{ Status_W.Intelligence, Status_W.Mind, Status_W.Agility, Status_W.Vitality } ;
//		public Status?[]		Dummys = new Status?[]{ null, Status.Mind, Status.Agility, null } ;
//		public List<Status?>	Dummys = new List<Status?>{ null, Status.Mind, Status.Agility, null } ;

	}

	public partial class IgnoreMySample
	{
		public int a ;
		public int b ;
		public int c ;
	}
}
