using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core;

namespace app.web.application.store_browsing
{
    public interface IGetItems<Items>
    {
        IEnumerable<Items> get_items(IGetTheParentCategory parent);
    }

    public delegate SubCategoryListingInput IGetTheParentCategory(IProvideDetailsAboutTheRequest request);
}
