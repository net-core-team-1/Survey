﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Identity.Api.Identity.Domain.Civilities
{
    public class Civility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected Civility() { }

        public Civility(int Id)
           : this()
        {
            this.Id = Id;
        }
        private Civility(string name, string description)
            : this()
        {
            this.Name = name;
            this.Description = description;
        }

        public static Civility Create(string name, string description)
        {
            return new Civility(name, description);
        }
    }
}
