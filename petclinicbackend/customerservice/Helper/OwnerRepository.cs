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
            /*var ownerlist = new List<AngularWebApi.Models.Owner>();
			using (SqlConnection conn = new SqlConnection("Application Name = Service; Data Source = DELMW51370\\SQLSERVER2014; Initial Catalog = petclinic; Integrated Security = True; Connection Timeout = 120; MultipleActiveResultSets = True; "))
			{
				SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text,
					@"SELECT [id],[first_name],[last_name],[address],[city],[telephone] FROM[dbo].owners", null);
				while (dr.Read())
				{
					AngularWebApi.Models.Owner o = new AngularWebApi.Models.Owner
					{
						id = System.Convert.ToInt32(dr[0]),
						firstName = System.Convert.ToString(dr[1]),
						lastName = System.Convert.ToString(dr[2]),
						address = System.Convert.ToString(dr[3]),
						city = System.Convert.ToString(dr[4]),
						telephone = System.Convert.ToString(dr[5]),
						pet=Enumerable.Empty<AngularWebApi.Models.Pet>().ToArray()
					};
					ownerlist.Add(o);
				}
			}
            return ownerlist.ToArray();*/
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
