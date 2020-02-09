using System;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using IProjenFramework.Core.Utilities.Cryptology;

namespace Cryptographer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtEnc1.Text = Cryptology.Encrypt(txtClear1.Text.Trim());
            }
            catch (Exception ex)
            {

                txtEnc1.Text = "Hata :" + ex.Message;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtClear2.Text = Cryptology.Decrypt(txtEnc2.Text.Trim());
            }
            catch (Exception ex)
            {

                txtClear2.Text = "Hata :" + ex.Message;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int len = Convert.ToInt32(txtKeySize.Text);
            byte[] buff = new byte[len / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buff);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < buff.Length; i++)
                sb.Append(string.Format("{0:X2}", buff[i]));
            txtKey.Text = sb.ToString();
        }
    }
}
