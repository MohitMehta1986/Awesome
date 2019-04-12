namespace petclinicmicroservice.Model
{
    public class Owner
    {
	    public Owner()
	    {
		    OwnerId = string.Empty;
		    Firstname = string.Empty;
		    LastName = string.Empty;
		    Address = string.Empty;
		    City = string.Empty;
	    }


	    public Owner(AngularWebApi.Models.Owner owner)
	    {
		    Firstname = owner.firstName;
		    LastName = owner.lastName;
		    Address = owner.address;
		    City = owner.city;
		    Telephone = owner.telephone;
		    OwnerId = owner.id.ToString();
	    }

		public string OwnerId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }

    }
}
