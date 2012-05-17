﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    public class DataSource : JsonObject
    {
        public DataSource()
        {
            Transport = new Transport();

            Filters = new List<CompositeFilterDescriptor>();
            OrderBy = new List<SortDescriptor>();
            Groups = new List<GroupDescriptor>();
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            var transport = Transport.ToJson();

            if (transport.Keys.Any())
            {
                json["transport"] = transport;
            }

            if (PageSize > 0)
            {
                json["pageSize"] = PageSize;
            }

            if (ServerPaging)
            {
                json["serverPaging"] = ServerPaging;
            }

            if (ServerSorting)
            {
                json["serverSorting"] = ServerSorting;
            }

            if (ServerFiltering)
            {
                json["serverFiltering"] = ServerFiltering;
            }

            if (ServerGrouping)
            {
                json["serverGrouping"] = ServerGrouping;
            }

            if (ServerAggregates)
            {
                json["serverAggregates"] = ServerAggregates;
            }

            json["type"] = "aspnetmvc-" + Type.ToString().ToLower();

            if (OrderBy.Any())
            {
                json["sort"] = OrderBy.ToJson();
            }

            if (Groups.Any())
            {
                json["group"] = Groups.ToJson();
            }
        }

        public DataSourceType Type
        {
            get;
            set;
        }

        public IList<CompositeFilterDescriptor> Filters
        {
            get;
            private set;
        }

        public IList<SortDescriptor> OrderBy
        {
            get;
            private set;
        }

        public IList<GroupDescriptor> Groups
        {
            get;
            private set;
        }

        public int PageSize 
        { 
            get; 
            set; 
        }

        public bool ServerPaging
        {
            get;
            set;
        }

        public bool ServerSorting
        {
            get;
            set;
        }

        public bool ServerFiltering
        {
            get;
            set;
        }

        public bool ServerGrouping
        {
            get;
            set;
        }

        public bool ServerAggregates
        {
            get;
            set;
        }

        public Transport Transport
        {
            get;
            private set;
        }
    }
}