using isk.Database.Repository;
using isk.GeneralAPI.DAL.Entities;
using isk.LanguageLearning.Enums;
using isk.LanguageLearning.Services;
using Microsoft.AspNetCore.Mvc;

namespace isk.GeneralAPI.Controllers
{
    [Route("Grammar")]
    [ApiController]
    public class GrammarController : BaseController
    {
        private ISentenceGeneratorService _sentenceGeneratorService;
        public GrammarController(IRepository repository,ISentenceGeneratorService sentenceGenerator) : base(repository)
        {
            _sentenceGeneratorService = sentenceGenerator;
        }

        [HttpGet]
        [Route("GetStem/{form}/{infinitive}")]
        public IActionResult GetStem(string infinitive, VerbFormEnum form)
        {
            var stem = _sentenceGeneratorService.determineStemAndVerbType(infinitive, form);
            var conjugation = _sentenceGeneratorService.ConjugateVerb(stem.Item1, form, stem.Item3);

            return Ok($"The stem is '{stem.Item1}' (verb type {stem.Item3}). Conjugated with {form.ToString()} the verb should be {conjugation}. Example: {form} {conjugation} [...]");
        }
    }
}
