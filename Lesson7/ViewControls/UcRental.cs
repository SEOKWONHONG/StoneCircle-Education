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
using Lesson7.HelpControls;

namespace Lesson7.ViewControls {
	public partial class UcRental : UserControl {
		private RentalService viewModel;

		private BookService bookService;
		private CustomerService customerService;

		private BindingList<Rental> _rentals;

		public UcRental () {
			viewModel = new RentalService();

			bookService = new BookService();
			customerService = new CustomerService();

			InitializeComponent();
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
			else if(sender.Equals(this.button5)) {
				FindCustomer();
			}
			else if(sender.Equals(this.button6)) {
				FindBook();
			}
		}

		private void FindBook() {
			using (SearchHelper dlg = new SearchHelper()) {
				dlg.DataSource = bookService.GetBooks();

				if(dlg.ShowDialog() == DialogResult.OK) {
					Book book = dlg.SelectedItem as Book;

					if(book != null) {
						Rental rental = this.dataGridView1.CurrentRow.DataBoundItem as Rental;

						if (rental != null) {
							rental.Book_Idx = book.Idx;
							rental.BookTitle = book.Title;
							rental.Rentbook = book;
						}
					}
				}
			}
		}

		private void FindCustomer() {
			using (SearchHelper dlg = new SearchHelper()) {
				dlg.DataSource = customerService.GetCustomers();

				if (dlg.ShowDialog() == DialogResult.OK) {
					Customer customer = dlg.SelectedItem as Customer;

					if (customer != null) {
						Rental rental = this.dataGridView1.CurrentRow.DataBoundItem as Rental;

						if (rental != null) {
							rental.Customer_Idx = customer.Idx;
							rental.CustomerName = customer.Name;
							rental.Rentcustomer = customer;
						}
					}
				}
			}
		}

		private void Save () {
			using (var transaction = new TransactionScope()) {
				foreach (var item in _rentals) {
					if (item.CrudType == BookCoreLibrary.Core.CRUDType.INSERT) {
						item.Idx = viewModel.AddRental(item);

						if (item.Idx > 0) {
							item.CrudType = BookCoreLibrary.Core.CRUDType.NONE;
						}
					}
					else if (item.CrudType == BookCoreLibrary.Core.CRUDType.MODIFY) {
						if (viewModel.ModifyRental(item)) {
							item.CrudType = BookCoreLibrary.Core.CRUDType.NONE;
						}
					}
				}

				transaction.Complete();
			}
		}

		private void Search () {
			this._rentals = new BindingList<Rental>(viewModel.GetRentals());

			//if(this._rentals != null && this._rentals.Count > 0) {
			//	foreach(var item in _rentals) {
			//		item.RentBook = _bookService.GetBook(item.Book_Idx);
			//		item.RentCustomer = _customerService.GetCustomer(item.Customer_Idx);
			//	}
			//}

			//if (string.IsNullOrEmpty(textBox1.Text))
			//	this._rentals = new BindingList<Rental>(_viewModel.GetRentals());
			//else
			//	this._customers = new BindingList<Customer>(_viewModel.GetCustomers(textBox1.Text));

			this.dataGridView1.DataSource = this._rentals;

			this.dateTimePicker1.DataBindings.Clear();
			this.dateTimePicker2.DataBindings.Clear();
			this.textBox4.DataBindings.Clear();
			this.textBox5.DataBindings.Clear();
			this.textBox6.DataBindings.Clear();

			this.dateTimePicker1.DataBindings.Add("Value", this._rentals, "Rent_Start_Day");
			this.dateTimePicker2.DataBindings.Add("Value", this._rentals, "Rent_End_Day");
			this.textBox4.DataBindings.Add("Text", this._rentals, "Rent_Total_Cost");
			this.textBox5.DataBindings.Add("Text", this._rentals, "CustomerName");
			this.textBox6.DataBindings.Add("Text", this._rentals, "BookTitle");

			this.dataGridView1.Columns[0].Visible = false;
			this.dataGridView1.Columns[1].Visible = false;
			this.dataGridView1.Columns["CrudType"].Visible = false;
		}

		private void Add () {
			Rental rantal = new Rental {
				Idx = -1,
				CrudType = BookCoreLibrary.Core.CRUDType.INSERT,
				Rent_Start_Day = DateTime.Now,
				Rent_End_Day = DateTime.Now,
				Book_Idx = -1,
				Customer_Idx = -1,
				Rent_Total_Cost = 0
			};

			this._rentals.Add(rantal);
		}

		private void Remove () {
			using (var transaction = new TransactionScope()) {
				Rental rental = this.dataGridView1.CurrentRow.DataBoundItem as Rental;

				if (rental != null) {
					if (this.viewModel.RemoveRental(rental.Idx))
						this._rentals.Remove(rental);
				}

				transaction.Complete();
			}
		}
	}
}
