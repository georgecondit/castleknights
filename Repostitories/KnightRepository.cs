using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using castleknights1.Models;

namespace castleknights1.Repositories
{
    public class KnightRepository
    {
        private readonly IDbConnection _db;

        public KnightRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Knight> GetAll()
        {
            string sql = "SELECT * FROM knight;";
            return _db.Query<Knight>(sql);
        }

        internal Knight GetById(int Id)
        { 
            string sql = "SELECT * FROM knight WHERE id = @id;"; 
            return _db.QueryFirstOrDefault<Knight>(sql, new { Id });
            // NOTE Add JOIN statement here^

    //         string sql = @"
    //   SELECT 
    //   k.*,
    //   c.*
    //   FROM knight k
    //   JOIN castle c ON k.castleId = c.id
    //   WHERE k.Id = @Id;";
    //         return _db.Query<Knight, Castle, Knight>(sql, (knight, castle) =>
    //             {
    //                 knight.Castle = castle;
    //                 return knight;
    //             }, splitOn: "id").FirstOrDefault();
        }
        internal Knight Create(Knight newKnight)
        {
            string sql = @"
      INSERT INTO knight
      (name, description, color, castleId)
      VALUES
      (@Name, @Description, @Color, @CastleId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKnight);
            newKnight.Id = id;
            return newKnight;
        }

        internal Knight Edit(Knight data)
        {
            string sql = @"
      UPDATE knight
      SET
        name = @Name,
        description = @Description,
        color = @Color
      WHERE id = @Id;
      SELECT * FROM knight WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Knight>(sql, data);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM knight WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Knight> GetByCastleId(int id)
        {
            // string sql = "SELECT * FROM knight WHERE castleId = @id;";

            // return _db.Query<Knight>(sql, new { id });


            string sql = @"
      SELECT 
      k.*,
      c.*
      FROM knight k
      JOIN castle c ON k.castleId = c.id
      WHERE castleId = @id;";

            return _db.Query<Knight, Castle, Knight>(sql, (knight, castle) =>
            {
                knight.Castle = castle;
                return knight;
            }, new { id }, splitOn: "id");

        }
    }
}