using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IT_Store.Repositories.Implements
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly CodexContext _db;

		public CategoryRepository(CodexContext db):base(db)
		{
			_db = db;
		}

        public IEnumerable<Category> GetAllWithParentCategory()
        {
            return _db.Categories.Include(c=>c.ParentCategory).ToList();
        }

        public override Category GetById(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Category was not found");
			return _db.Categories.FirstOrDefault(c => c.CategoryId== id);
		}

		public override bool IsExisted(int id)
		{
			return _db.Categories.Any(c=>c.CategoryId== id);
		}
	}
}
