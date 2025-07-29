$(document).ready(function () {
  // Initialize DataTable
  $("#departmentTable").DataTable({
    responsive: true,
    autoWidth: false,
    pageLength: 5,
    dom:
      '<"row"<"col-sm-6"l><"col-sm-6"f>>' +
      '<"row"<"col-sm-12"tr>>' +
      '<"row"<"col-sm-5"i><"col-sm-7"p>>',

    ajax: {
      url: "/Departments/GetAll",

      dataSrc: function (json) {
        console.log("AJAX response:", json);

        // Handle null or unexpected response
        if (!json || !Array.isArray(json)) {
          console.warn("Invalid or null response received.");
          return []; // Return empty array to prevent DataTables error
        }

        return json;
      },
    },
    columns: [
      { data: "departmentID" },
      { data: "departmentName" },
      {
        data: "departmentID",
        render: function (data) {
        return `<button type="button" class="btn btn-sm btn-primary edit" data-id="${data}"><i class="fas fa-edit"></i></button>
                <button type="button" class="btn btn-sm btn-danger delete" data-id="${data}"><i class="fas fa-trash-alt"></i></button>`;
        },
      },
    ],
  });

  // Add Department
  $("#btnAdd").click(function (e) {
    debugger;
    e.preventDefault();
    $("#departmentForm")[0].reset();
    $("#DepartmentID").val("");
    $("#departmentModalLabel").text("Add Department");
    $('#departmentForm button[type="submit"]').text("Save");
    $("#departmentModal").modal("show");
  });

  // Edit Department
  $("#departmentTable tbody").on("click", ".edit", function (e) {
    debugger;
    e.preventDefault();
    $('#departmentForm button[type="submit"]').text("Update");
    const id = $(this).data("id");
    $.get(`/Departments/Get/${id}`, function (data) {
      $("#DepartmentID").val(data.departmentID);
      $("#DepartmentName").val(data.departmentName);
      $("#departmentModalLabel").text("Edit Department");
      $("#departmentModal").modal("show");
    });
  });

  // Delete Department
  $("#departmentTable tbody").on("click", ".delete", function (e) {
    debugger;
    e.preventDefault();
    const id = $(this).data("id");
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: `/Departments/Delete/${id}`,
          type: "DELETE",
          success: function () {
            $("#departmentTable").DataTable().ajax.reload();
            Swal.fire(
              "Deleted!",
              "Your department has been deleted.",
              "success"
            );
          },
          error: function (xhr) {
            Swal.fire(
              "Error!",
              "There was an error deleting the department.",
              "error"
            );
          },
        });
      }
    });
  });

  $("#departmentForm").validate({
    rules: {
      DepartmentName: "required",
    },
    messages: {
      DepartmentName: "Please enter the department name",
    },
  });

  // Save Department
  $("#departmentForm").submit(function (e) {
    debugger;
    e.preventDefault();

    if (!$(this).valid()) {
      return; // Stop if form is invalid
    }
    const departmentId = $("#DepartmentID").val().trim();
    const isEdit = departmentId !== "";

    // Build the department object
    const department = {
      DepartmentName: $("#DepartmentName").val().trim(),
    };

    // Only include DepartmentID if editing
    if (isEdit) {
      department.DepartmentID = parseInt(departmentId);
    }

    $.ajax({
      url: isEdit
        ? `/Departments/Update/${departmentId}`
        : "/Departments/Create",
      type: isEdit ? "PUT" : "POST",
      data: JSON.stringify(department),
      contentType: "application/json",
      success: function () {
        $("#departmentModal").modal("hide");
        $("#departmentTable").DataTable().ajax.reload();
      },
      error: function (xhr) {
        alert("Error saving department: " + xhr.responseText);
      },
    });
  });
});
