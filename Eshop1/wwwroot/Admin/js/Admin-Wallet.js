function ShowChargeWalletModal(url) {
    fetch(url)
        .then(res => res.text())
        .then(data => {
            $('#Large_modal_Title').html("شارژ کیف پول کاربر");
            $('#Large_Modal_Body').html(data);
            $('#large_modal').modal('show');
        })
}


function OnSuccessChargeWalletAdmin(res) {



    if (res.status == 100) {
        $('#large_modal').modal('hide');
        Swal.fire({
            title: "عملیات موفق",
            text: res.message,
            icon: "success"
        });
    }
    else {
        $('#large_modal').modal('hide');
        Swal.fire({
            title: "عملیات با شکست مواجه شد",
            text: res.message,
            icon: "warning"
        });
    }


}
