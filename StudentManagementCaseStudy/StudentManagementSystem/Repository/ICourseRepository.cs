using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public interface ICourseRepository
    {
        Task<int> AddCourseAsync(Course course);
        Task<int> DeleteCourseAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<int> UpdateCourseAsync(Course course);
    }
}
