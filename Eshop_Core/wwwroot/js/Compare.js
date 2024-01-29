
$(function () {

    $.get("/Compare/CompareList/", function (result) {
        $("#CompareList").html(result);
    });
});

function IsUserLogedInForComparing() {
    $.ajax({
        url: "/Account/IsUserLogedIn",
        type: "Get"
    }).done(function (result) {
        if (result == false) {
            Swal.fire({
                title: "کاربر گرامی برای افزودن محصول به لیست مقایسه میتوانید وارد حساب کاربری خود شوید ",
                icon: "warning",
                iconHtml: "!",
                confirmButtonText: "باشه",
            });
        }
    });
}

function AddToCompareList(id) {

    IsUserLogedInForComparing();
    $.get("/Compare/AddToCompareList/" + id, function (result) {
        $("#CompareList").html(result);
    })
}

function DeleteFromList(id) {
    $.ajax({
        url: "/Compare/DeleteFromList/" + id,
        type: "Get"
    }).done(function (result) {
        $("#CompareList").html(result);
    });
}