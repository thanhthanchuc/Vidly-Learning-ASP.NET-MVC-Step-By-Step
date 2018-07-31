namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToCustomerForTest : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Customers ON");
            Sql("INSERT INTO Customers (Id, Name, IsSuprierToNewLetter, MembershipTypeId) VALUES (1, 'Will Smith', 0, 1)");
            Sql("INSERT INTO Customers (Id, Name, IsSuprierToNewLetter, MembershipTypeId) VALUES (2, 'Mary William', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
