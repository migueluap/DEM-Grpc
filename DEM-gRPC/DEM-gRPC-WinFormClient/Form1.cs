using DEM_gRPC_Service;
using Grpc.Net.Client;

namespace DEM_gRPC_WinFormClient
{
    public partial class Form1 : Form
    {
        private readonly Greeter.GreeterClient client;

        public Form1()
        {
            InitializeComponent();

            var url = "http://localhost:5140";
            var channel = GrpcChannel.ForAddress(url);
            client = new Greeter.GreeterClient(channel);
        }

        private void txtSend_Click(object sender, EventArgs e)
        {
            var helloRequest = new HelloRequest();
            helloRequest.Name = txtName.Text;

            var result = client.SayHello(helloRequest);

            lblResult.Text = result.Message;
        }
    }
}