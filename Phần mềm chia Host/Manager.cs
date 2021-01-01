using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;

namespace Phần_mềm_chia_Host
{
    public partial class Manager : Form
    {
        private Calculator calculator;
        private int count = 0;
        private Color colorError = System.Drawing.Color.Red;
        List<IP_Host> Data;
        private bool LockMK = false;
        public Manager()
        {
            calculator = new Calculator();
            IP_Host iP_Host = new IP_Host();
            iP_Host.AddOctet(172, 31, 10, 192);
            IP_Host iP_Host1 = new IP_Host();
            Data = new List<IP_Host>();

            InitializeComponent();
        }
        private void AddListHost(string text)
        {
            count += 1;
            ListHost.Items.Add(count + "            " + text);
        }
        private int checkNumber(bool status)
        {
            int parsedValue;
            if (textoc1.Text.CompareTo("...") == 0 || textoc1.Text.CompareTo("") == 0)
            {     
                if(status == true)
                {
                    textoc1.BackColor = colorError;
                    textoc1.Text = "";
                    MessageBox.Show("Octec 1 rỗng.", "Thông báo lỗi");
                    return -1;
                }
                
            }
            else if (int.TryParse(textoc1.Text, out parsedValue) != true)
            {
                textoc1.BackColor = colorError;
                textoc1.Text = "";
                goto False;
            }
            else if (Convert.ToInt32(textoc1.Text) <= -1 || Convert.ToInt32(textoc1.Text) > 255)
                {
                    textoc1.BackColor = colorError;
                    textoc1.Text = "";
                    MessageBox.Show("Octec 1 không trong khoảng 1->255", "Thông báo lỗi");
                    return -1;
                }
            if (textoc2.Text.CompareTo("...") == 0 || textoc2.Text.CompareTo("") == 0)
            {
                if (status == true)
                {
                    textoc2.BackColor = colorError;
                    textoc2.Text = "";
                    MessageBox.Show("Octec 2 rỗng.", "Thông báo lỗi");
                    return -1;
                }
            }
            else if (int.TryParse(textoc2.Text, out parsedValue) != true)
            {
                textoc2.BackColor = colorError;
                textoc2.Text = "";
                goto False;
            }
            else if (Convert.ToInt32(textoc2.Text) <= -1 || Convert.ToInt32(textoc2.Text) > 255)
                {
                    textoc2.BackColor = colorError;
                    textoc2.Text = "";
                    MessageBox.Show("Octec 2 không trong khoảng 1->255", "Thông báo lỗi");
                    return -1;
                }
            if (textoc3.Text.CompareTo("...") == 0 || textoc3.Text.CompareTo("") == 0)
            {
                if (status == true)
                {
                    textoc3.BackColor = colorError;
                    textoc3.Text = "";
                    MessageBox.Show("Octec 3 rỗng.", "Thông báo lỗi");
                    return -1;
                }
            }
            else if (int.TryParse(textoc3.Text, out parsedValue) != true)
            {
                textoc3.BackColor = colorError;
                textoc3.Text = "";
                goto False;
            }
            else if (Convert.ToInt32(textoc3.Text) <= -1 || Convert.ToInt32(textoc3.Text) > 255)
                {
                    textoc3.BackColor = colorError;
                    textoc3.Text = "";
                    MessageBox.Show("Octec 3 không trong khoảng 1->255", "Thông báo lỗi");
                    return -1;
                }
            if (textoc4.Text.CompareTo("...") == 0 || textoc4.Text.CompareTo("") == 0)
            {
                if (status == true)
                {
                    textoc4.BackColor = colorError;
                    textoc4.Text = "";
                    MessageBox.Show("Octec 4 rỗng.", "Thông báo lỗi");
                    return -1;
                }
            }
            else if (int.TryParse(textoc4.Text, out parsedValue) != true)
            {
                textoc4.BackColor = colorError;
                textoc4.Text = "";
                goto False;
            }
            else if (Convert.ToInt32(textoc1.Text) <= -1 || Convert.ToInt32(textoc4.Text) > 255)
                {
                    textoc4.BackColor = colorError;
                    textoc4.Text = "";
                    MessageBox.Show("Octec 4 không trong khoảng 1->255", "Thông báo lỗi");
                    return -1;
                }
            if (textMask.Text.CompareTo("...") == 0 || textMask.Text.CompareTo("") == 0)
            {
                if (status == true)
                {
                    textMask.BackColor = colorError;
                    textMask.Text = "";
                    MessageBox.Show("Submark rỗng.", "Thông báo lỗi");
                    return -1;
                }
            }
            else if (int.TryParse(textMask.Text, out parsedValue) != true)
            {
                textMask.BackColor = colorError;
                textMask.Text = "";
                goto False;
            }
            else if (Convert.ToInt32(textMask.Text) <= -1 || Convert.ToInt32(textMask.Text) > 31)
                {
                    textMask.BackColor = colorError;
                    textMask.Text = "";
                    MessageBox.Show("Subnet Mark không trong khoảng 0->31", "Thông báo lỗi");
                    return -1;
                }
            else
            {
                return 0;
            }
            False:
                MessageBox.Show("IP không được chứa kí tự !", "Thông báo lỗi");
                return -1;
        }
        private void simpleButton1asd_Click(object sender, EventArgs e) //Start
        {          
            int count = 0;
            if (checkNumber(true)!=0)
                return;
            else if (ListHost.Items.Count == 0)
            {
                MessageBox.Show("Danh sách Host không tồn tại", "Thông báo lỗi");
                return;
            }             
                int oc1, oc2, oc3, oc4;
                oc1 = Convert.ToInt32(textoc1.Text);
                oc2 = Convert.ToInt32(textoc2.Text);
                oc3 = Convert.ToInt32(textoc3.Text);
                oc4 = Convert.ToInt32(textoc4.Text);
                IP_Host iP_Host1 = new IP_Host();
                //Thêm Ip đầu vào list result
                if (ListResult.Items.Count != 0)
                {
                    ListResult.Items.Add("------------------------------------------------------");                                   
                    iP_Host1.AddOctet(0, 0, 0, 0);
                    iP_Host1.CovertMask(0);
                    Data.Add(iP_Host1);
                }
                if (checkedListIP.Items.Count != 0)
                {
                    checkedListIP.Items.Add("------------------------------------------------------",CheckState.Indeterminate);
                }
                iP_Host1 = new IP_Host();
                ListResult.Items.Add("#" + count + ": " + oc1 + "." + oc2 + "." + oc3 + "." + oc4 + @"/" + textMask.Text);
                checkedListIP.Items.Add("#" + count + ": " + oc1 + "." + oc2 + "." + oc3 + "." + oc4 + @"/" + textMask.Text,CheckState.Unchecked);
                iP_Host1.AddOctet(oc1, oc2, oc3, oc4);
                iP_Host1.CovertMask(Convert.ToInt32(textMask.Text));
                Data.Add(iP_Host1);
                int countH = 0;
                    //Tinh #1->N
                for (int i = 0; i < ListHost.Items.Count; i++)
                {
                    IP_Host iP_Host2 = new IP_Host();
                    int temp = Convert.ToInt32(string.Join(" ", ListHost.GetItem(i).ToString().Split(' ').Skip(2)));
                       //if (iP_Host2.handlingIP(calculator.FindX(temp), Data[countH], i) != false)
                       //{
                        iP_Host2.handlingIP(calculator.FindX(temp), Data[i], i);
                        //Thêm items vao listResult tab1
                        countH += 1;
                        count = i + 1;
                        ListResult.Items.Add("#" + count + ": " + iP_Host2.toStringIP() + @"/" + iP_Host2.getSubnetMaskNumber().ToString()+" "+temp+" Host");
                        //Thêm items vao checklistIP tab2
                        checkedListIP.Items.Add("#" + count + ": " + iP_Host2.toStringIP() + @"/" + iP_Host2.getSubnetMaskNumber().ToString(), CheckState.Unchecked);                       
                        Data.Add(iP_Host2);
                       //}
                      //else
                       //{
                       //   MessageBox.Show("Không đủ "+ temp + " Host cho IP: " + Data[countH].toStringIP(),"Thông báo lỗi");
                       //}
                }
                //Kt list result !=null
                ListResult.SelectedIndex = 0;
                if (Data[ListResult.SelectedIndex] != null)
                    textSubnetMark.Text = Data[ListResult.SelectedIndex].toStringMask();               
        }

        private void ListHost_MouseDown(object sender, MouseEventArgs e)
        {
            ListHost.SelectedIndex = ListHost.IndexFromPoint(e.Location);
        }

        private void simpleButton3_Click(object sender, EventArgs e) //Remove
        {
            if (ListHost.Items.Count == 0)
            {
                MessageBox.Show("List is Null !");
                return;
            }
            else
            {
                List<string> temp = new List<string>(); ;
                ListHost.Items.Remove(ListHost.GetItem(ListHost.SelectedIndex));
                for (int i = 0; i < ListHost.Items.Count; i++)
                {
                    temp.Add(string.Join(" ", ListHost.GetItem(i).ToString().Split(' ').Skip(12)));
                }
                ListHost.Items.Clear();
                count = 0;
                for (int i = 0; i < temp.Count; i++)
                {
                    AddListHost(temp[i].ToString());
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkT_Host(true) != false)
            {
                AddListHost(numberHost.Text);
                if(LockMK==false)
                    numberHost.Text = "";
            }
        }

        private void textoc1_Click(object sender, EventArgs e)
        {
            textoc1.Text = ""; ListResult.Items.Clear();
            Data.Clear();
            textoc1.BackColor = System.Drawing.Color.White;
        }

        private void textoc2_Click(object sender, EventArgs e)
        {
            textoc2.Text = ""; ListResult.Items.Clear();
            textoc2.BackColor = System.Drawing.Color.White;
        }

        private void textoc3_Click(object sender, EventArgs e)
        {
            textoc3.Text = ""; ListResult.Items.Clear();
            textoc3.BackColor = System.Drawing.Color.White;
        }

        private void textoc4_Click(object sender, EventArgs e)
        {
            textoc4.Text = ""; ListResult.Items.Clear();
            textoc4.BackColor = System.Drawing.Color.White;
        }

        private void textMask_Click(object sender, EventArgs e)
        {
            textMask.Text = ""; ListResult.Items.Clear();
            textMask.BackColor = System.Drawing.Color.White;
        }

        private void numberHost_Click(object sender, EventArgs e)
        {
            numberHost.BackColor = System.Drawing.Color.White;           
            LockMK = false;
            numberHost.Text = "";
        }

        private void ListResult_MouseDown(object sender, MouseEventArgs e)
        {
            ListResult.SelectedIndex =ListResult.IndexFromPoint(e.Location);
            if (Data[ListResult.SelectedIndex]!=null)
               textSubnetMark.Text = Data[ListResult.SelectedIndex].toStringMask();           
        }
        public bool checkT_Host(bool status)
        {
            int parsedValue;
            if(numberHost.Text.CompareTo("...")==0 || numberHost.Text.CompareTo("")==0)
            {
                MessageBox.Show("Bạn chưa nhập Host.", "Thông báo lỗi");
                return false;
            }
            if (int.TryParse(numberHost.Text, out parsedValue) != true && status == true)
            {
                numberHost.BackColor = colorError;
                numberHost.Text = "";
                MessageBox.Show("Bạn không được nhập kí tự.","Thông báo lỗi");
                return false;
            }
            if(Convert.ToInt32(numberHost.Text)<3)
            {
                MessageBox.Show("Số Host không được nhỏ hơn 3.", "Thông báo lỗi");
                return false;
            }
            return true;
        }
        private void simpleButton2_Click(object sender, EventArgs e) //Chia nhỏ IP
        {
            textoc1.Text = (Data[ListResult.SelectedIndex].getOctet()[0].ToString());
            textoc2.Text = (Data[ListResult.SelectedIndex].getOctet()[1].ToString());          
            textoc3.Text = (Data[ListResult.SelectedIndex].getOctet()[2].ToString());          
            textoc4.Text = (Data[ListResult.SelectedIndex].getOctet()[3].ToString());
            textMask.Text = (Data[ListResult.SelectedIndex].getSubnetMaskNumber().ToString());
            ListHost.Items.Clear();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Data.Clear();
            ListResult.Items.Clear();
            ListHost.Items.Clear();
            textoc1.Text = "";
            textoc2.Text = "";
            textoc3.Text = "";
            textoc4.Text = "";
            textMask.Text = "";
            checkedListIP.Items.Clear();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string text= (Data[ListResult.SelectedIndex].getOctet()[0].ToString())
            +"."+(Data[ListResult.SelectedIndex].getOctet()[1].ToString())
            + "." + (Data[ListResult.SelectedIndex].getOctet()[2].ToString())
            + "." + (Convert.ToInt32(Data[ListResult.SelectedIndex].getOctet()[3])+Convert.ToInt32(textvalue.Text)).ToString()
            + "/" + (Data[ListResult.SelectedIndex].getSubnetMaskNumber().ToString());
            MessageBox.Show("IP mới :" + text, "Kết Quả");
        }

        private void textvalue_Click(object sender, EventArgs e)
        {
            textvalue.Text = "";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (LockMK != false)
            {
                LockMK = false;
                return;
            }
            if (LockMK != true)
            {
                LockMK = true;
                return;
            }
            

        }
        private void checkedListIP_MouseClick(object sender, MouseEventArgs e)
        {
            checkedListIP.SelectedIndex = checkedListIP.IndexFromPoint(e.Location);
            if (Data[checkedListIP.SelectedIndex] != null)
                textSubM.Text = Data[checkedListIP.SelectedIndex].toStringMask();
        }

        private void simpleButton7_Click(object sender, EventArgs e) //Button Convert Code
        {
            List<IP_Host> DataOut = new List<IP_Host>();
            string ipaddress = "ip address ";
            string network = "network ";
            foreach(int a in checkedListIP.CheckedIndices)
            {
                if (checkedListIP.GetItemChecked(a) == true)
                {
                    DataOut.Add(Data[a]);
                }
            }
            foreach(int c in checkedListQery.CheckedIndices)
            {
                foreach(IP_Host b in DataOut)
                {
                    switch (c)
                    {
                        case 0:
                            listBoxCode.Items.Add(ipaddress + b.toStringIP() + " " + b.toStringMask());
                            break;
                        case 1:
                            listBoxCode.Items.Add(network + b.toStringIP() + " " + b.toStringMask()+" area 0");
                            break;
                        case 2:
                            break;
                    }
                    
                }
                listBoxCode.Items.Add("------------------------------------------------------");
            }
            
        }

        private void checkedListQery_MouseClick(object sender, MouseEventArgs e)
        {
            checkedListQery.SelectedIndex = checkedListQery.IndexFromPoint(e.Location);          
        }

        private void listBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
                foreach (object item in listBoxCode.SelectedItems)
                    copy_buffer.AppendLine(item.ToString());
                if (copy_buffer.Length > 0)
                    Clipboard.SetText(copy_buffer.ToString());
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm chia Host V1.0\nProduce by Phương Minh\nDemo Date:20/8/2020","Information");
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            listBoxCode.Items.Clear();
        }

        private void numberHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (checkT_Host(true) != false)
                {
                    string temp = numberHost.Text.TrimEnd();
                    temp = temp.TrimStart();
                    AddListHost(temp);
                    if (LockMK == false)
                        numberHost.Text = "";
                }
            }
        }
    }
}
