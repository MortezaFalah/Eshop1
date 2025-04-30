const { local } = require("d3-selection");

function acceptComment(commentId) {

    $.ajax({
        url: '/ProductComment/ConfirmComment/' + commentId, // URL کنترلر خود را تغییر دهید  
        type: 'POST',
        data: { commentid: commentId },
        success: function (response) {
            if (response.status == 100) {  // بررسی موفقیت آمیز بودن عملیات  
                Swal.fire({
                    title: 'موفقیت',
                    text: response.message,  // پیام دریافتی  
                    icon: 'success'
                });

                setTimeout(function () {
                    location.reload()
                }, 3000);
            } else {
                Swal.fire({
                    title: 'خطا',
                    text: response.message,
                    icon: 'error'
                });
            }

        },
        error: function (response) {
            Swal.fire({
                title: 'خطا',
                text: response.message,
                icon: 'error'
            });
        }
    });
}

function rejectComment(commentId) {
    $.ajax({
        url: '/ProductComment/RejectComment/' + commentId, // URL کنترلر خود را تغییر دهید  
        type: 'POST',
        data: { id: commentId },
        success: function (response) {
            if (response.status == 100) {  // بررسی موفقیت آمیز بودن عملیات  
                Swal.fire({
                    title: 'موفقیت',
                    text: response.message,  // پیام دریافتی  
                    icon: 'success'
                });


                setTimeout(function () {
                    location.reload();
                }, 3000);


            } else {
                Swal.fire({
                    title: 'خطا',
                    text: response.message,
                    icon: 'error'
                });
            }
        },
        error: function (response) {
            Swal.fire({
                title: 'خطا',
                text: 'مشکلی در ارسال درخواست پیش آمد.',
                icon: 'error'
            });
        }
    });
}  