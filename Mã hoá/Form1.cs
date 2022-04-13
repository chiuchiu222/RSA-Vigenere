using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mã_hoá
{
    public partial class MaHoa : Form
    {
        public MaHoa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vigenere = new Vigenere();
            vigenere.Show();
        }
    }
}
