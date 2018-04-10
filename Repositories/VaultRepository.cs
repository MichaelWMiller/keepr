using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using MySql.Data.MySqlClient;

namespace keepr.Repositories {
  public class VaultRepository {

    private readonly IDbConnection _db;
    public VaultRepository (IDbConnection db) {
      _db = db;
    }

    //Create Vault
    public Vault AddVault (Vault vault) {
      int id = _db.ExecuteScalar<int>($@"
      INSERT INTO vaults
      ( name, description, userid)
        VALUES ( @Name, @Description, @UserId
      )
      ", vault);
      vault.Id = id;
      return vault;
    }
    public Vault GetById (int id) {
      return _db.QueryFirstOrDefault<Vault> (@"
      SELECT * FROM vaults where id = @Id", new { Id = id });
    }

    //Query by UserID

    public IEnumerable<Vault> GetByUserId (int id) {
      return _db.Query<Vault> (@"
        select * from vaults
        where userid = @userid
      ", new { userid = id});
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

    // ADD VAULTKEEP
    public Vaultkeeps AddVaultKeep (Vaultkeeps vaultkeep)
    {
      
      int id = _db.ExecuteScalar<int>($@"
      INSERT INTO vaultkeeps
      ( vaultid, keepid, userid)
        VALUES ( @VaultId, @KeepId, @UserId
      )
      ", vaultkeep);
      vaultkeep.Id = id;
      return vaultkeep;
    
    }

    //TESTING ONLY - GET ALL VAULTS

    public IEnumerable<Vault> GetAllVaults () {
      return _db.Query<Vault> (@"
      select * from vaults
      ");
    }

    //TESTING: GET ALL VAULTKEEPS
    public IEnumerable<Vaultkeeps> GetAllVaultKeeps() {
      return _db.Query<Vaultkeeps> (@"
      select * from vaultkeeps
      ");
    }

  }
}