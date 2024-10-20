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
            return _db.Addresses.FirstOrDefault(a => a.Id == id);
        }

        public override bool IsExisted(int id)
        {
            throw new NotImplementedException();
        }
    }
}
