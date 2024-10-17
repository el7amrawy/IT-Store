using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IT_Store.Repositories.Implements
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly CodexContext _db;

		public ProductRepository(CodexContext db):base(db)
		{
			_db = db;
		}
        public override IEnumerable<Product> GetAll()
        {
            return _db.Products.Where(p=>!p.Isdeleted).ToList();
        }
        public override Product GetById(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Product is not found");
			return _db.Products.FirstOrDefault(p=> !p.Isdeleted && p.ProductId == id);
		}
        public override void Delete(int id)
        {
			var product = GetById(id);
			product.Isdeleted = true;
			product.DeletedAt = DateTime.Now;
			Update(product);
        }
        public override bool IsExisted(int id)
		{
			return _db.Products.Any(p=>p.ProductId == id);
		}

		public Product GetByIdWithCategory(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Product is not found");
			return _db.Products.Include(p=>p.Category).FirstOrDefault(p => p.ProductId == id);
		}

		public IEnumerable<Product> GetAllWithCategory(int pageNumber=1, int pageSize = 10)
		{
			return _db.Products.OrderByDescending(p => p.CreatedAt).Skip((pageNumber - 1)*pageSize).Take(pageSize).Include(p=>p.Category).ToList();
		}
	}
}
