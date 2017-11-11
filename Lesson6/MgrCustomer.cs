using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6 {
	public class MgrCustomer {
		private readonly List<Customer> customers;

		public MgrCustomer () { customers = new List<Customer>(); }

		/// <summary>
		/// 고객 추가
		/// </summary>
		/// <param name="customer">고객 객체</param>
		/// <returns>bool</returns>
		public bool AddCustomer (Customer customer) {
			if (customer == null) return false;

			var exist = (from item in customers
						 where item.CustomerName == customer.CustomerName && item.CustomerTel == customer.CustomerTel
						 select item).FirstOrDefault();

			if(exist != null) {
				return false;
			}

			customers.Add(customer);

			return true;
		}

		/// <summary>
		/// 고객 삭제
		/// </summary>
		/// <param name="customerName">고객명</param>
		/// <returns>bool</returns>
		public bool RemoveCustomer (string customerName, string customerTel) {
			if (!string.IsNullOrEmpty(customerName) && !string.IsNullOrEmpty(customerTel)) {
				var exist = (from item in customers
							 where item.CustomerName == customerName && item.CustomerTel == customerTel
							 select item).FirstOrDefault();

				if (exist != null) {
					customers.Remove(exist);
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 고객검색
		/// </summary>
		/// <param name="name">고객명</param>
		/// <returns>Customer</returns>
		public Customer GetCustomer (string name, string tel) {
			return (from item in customers
					where item.CustomerName == name && item.CustomerTel == tel
					select item).FirstOrDefault();
		}

		/// <summary>
		/// 고객명단
		/// </summary>		
		/// <returns>List</returns>
		public List<Customer> GetCustomers () {
			return this.customers;
		}

	}

	/// <summary>
	/// 고객 클래스	
	/// </summary>
	public class Customer {
		/// <summary>
		/// 고객명
		/// </summary>
		public string CustomerName { get; set; }
		/// <summary>
		/// 고객 전화번호
		/// </summary>
		public string CustomerTel { get; set; }

		public Customer () {

		}

		public Customer (string name, string tel) {
			this.CustomerName = name; this.CustomerTel = tel;
		}
	}
}
