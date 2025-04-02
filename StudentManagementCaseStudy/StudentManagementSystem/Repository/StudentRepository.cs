using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        readonly StudentDbContext _studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            _studentDbContext.Students.Add(student);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            Student student =await GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Book with Id{id} not found");
            }
            _studentDbContext.Students.Remove(student);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentDbContext.Students.FindAsync(id);
        }

        public Task<int> UpdateStudentAsync(Student student)
        {
            _studentDbContext.Students.Update(student);
            return _studentDbContext.SaveChangesAsync();
        }
    }
}
