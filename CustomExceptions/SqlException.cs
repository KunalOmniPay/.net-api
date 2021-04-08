﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class SqlException : Exception
    {
        public SqlException(string message) :
            base(message)
        {

        }
        public SqlException(string message, Exception innerException) :
            base(message, innerException)
        {

        }
    }
}
