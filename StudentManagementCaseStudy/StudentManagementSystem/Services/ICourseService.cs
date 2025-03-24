
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface ICourseService
    {
        Task<int> AddCourseAsync(Course course);
        Task<int> DeleteCourseAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<int> UpdateCourseAsync(Course course);
    }
}
