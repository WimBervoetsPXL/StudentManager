using StudentManager.Domain;
using Xunit;

public class StudentTests
{
    [Fact]
    public void Constructor_ValidNames_CreatesStudent()
    {
        // Arrange
        string firstName = "Alice";
        string lastName = "Johnson";

        // Act
        Student student = new Student(firstName, lastName);

        // Assert
        Assert.Equal(firstName, student.FirstName);
        Assert.Equal(lastName, student.LastName);
    }

    [Fact]
    public void Constructor_EmptyFirstName_ThrowsArgumentException()
    {
        // Arrange
        string firstName = "";
        string lastName = "Johnson";

        // Act + Assert
        Assert.Throws<ArgumentException>(() =>
        {
            new Student(firstName, lastName);
        });
    }

    [Fact]
    public void Constructor_EmptyLastName_ThrowsArgumentException()
    {
        // Arrange
        string firstName = "Alice";
        string lastName = "";

        // Act + Assert
        Assert.Throws<ArgumentException>(() =>
        {
            new Student(firstName, lastName);
        });
    }

    [Fact]
    public void ToString_ValidStudent_ReturnsFullName()
    {
        // Arrange
        Student student = new Student("Alice", "Johnson");

        // Act
        string result = student.ToString();

        // Assert
        Assert.Equal("Alice Johnson", result);
    }
}