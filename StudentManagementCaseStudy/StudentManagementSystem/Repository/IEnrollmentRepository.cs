
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public interface IEnrollmentRepository
    {
        Task<int> EnrollStudentAsync(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
        Task<int> WithdrawStudentAsync(int studentId, int courseId);
        Task<Enrollment> GetEnrollmentByStudentAndCourseAsync(int studentId, int courseId);
    }
}
