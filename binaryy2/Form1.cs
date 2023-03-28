
using System.Text;

namespace binaryy2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox1.Clear();
            FileStream DataFlow = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter WriteB= new BinaryWriter(DataFlow);
            BinaryReader ReadB = new BinaryReader(DataFlow);
            StreamReader ReadTxT = new StreamReader("sport.txt", Encoding.GetEncoding("UTF-8"));

            while (!ReadTxT.EndOfStream)
            {
                string line = ReadTxT.ReadLine();
                string[] items = line.Split(';');
                for(int i = 0; i < items.Length; i++)
                {
                    if(i == 0 || i==4 || i==5)
                    {
                        WriteB.Write(Convert.ToInt32(items[i]));
                    }
                    else if(i==3)
                    {
                        WriteB.Write(Convert.ToChar(items[i]));
                    }
                    else
                    {
                        WriteB.Write(items[i]);
                    }
                }
                Array.Clear(items, 0, items.Length);
            }

                ReadB.BaseStream.Position = 0;
                while (ReadB.BaseStream.Length > ReadB.BaseStream.Position)
                {
                    string linetextbox = "" + ReadB.ReadInt32() + ";" + ReadB.ReadString() + ";"+ ReadB.ReadString() + 
                                                                                    ";"
                                            + ReadB.ReadChar() + ";"+ ReadB.ReadInt32() + ";"+ ReadB.ReadInt32()+"\r\n";
                    textBox1.AppendText(linetextbox + Environment.NewLine);
                }
                
            
            ReadB.Close();
            WriteB.Close();
            ReadTxT.Close();
            DataFlow.Close();
        }
    }
}