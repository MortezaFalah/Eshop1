

function ConfirmDelete(url,e)
{
    e.preventDefault();
    Swal.fire({

        text: "آیا از انجام این عملیات مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "بله, حذفش کن!",
        cancelButtonText: "خیر"
    }).then((result) => {
        if (result.isConfirmed) {
            location.href = url;
            Swal.fire({
                title: "حذف شد!",
                text: "حذف با موفقیت انجام شد.",
                icon: "success"
            });
        }
    });
}



function filPageId(PageId) {
    $("#Page").val(PageId);
    $("#filter-search").submit();
}




