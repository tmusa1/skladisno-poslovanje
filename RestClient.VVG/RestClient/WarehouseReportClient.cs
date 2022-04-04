using RestClient.VVG.RestClient;
using System.Text.Json;

namespace RestClient.VVG.RestClient
{
    public class WarehouseReportClient<T> : RestClient<T>
    {
        public WarehouseReportClient() : base("") { }

        public void warehouseTransactionReport()
        {
            // *?
            Task<HttpResponseMessage> responseTask = base.client.GetAsync("BankTransaction/getTransactionReport");

            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                var responseContent = responseTask.Result.Content.ReadAsStringAsync();

                DataSource = JsonSerializer.Deserialize<IList<T>>(responseContent.Result);
            }
        }
    }
}
