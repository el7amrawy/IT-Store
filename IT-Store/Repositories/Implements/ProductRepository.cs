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

		public IEnumerable<Product> FilterProducts(int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0, int pageNumber = 1, int pageSize = 10)
		{
			if(pageNumber < 1)
				pageNumber = 1;

			var query = _db.Products.AsQueryable();
			if ( categoryId !=0)
				query=query.Where(p => p.CategoryId == categoryId);

			if ( minPrice != 0 )
				query=query.Where(p => p.Price >= minPrice);

			if( maxPrice !=0 )
				query=query.Where(p=>p.Price <= maxPrice);

			if( brandId != 0 )
				query=query.Where(p=>brandId==p.BrandId);

			return query.Where(x=>!x.Isdeleted).OrderByDescending(p=>p.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize).Include(p=>p.Category).ToList();
		}

		public int FilteredProductsCount(int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0)
		{
			var query = _db.Products.AsQueryable();
			if (categoryId != 0)
				query = query.Where(p => p.CategoryId == categoryId);

			if (minPrice != 0)
				query = query.Where(p => p.Price >= minPrice);

			if (maxPrice != 0)
				query = query.Where(p => p.Price <= maxPrice);

			if (brandId != 0)
				query = query.Where(p => brandId == p.BrandId);

			return query.Count(p=>!p.Isdeleted);
		}

		public IEnumerable<Product> Search(string searchTerm, int pageNumber = 1, int pageSize = 10)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
				return FilterProducts();

			var query = _db.Products.AsQueryable();

			query = query.Where(p => p.Name.Contains(searchTerm) || (p.Description != null && p.Description.Contains(searchTerm) ));

			return query.Where(x => !x.Isdeleted).OrderByDescending(p => p.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize).Include(p => p.Category).ToList();
		}

		public IEnumerable<Product> SearchAndFilter(string searchTerm, int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0, int pageNumber = 1, int pageSize = 10)
		{
			if (pageNumber < 1)
				pageNumber = 1;

			var query = _db.Products.AsQueryable();

			if (!string.IsNullOrWhiteSpace(searchTerm))
				query = query.Where(p => p.Name.Contains(searchTerm) || (p.Description != null && p.Description.Contains(searchTerm)));

			if (categoryId != 0)
				query = query.Where(p => p.CategoryId == categoryId);

			if (minPrice != 0)
				query = query.Where(p => p.Price >= minPrice);

			if (maxPrice != 0)
				query = query.Where(p => p.Price <= maxPrice);

			if (brandId != 0)
				query = query.Where(p => brandId == p.BrandId);

			return query.Where(p=>!p.Isdeleted).OrderByDescending(p => p.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize).Include(p => p.Category).ToList();
		}

		public int SearchedAndFilteredCount(string searchTerm, int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0)
		{
			var query = _db.Products.AsQueryable();

			if (!string.IsNullOrWhiteSpace(searchTerm))
				query = query.Where(p => p.Name.Contains(searchTerm) || (p.Description != null && p.Description.Contains(searchTerm)));

			if (categoryId != 0)
				query = query.Where(p => p.CategoryId == categoryId);

			if (minPrice != 0)
				query = query.Where(p => p.Price >= minPrice);

			if (maxPrice != 0)
				query = query.Where(p => p.Price <= maxPrice);

			if (brandId != 0)
				query = query.Where(p => brandId == p.BrandId);

			return query.Count(p => !p.Isdeleted);
		}
	}
}
