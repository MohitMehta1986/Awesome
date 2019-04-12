using System;

namespace petclinicmicroservice.Model
{
    public class Pet
    {
        public int PetId { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public PetType PetType { get; set; }

    }
}
