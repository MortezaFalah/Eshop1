function OnSuccessChargeWallet(res) {
    if (res && res.status == 100) {
        location.href = res.url;
       
    }
    else {
        Swal.fire({
            title: "خطا",
            text: res.message,
            icon: "warning"
        });
    }
}


