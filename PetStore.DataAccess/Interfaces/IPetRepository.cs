using PetStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.DataAccess.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetAll();
        Pet GetById(int id);
        void Add(Pet product);
        void Update(Pet product);
        void Delete(int id);
        int GetMaxPetId();
    }
}
