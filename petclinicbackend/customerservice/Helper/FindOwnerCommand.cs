using System.Data;
using petclinicmicroservice.Model;



namespace petclinicmicroservice.Helper
{
    public class FindOwnerCommand:ReaderCommand<Owner>
    {
	    private string ownerId;

	    public FindOwnerCommand(string ownerId) : base(CommandType.StoredProcedure, "FindOwner")
	    {
		    this.ownerId = ownerId;
	    }

	    
	    protected override void SetParameters(IDbCommand command)
	    {
			AddParameter(command, "@OwnerId", this.ownerId);
		}

	    protected override Owner ProcessReader(IDataReader reader)
	    {
			var owner=new Owner();
		    while (reader.Read())
		    {
				owner.OwnerId= reader["OwnerId"].ToString();
				owner.Firstname = reader["FirstName"].ToString();
			    owner.LastName = reader["LastName"].ToString();
			    owner.Address = reader["Address"].ToString();
			    owner.City = reader["City"].ToString();
			    owner.Telephone = reader["Telephone"].ToString();
			    
		    }
		    return owner;
	    }
	}
}
