using CodeWith_EFCore.EF_ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWith_EFCore.Controllers
{
    [Route("api/Language")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly EFC_DbContext _eFC_DbContext;
        public CurrencyController(EFC_DbContext eFC_DbContext)
        {
            _eFC_DbContext = eFC_DbContext;
        }
        [HttpGet("FetchLanguage")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var lang = await (from x in _eFC_DbContext.languages
                              select x).ToListAsync();
            return Ok(lang);
        }
        [HttpGet("FetchCurrency")]
        public async Task<IActionResult> GetAllCurrency()
        {
            var cur = await (from x in _eFC_DbContext.currency
                             select x).ToListAsync();
            return Ok(cur);
        }

        [HttpGet("FetchLanguageById{id:int}")]
        public async Task<IActionResult> GetLanguageByIdAsync([FromRoute] int id)
        {
            //var lang = await _eFC_DbContext.languages.Where(x => x.ID == id)
            //            .Select(y=>y).ToListAsync();

            var lang = await _eFC_DbContext.languages.FindAsync(id);
            return Ok(lang);
        }

        [HttpGet("FetchAllCurrecyByName{name}")]
        public async Task<IActionResult> GetAllCurrencyByNameAsync([FromRoute] string name)
        {
            var cur = await (_eFC_DbContext.currency).FirstOrDefaultAsync(x => x.Title == name);
            return Ok(cur);
        }
        // sending two parameters
        [HttpGet("Fetch Language By Para{name}/{discription}")]
        public async Task<IActionResult> GetLanguagebyParaAsync([FromRoute] string name, [FromRoute] string discription)
        {
            //var lang = (from z in _eFC_DbContext.languages
            //            where z.Title == name && z.Description == discription select z)
            //             .FirstOrDefaultAsync();
            //OR
            var lang = await (_eFC_DbContext.languages.FirstOrDefaultAsync(x => 
                        x.Title == name && x.Description == discription));
            return Ok(lang);
        }
        // using optional parameters
        [HttpGet("Fetch language by  Optional pars{name}/{discription}")]
        public async Task<IActionResult> GetLangByOptionalParaAsync(string name,string? discription)
        {
            var lang =await( _eFC_DbContext.languages.
                FirstOrDefaultAsync(x => x.Title == name
                && (string.IsNullOrEmpty(discription) || (x.Description == discription))));
            return Ok(lang);
        }
        [HttpGet("Get Currency by two column{id:int}")]
        public async Task<IActionResult> GetcurrencyBytwoColbyIdAsync(List<int> id)
        {
            var cur = await _eFC_DbContext.currency.
                Where(x => id.Contains(x.ID)).
                Select(c => new Currency
                {
                    ID = c.ID,
                    Description = c.Description
                }).ToListAsync();
            return Ok(cur);
        }
        [HttpPost("PassDynamicly")]
        public async Task<IActionResult> GetRecordDynamicllyAsync([FromBody] List<int> ids)
        {
            var lan = await _eFC_DbContext.languages.
                Where(x => ids.Contains(x.ID))
                .Select( c => new Language
                    {
                        Description = c.Description
                    }
                ).ToListAsync();
            return Ok(lan);
        }
    }
}
