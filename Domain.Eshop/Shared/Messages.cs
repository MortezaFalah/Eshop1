using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Shared
{
    public class SuccessMessages
    {

        public static string SuccessRegister = "ثبت شما با موفقیت انجام شد";
        
        public static string SuccessEditProfile = "ویرایش حساب کاربری شما با موفقیت انجام شد";

        public static string SuccessLogin = "ورود شما با موفقیت انجام شد";

        public static string ForgotpasswordSuccessfulydone = "کد تایید برای شما ارسال شد";

        public static string ResetpasswordSuccessfulydone = "بازیابی کلمه عبور با موفقیت انجام شد";
    }

    public class ErrorMessages
    {
        #region Register
        public static string OperationFeild = "عملیات با شکست مواجه شد لطفا دوباره تلاش کنید";



        public static string DuplicatedMobile = "کاربری با شماره موبایل شما ثبت نام کرده است";
        #endregion

        #region Login
        public static string UserBan = "حساب کاربری شما مسدود میباشد لطفا از طریق پشتیبانی اقدام فرمایید";


        public static string NotFounds = "کاربری با مشخصات وارد شده یافت نشد";
        #endregion
    }





}
