namespace MiniApp.Models
{
    public class Category : BaseEntity
    {
        private static int id=1;
        public int ID { get; private set; }

        public string Name { get; set; }

        public Category()
        {
            ID = id++;
        }

    }
}
