using System.Threading.Tasks;

namespace Viticulture.Services
{
    public interface IPlayerSelection
    {
        Task<Selection> Select(string title, string message, string option1, string option2);
    }
}