using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadRomanNumerals
{
	public class RomanNumeral
	{
		public uint Value { get; private set; }
		public string Representation { get; private set; }
		private RomanCharacter[] _romanCharacters;

		public RomanNumeral(string romanNumber)
		{
			Representation = romanNumber;
			Value = AttemptParseRomanNumber(romanNumber);
		}

		public RomanNumeral(uint value)
		{
			Value = value;
			Representation = TranslateToRomanNumber(value);
		}

		private uint AttemptParseRomanNumber(string romanNumber)
		{
			_romanCharacters = new RomanCharacter[romanNumber.Length];
			var repetitionDictionary = new Dictionary<RomanCharacter, uint>();
			var negatedDictionary = new Dictionary<RomanCharacter, bool>();
			var negatingDictionary = new Dictionary<RomanCharacter, bool>();
			for (int i=0; i<romanNumber.Length; i++)
			{
				var currentChar = _romanCharacters[i] = new RomanCharacter(romanNumber[i]);
				repetitionDictionary.TryAdd(currentChar, 0);
				repetitionDictionary[currentChar]++;
				if (i == 0)
				{
					continue;
				}
				var precedingChar = _romanCharacters[i - 1];
				negatedDictionary.TryAdd(precedingChar, false);
				negatedDictionary[precedingChar] = negatedDictionary[precedingChar] || precedingChar.IsNegatedBy(currentChar);
				negatingDictionary.TryAdd(currentChar, false);
				negatingDictionary[currentChar] = negatingDictionary[currentChar] || precedingChar.IsNegatedBy(currentChar);
			}
			uint result = 0;
			foreach (var charCount in repetitionDictionary)
			{
				var romanChar = charCount.Key;
				var count = charCount.Value;
				var hasCharacterBeenNegated = negatedDictionary.ContainsKey(romanChar) && negatedDictionary[romanChar];
				var isCharacterUsedToNegateAnother = negatingDictionary.ContainsKey(romanChar) && negatingDictionary[romanChar];
				romanChar.CheckSyntaxRules(count, hasCharacterBeenNegated, isCharacterUsedToNegateAnother);
				result += count * romanChar.Value;
				result -= hasCharacterBeenNegated ? 2 * romanChar.Value : 0;
			}
			return result;
		}

		private string TranslateToRomanNumber(uint value)
		{
			throw new NotImplementedException();
		}
	}
}
