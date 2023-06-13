using isk.LanguageLearning.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.LanguageLearning.Services
{
    public interface ISentenceGeneratorService
    {
        void GenerateSentence();
        void CreateSentenceBasedOnStructure(Case _case);
         void createSentenceNonimativeCase(string subject, string verb, string obj);
        void createSentenceAccusativeCase(string subject, string verb, string obj);
        (string, string, VerbTypeEnum) determineStemAndVerbType(string infiniteVerb, VerbFormEnum verbForm);
        string ConjugateVerb(string stem, VerbFormEnum verbForm, VerbTypeEnum verbType);
    }
}
