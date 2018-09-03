using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Abstractions.Entities {
	public interface IMerchantTransaction {
		/// <summary>
		/// Gets or sets the selected transaction.
		/// </summary>
		/// <value>
		/// The selected transaction.
		/// </value>
		string SelectedTransaction {
			get; set;
		}

		/// <summary>
		/// Gets or sets the symbols.
		/// </summary>
		/// <value>
		/// The symbols.
		/// </value>
		IDictionary<string, IRomanBase> Symbols {
			get; set;
		}

		/// <summary>
		/// Gets or sets the units.
		/// </summary>
		/// <value>
		/// The units.
		/// </value>
		IDictionary<string, double> Units {
			get; set;
		}

		/// <summary>
		/// Gets or sets the enquiries.
		/// </summary>
		/// <value>
		/// The enquiries.
		/// </value>
		IList<string> Enquiries {
			get; set;
		}
	}
}
