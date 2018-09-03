using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;
using Merchant.Abstractions.Logic;
using Merchant.Concrete.Entities;

namespace Merchant.Concrete.Logic {
	public class EnquiryParser : IParserEngine<MerchantTransaction> {
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

			if (inputStr.EndsWith("?")) {
				Transaction.Enquiries.Add(inputStr.Replace("?", string.Empty).Trim());
				retval = true;
			}
			
			return retval;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EnquiryParser"/> class.
		/// </summary>
		/// <param name="transaction">The transaction.</param>
		public EnquiryParser(IMerchantTransaction transaction) {
			Transaction = transaction as MerchantTransaction;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EnquiryParser"/> class.
		/// </summary>
		public EnquiryParser() : this(new MerchantTransaction()) {

		}
	}
}