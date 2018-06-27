using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    interface IDatabase
    {
        void Create(Pet pet);
        Pet Read(int id);
        void Update(Pet pet, int id);
        void Delete(int id);
        IEnumerable<Pet> GetAllPets();
    }
}
