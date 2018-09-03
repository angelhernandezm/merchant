using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;
using Merchant.Abstractions.Logic;
using Merchant.Concrete.Entities;

namespace Merchant.Concrete.Logic {
	public class UnitSolver : ISolverBase<MerchantTransaction> {
		/// <summary>
		/// Gets the solution as string.
		/// </summary>
		/// <value>
		/// The solution as string.
		/// </value>
		public string SolutionAsString {
			get; private set;
		}

		/// <summary>
		/// Gets the transaction.
		/// </summary>
		/// <value>
		/// The transaction.
		/// </value>
		public MerchantTransaction Transaction {
			get; private set;
		}

		/// <summary>
		/// Occurs when [on solve completed].
		/// </summary>
		public event EventHandler OnSolveCompleted;

		/// <summary>
		/// Solves the specified transaction as string.
		/// </summary>
		/// <param name="transactionAsString">The transaction as string.</param>
		/// <returns></returns>
		public bool Solve(string transactionAsString) {
			var retval = false;

			if (string.IsNullOrEmpty(transactionAsString))
				throw new ArgumentNullException("Unable to solve a transaction if transactionAsString is missing");

			var enquiry = $"how many {Transaction.SelectedTransaction} is";

			if (transactionAsString.StartsWith(enquiry)) {
				var contents = transactionAsString.Substring(enquiry.Length + 1);
				var parts = contents.Split(' ');
				var lastUnit = parts.Last().Trim();
				var value = Transaction.Units[lastUnit];
				var romanNumber = (new RomanNumber()).Parse(string.Join(" ", parts.Take(parts.Length - 1)), Transaction.Symbols).Calculate();
				var result = romanNumber * value + " " + Transaction.SelectedTransaction;
				retval = true;
				SolutionAsString = contents + " is " + result;
				OnSolveCompleted?.Invoke(this, new EventArgs());
			}

			return retval;
		}

		/// <summary>
		/// Raises the unable to understand notification.
		/// </summary>
		public void RaiseUnableToUnderstandNotification() {
			SolutionAsString = "I have no idea what you are talking about";
			OnSolveCompleted?.Invoke(this, new EventArgs());
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="UnitSolver"/> class.
		/// </summary>
		/// <param name="transaction">The transaction.</param>
		public UnitSolver(IMerchantTransaction transaction) {
			Transaction = transaction as MerchantTransaction;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitSolver"/> class.
		/// </summary>
		public UnitSolver() : this(new MerchantTransaction()) {

		}
	}
}