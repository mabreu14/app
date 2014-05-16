using System.Collections.Generic;

namespace app.web.application.store_browsing
{
  public interface IGetSubCategories
  {
    CategoryLineItem main_category { get; set; }

    IEnumerable<CategoryLineItem> get_sub_categories();
  }
}