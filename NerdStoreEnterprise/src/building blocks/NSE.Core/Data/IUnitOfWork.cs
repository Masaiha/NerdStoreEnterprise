using System.Threading.Tasks;

namespace NSE.Core.DomainObjects
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
