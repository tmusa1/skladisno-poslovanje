using RestClient.VVG.RestClient;
using System.Text.Json;

namespace RestClient.VVG.RestClient
{
    public class WarehouseTransactionReportClient<T> : RestClient<T>
    {
        public WarehouseTransactionReportClient() : base("") { }

        public void warehouseTransactionReport()
        {
            // *?
            Task<HttpResponseMessage> responseTask = base.client.GetAsync("WarehouseTransaction/getTransactionReport");

            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                var responseContent = responseTask.Result.Content.ReadAsStringAsync();

                DataSource = JsonSerializer.Deserialize<IList<T>>(responseContent.Result);
            }
        }
    }
}
