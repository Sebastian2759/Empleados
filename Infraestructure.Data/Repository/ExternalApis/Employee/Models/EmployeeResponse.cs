﻿using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository.ExternalApis.Employee.Models
{
    public class EmployeeResponse
    {
        public string Status { get; set; }
        public object Data { get; set; }
    }
}
