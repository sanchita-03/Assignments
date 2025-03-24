using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<int> EnrollStudentAsync(int studentId, int courseId)
        {
            return await _enrollmentRepository.EnrollStudentAsync(studentId,courseId);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllEnrollmentsAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            var enrollment= await _enrollmentRepository.GetEnrollmentsByStudentIdAsync(studentId);
            if (!enrollment.Any())
            {
                throw new EnrollmentNotFoundException($"Enrollment with Id {studentId} was not found");
            }
            return enrollment;
        }

        public async Task<int> WithdrawStudentAsync(int studentId, int courseId)
        {
            return await _enrollmentRepository.WithdrawStudentAsync(studentId, courseId);
        }

        public async Task<Enrollment> GetEnrollmentByStudentAndCourseAsync(int studentId, int courseId)
        {
            return await _enrollmentRepository.GetEnrollmentByStudentAndCourseAsync(studentId, courseId);
        }
    }
}
