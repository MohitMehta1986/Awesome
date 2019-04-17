using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using petclinicmicroservice.Interfaces;
using petclinicmicroservice.Model;

namespace petclinicmicroservice.Helper
{
	public class OwnerRepository:IOwnerRepository
    {
	    private IDbConnection dbConnection;
	    public OwnerRepository(IDbConnection dbConnection)
	    {
		    this.dbConnection = dbConnection;

	    }
		//var conn = new SqlConnection("Server=(local);DataBase=master;Integrated Security=SSPI");
	    public void CreateOwner(AngularWebApi.Models.Owner owner)
	    {
		    var dbowner = new Owner()
		    {
			    Firstname = owner.firstName,
			    LastName = owner.lastName,
			    Address = owner.address,
			    City = owner.city,
			    Telephone = owner.telephone
		    };
		    var createOwnerCommand = new CreateOwnerCommand(dbowner);
		    createOwnerCommand.Execute(dbConnection);
	    }

	    public AngularWebApi.Models.Owner FindOwner(string ownerid)
	    {
		    var findOwnerCommand = new FindOwnerCommand(ownerid);
		    findOwnerCommand.Execute(dbConnection);
		    var result = new AngularWebApi.Models.Owner()
		    {
			    address = findOwnerCommand.Result.Address,
			    city = findOwnerCommand.Result.City,
			    firstName = findOwnerCommand.Result.Firstname,
			    id = int.Parse(findOwnerCommand.Result.OwnerId),
			    lastName = findOwnerCommand.Result.LastName,
			    telephone = findOwnerCommand.Result.Telephone,
			    pet = Enumerable.Empty<AngularWebApi.Models.Pet>().ToArray()
		    };

			return result;
	    }

	    public void DeleteOwner(string ownerId)
	    {

		    var deleteOwnerCommand = new DeleteOwnerCommand(ownerId);
		    deleteOwnerCommand.Execute(dbConnection);
		}

	    public AngularWebApi.Models.Owner[] FindAll()
        {
			var findAllOwnerCommand=new FindAllOwnerCommand();
	        findAllOwnerCommand.Execute(dbConnection);
	        return findAllOwnerCommand.Result;
        }

        public void UpdateOwner(AngularWebApi.Models.Owner owner)
        {
			var dbowner=new Owner(owner);
            var updateCommand=new UpdateOwnerCommand(dbowner);
			updateCommand.Execute(dbConnection);
        }
    }
}
