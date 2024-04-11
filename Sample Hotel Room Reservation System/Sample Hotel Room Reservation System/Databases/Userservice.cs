
using MongoDB.Driver;
using Sample_Hotel_Room_Reservation_System.Models;

public class Userservice{



        List<User> sampleUsers = new List<User>
    {
        new User
        {
            UserId = 1,
            UserName = "john_doe",
            Email = "john@example.com",
            PasswordHash = "hashedpassword1",
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = 1234567890,
            PhysicalAddress = "123 Main St, City, Country"
        },
        new User
        {
            UserId = 2,
            UserName = "jane_smith",
            Email = "jane@example.com",
            PasswordHash = "hashedpassword2",
            FirstName = "Jane",
            LastName = "Smith",
            PhoneNumber = 987654310,
            PhysicalAddress = "456 Elm St, City, Country"
        },
        new User
        {
            UserId = 3,
            UserName = "mike_jones",
            Email = "mike@example.com",
            PasswordHash = "hashedpassword3",
            FirstName = "Mike",
            LastName = "Jones",
            PhoneNumber = 55514567,
            PhysicalAddress = "789 Oak St, City, Country"
        }
    };



        private readonly string database="userTest";

        private readonly string collectionname="userManager";

        public IMongoCollection<T> mongoCollection<T>(in string collection)
        {
            var connect = new MongoClient("");
            var db = connect.GetDatabase(database);
            return db.GetCollection<T>(collection);

        }


        public string addUser(User user){

            var collect = mongoCollection<User>(collectionname);

            collect.InsertOne(user);

            return "success";

        }

        public string login(string username, string password){


          var response = sampleUsers.Where(x=>x.UserName == username && x.PasswordHash == password).FirstOrDefault();

          if(response != null){

              return "success";
          }

          return "unsuccessful";

        }


}