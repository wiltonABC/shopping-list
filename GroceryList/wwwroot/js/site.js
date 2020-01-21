// Write your JavaScript code.

function removeRecord(e, action) {

    if (e.target.id == "deleteButton") {

        $("#confirmationModal").off("click", "#confirmButton");

        var id = e.target.getAttribute("data-id");
        $("#confirmationModal").modal({
            backdrop: 'static',
            keyboard: false
        })
            .on("click", "#confirmButton", (e) => {
                //console.log(`The selected id is ${id}`);
                $.ajax({
                    type: "DELETE",
                    url: `${action}${id}`,
                    success: function () {
                        $(`[data-id=${id}]`).parents("tr").remove();
                    },
                    error: function () {
                        alert("Error while deleting data");
                    }
                });
            });
    }

}

$("#categoriesTable").on("click", (e) => {

    removeRecord(e, "/Categories/Delete/");

});

$("#productsTable").on("click", (e) => {

    removeRecord(e, "/Products/Delete/");

});