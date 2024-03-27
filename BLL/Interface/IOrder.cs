

namespace BLL
{
    public interface IOrder
    {
        public void MakeOrder(UserDTO user);
        public IEnumerable<OrderDTO> GetOrderAll();

        public IEnumerable<OrderDTO> GetOrderUser(int idUser);

    }
}
