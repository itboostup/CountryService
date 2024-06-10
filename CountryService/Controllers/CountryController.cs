using CountryService.DAL;
using CountryService.Helper;
using CountryService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountryController : ControllerBase
    {
        private readonly CountryContext _context;

        public CountryController(CountryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int no1 = 10;
            int no2 = 0;
            int result = no1 / no2;
            Console.WriteLine(result);

            var countrys = await _context.Country.ToListAsync();
            return Ok(countrys);
        }

        [HttpGet("GetCountryByID")]
        public async Task<IActionResult> GetById(int id)
        {
            int[] array = { 1, 2, 3 };
            int inex = 5;
            int value = array[5];
            var countrys = _context.Country.Where(e => e.CountryId == id);
            return Ok(countrys);
        }
        [HttpPost("CreateCountry)")]
        public async Task<IActionResult> AddCountry([FromBody] Country country)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _context.Country.Any(e => e.CountryName.Trim().ToLower() == country.CountryName.Trim().ToLower());
            if (isExist)
            {
                return Ok("Country already exist , try with another country name");
            }
            _context.Country.Add(country);
            int savedStatus = await _context.SaveChangesAsync();
            if (savedStatus == 1)
                return Ok("Recored saved successfully");
            else
                return BadRequest("Recored not saved successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCountry(int id, Country country)
        {
            if (id != country.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!countryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool countryExists(int id)
        {
            return _context.Country.Any(e => e.CountryId == id);
        }
    }
}
