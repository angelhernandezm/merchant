using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions;
using Merchant.Abstractions.Entities;
using Merchant.Concrete.Logic;

namespace Merchant.Concrete.Entities {
	public class RomanBase : IRomanBase {
		private static readonly ILookup<char, IRomanBase> _symbols = new List<IRomanBase>() {
				new RomanBase(RomanSymbols.I, Numbers.One, true, true),
				new RomanBase(RomanSymbols.V, Numbers.Five),
				new RomanBase(RomanSymbols.X, Numbers.Ten, true, true),
				new RomanBase(RomanSymbols.L, Numbers.Fifty),
				new RomanBase(RomanSymbols.C, Numbers.OneHundred, true, true),
				new RomanBase(RomanSymbols.D, Numbers.FiveHundred),
				new RomanBase(RomanSymbols.M, Numbers.OneThousand, true),
		}.ToLookup(p => p.Symbol);

		/// <summary>
		/// Gets or sets a value indicating whether this instance can it be subtracted.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance can it be subtracted; otherwise, <c>false</c>.
		/// </value>
		/// <exception cref="System.NotImplementedException">
		/// </exception>
		public bool CanItBeSubtracted {
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is repeatable.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is repeatable; otherwise, <c>false</c>.
		/// </value>
		/// <exception cref="System.NotImplementedException">
		/// </exception>
		public bool IsRepeatable {
			get; set;
		}

		/// <summary>
		/// Gets or sets the symbol.
		/// </summary>
		/// <value>
		/// The symbol.
		/// </value>
		/// <exception cref="System.NotImplementedException">
		/// </exception>
		public char Symbol {
			get; set;
		}

		/// <summary>
		/// Gets the symbols.
		/// </summary>
		/// <value>
		/// The symbols.
		/// </value>
		public ILookup<char, IRomanBase> Symbols {
			get {
				return _symbols;
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		/// <exception cref="System.NotImplementedException">
		/// </exception>
		public int Value {
			get; set;
		}

		/// <summary>
		/// Parses the specified symbol.
		/// </summary>
		/// <param name="symbol">The symbol.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IRomanBase Parse(char symbol) {
			return Symbols[symbol].FirstOrDefault();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RomanBase"/> class.
		/// </summary>
		public RomanBase() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RomanBase"/> class.
		/// </summary>
		/// <param name="symbol">The symbol.</param>
		/// <param name="value">The value.</param>
		/// <param name="isRepeatable">if set to <c>true</c> [is repeatable].</param>
		/// <param name="canItBeSubtracted">if set to <c>true</c> [can it be subtracted].</param>
		public RomanBase(char symbol, int value, bool isRepeatable = false, bool canItBeSubtracted = false) : this() {
			Value = value;
			Symbol = symbol;
			IsRepeatable = isRepeatable;
			CanItBeSubtracted = canItBeSubtracted;
		}
	}
}