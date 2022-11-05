﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        {
        }
    }
}
