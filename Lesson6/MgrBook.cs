using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6 {
	class MgrBook {
		private readonly List<Book> books;

		public MgrBook () { books = new List<Book>(); }

		public bool AddBook (Book book) {
			try {
				books.Add(book);
				return true;
			}
			catch (Exception e) {
				//log
				Console.WriteLine(e.Message);
			}

			return false;
		}

		public List<Book> GetBooks () {
			return this.books;
		}

		public Book GetBook (string name) {
			var book = (from item in this.books
						where item.Name == name
						select item).FirstOrDefault();

			return book;
		}

		public bool RemoveBook (string bookName, string writer) {
			try {
				var exist = (from item in this.books
							 where item.Name == bookName && item.Writer == writer
							 select item).FirstOrDefault();

				if (exist != null) {
					this.books.Remove(exist);
					return true;
				}
			}
			catch (Exception e) {
				//log
				Console.WriteLine(e.Message);
			}

			return false;
		}
	}

	class Book {
		public string Name { get; set; }
		public string Writer { get; set; }

		//도서 표준 번호
		private string _isbn;
		public string ISBN
		{
			get
			{
				try {
					return string.Format("{0}{1}{2}-{3}{4}-{5}{6}{7}{8}{9}-{10}-{11} {12}{13}{14}{15}{16}", _isbn.ToArray());
				}
				catch (Exception e) {
					Console.WriteLine(e.Message);
				}

				return _isbn;
			}
			set { _isbn = value; }
		} //XXX-XX-XXXXX-X-X XXXXX

		public Book () { }

		public Book (string name, string writer, string isbn) {
			this.Name = name;
			this.Writer = writer;
			this.ISBN = isbn;
		}
	}
}
