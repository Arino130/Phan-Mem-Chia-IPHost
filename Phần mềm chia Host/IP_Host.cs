using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_mềm_chia_Host
{
    class IP_Host
    {
        private List<int> octet;
        private int MaskNumber;
        private List<int> subnetMask;
        private int k=0;
        private int vtr = 0;
        public IP_Host() {
            octet = new List<int>();
            subnetMask = new List<int>(); 
        }
        public void AddOctet(int a,int b,int c,int d)
        {
            octet.Add(a);
            octet.Add(b);
            octet.Add(c);
            octet.Add(d);
        }
        public void AddsubnetMask(int a,int b,int c,int d)
        {
            subnetMask.Add(a);
            subnetMask.Add(b);
            subnetMask.Add(c);
            subnetMask.Add(d);
        }
        public List<int> getOctet()
        {
            return octet;
        }
        public int getSubnetMaskNumber()
        {
            return MaskNumber;
        }
        public int getVtr()
        {
            return vtr;
        }
        public void CovertMask(int MaskNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                switch (MaskNumber)
                {
                    case 0:
                        AddsubnetMask(0, 0, 0, 0);
                        break;
                    case 1:
                        AddsubnetMask(128, 0, 0, 0);
                        break;
                    case 2:
                        AddsubnetMask(192, 0, 0, 0);
                        break;
                    case 3:
                        AddsubnetMask(224, 0, 0, 0);
                        break;
                    case 4:
                        AddsubnetMask(220, 0, 0, 0);
                        break;
                    case 5:
                        AddsubnetMask(248, 0, 0, 0);
                        break;
                    case 6:
                        AddsubnetMask(252, 0, 0, 0);
                        break;
                    case 7:
                        AddsubnetMask(254, 0, 0, 0);
                        break;
                    case 8:
                        AddsubnetMask(255, 0, 0, 0);
                        break;
                    case 9:
                        AddsubnetMask(255, 128, 0, 0);
                        break;
                    case 10:
                        AddsubnetMask(255, 192, 0, 0);
                        break;
                    case 11:
                        AddsubnetMask(255, 224, 0, 0);
                        break;
                    case 12:
                        AddsubnetMask(255, 240, 0, 0);
                        break;
                    case 13:
                        AddsubnetMask(255, 248, 0, 0);
                        break;
                    case 14:
                        AddsubnetMask(255, 252, 0, 0);
                        break;
                    case 15:
                        AddsubnetMask(255, 254, 0, 0);
                        break;
                    case 16:
                        AddsubnetMask(255, 255, 0, 0);
                        break;
                    case 17:
                        AddsubnetMask(255, 255, 128, 0);
                        break;
                    case 18:
                        AddsubnetMask(255, 255, 192, 0);
                        break;
                    case 19:
                        AddsubnetMask(255, 255, 224, 0);
                        break;
                    case 20:
                        AddsubnetMask(255, 255, 240, 0);
                        break;
                    case 21:
                        AddsubnetMask(255, 255, 248, 0);
                        break;
                    case 22:
                        AddsubnetMask(255, 255, 252, 0);
                        break;
                    case 23:
                        AddsubnetMask(255, 255, 254, 0);
                        break;
                    case 24:
                        AddsubnetMask(255, 255, 255, 0);
                        break;
                    case 25:
                        AddsubnetMask(255, 255, 255, 128);
                        break;
                    case 26:
                        AddsubnetMask(255, 255, 255, 192);
                        break;
                    case 27:
                        AddsubnetMask(255, 255, 255, 224);
                        break;
                    case 28:
                        AddsubnetMask(255, 255, 255, 240);
                        break;
                    case 29:
                        AddsubnetMask(255, 255, 255, 248);
                        break;
                    case 30:
                        AddsubnetMask(255, 255, 255, 252);
                        break;
                    case 31:
                        AddsubnetMask(255, 255, 255, 254);
                        break;
                }
            }
        }
        public void SubnetMaskNumber(int m)
        {
            MaskNumber = 32 - m;
            CovertMask(MaskNumber);
        }
        public int get_K()
        {
            return k;
        }
        public void setVtr(int MaskNumber)
        {
            if(MaskNumber<=8)
            {
                //Tim k
                k = 16 - MaskNumber;
                vtr = 2;
                return;
            }
            if (MaskNumber <= 24)
            {
                //Tim k
                k = 24 - MaskNumber;
                vtr = 3;
                return;
            }
            if (MaskNumber <= 32)
            {
                //Tim k
                k = 32 - MaskNumber;
                vtr = 4;
                return;
            }
        }
        public bool SumMark(int octec1,IP_Host dataIn,int index) //nếu octec truyền vào lớn hơn 255
        {
            int count = 0;
            int Tong = 0;

            if(octec1>=0 || octec1 <= 127) //N,H,H,H
            {
                int temp;
                switch (index)
                {
                    case 2:
                        break;
                    case 3:
                        temp = Convert.ToInt32(dataIn.getOctet()[2] + Math.Pow(2, dataIn.get_K()));
                        count = 0;
                        Start1:
                        if (temp > 255)
                        {
                            octet[2] = 255;
                            temp = temp - 255;
                            count =count+ 1;
                            goto Start1;
                        }
                        else
                        {                            
                            if (temp < 0)
                                temp *= -1;
                            if (count == 0)
                            {
                                octet[2] = temp;
                                return true;
                            }
                            octet[2] = temp;
                            temp = Convert.ToInt32(dataIn.getOctet()[1] + count);
                            count = 0;
                            Start2:
                            if (temp > 255)
                            {
                                octet[1] = 255;
                                temp = temp - 255;
                                count = count + 1;
                                goto Start2;
                            }
                            else
                            {
                                if (temp < 0)
                                    temp *= -1;
                                if (count == 0)
                                {
                                    octet[2] = temp;
                                    return true;
                                }
                                octet[2] = temp;
                                temp = Convert.ToInt32(dataIn.getOctet()[1] + count);
                                count = 0;
                                Start3:
                                if (temp > 255)
                                {
                                    octet[1] = 255;
                                    temp = temp - 255;
                                    count = count + 1;
                                    if (count == 2) return false;
                                    goto Start3;
                                }
                                if (dataIn.getOctet()[1] + temp > 255)
                                    return false;
                                else
                                {
                                    if (temp < 0)
                                        temp *= -1;
                                    if (count == 0)
                                    {
                                        octet[1] = temp;
                                        return true;
                                    }
                                    octet[1] = temp;
                                    return true;
                                }
                            }
                        }
                    case 4:
                        temp = Convert.ToInt32(dataIn.getOctet()[3] + Math.Pow(2, dataIn.get_K()));
                        count = 0;
                        Tong = 0;
                        Start4:
                        if (temp > 255)
                        {
                            octet[3] = 255;
                            temp = temp - 255;
                            count += 1;
                            goto Start4;
                        }
                        else
                        {
                            if (count == 0)
                                return true;
                            if (temp < 0)
                                temp *= -1;
                            octet[3] = temp;
                            temp = Convert.ToInt32(dataIn.getOctet()[2] + count);
                            count = 0;
                        Start5:
                            if (temp > 255)
                            {
                                octet[2] = 255;
                                temp = temp - 255;
                                count += 1;
                                goto Start5;
                            }
                            else
                            {
                                if (count == 0)
                                    return true;
                                if (temp < 0)
                                    temp *= -1;
                                octet[2] = temp;
                                temp = Convert.ToInt32(dataIn.getOctet()[1] + count);
                                count = 0;
                            Start6:
                                if (temp > 255)
                                {
                                    octet[1] = 255;
                                    temp = temp - 255;
                                    count += 1;
                                    if (count == 2) return false;
                                    goto Start6;
                                }
                                else
                                {
                                    if (temp < 0)
                                        temp *= -1;
                                    octet[1] = temp;
                                    return true;
                                }

                            }
                        }
                }
                

            }
            else if(octec1 >= 128 && octec1 <= 191)//N,N,H,H
            {

            }
            else if(octec1 >= 192 && octec1 <= 223)//N,N,N,H
            {

            }
            return false;
        }
        public bool handlingIP(int m,IP_Host dataIn,int index)
        {
            //Tim so moi de xet DK
            SubnetMaskNumber(m); //Tinh M
            setVtr(MaskNumber); //Tinh K
            if (index == 0)
            {
                AddOctet(dataIn.getOctet()[0], dataIn.getOctet()[1], dataIn.getOctet()[2], dataIn.getOctet()[3]); 
                return true;
            }
            else
            {
                switch (dataIn.getVtr())
                {
                    case 2:
                        if (dataIn.get_K() == 0)
                        {
                            AddOctet(dataIn.getOctet()[0], dataIn.getOctet()[1] + 1, dataIn.getOctet()[2], dataIn.getOctet()[3]);
                            return true;
                        }
                        AddOctet(dataIn.getOctet()[0], Convert.ToInt32(dataIn.getOctet()[1] + Math.Pow(2, dataIn.get_K())), dataIn.getOctet()[2], dataIn.getOctet()[3]);
                        //return (SumMark(dataIn.getOctet()[0], dataIn, 1));
                        break;
                    case 3:
                        if (dataIn.get_K() == 0)
                        {
                            AddOctet(dataIn.getOctet()[0], dataIn.getOctet()[1], dataIn.getOctet()[2] + 1, dataIn.getOctet()[3]);
                            return true;
                        }
                        AddOctet(dataIn.getOctet()[0], dataIn.getOctet()[1], Convert.ToInt32(dataIn.getOctet()[2] + Math.Pow(2, dataIn.get_K())), dataIn.getOctet()[3]);
                        //return (SumMark(dataIn.getOctet()[0], dataIn, 2)); 
                        break;
                    case 4:
                        if (dataIn.get_K() == 0)
                        {                          
                             AddOctet(dataIn.getOctet()[0], dataIn.getOctet()[1], dataIn.getOctet()[2], dataIn.getOctet()[3]+1);
                             return true;
                        }
                        //return (SumMark(dataIn.getOctet()[0], dataIn, 3));
                        AddOctet(dataIn.getOctet()[0], dataIn.getOctet()[1], dataIn.getOctet()[2], Convert.ToInt32(dataIn.getOctet()[3] + Math.Pow(2, dataIn.get_K())));
                        break;
                }
                return false;
            }
        }
        public string toStringIP()
        {
            return octet[0] + "." + octet[1] + "." + octet[2] + "." + octet[3];
        }
        public string toStringMask()
        {
            return subnetMask[0] + "." + subnetMask[1] + "." + subnetMask[2] + "." + subnetMask[3];
        }
    }
}
