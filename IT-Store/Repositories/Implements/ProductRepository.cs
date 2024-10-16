using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly CodexContext _db;

		public ProductRepository(CodexContext db):base(db)
		{
			_db = db;
		}

		public override Product GetById(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Product is not found");
			return _db.Products.FirstOrDefault(p=>p.ProductId == id);
		}

		public override bool IsExisted(int id)
		{
			return _db.Products.Any(p=>p.ProductId == id);
		}
	}
}
