using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Shared
{
    public class SuccessMessages
    {

        #region AdminUser

        public static string SuccessfullyEditUserAdmin = "ویرایش حساب کاربر با موفقیت انجام شد";

        public static string SuccessfullyCreateUserAdmin = "افزودن کاربر با موفقیت انجام شد";


        #endregion

        public static string SuccessRegister = "ثبت شما با موفقیت انجام شد";
        
        public static string SuccessEditProfile = "ویرایش حساب کاربری شما با موفقیت انجام شد";

        public static string SuccessLogin = "ورود شما با موفقیت انجام شد";

        public static string ForgotpasswordSuccessfulydone = "کد تایید برای شما ارسال شد";

        public static string ResetpasswordSuccessfulydone = "بازیابی کلمه عبور با موفقیت انجام شد";


        public static string SuccessDelete = "حذف کاربر با موفقیت انجام شد";

        public static string SuccessfullyDoneCreateRole = "افزودن نقش با موفقیت انجام شد";

        public static string SuccessfullyDoneUpdateRole = "ویرایش نقش با موفقیت انجام شد";

        #region productCategory
        public static string CreateProductCategorySuccessfulydone = "افزودن دسته بندی با موفقیت انجام شد";
        public static string UpdateProductCategorySuccessfulydone = "ویرایش دسته بندی با موفقیت انجام شد";
        public static string DeleteProductCategorySuccessfulydone = "حذف دسته بندی با موفقیت انجام شد";
        #endregion


        #region product
        public static string CreateProductSuccessfulydone = "افزودن محصول با موفقیت انجام شد";
        public static string UpdateProductSuccessfulydone = "ویرایش محصول با موفقیت انجام شد";
        public static string DeleteProductSuccessfulydone = "حذف محصول با موفقیت انجام شد";
        #endregion


        #region Feature and ProductFeature

        public static string DeleteFeatureSuccessfulydone = "حذف ویژگی موفقیت انجام شد";
        public static string UpdateFeatureSuccessfulydone = "ویرایش ویژگی با موفقیت انجام شد";

        #endregion

        #region ProductColor

        public static string AddProductColorSuccessfullyDone = "رنگ با موفقیت به محصول افزوده شد";

        public static string UpdateProductColorSuccessfullyDone = " ویرایش رنگ با موفقیت انجام شد"; 

        public static string DeleteProductColorSuccessfullyDone = " حذف رنگ با موفقیت انجام شد";
        #endregion


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

        #region AdminUser
        public static string DuppLicatedMobileAdmin = "کاربری با این شماره موبایل ثبت نام کرده است";

        public static string NotSelectedRole = "هیچ نقشی برای این کاربر انتخاب نشده است";

        public static string NotFoundUser = "کاربری با این مشخصات یافت نشد";


        #endregion

        #region Product

        public static string ProductCategoryNotFound = "دسته بندی با این مشخصات یافت نشد";

        public static string ProductNotFound = "محصولی با این مشخصات یافت نشد";
        #endregion

        #region Feature and ProductFeature

        public static string FeatureNotFound = "ویژگی مورد نظر یافت نشد";

        #endregion

        #region ProductColor

        public static string DupplicatedColor = "این رنگ در لیست رنگ محصول از قبل موجود میباشد";

        public static string ColorNotFound = "رنگ پیدا نشد";

        public static string ExistanotherDefaultcolor = "رنگ پیشفرض دیگری برای این محصول انتخاب شده است";
        #endregion

        #region RoleAndPermission

        public static string PermissionNotFound = "این دسترسی برای  افزودن به نقش پیدا نشده است";


        public static string RoleNotFound = " نقش پیدا نشده است";
        #endregion
    }





}
