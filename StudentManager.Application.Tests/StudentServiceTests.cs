using StudentManager.Application;
using StudentManager.Infrastructure;
using Xunit;

public class StudentServiceTests
{
    [Fact]
    public void AddStudent_ValidStudent_AddsStudent()
    {
        // Arrange
        StudentRepository repository = new StudentRepository();
        StudentService service = new StudentService(repository);

        // Act
        service.AddStudent("Alice", "Johnson");

        // Assert
        Assert.Single(service.GetAllStudents());
        Assert.Equal("Alice", service.GetAllStudents()[0].FirstName);
        Assert.Equal("Johnson", service.GetAllStudents()[0].LastName);
    }

    [Fact]
    public void AddStudent_DuplicateStudent_ThrowsInvalidOperationException()
    {
        // Arrange
        StudentRepository repository = new StudentRepository();
        StudentService service = new StudentService(repository);

        service.AddStudent("Alice", "Johnson");

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            service.AddStudent("alice", "johnson");
        });
    }

    [Fact]
    public void AddStudent_EmptyFirstName_ThrowsArgumentException()
    {
        // Arrange
        StudentRepository repository = new StudentRepository();
        StudentService service = new StudentService(repository);

        // Act + Assert
        Assert.Throws<ArgumentException>(() =>
        {
            service.AddStudent("", "Johnson");
        });
    }
}