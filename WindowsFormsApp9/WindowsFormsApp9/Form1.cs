using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        List<char> sifra = new List<char>();
        DispatcherTimer timer1 = new DispatcherTimer();


        private String dekodiraj()
        {
            String zaReturn = "";
            foreach(char c in sifra)
            {
                zaReturn += c;
            }
            return zaReturn;
        }
        
        private bool provjeri()
        {
            if (sifra[0] == 'x' && sifra[1] == 'x' && sifra[2] == 'x')
            {
                return true;
            }

            if (sifra[3] == 'x' && sifra[4] == 'x' && sifra[5] == 'x')
            {
                return true;
            }

            if (sifra[6] == 'x' && sifra[7] == 'x' && sifra[8] == 'x')
            {
                return true;
            }

            if (sifra[0] == 'x' && sifra[3] == 'x' && sifra[6] == 'x')
            {
                return true;
            }

            if (sifra[1] == 'x' && sifra[4] == 'x' && sifra[7] == 'x')
            {
                return true;
            }

            if (sifra[2] == 'x' && sifra[5] == 'x' && sifra[8] == 'x')
            {
                return true;
            }

            if (sifra[0] == 'x' && sifra[4] == 'x' && sifra[8] == 'x')
            {
                return true;
            }

            if (sifra[2] == 'x' && sifra[4] == 'x' && sifra[6] == 'x')
            {
                return true;
            }














            if (sifra[0] == 'o' && sifra[1] == 'o' && sifra[2] == 'o')
            {
                return true;
            }

            if (sifra[3] == 'o' && sifra[4] == 'o' && sifra[5] == 'o')
            {
                return true;
            }

            if (sifra[6] == 'o' && sifra[7] == 'o' && sifra[8] == 'o')
            {
                return true;
            }

            if (sifra[0] == 'o' && sifra[3] == 'o' && sifra[6] == 'o')
            {
                return true;
            }

            if (sifra[1] == 'o' && sifra[4] == 'o' && sifra[7] == 'o')
            {
                return true;
            }

            if (sifra[2] == 'o' && sifra[5] == 'o' && sifra[8] == 'o')
            {
                return true;
            }

            if (sifra[0] == 'o' && sifra[4] == 'o' && sifra[8] == 'o')
            {
                return true;
            }

            if (sifra[2] == 'o' && sifra[4] == 'o' && sifra[6] == 'o')
            {
                return true;
            }

            return false;


        }

        private void kodiraj(String poruka)
        {
            for(int i = 0; i<poruka.Length; i++)
            {
                sifra[i] = poruka[i];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('0');
            sifra.Add('x');
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
            timer1.Interval = TimeSpan.FromSeconds(0.1);

            // funkcija koja će se pozvati nakon što prođe zadani vremenski interval
            timer1.Tick += new EventHandler(timerFunkc);
            timer1.Start();

        }

        void timerFunkc(object sender, EventArgs e)
        {

            promjeni(0, button3);
            promjeni(1, button4);
            promjeni(2, button5);
            promjeni(3, button6);
            promjeni(4, button7);
            promjeni(5, button8);
            promjeni(6, button9);
            promjeni(7, button10);
            promjeni(8, button11);
            Console.WriteLine("Resi");
        }


        private void promjeni(int sifraB, Button b)
        {
            if (sifra[sifraB] == 'x')
            {
                b.Text = "X";
            }
            else if (sifra[sifraB] == 'o')
            {
                b.Text = "O";
            }
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            textBox3.Invoke((MethodInvoker)delegate ()
            {
                textBox3.Text = e.MessageString;
            });

            kodiraj(e.MessageString);

            if (provjeri())
            {
                timer1.Stop();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            client.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Write(textBox3.Text);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sifra[0] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button3.Text = "X";
                    sifra[0] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button3.Text = "O";
                    sifra[0] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sifra[1] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button4.Text = "X";
                    sifra[1] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button4.Text = "O";
                    sifra[1] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());

            if (sifra[0] == 'x')
            {
                button3.Text = "X";
            }
            else if (sifra[0] == 'o')
            {
                button3.Text = "O";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (sifra[2] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button5.Text = "X";
                    sifra[2] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button5.Text = "O";
                    sifra[2] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (sifra[3] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button6.Text = "X";
                    sifra[3] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button6.Text = "O";
                    sifra[3] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sifra[4] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button7.Text = "X";
                    sifra[4] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button7.Text = "O";
                    sifra[4] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (sifra[5] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button8.Text = "X";
                    sifra[5] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button8.Text = "O";
                    sifra[5] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sifra[6] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button9.Text = "X";
                    sifra[6] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button9.Text = "O";
                    sifra[6] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (sifra[7] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button10.Text = "X";
                    sifra[7] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button10.Text = "O";
                    sifra[7] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (sifra[8] == '0')
            {
                if (sifra[9] == 'x')
                {
                    button11.Text = "X";
                    sifra[8] = 'x';
                    sifra[9] = 'o';
                }
                else
                {
                    button11.Text = "O";
                    sifra[8] = 'o';
                    sifra[9] = 'x';
                }
            }
            else
            {
                Console.WriteLine("Resi");
            }
            client.Write(dekodiraj());
        }
    }
}
