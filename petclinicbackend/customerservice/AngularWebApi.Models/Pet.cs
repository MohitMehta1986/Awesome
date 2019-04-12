using petclinicmicroservice.Model;

namespace petclinicmicroservice.AngularWebApi.Models
{
#pragma warning disable IDE1006 // Naming Styles
	public class Pet
    {
		public int id { get; set; }
		public string name { get; set; }
		public string birthDate { get; set; }

	    public PetType type { get; set; }
		public Visit[] visits { get; set; }
	    /*id: number;
	    name: string;
	    birthDate: string;
	    type: PetType;
	    owner: Owner;
	    visits: Visit[];*/
    }
}
