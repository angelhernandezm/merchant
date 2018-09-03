using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;
using Merchant.Abstractions.Logic;
using Merchant.Concrete.Entities;

namespace Merchant.Concrete.Logic {
	public class UnitParser : IParserEngine<MerchantTransaction> {
		/// <summary>
		/// Gets or sets the transaction.
		/// </summary>
		/// <value>
		/// The transaction.
		/// </value>
		public MerchantTransaction Transaction {
			get; private set;
		}

		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputStr">The input string.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">inputStr cannot be null - Unable to parse input string</exception>
		public bool Parse(string inputStr) {
			var retval = false;

			if (string.IsNullOrEmpty(inputStr))
				throw new ArgumentNullException("inputStr cannot be null - Unable to parse input string");

			var parts = inputStr.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

			if (parts.Length == 2) {
				var leftPart = parts[0].Split(' ');

				if (leftPart.Length > 2) {
					var value = int.Parse(parts[1].Split(' ')[0]);
					var unit = parts[1].Split(' ')[1];
					Transaction.SelectedTransaction = unit;
					var romanNumber = new RomanNumber();
					romanNumber = (RomanNumber)romanNumber.Parse(string.Join(" ", leftPart.Take(leftPart.Length - 1)), Transaction.Symbols);
					var result = romanNumber.Calculate();
					var lastUnit = leftPart.Last();
					var finalUnit = value / result;
					Transaction.Units[lastUnit] = finalUnit;
					retval = true;
				}
			}

			return retval;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitParser"/> class.
		/// </summary>
		/// <param name="transaction">The transaction.</param>
		public UnitParser(IMerchantTransaction transaction) {
			Transaction = transaction as MerchantTransaction;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="UnitParser"/> class.
		/// </summary>
		public UnitParser() : this(new MerchantTransaction()) {

		}
	}
}
