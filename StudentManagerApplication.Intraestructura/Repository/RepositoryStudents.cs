using StudentManagerApplication.Applicaction.IRepository;
using StudentManagerApplication.Domain.Entity;

namespace StudentManagerApplication.Intraestructura.Repository
{
    public class RepositoryStudents : IRepositoryStudents
    {
        public Task<Student> Add(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
