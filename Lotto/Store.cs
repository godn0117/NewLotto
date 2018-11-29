using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Store
    {
        private int pkNo;

        public int PkNo
        {
            get { return pkNo; }
            set { pkNo = value; }
        }

        private string shopName;

        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }
        private int winningCount;

        public int WinningCount
        {
            get { return winningCount; }
            set { winningCount = value; }
        }
        private string addr;

        public string Addr
        {
            get { return addr; }
            set { addr = value; }
        }

        public Store(int pkNo, string shopName, int winningCount, string addr)
        {
            this.pkNo = pkNo;
            this.shopName = shopName;
            this.winningCount = winningCount;
            this.addr = addr;
        }

        
    }
}
