using BookCoreLibrary.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BookCoreLibrary {
	public class CustomerService {
		private List<Customer> customer;
		private readonly string _conString = @"Data Source=192.168.25.30;Initial Catalog=StoneCircleTestDb;Persist Security Info=True;User ID=sa;Password=wcw123";

		public CustomerService() {
			InitCustomer();
		}

		public void InitCustomer () {
			//db process
			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					customer = connection.Query<Customer>("SELECT * FROM CUSTOMER").ToList();

					if (customer != null && customer.Count > 0) {
						foreach (var model in customer) {
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

		public List<Customer> GetCustomers () {
			return this.customer;
		}

		public List<Customer> GetCustomers (string name) {
			return (from customer in customer
					where customer.Name.StartsWith(name) == true
					select customer
				   ).ToList();
		}

		public Customer GetCustomer (int key) {
			return (from customer in customer
					where customer.Idx == key
					select customer
				   ).FirstOrDefault();
		}

		public int AddCustomer (Customer customer) {
			int retIdx = 0;

			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					retIdx = (int)connection.Query<int>("INSERT INTO CUSTOMER (NAME, TEL, RRN, EMAIL, ADDRESS) VALUES (@NAME, @TEL, @RRN, @EMAIL, @ADDRESS) SELECT CAST(SCOPE_IDENTITY() AS INT)", customer).First();
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

		public bool RemoveCustomer (int idx) {
			bool isRet = false;

			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					int n = connection.Execute("DELETE FROM CUSTOMER WHERE IDX = @IDX", new { IDX = idx });

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

		public bool ModifyCustomer (Customer customer) {
			bool isRet = false;

			SqlConnection connection = new SqlConnection(_conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					int n = connection.Execute("UPDATE CUSTOMER SET NAME = @NAME, TEL = @TEL, RRN = @RRN, EMAIL = @EMAIL, ADDRESS = @ADDRESS WHERE IDX = @IDX", customer);

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
