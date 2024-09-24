using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using BackEnd_Students.Controllers;
using BackEnd_Students.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd_Students.Tests.Controllers
{
    public class StudentControllerTests
    {
        private DbContextOptions<AppDbContext> GetInMemoryDbContextOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task Get_ReturnsListOfStudents_WhenStudentsExist()
        {
            // Arrange
            var options = GetInMemoryDbContextOptions();
            using (var context = new AppDbContext(options))
            {
                // Insert some test data into the in-memory database
                context.Students.AddRange(new List<Student>
                {
                    new Student { Id = 1, Name = "Juan", Age = 20, Gender = "Masculine", CurrentCourse = "Systems", Email = "juan@gmail.com" },
                    new Student { Id = 2, Name = "Gabriela", Age = 22, Gender = "Female", CurrentCourse = "Arts", Email = "gabriela@gmail.com" }
                });
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new AppDbContext(options))
            {
                var controller = new StudentController(context);
                var result = await controller.Get();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var students = Assert.IsType<List<Student>>(okResult.Value);
                Assert.Equal(2, students.Count);
            }
        }
    }
}
