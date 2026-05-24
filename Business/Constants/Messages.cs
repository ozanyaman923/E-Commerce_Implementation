using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //Newlenmesine gerek yok sadece tek seferlik.
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";

        public static string NameAlreadyHave ="sisteme ürün zaten ekli";

        public static string ProductRemoved ="ürün silindi" ;

        public static string ProductCountOfCategoryError ="Kategoriye ait ürün sayısı 10'u geçemez";
    }
}
