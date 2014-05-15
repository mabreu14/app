 using System.Web;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(AspNetRequestHandler))]  
  public class AspNetRequestHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
      AspNetRequestHandler>
    {
        
    }
   
    public class when_processing_an_new_http_context : concern
    {
      Establish c = () =>
      {
        request_handler = depends.on<IProcessWebRequests>();
        a_new_request = fake.an<IProvideDetailsAboutTheRequest>();
        a_plain_old_asp_net_request = ObectFactory.web.create_http_context();
        ICreateARequestFromAspNetRequests factory = x => a_new_request;
        depends.on(factory);
      };

      Because b = () =>
        sut.ProcessRequest(a_plain_old_asp_net_request);

      It should_delegate_the_processing_a_new_request_to_the_front_controller = () =>
        request_handler.received(x => x.process(a_new_request));

      static IProcessWebRequests request_handler;
      static IProvideDetailsAboutTheRequest a_new_request;
      static HttpContext a_plain_old_asp_net_request;
    }
  }
}
