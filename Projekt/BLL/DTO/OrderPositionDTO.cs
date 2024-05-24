namespace BLL
{
    public class OrderPositionDTO
    {
        public int ID { get; init; }
        public int OrderID { get; init; }
        public int ProductID { get; init; }
        public int Amount { get; init; }
        public double Price { get; init; }
    }
}
