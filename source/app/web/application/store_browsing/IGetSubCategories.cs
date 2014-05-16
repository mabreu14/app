using System.Collections.Generic;

namespace app.web.application.store_browsing {
	public interface IGetSubCategories {
		IEnumerable<CategoryLineItem> get_sub_categories();
	}
}
