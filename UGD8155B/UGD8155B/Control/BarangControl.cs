using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGD8155B.dsPecahBelahTableAdapters;
using System.Data;
using UGD8155B.Entity;

namespace UGD8155B.Control
{
    class BarangControl
    {
        private tbl_barangTableAdapter TB = new tbl_barangTableAdapter();
        private tbl_bahanTableAdapter TH = new tbl_bahanTableAdapter();
        private tbl_kategoriTableAdapter TK = new tbl_kategoriTableAdapter();
        private tbl_merekTableAdapter TM = new tbl_merekTableAdapter();

        public DataTable showBarang()
        {
            return TB.GetData();
        }

        public DataTable searchBarang(string Keyword)
        {
            return TB.GetDataBy(Keyword);
        }

        public void addBarang(Barang B)
        {
            TB.InsertBarang(B.Nama, B.Deskripsi, B.Stok, B.Harga, B.Merek, B.Bahan, B.Kategori);
        }

        public DataTable getKategori()
        {
            return TK.GetData();
        }

        public DataTable getBahan()
        {
            return TH.GetData();
        }

        public DataTable getMerek()
        {
            return TM.GetData();
        }

        public int getIDKategori(string kategori)
        {
            return int.Parse(TK.GetIdKategori(kategori).ToString());
        }

        public int getIDBahan(string bahan)
        {
            return int.Parse(TH.GetIdBahan(bahan).ToString());
        }

        public int getIDMerek(string merek)
        {
            return int.Parse(TM.GetIdMerek(merek).ToString());
        }

        public void editBarang(Barang B, int idbarang)
        {
            TB.UpdateBarang(B.Nama, B.Stok, B.Harga, B.Kategori, B.Merek, B.Bahan, idbarang);
        }

        public void deleteBarang(int idbarang)
        {
            TB.DeleteBarang(idbarang);
        }
    }
}
