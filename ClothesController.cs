using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        //adding default clothes
        private static List<clothes> products = new List<clothes>
        {
            new clothes {
                Id = 1,
                Name ="blue jean",
                Category ="Jean",
                Material ="Cotton",
                CutType = "Skinny"
            },
            new clothes {
                Id = 2,
                Name ="purple tshirt",
                Category ="tshirt",
                Material ="Cotton",
                CutType = "Large"
            }
        };

        //getting all the clothes which is avaible 
        [HttpGet]
        public async Task<ActionResult<List<clothes>>> Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<clothes>> Get(int id)
        {
            var clothe = products.Find(h=> h.Id ==id);
            if(clothe == null)
            {
                return BadRequest("Clothes is not found.");
            }
            return Ok(clothe);
        }

        //Posting a new clothes
        [HttpPost]
        public async Task<ActionResult<List<clothes>>> AddClothes(clothes clothe)
        {
            products.Add(clothe);
            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<List<clothes>>> UpdateClothes(clothes request)
        {
            var clothe = products.Find(h => h.Id == request.Id);
            if (clothe == null)
            {
                return BadRequest("Clothes is not found.");
            }
            clothe.Name=request.Name;
            clothe.Category=request.Category;
            clothe.Material=request.Material;
            clothe.CutType=request.CutType;

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<clothes>>> Delete(int id)
        {
            var clothe = products.Find(h => h.Id == id);
            if (clothe == null)
            {
                return BadRequest("Clothes is not found.");
            }
            return Ok(clothe);
        }



    }
}
