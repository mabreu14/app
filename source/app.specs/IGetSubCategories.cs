using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.application.store_browsing;

namespace app.specs {
	public interface IGetSubCategories {
		IEnumerable<CategoryLineItem> get_sub_categories();
	}
}
