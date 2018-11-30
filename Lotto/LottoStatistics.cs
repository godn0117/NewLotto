using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class LottoStatistics
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public LottoStatistics() { }
        public LottoStatistics(string name) : this()
        {
            this.name = name;
        }

        public LottoStatistics(string name, int num) : this(name)
        {
            this.num = num;
        }
    }
}
