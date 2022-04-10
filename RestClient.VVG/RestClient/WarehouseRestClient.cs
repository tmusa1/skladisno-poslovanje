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

        public void articleByCompanyId(int companyId)
        {
            Task<HttpResponseMessage> responseTask = base.client.GetAsync("Article/Company/" + companyId);

            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                var responseContent = responseTask.Result.Content.ReadAsStringAsync();

                DataSource = JsonSerializer.Deserialize<IList<T>>(responseContent.Result);
            }
        }
    }
}
