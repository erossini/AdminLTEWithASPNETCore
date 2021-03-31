using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain.Interfaces
{
    public interface ICommonTable : ITable
    {
        public string Name { get; set; }
    }
}
