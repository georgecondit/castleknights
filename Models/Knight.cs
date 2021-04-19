namespace castleknights1.Models
{
    public class Knight
    {
        public Knight()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int CastleId { get; set; }
        //only for populate
        public Castle Castle { get; set; }
    }
}
