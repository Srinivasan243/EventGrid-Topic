using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Azure.Messaging.EventGrid;
using Newtonsoft.Json;
using SendEventGrid.Utility;
using Microsoft.Azure.EventGrid;



namespace SendEventGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = "https://pastracking-eventgrid.westeurope-1.eventgrid.azure.net/api/events";
            string SAS = "FzkqkCCH9bQg7b5bk03PEurnCM3OEV7TcKlBCMECRO4=";

            Console.WriteLine($"Enter No of Message will send to Event Grid\n");
            var Count = Convert.ToInt32(Console.ReadLine());

            var events = new List<PasTracking>();

            for (int i = 1; i <= Count; i++)
            {
                var j = Convert.ToString(i);
                PasTracking ps = new PasTracking();
                Context ct = new Context();
                ct.id = Guid.NewGuid().ToString();
                ct.orderId = Convert.ToString(i);
                ct.quantity = i*3;
                ct.query = "Testing Purpose";
                ct.revenue = i*2000;
                ct.store = "Coop";
                ct.source = "Product";

                ps.context = ct;
                ps.primaryId = "12345"+j;
                ps.secondaryId = "7365"+j;
                ps.action = "Add";
                

                events.Add(ps);
            }

            List<Message<PasTracking>> msg = new List<Message<PasTracking>>();

            var message = new Message<PasTracking>();
            message.Id = Guid.NewGuid().ToString();
            message.EventTime = DateTime.UtcNow.ToString();
            message.EventType = "test";
            message.Subject = "testData";
            message.Data = events;
            msg.Add(message);





            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("aeg-sas-key", SAS);
                var message1 = JsonConvert.SerializeObject(msg);
                StringContent content = new StringContent(message1, Encoding.UTF8, "application/json");
                var response = client.PostAsync(endpoint, content);
                if (response.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully send message{response.Status}");
                }

            }
        }
    }
}
