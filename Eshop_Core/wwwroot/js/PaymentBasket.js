function UpdatePriceByCount(id, count) {
    $.ajax({
        url: "/Basket/UpdatePriceByCount/" + id,
        type: "Get",
        data: { count: count }
    }).done(function (result) {
        $("#PaymentBasket").html(result);
    });
}


function DeleteOrderDetail(id) {
    $.ajax({
        url: "/Basket/DeleteOrderDetial/" + id,
        type: "Get",
    }).done(function (result) {
        $("#PaymentBasket").html(result);
    });

}