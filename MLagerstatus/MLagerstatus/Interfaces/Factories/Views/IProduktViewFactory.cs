using System.Threading.Tasks;
using MLagerstatus.Models.Views;

namespace MLagerstatus.Interfaces.Factories.Views
{
    public interface IProduktViewFactory
    {
        Task<ProduktIndexView> Build();
        Task<ProduktDetailView> Build(string artikel);
    }
}