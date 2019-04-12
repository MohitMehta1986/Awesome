namespace petclinicmicroservice.AngularWebApi.Models
{
#pragma warning disable IDE1006 // Naming Styles
	public class Owner
    {

		public int? id { get; set; }

		public string firstName { get; set; }
	    public string lastName { get; set; }
	    public string address { get; set; }
		public string city { get; set; }

		public string telephone { get; set; }

		public Pet[] pet { get; set; }
    }
}
