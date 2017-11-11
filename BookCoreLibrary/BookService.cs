using BookCoreLibrary.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BookCoreLibrary
{
	public class BookService {
		private List<Book> books;
		private readonly string _conString = @"Data Source=192.168.25.30;Initial Catalog=StoneCircleTestDb;Persist Security Info=True;User ID=sa;Password=wcw123";

		public BookService () {
			InitBook();
			//_books = new List<Book>();
			//_books.Add(new Book { Idx = 1, Title = "누가 내 머리에 똥쌌어?", Writer = "베르너 홀츠바르트", BookType = BookTypes.EDUCATION, PublishDate = DateTime.Now });
			//_books.Add(new Book { Idx = 2, Title = "나는 왜 똑같은 생각만 할까", Writer = "데이비드 니븐", BookType = BookTypes.SELFDEVELOPMENT, PublishDate = DateTime.Now });
			//_books.Add(new Book { Idx = 3, Title = "Do it! 안드로이드 앱 프로그래밍", Writer = "정재곤", BookType = BookTypes.IT, PublishDate = DateTime.Now });
			//_books.Add(new Book { Idx = 4, Title = "Do it! 점프 투 파이썬", Writer = "박응용", BookType = BookTypes.IT, PublishDate = DateTime.Now });
			//_books.Add(new Book { Idx = 5, Title = "드림걸 패션북 종이인형", Writer = "이보라", BookType = BookTypes.FASHION, PublishDate = DateTime.Now });
			//_books.Add(new Book { Idx = 6, Title = "모두의 라즈베리 파이 with 파이썬", Writer = "이시이 모루나", BookType = BookTypes.ELECTRONIC, PublishDate = DateTime.Now });
		}
		public void InitBook() {
			//db process
			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					books = connection.Query<Book>("SELECT * FROM BOOK").ToList();

					if(books != null && books.Count > 0) {
						foreach(var model in books) {
							model.CrudType = CRUDType.NONE;
						}
					}
				}
			}
			catch (SqlException ex) {
				throw ex;
			}
			finally {
				connection.Close();
			}
		}

		public List<Book> GetBooks () {
			return this.books;
		}

		public List<Book> GetBooks (string title) {
			return (from book in books
					where book.Title.StartsWith(title) == true
					select book
				   ).ToList();
		}

		public Book GetBook(int key) {
			return (from book in books
					where book.Idx == key
					select book
				   ).FirstOrDefault();
		}

		public int AddBook (Book book) {
			int retIdx = 0;

			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					retIdx = (int)connection.Query<int>("INSERT INTO BOOK (TITLE, WRITER, PUBLISH_DATE, BOOK_TYPE, RENT_COST) VALUES (@TITLE, @WRITER, @PUBLISH_DATE, @BOOK_TYPE, @RENT_COST) SELECT CAST(SCOPE_IDENTITY() AS INT)", book).First();
				}
			}
			catch (SqlException ex) {
				//log
				throw ex;
			}
			finally {
				connection.Close();
			}

			return retIdx;
		}

		public bool RemoveBook (Book book) {
			bool isRet = false;

			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					int n = connection.Execute("DELETE FROM BOOK WHERE IDX = @IDX", book);

					if (n > 0) isRet = true;
				}
			}
			catch (SqlException ex) {
				//log
				throw ex;
			}
			finally {
				connection.Close();
			}

			return isRet;
		}

		public bool ModifyBook (Book book) {
			bool isRet = false;

			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					int n = connection.Execute("UPDATE BOOK SET TITLE = @TITLE, WRITER = @WRITER, PUBLISH_DATE = @PUBLISHDATE, BOOK_TYPE = @BOOKTYPE, RENT_COST = @RENT_COST WHERE IDX = @IDX", book);

					if (n > 0) isRet = true;
				}
			}
			catch (SqlException ex) {
				//log
				throw ex;
			}
			finally {
				connection.Close();
			}

			return isRet;
		}
	}
}
