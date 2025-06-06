using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class UnityOfMeasureService(IUnityOfMeasureRepository unityOfMeasureRepository)
    {
        private readonly IUnityOfMeasureRepository _unityOfMeasureRepository = unityOfMeasureRepository;

        public async Task<List<UnityOfMeasureDto>> ListUnitiesOfMeasure()
        {
            var response = await _unityOfMeasureRepository.ListUnitiesOfMeasure();

            return response;
        }
    }
}
