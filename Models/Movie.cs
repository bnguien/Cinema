using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyMVCApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public string ? Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}