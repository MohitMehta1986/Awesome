using System.Data;
using petclinicmicroservice.Model;

namespace petclinicmicroservice.Helper
{
	public class UpdateOwnerCommand:NonQueryCommand
    {
	    private Owner owner;
	    public UpdateOwnerCommand(Owner owner) : base("UpdateOwner")
	    {
		    this.owner = owner;
	    }

	    protected override void SetParameters(IDbCommand command)
	    {
		    AddParameter(command, "@OwnerId", owner.OwnerId, DbType.Int32);
		    AddParameter(command, "@FirstName", owner.Firstname);
		    AddParameter(command, "@LastName", owner.LastName);
		    AddParameter(command, "@Address", owner.Address);
		    AddParameter(command, "@City", owner.City);
		    AddParameter(command, "@Telephone", owner.Telephone);
		}
	}
}
