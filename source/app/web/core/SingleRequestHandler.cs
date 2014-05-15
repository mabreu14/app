namespace app.web.core
{
  public class SingleRequestHandler : IProcessOneWebRequest
  {
    IMatchARequest request_specification;
    ISupportAUserFeature feature;

    public SingleRequestHandler(IMatchARequest request_specification, ISupportAUserFeature feature)
    {
      this.request_specification = request_specification;
      this.feature = feature;
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      feature.process(request);
    }

    public bool can_handle(IProvideDetailsAboutTheRequest request)
    {
      return request_specification(request);
    }
  }
}