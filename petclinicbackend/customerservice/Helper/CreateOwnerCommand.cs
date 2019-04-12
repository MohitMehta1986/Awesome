using System.Data;
using petclinicmicroservice.Model;

namespace petclinicmicroservice.Helper
{
    public class CreateOwnerCommand: NonQueryCommand
    {
	    private Owner owner;
		public CreateOwnerCommand(Owner owner):base(CommandType.StoredProcedure,"CreateOwner")
		{
			this.owner = owner;
		}

	    protected override void SetParameters(IDbCommand command)
	    {
		    AddParameter(command,"@FirstName",owner.Firstname);
		    AddParameter(command, "@LastName", owner.LastName);
		    AddParameter(command, "@Address", owner.Address);
		    AddParameter(command, "@City", owner.City);
		    AddParameter(command, "@Telephone", owner.Telephone);
		}
    }
}
