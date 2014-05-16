using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.application.store_browsing;
using app.web.application.store_browsing.stubs;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
    [Subject(typeof(ViewItem<ProductLineItem>))]
    public class ViewItemSpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature, ViewItem<ProductLineItem>>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IProvideDetailsAboutTheRequest>();

                categories = depends.on<IGetItems<ProductLineItem>>();
                response_engine = depends.on<IRenderInformation>();
                parent = depends.on(parent);
                main_categories = new List<ProductLineItem>();

                categories.setup(x => x.get_items(parent)).Return(main_categories);
            };

            Because b = () =>
              sut.process(request);

            It displays_the_list_of_main_categories = () =>
              response_engine.received(x => x.display(main_categories));

            static IGetItems<ProductLineItem> categories;
            static IProvideDetailsAboutTheRequest request;
            static IEnumerable<ProductLineItem> main_categories;
            static IRenderInformation response_engine;
            private static IGetTheParentCategory parent = (x => x.map<SubCategoryListingInput>());
        }
    }
}
