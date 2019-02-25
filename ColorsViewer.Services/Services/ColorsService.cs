using ColorsViewer.DataAccess.Contracts;
using ColorsViewer.DataAccess.DTO;
using ColorsViewer.Services.Contracts;
using System.Collections.Generic;

namespace ColorsViewer.Services.Services
{
    public class ColorsService : IColorsService
    {
        public ColorsService(IColorsRepository colorsRepository)
        {
            ColorsRepository = colorsRepository;
        }

        private IColorsRepository ColorsRepository { get; }

        public IEnumerable<ColorsDTO> GetColors(int number)
        {
            return ColorsRepository.GetColors(number);
        }
    }
}
