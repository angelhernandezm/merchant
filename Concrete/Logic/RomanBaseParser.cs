using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;
using Merchant.Abstractions.Logic;
using Merchant.Concrete.Entities;

namespace Merchant.Concrete.Logic {
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="Merchant.Abstractions.Logic.IParserEngine{MerchantTransaction}" />
	public class RomanBaseParser : IParserEngine<MerchantTransaction> {
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
		public bool Parse(string inputStr) {
			var retval = false;

			if (string.IsNullOrEmpty(inputStr))
				throw new ArgumentNullException("inputStr cannot be null - Unable to parse input string");

			var parts = inputStr.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

			if (!(parts.Length != 2 || parts[1].Length > 1)) {
				var romanBase = (new RomanBase()).Parse(parts[1][0]);

				if (romanBase == null)
					throw new ApplicationException("Syntax error.");

				var tempStr = parts[0].Trim();
				Transaction.Symbols[tempStr] = romanBase;

				retval = true;
			}

			return retval;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RomanBaseParser" /> class.
		/// </summary>
		/// <param name="transaction">The transaction.</param>
		public RomanBaseParser(IMerchantTransaction transaction) {
			Transaction = transaction as MerchantTransaction;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RomanBaseParser"/> class.
		/// </summary>
		public RomanBaseParser() : this(new MerchantTransaction()) {

		}
	}
}
