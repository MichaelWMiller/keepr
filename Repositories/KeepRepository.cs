using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories{

  public class KeepRepository {
    private readonly IDbConnection _db;
    public KeepRepository (IDbConnection db){
      _db = db;
    }

//ADD KEEP
    public Keep AddKeep (Keep keep) {
      var success = _db.Execute(@"
        INSERT INTO keeps (
          id, name, description, imgurl, 
          articleurl, tags, ispublic, nbrviews, nbrkeeps)
          VALUES (
            @Id, @Name, @Description, @Imgurl, @Articleurl, @Tags, @Ispublic, 
            @Nbrviews, @Nbrkeeps
          )
        )
      ", keep);
      return keep;
    }

//GET KEEP BY ITS ID
    public Keep GetById (int id) {
      return _db.QueryFirstOrDefault<Keep> (@"
      SELECT * FROM keeps where id = @Id", new{ Id = id});
    }

//GET ALL KEEPS FOR A VAULTID
    public IEnumerable<Keep> GetByVaultId (Vault vault, int id) {
      return _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @Id)
      ", new { Id = id});
    }
//DELETE KEEP BY KEEPID
    public string DeleteByKeepId (int id) {
      _db.Execute(@"
      DELETE FROM keeps WHERE id = @Id
      ", new {Id = id});
      return "Keep deleted successfully";
    }

//UPDATE A KEEP
    public Keep UpdateKeep (int id, Keep keep) {
      if (GetById(id) != null)
      {
        keep.id = id;
        _db.Execute(@"
        UPDATE keeps SET
        name = @Name,
        description = @Description, 
        imgurl = @Imgurl, 
        articleurl = @Articleurl, 
        tags = @Tags, 
        ispublic = @Ispublic, 
        nbrviews = @Nbrviews, 
        nbrkeeps = @Nbrkeeps
        ", new{Id = id});
        return keep;
      }
      else
      {
        return null;
      }
    }

    //TESTING ONLY - GET ALL KEEPS

    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep> (@"
      select * from keeps
      ");
    }


  }
}