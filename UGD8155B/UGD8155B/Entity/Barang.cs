using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGD8155B.Entity
{
    class Barang
    {
        string nama, deskripsi;
        int stok, kategori, merek, bahan;
        float harga;

        public Barang(string nama, string deskripsi, int stok, float harga, int merek, int bahan, int kategori)
        {
            this.nama = nama;
            this.deskripsi = deskripsi;
            this.stok = stok;
            this.harga = harga;
            this.merek = merek;
            this.bahan = bahan;
            this.kategori = kategori;
        }

        public string Nama
        {
            get { return nama; }
            set { value = nama; }
        }

        public string Deskripsi
        {
            get { return deskripsi; }
            set { value = deskripsi; }
        }

        public int Stok
        {
            get { return stok; }
            set { value = stok; }
        }

        public float Harga
        {
            get { return harga; }
            set { value = harga; }
        }

        public int Merek
        {
            get { return merek; }
            set { value = merek; }
        }

        public int Bahan
        {
            get { return bahan; }
            set { value = bahan; }
        }

        public int Kategori
        {
            get { return kategori; }
            set { value = kategori; }
        }

    }
}
