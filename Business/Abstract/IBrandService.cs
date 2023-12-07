﻿using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        Brand GetById(int id);
    }
}
