using DEPI_Propject_Company_System.Data;
using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.Models.Enums;
using DEPI_Propject_Company_System.Repositories.Interfaces;
using DEPI_Propject_Company_System.ViewModels.DependentVM;

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
        public async void create(CreateDependentVM model)
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

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(int id, CreateDependentVM model)
        {
            throw new NotImplementedException();
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
