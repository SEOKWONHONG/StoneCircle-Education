using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookCoreLibrary;
using System.Transactions;

namespace Lesson7.ViewControls {
	public partial class UcCustomer : UserControl {
		private CustomerService viewModel;
		private BindingList<Customer> customers;

		public UcCustomer () {
			viewModel = new CustomerService();

			InitializeComponent();

			this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
		}

		private void DataGridView1_SelectionChanged (object sender, EventArgs e) {

		}

		private void Button_Click (object sender, EventArgs e) {
			if (sender.Equals(this.button1)) {
				//조회
				Search();
			}
			else if (sender.Equals(this.button2)) {
				//삭제
				Remove();
			}
			else if (sender.Equals(this.button3)) {
				//추가
				Add();
			}
			else if (sender.Equals(this.button4)) {
				//저장
				Save();
			}
		}

		private void Save () {
			using (var transaction = new TransactionScope()) {
				foreach (var item in customers) {
					if (item.CrudType == BookCoreLibrary.Core.CRUDType.INSERT) {
						item.Idx = viewModel.AddCustomer(item);

						if (item.Idx > 0) {
							item.CrudType = BookCoreLibrary.Core.CRUDType.NONE;
						}
					}
					else if (item.CrudType == BookCoreLibrary.Core.CRUDType.MODIFY) {
						if (viewModel.ModifyCustomer(item)) {
							item.CrudType = BookCoreLibrary.Core.CRUDType.NONE;
						}
					}
				}

				transaction.Complete();
			}
		}

		private void Search () {
			if (string.IsNullOrEmpty(textBox1.Text))
				this.customers = new BindingList<Customer>(viewModel.GetCustomers());
			else
				this.customers = new BindingList<Customer>(viewModel.GetCustomers(textBox1.Text));

			this.dataGridView1.DataSource = this.customers;

			this.textBox2.DataBindings.Clear();
			this.textBox3.DataBindings.Clear();
			this.textBox4.DataBindings.Clear();
			this.textBox5.DataBindings.Clear();

			this.textBox2.DataBindings.Add("Text", this.customers, "Name");
			this.textBox3.DataBindings.Add("Text", this.customers, "Rrn");
			this.textBox4.DataBindings.Add("Text", this.customers, "Tel");
			this.textBox5.DataBindings.Add("Text", this.customers, "Email");
		}

		private void Add () {
			Customer customer = new Customer {
				Idx = -1,
				CrudType = BookCoreLibrary.Core.CRUDType.INSERT,
			};

			this.customers.Add(customer);
		}

		private void Remove () {
			using (var transaction = new TransactionScope()) {
				Customer customer = this.dataGridView1.CurrentRow.DataBoundItem as Customer;

				if (customer != null) {
					if (this.viewModel.RemoveCustomer(customer.Idx))
						this.customers.Remove(customer);
				}

				transaction.Complete();
			}
		}
	}
}
