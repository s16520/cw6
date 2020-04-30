using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw6.Models;

namespace cw6.Services
{
    public interface IDbService
    {

        Student GetStudent(string index);
    }
}
