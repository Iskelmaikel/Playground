using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.LanguageLearning.Services
{
    public class SentenceGeneratorService
    {
        public SentenceGeneratorService() {
        
        }

        public void GenerateSentence()
        {
            string subject = "";
            string verb = "";
            string obj = "";
            string sentenceTemplate = $"{subject} {verb} {obj}";
        }
    }
}
