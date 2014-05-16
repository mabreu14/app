using app.web.application.store_browsing;
using app.web.core;
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
      It first_observation = () =>
      {
      };
    }
  }
}