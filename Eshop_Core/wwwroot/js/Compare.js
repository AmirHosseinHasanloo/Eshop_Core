$(function () {
    $("#CompareList").load("/Compare/CompareList");
});

function AddToCompareList(id) {
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