using app.web.application.store_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewReport<OneReport>))]
  public class ViewReportSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature, ViewReport<OneReport>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutTheRequest>();

        the_report = new OneReport();
        response_engine = depends.on<IRenderInformation>();
        depends.on<IQueryForDataUsingTheRequest<OneReport>>(x =>
        {
          x.ShouldEqual(request);
          return the_report;
        });
      };

      Because b = () =>
        sut.process(request);

      It displays_the_report_fetched_by_the_query = () =>
        response_engine.received(x => x.display(the_report));

      static IProvideDetailsAboutTheRequest request;
      static IRenderInformation response_engine;
      static OneReport the_report;
    }

    public class OneReport
    {
    }
  }
}