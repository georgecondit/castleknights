using System;
using System.Collections.Generic;
using castleknights1.Models;
using castleknights1.Repositories;

namespace castleknights1.Services
{
    public class CastleService
    {
        private readonly CastleRepository _repo;
        public CastleService(CastleRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> GetAll()
        {
            return _repo.GetAll();
        }
        
        internal Castle GetById(int id)
        {
            Castle data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Castle Create(Castle newProd)
        {
            return _repo.Create(newProd);
        }

        internal Castle Edit(Castle updated)
        {

            // REVIEW
            Castle data = GetById(updated.Id);

            //null check properties you are editing in repo
            data.Name = updated.Name != null ? updated.Name : data.Name;
            data.Description = updated.Description != null ? updated.Description : data.Description;
            data.Age = updated.Age != null ? updated.Age : data.Age;

            return _repo.Edit(data);
        }
        internal string Delete(int id)
        {
            Castle data = GetById(id);
            _repo.Delete(id);
            return "Castle Destroyed";
        }
    }
}
