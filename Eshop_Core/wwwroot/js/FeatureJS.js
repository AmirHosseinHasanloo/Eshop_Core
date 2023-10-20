function DeleteFeature(id) {
    if (confirm("آیا از حذف این ویژگی مطمئن هستید ؟")) {
        $.get("/Admin/ProductFeatures/Delete?id=" + id, function () {
            $("#Feature_" + id).hide("slow");
        })
    }
}