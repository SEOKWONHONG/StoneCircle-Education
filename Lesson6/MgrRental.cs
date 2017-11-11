using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6 {
	class MgrRental {
		private readonly List<Rental> rentals;

		public MgrRental () { rentals = new List<Rental>(); }
		//ref와 out의 차이
		// 매개변수를 초기화 하는 것에 있습니다.
		// ref 는 매개변수를 사용하기 전에 초기화
		// out 은 전달전에 초기화 필요가 없고 이전 모두 무시 됩니다.
		public bool AddRental (Customer customer, Book book, int rentedDay, ref /*out*/ string msg) {
			var exist = (from item in rentals
						 where item.RentCustomer.CustomerName == customer.CustomerName && item.RentBook.Name == book.Name
						 select item
						 );

			if(exist != null && exist.Count() > 0) {
				msg = "이미 랜트한 책이 있습니다.";
				return false;
			}

			Rental r = new Rental(customer, book, rentedDay);
			rentals.Add(r);

			return true;
		}

		public bool RemoveRental(string customerName, string bookName, ref string msg) {
			var cName = (from item in rentals
						 where item.RentCustomer.CustomerName == customerName && item.RentBook.Name == bookName
						 select item
						).FirstOrDefault();

			if (cName != null) {
				rentals.Remove(cName);
				return true;
			}
			else {
				msg = "랜트한 책이 없습니다.";
			}

			return false;
		}

		public List<Rental> GetRentalList () {
			return rentals;
		}

		public List<Rental> GetRentals (string customerName, string bookName) {
			return (from item in rentals
					where item.RentCustomer.CustomerName == customerName && item.RentBook.Name == bookName
					select item
					).ToList();
		}

		public Rental GetRental (string customerName, string bookName) {
			return (from item in rentals
					where item.RentCustomer.CustomerName == customerName && item.RentBook.Name == bookName
					select item
					).FirstOrDefault();
		}

	}

	class Rental {		
		public Book RentBook { get; set; }
		public DateTime rentStartDay { get; set; }
		public DateTime rentEndDay { get; set; }
		public Customer RentCustomer { get; set; }
		public decimal RentCost { get; set; }

		public Rental () { }
		public Rental(Customer customer, Book book, int rentedDay) {
			RentCustomer = customer;
			RentBook = book;
			rentStartDay = DateTime.Now;
			rentEndDay = DateTime.Now.AddDays(rentedDay);
			//var tip = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");			
		}
	}
}
