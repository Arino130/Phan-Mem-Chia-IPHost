using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_mềm_chia_Host
{
    class Calculator
    {
        public Calculator(){}
        public int FindX(int n)
        {
            for(int i = 0; i < n; i++)
            {
                if (Math.Pow(2, i) > n)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
