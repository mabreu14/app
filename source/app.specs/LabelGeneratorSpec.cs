using System.Collections.Generic;
using System.Linq;
using app.utility;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  class LabelGeneratorSpec
  {
    public abstract class concern : Observes<LabelGenerator>
    {
      Establish c = () =>
      {
        depends.on(40);  
        depends.on<IList<string>>(new List<string> {"a", "b", "c", "d", "e", "f"});
      };
    }

    public class when_creating_labels : concern
    {
      Because b = () =>
        result = sut.Skip(number_to_skip).Take(1).First();

      public class the_first_label
      {
        Establish c = () =>
          number_to_skip = 0;

        It should_be_the_first_character_in_the_symbol_map = () =>
          result.ShouldEqual("a");
      }

      public class label_should_wrap_after_the_symbol_map_length_is_exceeded
      {
        Establish c = () =>
          number_to_skip = 6;

        It should_be_the_first_character_in_the_symbol_map = () =>
          result.ShouldEqual("aa");
      }
      static int number_to_skip;
      static string result;
    }
  }
}