using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestClient.VVG.RestClient
{
    public class WarehouseRestClient<T> : RestClient<T>
    {
        public WarehouseRestClient(string inEndpoint) : base(inEndpoint)
        {
        }

        public void bankAccountByPersonId(int personId)
        {
            Task<HttpResponseMessage> responseTask = base.client.GetAsync("BankAccount/Person/" + personId);

            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                var responseContent = responseTask.Result.Content.ReadAsStringAsync();

                DataSource = JsonSerializer.Deserialize<IList<T>>(responseContent.Result);
            }
        }
    }
}
