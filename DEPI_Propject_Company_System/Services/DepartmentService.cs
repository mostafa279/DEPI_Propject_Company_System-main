using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.Repositoories;
using DEPI_Propject_Company_System.ViewModels.DepartmentVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DEPI_Propject_Company_System.Services
{
    public class DepartmentService
    {
        private readonly CRUD<Department> _department;
        private readonly CRUD<Employee> _Manager;
        public DepartmentService(CRUD<Department> dep, CRUD<Employee> manager)
        {
            _department = dep;
            _Manager = manager;
        }
        public List<CreateDepartmentVM> GetAll()
        {    var VMList = new List<CreateDepartmentVM>();
            foreach (var vm in _department.GetAll())
            {
                var Model = new CreateDepartmentVM()
                {
                    Location = vm.Location,
                    Name = vm.Name,
                    ManagerId=vm.ManagerId,
                    Managers = _Manager.GetAll()
                   .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Name

                    })
                   .ToList()
                };
                VMList.Add(Model);
            }
            return VMList;
        }
        public List<DisplayDepartmentVM> DisplayDepartment()
        {
            var VMList = new List<DisplayDepartmentVM>();
            foreach (var vm in _department.GetAll())
            {
                var Model = new DisplayDepartmentVM()
                {
                    Location = vm.Location,
                    Name = vm.Name,
                    ManagerName = vm.Manager.Name,

                };
                VMList.Add(Model);
            }
            return VMList;
        }
        //public void Create(CreateDepartmentVM model)
        //{
        //    var model = new CreateDepartmentVM();
        //    model.Managers = _Manager.GetAll()
        //         .Select(m => new SelectListItem
        //         {
        //             Value = m.Id.ToString(),
        //             Text = m.Name

        //         })
        //         .ToList();
        //    return model;
        //}
        public CreateDepartmentVM update(int id, CreateDepartmentVM DepartmentFromReq)
        {    
            
            var model = _department.GetById(id);
            model.Location= DepartmentFromReq.Location;
            model.Name= DepartmentFromReq.Name;
            model.ManagerId= DepartmentFromReq.ManagerId;

            //model.Manager = _Manager.GetAll()
            //     .Select(m => new SelectListItem
            //     {
            //         Value = m.Id.ToString(),
            //         Text = m.Name
            //     })
            //     .ToList();
            return null;
        }
    }
}
