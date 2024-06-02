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

    }
}
