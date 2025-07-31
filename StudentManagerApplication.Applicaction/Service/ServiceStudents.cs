
using StudentManagerApplication.Applicaction.IRepository;
using StudentManagerApplication.Applicaction.IService;
using StudentManagerApplication.Domain.Entity;

namespace StudentManagerApplication.Applicaction.Service
{
   
    public class ServiceStudents : IServiceStudents
    {

        private readonly IRepositoryStudents repositoryStudents ;

        public ServiceStudents(IRepositoryStudents repository)
        {
            repositoryStudents = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        public async Task AddStudentAsync(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student));
                }
                await repositoryStudents.Add(student);

            }
            catch(Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while adding the student.", ex);
            }

        }

        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
                }
                var exists = await repositoryStudents.Delete(id);
                if (!exists)
                {
                    throw new KeyNotFoundException($"Student with ID {id} not found.");
                }

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while deleting the student.", ex);

            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {

            try
            {
                var students = await repositoryStudents.GetAll();
                if (students == null || !students.Any())
                {
                    throw new KeyNotFoundException("No students found.");
                }
                return students;

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving all students.", ex);
            }
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
                }
                var student = await repositoryStudents.GetById(id);
                if (student == null)
                {
                    throw new KeyNotFoundException($"Student with ID {id} not found.");
                }
                return student;

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving the student by ID.", ex);



            }
        }

        public async Task<bool> StudentExistsAsync(int id)
        {

            try
            {

                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
                }
                var student = await repositoryStudents.GetById(id);
                return student != null;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while checking if the student exists.", ex);
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student));
                }
                var existingStudent = await repositoryStudents.GetById(student.Id);
                if (existingStudent == null)
                {
                    throw new KeyNotFoundException($"Student with ID {student.Id} not found.");
                }
                await repositoryStudents.Update(student);

            }
            catch(Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while updating the student.", ex);
            }
        }
    }
}
