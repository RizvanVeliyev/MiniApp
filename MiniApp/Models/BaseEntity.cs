using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.Models
{
    public abstract class BaseEntity
    {
        private static int _id = 1;
        public int Id { get; private set; }

        protected BaseEntity()
        {
            Id = _id++;
        }
    }
}
