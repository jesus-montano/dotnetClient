using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            runClient();
        }
        static void runClient(){
            using(var client = new HttpClient()){
                client.BaseAddress =new Uri("https://jsonplaceholder.typicode.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplicatiion/json"));
                GetById(client, "1").Wait();
                postComment(client, new Comment() {name = "asdgfs", email = "test@test.com", body ="dgadfgshfgnsvrgsbfdd"}).Wait();
                updateComment(client, "1", new Comment() {name = "asdgfs", email = "test@test.com", body ="dgadfgshfgnsvrgsbfdd"}).Wait();
                 GetAll(client).Wait();

            }
        }
        static async Task GetById(HttpClient client, string id){
            //get Comment
            try{
                HttpResponseMessage response = await client.GetAsync("comments/" + id);
                response.EnsureSuccessStatusCode();

                Comment comment = await response.Content.ReadAsAsync<Comment>();

                Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
            }
        }

        static async Task GetAll(HttpClient client){
            //get Comment
            try{
                HttpResponseMessage response = await client.GetAsync("comments" );
                response.EnsureSuccessStatusCode();

                List<Comment> comments = await response.Content.ReadAsAsync<List<Comment>>();

                foreach(Comment comment in comments){
                    Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                }
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
            }
        }

        static async Task postComment(HttpClient client, Comment comment){
            //post Comment
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync("comments", comment);
                response.EnsureSuccessStatusCode();

                Comment comments = await response.Content.ReadAsAsync<Comment>();
                Console.WriteLine("saved");

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
            }
        }

        static async Task updateComment(HttpClient client, string id, Comment comment){
            //put Comment
            try{
                HttpResponseMessage response = await client.PutAsJsonAsync("comments/"+ id, comment);
                response.EnsureSuccessStatusCode();

                Comment comments = await response.Content.ReadAsAsync<Comment>();
                Console.WriteLine("updated");

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
            }
        }
    }

    public class Comment{
        public int postId {get; set;}
        public int id {get; set;}
        
        public string name {get; set;}

        public string email {get; set;}
    
        public string body {get; set;}
    }
}
   
