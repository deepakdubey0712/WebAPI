$(document).ready(function () {
  const table = $("#employeeTable").DataTable({
    responsive: true,
    autoWidth: false,
    pageLength: 5,
    dom:
      '<"row"<"col-sm-6"l><"col-sm-6"f>>' +
      '<"row"<"col-sm-12"tr>>' +
      '<"row"<"col-sm-5"i><"col-sm-7"p>>',

    ajax: {
      url: "/Employees/GetAll",
      dataSrc: "",
    },
    columns: [
      { data: "employeeID" },
      { data: "name" },
      {
        data: "dob",
        render: (data) => new Date(data).toLocaleDateString(),
      },
      {
        data: "doj",
        render: (data) => new Date(data).toLocaleDateString(),
      },
      {
        data: "employeeID",
        render: function (data) {
          return `<button type="button" class="btn btn-sm btn-primary edit" data-id="${data}"><i class="fas fa-edit"></i></button>
                <button type="button" class="btn btn-sm btn-danger delete" data-id="${data}"><i class="fas fa-trash-alt"></i></button>`;
        },
      },
    ],
  });

  $("#btnAdd").click(function (e) {
    e.preventDefault();

    const form = $("#employeeForm")[0];
    if (form) {
      form.reset();
    } else {
      console.warn("Form #employeeForm not found.");
    }

    $("#EmployeeID").val("");
    $("#employeeModalLabel").text("Add Employee");
    $('#employeeForm button[type="submit"]').text("Save");
    $("#employeeModal").modal("show");
  });

  $("#employeeTable").on("click", ".edit", function (e) {
    debugger;
    e.preventDefault();
    $('#employeeForm button[type="submit"]').text("Update");
    const id = $(this).data("id");
    $.get(`/Employees/Get/${id}`, function (data) {
      $("#EmployeeID").val(data.employeeID);
      $("#Name").val(data.name);
      $("#DOB").val(data.dob.split("T")[0]);
      $("#DOJ").val(data.doj.split("T")[0]);
      $("#employeeModalLabel").text("Edit Employee");
      $("#employeeModal").modal("show");
    });
  });

  $("#employeeForm").validate({
    rules: {
      Name: "required",
      DOB: "required",
      DOJ: "required",
    },
    messages: {
      Name: "Please enter the employee's name",
      DOB: "Please select a date of birth",
      DOJ: "Please select a date of joining",
    },
  });

  $("#employeeForm").submit(function (e) {
    debugger;
    e.preventDefault();
    if (!$(this).valid()) {
      return; // Stop if form is invalid
    }
    const employeeId = $("#EmployeeID").val().trim();
    const isEdit = employeeId !== "";
    // Build the employee object
    const employee = {
      Name: $("#Name").val().trim(),
      DOB: $("#DOB").val(),
      DOJ: $("#DOJ").val(),
    };

    // Only include EmployeeID if editing
    if (isEdit) {
      employee.EmployeeID = parseInt(employeeId);
    }

    const method = isEdit ? "PUT" : "POST";
    const url = isEdit
      ? `/Employees/Update/${employeeId}`
      : "/Employees/Create";

    console.log("Payload:", JSON.stringify(employee));

    $.ajax({
      url: url,
      method: method,
      contentType: "application/json; charset=utf-8",
      data: JSON.stringify(employee),
      success: function (response) {
        debugger;
        console.log("Server response:", response);
        $("#employeeModal").modal("hide");
        table.ajax.reload();
      },
      error: function (xhr) {
        console.error("Error:", xhr.status, xhr.responseText);
        alert("Failed to save employee. Check console for details.");
      },
    });
  });

  // $("#employeeTable").on("click", ".delete", function () {
  //   debugger;
  //   const id = $(this).data("id");
  //   if (confirm("Are you sure you want to delete this employee?")) {
  //     $.ajax({
  //       url: `/Employees/Delete/${id}`,
  //       method: "DELETE",
  //       success: function () {
  //         table.ajax.reload();
  //       },
  //     });
  //   }
  // });

  $("#employeeTable").on("click", ".delete", function (e) {
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
          url: `/Employees/Delete/${id}`,
          method: "DELETE",
          success: function () {
            Swal.fire("Deleted!", "The employee has been deleted.", "success");
            // Reload the DataTable
            $("#employeeTable").DataTable().ajax.reload();
          },
          error: function () {
            Swal.fire(
              "Error!",
              "There was a problem deleting the employee.",
              "error"
            );
          },
        });
      }
    });
  });
});
