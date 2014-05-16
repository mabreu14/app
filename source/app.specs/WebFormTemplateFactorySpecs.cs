using System.Web;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(WebFormTemplateFactory))]
  public class WebFormTemplateFactorySpecs
  {
    public abstract class concern : Observes<ICreateAspTemplateInstances,
      WebFormTemplateFactory>
    {
    }

    public class khen_creating_a_template_instance_for_a_report : concern
    {
      Establish c = () =>
      {
        template_paths = depends.on<IGetAPathToATemplate>();
        report = new MyCustomReport();
        path_to_template = "blah.aspx";
        an_instance_of_the_template = fake.an<IDisplayA<MyCustomReport>>();

        template_paths.setup(x => x.get_path_to_template_for<MyCustomReport>()).Return(path_to_template);

        depends.on<ICreatePageInstances>((path, type) =>
        {
          path.ShouldEqual(path_to_template);
          type.ShouldEqual(typeof(IDisplayA<MyCustomReport>));
          return an_instance_of_the_template;
        });
      };

      Because b = () =>
        result = sut.create_template_instance_to_render(report);

      It creates_an_instance_of_the_template_from_its_path = () =>
        result.ShouldEqual(an_instance_of_the_template);

      It populates_the_template_instance_with_its_data = () =>
        an_instance_of_the_template.report.ShouldEqual(report);

      static IGetAPathToATemplate template_paths;
      static MyCustomReport report;
      static IHttpHandler result;
      static string path_to_template;
      static IDisplayA<MyCustomReport> an_instance_of_the_template;
    }

    public class MyCustomReport
    {
    }
  }
}