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

    //GET KEEP BY ITS ID - works
    [HttpGet ("/api/keep/{id}")]
    public Keep GetById (int id) {
      return _repo.GetById (id);
    }

    //GET ALL KEEPS FOR A VAULTID - works
    [HttpGet ("/api/keepbyvault/{vaultId}")]
    public IEnumerable<KeepsByVaultId> GetByVaultId (int vaultId) {
      if (ModelState.IsValid) {
        return _repo.GetByVaultId (vaultId);
      }
      return null;
    }

    // Delete by keep ID - works
    [HttpDelete("/api/keep/{id}")]
    public string DeleteByKeeperId (int id) {
      return _repo.DeleteByKeepId (id);
    }

    //Update a Keep  - works
    [HttpPut("/api/keep/{id}")]
    public Keep UpdateKeep ([FromBody] Keep keep, int id) {
      if (ModelState.IsValid) {
        return _repo.UpdateKeep (keep, id);
      } else {
        return null;
      }
    }
    //CREATE KEEP - works
    [HttpPost]
    public Keep AddKeep ([FromBody] Keep keep) {
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

    //GetPublicKeeps
    [HttpGet("/api/public/keep")]
    public IEnumerable<Keep> GetPublicKeeps() {
      return _repo.GetPublicKeeps();
    }

  }
}