using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer
{
    public interface IFilmService
    {
        Task CreateFilmAsync(FilmViewModel filmViewModel, string userId);
        Task EditFilmAsync(FilmViewModel filmViewModel);
        Task<List<ShowFilmsViewModel>> ShowFilmViewmodelsAsync();
        Task<List<ShowFilmsViewModel>> ShowMyFilmViewmodelsAsync(string userId);
        Task DeleteFilmAsync(int id);
        Task<ShowFilmsViewModel> GetVMFromIDAsync(int id);
    }
}
