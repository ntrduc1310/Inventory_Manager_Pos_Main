using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Invoice;
using System.Windows.Forms;
using BL.Invoice;
using QRCoder;

namespace PL.View
{
    public partial class QR_Payment : Form
    {
        private readonly InvoiceClass Invoice;
        private readonly InvoiceBL invoiceBL;

        public QR_Payment(InvoiceClass invoice)
        {
            InitializeComponent();
            Invoice = invoice;
            invoiceBL = new InvoiceBL();
            this.Load += QR_Payment_Load;
        }

        private void QR_Payment_Load(object sender, EventArgs e)
        {
            SetupQRCode();
            SetupUI();
        }

        private void SetupQRCode()
        {
            string qrData = invoiceBL.GenerateQRCodeData(Invoice);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                pictureBox_QR.Image = qrCode.GetGraphic(20);
                pictureBox_QR.SizeMode = PictureBoxSizeMode.Zoom; // Đảm bảo co dãn đúng
                pictureBox_QR.Width = 300; // Cài đặt chiều rộng lớn hơn
                pictureBox_QR.Height = 300; // Cài đặt chiều cao lớn hơn

            }
        }

        private void SetupUI()
        {
            lbl_Amount.Text = $"Số tiền: {Invoice.TotalAmount:N0} VNĐ";
            lbl_InvoiceId.Text = $"Mã hóa đơn: {Invoice.InvoiceID}";
            lbl_Amount.Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Regular);
            lbl_InvoiceId.Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Regular);
        }

        private async void btn_Verify_Click_1(object sender, EventArgs e)
        {
            try
            {
                btn_Verify.Enabled = false;
                await Task.Delay(2000); // Simulate verification
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_Verify.Enabled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
