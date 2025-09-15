using Microsoft.EntityFrameworkCore;
using PHMIS.Domain.Entities;

namespace PHMIS.Infrastructure.DatabaseSeeders
{
    public static class ProvinceSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            // Seed a selection of Afghanistan provinces with PublicId and names
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, Name = "Kabul", PublicId = "11111111-1111-1111-1111-111111111111", IsPublic = true, HospitalId = 0 },
                new Province { Id = 2, Name = "Kandahar", PublicId = "22222222-2222-2222-2222-222222222222", IsPublic = true, HospitalId = 0 },
                new Province { Id = 3, Name = "Herat", PublicId = "33333333-3333-3333-3333-333333333333", IsPublic = true, HospitalId = 0 },
                new Province { Id = 4, Name = "Nangarhar", PublicId = "44444444-4444-4444-4444-444444444444", IsPublic = true, HospitalId = 0 },
                new Province { Id = 5, Name = "Balkh", PublicId = "55555555-5555-5555-5555-555555555555", IsPublic = true, HospitalId = 0 },
                new Province { Id = 6, Name = "Ghazni", PublicId = "66666666-6666-6666-6666-666666666666", IsPublic = true, HospitalId = 0 },
                new Province { Id = 7, Name = "Kunduz", PublicId = "77777777-7777-7777-7777-777777777777", IsPublic = true, HospitalId = 0 }
            );

            // Seed translations (English as default, plus Dari (fa) and Pashto (ps) where available)
            modelBuilder.Entity<ProvinceTranslation>().HasData(
                // Kabul
                new ProvinceTranslation { Id = 1, ProvinceId = 1, LanguageCode = "en", IsDefault = true, Name = "Kabul" },
                new ProvinceTranslation { Id = 2, ProvinceId = 1, LanguageCode = "fa", IsDefault = false, Name = "????" },
                new ProvinceTranslation { Id = 3, ProvinceId = 1, LanguageCode = "ps", IsDefault = false, Name = "????" },

                // Kandahar
                new ProvinceTranslation { Id = 4, ProvinceId = 2, LanguageCode = "en", IsDefault = true, Name = "Kandahar" },
                new ProvinceTranslation { Id = 5, ProvinceId = 2, LanguageCode = "fa", IsDefault = false, Name = "??????" },
                new ProvinceTranslation { Id = 6, ProvinceId = 2, LanguageCode = "ps", IsDefault = false, Name = "??????" },

                // Herat
                new ProvinceTranslation { Id = 7, ProvinceId = 3, LanguageCode = "en", IsDefault = true, Name = "Herat" },
                new ProvinceTranslation { Id = 8, ProvinceId = 3, LanguageCode = "fa", IsDefault = false, Name = "????" },
                new ProvinceTranslation { Id = 9, ProvinceId = 3, LanguageCode = "ps", IsDefault = false, Name = "????" },

                // Nangarhar
                new ProvinceTranslation { Id = 10, ProvinceId = 4, LanguageCode = "en", IsDefault = true, Name = "Nangarhar" },
                new ProvinceTranslation { Id = 11, ProvinceId = 4, LanguageCode = "fa", IsDefault = false, Name = "???????" },
                new ProvinceTranslation { Id = 12, ProvinceId = 4, LanguageCode = "ps", IsDefault = false, Name = "???????" },

                // Balkh
                new ProvinceTranslation { Id = 13, ProvinceId = 5, LanguageCode = "en", IsDefault = true, Name = "Balkh" },
                new ProvinceTranslation { Id = 14, ProvinceId = 5, LanguageCode = "fa", IsDefault = false, Name = "???" },
                new ProvinceTranslation { Id = 15, ProvinceId = 5, LanguageCode = "ps", IsDefault = false, Name = "???" },

                // Ghazni
                new ProvinceTranslation { Id = 16, ProvinceId = 6, LanguageCode = "en", IsDefault = true, Name = "Ghazni" },
                new ProvinceTranslation { Id = 17, ProvinceId = 6, LanguageCode = "fa", IsDefault = false, Name = "????" },
                new ProvinceTranslation { Id = 18, ProvinceId = 6, LanguageCode = "ps", IsDefault = false, Name = "????" },

                // Kunduz
                new ProvinceTranslation { Id = 19, ProvinceId = 7, LanguageCode = "en", IsDefault = true, Name = "Kunduz" },
                new ProvinceTranslation { Id = 20, ProvinceId = 7, LanguageCode = "fa", IsDefault = false, Name = "?????" },
                new ProvinceTranslation { Id = 21, ProvinceId = 7, LanguageCode = "ps", IsDefault = false, Name = "?????" }
            );
        }
    }
}
