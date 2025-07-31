

using StudentManagerApplication.Domain.Entity;

namespace StudentManagerApplication.Applicaction.IRepository
{
    public interface IRepositoryStudents
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task<Student> GetById(int id);
        public Task<Student> Add(Student student);
        public Task<Student> Update(Student student);
        public Task<bool> Delete(int id);

    }
}
