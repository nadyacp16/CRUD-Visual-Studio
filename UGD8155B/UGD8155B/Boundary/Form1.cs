using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UGD8155B.Control;

namespace UGD8155B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BarangControl BC = new BarangControl();

        public void setDatagridview(DataGridView DG)
        {
            DG.DataSource = BC.showBarang();

            DG.Columns[0].HeaderText = "ID BARANG";
            DG.Columns[1].HeaderText = "NAMA BARANG";
            DG.Columns[2].HeaderText = "STOK";
            DG.Columns[3].HeaderText = "HARGA";
            DG.Columns[4].HeaderText = "KATEGORI";
            DG.Columns[5].HeaderText = "BAHAN";
            DG.Columns[6].HeaderText = "MEREK";

            DG.Columns[0].Width = 55;
            DG.Columns[1].Width = 150;
            DG.Columns[2].Width = 50;
            DG.Columns[3].Width = 70;
            DG.Columns[4].Width = 80;
            DG.Columns[5].Width = 80;
            DG.Columns[6].Width = 80;

        }

        public void searchDatagridview(DataGridView DG, string keyword)
        {
            DG.DataSource = BC.searchBarang(keyword);

            DG.Columns[0].HeaderText = "ID BARANG";
            DG.Columns[1].HeaderText = "NAMA BARANG";
            DG.Columns[2].HeaderText = "STOK";
            DG.Columns[3].HeaderText = "HARGA";
            DG.Columns[4].HeaderText = "KATEGORI";
            DG.Columns[5].HeaderText = "BAHAN";
            DG.Columns[6].HeaderText = "MEREK";

            DG.Columns[0].Width = 55;
            DG.Columns[1].Width = 150;
            DG.Columns[2].Width = 50;
            DG.Columns[3].Width = 70;
            DG.Columns[4].Width = 80;
            DG.Columns[5].Width = 80;
            DG.Columns[6].Width = 80;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setDatagridview(this.dataGridView1);
            uC_BARANG1.Visible = false;
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            searchDatagridview(dataGridView1, txtCari.Text);
        }

        private void disable()
        {
            txtCari.Enabled = false;
            dataGridView1.Enabled = false;
            btnTambah.Enabled = false;
            btnUbah.Enabled = false;
            btnHapus.Enabled = false;
            btnBatal.Enabled = false;
        }

        public void enable()
        {
            txtCari.Enabled = true;
            dataGridView1.Enabled = true;
            btnTambah.Enabled = true;
            btnUbah.Enabled = true;
            btnHapus.Enabled = true;
            btnBatal.Enabled = true;

            setDatagridview(this.dataGridView1);
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                txtID.Text = getKolom(dataGridView1,0);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            uC_BARANG1.setFlag(1);
            uC_BARANG1.Visible = true;
            disable();
        }

        private string getKolom(DataGridView dg, int i)
        {
            return dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
        }

        private string getKolomEdit(DataGridView dg, int i)
        {
            return dg[dg.Columns[0].Index,dg.Rows[i].Index].Value.ToString();
        }

        private string getRow(DataGridView dg)
        {
            return dg.CurrentRow.Index.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1,0);
            txtRow.Text = getRow(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1,0);
            txtRow.Text = getRow(dataGridView1);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
        }

        public void EnableEdit()
        {
            txtCari.Enabled = true;
            dataGridView1.Enabled = true;
            btnTambah.Enabled = true;
            btnUbah.Enabled = true;
            btnHapus.Enabled = true;
            btnBatal.Enabled = true;

            setDatagridview(this.dataGridView1);
            dataGridView1.Rows[int.Parse(txtRow.Text)].Selected=true;
            txtID.Text = getKolomEdit(dataGridView1,int.Parse(txtRow.Text));
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Silahkan pilih data yang hendak diubah");
                dataGridView1.Focus();
            }
            else
            {
                uC_BARANG1.setFlag(2);

                string nama=getKolom(dataGridView1,1);
                string stok = getKolom(dataGridView1, 2);
                string harga = getKolom(dataGridView1, 3);
                string kategori=getKolom(dataGridView1,4);
                string bahan=getKolom(dataGridView1,5);
                string merek=getKolom(dataGridView1,6);

                uC_BARANG1.isiTextBox(nama, stok, harga, kategori, merek, bahan, txtID.Text);
                uC_BARANG1.Visible = true;
                txtID.Clear();
                disable();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Silahkan pilih data yang hendak dihapus");
                dataGridView1.Focus();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Apakah anda yakin ingin menghapus data menu? " + getKolom(dataGridView1,1), "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    BC.deleteBarang(int.Parse(txtID.Text));
                }
                txtID.Clear();
                this.enable();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.enable();
        }
    }
}
