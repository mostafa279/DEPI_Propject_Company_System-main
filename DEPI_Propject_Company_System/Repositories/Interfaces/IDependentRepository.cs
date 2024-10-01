using DEPI_Propject_Company_System.ViewModels;
using DEPI_Propject_Company_System.ViewModels.DependentVM;

namespace DEPI_Propject_Company_System.Repositories.Interfaces
{
    public interface IDependentRepository
    {
        bool delete (int id);
        bool update(int id,CreateDependentVM model);
        void create(CreateDependentVM model);

    }
}
