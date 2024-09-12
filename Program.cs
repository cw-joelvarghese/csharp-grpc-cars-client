using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using csharp_grpc_cars; // Replace with the namespace defined in the proto file

namespace csharp_grpc_cars_client;

class Program
{
    static async Task Main(string[] args)
    {
        // Create a channel to the gRPC server
        using var channel = GrpcChannel.ForAddress("http://localhost:5053"); // Replace with your server's address

        // Create a client instance
        var client = new FinanceService.FinanceServiceClient(channel);

        // Create a request
        var request = new CarsRequest();
        request.Id.AddRange([1, 2, 3, 4]);

        try
        {
            // Make the call
            var response = await client.GetIsValueForMoneyAsync(request);

            // Display the response
            Console.WriteLine($"Received data: {response.Cars.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calling gRPC server: {ex.Message}");
        }
    }
}
