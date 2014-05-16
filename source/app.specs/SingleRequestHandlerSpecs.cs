using System.Collections.Generic;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(SingleRequestHandler))]
  public class SingleRequestHandlerSpecs
  {
    public abstract class concern : Observes<IProcessOneWebRequest,
      SingleRequestHandler>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutTheRequest>();
        depends.on<IMatchARequest>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_make_the_decision_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static bool result;
      static IProvideDetailsAboutTheRequest request;
    }
    public class when_processing_the_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutTheRequest>();
        feature = depends.on<ISupportAUserFeature>();
      };

      Because b = () =>
        sut.process(request);

      It should_run_the_application_feature = () =>
        feature.received(x => x.process(request));

      static IProvideDetailsAboutTheRequest request;
      static ISupportAUserFeature feature;
    }

  }
}