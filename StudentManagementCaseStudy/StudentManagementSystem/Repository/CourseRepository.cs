using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        readonly StudentDbContext _studentDbContext;
        public CourseRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<int> AddCourseAsync(Course course)
        {
            _studentDbContext.Courses.Add(course);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCourseAsync(int id)
        {
            Course course = await GetCourseByIdAsync(id);
            _studentDbContext.Courses.Remove(course);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _studentDbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _studentDbContext.Courses.FindAsync(id);
        }

        public Task<int> UpdateCourseAsync(Course course)
        {
            _studentDbContext.Courses.Update(course);
            return _studentDbContext.SaveChangesAsync();
        }
    }
}
