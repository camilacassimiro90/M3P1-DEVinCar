﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Exceptions
{
    public class ExisteException : Exception
    {
        public ExisteException(string message) : base(message)
        {
        }
    }
}
