using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCoreLibrary.Core {
	public class ModelBase {
		public CRUDType CrudType { get; set; }

		public ModelBase() {
			this.CrudType = CRUDType.NONE;
		}
	}

	public enum CRUDType {
		NONE,
		SELECT,
		INSERT,
		MODIFY,
		REMOVE
	}
}
