using Console.VVG.Database;
using Model.VVG.model;

var dbcontext = new WarehouseDbContext();

Company cmp = new Company
{
    Id = 4,
    CompanyName = "Company 4",
    Address = "Address 4",
    Contact = "Contact 4"
};
dbcontext.Company.Add(cmp);

Company company = dbcontext.Company.Find(4);
System.Console.WriteLine(company.Id);
System.Console.WriteLine(company.Address);