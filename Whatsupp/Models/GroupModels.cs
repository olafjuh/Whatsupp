using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class Group
    {
        public int number;
        public string naam;

        public Group(int a, string b)
        {
            this.number = a;
            this.naam = b;
        }
    }
}