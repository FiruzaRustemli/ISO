$(document).ready(function () {

    $('table.display').DataTable();


    $("form").attr('autocomplete', 'off');

    var storageData = localStorage.getItem("row");
    localStorage.removeItem("row");

    if (!window.location.pathname.startsWith('/Home/Index') && !(window.location.pathname === '/')) {
        localStorage.setItem("row", storageData);
    }
    var saveMenu = localStorage.getItem("row");
    $("#sidebar-menu ul").html(saveMenu);

   
    $("input[type=time]").on("change", function () {
        console.log(this.valueAsDate)
    })

});
