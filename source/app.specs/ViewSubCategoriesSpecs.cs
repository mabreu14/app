 using app.web.application.store_browsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

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
