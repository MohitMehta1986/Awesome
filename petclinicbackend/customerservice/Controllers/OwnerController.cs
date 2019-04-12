using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using petclinicmicroservice.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petclinicmicroservice.Controllers
{
    [Route("petclinic/api/owners")]
	[ApiController]
    [EnableCors(PolicyName ="_myAllowSpecificOrigins")]
  
	public class OwnerController : Controller
    {
	    private IOwnerRepository ownerRepository;
	    public OwnerController(IOwnerRepository repository)
	    {
		    this.ownerRepository = repository;
	    }
        // GET: api/<controller>
	    [HttpPost]
	    public void addOwner(AngularWebApi.Models.Owner value)
	    {
		    this.ownerRepository.CreateOwner(value);
	    }

	    // GET api/<controller>/5
        [HttpGet("{ownerid}")]
        public AngularWebApi.Models.Owner FindOwner(string ownerid)
        {
	        return ownerRepository.FindOwner(ownerid);
        }

		//// POST api/<controller>
		[HttpPut("{ownerid}")]
		public void editOwner(AngularWebApi.Models.Owner value)
		{
			ownerRepository.UpdateOwner(value);
		}

		//// PUT api/<controller>/5
		[HttpGet]
		public AngularWebApi.Models.Owner[] GetOwners()
		{
			return ownerRepository.FindAll().ToArray();
		}

		//// DELETE api/<controller>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
