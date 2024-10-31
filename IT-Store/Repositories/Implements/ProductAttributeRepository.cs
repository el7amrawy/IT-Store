using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
	public class ProductAttributeRepository : Repository<ProductAttribute>,IProductAttributeRepository
	{
		private readonly CodexContext _db;
		public ProductAttributeRepository(CodexContext db) : base(db)
		{
			_db = db;
		}

		public override ProductAttribute GetById(int id)
		{
			if (IsExisted(id))
				throw new Exception("Product attribute doesn't exist");
			return _db.ProductAttributes.FirstOrDefault(a => a.Id == id);
		}

		public override bool IsExisted(int id)
		{
			return _db.ProductAttributes.Any(a => a.Id == id);
		}
	}
}
