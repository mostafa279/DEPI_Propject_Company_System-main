using DEPI_Propject_Company_System.ViewModels;
using DEPI_Propject_Company_System.ViewModels.DependentVM;
using System.Globalization;

namespace DEPI_Propject_Company_System.Repositories.Interfaces
{
    public interface IDependentRepository
    {
        bool delete (int Employeeid, string name);
        Task<bool> update(CreateDependentVM model);
        void create(CreateDependentVM model);

          DisplayDependentVM getByIdAndName(int Employeeid, string name);
        List<DisplayDependentVM> GetAll();


    }
}
