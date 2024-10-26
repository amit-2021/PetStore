using PetStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Business.Interfaces
{
    public interface IPetService
    {
        IEnumerable<Pet> GetPets();
        Pet GetPetById (int petId);
        Pet AddPet(Pet pet);
        Pet UpdatePet(Pet pet);
        bool DeletePet(int id);
    }
}
