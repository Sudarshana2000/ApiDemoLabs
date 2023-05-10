using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAppDemo.Models
{
    [Table(name: "Categories")]
    public class Category
    {
        [Key]                                                       // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       // Identity Column
        public int CategoryId { get; set; }

        [Required]                                                  // NOT EMPTY
        [MaxLength(50, ErrorMessage = "Category Name cannot have more than {1} characters.")]
        public string CategoryName { get; set; } = string.Empty;   // NOT NULL
    }


    /********************
    
        CREATE TABLE [Categories]
        (
            [CategoryId] int NOT NULL IDENTITY (1, 1)
            , [CategoryName] nvarchar(50) NOT NULL

            , CONSTRAINT [PK_Categories] PRIMARY KEY ( [CategoryId] ASC )
        )
    
     ******/

}
