using Microsoft.EntityFrameworkCore;
using StudentManagerApplication.Applicaction.IRepository;
using StudentManagerApplication.Domain.Entity;
using StudentManagerApplication.Intraestructura.Data;

namespace StudentManagerApplication.Intraestructura.Repository
{

    public class RepositoryStudents : IRepositoryStudents
    {
        private readonly ApplicationDbContextDB applicationDbContextDB;

        public RepositoryStudents(ApplicationDbContextDB applicationDbContext)
        {
            applicationDbContextDB = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

        }
        public async Task<Student> Add(Student student)
        {
            try
            {
                applicationDbContextDB.Students.Add(student);
                await applicationDbContextDB.SaveChangesAsync();

                throw new Exception("Se creo el estudiante ");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while adding the student.", ex);

            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if(id == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                var student = await applicationDbContextDB.Students.FindAsync(id);
                return true;

            }catch(Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while deleting the student.", ex);
            }

        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                if (applicationDbContextDB.Students == null)
                {
                    throw new ArgumentNullException(nameof(applicationDbContextDB.Students));
                }
                return await applicationDbContextDB.Students.ToListAsync();

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving all students.", ex);
            }

        }

        public async Task<Student> GetById(int id)
        {
            try
            {
               
                var student = await applicationDbContextDB.Students.FindAsync(id);
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

        public async Task<Student> Update(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student));
                }
                var existingStudent = await applicationDbContextDB.Students.FindAsync(student.Id);
                if (existingStudent == null)
                {
                    throw new KeyNotFoundException($"Student with ID {student.Id} not found.");
                }
                applicationDbContextDB.Entry(existingStudent).CurrentValues.SetValues(student);
                await applicationDbContextDB.SaveChangesAsync();
                return existingStudent;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while updating the student.", ex);
            }

        }
    }
}
