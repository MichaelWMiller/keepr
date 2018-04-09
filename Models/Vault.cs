using System.ComponentModel.DataAnnotations;
namespace keepr.Models
{
  public class Vault
  {
    public int Id {get; set;}
     [Required]
     public string Name {get; set;}
     public string Description {get; set;}
     public Vault(string name, string description)
     {
       Name = name;
       Description = description;
     }
  }
}