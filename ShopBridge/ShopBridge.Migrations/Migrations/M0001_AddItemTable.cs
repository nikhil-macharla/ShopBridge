using FluentMigrator;
using ShopBridge.Data.Core.DbConstants;

namespace ShopBridge.Migrations.Migrations
{
    [Migration(1)]
    public class M0001_AddItemTable : Migration
    {
        public override void Down()
        {
            Delete.Table(TableConstants.Item);
        }

        public override void Up()
        {
            Create.Table(TableConstants.Item)
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("description").AsString(255).NotNullable()
                .WithColumn("price").AsDecimal().NotNullable()
                .WithColumn("category").AsByte()
                .WithColumn("model_number").AsString(20)
                .WithColumn("manufacturer").AsString(50);
        }
    }
}
