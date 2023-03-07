using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projectEf.Models
{



public class Category
{
    //Agregar data Notation.
   // [Key]
    public Guid CategoryId {get;set;}

    //[Required]
    //[MaxLength(150)]
    public string? Name {get;set;}
    public string? Description {get;set;}

    [JsonIgnore]     
    public virtual ICollection<Work>? Works {get;set;}
    public int Weight {get;set;}

}




    
}