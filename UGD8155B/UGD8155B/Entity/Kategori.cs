using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGD8155B.Entity
{
    class Kategori
    {
        string nama, deskripsi;

        public Kategori(string nama, string deskripsi)
        {
            this.nama = nama;
            this.deskripsi = deskripsi;
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
    }
}
