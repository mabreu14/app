using System.Collections.Generic;

namespace app.web.application.store_browsing
{
  public interface IGetCategories
  {
    IEnumerable<CategoryLineItem> get_main_categories();
  }
}