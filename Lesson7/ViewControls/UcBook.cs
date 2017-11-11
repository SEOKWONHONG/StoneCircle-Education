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
using BookCoreLibrary.Core;
using System.Transactions;

namespace Lesson7.ViewControls {
	public partial class UcBook : UserControl {
		private BookService viewModel;
		private BindingList<Book> books;

		public UcBook () {
			viewModel = new BookService();

			InitializeComponent();

			this.Load += UcBook_Load;
			this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

			List<ComboboxKeyValue> cbkv = new List<ComboboxKeyValue>();
			cbkv.Add(new ComboboxKeyValue { Key = "0", Value = BookTypes.EDUCATION.ToString() });
			cbkv.Add(new ComboboxKeyValue { Key = "1", Value = BookTypes.ELECTRONIC.ToString() });
			cbkv.Add(new ComboboxKeyValue { Key = "2", Value = BookTypes.IT.ToString() });
			cbkv.Add(new ComboboxKeyValue { Key = "3", Value = BookTypes.FASHION.ToString() });
			cbkv.Add(new ComboboxKeyValue { Key = "4", Value = BookTypes.SELFDEVELOPMENT.ToString() });
			this.comboBox1.DataSource = cbkv;
			this.comboBox1.DisplayMember = "Value";
			this.comboBox1.ValueMember = "Key";
		}

		private void UcBook_Load (object sender, EventArgs e) {

		}

		private void DataGridView1_SelectionChanged (object sender, EventArgs e) {
			Book book = this.dataGridView1.CurrentRow.DataBoundItem as Book;
			if (book != null) {
				//this.textBox2.Text = book.Title;
				//this.textBox3.Text = book.Writer;
				this.comboBox1.SelectedIndex = (int)book.BookType;
				this.dateTimePicker1.Value = book.PublishDate;
			}
		}

		private List<T> GetValues<T> () {
			return Enum.GetValues(typeof(T)).Cast<T>().ToList();
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
				foreach (var item in books) {
					if (item.CrudType == BookCoreLibrary.Core.CRUDType.INSERT) {
						item.Idx = viewModel.AddBook(item);

						if (item.Idx > 0) {
							item.CrudType = BookCoreLibrary.Core.CRUDType.NONE;
						}
					}
					else if (item.CrudType == BookCoreLibrary.Core.CRUDType.MODIFY) {
						if (viewModel.ModifyBook(item)) {
							item.CrudType = BookCoreLibrary.Core.CRUDType.NONE;
						}
					}
				}

				transaction.Complete();
			}
		}

		private void Search () {
			if (string.IsNullOrEmpty(textBox1.Text))
				this.books = new BindingList<Book>(viewModel.GetBooks());
			else
				this.books = new BindingList<Book>(viewModel.GetBooks(textBox1.Text));

			this.dataGridView1.DataSource = this.books;

			this.textBox2.DataBindings.Clear();
			this.textBox3.DataBindings.Clear();
			this.dateTimePicker1.DataBindings.Clear();

			this.textBox2.DataBindings.Add("Text", this.books, "Title");
			this.textBox3.DataBindings.Add("Text", this.books, "Writer");
			//this.comboBox1.DataBindings.Add("Text", this._books, "BookType");
			this.dateTimePicker1.DataBindings.Add("Text", this.books, "PublishDate");
		}

		private void Add () {
			Book book = new Book {
				Idx = -1,
				CrudType = BookCoreLibrary.Core.CRUDType.INSERT,
				BookType = BookTypes.EDUCATION,
				PublishDate = DateTime.Now
			};

			this.books.Add(book);
		}

		private void Remove () {
			using (var transaction = new TransactionScope()) {
				Book book = this.dataGridView1.CurrentRow.DataBoundItem as Book;

				if (book != null) {
					if (this.viewModel.RemoveBook(book))
						this.books.Remove(book);
				}

				transaction.Complete();
			}
		}

	}
}
