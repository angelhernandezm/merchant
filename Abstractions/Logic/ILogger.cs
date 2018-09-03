using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Abstractions.Logic {
	public interface ILogger {
		/// <summary>
		/// Logs the specified log entry.
		/// </summary>
		/// <param name="logEntry">The log entry.</param>
		void Log(string logEntry);
	}
}
