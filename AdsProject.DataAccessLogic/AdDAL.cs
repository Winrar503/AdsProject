using System;
using AdsProject.BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AdsProject.DataAccessLogic
{
    public class AdDAL
    {
        public static async Task<int> CreateAsync(Ad ad)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Add(ad);
                await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Ad ad)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var adDb = await bdContexto.Ad.FirstOrDefaultAsync(a => a.Id == a.Id);
                if (adDb != null)
                {
                    adDb.IdCategory = ad.IdCategory;
                    adDb.Title = ad.Title;
                    adDb.Description = ad.Description;
                    adDb.Price = ad.Price;
                    adDb.RegidtrationDate = ad.RegidtrationDate;
                    adDb.State = ad.State;

                    bdContexto.Update(adDb);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

        }
        public static async Task<int> DeleteAsync(Ad ad)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var adDB = await bdContexto.Ad.FirstOrDefaultAsync(a => a.Id == a.Id);
                if (adDB != null)
                {
                    bdContexto.Ad.Remove(adDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<Ad> GetById(Ad ad)
        {
            var adBD = new Ad();
            using(var bdContexto =new ContextoBD())
            {
                adBD = await bdContexto.Ad.FirstOrDefaultAsync(ad => ad.Id == ad.Id);
            }
            return adBD;
        }public static async Task<List<Ad>> GetAllAsync()
        {
            var ads = new List<Ad>();
            using(var bdContexto = new ContextoBD())
            {
                ads = await bdContexto.Ad.ToListAsync();
            }
            return ads;
        }
        internal static IQueryable<Ad> QuerySelect(IQueryable<Ad> query, Ad ad)
        {
            if (ad.Id > 0)
                query = query.Where(a => a.Id == a.Id);
            if (ad.IdCategory > 0)
                query = query.Where(a => a.IdCategory == a.IdCategory);
            if (!string.IsNullOrWhiteSpace(ad.Title))
                query = query.Where(a => a.Title.Contains(ad.Title));
            if (!string.IsNullOrWhiteSpace(ad.Description))
                query = query.Where(a => a.Description.Contains(ad.Description));
            if (ad.Price > 0)
                query = query.Where(a => a.Price == ad.Price);
            if (ad.RegidtrationDate.Year > 1900)
            {
                DateTime initialDate = new DateTime(ad.RegidtrationDate.Year, ad.RegidtrationDate.Month, ad.RegidtrationDate.Day, 0, 0, 0);
                DateTime finalDate = initialDate.AddDays(1).AddMicroseconds(-1);
                query = query.Where(a => a.RegidtrationDate > initialDate && a.RegidtrationDate <= finalDate);
            }
            if (!string.IsNullOrWhiteSpace(ad.State))
                query = query.Where(a => a.State.Contains(ad.State));
            query = query.OrderByDescending(a => a.Id).AsQueryable();

            if (ad.Top_Aux > 0)
                query = query .Take(ad.Top_Aux).AsQueryable();
            return query;

        }
        public static async Task<List<Ad>> SearchAsync(Ad ad)
        {
            var ads  = new List<Ad>();
            using(var bdContexto= new ContextoBD())
            {
                var select = bdContexto.Ad.AsQueryable();
                select = QuerySelect(select, ad);
                ads = await select.ToListAsync();
            }
            return ads;

        }
        public static async Task<List<Ad>> SearchIncludeCludeCategoryAsync(Ad ad)
        {
            var ads = new List<Ad>();
            using(var bdContxto = new ContextoBD())
            {
                var selec  = bdContxto.Ad.AsQueryable();
                selec = QuerySelect(selec, ad).Include(a => a.Category).AsQueryable();
                ads = await selec.ToListAsync();
            }
            return ads;
        }
    }
}
