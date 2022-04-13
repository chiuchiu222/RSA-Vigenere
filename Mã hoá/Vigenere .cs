
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
    public partial class Vigenere : Form
    {
        public Vigenere()
        {
            InitializeComponent();
        }
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

		private static string Cipher(string input, string key, bool encipher)
		{
			for (int i = 0; i < key.Length; ++i)
				if (!char.IsLetter(key[i]))
					return null; // Error

			string output = string.Empty;
			int nonAlphaCharCount = 0;

			for (int i = 0; i < input.Length; ++i)
			{
				if (char.IsLetter(input[i]))
				{
					bool cIsUpper = char.IsUpper(input[i]);
					char offset = cIsUpper ? 'A' : 'a';
					int keyIndex = (i - nonAlphaCharCount) % key.Length;
					int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
					k = encipher ? k : -k;
					char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
					output += ch;
				}
				else
				{
					output += input[i];
					++nonAlphaCharCount;
				}
			}

			return output;
		}

		public static string Encipher(string input, string key)
		{
			return Cipher(input, key, true);
		}

		public static string Decipher(string input, string key)
		{
			return Cipher(input, key, false);
		}

		private void btnMaHoa_Click(object sender, EventArgs e)
        {
			string key = txtKey.Text;
			string text = txtText.Text;
			string cipherText = Encipher(text, key);
			txtCipher.Text = cipherText;
		}

        private void btnDecipher_Click(object sender, EventArgs e)
        {
			string pass = txtPass.Text;
			string text = txtVanBanMaHoa.Text;
			string plainText = Decipher(text, pass);
			txtVanBanGoc.Text = plainText;
		}
	}
}
