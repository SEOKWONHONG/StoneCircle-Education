using BookCoreLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCoreLibrary {
	/// <summary>
	/// 고객 클래스
	/// </summary>
	public class Customer : ServiceModelBase {
		private int idx;
		private string name;
		private string tel;
		private string rrn;
		private string email;
		private string address;

		public int Idx
		{
			get
			{
				return idx;
			}

			set
			{
				idx = value;
				RaisePropertyChanged("Idx");
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
				RaisePropertyChanged("Name");
			}
		}

		public string Tel
		{
			get
			{
				return tel;
			}

			set
			{
				tel = value;
				RaisePropertyChanged("Tel");
			}
		}

		public string Rrn
		{
			get
			{
				return rrn;
			}

			set
			{
				rrn = value;
				RaisePropertyChanged("Rrn");
			}
		}

		public string Email
		{
			get
			{
				return email;
			}

			set
			{
				email = value;
				RaisePropertyChanged("Email");
			}
		}

		public string Address
		{
			get
			{
				return address;
			}

			set
			{
				address = value;
				RaisePropertyChanged("Address");
			}
		}

		///// <summary>
		///// 순번(DB INDEX)
		///// </summary>
		//public int Idx { get; set; }

		///// <summary>
		///// 고객명
		///// </summary>
		//public string Name { get; set; }

		///// <summary>
		///// 고객 전화번호
		///// </summary>
		//public string Tel { get; set; }

		///// <summary>
		///// 주민등록번호
		///// </summary>
		//public string Rrn { get; set; }

		///// <summary>
		///// 전자메일주소
		///// </summary>
		//public string Email { get; set; }

		///// <summary>
		///// 집주소
		///// </summary>
		//public string Address { get; set; }

		public Customer () {

		}
	}
}
