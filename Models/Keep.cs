using System.ComponentModel.DataAnnotations;

namespace keepr.Models {
  public class Keep {
  
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Imgurl { get; set; }
    public string Articleurl { get; set; }
    public string Tags { get; set; }
    public int Ispublic { get; set; }
    public int Nbrviews { get; set; }
    public int Nbrkeeps { get; set; }
    public int UserId {get; set;}

    
  }
}