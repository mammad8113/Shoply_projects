﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public class SlideViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Heding { get; set; }
        public string Title { get; set; }
        public bool IsRemove { get; set; }
        public string CreationDate { get; set; }
    }
}
