using System.Collections.Generic;

namespace app.web.application.store_browsing {
	public interface IGetSubCategories {

        CategoryLineItem MainCategory { get; set; }

		IEnumerable<CategoryLineItem> get_sub_categories();
	}
}
