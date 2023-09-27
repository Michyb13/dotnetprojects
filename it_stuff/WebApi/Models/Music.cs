using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Music
    {
        public int Id {get; set;}
        public string name {get; set;}
        public string artist {get; set;}
        public string genre{get; set;}
    }
}