$(function () {
    $.ajax({
        url: "/Basket/ListOrder",
        type: "Get"
    }).done(function (result) {
        $("#basket").html(result);
    });
});


function IsUserLogedInForShopping() {
    $.ajax({
        url: "/Account/IsUserLogedIn",
        type: "Get"
    }).done(function (result) {
        if (result == false) {
            Swal.fire({
                title: "کاربر گرامی برای افزودن محصول به سبد خرید میتوانید وارد حساب کاربری خود شوید ",
                icon: "warning",
                iconHtml: "!",
                confirmButtonText: "باشه",
            });
        }
    });
}


function AddOrder(id) {
    IsUserLogedInForShopping();

    $.ajax({
        url: "/Basket/AddOrder/" + id,
        type: "Get"
    }).done(function (result) {
        $("#basket").html(result);
    });
}