$(document).ready(function () {
  const table = $("#deductioncomponentTable").DataTable({
    responsive: true,
    autoWidth: false,
    dom:
      '<"row"<"col-sm-6"l><"col-sm-6"f>>' +
      '<"row"<"col-sm-12"tr>>' +
      '<"row"<"col-sm-5"i><"col-sm-7"p>>',

    ajax: {
      url: "/DeductionComponents/GetAll",
      dataSrc: "",
    },
    columns: [
      { data: "deductionID" },
      { data: "deductionName" },
      { data: "rule" },
      {
        data: "deductionID",
        render: function (data) {
          return `<button class="btn btn-sm btn-primary edit" data-id="${data}">Edit</button>
                  <button class="btn btn-sm btn-danger delete" data-id="${data}">Delete</button>`;
        },
      },
    ],
  });

  $("#btnAdd").click(function () {
    debugger;
    $("#deductioncomponentForm")[0].reset();
    $("#DeductionID").val("");
    $("#deductioncomponentModalLabel").text("Add Deduction");
    $('#deductioncomponentForm button[type="submit"]').text("Save");
    $("#deductioncomponentModal").modal("show");
  });

  $("#deductioncomponentTable").on("click", ".edit", function () {
    debugger;
    $('#deductioncomponentForm button[type="submit"]').text("Update");
    const id = $(this).data("id");
    $.get(`/DeductionComponents/Get/${id}`, function (data) {
      $("#DeductionID").val(data.deductionID);
      $("#DeductionName").val(data.deductionname);
      $("#Rule").val(data.rule);
      $("#deductioncomponentModalLabel").text("Edit Deduction");
      $("#deductioncomponentModal").modal("show");
    });
  });

  $("#deductioncomponentForm").validate({
    rules: {
      Name: "required",
      Rule: "required",
    },
    messages: {
      Name: "Please enter the Deduction name",
      Rule: "Please enter the Rule",
    },
  });

  $("#deductioncomponentForm").submit(function (e) {
    e.preventDefault();
    if (!$(this).valid()) {
      return; // Stop if form is invalid
    }
    const deductionId = $("#deductionID").val().trim();
    const isEdit = deductionId !== "";
    // Build the deduction object
    const deduction = {
      DeductionName: $("#deductionName").val().trim(),
      Rule: $("#deductionRule").val().trim(),
    };

    // Only include DeductionID if editing
    if (isEdit) {
      deduction.DeductionID = parseInt(deductionId);
    }

    const method = isEdit ? "PUT" : "POST";
    const url = isEdit
      ? `/DeductionComponents/Update/${deductionId}`
      : "/DeductionComponents/Create";

    console.log("Payload:", JSON.stringify(deduction));

    $.ajax({
      url: url,
      method: method,
      contentType: "application/json; charset=utf-8",
      data: JSON.stringify(deduction),
      success: function (response) {
        debugger;
        console.log("Server response:", response);
        $("#deductioncomponentModal").modal("hide");
        table.ajax.reload();
      },
      error: function (xhr) {
        console.error("Error:", xhr.status, xhr.responseText);
        alert("Failed to save deduction component. Check console for details.");
      },
    });
  });

  $("#deductioncomponentTable").on("click", ".delete", function () {
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
          url: `/DeductionComponents/Delete/${id}`,
          method: "DELETE",
          success: function () {
            Swal.fire("Deleted!", "The deduction has been deleted.", "success");
            // Reload the DataTable
            $("#deductioncomponentTable").DataTable().ajax.reload();
          },
          error: function () {
            Swal.fire(
              "Error!",
              "There was a problem deleting the deduction.",
              "error"
            );
          },
        });
      }
    });
  });
});
