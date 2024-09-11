namespace ConsoleApp1.Services;

public interface IMyService
{
  void InsertRecord(Employee employee);
  void UpdateRecordEntryYear(int entryYear);
  void UpdateRecordLastName(string lastName);
  void UpdateRecordFirstName(string firstName);


  void DeleteEntry();
  void DeleteAllRecords();

  List<EmployeeHistory> GetHistoryOfDataSet(int id);
}