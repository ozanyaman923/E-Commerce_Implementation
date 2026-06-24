using Core.Entities.Concrete;
using Entities.DTOs;
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

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string PasswordCannotBeEmpty = "Parola boş olamaz";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Erişim tokenı oluşturuldu";

      
    }
}
