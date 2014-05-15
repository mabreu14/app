using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.utility
{
    public class LabelGenerator
    {
        int label_limit;
        IList<char> vocabulary;
        int sequence;

        public LabelGenerator(IList<char> vocabulary, int label_limit)
        {
            this.vocabulary = vocabulary;
            this.label_limit = label_limit;
            this.sequence = 0;
        }

        public string create_label()
        {
            string label="";
            int modulo=sequence;
            int length = vocabulary.Count();
            do
            {
                label+=vocabulary[modulo%length];
                modulo /= length;
            }
            while(modulo>0);
            sequence++;
            return label;
        }
    }
}
