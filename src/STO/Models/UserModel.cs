﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string ModelCar { get; set; }
        public UserModel()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}