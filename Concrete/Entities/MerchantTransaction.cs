using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Abstractions.Entities;

namespace Merchant.Concrete.Entities {
	public class MerchantTransaction : IMerchantTransaction {
		/// <summary>
		/// Gets or sets the enquiries.
		/// </summary>
		/// <value>
		/// The enquiries.
		/// </value>
		public IList<string> Enquiries {
			get; set;
		}

		/// <summary>
		/// Gets or sets the selected transaction.
		/// </summary>
		/// <value>
		/// The selected transaction.
		/// </value>
		public string SelectedTransaction {
			get; set;
		}

		/// <summary>
		/// Gets or sets the symbols.
		/// </summary>
		/// <value>
		/// The symbols.
		/// </value>
		public IDictionary<string, IRomanBase> Symbols {
			get; set;
		}

		/// <summary>
		/// Gets or sets the units.
		/// </summary>
		/// <value>
		/// The units.
		/// </value>
		public IDictionary<string, double> Units {
			get; set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MerchantTransaction"/> class.
		/// </summary>
		public MerchantTransaction() {
			Enquiries = new List<string>();
			SelectedTransaction = string.Empty;
			Units = new Dictionary<string, double>();
			Symbols = new Dictionary<string, IRomanBase>();
		}
	}
}
