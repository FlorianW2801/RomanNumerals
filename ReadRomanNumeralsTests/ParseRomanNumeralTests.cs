using ReadRomanNumerals;
using System;
using Xunit;

namespace ReadRomanNumeralsTests
{
	public class ParseRomanNumeralTests
	{
		[Fact]
		public void Throw_On_InvalidCharacters()
		{
			Assert.Throws<Exception>(() => new RomanNumeral("A"));
			Assert.Throws<Exception>(() => new RomanNumeral("B"));
			Assert.Throws<Exception>(() => new RomanNumeral("E"));
			Assert.Throws<Exception>(() => new RomanNumeral("F"));
			Assert.Throws<Exception>(() => new RomanNumeral("G"));
			Assert.Throws<Exception>(() => new RomanNumeral("H"));
			Assert.Throws<Exception>(() => new RomanNumeral("J"));
			Assert.Throws<Exception>(() => new RomanNumeral("K"));
			Assert.Throws<Exception>(() => new RomanNumeral("N"));
			Assert.Throws<Exception>(() => new RomanNumeral("O"));
			Assert.Throws<Exception>(() => new RomanNumeral("P"));
			Assert.Throws<Exception>(() => new RomanNumeral("Q"));
			Assert.Throws<Exception>(() => new RomanNumeral("R"));
			Assert.Throws<Exception>(() => new RomanNumeral("S"));
			Assert.Throws<Exception>(() => new RomanNumeral("T"));
			Assert.Throws<Exception>(() => new RomanNumeral("U"));
			Assert.Throws<Exception>(() => new RomanNumeral("W"));
			Assert.Throws<Exception>(() => new RomanNumeral("Y"));
			Assert.Throws<Exception>(() => new RomanNumeral("Z"));
		}

		[Fact]
		public void Throw_On_InvalidCase()
		{
			Assert.Throws<Exception>(() => new RomanNumeral("i"));
			Assert.Throws<Exception>(() => new RomanNumeral("v"));
			Assert.Throws<Exception>(() => new RomanNumeral("x"));
			Assert.Throws<Exception>(() => new RomanNumeral("l"));
			Assert.Throws<Exception>(() => new RomanNumeral("c"));
			Assert.Throws<Exception>(() => new RomanNumeral("d"));
			Assert.Throws<Exception>(() => new RomanNumeral("m"));
		}

		[Fact]
		public void DoNotThrow_On_ValidCharacters()
		{
			new RomanNumeral("I");
			new RomanNumeral("V");
			new RomanNumeral("X");
			new RomanNumeral("L");
			new RomanNumeral("C");
			new RomanNumeral("D");
			new RomanNumeral("M");
		}

		[Fact]
		public void HaveProperValue_FromSingleCharacters()
		{
			Assert.Equal((uint)1, new RomanNumeral("I").Value);
			Assert.Equal((uint)5, new RomanNumeral("V").Value);
			Assert.Equal((uint)10, new RomanNumeral("X").Value);
			Assert.Equal((uint)50, new RomanNumeral("L").Value);
			Assert.Equal((uint)100, new RomanNumeral("C").Value);
			Assert.Equal((uint)500, new RomanNumeral("D").Value);
			Assert.Equal((uint)1000, new RomanNumeral("M").Value);
		}

		[Fact]
		public void HaveProperValue_FromTwo_Valid_And_WellOrdered_Characters()
		{
			Assert.Equal((uint)2, new RomanNumeral("II").Value);
			Assert.Equal((uint)6, new RomanNumeral("VI").Value);
			Assert.Equal((uint)11, new RomanNumeral("XI").Value);
			Assert.Equal((uint)15, new RomanNumeral("XV").Value);
			Assert.Equal((uint)20, new RomanNumeral("XX").Value);
			Assert.Equal((uint)51, new RomanNumeral("LI").Value);
			Assert.Equal((uint)55, new RomanNumeral("LV").Value);
			Assert.Equal((uint)60, new RomanNumeral("LX").Value);
			Assert.Equal((uint)101, new RomanNumeral("CI").Value);
			Assert.Equal((uint)105, new RomanNumeral("CV").Value);
			Assert.Equal((uint)110, new RomanNumeral("CX").Value);
			Assert.Equal((uint)150, new RomanNumeral("CL").Value);
			Assert.Equal((uint)200, new RomanNumeral("CC").Value);
			Assert.Equal((uint)501, new RomanNumeral("DI").Value);
			Assert.Equal((uint)505, new RomanNumeral("DV").Value);
			Assert.Equal((uint)510, new RomanNumeral("DX").Value);
			Assert.Equal((uint)550, new RomanNumeral("DL").Value);
			Assert.Equal((uint)600, new RomanNumeral("DC").Value);
			Assert.Equal((uint)1001, new RomanNumeral("MI").Value);
			Assert.Equal((uint)1005, new RomanNumeral("MV").Value);
			Assert.Equal((uint)1010, new RomanNumeral("MX").Value);
			Assert.Equal((uint)1050, new RomanNumeral("ML").Value);
			Assert.Equal((uint)1100, new RomanNumeral("MC").Value);
			Assert.Equal((uint)1500, new RomanNumeral("MD").Value);
			Assert.Equal((uint)2000, new RomanNumeral("MM").Value);
		}

		[Fact]
		public void Throw_On_Invalid_RepeatedOnceOrTwiceCharacters()
		{
			Assert.Throws<Exception>(() => new RomanNumeral("VV"));
			Assert.Throws<Exception>(() => new RomanNumeral("VVV"));
			Assert.Throws<Exception>(() => new RomanNumeral("DD"));
			Assert.Throws<Exception>(() => new RomanNumeral("DDD"));
			Assert.Throws<Exception>(() => new RomanNumeral("LL"));
			Assert.Throws<Exception>(() => new RomanNumeral("LLL"));
		}

		[Fact]
		public void DoNotThrow_On_Valid_RepeatedOnceOrTwiceCharacters()
		{
			new RomanNumeral("II");
			new RomanNumeral("III");
			new RomanNumeral("XX");
			new RomanNumeral("XXX");
			new RomanNumeral("CC");
			new RomanNumeral("CCC");
			new RomanNumeral("MM");
			new RomanNumeral("MMM");
		}

		[Fact]
		public void Throw_On_TooManyCharacters()
		{
			Assert.Throws<Exception>(() => new RomanNumeral("IIII"));
			Assert.Throws<Exception>(() => new RomanNumeral("IIIII"));
			Assert.Throws<Exception>(() => new RomanNumeral("VVVV"));
			Assert.Throws<Exception>(() => new RomanNumeral("VVVVV"));
			Assert.Throws<Exception>(() => new RomanNumeral("XXXX"));
			Assert.Throws<Exception>(() => new RomanNumeral("XXXXX"));
			Assert.Throws<Exception>(() => new RomanNumeral("LLLL"));
			Assert.Throws<Exception>(() => new RomanNumeral("LLLLL"));
			Assert.Throws<Exception>(() => new RomanNumeral("CCCC"));
			Assert.Throws<Exception>(() => new RomanNumeral("CCCCC"));
			Assert.Throws<Exception>(() => new RomanNumeral("DDDD"));
			Assert.Throws<Exception>(() => new RomanNumeral("DDDDD"));
			Assert.Throws<Exception>(() => new RomanNumeral("MMMM"));
			Assert.Throws<Exception>(() => new RomanNumeral("MMMMM"));
		}

		[Fact]
		public void Throw_On_InvalidNegatedCharacters()
		{
			Assert.Throws<Exception>(() => new RomanNumeral("VX"));
			Assert.Throws<Exception>(() => new RomanNumeral("VL"));
			Assert.Throws<Exception>(() => new RomanNumeral("VC"));
			Assert.Throws<Exception>(() => new RomanNumeral("VD"));
			Assert.Throws<Exception>(() => new RomanNumeral("VM"));
			Assert.Throws<Exception>(() => new RomanNumeral("LC"));
			Assert.Throws<Exception>(() => new RomanNumeral("LD"));
			Assert.Throws<Exception>(() => new RomanNumeral("LM"));
			Assert.Throws<Exception>(() => new RomanNumeral("DM"));
		}

		[Fact]
		public void Throw_On_NegatedCharacters_AppearingAlsoAsRegular()
		{
			Assert.Throws<Exception>(() => new RomanNumeral("IIX"));
			Assert.Throws<Exception>(() => new RomanNumeral("XXC"));
			Assert.Throws<Exception>(() => new RomanNumeral("CCM"));
			Assert.Throws<Exception>(() => new RomanNumeral("IXI"));
			Assert.Throws<Exception>(() => new RomanNumeral("XCX"));
			Assert.Throws<Exception>(() => new RomanNumeral("CMC"));
		}

		[Fact]
		public void ProperValues_From_1_To50()
		{
			Assert.Equal((uint)1 ,new RomanNumeral("I").Value);
			Assert.Equal((uint)2 ,new RomanNumeral("II").Value);
			Assert.Equal((uint)3 ,new RomanNumeral("III").Value);
			Assert.Equal((uint)4 ,new RomanNumeral("IV").Value);
			Assert.Equal((uint)5 ,new RomanNumeral("V").Value);
			Assert.Equal((uint)6 ,new RomanNumeral("VI").Value);
			Assert.Equal((uint)7 ,new RomanNumeral("VII").Value);
			Assert.Equal((uint)8 ,new RomanNumeral("VIII").Value);
			Assert.Equal((uint)9 ,new RomanNumeral("IX").Value);
			Assert.Equal((uint)10,new RomanNumeral("X").Value);
			Assert.Equal((uint)11,new RomanNumeral("XI").Value);
			Assert.Equal((uint)12,new RomanNumeral("XII").Value);
			Assert.Equal((uint)13,new RomanNumeral("XIII").Value);
			Assert.Equal((uint)14,new RomanNumeral("XIV").Value);
			Assert.Equal((uint)15,new RomanNumeral("XV").Value);
			Assert.Equal((uint)16,new RomanNumeral("XVI").Value);
			Assert.Equal((uint)17,new RomanNumeral("XVII").Value);
			Assert.Equal((uint)18,new RomanNumeral("XVIII").Value);
			Assert.Equal((uint)19,new RomanNumeral("XIX").Value);
			Assert.Equal((uint)20,new RomanNumeral("XX").Value);
			Assert.Equal((uint)21,new RomanNumeral("XXI").Value);
			Assert.Equal((uint)22,new RomanNumeral("XXII").Value);
			Assert.Equal((uint)23,new RomanNumeral("XXIII").Value);
			Assert.Equal((uint)24,new RomanNumeral("XXIV").Value);
			Assert.Equal((uint)25,new RomanNumeral("XXV").Value);
			Assert.Equal((uint)26,new RomanNumeral("XXVI").Value);
			Assert.Equal((uint)27,new RomanNumeral("XXVII").Value);
			Assert.Equal((uint)28,new RomanNumeral("XXVIII").Value);
			Assert.Equal((uint)29,new RomanNumeral("XXIX").Value);
			Assert.Equal((uint)30,new RomanNumeral("XXX").Value);
			Assert.Equal((uint)31,new RomanNumeral("XXXI").Value);
			Assert.Equal((uint)32,new RomanNumeral("XXXII").Value);
			Assert.Equal((uint)33,new RomanNumeral("XXXIII").Value);
			Assert.Equal((uint)34,new RomanNumeral("XXXIV").Value);
			Assert.Equal((uint)35,new RomanNumeral("XXXV").Value);
			Assert.Equal((uint)36,new RomanNumeral("XXXVI").Value);
			Assert.Equal((uint)37,new RomanNumeral("XXXVII").Value);
			Assert.Equal((uint)38,new RomanNumeral("XXXVIII").Value);
			Assert.Equal((uint)39,new RomanNumeral("XXXIX").Value);
			Assert.Equal((uint)40,new RomanNumeral("XL").Value);
			Assert.Equal((uint)41,new RomanNumeral("XLI").Value);
			Assert.Equal((uint)42,new RomanNumeral("XLII").Value);
			Assert.Equal((uint)43,new RomanNumeral("XLIII").Value);
			Assert.Equal((uint)44,new RomanNumeral("XLIV").Value);
			Assert.Equal((uint)45,new RomanNumeral("XLV").Value);
			Assert.Equal((uint)46,new RomanNumeral("XLVI").Value);
			Assert.Equal((uint)47,new RomanNumeral("XLVII").Value);
			Assert.Equal((uint)48,new RomanNumeral("XLVIII").Value);
			Assert.Equal((uint)49,new RomanNumeral("XLIX").Value);
			Assert.Equal((uint)50,new RomanNumeral("L").Value);
		}
	}
}
