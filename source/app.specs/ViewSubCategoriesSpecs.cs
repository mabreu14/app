using System.Collections.Generic;
using app.web.application.store_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewSubCategories))]
  public class ViewSubCategoriesSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
      ViewSubCategories>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutTheRequest>();

        sub_categories_lookup = depends.on<IGetSubCategories>();
        response_engine = depends.on<IRenderInformation>();

        sub_categories = new List<CategoryLineItem>();

        sub_categories_lookup.setup(x => x.get_sub_categories()).Return(sub_categories);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_list_of_sub_categories = () =>
        response_engine.received(x => x.display(sub_categories));

      static IGetSubCategories sub_categories_lookup;
      static IProvideDetailsAboutTheRequest request;
      static IEnumerable<CategoryLineItem> sub_categories;
      static IRenderInformation response_engine;
    }
  }
}