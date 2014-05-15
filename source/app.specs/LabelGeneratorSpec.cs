using app.web.core;
using app.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using System.Collections.Generic;

namespace app.specs
{
    class LabelGeneratorSpec
    {
        public abstract class concern : Observes<LabelGenerator>
        {
        }
        public class when_creating_a_label : concern
        {
            Establish c = () =>
                {
                    result=new List<string>();
                    depends.on<IList<string>>(new List<string> {"a","b","c","d","e","f"});
                };
            Because b = () =>
            {
                result.Add(sut.create_label());
            };
            
            It creates_a_label = () =>
                result[0].ShouldMatch("a");


           

            static List<string> result;
        }
    }
}
