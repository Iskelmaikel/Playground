﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.Database.Entities
{
    public interface IId
    {
        public Guid Id { get; set; }
    }
}