using System.ComponentModel.DataAnnotations.Schema;

namespace BollywoodHubAPI.Models.Entities
{
    public class Favorites
    {
        public Guid Id { get; set; }
        public required int user_id { get; set; }
        public required int movie_id { get; set; }
        public virtual Users? User { get; set; }
        public virtual Movies? Movies { get; set; }
    }
}
