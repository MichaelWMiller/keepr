using System.ComponentModel.DataAnnotations;
namespace keepr.Models{
public class Vaultkeeps {
  public int Id {get;set;}
  public int VaultId{get;set;}
  public int KeepId{get;set;}
  public int UserId{get;set;}
  
}

}