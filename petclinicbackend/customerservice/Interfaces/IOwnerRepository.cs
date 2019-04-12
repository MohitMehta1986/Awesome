namespace petclinicmicroservice.Interfaces
{
	public interface IOwnerRepository
    {
	    void CreateOwner(AngularWebApi.Models.Owner owner);
	    AngularWebApi.Models.Owner FindOwner(string ownerid);
	    void DeleteOwner(string ownerId);
	    AngularWebApi.Models.Owner[] FindAll();
	    void UpdateOwner(AngularWebApi.Models.Owner owner);
    }
}
