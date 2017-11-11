using BookCoreLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCoreLibrary {
	public class Book : ServiceModelBase {
		private int idx;
		public int Idx { get { return idx; }
			set
			{
				idx = value;
				this.RaisePropertyChanged("Idx");
			}
		}

		private string title;
		public string Title { get { return title; }
			set
			{
				title = value;
				this.RaisePropertyChanged("Title");
			}
		}

		private string writer;
		public string Writer { get { return writer; }
			set {
				this.SetProperty(ref this.writer, value, () => this.writer);
			}
		}

		private DateTime publishDate;
		public DateTime PublishDate { get { return publishDate == DateTime.MinValue ? DateTime.Now : publishDate; }
			set {
				this.SetProperty(ref this.publishDate, value, () => this.publishDate);
			}
		}

		private BookTypes bookType;
		public BookTypes BookType { get { return bookType; }
			set {
				this.bookType = value;
				RaisePropertyChanged("BookType");
			}
		}

		private decimal rent_cost;
		public decimal Rent_Cost
		{
			get { return rent_cost; }
			set
			{
				this.rent_cost = value;
				RaisePropertyChanged("Rent_Cost");
			}
		}
	}

	public enum BookTypes {
		EDUCATION,
		ELECTRONIC,
		IT,
		FASHION,
		SELFDEVELOPMENT
	}
}
