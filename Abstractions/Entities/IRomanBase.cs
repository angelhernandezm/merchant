using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Abstractions.Entities {
	/// <summary>
	/// 
	/// </summary>
	public interface IRomanBase {
		/// <summary>
		/// Gets the symbols.
		/// </summary>
		/// <value>
		/// The symbols.
		/// </value>
		ILookup<char, IRomanBase> Symbols { get; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		int Value { get; set; }

		/// <summary>
		/// Gets or sets the symbol.
		/// </summary>
		/// <value>
		/// The symbol.
		/// </value>
		char Symbol { get; set; }
		
		/// <summary>
		/// Gets or sets a value indicating whether this instance is repeatable.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is repeatable; otherwise, <c>false</c>.
		/// </value>
		bool IsRepeatable { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance can it be subtracted.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance can it be subtracted; otherwise, <c>false</c>.
		/// </value>
		bool CanItBeSubtracted { get; set; }

		/// <summary>
		/// Parses the specified symbol.
		/// </summary>
		/// <param name="symbol">The symbol.</param>
		/// <returns></returns>
		IRomanBase Parse(char symbol);
	}
}
