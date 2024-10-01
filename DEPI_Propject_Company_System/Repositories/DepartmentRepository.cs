using DEPI_Propject_Company_System.Data;
using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.Repositoories.Interfaces;
using DEPI_Propject_Company_System.Repositories.Interfaces;
using DEPI_Propject_Company_System.ViewModels.DepartmentVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DEPI_Propject_Company_System.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {    
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(CreateDepartmentVM model)
        {
            var Department = new Department()
            {
                Location = model.Location,
                ManagerId = model.ManagerId,
                Name = model.Name,
            };
            _context.Add(Department);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var modelFromDb = _context.Departments.FirstOrDefault(m => m.Id == id);
            if (modelFromDb is null)
                return false;

            _context.Departments.Remove(modelFromDb);
            _context.SaveChanges();
            return true;
        }

        public List<DisplayDepartmentVM> GetAll()
        {   
            var Departments=_context.Departments
                            .Include(d => d.Manager)
                            .AsNoTracking()
                            .ToList();
            var VMList = new List<DisplayDepartmentVM>();
            foreach (var vm in _context.Departments)
            {
                var Model = new DisplayDepartmentVM()
                {
                    Location = vm.Location,
                    Name = vm.Name,
                    ManagerName = vm.Manager.Name
                };
                VMList.Add(Model);
            }
            return VMList;
        }

        public DisplayDepartmentVM GetById(int id)
        {
            var DeptFromDb = _context.Departments
                           .Include(x => x.Manager)
                           .AsNoTracking()
                           .FirstOrDefault(x => x.Id == id);
            if (DeptFromDb is null)
                return null;

            var VM = new DisplayDepartmentVM()
            {
                Location = DeptFromDb.Location,
                Name = DeptFromDb.Name,
                ManagerName= DeptFromDb.Manager.Name
            };
            return VM; 
        }

        public bool update(int id, CreateDepartmentVM DepartmentFromReq)
        {
            var DeptFromDb = _context.Departments
                          .Include(x => x.Manager)
                          .FirstOrDefault(x => x.Id == id);
            if (DeptFromDb is null)
            return false;
            DeptFromDb.Name = DepartmentFromReq.Name;
            DeptFromDb.Location = DepartmentFromReq.Location;
            DeptFromDb.ManagerId = DepartmentFromReq.ManagerId;
            DeptFromDb.Employees = DepartmentFromReq.SelectedManagers.Select((d => new Employee { Id = d })).ToList();
            _context.SaveChanges();
            return true;
        }
        public IEnumerable<SelectListItem> GetSelectList()
          => _context.Employees.Select(x => new SelectListItem { Value= x.Id.ToString(),Text=x.Name });   

        
    }
}
