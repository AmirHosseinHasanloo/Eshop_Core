
function AddComment(id) {
    $.ajax({
        url: "/Products/AddComments/" + id,
        type: "Post",
        data: { UserName: $("#UserName").val(), Email: $("#Email").val(), WebSite: $("#WebSite").val(), Comment: $("#Comment").val() }
    })
}