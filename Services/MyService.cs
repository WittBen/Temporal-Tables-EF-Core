namespace ConsoleApp1.Services;

public class MyService : IMyService
{
  private readonly DBContext _context;

  public MyService()
  {
    if (_context == null)
      _context = Create.Context();
  }




  #region function
  public void DeleteAllRecords()
  {
    
    foreach (var e in _context.Employee)
    {

      _context.Update(e);

      _context.Remove(e);
    }

    _context.SaveChanges();
  }

  public void DeleteEntry()
  {
    _context.Database.BeginTransaction();

    try
    {
      var e = _context.Employee.First(x => x.LastName == "Mustermann");


      _context.Update(e);

      _context.Remove(e);
      _context.SaveChanges();
      _context.Database.CommitTransaction();
    }
    catch
    {
      _context.Database.RollbackTransaction();
    }

  }

  #region update
  string _lastName = string.Empty;
  public void UpdateRecordLastName(string lastName)
  {
    System.Threading.Thread.Sleep(1000);
    _context.Database.BeginTransaction();

    try
    {
      var dto = _context.Employee.First(x => x.LastName == _lastName);

      if (dto != null)
      {
        dto.LastName = lastName;
        _context.Update(dto);
        _context.SaveChanges();
        _context.Database.CommitTransaction();

        _lastName = lastName;
      }
    }
    catch
    {
      _context.Database.RollbackTransaction();
    }
  }
  public void UpdateRecordEntryYear(int entryYear)
  {
    System.Threading.Thread.Sleep(1000);

    _context.Database.BeginTransaction();

    try
    {
      var dto = _context.Employee.First(x => x.LastName == _lastName);

      if (dto != null)
      {

        dto.EntryYear = entryYear;
        _context.Update(dto);
        _context.SaveChanges();

        _context.Database.CommitTransaction();
      }
    }
    catch
    {
      _context.Database.RollbackTransaction();
    }
  }
  public void UpdateRecordFirstName(string firstName)
  {

    System.Threading.Thread.Sleep(1000);

    _context.Database.BeginTransaction();

    try
    {
      var dto = _context.Employee.First(x => x.LastName == _lastName);

      if (dto != null)
      {
        dto.FirstName = firstName;
        _context.Update(dto);
        _context.SaveChanges();


        _context.Database.CommitTransaction();
      }
    }
    catch
    {
      _context.Database.RollbackTransaction();
    }
  }
  #endregion

  public void InsertRecord(Employee employee)
  {
    _lastName = employee.LastName;
    _context.Database.BeginTransaction();

    try
    {
      if (employee != null)
      {
        _context.Update(employee);
        _context.SaveChanges();
        _context.Database.CommitTransaction();
      }
    }
    catch
    {
      _context.Database.RollbackTransaction();
    }
  }

  public List<EmployeeHistory> GetHistoryOfDataSet(int id)
  {
    return _context
        .Employee
        .TemporalAll()
        .Where(c => c.Id == id)
        .OrderByDescending(c => EF.Property<DateTime>(c, "PeriodStart"))
        .Select(
            c => new EmployeeHistory
            {
              Employee = c,
              ValidFrom = EF.Property<DateTime>(c, "PeriodStart"),
              ValidTo = EF.Property<DateTime>(c, "PeriodEnd")
            })
        .ToList();
  }
  #endregion

}

