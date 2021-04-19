using System;
using System.Collections.Generic;
using castleknights1.Models;
using castleknights1.Repositories;

namespace castleknights1.Services
{
    public class KnightService
    {
        private readonly KnightRepository _repo;

        public KnightService(KnightRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Knight> GetAll()
        {
            return _repo.GetAll();
        }

        internal Knight GetById(int id)
        {
            Knight data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Knight Create(Knight newProd)
        {
            return _repo.Create(newProd);
        }

        internal Knight Edit(Knight updated)
        {

            // REVIEW
            Knight data = GetById(updated.Id);

            //null check properties you are editing in repo
            data.Name = updated.Name != null ? updated.Name : data.Name;
            data.Description = updated.Description != null ? updated.Description : data.Description;
            data.Color = updated.Color != null ? updated.Color : data.Color;


            return _repo.Edit(data);
        }
        internal string Delete(int id)
        {
            Knight data = GetById(id);
            _repo.Delete(id);
            return "Knight is Deceased";
        }

        internal IEnumerable<Knight> GetByCastleId(int id)
        {
            return _repo.GetByCastleId(id);
        }
    }
}