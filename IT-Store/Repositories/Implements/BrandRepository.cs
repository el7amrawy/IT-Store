using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
	public class BrandRepository:Repository<Brand>,IBrandRepository
	{
		private readonly CodexContext _db;

		public BrandRepository(CodexContext db):base(db)
		{
			_db = db;
		}

		public override Brand GetById(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Brand was not found");
			return _db.Brands.FirstOrDefault(b=>b.BrandId==id);
		}

		public override bool IsExisted(int id)
		{
			return _db.Brands.Any(b=>b.BrandId==id);
		}
	}
}
