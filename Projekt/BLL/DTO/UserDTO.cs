namespace BLL
{
    public enum TypeEnum
    {
        Admin = 0, Casual = 1
    };

    public class UserDTO
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public TypeEnum Type { get; set; }
    }
}
