using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Concrete {
	/// <summary>
	/// 
	/// </summary>
	public static class Extensions {
		/// <summary>
		/// Formats the exception as log entry.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <returns></returns>
		/// <exception cref="System.NullReferenceException">An exception was expected to be formatted prior logging it</exception>
		public static string FormatExceptionAsLogEntry(this Exception exception) {
			var retval = string.Empty;

			if (exception == null)
				throw new NullReferenceException("An exception was expected to be formatted prior logging it");

			retval = $"DateTime:{DateTime.Now} | Exception:{ exception.Message} | StackTrace:{exception.StackTrace}";

			return retval;
		}
	}
}
