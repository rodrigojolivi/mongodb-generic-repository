namespace MongoDBGenericRepository.API.Requests
{
    public class CreatePersonRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
