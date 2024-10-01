namespace DEPI_Propject_Company_System.Repositoories.Interfaces
{
    public interface ICRUD<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Create(T entity);
        public bool Update(int id, T entity);
        public bool Delete(int id);
        public void Save();
    }
}
