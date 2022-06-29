using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase //default
    {
        public readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        /*public static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id= 1,
                Name="IronMan",
                RealName="Tony",
                SurName="Stark",
                Address="Malibu"
            }
        };*/
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            // return Ok(heroes)
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        /* [HttpGet("{id}")]
         public async Task<ActionResult<SuperHero>> Get(int id)
         {
             var hero = heroes.Find(el => el.Id == id);
             if (hero == null)
                 return BadRequest("Empty Data");
             return Ok(hero);

         }*/
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Empty Data");
            return Ok(hero);

        }
        /*
        [HttpPost]
        public async Task<ActionResult<SuperHero>> addHero(SuperHero hero)
        {
             heroes.Add(hero);
            return Ok(heroes);
        }*/
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
         
            
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
           /*
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)

        {
            var hero=heroes.Find(el => el.Id == request.Id);
            if (hero == null)
                return BadRequest("Data not found ");
            hero.Name = request.Name;
            hero.RealName = request.RealName;
            hero.SurName = request.SurName;
            hero.Address = request.Address;
            return Ok(hero);
        }*/  
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)

        {
            var hero=await _context.SuperHeroes.FindAsync(request.Id);
            if (hero == null)
                return BadRequest("Data not found ");
            hero.Name = request.Name;
            hero.RealName = request.RealName;
            hero.SurName = request.SurName;
            hero.Address = request.Address;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
  
        /*
       [HttpDelete("{id}")]

       public async Task<ActionResult<SuperHero>> Delete(int id)
       {
           var hero = heroes.Find(el => el.Id == id);
           if (hero == null)
               return BadRequest("Empty Data");
           heroes.Remove(hero);
           return Ok(hero);

       }
         */

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero=await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Empty Data");
            _context.SuperHeroes.Remove(hero);
     
            await _context.AddRangeAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

        }
    }
}



