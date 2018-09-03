using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;

namespace Merchant.Abstractions.Logic {
	/// <summary>
	/// 
	/// </summary>
	public interface IParserEngine<out T> where T : IMerchantTransaction {
		/// <summary>
		/// Gets or sets the transaction.
		/// </summary>
		/// <value>
		/// The transaction.
		/// </value>
		T Transaction {
			get; 
		}

		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputStr">The input string.</param>
		/// <returns></returns>
		bool Parse(string inputStr);
	}
}
