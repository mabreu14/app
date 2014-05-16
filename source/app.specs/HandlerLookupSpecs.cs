using System.Collections.Generic;
using System.Linq;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(HandlerLookup))]
  public class HandlerLookupSpecs
  {
    public abstract class concern : Observes<IFindHandlersToProcessRequests,
      HandlerLookup>
    {
    }

    public class when_getting_the_handler_for_a_request : concern
    {
      public class and_it_has_the_handler
      {
        Establish c = () =>
        {
          request = fake.an<IProvideDetailsAboutTheRequest>();
          the_handler_that_can_handle_the_request = fake.an<IProcessOneWebRequest>();

          all_handlers = Enumerable.Range(1, 1000).Select(x => fake.an<IProcessOneWebRequest>()).ToList();
          all_handlers.Add(the_handler_that_can_handle_the_request);

          the_handler_that_can_handle_the_request.setup(x => x.can_handle(request)).Return(true);

          depends.on<IEnumerable<IProcessOneWebRequest>>(all_handlers);
        };

        Because b = () =>
          result = sut.get_the_handler_for(request);

        It should_returns_the_handler_that_can_handle_the_request = () =>
          result.ShouldEqual(the_handler_that_can_handle_the_request);

        static IProcessOneWebRequest result;
        static IProcessOneWebRequest the_handler_that_can_handle_the_request;
        static IProvideDetailsAboutTheRequest request;
        static IList<IProcessOneWebRequest> all_handlers;
      }

      public class and_it_does_not_have_the_handler
      {
        Establish c = () =>
        {
          request = fake.an<IProvideDetailsAboutTheRequest>();
          the_special_case = fake.an<IProcessOneWebRequest>();

          all_handlers = Enumerable.Range(1, 1000).Select(x => fake.an<IProcessOneWebRequest>()).ToList();
          all_handlers.Add(the_special_case);

          depends.on<IEnumerable<IProcessOneWebRequest>>(all_handlers);
          depends.on<ICreateAHandlerForAnUncofiguredRequest>(x =>
          {
            x.ShouldEqual(request);
            return the_special_case;
          });
        };

        Because b = () =>
          result = sut.get_the_handler_for(request);

        It should_return_the_special_case_handler = () =>
          result.ShouldEqual(the_special_case);

        static IProcessOneWebRequest result;
        static IProcessOneWebRequest the_special_case;
        static IProvideDetailsAboutTheRequest request;
        static IList<IProcessOneWebRequest> all_handlers;
      }
    }
  }
}