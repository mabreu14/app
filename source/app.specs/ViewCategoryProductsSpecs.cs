using System.Collections.Generic;
using app.web.application.store_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks;

namespace app.specs
{
  [Subject(typeof(ViewCategoryProducts))]
  public class ViewCategoryProductsSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
      ViewCategoryProducts>
    {
    }

    public class when_run : concern
    {
        Establish c = () =>
        {
            request = fake.an<IProvideDetailsAboutTheRequest>();

            main_category = new SubCategoryListingInput();

            sub_categories_lookup = depends.on<IGetSubItemsOFCategories<ProductLineItem>>();
            response_engine = depends.on<IRenderInformation>();

            products = new List<ProductLineItem>();

            request.Stub(x => x.map<SubCategoryListingInput>()).Return(main_category);

            sub_categories_lookup.setup(x => x.get_categories_in(main_category)).Return(products);
        };

        Because b = () =>
          sut.process(request);

        It displays_the_list_of_sub_categories = () =>
          response_engine.received(x => x.display(products));

        static IGetSubItemsOFCategories<ProductLineItem> sub_categories_lookup;
        static IProvideDetailsAboutTheRequest request;
        static IEnumerable<ProductLineItem> products;
        static IRenderInformation response_engine;
        static SubCategoryListingInput main_category;
    }
  }
}