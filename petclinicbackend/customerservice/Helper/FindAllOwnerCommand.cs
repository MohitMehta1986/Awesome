using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using petclinicmicroservice.AngularWebApi.Models;

namespace petclinicmicroservice.Helper
{
    public class FindAllOwnerCommand:ReaderCommand<Owner[]>
	{

	    public FindAllOwnerCommand() : base(CommandType.Text, "SELECT id,first_name,last_name,address,city,telephone FROM owners")
	    {
	    }


	    protected override void SetParameters(IDbCommand command)
	    {
		    
	    }

	    protected override Owner[] ProcessReader(IDataReader reader)
	    {
		    var ownerlist = new List<Owner>();
			while (reader.Read())
		    {
			    Owner o = new AngularWebApi.Models.Owner
			    {
				    id = System.Convert.ToInt32(reader[0]),
				    firstName = System.Convert.ToString(reader[1]),
				    lastName = System.Convert.ToString(reader[2]),
				    address = System.Convert.ToString(reader[3]),
				    city = System.Convert.ToString(reader[4]),
				    telephone = System.Convert.ToString(reader[5]),
				    pet = Enumerable.Empty<AngularWebApi.Models.Pet>().ToArray()
			    };
			    ownerlist.Add(o);
		    }
			return ownerlist.ToArray();

	    }
	}
}
