var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
var service = serviceProvider.GetService<IMyService>()!;

Console.WriteLine("*********************  insert  ***************");

var employee = new Employee()
{
  FirstName = "TestFirstName#1",
  LastName = "TestLastName#1",
  Department = "CEO",
  EntryYear = 2023,
};
service.InsertRecord(employee);

Console.WriteLine("*********************  update  *****************");
Console.ReadKey();


service.UpdateRecordLastName("Mustermann");
service.UpdateRecordFirstName("Max");
service.UpdateRecordEntryYear(2055);

Console.WriteLine("Check the version table, 3 new data records should have been added to the history table");
Console.WriteLine("First data record was added due to the change of the year of entry, " + Environment.NewLine +
                  "second data record was added due to the change of the surname" + Environment.NewLine +
                  "the last record added due to the change of the first name");
Console.WriteLine("press any key");
Console.ReadKey();


Console.WriteLine("*********************  delete  ****************");
service.DeleteEntry();
Console.WriteLine("Check the version table, a new data record should have been added to the history table");
Console.WriteLine("press any key");
Console.ReadKey();

Console.WriteLine("*********************  get history ************");

var historie = service.GetHistoryOfDataSet(1);

foreach (var pointInTime in historie)
{
  Console.WriteLine($"  Employee {pointInTime.Employee.Id}: {pointInTime.Employee.Fullname}, {pointInTime.Employee.EntryYear}, {pointInTime.Employee.Department} from {pointInTime.ValidFrom} to {pointInTime.ValidTo}");
}

Console.WriteLine("press any key");
Console.ReadKey();


Console.WriteLine("*********************  delete all records  ***************");
service.DeleteAllRecords();
Console.WriteLine("Check the version table, all data records from the table should now be in the history table.");
Console.WriteLine("press any key");
Console.ReadKey();
