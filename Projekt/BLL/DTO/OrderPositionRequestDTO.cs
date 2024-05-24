namespace BLL
{
    public class OrderPositionRequestDTO
    {
        public int OrderID { get; init; }
        public int ProductID { get; init; }
        public int Amount { get; init; }
        public double Price { get; init; }
    }
}
