namespace MongoDBGenericRepository.API.Models
{
    public class Person(string name, string email, string phone) : Entity
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;

        public void Update(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
