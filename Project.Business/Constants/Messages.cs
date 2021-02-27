using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Constants
{
    public static class Messages
    {
        #region Success Messages
        public static string SuccessAdded = "Ekleme Basarili.";
        public static string SuccessUpdated = "Guncelleme Basarili.";
        public static string SuccessDeleted = "Silme basarili.";
        public static string SuccessListed = "Listeleme Basarili.";
        #endregion
        #region Error Messages
        public static string NameInvalidError = "Girilen Ad Gecersiz.";
        public static string MaintenanceTimeError = "Sistem bakimdadir.";
        public static string ErrorAdded = "Ekleme Basarisiz.";
        public static string ErrorUpdated = "Guncelleme Basarisiz.";
        public static string ErrorDeleted = "Silme basarisiz.";
        public static string ErrorListed = "Listeleme Basarisiz.";

        public static string CarImageLimitExceded = "Fotograf ekleme limit asimi";
        #endregion
    }
}
