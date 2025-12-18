using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace smart_journal.Models
{
    public class AppSettings
    {
        public int Id { get; set; } = 1;
        public string PinHash { get; set; }
        public bool IsPinSet { get; set; }

    }
}
