(function ($) {
    "use strict";
    let THEME = {};

    /*====== Example ======*/
    THEME.Example = function () {
        // Write your code here
    };
    /*====== end Example ======*/

    $(window).on("load", function () { });
    $(document).ready(function () {
        THEME.Example();
    });
})(jQuery);




function filPageId(PageId) {
    $("#Page").val(PageId);
    $("#filter-search").submit();
}

function ChangeProductColor(productcolorid) {

    fetch(`/Product/GetColorForAjax/${productcolorid}`)
        .then(res => res.json())
        .then(data => {
            document.getElementById("ProductPriceOne").innerText = data.price;
            document.getElementById("ProductPriceTwo").innerText = data.price
        });
    /*console.log(productcolorid);*/

}

function ShowProductCommentModal(productid) {
    console.log(productid);
    //// نام اکشن کنترلر را در اینجا قرار دهید
    //$.ajax({
    //    url: /Product/addproductcomment / productid, // آدرس اکشن کنترلر
    //    type: 'GET', // یا 'POST' بر حسب نیاز
    //    success: function (data) {
    //        // وقتی داده ها برگشتند
    //        $('#Large_modal_Title').html("افزودن نظر به محصول")
    //        $('#Large_Modal_Body').html(data); // قرار دادن محتوا در مودال
    //        $('#large_modal').modal('show'); // نمایش مودال
    //    },
    //    //error: function (xhr, status, error) {
    //    //    console.error("Error occurred: " + status + " " + error);
    //    //}
    //});

    fetch(`/Product/addproductcomment/${productid}`)
        .then(res => res.text())
        .then(data => {
            $('#Large_modal_Title').html("افزودن نظر به محصول");
            $('#Large_Modal_Body').html(data);
            $('#large_modal').modal('show');
        })
}

