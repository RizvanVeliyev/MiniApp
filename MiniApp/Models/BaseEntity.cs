namespace MiniApp.Models
{
    public abstract class BaseEntity
    {
        private static int _id = 1;
        public int Id { get; private set; }

        protected BaseEntity()
        {
            Id = _id++;
        }
    }
}
