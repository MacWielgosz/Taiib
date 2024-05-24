namespace BLL
{
    public enum TypeEnum
    {
        Admin = 0, Casual = 1
    };

    public class UserDTO
    {
        public int ID { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public bool IsActive { get; init; }
        public TypeEnum Type { get; init; }
    }
}
