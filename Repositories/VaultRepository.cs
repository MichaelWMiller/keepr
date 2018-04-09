using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories {
  public class VaultRepository {

    private readonly IDbConnection _db;
    public VaultRepository (IDbConnection db) {
      _db = db;
    }

    //Create Vault
    public Vault AddVault (Vault vault) {
      var success = _db.Execute (@"
      INSERT INTO vaults (
        id, 
        name, 
        description
        )
        VALUES(
          @Id,
          @Name,
          @Description
        )
        ", vault);
      return vault;
    }

    public Vault GetById (int id) {
      return _db.QueryFirstOrDefault<Vault> (@"
      SELECT * FROM vaults where id = @Id", new { Id = id });
    }

    //Query by UserID

    public IEnumerable<Vault> GetByUserId (User user) {
      int id = user.Id;
      return _db.Query<Vault> (@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN vaults v ON v.id = vk.keepId 
        WHERE (userid = @Id)
      ", new {
        Id = id
      });
    }

    //Delete vault by Id
    public string DeleteByVaultId (int id) {
      _db.Execute (@"
      DELETE FROM vaults WHERE id = @Id
      ", new { Id = id });
      return "Vault deleted successfully.";
    }

    //Update Vault
    public Vault UpdateVault (int id, Vault vault) {
      if (GetById (id) != null) {
        vault.Id = id;
        _db.Execute (@"
        UPDATE vaults SET name = @Name,
        description = @Description
        WHERE id = @id", new { Id = id });
        return vault;
      } else {
        return null;
      }
    }

    //TESTING ONLY - GET ALL VAULTS

    public IEnumerable<Vault> GetAllVaults () {
      return _db.Query<Vault> (@"
      select * from vaults
      ");
    }

  }
}