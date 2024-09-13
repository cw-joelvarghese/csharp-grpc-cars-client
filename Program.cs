using Grpc.Net.Client;
using csharp_grpc_cars;


using var channel = GrpcChannel.ForAddress("http://localhost:5053");

var client = new FinanceService.FinanceServiceClient(channel);

var request = new CarsRequest();
request.Id.AddRange([1, 2, 3, 4]);

try
{
    CarsResponse response = await client.GetIsValueForMoneyAsync(request);

    foreach (var item in response.Cars) {
        Console.WriteLine(item.Id);
        Console.WriteLine(item.IsValueForMoney);
        Console.WriteLine();
    } ;
}
catch (Exception ex)
{
    Console.WriteLine($"Error calling gRPC server: {ex.Message}");
}
