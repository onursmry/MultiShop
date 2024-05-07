namespace MultiShop.Cargo.DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T GetById(int id);
    List<T> GetAll();
}