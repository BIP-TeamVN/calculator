using System;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
         txtSo1.TextChanged += txtTextChanged;
         txtSo2.TextChanged += txtTextChanged;
         txtKq.TextChanged += txtTextChanged;
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         txtSo1.Text = txtSo2.Text = "0";
         radCong.Checked = true;             //đầu tiên chọn phép cộng
      }

      private void btnThoat_Click(object sender, EventArgs e)
      {
         DialogResult dr;
         dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                              "Thông báo", MessageBoxButtons.YesNo);
         if (dr == DialogResult.Yes)
            this.Close();
      }

      private void btnTinh_Click(object sender, EventArgs e)
      {

         //lấy giá trị của 2 ô số
         double so1, so2, kq = 0;
         so1 = double.Parse(txtSo1.Text);
         so2 = double.Parse(txtSo2.Text);
         //Thực hiện phép tính dựa vào phép toán được chọn
         if (radCong.Checked) kq = so1 + so2;
         else if (radTru.Checked) kq = so1 - so2;
         else if (radNhan.Checked) kq = so1 * so2;
         else if (radChia.Checked)
         {
            if (so2 == 0)
            {
               MessageBox.Show("Số chia phải khác 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               txtSo2.Focus();
               return;
            }
            kq = so1 / so2;
         }
         //Hiển thị kết quả lên trên ô kết quả

         BigInteger big = new BigInteger(kq);

         txtKq.Text = big.ToString();
         if (kq - Math.Truncate(kq) > 0)
         {
            txtKq.Text += "." + (kq - Math.Truncate(kq)).ToString().Replace("0.", "");
         }
      }

      private void txtSo1_Leave(object sender, EventArgs e)
      {
         if ("".Equals(txtSo1.Text) || txtSo1.Text == null)
         {
            MessageBox.Show("Chưa nhập dữ liệu ô thứ nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSo1.Focus();
         }
         else if (!validateInput(txtSo1.Text.ToString()))
         {
            MessageBox.Show("Dữ liệu nhập vào ô thứ nhất không phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSo1.Focus();
         }
      }

      private void txtSo2_Leave(object sender, EventArgs e)
      {
         if ("".Equals(txtSo2.Text) || txtSo2.Text == null)
         {
            MessageBox.Show("Chưa nhập dữ liệu ô thứ hai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSo2.Focus();
         }
         else if (!validateInput(txtSo2.Text.ToString()))
         {
            MessageBox.Show("Dữ liệu nhập vào ô thứ 2 không phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSo2.Focus();
         }
      }

      private bool validateInput(string str)
      {
         Regex regex = new Regex(@"^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$");
         if (regex.IsMatch(str))
         {
            return true;
         }
         return false;
      }

      private void onClick(object sender, EventArgs e)
      {
         var textBox = (TextBox)sender;
         textBox.SelectAll();
         textBox.Focus();
      }

      private void txtTextChanged(object sender, EventArgs e)
      {
         var txt = sender as TextBox;
         if (txt.Text.Length < 20)
         {
            txt.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         }
         else if (txt.Text.Length < 30)
         {
            txt.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         }
         else
         {
            txt.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         }
      }
   }
}
