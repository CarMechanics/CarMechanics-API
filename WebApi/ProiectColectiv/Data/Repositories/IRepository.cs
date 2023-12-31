﻿using ProiectColectiv.Data;

namespace ProiectColectiv.Data.Repositories;

public interface IRepository<T> where T : EntityBase
{
    T GetById(int id);
    IEnumerable<T> GetAll(string userName);
    void Add(CarPostDTO entity);
    void Update(T entity);
    void Delete(int id);
}