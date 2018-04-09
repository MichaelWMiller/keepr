using System.ComponentModel.DataAnnotations;

namespace keepr.Models {
  public class Keep {
  
    public int id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Imgurl { get; set; }
    public string Articleurl { get; set; }
    public string Tags { get; set; }
    public int Ispublic { get; set; }
    public int Nbrviews { get; set; }
    public int Nbrkeeps { get; set; }

  public Keep (int id, string name, string description, 
  string imgurl, string articleurl, string tags, 
  int ispublic, int nbrviews, int nbrkeeps) {
      this.id = id;
      this.Name = name;
      this.Description = description;
      this.Imgurl = imgurl;
      this.Articleurl = articleurl;
      this.Tags = tags;
      this.Ispublic = ispublic;
      this.Nbrviews = nbrviews;
      this.Nbrkeeps = nbrkeeps;

    }
  }
}