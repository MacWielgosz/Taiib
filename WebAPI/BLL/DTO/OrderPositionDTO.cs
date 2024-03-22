namespace BLL.DTO
{
    internal class OrderPositionDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
