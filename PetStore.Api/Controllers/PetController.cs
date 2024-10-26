using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Interfaces;
using PetStore.DataAccess.Context;
using PetStore.DataAccess.Entities;
using PetStore.Logger.Enums;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly PetStore.Logger.Logging.Interfaces.ILogger _logger;
        private readonly ApplicationDbContext _context;
        public PetController(IPetService productService, ApplicationDbContext context) 
        {
            _petService = productService;
            _logger = PetStore.Logger.Logging.LoggerFactory.CreateLogger(LogType.Database);
            _context = context;
        }

        [HttpGet(Name = "GetAllPets")]
        public IEnumerable<Pet> Get()
        {
            try
            {
                var data = this._context.Pets.ToList();
            }
            catch (Exception ex) 
            { 
            }
            _logger.Log("Getting all pets");
            return _petService.GetPets();
        }

        [HttpGet("{id}", Name = "GetPetById")]
        public ActionResult<Pet> GetPetById(int id)
        {
            var pet = _petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpPost]
        public ActionResult<Pet> AddPet([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("Pet cannot be null");
            }

            var createdPet = _petService.AddPet(pet);
            return CreatedAtRoute("GetPetById", new { id = createdPet.PetId }, createdPet);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> UpdatePet(int id, [FromBody] Pet pet)
        {
            if (pet == null || pet.PetId != id)
            {
                return BadRequest("Pet data is invalid");
            }

            var updatedPet = _petService.UpdatePet(pet);
            if (updatedPet == null)
            {
                return NotFound();
            }
            return Ok(updatedPet);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            var deleted = _petService.DeletePet(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
