using System;
using System.Threading.Tasks;
namespace myApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
           await runClient();
        }
        static async Task runClient(){
            Client client = new Client();
                Comment comment = new Comment(); 
                comment = await client.GetById("1");
                Console.WriteLine(comment.name.ToString());
                //client.postComment(new Comment() {name = "asdgfs", email = "test@test.com", body ="dgadfgshfgnsvrgsbfdd"}).Wait();
                //client.updateComment("1", new Comment() {name = "asdgfs", email = "test@test.com", body ="dgadfgshfgnsvrgsbfdd"}).Wait();
                //client.GetAll().Wait();

            
        }
        
    }

}
   
