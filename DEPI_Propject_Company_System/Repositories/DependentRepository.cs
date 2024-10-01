using DEPI_Propject_Company_System.Data;
using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.Models.Enums;
using DEPI_Propject_Company_System.Repositories.Interfaces;
using DEPI_Propject_Company_System.ViewModels.DependentVM;
using Microsoft.EntityFrameworkCore;

namespace DEPI_Propject_Company_System.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private readonly ApplicationDbContext _Context;
        private readonly string _imagesPath;
        private readonly IWebHostEnvironment _webHostEnvironment;
 

        public DependentRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _Context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}/assets/images/Dependents";
        }
        public async  void create(CreateDependentVM model)
        {
            var imageName = await SaveImage(model.Image);
            var path=Path.Combine(_imagesPath, imageName);
            using var stream=File.Create(path);
            await model.Image.CopyToAsync(stream);
            var Dependent = new Dependent
            {
                Name = model.Name,
                EmployeeId = model.EmployeeId,
                Gender = (Gender)model.Gender,
                Image = imageName,
            };
            _Context.Add(Dependent);
            _Context.SaveChanges();
        }

        public bool delete(int Empid,string Name)
        {
            var Dependent=_Context.Dependents.FirstOrDefault(x => x.EmployeeId == Empid && x.Name==Name);
             if (Dependent is null) return false;
             _Context.Remove(Dependent);
            _Context.SaveChanges() ;
            return true;
        }

        public List<DisplayDependentVM> GetAll()
        {
            var modelFromDb = _Context.Dependents
                              .Include(d => d.Employee)
                              .AsNoTracking();
            var ListVm = new List<DisplayDependentVM>();
            foreach(var d in modelFromDb)
            {
                var vm = new DisplayDependentVM()
                {
                    Name = d.Name,
                    Gender = (Gender)d.Gender,
                    Image = d.Image,
                };
                ListVm.Add(vm);
            }
            return ListVm;
        }

        public DisplayDependentVM getByIdAndName(int Employeeid, string name)
        {
            var modelFromDb= _Context.Dependents
                             .Include(d=>d.Employee)
                             .AsNoTracking()
                             .FirstOrDefault(x=>x.EmployeeId==Employeeid && x.Name==name);
            var vm = new DisplayDependentVM()
            {
                Name = modelFromDb.Name,
                Gender = (Gender)modelFromDb.Gender,
                Image = modelFromDb.Image,
            };
            return vm;
        }

        public async Task<bool> update(CreateDependentVM model)
        {
            var modelFromDb=_Context.Dependents.Include(x=>x.Employee)
                                               .FirstOrDefault(x=>x.EmployeeId==model.EmployeeId && x.Name==model.Name);
            if(modelFromDb is null) return false;


            var imageName = await SaveImage(model.Image);
            var path = Path.Combine(_imagesPath, imageName);
            using var stream = File.Create(path);
            await model.Image.CopyToAsync(stream);
            modelFromDb.EmployeeId = model.EmployeeId;
            modelFromDb.Name = model.Name;
            modelFromDb.Gender=(Gender) model.Gender;
            modelFromDb.Image = imageName;


            await _Context.SaveChangesAsync();
            return true;
        }


        private async Task<string> SaveImage(IFormFile image)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            var path = Path.Combine(_imagesPath, coverName);

            using var stream = File.Create(path);
            await image.CopyToAsync(stream);

            return coverName;
        }
    }
}
