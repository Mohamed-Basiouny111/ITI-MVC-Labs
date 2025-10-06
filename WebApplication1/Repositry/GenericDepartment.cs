using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Context;
using WebApplication1.GenericRepo;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public class GenericDepartment : GenericRepository<Department>
    {
        public GenericDepartment(TantaMVCContext context) : base(context)
        {
           
        }
       
    }
}
