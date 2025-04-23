namespace CarShare.DTO
{
    public class CarPostResponseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CarType { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public DateTime AvailStart { get; set; }
        public DateTime AvailEnd { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int ProposalCount { get; set; }
    }
}
