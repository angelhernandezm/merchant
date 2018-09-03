using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;

namespace Merchant.Concrete.Entities {
	public class RomanNumber : IRomanNumber {
		private int _tempValue = 0;

		public IList<IRomanBase> Symbols {
			get; private set;
		}

		/// <summary>
		/// Calculates this instance.
		/// </summary>
		/// <returns></returns>
		public int Calculate() {
			var retval = 0;

			if (_tempValue == 0) {
				var symbolsList = Symbols.ToList();

				for (var index = 0; index < symbolsList.Count; index++) {
					var selected = symbolsList[index];
					retval += selected.Value;

					if (index == symbolsList.Count - 1)
						return retval;

					var next = symbolsList[index + 1];

					if (selected.Value < next.Value) {
						retval = next.Value - retval;
						index++;
					} else if (selected.Value == next.Value) {
						var count = 2;

						if (!selected.IsRepeatable)
							throw new Exception($"{selected.Symbol} cannot be repeated");

						for (var x = index + 2; x < symbolsList.Count; x++) {
							if (symbolsList[x].Symbol != selected.Symbol)
								break;

							count++;
							retval += selected.Value;
							index++;

							if (count > 3)
								throw new Exception($"{selected.Symbol} cannot be repeated more than 3 times");
						}
					}
				}
				_tempValue = retval;
			}
			return _tempValue;
		}

		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputStr">The input string.</param>
		/// <param name="values">The values.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// inputString was expected
		/// or
		/// values was expected
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">Unable to parse an empty dictionary (values)</exception>
		public IRomanNumber Parse(string inputStr, IDictionary<string, IRomanBase> values) {
			IRomanNumber retval = null;
			var buffer = new StringBuilder();

			if (string.IsNullOrEmpty(inputStr))
				throw new ArgumentNullException("inputString was expected");

			if (values == null)
				throw new ArgumentNullException("values was expected");

			if (values.Count == 0)
				throw new IndexOutOfRangeException("Unable to parse an empty dictionary (values)");

			retval = new RomanNumber();
			var leftSplit = inputStr.Split(' ');
			Array.ForEach(leftSplit, p => buffer.Append(values[p].Symbol));
			retval = retval.Parse(buffer.ToString());

			return retval;
		}


		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputStr">The input string.</param>
		/// <returns></returns>
		public IRomanNumber Parse(string inputStr) {
			IRomanNumber retval = null;

			if (string.IsNullOrEmpty(inputStr))
				throw new ArgumentNullException("inputString was expected");

			retval = new RomanNumber();
			var romanBase = new RomanBase();
			Array.ForEach(inputStr.ToCharArray(), p => retval.Symbols.Add(romanBase.Parse(p)));

			return retval;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RomanNumber"/> class.
		/// </summary>
		public RomanNumber() {
			Symbols = new List<IRomanBase>();
		}
	}
}
