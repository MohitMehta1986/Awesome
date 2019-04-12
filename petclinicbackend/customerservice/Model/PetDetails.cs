using System;

namespace petclinicmicroservice.Model
{
    public class PetDetails
    {
        public string OwnerId { get; set;}

        public int PetId { get; set; }

        public string Name { get; set; }

        public String Owner { get; set; }

        public DateTime Date { get; set; }

        public PetType Type { get; set; }


        public PetDetails(Pet pet, Owner owner)
        {
            this.OwnerId = owner.OwnerId;
            this.PetId = pet.PetId;
            this.Name = pet.Name;
            this.Owner = string.Format("{0} {1}", owner.Firstname, owner.LastName);
            this.Date = pet.BirthDate;
            this.Type = pet.PetType;
        }

    }
}
