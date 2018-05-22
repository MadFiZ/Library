function deleteRow() {
    $(this).closest("tr").hide("slow");  
}

angular.module("Book", ["kendo.directives"])
  .controller("BookController", function ($scope) {
    $scope.bookOptions = {
      sortable: true,
      pageable: true,
      dataBound: onDataBoundBook,
    columns: [
      {
        field: "name",
        title: "Name"
      },
      {
        field: "author",
        title: "Author"
      },
      {
        field: "yearOfPublishing",
        title: "Year Of Publishing"
      },
      {
        field: "publicationHouseNames",
        title: "Publication Houses"
      },
      {
        template: "<button class=\"btn btn-sm btn-primary\" (click) = \"editBook(b)\" > Edit</button> | <button class=\"btn btn-sm btn-danger\" (click) = \"delete(b)\"> Delete</button>",
        title: "Actions"
      }]
    };
  })

function onDataBoundBook() {
    var newWidth = 0;
    var grid = $("#BookGrid").data("kendoGrid");
    for (var i = 0; i < grid.columns.length; i++) {
        grid.autoFitColumn(i);
    }
    $.each(grid.columns, function (i, col) {
        newWidth += grid.table[0].rows[0].cells[i].offsetWidth;
    });
    grid.element.closest(".k-grid").width(newWidth + 17);
}  
