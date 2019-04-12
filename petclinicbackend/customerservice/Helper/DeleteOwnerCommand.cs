using System.Data;

namespace petclinicmicroservice.Helper
{
    public class DeleteOwnerCommand:NonQueryCommand
    {
	    private string ownerId;
	    public DeleteOwnerCommand(string ownerId) : base("DeleteOwner")
	    {
		    this.ownerId = ownerId;
	    }


	    protected override void SetParameters(IDbCommand command)
	    {
			AddParameter(command, "@OwnerId", this.ownerId);
		}
    }
}
