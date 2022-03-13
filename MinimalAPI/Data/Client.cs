namespace MinimalAPI.Data
{
    public class Client
    {

        public Client(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}