using DTIFunctions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTIFunctions.Services
{
    public class SimpleGreeter : IGreeter
    {
        public string SendGreetings(string payload)
        {
            return $"the payload: {payload} has been compiled!!";
        }
    }
}
