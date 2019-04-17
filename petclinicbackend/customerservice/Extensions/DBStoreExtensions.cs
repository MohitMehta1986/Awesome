using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;
using petclinicmicroservice.AngularWebApi.Models;

namespace petclinicmicroservice.Extensions
{
	public static class DatastoreBookStoreExtensionMethods
	{
		/// <summary>
		/// Make a datastore key given a book's id.
		/// </summary>
		/// <param name="id">A book's id.</param>
		/// <returns>A datastore key.</returns>
		public static Key ToKey(this string id) =>
			new Key().WithElement("owner", id);

		/// <summary>
		/// Make a book id given a datastore key.
		/// </summary>
		/// <param name="key">A datastore key</param>
		/// <returns>A book id.</returns>
		public static long ToId(this Key key) => key.Path.First().Id;

		/// <summary>
		/// Create a datastore entity with the same values as book.
		/// </summary>
		/// <param name="book">The book to store in datastore.</param>
		/// <returns>A datastore entity.</returns>
		/// [START toentity]
		public static Entity ToEntity(this Owner owner) => new Entity()
		{
			/* id INT(4) UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  first_name VARCHAR(30),
  last_name VARCHAR(30),
  address VARCHAR(255),
  city VARCHAR(80),
  telephone VARCHAR(20),
  INDEX(last_name)*/

			Key = owner.id.ToString().ToKey(),
			["first_name"] = owner.firstName,
			["last_name"] = owner.lastName,
			["address"] = owner.address,
			["city"] = owner.city,
			["telephone"] = owner.telephone
			,};
		// [END toentity]

		/// <summary>
		/// Unpack a book from a datastore entity.
		/// </summary>
		/// <param name="entity">An entity retrieved from datastore.</param>
		/// <returns>A book.</returns>
		public static Owner ToOwner(this Entity entity) => new Owner()
		{
			id = unchecked((int)entity.Key.Path.First().Id),
			firstName = (string)entity["first_name"],
			lastName = (string)entity["lastname"],
			address = (string)entity["address"],
			city = (string)entity["city"],
			telephone = (string)entity["telephone"],
			
		};
	}
}
