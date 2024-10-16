using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
    public class ParentCategoryRepository : Repository<ParentCategory>, IParentCategoryRepository
    {
        private readonly CodexContext _db;

        public ParentCategoryRepository(CodexContext db):base(db)
        {
            _db = db;
        }

        public override ParentCategory GetById(int id)
        {
            if (!IsExisted(id))
                throw new Exception("Parent category is not found");
            return _db.ParentCategories.FirstOrDefault(p => p.CategoryId == id);
        }

        public override bool IsExisted(int id)
        {
            return _db.ParentCategories.Any(p => p.CategoryId == id);
        }
    }
}
