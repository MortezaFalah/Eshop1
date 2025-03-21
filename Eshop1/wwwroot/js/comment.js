const { timeout } = require("d3-timer");

let advantages = [];
let disadvantages = [];

//function addAdvantage() {
//    const input = document.getElementById('advantage-input');
//    const value = input.value.trim();

//    if (value) {
//        advantages.push(value);
//        input.value = ''; // Clear the input  
//        displayAdvantages();
//    }
//}

//function addDisadvantage() {
//    const input = document.getElementById('disadvantage-input');
//    const value = input.value.trim();

//    if (value) {
//        disadvantages.push(value);
//        input.value = ''; // Clear the input  
//        displayDisadvantages();
//    }
//}

function OnsuccessCreateProductComment(result) {
    console.log(result);
    if (result && result.status == 100) {
        Swal.fire({
            title: "عملیات موفق",
            text: result.text,
            icon: "success"
        });
    }

    else {
        Swal.fire({
            title: "خطا",
            text: result.text,
            icon: "warning"
        });
    }


    setTimeout(() => {
        $("#large_modal").modal('hide');
        location.reload();
    }, 2000);
}


//function displayAdvantages() {
//    const list = document.getElementById('advantages-list');
//    list.innerHTML = advantages.join(', '); // نمایش مزایا
//}

//function displayDisadvantages() {
//    const list = document.getElementById('disadvantages-list');
//    list.innerHTML = disadvantages.join(', '); // نمایش معایب
//}

//function submitForm() {
//    // محتوای نهایی را آماده کنید
//    const advantagesStr = advantages.join(', ');
//    const disadvantagesStr = disadvantages.join(', ');

//    // می‌توانید این مقادیر را به فیلد‌های پنهان فرمان اضافه کنید یا بصورت دلخواه ارسال کنید
//    console.log('مزایا:', advantagesStr);
//    console.log('معایب:', disadvantagesStr);
//    // فرم را ارسال کنید
//    // document.forms[0].submit(); // در صورت نیاز

//    // ارسال به سرور یا دیگر اقدامات لازم
//}  