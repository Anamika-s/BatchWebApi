namespace BatchWebApi.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Seats { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }  // is used for soft delete
    }
}

