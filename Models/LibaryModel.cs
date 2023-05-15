using System;

namespace Libary.Models
{
    public class LibaryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
