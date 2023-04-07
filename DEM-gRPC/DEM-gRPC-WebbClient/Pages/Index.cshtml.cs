using DEM_gRPC_Service;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEM_gRPC_WebbClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Greeter.GreeterClient client;
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty]
        public string Name { get; set; }

        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            var url = "http://localhost:5140";
            var channel = GrpcChannel.ForAddress(url);
            client = new Greeter.GreeterClient(channel);
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            var helloRequest = new HelloRequest();
            helloRequest.Name = Name;

            var result = await client.SayHelloAsync(helloRequest);

            Message = result.Message;

        }
    }
}