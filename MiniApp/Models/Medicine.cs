namespace MiniApp.Models
{
    public class Medicine : BaseEntity
    {
        private static int id = 1;
        public int ID { get; private set; }


        public Medicine()
        {
            ID = id++;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
