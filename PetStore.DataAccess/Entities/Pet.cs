using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.DataAccess.Entities
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
    }
}
