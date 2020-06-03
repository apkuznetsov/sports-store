﻿using System;

namespace SportsStore.Webapp.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}