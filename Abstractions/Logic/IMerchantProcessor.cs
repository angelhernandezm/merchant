using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;

namespace Merchant.Abstractions.Logic {
	public interface IMerchantProcessor {
		/// <summary>
		/// Gets the parsers.
		/// </summary>
		/// <value>
		/// The parsers.
		/// </value>
		IList<IParserEngine<IMerchantTransaction>> Parsers {
			get;
		}

		/// <summary>
		/// Gets the solvers.
		/// </summary>
		/// <value>
		/// The solvers.
		/// </value>
		IList<ISolverBase<IMerchantTransaction>> Solvers {
			get;
		}

		/// <summary>
		/// Executes the specified transactions.
		/// </summary>
		/// <param name="transactions">The transactions.</param>
		void Execute(IEnumerable<string> transactions);

		/// <summary>
		/// Occurs when [on transaction processed].
		/// </summary>
		event EventHandler OnTransactionProcessed;
	}
}