using CleanArch_CRUD.Domain.Interfaces;
using CleanArch_CRUD.Domain.Interfaces.ICategoryRepo;
using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Infrastructure.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CleanArch_CRUD.Infrastructure.Repositories.CategoryRepo
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {


        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}
