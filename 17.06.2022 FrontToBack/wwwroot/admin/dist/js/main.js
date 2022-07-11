$(function () {
  $("#example1").DataTable({
    "responsive": true,
    "lengthChange": false,
    "autoWidth": false,
    "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
  }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
});

let catName = document.getElementById("categoryName")
let catDesc = document.getElementById("categoryDesc")
catName.onkeyup = function () {
  if (catName.value.length >= 3) {
    catDesc.removeAttribute("disabled")
  }
  else {
    catDesc.setAttribute("disabled")
  }
}
