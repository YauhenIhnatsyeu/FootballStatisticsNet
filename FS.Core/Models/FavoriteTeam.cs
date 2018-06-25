namespace FS.Core.Models
{
    public class FavoriteTeam
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }

        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}