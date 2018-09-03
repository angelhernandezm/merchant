using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Merchant.Abstractions.Logic;

namespace Merchant.Concrete.Logic {
	public class Logger : ILogger, IDisposable {
		private bool _isDisposed = false;
		private Mutex _syncMutex = new Mutex();

		/// <summary>
		/// The _current
		/// </summary>
		private static readonly Logger _current = new Logger();

		/// <summary>
		/// Gets the current.
		/// </summary>
		/// <value>
		/// The current.
		/// </value>
		public static ILogger Current {
			get {
				return _current;

			}
		}

		/// <summary>
		/// Logs the specified log entry.
		/// </summary>
		/// <param name="logEntry">The log entry.</param>
		public void Log(string logEntry) {
			var date = DateTime.Now;
			var dateAsString = date.Day.ToString().PadLeft(2, '0') + date.Month.ToString().PadLeft(2, '0') + date.Year;
			var selectedFile = $"log_{dateAsString}.txt";

			if (!string.IsNullOrEmpty(logEntry)) {
				try {
					_syncMutex.WaitOne();

					using (var fs = !File.Exists(selectedFile) ? File.Create(selectedFile) : File.Open(selectedFile, FileMode.Append, FileAccess.Write)) {
						var bytes = Encoding.Default.GetBytes(logEntry + '\n');
						fs.Write(bytes, 0, bytes.Length);
						fs.Flush();
					}
				} catch {
					// Safe to swallow exception here
				} finally {
					_syncMutex.ReleaseMutex();
				}

			}
		}

		#region IDisposable implementation

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		/// <summary>
		/// Dispose the specified isDisposing.
		/// </summary>
		/// <param name="isDisposing">If set to <c>true</c> is disposing.</param>
		protected virtual void Dispose(bool isDisposing) {
			if (_isDisposed)
				return;

			if (isDisposing) {
				_syncMutex.Dispose();
			}

			_isDisposed = true;
		}
	}
}
