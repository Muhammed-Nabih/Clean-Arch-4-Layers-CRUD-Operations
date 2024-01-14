﻿using CleanArch_CRUD.Domain.Interfaces;
using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly List<T> _entities = new List<T>();

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}