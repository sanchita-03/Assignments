using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        readonly StudentDbContext _studentDbContext;
        public EnrollmentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<int> EnrollStudentAsync(int studentId, int courseId)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.StudentId = studentId;
            enrollment.CourseId = courseId;
            await _studentDbContext.Enrollments.AddAsync(enrollment);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _studentDbContext.Enrollments.Include(a => a.Course).Include(s=>s.Student).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            return await _studentDbContext.Enrollments
                         .Include(s=>s.Student)
                         .Include(s=>s.Course)
                         .Where(s => s.StudentId == studentId)
                         .ToListAsync();
        }

        public async Task<int> WithdrawStudentAsync(int studentId, int courseId)
        {
            Enrollment enrollment = await _studentDbContext.Enrollments.FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);
            if (enrollment == null)
                return 0;
            _studentDbContext.Enrollments.Remove(enrollment);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<Enrollment> GetEnrollmentByStudentAndCourseAsync(int studentId, int courseId)
        {
            return await _studentDbContext.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }

    }
}
