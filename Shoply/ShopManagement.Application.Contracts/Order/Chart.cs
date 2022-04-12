using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class Chart
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("backgroundColor")]
        public List<string> BackgroundColor { get; set; }

        [JsonProperty("borderColor")]
        public string BorderColor { get; set; }

        [JsonProperty("data")]
        public List<int> Data { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }


        public Chart()
        {
            Labels= new List<string>();
            Data= new List<int>();
            BackgroundColor= new List<string>();
        }
        public Chart(string label, string borderColor, List<int> data)
        {
            Label = label;
            BorderColor = borderColor;
            Data = data;
           
        }
        public Chart(string label, string borderColor)
        {
            Labels = new List<string>();
            Data = new List<int>();
            BackgroundColor = new List<string>();
            Label = label;
            BorderColor = borderColor;
       

        }
    }
}
