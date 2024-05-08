namespace BLL
{
    public class OrderPositionRequestDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
