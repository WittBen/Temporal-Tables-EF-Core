using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Models;

public class Employee 
{
  public int Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

  public string Fullname => $"{FirstName} {LastName}";

  public string Department { get; set; } = string.Empty;
  public int EntryYear { get; set; }

}

public class DataTypeConiguration : IEntityTypeConfiguration<Employee>
{
  public void Configure(EntityTypeBuilder<Employee> builder)
  {
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Id).ValueGeneratedOnAdd();
   
    //set temporal table
    builder.ToTable(nameof(Employee), employee => employee.IsTemporal());
  }
}

public struct EmployeeHistory
{
  public Employee Employee { get; set; }
  public DateTime ValidFrom { get; set; }
  public DateTime ValidTo { get; set; }
}
