using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEf.Models
{


    public class Work
    {
        [Key]
        public Guid WorkId {get;set;}
        //[ForeignKey("<Str>")] Define una clave foránea y le da un nombre. Una clave foránea 
        //es un dato que se encuentra en otro documento, que es foráneo, que es “extranjero”.
        
        [ForeignKey("CategoriaId")]
        public Guid CategoryId{get;set;}
        //[Required] reemplazado por fluent API
        //[MaxLength(150)] DataNottations reemplazado por fluent API
        public string? Title {get;set;}
        public string? Description {get;set;}
        public Priority WorkPriority {get;set;}
        public DateTime CreationDate {get;set;}

        public virtual Category? Category {get;set;}
        //cuando se hace el mapeo del contexto hacia la BD, omita el campo de NotMapped
        //[NotMapped]
        public string? Summary {get;set;}



        public enum Priority
        {
            low,
            Medium,
            Low
        } 




    }

    
}