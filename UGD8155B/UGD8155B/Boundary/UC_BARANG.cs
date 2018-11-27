using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UGD8155B.Control;
using UGD8155B.Entity;

namespace UGD8155B
{
    public partial class UC_BARANG : UserControl
    {
        public UC_BARANG()
        {
            InitializeComponent();
        }

        private BarangControl BC = new BarangControl();

        private void UC_BARANG_Load(object sender, EventArgs e)
        {
            cmbKategori.DataSource = BC.getKategori();
            cmbKategori.DisplayMember = "nama_kategori";

            cmbMerek.DataSource = BC.getMerek();
            cmbMerek.DisplayMember = "nama_merek";

            cmbBahan.DataSource = BC.getBahan();
            cmbBahan.DisplayMember = "nama_bahan";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        int flagperintah = 0;
        public void setFlag(int flag)
        {
            flagperintah = flag;
        }

        private bool cektxt()
        {
            bool temp = true;

            if (txtNama.Text == "")
            {
                errorProvider1.SetError(txtNama, "Silahkan isi nama barang");
                txtNama.Focus();
                temp = false;
            }
            /*if (txtDeskripsi.Text == "")
            {
                errorProvider1.SetError(txtDeskripsi, "Silahkan isi deskripsi barang");
                txtDeskripsi.Focus();
                temp = false;
            }*/
            if (txtHarga.Text == "")
            {
                errorProvider1.SetError(txtHarga, "Silahkan isi harga barang");
                txtHarga.Focus();
                temp = false;
            }
            if (txtStok.Text == "")
            {
                errorProvider1.SetError(txtStok, "Silahkan isi stok barang");
                txtStok.Focus();
                temp = false;
            }
            if (cmbKategori.Text == "")
            {
                errorProvider1.SetError(cmbKategori, "Silahkan pilih kategori barang");
                cmbKategori.Focus();
                temp = false;
            }
            if (cmbBahan.Text == "")
            {
                errorProvider1.SetError(cmbBahan, "Silahkan pilih bahan");
                cmbBahan.Focus();
                temp = false;
            }
            if (cmbMerek.Text == "")
            {
                errorProvider1.SetError(cmbMerek, "Silahkan pilih merek barang");
                cmbMerek.Focus();
                temp = false;
            }
            return temp;
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void cleartxt()
        {
            txtNama.Clear();
            txtHarga.Clear();
            txtDeskripsi.Clear();
            txtStok.Clear();
            cmbKategori.SelectedIndex = -1;
            cmbBahan.SelectedIndex = -1;
            cmbMerek.SelectedIndex = -1;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (flagperintah == 1)
            {
                if (cektxt() == true)
                {
                    errorProvider1.Clear();

                    int IDKategori = BC.getIDKategori(cmbKategori.Text);
                    int IDBahan = BC.getIDBahan(cmbBahan.Text);
                    int IDMerek = BC.getIDMerek(cmbMerek.Text);

                    UGD8155B.Entity.Barang B = new Entity.Barang(txtNama.Text, txtDeskripsi.Text, int.Parse(txtStok.Text), float.Parse(txtHarga.Text), IDMerek, IDBahan, IDKategori);
                    if (float.Parse(txtHarga.Text) < 50000 || float.Parse(txtHarga.Text) > 5000000)
                    {
                        MessageBox.Show("Harga tidak boleh kurang dari 50000 dan lebih dari 5000000", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        BC.addBarang(B);
                        cleartxt();
                        this.Hide();
                        Form1 myParent = (Form1)this.Parent;
                        myParent.enable();
                    }
                }
            }
            else
            {
                if (cektxt() == true)
                {
                    errorProvider1.Clear();

                    int IDKategori = BC.getIDKategori(cmbKategori.Text);
                    int IDBahan = BC.getIDBahan(cmbBahan.Text);
                    int IDMerek = BC.getIDMerek(cmbMerek.Text);

                    Barang B = new Barang(txtNama.Text, txtDeskripsi.Text, int.Parse(txtStok.Text), float.Parse(txtHarga.Text), IDMerek, IDBahan, IDKategori);
                    if (float.Parse(txtHarga.Text) < 50000 || float.Parse(txtHarga.Text) > 5000000)
                    {
                        MessageBox.Show("Harga tidak boleh kurang dari 50000 dan lebih dari 5000000","Peringatan",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Apakah anda yakin ingin mengupdate menu? " + temp_barang, "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            BC.editBarang(B, int.Parse(txtID.Text));
                        }
                        cleartxt();
                        this.Hide();
                        Form1 myParent = (Form1)this.Parent;
                        myParent.EnableEdit();
                    }
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            cleartxt();
            errorProvider1.Clear();
            this.Hide();
            Form1 myParent = (Form1)this.Parent;
            myParent.enable();
        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        string temp_barang = "";
        public void isiTextBox(string nama, string stok, string harga, string kategori, string merek, string bahan, string id)
        {
            txtNama.Text = nama;
            temp_barang = nama;
            txtStok.Text = stok;
            txtHarga.Text = harga;
            cmbKategori.Text = kategori;
            cmbMerek.Text = merek;
            cmbBahan.Text = bahan;
            txtID.Text = id;
        }
    }
}
