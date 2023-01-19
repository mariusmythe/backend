using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class DbArticle
    {
        [Key]
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageURL { get; set; }

        public DateTime Published { get; set; }
    }
}
