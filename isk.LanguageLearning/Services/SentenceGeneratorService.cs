using isk.LanguageLearning.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.LanguageLearning.Services
{
    public class SentenceGeneratorService : ISentenceGeneratorService
    {
        public SentenceGeneratorService()
        {

        }

        public void GenerateSentence()
        {
            string subject = "";
            string verb = "";
            string obj = "";
            string sentenceTemplate = $"{subject} {verb} {obj}";
        }

        public void CreateSentenceBasedOnStructure(Case _case)
        {
            switch (_case)
            {
                case Case.Nominative_Case:

                    break;
            }
        }

        private void createSentenceNonimativeCase(string subject, string verb, string obj)
        {

        }
        private void createSentenceAccusativeCase(string subject, string verb, string obj)
        {

        }

        public string ConjugateVerb(string stem, VerbFormEnum verbForm, VerbTypeEnum verbType)
        {
            var conjugation = stem;

            switch (verbForm)
            {
                case VerbFormEnum.minä:
                    conjugation += "n";
                    break;
                case VerbFormEnum.sinä:
                    conjugation += "t";
                    break;
                case VerbFormEnum.hän:
                    if (verbType == VerbTypeEnum.verb2)
                    {

                    }
                    else if (verbType == VerbTypeEnum.verb1 || verbType == VerbTypeEnum.verb4)
                    {
                        conjugation += stem.Substring(stem.Length - 1, 1);
                        //conjugation += "a";
                    }
                    
                    break;
                case VerbFormEnum.me:
                    conjugation += "mme";
                    break;
                case VerbFormEnum.te:
                    conjugation += "tte";
                    break;
                case VerbFormEnum.he:
                    conjugation += "vat";
                    break;
            }

            return conjugation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="infiniteVerb"></param>
        /// <param name="verbForm"></param>
        /// <returns>Tuple containing verb type and stem</returns>
        public (string, string, VerbTypeEnum) determineStemAndVerbType(string infiniteVerb, VerbFormEnum verbForm)
        {
            VerbTypeEnum verbType = VerbTypeEnum.unknown;
            var stem = string.Empty;
            string[] typeOneEndings = { "aa", "ea", "eä", "ia", "oa", "ua", "yä", "ää", "öä" };
            string[] typeTwoEndings = { "dä", "da" };
            string[] typeThreeEndings = { "lla", "llä", "nna", "nnä", "rra", "rrä", "sta", "stä" };
            string[] typeFourEndings = { "ata", "ätä", "ota", "ötä", "uta", "ytä" };
            string[] typeFiveEndings = { "ita", "itä" };
            string[] typeSixEndings = { "ta", "tä" };

            if (typeOneEndings.Any(end => infiniteVerb.EndsWith(end)) == true)
            {
                //To find this type of verb’s infinitive stem, you remove the final -a or -ä from the infinitive.
                stem = infiniteVerb.Remove(infiniteVerb.Length - 1, 1);
                verbType = VerbTypeEnum.verb1;
            }
            else if (typeTwoEndings.Any(end => infiniteVerb.EndsWith(end)) == true)
            {
                //To find this type of verb’s infinitive stem,
                //you remove the -da/-dä. Notice that the third person singular doesn’t get the
                //final letter doubled like in verbtype 1!

                stem = infiniteVerb.Remove(infiniteVerb.Length - 2, 2);
                verbType = VerbTypeEnum.verb2;
            }
            else if (typeThreeEndings.Any(end => infiniteVerb.EndsWith(end)) == true)
            {
                //To find these verbs’ infinitive stem, remove the -la/-lä, -na/-nä, -ra/-rä, or -ta/-tä.
                //To this stem, you add an -e- before adding the personal ending!

                stem = infiniteVerb.Remove(infiniteVerb.Length - 2, 2);
                stem += "e";
                verbType = VerbTypeEnum.verb3;
            }
            else if (typeFourEndings.Any(end => infiniteVerb.EndsWith(end)) == true)
            {
                //To find this type of verb’s infinitive stem, you remove the -t (so NOT the final -a!).
                //Some sources will tell you to remove the -ta and then add an -a.
                //This comes down to the same thing.

                stem = infiniteVerb.Remove(infiniteVerb.Length - 2, 1);

                // Probably the wrong place here...
                // If we're talking about the third person singular (se-case)
                //if (verbForm == VerbFormEnum.se)
                //{
                //    var lastTwoLetters = infiniteVerb.Substring(infiniteVerb.Length - 2);

                //    // If the final two letters are not the same, add a letter
                //    if (infiniteVerb.Substring(0, 1) != infiniteVerb.Substring(infiniteVerb.Length - 1))
                //    {
                //        stem += infiniteVerb.Substring(infiniteVerb.Length - 1);
                //    }
                //}
                verbType = VerbTypeEnum.verb4;
            }
            else if (typeFiveEndings.Any(end => infiniteVerb.EndsWith(end)) == true)
            {
                //To find this type of verb’s infinitive stem, you remove the final -ta/-tä.
                //To this stem, you then add -tse- before adding the personal ending!

                stem = infiniteVerb.Remove(infiniteVerb.Length - 2, 2);
                stem += "tse";
                verbType = VerbTypeEnum.verb5;
            }
            else if (typeSixEndings.Any(end => infiniteVerb.EndsWith(end)) == true)
            {
                //To find the infinitive stem for verbtype 6, you remove the final -ta/-tä.
                //To this stem, you then add -ne- before adding the personal ending.
                stem = infiniteVerb.Remove(infiniteVerb.Length - 2, 2);
                stem += "ne";
                verbType = VerbTypeEnum.verb6;
            }

            return (stem, stem, verbType);
        }

        void ISentenceGeneratorService.createSentenceNonimativeCase(string subject, string verb, string obj)
        {
            throw new NotImplementedException();
        }

        void ISentenceGeneratorService.createSentenceAccusativeCase(string subject, string verb, string obj)
        {
            throw new NotImplementedException();
        }
    }
}
