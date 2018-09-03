using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;
using Merchant.Abstractions.Logic;
using Merchant.Concrete.Entities;

namespace Merchant.Concrete.Logic {
	public class MerchantProcessor : IMerchantProcessor {
		/// <summary>
		/// Gets the parsers.
		/// </summary>
		/// <value>
		/// The parsers.
		/// </value>
		public IList<IParserEngine<IMerchantTransaction>> Parsers {
			get; private set;
		}

		/// <summary>
		/// Gets the solvers.
		/// </summary>
		/// <value>
		/// The solvers.
		/// </value>
		public IList<ISolverBase<IMerchantTransaction>> Solvers {
			get; private set;
		}

		/// <summary>
		/// Gets or sets the shared transaction scope.
		/// </summary>
		/// <value>
		/// The shared transaction scope.
		/// </value>
		private IMerchantTransaction SharedTransactionScope {
			get; set;
		}

		/// <summary>
		/// Gets the current.
		/// </summary>
		/// <value>
		/// The current.
		/// </value>
		public static IMerchantProcessor Current {
			get {
				return new MerchantProcessor(new MerchantTransaction());
			}
		}

		/// <summary>
		/// Occurs when [on transaction processed].
		/// </summary>
		public event EventHandler OnTransactionProcessed;

		/// <summary>
		/// Executes the specified transactions.
		/// </summary>
		/// <param name="transactions">The transactions.</param>
		public void Execute(IEnumerable<string> transactions) {
			List<string> tranList;

			if (transactions == null)
				throw new ArgumentNullException("Unable to process transactions if input is missing");

			if ((tranList = transactions.ToList()).Count == 0)
				throw new NotSupportedException("Unable to process transactions with an empty input collection");

			// let's ensure we can parse the transactions
			tranList.ForEach(p => {
				var isValid = false;
				Parsers.ToList().ForEach(q => {
					if (!isValid) {
						try {
							if (q.Parse(p))
								isValid = true;
						} catch (Exception ex) {
							Logger.Current.Log(ex.FormatExceptionAsLogEntry());
						}
					}
				});
			});

			// Let's process the transactions
			var enquiries = SharedTransactionScope.Enquiries.ToList();

			enquiries.ForEach(p => {
				var solvedFlag = false;

				foreach (var x in Solvers) {
					try {
						if (x.Solve(p)) {
							solvedFlag = true;
							break;
						}
					} catch (Exception ex) {
						Logger.Current.Log(ex.FormatExceptionAsLogEntry());
					}
				}

				if (!solvedFlag)
					Solvers[0].RaiseUnableToUnderstandNotification();
			});
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MerchantProcessor" /> class.
		/// </summary>
		/// <param name="transaction">The transaction.</param>
		protected MerchantProcessor(IMerchantTransaction transaction) {
			SharedTransactionScope = transaction;

			Solvers = new List<ISolverBase<IMerchantTransaction>>() {
				new RomanSolver(SharedTransactionScope),
				new UnitSolver(SharedTransactionScope)
			};

			Parsers = new List<IParserEngine<IMerchantTransaction>>() {
				new RomanBaseParser(SharedTransactionScope),
				new UnitParser(SharedTransactionScope),
				new EnquiryParser(SharedTransactionScope)
			};

			Solvers.ToList().ForEach(p => p.OnSolveCompleted += (s, a) => OnTransactionProcessed?.Invoke(s, a));
		}
	}
}