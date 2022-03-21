using System.Threading.Tasks;

namespace Olimp.Business.Interfaces
{
    public interface ISeedDatabaseService
    {
        public void CreateStartOrderStatus();
        public Task CreateStartRole();
        public Task CreateStartAdmin();
    }
}