using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNA_HUE
{
    public partial class Form1 : Form
    {
        readonly ColorDialog _dialog = new ColorDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private readonly ObjectEncode[] _lstEncode = new ObjectEncode[] {
            new ObjectEncode(){Key = 'A',Value= "CGA"},
            new ObjectEncode(){Key = 'B',Value = "CCA"},
            new ObjectEncode(){Key = 'C',Value = "GTT"},
            new ObjectEncode(){Key = 'D',Value = "TTG"},
            new ObjectEncode(){Key = 'E',Value = "GGT"},
            new ObjectEncode(){Key = 'F',Value = "ACT"},
            new ObjectEncode(){Key = 'G',Value = "TTT"},
            new ObjectEncode(){Key = 'H',Value = "CGC"},
            new ObjectEncode(){Key = 'I',Value = "ATG"},
            new ObjectEncode(){Key = 'J',Value = "AGT"},
            new ObjectEncode(){Key = 'K',Value = "AAG"},
            new ObjectEncode(){Key = 'L',Value = "TGC"},
            new ObjectEncode(){Key = 'M',Value = "TCC"}
        };

        private readonly CharacterToByte[] _lstByte = new CharacterToByte[]{
            new CharacterToByte(){Key = 'C',value = 0},
            new CharacterToByte(){Key = 'A',value = 1},
            new CharacterToByte(){Key = 'T',value = 2},
            new CharacterToByte(){Key = 'G',value = 3}
        };

        private readonly List<Color> _lstcorlor = new List<Color>();
        private readonly List<Color> _lstcorlor_after = new List<Color>();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private IEnumerable<char> ConvertBytetoChar(IEnumerable<byte> lst)
        {
            var enumerable = lst as IList<byte> ?? lst.ToList();
            return enumerable.Any()
                ? enumerable.Select(p => _lstByte.Where(k => k.value.Equals(p)).Select(z => z.Key).FirstOrDefault())
                    .ToList()
                : new List<char>();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var txtMautin = txtSimple.Text;
            var txtTindau = txtHide.Text;
            string[] txtMautin_toArray = txtMautin.Split(' ');
            string[] txtTindau_toArray = txtTindau.ToCharArray().Select(c => c.ToString()).ToArray();
            int sizeOfArray_mautin = txtMautin_toArray.Length;
            int sizeOfArray_tindau = txtTindau.Length;
            if (sizeOfArray_tindau > sizeOfArray_mautin)
            {
                Console.WriteLine("Tin can dau phai co tong so ky tu nho hon hoac bang tong so chu cua mau tin da cho!");
            }
            else
            {


                double xzi = 0.21821, wy = 5.1682, zy = 0.7812;

                byte xor = 00;
                Xor(xzi, ref xor);

                //Console.WriteLine("khang print......");
                var lstPrimer = this.ConvertBytetoChar(this.Yprimer(wy, zy));

                var yprimer = lstPrimer.Aggregate("", (current, item) => current + item);
                //Console.WriteLine(yprimer);

                // value need hide
                var value = DecodeCharacter(txtHide.Text.Trim()[0]);
                //Convert chuỗi MDNA -> danh sách Byte
                var lstByteConvert = value.Select(this.ConvertCharToByte).ToList();

                var lstMdna1 = this.AddByte(lstByteConvert, xor);

                var mdna1 = lstMdna1.Aggregate("", (current, item) => current + item);
                //Console.WriteLine(mdna1);

                var my = "";
                //Sau đó ta cộng chuỗi MDNA phẩy với chuỗi Yprimer
                my = yprimer + mdna1;
                var lenght_data = sizeOfArray_mautin - sizeOfArray_tindau;
                //Console.WriteLine("Lmautin - Ltindau = " + lenght_data);
                for (int index = 0; index < sizeOfArray_tindau; index++)
                {
                    var value_tindau = txtTindau_toArray[index];
                    var value_mautin = txtMautin_toArray[index];
                    var DANe = this.getDANe(value_tindau, value_mautin, my, yprimer);
                    Console.WriteLine(value_tindau + " --> " + value_mautin);
                    Console.WriteLine("DANe: " + DANe);
                    this.step6_old(DANe, value_mautin);
                }
                for (int index = 0; index < sizeOfArray_mautin; index++)
                {
                    this.showcurrent(txtMautin_toArray[index]);
                }
            }

        }

        private void step6_old(String DANe, String value_mautin)
        {
            var strDnae = new List<string>();
            //Chuyển chuỗi MDNAE thành dạng byte
            var lstbyteMDNAe = DANe.Select(this.ConvertCharToByte).ToList();

            var lstByteString = lstbyteMDNAe.Select(p => Convert.ToString(p, 2)).ToList();
            var dnaeBinaryStr = "";
            foreach (var item in lstByteString)
            {
                if (item.Length == 1)
                {
                    var tmp = "0" + item;
                    dnaeBinaryStr += tmp;
                }
                else
                    dnaeBinaryStr += item;
            }

            //Console.WriteLine("dnaeBinaryStr= " + dnaeBinaryStr);
            //Console.WriteLine("dnaeBinary size= " + dnaeBinaryStr.Length);

            //Get màu  của từng chữ trong text box
            int index = txtSimple.Text.IndexOf(value_mautin);
            string bitcolor = "";
            if (index != -1)
            {
                string myHexString = String.Format("{0:X2}{1:X2}{2:X2}", txtSimple.SelectionColor.R, txtSimple.SelectionColor.G, txtSimple.SelectionColor.B);
                bitcolor = Convert.ToString(Convert.ToInt32(myHexString, 16), 2);
                _lstcorlor.Add(txtSimple.SelectionColor);
            }
            //Chia nhỏ chuỗi chuỗi Byte các chuỗi với độ dài bằng 6
            int chunkSize = 6;
            int dnaeBinaryLength = dnaeBinaryStr.Length;
            for (var i = 0; i < dnaeBinaryLength; i+=chunkSize)
            {
                if (i + chunkSize > dnaeBinaryLength) chunkSize = dnaeBinaryLength - i;
                strDnae.Add(dnaeBinaryStr.Substring(i, chunkSize));
            }
            
            //Nhúng bit vào màu RBG
            this.nhungbit(dnaeBinaryStr, bitcolor, strDnae);
            //Dipbyte(strDnae);
            var k = 0;
            txtTextAfterConvert.Text = "";
            txtTextAfterConvert.Text = txtSimple.Text;
            lblAfter.Text = "";
            foreach (var item in _lstcorlor)
            {
                lblAfter.Items.Add(item.R + " " + item.G + " " + item.B);
                txtTextAfterConvert.Select(k, 1);
                txtTextAfterConvert.SelectionColor = item;
                k++;
            }
        }

        private void nhungbit(String dnaeBinaryStr, String bitcolor, List<string> strDnae)
        {
            //Console.WriteLine(dnaeBinaryStr + " lenght = " + dnaeBinaryStr.Length);
            //Console.WriteLine(bitcolor + " lenght = " + bitcolor.Length);
            Console.WriteLine("Nhung bit");
            foreach (var item in strDnae)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Nhung bit------------------");
            int chunkSize = 8;

            for (var i = 0; i < strDnae.Count; i++)
            {
                Console.WriteLine(strDnae[i]);
                var lstmp = new List<int>();
                string hex = "";
                for (var j = 0; j < 3; j++)
                {
                    var bi = strDnae[i].Substring(j * 2, 2);
                    String bitcolor_split = dnaeBinaryStr.Substring(j+chunkSize, chunkSize);
                    Console.WriteLine(bi);
                    Console.WriteLine("Bit color old: "+bitcolor_split);
                    String new_bin = bitcolor_split.Substring(0, bitcolor_split.Length - 2) + bi;
                    Console.WriteLine("Bit color new: " + new_bin);
                    lstmp.Add(Int32.Parse(new_bin));
                    hex += String.Concat(Regex.Matches(new_bin, "....").Cast<Match>().Select(m => Convert.ToInt32(m.Value, 2).ToString("x")));
                    
                }
                Console.WriteLine("Hex = " + hex);
                Color color = ColorTranslator.FromHtml("#"+hex);
                int r = Convert.ToInt16(color.R);
                int g = Convert.ToInt16(color.G);
                int b = Convert.ToInt16(color.B);
                Console.WriteLine(color);
                //_lstcorlor_after[i] = color;
            }
            

        }
        private void showcurrent(String value_mautin)
        {
            lblCurrent.Text = "";
            int index = txtSimple.Text.IndexOf(value_mautin);
            if (index != -1)
            {
                txtSimple.Select(index, value_mautin.Length);
                lblCurrent.Items.Add(txtSimple.SelectionColor.R + " " + txtSimple.SelectionColor.G + " " + txtSimple.SelectionColor.B);
            }
        }
        private void Dipbyte(IReadOnlyList<string> lststring)
        {
            //Vòng for một lấy màu của chữ hiện tại
            for (var i = 0; i < _lstcorlor.Count; i++)
            {
                var lstmp = new List<int>();
                //Vòng for 2 để nhúng màu vào byte RBG 
                for (var j = 0; j < 3; j++)
                {
                    var tmp = 0;
                    var bi = lststring[i].Substring(j * 2, 2);
                    var b = Convert.ToInt32(bi, 2);
                    switch (j)
                    {
                        case 0:
                            tmp = _lstcorlor[i].R & 252;
                            lstmp.Add(Convert.ToInt32((byte)tmp | b));
                            break;
                        case 1:
                            tmp = _lstcorlor[i].G & 252;
                            lstmp.Add(Convert.ToInt32((byte)tmp | b));
                            break;
                        case 2:
                            tmp = _lstcorlor[i].B & 252;
                            lstmp.Add(Convert.ToInt32((byte)tmp | b));
                            break;
                        default:
                            break;
                    }
                }
                //Gán lại màu mới vào list màu
                Console.WriteLine("Color after: "+_lstcorlor[i]);
                _lstcorlor[i] = Color.FromArgb(lstmp[0], lstmp[1], lstmp[2]);

            }
        }
        private String getDANe(String tindau, String mautin, String my, String yprimer)
        {
            int loop_yprimer = mautin.Length - 2;
            var DANe = "";
            for (int index = 1; index <= loop_yprimer; index++)
            {
                if (index == 1)
                    DANe = yprimer + my;
                else if (index == 2)
                    DANe = yprimer + my + yprimer;
                else if (index == 3)
                    DANe = yprimer + yprimer + my + yprimer;
                else if (index == 4)
                    DANe = yprimer + yprimer + my + yprimer + yprimer;

            }
            return DANe;
        }

        private IEnumerable<byte> Yprimer(double wi, double zi)
        {
            var lst = new List<byte>();
            for (double i = 1, ztest = zi; i <= 3; i++)
            {
                var sub = Math.Acos(ztest);
                ztest = Math.Cos(i * sub);
                if ((ztest > -1) && (ztest < -0.5))
                    lst.Add(3);  // G
                else if ((ztest > -0.5) && (ztest <= 0))
                    lst.Add(2); // T
                else if ((ztest > 0) && (ztest <= 0.5))
                    lst.Add(1); // A
                else if ((ztest > 0.5) && (ztest < 1))
                    lst.Add(0); // C
            }
            return lst;
        }
        private static void Xor(double zi, ref byte xi)
        {
            if ((zi > -1) && (zi <= -0.5))
                xi = 0;
            else if ((zi > -0.5) && (zi <= 0))
                xi = 1;
            else if ((zi > 0) && (zi <= 0.5))
                xi = 2;
            else if ((zi > 0.5) && (zi < 1))
                xi = 3;
        }

        private string DecodeCharacter(char a)
        {
            var firstOrDefault = _lstEncode.FirstOrDefault(p => p.Key == a);
            return firstOrDefault != null ? firstOrDefault.Value : "";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            _dialog.ShowDialog();
            txtSimple.SelectionLength = txtSimple.Text.Length;
            txtSimple.SelectionColor = _dialog.Color;
        }

        private void txtSimple_TextChanged(object sender, EventArgs e)
        {

        }
        private byte ConvertCharToByte(char a)
        {
            var ret = _lstByte.FirstOrDefault(p => p.Key == a);
            return (byte)ret.value;
            //return (byte)ret?.value ?? new byte();
        }
        private IEnumerable<char> AddByte(IEnumerable<byte> lst, byte test)
        {
            //List<byte> lsttest = new List<byte>();
            var lsttest = lst.Select(p => (byte)((byte)(p + test) & 3)).ToList();
            return this.ConvertBytetoChar(lsttest.Select(p => byte.Parse(p + "")).ToList());
        }
    }
}
