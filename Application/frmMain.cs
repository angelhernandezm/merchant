using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Merchant.Abstractions.Logic;
using Merchant.Concrete;
using Merchant.Concrete.Entities;
using Merchant.Concrete.Logic;

namespace Merchant.Application {
	public partial class frmMain : Form {
		public frmMain() {
			InitializeComponent();
		}

		#region "Event Handlers"

		/// <summary>
		/// Handles the Load event of the frmMain control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void frmMain_Load(object sender, EventArgs e) {

		}


		/// <summary>
		/// Handles the Click event of the btnFilePicker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void btnFilePicker_Click(object sender, EventArgs e) {
			var filePicker = new OpenFileDialog() { Title = "Select Merchant's input file " };

			if (filePicker.ShowDialog().Equals(DialogResult.OK) && !string.IsNullOrEmpty(filePicker.FileName))
				txtSelectedFile.Text = filePicker.FileName;
		}

		/// <summary>
		/// Handles the Click event of the btnProcessFile control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void btnProcessFile_Click(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(txtSelectedFile.Text)) {
				lstOutput.Items.Clear();
				var processor = MerchantProcessor.Current;

				try {
					var lines = File.ReadAllLines(txtSelectedFile.Text);
					processor.OnTransactionProcessed += (a, b) => lstOutput.Items.Add(((ISolverBase<MerchantTransaction>) a).SolutionAsString);
					processor.Execute(lines);
				} catch (Exception ex) {
					Logger.Current.Log(ex.FormatExceptionAsLogEntry());
					MessageBox.Show(ex.ToString(), "Error message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			} else
				MessageBox.Show("Input file not selected, please select one and try again",
								"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		#endregion

	}
}