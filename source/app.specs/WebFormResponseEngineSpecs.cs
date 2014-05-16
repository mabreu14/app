using System.Web;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(WebFormResponseEngine))]
  public class WebFormResponseEngineSpecs
  {
    public abstract class concern : Observes<IRenderInformation,
      WebFormResponseEngine>
    {
    }

    public class when_displaying_a_report : concern
    {
      Establish c = () =>
      {
        thing_to_display = new SomethingToDisplay();
        context = ObectFactory.web.create_http_context();

        template_factory = depends.on<ICreateAspTemplateInstances>();
        depends.on<IGetTheCurrentlyExecutingContext>(() => context);

        template_instance = fake.an<IHttpHandler>();

        template_factory.setup(x => x.create_template_instance_to_render(thing_to_display)).Return(template_instance);
      };

      Because b = () =>
        sut.display(thing_to_display);

      It tells_the_template_instance_that_can_display_the_report_to_render = () =>
        template_instance.received(x => x.ProcessRequest(context));

      static SomethingToDisplay thing_to_display;
      static ICreateAspTemplateInstances template_factory;
      static IHttpHandler template_instance;
      static HttpContext context;
    }

    class SomethingToDisplay
    {
      
    }
  }
}