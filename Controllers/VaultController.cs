using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr {
  [Route ("api/[controller]")]
  public class VaultController: Controller {

    private readonly VaultRepository _repo;
    public VaultController (VaultRepository repo ) {
      _repo = repo;
    }

    //GET VAULT BY ITS ID
    [HttpGet ("{id}")]
    public Vault GetById (int id) {
      return _repo.GetById (id);
    }

    //GET ALL VAULTS FOR A USER
    [HttpGet ("{id}")]
    public IEnumerable<Vault> GetByUserId(User user, int id)
    {
      return _repo.GetByUserId (user);
    }
  //DELETE VAULT BY VAULT ID
    [HttpDelete]
    public string DeleteByVaultId (int id) {
      return _repo.DeleteByVaultId(id);
    }
  //UPDATE VAULT
  [HttpPut]
  public Vault UpdateVault (int id, Vault vault) {
    if (ModelState.IsValid) {
      return _repo.UpdateVault(id, vault);
    } else {
      return null;
    }
  }
  //ADD VAULT
  [HttpPost]
  public Vault AddVault (Vault vault) {
    if (ModelState.IsValid)
    {
      return _repo.AddVault (vault);
    } else {
      return null;
    }
  }
  //TESTING: GET ALL VAULTS
  [HttpGet]
  public IEnumerable<Vault> GetAllVaults() {
    return _repo.GetAllVaults();
  }



  }
}