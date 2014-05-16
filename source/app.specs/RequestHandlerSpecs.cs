using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(RequestHandler))]
  public class RequestHandlerSpecs
  {
    public abstract class concern : Observes<IProcessWebRequests,
      RequestHandler>
    {
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        command_lookup = depends.on<IFindHandlersToProcessRequests>();
        request = fake.an<IProvideDetailsAboutTheRequest>();
        handler_for_request = fake.an<IProcessOneWebRequest>();

        command_lookup.setup(x => x.get_the_handler_for(request)).Return(handler_for_request);
      };

      Because b = () =>
        sut.process(request);

      It should_tell_the_handler_that_can_process_the_request_to_process_the_request = () =>
        handler_for_request.received(x => x.process(request));

      static IProcessOneWebRequest handler_for_request;
      static IProvideDetailsAboutTheRequest request;
      static IFindHandlersToProcessRequests command_lookup;
    }
  }
}