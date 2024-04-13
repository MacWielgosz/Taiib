

namespace BLL
{
    public interface IOrder
    {
        public void MakeOrder(int userID);
        public IEnumerable<OrderDTO> GetOrderAll();

        public IEnumerable<OrderDTO> GetOrderUser(int userID);

    }
}
