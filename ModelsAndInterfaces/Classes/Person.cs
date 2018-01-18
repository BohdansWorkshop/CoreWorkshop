using ModelsAndInterfaces.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModelsAndInterfaces.Classes
{
    public class Person
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}