using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mei.Stores
{
    public class RefreshStore
    {
        public event Action? RefreshRequested;

        public void RequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}
