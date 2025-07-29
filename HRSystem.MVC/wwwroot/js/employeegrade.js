$(document).ready(function () {
  loadEmployees();
  //loadGrades();
  $("#gradeTable").DataTable({
    responsive: true,
    autoWidth: false,
    pageLength: 5,
    dom:
      '<"row"<"col-sm-6"l><"col-sm-6"f>>' +
      '<"row"<"col-sm-12"tr>>' +
      '<"row"<"col-sm-5"i><"col-sm-7"p>>',
    ajax: {
      url: "/EmployeeGrades/GetAll",
      dataSrc: function (json) {
        return Array.isArray(json) ? json : [];
      },
    },
    columns: [
      { data: "employeeGradeID" },
      { data: "employeeID" },
      { data: "gradeID" },
      {
        data: "startDate",
        render: (data) =>
          data ? new Date(data).toLocaleDateString("en-IN") : "-",
      },
      {
        data: "endDate",
        render: (data) =>
          data ? new Date(data).toLocaleDateString("en-IN") : "-",
      },
      {
        data: "employeeGradeID",
        render: function (data) {
          return `<button type="button" class="btn btn-sm btn-primary edit" data-id="${data}"><i class="fas fa-edit"></i></button>
                <button type="button" class="btn btn-sm btn-danger delete" data-id="${data}"><i class="fas fa-trash-alt"></i></button>`;
        },
      },
    ],
  });

  $("#btnAddGrade").click(function (e) {
    debugger;
    e.preventDefault();
    $("#gradeForm")[0].reset();
    $("#EmployeeGradeID").val("");
    $("#gradeModalLabel").text("Assign Grade");
    $('#gradeForm button[type="submit"]').text("Save");
    $("#gradeModal").modal("show");
  });

  $("#gradeTable tbody").on("click", ".edit", function (e) {
    debugger;
    e.preventDefault();
    const id = $(this).data("id");
    $.get(`/EmployeeGrades/Get/${id}`, function (data) {
      $("#EmployeeGradeID").val(data.employeeGradeID);
      $("#EmployeeID").val(data.employeeID);
      $("#GradeID").val(data.gradeID);
      $("#StartDate").val(data.startDate.split("T")[0]);
      $("#EndDate").val(data.endDate.split("T")[0]);
      $("#gradeModalLabel").text("Edit Grade");
      $('#gradeForm button[type="submit"]').text("Update");
      $("#gradeModal").modal("show");
    });
  });

  $("#gradeTable tbody").on("click", ".delete", function (e) {
    debugger;
    e.preventDefault();
    const id = $(this).data("id");
    Swal.fire({
      title: "Are you sure?",
      text: "This grade assignment will be deleted.",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Yes, delete it!",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: `/EmployeeGrades/Delete/${id}`,
          type: "DELETE",
          success: function () {
            $("#gradeTable").DataTable().ajax.reload();
            Swal.fire("Deleted!", "Grade deleted.", "success");
          },
          error: function () {
            Swal.fire("Error!", "Could not delete grade.", "error");
          },
        });
      }
    });
  });

  $("#gradeForm").submit(function (e) {
    debugger;
    e.preventDefault();
    const id = $("#EmployeeGradeID").val().trim();
    const isEdit = id !== "";

    const grade = {
      employeeID: parseInt($("#EmployeeID").val()),
      gradeID: parseInt($("#GradeID").val()),
      startDate: $("#StartDate").val(),
      endDate: $("#EndDate").val(),
    };

    if (isEdit) grade.employeeGradeID = parseInt(id);

    $.ajax({
      url: isEdit ? "/EmployeeGrades/Update" : "/EmployeeGrades/Create",
      type: isEdit ? "PUT" : "POST",
      data: JSON.stringify(grade),
      contentType: "application/json",
      success: function () {
        $("#gradeModal").modal("hide");
        $("#gradeTable").DataTable().ajax.reload();
      },
      error: function (xhr) {
        alert("Error saving grade: " + xhr.responseText);
      },
    });
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

function loadGrades() {
  $.get("/Grades/GetAll", function (data) {
    const $gradeSelect = $("#GradeID");
    $gradeSelect.empty().append('<option value="">-- Select Grade --</option>');
    data.forEach((grade) => {
      $gradeSelect.append(
        `<option value="${grade.gradeID}">${grade.gradeName}</option>`
      );
    });
  });
}
