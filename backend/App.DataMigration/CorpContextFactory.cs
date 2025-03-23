/* ---------------------------------------------------
 * Миграции БД corpdb, схема ent, контекст CorpContext
 * ---------------------------------------------------
 * Package Manager Console:
 *
 * Создать новую миграцию по измененному контексту:
 *   PM> EntityFrameworkCore\Add-Migration "НазваниеМиграции" -OutputDir History -Project App.DataMigration -StartupProject App.DataMigration
 *
 * Сгенерировать sql-скрипт для БД:
 *   PM> EntityFrameworkCore\Script-Migration -From "НазваниеПредМиграции" -Project App.DataMigration -StartupProject App.DataMigration
 *
 * Применить изменения в БД:
 *   PM> EntityFrameworkCore\Update-Database -Project App.DataMigration -StartupProject App.DataMigration
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using App.Entities;


namespace App.DataMigration
{
    internal class CorpContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        static CorpContextFactory() =>
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            const string connectionString =
                "Host=localhost;Port=5433;Database=appdb;Persist Security Info=True;User ID=postgres;Password=postgres";

            optionsBuilder
                .UseNpgsql(
                    connectionString,
                    options => options
                        .CommandTimeout(1000)
                        .MigrationsAssembly("App.DataMigration")
                        .MigrationsHistoryTable("EntMigrations", "public"));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}