namespace petclinicmicroservice.AngularWebApi.Models
{
#pragma warning disable IDE1006 // Naming Styles
	public class Visit
    {
		public int id { get; set; }
		public string date { get; set; }
		public string description { get; set; }
		public Pet pet { get; set; }
		/*id: number;
  date: string;
  description: string;
  pet: Pet;*/
	}
}
