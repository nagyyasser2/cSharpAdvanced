using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    public class Employee: IEnumerable<PayItem>
    {
        private readonly List<PayItem> _payItems = new List<PayItem>();
        public string Name { get; set; }

        public void AddPayItem(string name, int value)
        {
            _payItems.Add(new PayItem { Name = name, Value = value });
        }

        public IEnumerator<PayItem> GetEnumerator()
        {
            return _payItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
