using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace app.utility
{
  public class LabelGenerator : IEnumerable<string>
  {
    int label_limit;
    IList<string> vocabulary;
    int sequence;

    public LabelGenerator(IList<string> vocabulary, int label_limit)
    {
      this.vocabulary = vocabulary;
      this.label_limit = label_limit;
      this.sequence = 1;
    }

    public string create_label(int number)
    {
      var length = vocabulary.Count();
      var index = number - 1;

      if (index < length)
        return vocabulary[index];
      return create_label(number % length) + create_label(number / length);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
      while (sequence < label_limit)
      {
        yield return create_label(sequence);
        sequence++;
      }
    }
  }
}