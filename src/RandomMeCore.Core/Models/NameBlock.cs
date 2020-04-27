namespace RandomMeCore.Core.Models
{
    public abstract class NameBlock
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public NameBlockType BlockType { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
