using System.Collections.Generic;

namespace app.web.application.store_browsing
{
  public interface IGetSubItemsOFCategories<Item>
  {
    IEnumerable<Item> get_categories_in(SubCategoryListingInput parent);
  }
}