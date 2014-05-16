using System.Collections.Generic;
using app.web.application.store_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewMainCategories))]
  public class ViewMainCategoriesSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
      ViewMainCategories>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutTheRequest>();

        categories = depends.on<IGetCategories>();
        response_engine = depends.on<IRenderInformation>();

        main_categories = new List<CategoryLineItem>();

        categories.setup(x => x.get_main_categories()).Return(main_categories);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_list_of_main_categories = () =>
        response_engine.received(x => x.display(main_categories));

      static IGetCategories categories;
      static IProvideDetailsAboutTheRequest request;
      static IEnumerable<CategoryLineItem> main_categories;
      static IRenderInformation response_engine;
    }
  }
}