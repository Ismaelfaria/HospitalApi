﻿using HospitalApi.Entity;
using HospitalApi.Entity.Contracts;

namespace HospitalApi.Models
{
    public class HospitalInputModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sexuality { get; set; }
        public Condition Condition { get; set; }
    }
}