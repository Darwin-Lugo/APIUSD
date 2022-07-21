#region References
using System.Threading.Tasks;
using USD.Models;
using static USD.Models.Request; 
#endregion

namespace USD.Service
{
    public interface IServiceConsult
    {
        Task<Root> Get();
    }
}