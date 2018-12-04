using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class UserNumbers
    {
        private string turnnumber;

        public string Turnnumber
        {
            get { return turnnumber; }
            set { turnnumber = value; }
        }

        private int num1;

        public int Num1
        {
            get { return num1; }
            set { num1 = value; }
        }

        private int num2;

        public int Num2
        {
            get { return num2; }
            set { num2 = value; }
        }

        private int num3;

        public int Num3
        {
            get { return num3; }
            set { num3 = value; }
        }

        private int num4;

        public int Num4
        {
            get { return num4; }
            set { num4 = value; }
        }

        private int num5;

        public int Num5
        {
            get { return num5; }
            set { num5 = value; }
        }

        private int num6;

        public int Num6
        {
            get { return num6; }
            set { num6 = value; }
        }
<<<<<<< HEAD

=======
       
        private string id;
>>>>>>> cd4861abc14ab5b1fc5717604df247d083cc960e

        public UserNumbers(string turnnumber, int num1, int num2, int num3, int num4, int num5, int num6)
        {
            this.turnnumber = turnnumber;
            this.num1 = num1;
            this.num2 = num2;
            this.num3 = num3;
            this.num4 = num4;
            this.num5 = num5;
            this.num6 = num6;
        }

        public List<int> MakeList()
        {
            List<int> list = new List<int>();
            list.Add(num1);
            list.Add(num2);
            list.Add(num3);
            list.Add(num4);
            list.Add(num5);
            list.Add(num6);

            return list;
        }
    }
}
