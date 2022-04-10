using Model.VVG.model;
using RestClient.VVG.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.VVG.Service
{
    public sealed class DataService
    {
        // *??
        public static string baseUrl { get; set; } = "https://localhost:7109";

        private static readonly DataService instance = new DataService();
        public static RestClient<Company> companyRestClient { get; set; }
        public static WarehouseRestClient<Article> warehouseRestClient { get; set; }
        public static RestClient<Article> articleRestClient { get; set; }


        private DataService()
        {
            Initialize();
        }

        public static DataService Instance
        {

            get { return instance; }
        }

        public static void Initialize()
        {
            companyRestClient = new RestClient<Company>("Company");
            warehouseRestClient = new WarehouseRestClient<Article>("Article");
            articleRestClient = new RestClient<Article>("Article");
        }

    }
}
