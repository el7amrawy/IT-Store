namespace IT_Store.Repositories.Interfaces
{
	public interface IRepository<Model>
	{
		public Model GetById(int id);
		public IEnumerable<Model> GetAll();
		public void Add(Model entity);
		public void Update(Model entity);
		public void Delete(Model entity);
		public void Save();
		public bool IsExisted(int id);
	}
}
