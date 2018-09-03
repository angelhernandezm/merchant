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
	/// <typeparam name="T"></typeparam>
	public interface ISolverBase<out T> where T : IMerchantTransaction {
		/// <summary>
		/// Gets the transaction.
		/// </summary>
		/// <value>
		/// The transaction.
		/// </value>
		T Transaction {
			get; 
		}

		/// <summary>
		/// Gets the solution as string.
		/// </summary>
		/// <value>
		/// The solution as string.
		/// </value>
		string SolutionAsString {
			get;
		}

		/// <summary>
		/// Solves the specified transaction as string.
		/// </summary>
		/// <param name="transactionAsString">The transaction as string.</param>
		/// <returns></returns>
		bool Solve(string transactionAsString);

		/// <summary>
		/// Occurs when [on solve completed].
		/// </summary>
		event EventHandler OnSolveCompleted;

		/// <summary>
		/// Raises the unable to understand notification.
		/// </summary>
		void RaiseUnableToUnderstandNotification();
	}
}
