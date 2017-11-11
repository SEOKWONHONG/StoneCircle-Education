using BookCoreLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCoreLibrary {
	public class Rental : ServiceModelBase {
		private int idx;
		private DateTime rent_start_day;
		private DateTime rent_end_day;
		private decimal rent_total_cost;
		private int customer_idx;
		private int book_idx;

		private string bookTitle;
		private string customerName;

		private Book rentbook;
		private Customer rentcustomer;

		public Book Rentbook { get { return rentbook; } set { rentbook = value; RentalDayCal(); } }
		public Customer Rentcustomer { get { return rentcustomer; } set { rentcustomer = value; } }

		public int Idx { get { return idx; } set { idx = value; RaisePropertyChanged("Idx"); } }

		/// <summary>
		/// 렌트 시작일
		/// </summary>
		public DateTime Rent_Start_Day { get { return rent_start_day; }
			set {
				rent_start_day = value;
				RaisePropertyChanged("Rent_Start_Day");
				RentalDayCal();
			}
		}

		/// <summary>
		/// 렌트 종료일
		/// </summary>
		public DateTime Rent_End_Day { get { return rent_end_day; }
			set {
				rent_end_day = value;
				RaisePropertyChanged("Rent_End_Day");
				RentalDayCal();
			}
		}

		/// <summary>
		/// 렌트 총 비용
		/// </summary>
		public decimal Rent_Total_Cost { get { return rent_total_cost; }
			set {
				rent_total_cost = value;
				RaisePropertyChanged("Rent_Total_Cost");
			}
		}

		/// <summary>
		/// 고객 키
		/// </summary>
		public int Customer_Idx { get { return customer_idx; } set { customer_idx = value; RaisePropertyChanged("Customer_Idx"); } }

		/// <summary>
		/// 도서 키
		/// </summary>
		public int Book_Idx { get { return book_idx; } set { book_idx = value; RaisePropertyChanged("Book_Idx"); } }

		public string CustomerName { get { return customerName; } set { customerName = value; RaisePropertyChanged("CustomerName"); } }
		public string BookTitle { get { return bookTitle; } set { bookTitle = value; RaisePropertyChanged("BookTitle"); } }

		public Rental () { }

		private void RentalDayCal() {
			if (Rentbook == null) return;
			if (this.Rent_Start_Day == DateTime.MinValue) return;
			if (this.Rent_End_Day == DateTime.MinValue) return;

			TimeSpan ts = this.Rent_End_Day - this.Rent_Start_Day;
			this.Rent_Total_Cost = this.Rentbook.Rent_Cost * ts.Days;
		}

	}
}
