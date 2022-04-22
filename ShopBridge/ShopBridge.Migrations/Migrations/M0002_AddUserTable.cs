using FluentMigrator;
using ShopBridge.Data.Core.DbConstants;

namespace ShopBridge.Migrations.Migrations
{
    [Migration(2)]
    public class M0002_AddUserTable : Migration
    {
        public override void Down()
        {
            Delete.Table(TableConstants.User);
        }

        public override void Up()
        {
            Create.Table(TableConstants.User)
                .WithColumn("id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("username").AsString(20).NotNullable()
                .WithColumn("password").AsString(25).NotNullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("given_name").AsString(20)
                .WithColumn("surname").AsString(20)
                .WithColumn("role").AsByte();

            string sql = $"INSERT INTO {TableConstants.User} (username, password, email, given_name, surname, role) VALUES " +
                "('nikhil', 'mYpassW0rd', 'nikhil.macharla@email.com', 'Nikhil', 'Macharla', 0)";

            Execute.Sql(sql);
        }
    }
}
