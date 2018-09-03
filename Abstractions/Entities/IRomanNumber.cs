using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Abstractions.Entities {
	public interface IRomanNumber {
		/// <summary>
		/// Gets the symbols.
		/// </summary>
		/// <value>
		/// The symbols.
		/// </value>
		IList<IRomanBase> Symbols { get; }

		/// <summary>
		/// Calculates this instance.
		/// </summary>
		/// <returns></returns>
		int Calculate();

		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputStr">The input string.</param>
		/// <param name="values">The values.</param>
		/// <returns></returns>
		IRomanNumber Parse(string inputStr, IDictionary<string, IRomanBase> values);

		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputStr">The input string.</param>
		/// <returns></returns>
		IRomanNumber Parse(string inputStr);
	}
}
