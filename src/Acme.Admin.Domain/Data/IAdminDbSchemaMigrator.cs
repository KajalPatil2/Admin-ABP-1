using System.Threading.Tasks;

namespace Acme.Admin.Data;

public interface IAdminDbSchemaMigrator
{
    Task MigrateAsync();
}
