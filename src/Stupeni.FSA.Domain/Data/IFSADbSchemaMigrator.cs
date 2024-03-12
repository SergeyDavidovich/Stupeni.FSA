using System.Threading.Tasks;

namespace Stupeni.FSA.Data;

public interface IFSADbSchemaMigrator
{
    Task MigrateAsync();
}
