using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr {
  [Route ("api/[controller]")]
  public class KeepController : Controller {

    private readonly KeepRepository _repo;
    public KeepController (KeepRepository repo) {
      _repo = repo;
    }

    //GET KEEP BY ITS ID
    [HttpGet ("{id}")]
    public Keep GetById (int id) {
      return _repo.GetById (id);
    }

    //GET ALL KEEPS FOR A VAULTID
    [HttpGet ("{id}")]
    public IEnumerable<Keep> GetByVaultId (Vault vault, int id) {
      return _repo.GetByVaultId (vault, id);
    }

    // Delete by keep ID
    [HttpDelete]
    public string DeleteByKeeperId (int id) {
      return _repo.DeleteByKeepId (id);
    }

    //Update a Keep
    [HttpPut]
    public Keep UpdateKeep (int id, Keep keep) {
      if (ModelState.IsValid) {
        return _repo.UpdateKeep (id, keep);
      } else {
        return null;
      }
    }
//ADD KEEP
    [HttpPost]
    public Keep AddKeep (Keep keep) {
      if (ModelState.IsValid) {
        return _repo.AddKeep (keep);
      } else {
        return null;
      }
    }

    // GET ALL KEEPS
    [HttpGet]
    public IEnumerable<Keep> GetAllKeeps () {
      return _repo.GetAllKeeps ();
    }

  }
}