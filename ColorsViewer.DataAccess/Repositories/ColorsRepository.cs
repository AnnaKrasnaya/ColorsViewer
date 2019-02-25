using ColorsViewer.DataAccess.Contracts;
using ColorsViewer.DataAccess.DTO;
using ColorsViewer.DataAccess.Ef;
using System.Linq;
using System.Collections.Generic;

namespace ColorsViewer.DataAccess.Repositories
{
    public class ColorsRepository : IColorsRepository
    {
        public ColorsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public IEnumerable<ColorsDTO> GetColors(int colorsNumber)
        {
            using (var context = new ApplicationContext(ConnectionString))
            {
                return context.Colors
                    .Join(context.Items,
                    color => color.Id,
                    item => item.ColorId,
                    (color, item) => new ColorsDTO { Id = item.Id, Name = item.Name, ColorCode = color.Code })
                    .Take(colorsNumber)
                    .ToList();
            }
        }
    }
}
