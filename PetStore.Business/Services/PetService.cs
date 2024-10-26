using PetStore.Business.Interfaces;
using PetStore.DataAccess.Context;
using PetStore.DataAccess.Entities;
using PetStore.DataAccess.Interfaces;

namespace PetStore.Business.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;
        private readonly ApplicationDbContext context;
        public PetService(IPetRepository petRepositor) 
        {
            this.petRepository = petRepository;
        }

        public Pet GetPetById(int petId)
        {
            Pet pet = this.petRepository.GetById(petId);
            return pet;
        }

        public IEnumerable<Pet> GetPets()
        {
            var petsArrray = this.petRepository.GetAll();
            return petsArrray;
        }

        public Pet AddPet(Pet pet)
        {
            pet.PetId = this.petRepository.GetMaxPetId() + 1;
            this.petRepository.Add(pet);
            return pet;
        }

        public bool DeletePet(int id)
        {
            var pet = GetPetById(id);
            if (pet == null)
            {
                return false;
            }

            this.petRepository.Delete(id);
            return true;
        }

        public Pet UpdatePet(Pet pet)
        {
            var existingPet = GetPetById(pet.PetId);
            if (existingPet == null)
            {
                return null;
            }

            existingPet.PetName = pet.PetName;
            existingPet.Type = pet.Type;
            existingPet.Age = pet.Age;

            this.petRepository.Update(existingPet);
            return existingPet;
        }
    }
}
