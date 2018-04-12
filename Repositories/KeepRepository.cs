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

//ADD KEEP - works
    public Keep AddKeep (Keep keep) {
     int id = _db.Execute(@"
        INSERT INTO keeps (
          id, name, description, imgurl, 
          articleurl, tags, ispublic, nbrviews, nbrkeeps, userid)
          VALUES (
            @Id, @Name, @Description, @Imgurl, @Articleurl, @Tags, @Ispublic, 
            @Nbrviews, @Nbrkeeps, UserId
          )
        
      ", keep);
      keep.Id = id;
      return keep;
    }

//GET KEEP BY ITS ID
    public Keep GetById (int id) {
      return _db.QueryFirstOrDefault<Keep> (@"
      SELECT * FROM keeps where id = @Id", new{ Id = id});
    }

//GET ALL KEEPS FOR A VAULTID - works
    public IEnumerable<KeepsByVaultId> GetByVaultId (int vaultId) {
      return _db.Query<KeepsByVaultId>(@"
      SELECT vk.vaultid,
            vk.keepid,
            k.name,
            k.description,
            k.imgurl,
            k.articleurl,
            k.tags,
            k.IsPublic,
            k.nbrviews,
            k.nbrkeeps
       
            FROM vaultkeeps vk
              INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @Id)
      ", new { Id = vaultId});
    }
//DELETE KEEP BY KEEPID
    public string DeleteByKeepId (int id) {
      _db.Execute(@"
      DELETE FROM keeps WHERE id = @Id
      ", new {Id = id});
      return "Keep deleted successfully";
    }

//UPDATE A KEEP - works
    public Keep UpdateKeep (Keep keep, int id) {
        
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
        where id = @id
        ", id);
        return keep;
    }

    //TESTING ONLY - GET ALL KEEPS

    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep> (@"
      select * from keeps
      ");
    }

    public IEnumerable<Keep> GetPublicKeeps(){
       return _db.Query<Keep>(@"
    select * from keeps where ispublic = 1");
    }

  }
}