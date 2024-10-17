using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
	public abstract class Repository<Model> : IRepository<Model> where Model : class
	{
		private readonly CodexContext _db;

		public Repository(CodexContext db)
		{
			_db = db;
		}

		public void Add(Model entity)
		{
			_db.Add(entity);
		}

		public virtual void Delete(int id)
		{
			var entity = GetById(id);
			_db.Remove(entity);
		}

		public virtual IEnumerable<Model> GetAll()
		{
			return _db.Set<Model>().ToList();
		}

		public abstract Model GetById(int id);

		public abstract bool IsExisted(int id);

		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Model entity)
		{
			_db.Update(entity);
		}
	}
}
