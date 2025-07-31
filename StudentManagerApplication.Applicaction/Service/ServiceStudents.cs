using StudentManagerApplication.Applicaction.IService;
using StudentManagerApplication.Domain.Entity;

namespace StudentManagerApplication.Applicaction.Service
{
    public class ServiceStudents : IServiceStudents
    {
        public Task AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StudentExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
