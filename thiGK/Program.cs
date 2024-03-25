using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thiGK
{

    class TaiLieu_334
    {
        public string MaXB { get; set; }
        public string TenTL { get; set; }
        public string NhaPhatHanh { get; set; }
    }

    class DanhMuc_334
    {
        public int ID { get; set; }
        public string CateName { get; set; }
    }

    class Sach_334 : TaiLieu_334
    {
        public string TenTG { get; set; }
        public int SoTrang { get; set; }
    }

    class TapChi_334 : TaiLieu_334
    {
        public int SoPhatHanh { get; set; }
        public int TrangPhatHanh { get; set; }
    }

    class Bao_334 : TaiLieu_334
    {
        public DateTime NgayPhatHanh { get; set; }
    }

    class Program
    {
        static List<TaiLieu_334> danhSachTaiLieu = new List<TaiLieu_334>();

        static void ThemTaiLieu(TaiLieu_334 taiLieu)
        {
            danhSachTaiLieu.Add(taiLieu);
        }

        static List<TaiLieu_334> TimTheoLoai<T>(List<TaiLieu_334> danhSach, Type type)
        {
            List<TaiLieu_334> ketQua = new List<TaiLieu_334>();

            foreach (var taiLieu in danhSach)
            {
                if (taiLieu.GetType() == type)
                {
                    ketQua.Add(taiLieu);
                }
            }

            return ketQua;
        }

        static List<Bao_334> TimBaoTheoThangNam(List<Bao_334> danhSachBao, int thang, int nam)
        {
            List<Bao_334> ketQua = new List<Bao_334>();

            foreach (var bao in danhSachBao)
            {
                if (bao.NgayPhatHanh.Month == thang && bao.NgayPhatHanh.Year == nam)
                {
                    ketQua.Add(bao);
                }
            }

            return ketQua;
        }

        static void Main(string[] args)
        {
            // Thêm các tài liệu mới vào danh sách
            ThemTaiLieu(new Sach_334 { MaXB = "S1", TenTL = "Sach 1", NhaPhatHanh = "Nha Xuat Ban A", TenTG = "Tac Gia 1", SoTrang = 100 });
            ThemTaiLieu(new TapChi_334 { MaXB = "TC1", TenTL = "Tap chi 1", NhaPhatHanh = "Nha Xuat Ban B", SoPhatHanh = 1, TrangPhatHanh = 50 });
            ThemTaiLieu(new Bao_334 { MaXB = "B1", TenTL = "Bao 1", NhaPhatHanh = "Nha Xuat Ban C", NgayPhatHanh = new DateTime(2024, 3, 15) });
            ThemTaiLieu(new Bao_334 { MaXB = "B2", TenTL = "Bao 2", NhaPhatHanh = "Nha Xuat Ban D", NgayPhatHanh = new DateTime(2024, 4, 1) });

            // Tìm theo loại tài liệu
            List<TaiLieu_334> sachList = TimTheoLoai<Sach_334>(danhSachTaiLieu, typeof(Sach_334));
            List<TaiLieu_334> tapChiList = TimTheoLoai<TapChi_334>(danhSachTaiLieu, typeof(TapChi_334));
            List<TaiLieu_334> baoList = TimTheoLoai<Bao_334>(danhSachTaiLieu, typeof(Bao_334));

            // Tìm báo có ngày phát hành trong tháng 3/2024
            List<Bao_334> baoThang3List = TimBaoTheoThangNam(baoList.ConvertAll(x => (Bao_334)x), 3, 2024);

            Console.WriteLine("Danh sach sach:");
            foreach (var sach in sachList)
            {
                Console.WriteLine($"{sach.MaXB} - {sach.TenTL}");
            }

            Console.WriteLine("\nDanh sach tap chi:");
            foreach (var tapChi in tapChiList)
            {
                Console.WriteLine($"{tapChi.MaXB} - {tapChi.TenTL}");
            }

            Console.WriteLine("\nDanh sach bao:");
            foreach (var bao in baoList)
            {
                Console.WriteLine($"{bao.MaXB} - {bao.TenTL}");
            }

            Console.WriteLine("\nDanh sach bao phat hanh trong thang 3/2024:");
            foreach (var baoThang3 in baoThang3List)
            {
                Console.WriteLine($"{baoThang3.MaXB} - {baoThang3.TenTL} - Ngay phat hanh: {baoThang3.NgayPhatHanh.ToShortDateString()}");
            }
            Console.ReadLine();
        }
    }

}
