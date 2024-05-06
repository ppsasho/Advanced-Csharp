using Models;
namespace Storage
{
    public interface IDataSet<T> where T : Base
    {
        void Add(T user);
        List<T> GetAll();
        void Update(T user);
    }
}
