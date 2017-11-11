using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BookCoreLibrary.Core;

namespace BookCoreLibrary {
	public class RentalService {
		private List<Rental> rentals;
		private readonly string conString = @"Data Source=192.168.25.30;Initial Catalog=StoneCircleTestDb;Persist Security Info=True;User ID=sa;Password=wcw123";

		public RentalService () {
			InitRantal();
		}

		public void InitRantal () {
			//db process
			SqlConnection connection = new SqlConnection(conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();
					string strQuery = @"
SELECT A.IDX
	 , A.RENT_START_DAY
	 , A.RENT_END_DAY
	 , A.RENT_TOTAL_COST
	 , A.CUSTOMER_IDX
	 , A.BOOK_IDX
	 , C.NAME AS CUSTOMERNAME
	 , B.TITLE AS BOOKTITLE
FROM RENTAL A LEFT JOIN BOOK B ON A.BOOK_IDX = B.IDX
              LEFT JOIN CUSTOMER C ON A.CUSTOMER_IDX = C.IDX
";
					rentals = connection.Query<Rental>(strQuery).ToList();

					if (rentals != null && rentals.Count > 0) {
						foreach (var model in rentals) {
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

		public List<Rental> GetRentals () {
			return this.rentals;
		}

		public int AddRental (Rental rental) {
			int retIdx = 0;

			SqlConnection connection = new SqlConnection(conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					retIdx = (int)connection.Query<int>("INSERT INTO RENTAL (RENT_START_DAY, RENT_END_DAY, RENT_TOTAL_COST, CUSTOMER_IDX, BOOK_IDX) VALUES (@RENT_START_DAY, @RENT_END_DAY, @RENT_TOTAL_COST, @CUSTOMER_IDX, @BOOK_IDX) SELECT CAST(SCOPE_IDENTITY() AS INT)", rental).First();
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

		public bool RemoveRental (int idx) {
			bool isRet = false;

			SqlConnection connection = new SqlConnection(conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					int n = connection.Execute("DELETE FROM RENTAL WHERE IDX = @IDX", new { IDX = idx });

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

		public bool ModifyRental (Rental rental) {
			bool isRet = false;

			SqlConnection connection = new SqlConnection(conString);

			try {
				if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
					connection.Open();

					int n = connection.Execute("UPDATE RENTAL SET RENT_START_DAY = @RENT_START_DAY, RENT_END_DAY = @RENT_END_DAY, RENT_TOTAL_COST = @RENT_TOTAL_COST, CUSTOMER_IDX = @CUSTOMER_IDX, BOOK_IDX = @BOOK_IDX WHERE IDX = @IDX", rental);

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
