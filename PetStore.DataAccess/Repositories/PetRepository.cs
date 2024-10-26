using PetStore.DataAccess.Context;
using PetStore.DataAccess.Entities;
using PetStore.DataAccess.Interfaces;

namespace PetStore.DataAccess.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        public Pet GetById(int id)
        {
            return _context.Pets.Find(id);
        }

        public void Add(Pet Pet)
        {
            _context.Pets.Add(Pet);
            _context.SaveChanges();
        }

        public void Update(Pet Pet)
        {
            _context.Pets.Update(Pet);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Pet = _context.Pets.Find(id);
            if (Pet != null)
            {
                _context.Pets.Remove(Pet);
                _context.SaveChanges();
            }
        }

        public int GetMaxPetId()
        {
            return _context.Pets.Max(p => p.PetId);
        }
    }
}
