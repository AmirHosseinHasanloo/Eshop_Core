function DeleteGallery(id) {
    if (confirm("آیا از حذف این عکس مطمئن هستید ؟")) {
        $.get("/Admin/ProductGallery/Delete?id=" + id, function () {
            $("#Gallery_" + id).hide("slow");
        })
    }
}