using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class DeptWithStudWithInstVM
    {
        public List<Department> department { get; set; } = new List<Department>();

        public int StdCount { get; set; }
        public int InsCount { get; set; }
       

    }
}
