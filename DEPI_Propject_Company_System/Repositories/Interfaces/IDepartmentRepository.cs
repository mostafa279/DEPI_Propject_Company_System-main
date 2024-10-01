using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.ViewModels.DepartmentVM;

namespace DEPI_Propject_Company_System.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        public void Create(CreateDepartmentVM model);
        public bool update(int id, CreateDepartmentVM DepartmentFromReq);
        public List<DisplayDepartmentVM> GetAll();
        public DisplayDepartmentVM GetById(int id);
        public bool Delete(int id);
    }
}
