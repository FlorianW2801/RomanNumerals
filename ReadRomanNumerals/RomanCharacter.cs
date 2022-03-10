using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadRomanNumerals
{
	public struct RomanCharacter : IEquatable<RomanCharacter>
	{
		private Character _enumChar;

		public uint Value => (uint)_enumChar;

		public RomanCharacter(char romanChar)
		{
			if (!Enum.TryParse(romanChar.ToString(), out _enumChar))
			{
				throw new Exception($"The character {romanChar} isn't a valid roman numeral character");
			}
		}

		private enum Character
		{
			I = 1,
			V = 5,
			X = 10,
			L = 50,
			C = 100,
			D = 500,
			M = 1000
		}

		public bool IsNegatedBy(RomanCharacter followingCharacter)
		{
			return this.Value < followingCharacter.Value;
		}

		public void CheckSyntaxRules(uint countAppearances, bool hasBeenNegated, bool isNegatingAnother)
		{
			if (hasBeenNegated && !CanBeNegative())
			{
				throw new Exception($"The roman character {_enumChar} cannot be used negatively (placed behind a bigger value)");
			}
			if (isNegatingAnother && !CanNegateAnother())
			{
				throw new Exception($"The roman character {_enumChar} cannot be used to negate another character (placed after a smaller value)");
			}
			var maxAppearances = hasBeenNegated ? 1 : MaxNormalAppearances();
			maxAppearances += isNegatingAnother ? (uint)1 : 0;
			if (countAppearances > maxAppearances)
			{ 
				throw new Exception($"The roman character {_enumChar} appears too often in the string");
			}
		}

		public uint MaxNormalAppearances()
		{
			switch (_enumChar)
			{
				case Character.I:
				case Character.X:
				case Character.C:
				case Character.M:
					return 3;
				case Character.V:
				case Character.L:
				case Character.D:
					return 1;
				default:
					throw new Exception("Unknown case");
			}
		}

		public bool CanBeNegative()
		{
			switch (_enumChar)
			{
				case Character.I:
				case Character.X:
				case Character.C:
					return true;
				case Character.V:
				case Character.L:
				case Character.D:
				case Character.M:
					return false;
				default:
					throw new Exception("Unknown case");
			}
		}

		public bool CanNegateAnother()
		{
			switch (_enumChar)
			{
				case Character.V:
				case Character.X:
				case Character.L:
				case Character.C:
				case Character.D:
				case Character.M:
					return true;
				case Character.I:
					return false;
				default:
					throw new Exception("Unknown case");
			}
		}

		public bool Equals(RomanCharacter other)
		{
			return other._enumChar == _enumChar;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_enumChar);
		}

		public override string ToString()
		{
			return _enumChar.ToString();
		}
	}
}
