using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Books");
            Department d4 = new Department(4, "Softwares");
            Department d5 = new Department(5, "Games");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1990, 5, 16), 1500.00, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1982, 1, 1), 1500.00, d2);
            Seller s3 = new Seller(3, "Alex Gray", "alex@gmail.com", new DateTime(2000, 12, 15), 1500.00, d3);
            Seller s4 = new Seller(4, "David Ficher", "david@gmail.com", new DateTime(1996, 3, 29), 1500.00, d4);
            Seller s5 = new Seller(5, "Ana Silva", "ana@gmail.com", new DateTime(1987, 9, 22), 1500.00, d5);
            Seller s6 = new Seller(6, "Robert Jhon", "jhon@gmail.com", new DateTime(1993, 2, 7), 1500.00, d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2020, 01, 1), 2000.00, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2020, 02, 1), 1600.00, SaleStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2020, 03, 1), 1450.00, SaleStatus.Canceled, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2020, 04, 1), 5590.99, SaleStatus.Pending, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2020, 05, 1), 8800.50, SaleStatus.Canceled, s5);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2020, 06, 1), 880.00, SaleStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4, d5);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6);

            _context.SaveChanges();
        }
    }
}
