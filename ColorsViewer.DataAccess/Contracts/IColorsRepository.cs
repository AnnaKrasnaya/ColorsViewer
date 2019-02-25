using ColorsViewer.DataAccess.DTO;
using System.Collections.Generic;

namespace ColorsViewer.DataAccess.Contracts
{
    public interface IColorsRepository
    {
        IEnumerable<ColorsDTO> GetColors(int colorsNumber);
    }
}
