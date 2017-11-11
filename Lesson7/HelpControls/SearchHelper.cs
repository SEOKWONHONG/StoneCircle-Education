using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7.HelpControls {
	public partial class SearchHelper : Form {
		private Object _dataSource;
		public Object DataSource
		{
			get
			{
				return _dataSource;
			}
			set
			{
				_dataSource = value;
				this.dataGridView1.DataSource = _dataSource;
			}
		}

		public Object SelectedItem;

		public SearchHelper () {
			InitializeComponent();

			this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
		}

		private void DataGridView1_SelectionChanged (object sender, EventArgs e) {

		}

		private void Button_Click (object sender, EventArgs e) {
			if(sender.Equals(this.button2)) {
				this.SelectedItem = this.dataGridView1.CurrentRow.DataBoundItem;
				this.DialogResult = DialogResult.OK;
			}
			else if(sender.Equals(this.button1)) {
				this.DialogResult = DialogResult.Cancel;
			}

			this.Close();
		}
	}
}
