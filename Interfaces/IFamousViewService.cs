using System.Collections.Generic;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace statistique.Interfaces
{
    public interface IFamousViewService
    {
        public string SaveFamous(FamousView famous);
        public List<FamousView> GetAllFamous();    }
}
