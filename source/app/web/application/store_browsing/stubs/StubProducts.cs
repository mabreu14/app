using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.store_browsing.stubs
{
    class StubProducts : IGetSubItemsOFCategories<ProductLineItem>
    {

        public IEnumerable<ProductLineItem> get_categories_in(SubCategoryListingInput parent)
        {
            return Enumerable.Range(1, 1000).Select(x => new ProductLineItem() { name = "hello", description = "This is a Hello", price = 100, quantity = 50 });
        }

    }
}
