using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SendEventGrid.Utility
{
    public class Message<T>
    {
        public string Id { get;  set; }

        public string EventType { get; set; }

        public string Subject { get; set; }

        public string EventTime { get;  set; }

        public List<T> Data { get; set; }

      
    }

    public class PasTracking
    {
        public string primaryId { get; set; }

        public string secondaryId { get; set; }

        public string action { get; set; }

        public Context context { get; set; }

        
    }

    public class Context
    {
        public string id { get; set; }

        public string type { get; set; }

        public string orderId { get; set; }

        public string store { get; set; }

        public string query { get; set; }

        public string source { get; set; }

        public string targetSystem { get; set; }

        public int quantity { get; set; }

        public double revenue { get; set; }

        public bool searchAsYouType { get; set; }


    }
}
