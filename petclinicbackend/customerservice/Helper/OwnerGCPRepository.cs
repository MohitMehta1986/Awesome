using Google.Cloud.Datastore.V1;
using petclinicmicroservice.AngularWebApi.Models;
using petclinicmicroservice.Extensions;
using petclinicmicroservice.Interfaces;
using System;
using System.Linq;

namespace petclinicmicroservice.Helper
{
	public class OwnerGcpRepository:IOwnerRepository
    {
	    private readonly string projectId;
	    private readonly DatastoreDb db;
		public OwnerGcpRepository(string projectId)
		{
			this.projectId = projectId;
			db=DatastoreDb.Create(projectId);
		}
	    public void CreateOwner(Owner owner)
	    {
		    var entity = owner.ToEntity();
		    db.Insert(new[] {entity});
	    }

	    public Owner FindOwner(string ownerid)
	    {
			return db.Lookup(ownerid.ToKey())?.ToOwner();
		}

	    public void DeleteOwner(string ownerId)
	    {
		    db.Delete(ownerId.ToKey());
	    }

	    public Owner[] FindAll()
	    {
			var query = new Query("owner") { Limit = 10 };
		    var results = db.RunQuery(query);
		    return results.Entities.Select(entity => entity.ToOwner()).ToArray();
	    }

	    public void UpdateOwner(Owner owner)
	    {
			db.Update(owner.ToEntity());
		}
    }
}
