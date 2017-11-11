using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6 {
	class Program {
		static void Main (string[] args) {
			Console.WriteLine("도서 대여 관리 프로그램");

			//book 관리 class
			MgrBook mgrbook = new MgrBook();

			//customer 관리 class
			MgrCustomer mgrCustomer = new MgrCustomer();

			//rental 관리 class
			MgrRental mgrRental = new MgrRental();			

			while (true) {
				Console.WriteLine("SELECT MENU :");
				Console.WriteLine("************************Book************************");
				Console.WriteLine("1.BOOK REGISTRATION, 2.SHOW BOOK LIST, 3.BOOK UNREGISTRATION, 4.SEARH BOOK (BOOK NAME)");
				Console.WriteLine("************************Customer************************");
				Console.WriteLine("5.CUSTOMER REGISTRATION, 6.CUSTOMER UNREGISTRATION, 7.SHOW CUSTOMER LIST");
				Console.WriteLine("************************Rental************************");
				Console.WriteLine("8.RENTAL, 9. SHOW RENTAL LIST");
				Console.WriteLine("99.EXIT");
				string input = Console.ReadLine();

				switch(input) {
					case "1":
						RegistrationBook(mgrbook);
						break;
					case "2":
						ShowBookList(mgrbook);
						break;
					case "3":
						UnregistrationBook(mgrbook);
						break;
					case "4":
						SearchBook(mgrbook);
						break;
					case "5":
						RegistrationCustomer(mgrCustomer);
						break;
					case "6":
						UnRegistrationCustomer(mgrCustomer);
						break;
					case "7":
						ShowCustomerList(mgrCustomer);
						break;
					case "8":
						Rental(mgrbook, mgrCustomer, mgrRental);
						break;
					case "9":
						ShowRentalList(mgrRental);
						break;
					case "99":
						Console.WriteLine("Program terminate.");
						System.Threading.Thread.Sleep(1000);
						return;
					default:
						Console.WriteLine("Not yet implement.");
						break;
				}
				Console.WriteLine("Enter any key. ");
				Console.ReadLine();
				Console.Clear();
			}
		}

		#region rental
		private static void Rental (MgrBook mgrbook, MgrCustomer mgrCustomer, MgrRental mgrRental) {
			string msg = string.Empty;

			Console.Write("Enter rental customer name : ");
			var customerName = Console.ReadLine();
			Console.Write("Enter rental customer tel : ");
			var customerTel = Console.ReadLine();

			Customer customer = mgrCustomer.GetCustomer(customerName, customerTel);

			if(customer == null) {
				Console.WriteLine("Unregistration customer.");
				return;
			}

			Console.Write("Enter rental book name : ");
			var bookName = Console.ReadLine();

			Book book = mgrbook.GetBook(bookName);

			if(book == null) {
				Console.WriteLine("Unregistration book.");
				return;
			}

			Console.Write("Enter rental days : ");
			var rentalDays = Console.ReadLine();

			int iRentalDays = 0;
			int.TryParse(rentalDays, out iRentalDays);
			if(iRentalDays > 0) {
				if(mgrRental.AddRental(customer, book, iRentalDays, ref msg)) {
					Console.WriteLine(msg);
				}
				else {
					Console.WriteLine(msg);
				}
			}
			else {
				Console.WriteLine("Zero day not allowd.");
			}
			
		}

		private static void ShowRentalList(MgrRental mgrRental) {
			foreach(var item in mgrRental.GetRentalList()) {
				Console.WriteLine("Book Name : {0}", item.RentBook.Name);
				Console.WriteLine("Book Writer : {0}", item.RentBook.Writer);
				Console.WriteLine("Customer Name : {0}", item.RentCustomer.CustomerName);
				Console.WriteLine("Customer Tel : {0}", item.RentCustomer.CustomerTel);
				Console.WriteLine("Rent Start Day : {0}", item.rentStartDay);
				Console.WriteLine("Rent End Day : {0}", item.rentEndDay);
			}
		}
		#endregion

		#region Customer
		private static void UnRegistrationCustomer (MgrCustomer mgrCustomer) {
			Console.Write("Enter customer name : ");
			var name = Console.ReadLine();
			Console.Write("Enter customer tel : ");
			var tel = Console.ReadLine();

			
			if (mgrCustomer.RemoveCustomer(name, tel)) {
				Console.WriteLine("{0}, {1} unregistration is complete.", name, tel);
			}
			else {
				Console.WriteLine("{0}, {1} unregistration is not complete.", name, tel);
			}
		}

		private static void RegistrationCustomer (MgrCustomer mgrCustomer) {
			Console.Write("Enter customer name : ");
			var name = Console.ReadLine();
			Console.Write("Enter customer tel : ");
			var tel = Console.ReadLine();

			Customer cust = new Customer {
				CustomerName = name,
				CustomerTel = tel
			};

			if(mgrCustomer.AddCustomer(cust)) {
				Console.WriteLine("{0} registration is complete.", name);
			}
			else {
				Console.WriteLine("{0} registration is not complete.", name);
			}
		}

		private static void ShowCustomerList(MgrCustomer mgrCustomer) {
			Console.WriteLine("Customer Infomations");
			foreach(var item in mgrCustomer.GetCustomers()) {
				Console.WriteLine("Name : {0}", item.CustomerName);
				Console.WriteLine("Tel : {0}", item.CustomerTel);
			}
		}
		#endregion

		#region book
		private static void SearchBook (MgrBook mgrbook) {
			Console.Write("Enter search book name : ");
			var bookName = Console.ReadLine();

			Book book = mgrbook.GetBook(bookName);

			if (book != null) {
				Console.WriteLine("{0} Find book.", book.Name);
				Console.WriteLine("=> Book name : {0}", book.Name);
				Console.WriteLine("=> Book writer : {0}", book.Writer);
				Console.WriteLine("=> Book isbn : {0}", book.ISBN);
			}
		}

		private static void UnregistrationBook (MgrBook mgrbook) {
			Console.Write("Enter unregistration book name : ");
			var bookName = Console.ReadLine();
			Book book = mgrbook.GetBook(bookName);
			if (book != null) {
				if (mgrbook.RemoveBook(book.Name, book.Writer)) {
					Console.WriteLine("[{0}] Book unregistration complete.", bookName);
				}
				else {
					Console.WriteLine("[{0}] Book unregistration not complete.", bookName);
				}
			}
		}

		private static void ShowBookList (MgrBook mgrbook) {
			int count = 1;
			Console.WriteLine("Book information.");
			foreach (var item in mgrbook.GetBooks()) {				
				Console.WriteLine("=> NAME : {0}", item.Name);
				Console.WriteLine("=> WRITER : {0}", item.Writer);
				Console.WriteLine("=> ISBN : {0}", item.ISBN);
				count++;
				if(count % 10 == 0) {
					Console.WriteLine("Next.");
					Console.ReadLine();
				}
			}
		}

		private static void RegistrationBook (MgrBook mgrbook) {
			Console.Write("Enter book NAME : ");
			var name = Console.ReadLine();
			Console.Write("Enter book WRITER : ");
			var writer = Console.ReadLine();
			Console.Write("Enter book ISBN");
			var isbn = Console.ReadLine();

			Book book = new Book {
				Name = name,
				Writer = writer,
				ISBN = isbn
			};

			if (mgrbook.AddBook(book )) {
				Console.WriteLine("[{0}] Book registration complete.", name);
			}
			else {
				Console.WriteLine("[{0}] Book registration not complete.", name);
			}
		}
		#endregion
	}
}
