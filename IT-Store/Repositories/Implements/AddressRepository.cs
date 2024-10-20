using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly CodexContext _db;

        public AddressRepository(CodexContext db):base(db)
        {
            _db = db;
        }

        public override Address GetById(int id)
        {
            if (!IsExisted(id)) {
                throw new Exception("Address does not exist");
            }
            return _db.Addresses.FirstOrDefault(a => a.AddressId == id);
        }

		public IEnumerable<Address> GetByUserId(int userId)
		{
			return _db.Addresses.Where(a => a.UserId == userId).ToList();
		}

		public override bool IsExisted(int id)
        {
            return _db.Addresses.Any(a => a.AddressId == id);
        }
    }
}
