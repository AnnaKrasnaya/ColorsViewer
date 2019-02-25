using ColorsViewer.DataAccess.DTO;
using System.Collections.Generic;

namespace ColorsViewer.Services.Contracts
{
    public interface IColorsService
    {
        IEnumerable<ColorsDTO> GetColors(int number);        
    }
}
