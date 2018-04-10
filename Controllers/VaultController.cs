using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr {
  [Route ("api/[controller]")]
  public class VaultController : Controller {

    private readonly VaultRepository _repo;
    public VaultController (VaultRepository repo) {
      _repo = repo;
    }

    //GET VAULT BY ITS ID
    [HttpGet ("{id}")]
    public Vault GetById (int id) {
      return _repo.GetById (id);
    }

    //GET ALL VAULTS FOR A USER

    [HttpGet ("/api/vault/user/{id}")]
    public IEnumerable<Vault> GetByUserId (int id) {
      return _repo.GetByUserId (id);
    }

    //DELETE VAULT BY VAULT ID
    [HttpDelete]
    public string DeleteByVaultId (int id) {
      return _repo.DeleteByVaultId (id);
    }
    //UPDATE VAULT
    [HttpPut("/api/vault/{id}")]
    public Vault UpdateVault ([FromBody] Vault vault, int id) {
      if (ModelState.IsValid) {
        return _repo.UpdateVault (vault, id);
      } else {
        return null;
      }
    }
    //ADD VAULT -- ASSIGNS VAULT TO USERID
    [HttpPost]
    public Vault AddVault ([FromBody] Vault vault) {
      if (ModelState.IsValid) {
        return _repo.AddVault (vault);
      } else {
        return null;
      }
    }
    //ADD KEEP TO A VAULT (ADD RECORD TO VAULTKEEPS)
    //PASS in  KEEPID, VAULTID, USERID -- POST -- KeepKeep?? hahahaha
    [HttpPost("/api/vaultkeeps")]
    public Vaultkeeps AddVaultKeep ([FromBody] Vaultkeeps vaultkeep) {
     
      if (ModelState.IsValid) {
        return _repo.AddVaultKeep (vaultkeep);
      } else {
        return null;
      }
    }

    //TESTING: GET ALL VAULTS
    [HttpGet]
    public IEnumerable<Vault> GetAllVaults () {
      return _repo.GetAllVaults ();
    }

    //GET ALL VAULTKEEPS
    [HttpGet("/api/vaultkeeps")]
    public IEnumerable<Vaultkeeps> GetAllVaultKeeps () {
      return _repo.GetAllVaultKeeps();
    }

  }
}