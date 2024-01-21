
function Success() {

    $("#comment_Comment").val("");

    Swal.fire({
        title: "موفقیت آمیز!",
        text: "کاربر گرامی نظر شما با موفقیت ثبت شد",
        icon: "success"
    });
}

function ReplyComment(id) {
    $("#comment_ParentId").val(id);
    $("html, body").animate({ scrollTop: $("#comments").offset().top }, 1000);
}

$(function () {
    $("#listComment").load("/Products/ShowComments/@ProductPage.ProductId")
});

function ShowPageComments(id) {
    $("#listComment").load("/Products/ShowComments/@ProductPage.ProductId" + "?pageId=" + id)
}
