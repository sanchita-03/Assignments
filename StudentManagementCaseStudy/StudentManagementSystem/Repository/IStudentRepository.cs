using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public interface IStudentRepository
    {
        Task<int> AddStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<int> UpdateStudentAsync(Student student);
    }
}
