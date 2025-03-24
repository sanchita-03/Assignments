using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<int> UpdateStudentAsync(Student student);
    }
}
