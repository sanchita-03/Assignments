﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemApp.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string msg):base(msg)
        {
            
        }
    }
}
