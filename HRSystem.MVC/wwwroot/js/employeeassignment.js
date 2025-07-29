$(document).ready(function () {
  loadEmployees();
  loadDepartments();
  $("#assignmentTable").DataTable({
    responsive: true,
    autoWidth: false,
    pageLength: 5,
    dom:
      '<"row"<"col-sm-6"l><"col-sm-6"f>>' +
      '<"row"<"col-sm-12"tr>>' +
      '<"row"<"col-sm-5"i><"col-sm-7"p>>',
    ajax: {
      url: "/EmployeeAssignments/GetAll",
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
      { data: "empDeptID" },
      {
        data: "employeeID",
        render: function (data, type, row) {
          return row.employee ? row.employee.name : "N/A";
        },
      },
      {
        data: "departmentID",
        render: function (data, type, row) {
          return row.department ? row.department.departmentName : "N/A";
        },
      },
      {
        data: "startDate",
        render: function (data, type, row) {
          return data ? new Date(data).toLocaleDateString("en-IN") : "-";
        },
      },
      {
        data: "endDate",
        render: function (data, type, row) {
          return data ? new Date(data).toLocaleDateString("en-IN") : "-";
        },
      },
      {
        data: "empDeptID",
        render: function (data) {
          return `
        <button type="button" class="btn btn-sm btn-primary btn-edit" data-id="${data}"><i class="fas fa-edit"></i></button>
        <button type="button" class="btn btn-sm btn-danger btn-delete" data-id="${data}"><i class="fas fa-trash-alt"></i></button>
      `;
        },
      },
    ],
  });

  $("#assignmentForm").validate({
    rules: {
      EmployeeID: "required",
      DepartmentID: "required",
      StartDate: "required",
      EndDate: "required",
    },
    messages: {
      EmployeeID: "Please select an employee",
      DepartmentID: "Please select a department",
      StartDate: "Please select a start date",
      EndDate: "Please select an end date",
    },
  });

  $("#btnAdd").click(function (e) {
    debugger;
    e.preventDefault();
    $("#assignmentForm")[0].reset();
    $("#EmpDeptID").val("");
    $("#assignmentModalLabel").text("Assign Employee");
    $('#assignmentForm button[type="submit"]').text("Save");
    $("#assignmentModal").modal("show");
  });

  $("#assignmentTable tbody").on("click", ".btn-edit", function (e) {
    debugger;
    e.preventDefault();
    const id = $(this).data("id");
    $.get(`/EmployeeAssignments/Get/${id}`, function (data) {
      $("#EmpDeptID").val(data.empDeptID);
      $("#EmployeeID").val(data.employeeID);
      $("#DepartmentID").val(data.departmentID);
      $("#StartDate").val(data.startDate.split("T")[0]);
      $("#EndDate").val(data.endDate ? data.endDate.split("T")[0] : "");
      $("#assignmentModalLabel").text("Edit Assignment");
      $('#assignmentForm button[type="submit"]').text("Update");
      $("#assignmentModal").modal("show");
    });
  });

  $("#assignmentTable tbody").on("click", ".btn-delete", function (e) {
    debugger;
    e.preventDefault();
    const id = $(this).data("id");
    Swal.fire({
      title: "Are you sure?",
      text: "This assignment will be deleted.",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: `/EmployeeAssignments/Delete/${id}`,
          type: "DELETE",
          success: function () {
            $("#assignmentTable").DataTable().ajax.reload();
            Swal.fire("Deleted!", "Assignment deleted.", "success");
          },
          error: function () {
            Swal.fire("Error!", "Could not delete assignment.", "error");
          },
        });
      }
    });
  });

  $("#assignmentForm").submit(function (e) {
    debugger;
    e.preventDefault();
    if (!$(this).valid()) {
      return; // Stop if form is invalid
    }
    const id = $("#EmpDeptID").val().trim();
    const isEdit = id !== "";

    const assignment = {
      employeeID: parseInt($("#EmployeeID").val()),
      departmentID: parseInt($("#DepartmentID").val()),
      startDate: $("#StartDate").val(),
      endDate: $("#EndDate").val() || null,
    };

    if (isEdit) assignment.empDeptID = parseInt(id);

    $.ajax({
      url: isEdit
        ? `/EmployeeAssignments/Update/${id}`
        : "/EmployeeAssignments/Create",
      type: isEdit ? "PUT" : "POST",
      data: JSON.stringify(assignment),
      contentType: "application/json",

      success: function (response) {
        console.log("Created:", response);

        $("#assignmentModal").modal("hide");
        $("#assignmentTable").DataTable().ajax.reload();
      },
      error: function (xhr) {
        alert("Error saving assignment: " + xhr.responseText);
      },
    });
  });

  $("#EmployeeID, #DepartmentID").on("change", function (e) {
    debugger;
    e.preventDefault();
    e.stopImmediatePropagation();
    return false;
  });

  $("#assignmentForm").on("keypress", function (e) {
    if (e.key === "Enter") {
      e.preventDefault();
      return false;
    }
  });
});

function loadEmployees() {
  $.get("/Employees/GetAll", function (data) {
    const $empSelect = $("#EmployeeID");
    $empSelect
      .empty()
      .append('<option value="">-- Select Employee --</option>');
    data.forEach((emp) => {
      $empSelect.append(
        `<option value="${emp.employeeID}">${emp.name}</option>`
      );
    });
  });
}

function loadDepartments() {
  $.get("/Departments/GetAll", function (data) {
    const $deptSelect = $("#DepartmentID");
    $deptSelect
      .empty()
      .append('<option value="">-- Select Department --</option>');
    data.forEach((dept) => {
      $deptSelect.append(
        `<option value="${dept.departmentID}">${dept.departmentName}</option>`
      );
    });
  });
}
