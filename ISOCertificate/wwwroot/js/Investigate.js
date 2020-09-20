$(document).ready(function () {

    //*********************************************************** Common Jq

    $(`.itemClick`).on("click", () => EditData());
    $(`.itemAdd`).on("click", () => AddData());
    $(`.itemDel`).on("click", () => DelData());
    $(`.CompleteSts`).on("click", () => CompleteData());

    function formatDate(date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();
        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [year, month, day].join('-');
    }
    function get_no_auto_increment() {
        $.ajax({
            method: "POST",
            url: '/Investigate/GetAutoNoIncrement',
            dataType: "json",
            success: function (data) {
                console.log(data);
                $("#inv-no").val(data);
            },
            error: function (data) {
                alert("Error");
            }

        });
    }

    function AddData() {
     resetAllControl();
        get_no_auto_increment();
        var now = new Date();
        $("#inv-date").val(formatDate(now));
    
    }

    function resetAllControl() {
        $("#inv-id").val("0");
        $("#material-id").val("0");
        $("#line-id").val("0");
        $("#image-id").val("0");
        $("#inv-name").val("");
        $("#inv-position").val("");
        $("#inv-date").val("");
        $("#inv-area").val("");
        $("#inv-activity").val("");
        $("#inv-occurenceReason").val("0");
        $("#inv-occurenceType").val("0");
        $("#inv-wheatherType").val("0");
        $("#inv-ground").val("0");
        $("#inv-groundCondition").val("0");
        $("#inv-illumination").val("0");
        $("#inv-contact").val("0");
        $("#inv-injury").val("0");
        $("#inv-ilness").val("0");
        $("#inv-bodily").val("0");
        $("#inv-injuredAction").val("0");
        $("#inv-release").val("0");
        $("#inv-releaseToType").val("0");
        $("#inv-safeFact").val("0");
        $("#inv-safeCondition").val("0");
        $("#descriptionIncident").val("");
        $("#inv-descriptionImmediate").val("");

        $("#material-release").val("0");
        $("#material-category").val("0");
        $("#material-duration").val("");
        $("#material-pollution").val("");
        $("#quantity-recovered").val("");
        $("#quantity-released").val("");

        $("#line-name").val("");
        $("#line-position").val("");
        $("#line-organization").val("");
        $("#line-type").val("0");


        $("#image-document").val("");
        $("#image-name").val("");

        $("#lbl_error_investigate").text("");
        $("#lbl_error_material_line").text("");
        $("#lbl_error_investigate_line").text("");
        $("#lbl_error_image_line").text("");


        DELIVERY = [];
        DELIVERYLINE = [];
        FILES = [];

        var material_table = $("#material-body");
        material_table.html("");
        var line_table = $("#line-body");
        line_table.html("");
        var file_table = $("#image-body");
        file_table.html("");
    }

    function ClearLine() {
        $("#material-id").val("").prop('required', false);
        $("#material-release").val("");
        $("#material-category").val("");
        $("#material-duration").val("");
        $("#material-pollution").val("");
        $("#quantity-recovered").val("");
        $("#quantity-released").val("");

        $("#line-id").val("").prop('required', false);
        $("#line-name").val("").prop('required', false);;
        $("#line-position").val("");
        $("#line-organization").val("");
        $("#line-type").val("");

        $("#image-id").val("").prop('required', false);
        $("#image-document").val("").prop('required', false);
        $("#image-name").val("").prop('required', false);
        $("#customFile").val("").prop('required', false);
        $(".custom-file-label").text("").prop('required', false);

    }


    //*********************************************************************Seed Materials Table

    var DELIVERY = [];
    var DELIVERIES = {};

    $(document).on("click", ".btn-material-save", function () {

        if ($("#material-release").val() === 0 || $("#material-category").val() === 0 || $("#material-duration").val().length === 0
            || $("#material-pollution").val().length === 0 || $("#quantity-recovered").val().length === 0 || $("#quantity-released").val().length === 0) {
            $("#lbl_error_material_line").text("*** Fill out all starred fields");
            return false;
        }

        DELIVERIES = {};

        var id = +$("#material-id").val();
        var release = +$("#material-release").val();
        var release_text = $("#material-release option:selected").text();
        var category = +$("#material-category").val();
        var category_text = $("#material-category option:selected").text();
        var duration = +$("#material-duration").val();
        var pollution = +$("#material-pollution").val();
        var recovered = +$("#quantity-recovered").val();
        var qRelease = +$("#quantity-released").val();

        DELIVERIES.Id = id;
        DELIVERIES.Release = release;
        DELIVERIES.Release_text = release_text;
        DELIVERIES.Category = category;
        DELIVERIES.Category_text = category_text;
        DELIVERIES.Duration = duration;
        DELIVERIES.Pollution = pollution;
        DELIVERIES.Recovered = recovered;
        DELIVERIES.QRelease = qRelease;

        DELIVERY.push(DELIVERIES);


        var table = $("#material-body");

        const i = DELIVERY.length - 1;
        console.log(DELIVERY[i]);

        if (i % 2 === 0) {
            row = "<tr id=material-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=material-body" + i + ">";
        }
        row += "<td style='display:none;class=''>" + DELIVERY[i].Id + "</td>";
        row += "<td class='release-m' style='display: none'>" + DELIVERY[i].Release + "</td>";
        row += "<td>" + DELIVERY[i].Release_text + "</td>";
        row += '<td class="category-m" style="display:none">' + DELIVERY[i].Category + "</td>";
        row += "<td>" + DELIVERY[i].Category_text + "</td>";
        row += "<td class='duration-m'>" + DELIVERY[i].Duration + "</td>";
        row += '<td class="pollution-m">' + DELIVERY[i].Pollution + "</td>";
        row += '<td class="recovered-m">' + DELIVERY[i].Recovered + "</td>";
        row += '<td  class="quantity-released-m">' + DELIVERY[i].QRelease + "</td>";
        row += "<td class='edit' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_material_line").text("");

        $(`#material-body${i} .edit a#editline`).on("click", () => EditMasterLine(i));
        $(`#material-body${i} .edit a#removeline`).on("click", () => RemoveMasterLine(i));
        $(`#material-body${i} .update a#cancelline`).on("click", () => CancelMasterLine(i));
        $(`#material-body${i} .update a#updateline`).on("click", () => UpdateMasterLine(i));

        $('.update').hide();
        ClearLine();

    });

    //materialLineEdit
    function EditMasterLine(i) {
        $('.edit').show();
        $('.update').hide();
        $('.update:eq(' + i + '), .edit:eq(' + i + ')').toggle();

        $("#material-release").val(DELIVERY[i].Release);
        $("#material-category").val(DELIVERY[i].Category);
        $("#material-duration").val(DELIVERY[i].Duration);
        $("#material-pollution").val(DELIVERY[i].Pollution);
        $("#quantity-recovered").val(DELIVERY[i].Recovered);
        $("#quantity-released").val(DELIVERY[i].QRelease);
    }

    //materialLineRemove
    function RemoveMasterLine(j) {

        if (DELIVERY.length >= 1) {
            DELIVERY.splice(j, 1);
        }
        else {
            DELIVERY = [];

        }
        var delivery_table = $("#material-body");
        delivery_table.html("");
        ClearLine();

        for (let i = 0; i < DELIVERY.length; i++) {
            if (i % 2 === 0) {
                row = "<tr id=material-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=material-body" + i + ">";
            }
            row += "<td style='display:none;class=''>" + DELIVERY[i].Id + "</td>";
            row += "<td class='release-m' style='display: none'>" + DELIVERY[i].Release + "</td>";
            row += "<td>" + DELIVERY[i].Release_text + "</td>";
            row += '<td class="category-m" style="display:none">' + DELIVERY[i].Category + "</td>";
            row += "<td>" + DELIVERY[i].Category_text + "</td>";
            row += "<td class='duration-m'>" + DELIVERY[i].Duration + "</td>";
            row += '<td class="pollution-m">' + DELIVERY[i].Pollution + "</td>";
            row += '<td class="recovered-m">' + DELIVERY[i].Recovered + "</td>";
            row += '<td  class="quantity-released-m">' + DELIVERY[i].QRelease + "</td>";
            row += "<td class='edit' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            delivery_table.append(row);

            $(`#material-body${i} .edit a#editline`).on("click", () => EditMasterLine(i));
            $(`#material-body${i} .edit a#removeline`).on("click", () => RemoveMasterLine(i));
            $(`#material-body${i} .update a#cancelline`).on("click", () => CancelMasterLine(i));
            $(`#material-body${i} .update a#updateline`).on("click", () => UpdateMasterLine(i));
            $('.update').hide();
        }
    }

    //materialLineCancel
    function CancelMasterLine(i) {
        $('.update:eq(' + i + '), .edit:eq(' + i + ')').toggle();
        ClearLine();
    }

    //materialLineUpdate
    function UpdateMasterLine(j) {
        DELIVERY[j].Release = $("#material-release").val();
        DELIVERY[j].Release_text = $("#material-release option:selected").text();
        DELIVERY[j].Category = $("#material-category").val();
        DELIVERY[j].Category_text = $("#material-category option:selected").text();
        DELIVERY[j].Duration = $("#material-duration").val();
        DELIVERY[j].Pollution = $("#material-pollution").val();
        DELIVERY[j].Recovered = $("#quantity-recovered").val();
        DELIVERY[j].QRelease = $("#quantity-released").val();

        var delivery_table = $("#material-body");
        delivery_table.html("");

        for (let i = 0; i < DELIVERY.length; i++) {
            if (i % 2 === 0) {
                row = "<tr id=material-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=material-body" + i + ">";
            }
            row += "<td style='display:none;'>" + DELIVERY[i].Id + "</td>";
            row += "<td class='release-m' style='display: none'>" + DELIVERY[i].Release + "</td>";
            row += "<td>" + DELIVERY[i].Release_text + "</td>";
            row += '<td class="category-m" style="display:none">' + DELIVERY[i].Category + "</td>";
            row += "<td>" + DELIVERY[i].Category_text + "</td>";
            row += "<td class='duration-m'>" + DELIVERY[i].Duration + "</td>";
            row += '<td class="pollution-m">' + DELIVERY[i].Pollution + "</td>";
            row += '<td class="recovered-m">' + DELIVERY[i].Recovered + "</td>";
            row += '<td  class="quantity-released-m">' + DELIVERY[i].QRelease + "</td>";
            row += "<td class='edit' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "</tr>";

            delivery_table.append(row);
            $('.update').hide();
            $('.edit').show();

            $(`#material-body${i} .edit a#editline`).on("click", () => EditMasterLine(i));
            $(`#material-body${i} .edit a#removeline`).on("click", () => RemoveMasterLine(i));
            $(`#material-body${i} .update a#cancelline`).on("click", () => CancelMasterLine(i));
            $(`#material-body${i} .update a#updateline`).on("click", () => UpdateMasterLine(i));
        }
        ClearLine();
    }


    //*********************************************************************Seed Line Table
    var DELIVERYLINE = [];
    var DELIVERIESLINES = {};

    $(document).on("click", ".btn-line-save", function () {

        DELIVERIESLINES = {};

        if ($("#line-name").val().length === 0 || $("#line-name").val().length === 0 || $("#line-position").val().length === 0 ||
            $("#line-organization").val().length === 0 || $("#line-type").val() === null) {

            $("#lbl_error_investigate_line").text("*** Fill out all starred fields");
            return false;
        }


        var id = +$("#line-id").val();
        var name = $("#line-name").val();
        var position = $("#line-position").val();
        var organization = $("#line-organization").val();
        var type = +$("#line-type").val();
        var type_text = $("#line-type option:selected").text();

        DELIVERIESLINES.Id = id;
        DELIVERIESLINES.Name = name;
        DELIVERIESLINES.Position = position;
        DELIVERIESLINES.Organization = organization;
        DELIVERIESLINES.LineTypeId = type;
        DELIVERIESLINES.Type_text = type_text;

        DELIVERYLINE.push(DELIVERIESLINES);

        var table = $("#line-body");
        const i = DELIVERYLINE.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=line-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=line-body" + i + ">";
        }
        row += "<td style='display:none';>" + DELIVERYLINE[i].Id + "</td>";
        row += "<td class='name-l'>" + DELIVERYLINE[i].Name + "</td>";
        row += '<td class="position-l">' + DELIVERYLINE[i].Position + "</td>";
        row += "<td class='organization-l'>" + DELIVERYLINE[i].Organization + "</td>";
        row += "<td class='type-l' style='display: none'>" + DELIVERYLINE[i].LineTypeId + "</td>";
        row += "<td>" + DELIVERYLINE[i].Type_text + "</td>";
        row += "<td class='edit-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_investigate_line").text("");

        $(`#line-body${i} .edit-l a#editline`).on("click", () => EditLine(i));
        $(`#line-body${i} .edit-l a#removeline`).on("click", () => RemoveLine(i));
        $(`#line-body${i} .update-l a#cancelline`).on("click", () => CancelLine(i));
        $(`#line-body${i} .update-l a#updateline`).on("click", () => UpdateLine(i));


        $('.update-l').hide();
        ClearLine();

    });

    //investigateLineEdit
    function EditLine(i) {
        $('.edit-l').show();
        $('.update-l').hide();
        $('.update-l:eq(' + i + '), .edit-l:eq(' + i + ')').toggle();

        $("#line-id").val(DELIVERYLINE[i].Id);
        $("#line-name").val(DELIVERYLINE[i].Name);
        $("#line-position").val(DELIVERYLINE[i].Position);
        $("#line-organization").val(DELIVERYLINE[i].Organization);
        $("#line-type").val(DELIVERYLINE[i].LineTypeId);
    }

    //investigateLineRemove
    function RemoveLine(j) {

        if (DELIVERYLINE.length >= 1) {
            DELIVERYLINE.splice(j, 1);
        }
        else {
            DELIVERYLINE = [];

        }
        var delivery_table = $("#line-body");
        delivery_table.html("");
        ClearLine();

        for (let i = 0; i < DELIVERYLINE.length; i++) {
            if (i % 2 === 0) {
                row = "<tr id=line-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=line-body" + i + ">";
            }
            row += "<td style='display:none';>" + DELIVERYLINE[i].Id + "</td>";
            row += "<td class='name-l'>" + DELIVERYLINE[i].Name + "</td>";
            row += '<td class="position-l">' + DELIVERYLINE[i].Position + "</td>";
            row += "<td class='organization-l'>" + DELIVERYLINE[i].Organization + "</td>";
            row += "<td class='type-l' style='display: none'>" + DELIVERYLINE[i].LineTypeId + "</td>";
            row += "<td>" + DELIVERYLINE[i].Type_text + "</td>";
            row += "<td class='edit-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            delivery_table.append(row);

            $(`#line-body${i} .edit-l a#editline`).on("click", () => EditLine(i));
            $(`#line-body${i} .edit-l a#removeline`).on("click", () => RemoveLine(i));
            $(`#line-body${i} .update-l a#cancelline`).on("click", () => CancelLine(i));
            $(`#line-body${i} .update-l a#updateline`).on("click", () => UpdateLine(i));

            ClearLine();
            $('.update-l').hide();
        }
    }

    //investigateLineCancel
    function CancelLine(i) {
        $('.update-l:eq(' + i + '), .edit-l:eq(' + i + ')').toggle();
        ClearLine();
    }

    //investigateLineUpdate
    function UpdateLine(j) {
        DELIVERYLINE[j].Name = $("#line-name").val();
        DELIVERYLINE[j].Position = $("#line-position").val();
        DELIVERYLINE[j].Organization = $("#line-organization").val();
        DELIVERYLINE[j].LineTypeId = $("#line-type").val();
        DELIVERYLINE[j].Type_text = $("#line-type option:selected").text();

        var delivery_table = $("#line-body");
        delivery_table.html("");

        for (let i = 0; i < DELIVERYLINE.length; i++) {
            if (i % 2 === 0) {
                row = "<tr id=line-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=line-body" + i + ">";
            }
            row += "<td style='display:none';>" + DELIVERYLINE[i].Id + "</td>";
            row += "<td class='name-l'>" + DELIVERYLINE[i].Name + "</td>";
            row += '<td class="position-l">' + DELIVERYLINE[i].Position + "</td>";
            row += "<td class='organization-l'>" + DELIVERYLINE[i].Organization + "</td>";
            row += "<td class='type-l' style='display: none'>" + DELIVERYLINE[i].LineTypeId + "</td>";
            row += "<td>" + DELIVERYLINE[i].Type_text + "</td>";
            row += "<td class='edit-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            delivery_table.append(row);

            $(`#line-body${i} .edit-l a#editline`).on("click", () => EditLine(i));
            $(`#line-body${i} .edit-l a#removeline`).on("click", () => RemoveLine(i));
            $(`#line-body${i} .update-l a#cancelline`).on("click", () => CancelLine(i));
            $(`#line-body${i} .update-l a#updateline`).on("click", () => UpdateLine(i));

            ClearLine();
            $('.update-l').hide();
        }
    }


    //*********************************************************************Seed Image Table
    var FILES = [];
    var FILESLINE = {};
    var currentFile;

    //openImageAnotherWindow
    function openWin() {
        window.open($("img#myImage").attr("src"), "_blank");
    }

    $(document).on("click", ".btn-image-save", function () {

        if ($("#image-document").val() === null || $("#image-name").val().length === 0 || $("#customFile").val().length === 0) {
            $("#lbl_error_image_line").text("*** Fill out all starred fields");
            return false;
        }


        FILESLINE = {};

        var id = +$("#image-id").val();
        var document = +$("#image-document").val();
        var document_text = $("#image-document option:selected").text();
        var document_name = $("#image-name").val();
        var attachment = $("#customFile")[0].files[0];


        FILESLINE.Id = id;
        FILESLINE.Document = document;
        FILESLINE.Document_text = document_text;
        FILESLINE.Document_name = document_name;
        FILESLINE.Attachment = attachment;

        var table = $("#image-body");
        FILES.push(FILESLINE);

        const i = FILES.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=image-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=image-body" + i + ">";
        }
        row += "<td style='display:none';>" + FILES[i].Id + "</td>";
        row += "<td class='document-i'  style='display:none'>" + FILES[i].Document + "</td>";
        row += "<td>" + FILES[i].Document_text + "</td>";
        row += '<td class="document-n">' + FILES[i].Document_name + "</td>";
        row += "<td class='image-n'><img id='myImage' style='width: 40px; height: 40px; object-fit: cover' src = " + URL.createObjectURL(FILES[i].Attachment) + " /></td > ";
        row += "<td class='edit-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_image_line").text("");

        $(`#image-body${i} .edit-i a#editline`).on("click", () => EditImageLine(i));
        $(`#image-body${i} .edit-i a#removeline`).on("click", () => RemoveImageLine(i));
        $(`#image-body${i} .update-i a#cancelline`).on("click", () => CancelImageLine(i));
        $(`#image-body${i} .update-i a#updateline`).on("click", () => UpdateImageLine(i));

        $(`#image-body${i} #myImage`).on("click", () => openWin(i));

        $('.update-i').hide();
        ClearLine();

    });

    //insertNameonBrowser
    $('input[type="file"]').change(function (e) {
        var selectedFileName = e.target.files[0].name;
        $(".custom-file-label").text(selectedFileName);
        //  readURL(this);
    });

    //ImageLineEdit
    function EditImageLine(i) {
        $('.edit-i').show();
        $('.update-i').hide();
        $('.update-i:eq(' + i + '), .edit-i:eq(' + i + ')').toggle();

        // $(".custom-file-label").text(FILES[i].Attachment.name);
        currentFile = FILES[i].Attachment;
        $("#image-document").val(FILES[i].Document);
        $("#image-name").val(FILES[i].Document_name);
    }

    //ImageLineRemove
    function RemoveImageLine(j) {

        if (FILES.length >= 1) {
            FILES.splice(j, 1);
        }
        else {
            FILES = [];

        }
        var delivery_table = $("#image-body");
        delivery_table.html("");
        ClearLine();

        for (let i = 0; i < FILES.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=image-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=image-body" + i + ">";
            }
            row += "<td style='display:none';>" + FILES[i].Id + "</td>";
            row += "<td class='document-i'  style='display:none'>" + FILES[i].Document + "</td>";
            row += "<td>" + FILES[i].Document_text + "</td>";
            row += '<td class="document-n">' + FILES[i].Document_name + "</td>";
            row += "<td class='image-n'><img id='myImage' style='width: 40px; height: 40px; object-fit: cover' src=" + URL.createObjectURL(FILES[i].Attachment) + " /></td > ";
            row += "<td class='edit-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            delivery_table.append(row);

            $(`#image-body${i} .edit-i a#editline`).on("click", () => EditImageLine(i));
            $(`#image-body${i} .edit-i a#removeline`).on("click", () => RemoveImageLine(i));
            $(`#image-body${i} .update-i a#cancelline`).on("click", () => CancelImageLine(i));
            $(`#image-body${i} .update-i a#updateline`).on("click", () => UpdateImageLine(i));

            $('.update-i').hide();
            ClearLine();
        }
    }

    //ImageLineCancel
    function CancelImageLine(i) {
        $('.update-i:eq(' + i + '), .edit-i:eq(' + i + ')').toggle();
        ClearLine();
    }

    //ImageLineUpdate
    function UpdateImageLine(j) {
        FILES[j].Document = $("#image-document").val();
        FILES[j].Document_text = $("#image-document option:selected").text();
        FILES[j].Document_name = $("#image-name").val();
        FILES[j].Attachment = $("#customFile")[0].files[0] || currentFile;

        var delivery_table = $("#image-body");
        delivery_table.html("");

        for (let i = 0; i < FILES.length; i++) {

            console.log(FILES);

            if (i % 2 === 0) {
                row = "<tr id=image-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=image-body" + i + ">";
            }
            row += "<td style='display:none';>" + FILES[i].Id + "</td>";
            row += "<td class='document-i'  style='display:none'>" + FILES[i].Document + "</td>";
            row += "<td>" + FILES[i].Document_text + "</td>";
            row += '<td class="document-n">' + FILES[i].Document_name + "</td>";
            row += "<td class='image-n'><img id='myImage' style='width: 40px; height: 40px; object-fit: cover' src=" + URL.createObjectURL(FILES[i].Attachment) + " /></td > ";
            row += "<td class='edit-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            delivery_table.append(row);
            $(`#image-body${i} .edit-i a#editline`).on("click", () => EditImageLine(i));
            $(`#image-body${i} .edit-i a#removeline`).on("click", () => RemoveImageLine(i));
            $(`#image-body${i} .update-i a#cancelline`).on("click", () => CancelImageLine(i));
            $(`#image-body${i} .update-i a#updateline`).on("click", () => UpdateImageLine(i));


            $(`#image-body${i} #myImage`).on("click", () => openWin(i));


            $('.update-i').hide();
            ClearLine();
        }
    }

    //*********************************************************************FORM SUBMIT SEND DATA TO DB
    var ID;
    $('.clicked-table').on('click', 'tbody tr', function (event) {
        $(this).toggleClass('selected').siblings().removeClass("selected");
        ID = $(this).data('id');
        $("#inv-id").val(ID);
    });

    $('#investigate-form').submit((e) => {
      
        if ($("#inv-position").val().length === 0 || $("#inv-name").val().length === 0 ||  $("#inv-date").val().length === ""  || $("#inv-time").val().length === 0
            || $("#inv-area").val().length === 0 || $("#inv-activity").val().length === 0 || $("#inv-occurenceReason").val().length === 0
            || $("#inv-occurenceType").val().length === 0 || $("#inv-wheatherType").val().length === 0 || $("#inv-ground").val().length === 0
            || $("#inv-groundCondition").val().length === 0 || $("#inv-illumination").val().length === 0 || $("#inv-contact").val().length === 0
            || $("#inv-injury").val().length === 0 || $("#inv-ilness").val().length === 0 || $("#inv-bodily").val().length === 0
            || $("#inv-injuredAction").val().length === 0 || $("#inv-release").val().length === 0 || $("#inv-releaseToType").val().length === 0
            || $("#inv-safeFact").val().length === 0 || $("#inv-safeCondition").val().length === 0 || $("#descriptionIncident").val().length === 0
            || $("#inv-descriptionImmediate").val().length === 0) {
            $("#lbl_error_investigate").text("*** Fill out all starred fields");
            return false;
        }
        e.preventDefault(); 
        const formData = GetFormData();

        $.ajax({
            url: '/Investigate/CreateInvestigate',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            beforeSend: function () {
                $('.spinner-border').removeClass('d-none');
            },
            success: (response) => {
                $("#ModalHide").modal('hide');

                location.reload();
            },
            error: (error) => {
                $("#progressBar").hide();
                console.log(error);
            }
        });
    });



    function GetFormData() {
        let formData = new FormData();

        var UnSafeConditionTypeId = [];
        $('#inv-safeCondition :selected').each(function (i, selected) {
            UnSafeConditionTypeId[i] = $(selected).val();
        });

        var UnSafeFactTypeId = [];
        $('#inv-safeFact :selected').each(function (i, selected) {
            UnSafeFactTypeId[i] = $(selected).val();
        });



        formData.append('model.Id', $('#inv-id').val());
        formData.append('model.no', $('#inv-no').val());
        formData.append('model.name', $('#inv-name').val());
        formData.append('model.position', $('#inv-position').val());
        formData.append('model.dateTime', $('#inv-date').val());
        formData.append('model.time', $('#inv-time').val());
        formData.append('model.area', $('#inv-area').val());
        formData.append('model.activity', $('#inv-activity').val());
        formData.append('model.occurenceReasonId', $('#inv-occurenceReason').val());
        formData.append('model.occurenceTypeId', $('#inv-occurenceType').val());
        formData.append('model.wheatherTypeId', $('#inv-wheatherType').val());
        formData.append('model.groundTypeId', $('#inv-ground').val());
        formData.append('model.groundConditionTypeId', $('#inv-groundCondition').val());
        formData.append('model.illuminationTypeId', $('#inv-illumination').val());
        formData.append('model.contactTypeId', $('#inv-contact').val());
        formData.append('model.injuryTypeId', $('#inv-injury').val());
        formData.append('model.ilnessTypeId', $('#inv-ilness').val());
        formData.append('model.bodilyLocationTypeId', $('#inv-bodily').val());
        formData.append('model.injuredActionTypeId', $('#inv-injuredAction').val());
        formData.append('model.releaseTypeId', $('#inv-releaseToType').val());
        formData.append('model.releasedToTypeId', $('#inv-release').val());
        for (var f = 0; f < UnSafeFactTypeId.length; f++) {
            formData.append(`model.unSafeFactTypeId[]`, UnSafeFactTypeId[f]);
        }
        for (var e = 0; e < UnSafeConditionTypeId.length; e++) {
            formData.append(`model.UnSafeConditionTypeId[]`, UnSafeConditionTypeId[e]);
        }
        formData.append('model.descriptionIncident', $('#descriptionIncident').val());
        formData.append('model.descriptionImmediate', $('#inv-descriptionImmediate').val());



        for (var i = 0; i < $("#material-body tr").length; i++) {
            formData.append(`model.Materials[${i}].MaterialReleasedId`, +$(".release-m").eq(i).text());
            formData.append(`model.Materials[${i}].MaterialCategoryId`, +$(".category-m").eq(i).text());
            formData.append(`model.Materials[${i}].Duration`, +$(".duration-m").eq(i).text());
            formData.append(`model.Materials[${i}].Pollution`, $(".pollution-m").eq(i).text());
            formData.append(`model.Materials[${i}].QuantityRecovered`, $(".recovered-m").eq(i).text());
            formData.append(`model.Materials[${i}].QuantityReleased`, $(".quantity-released-m").eq(i).text());
        }

        for (i = 0; i < $("#line-body tr").length; i++) {
            formData.append(`model.InvestigateLines[${i}].Name`, $(".name-l").eq(i).text());
            formData.append(`model.InvestigateLines[${i}].Position`, $(".position-l").eq(i).text());
            formData.append(`model.InvestigateLines[${i}].Organization`, $(".organization-l").eq(i).text());
            formData.append(`model.InvestigateLines[${i}].LineTypeId`, +$(".type-l").eq(i).text());
        }


        for (i = 0; i < $("#image-body tr").length; i++) {
            formData.append(`model.Images[${i}].DocumentTypeId`, +$(".document-i").eq(i).text());
            formData.append(`model.Images[${i}].DocumentName`, $(".document-n").eq(i).text());
            formData.append(`model.Images[${i}].Photo`, FILES[i].Attachment);
        }

        return formData;

     

    }

    //*********************************************************************FORM EDIT


    function EditData() {
        var inv_id = $("#inv-id").val();
       
        if (inv_id === "" || inv_id === "0") {
            alert("You must choose the row!");
            return false;
        }
        $.ajax({
            type: "Post",
            url: "/Investigate/Edit/" + inv_id,
            success: function (result) {
                $(JSON.parse(result)).each(function (index, item) {
                    $("#inv-id").val(item.Id);
                    $("#inv-name").val(item.Name);
                    $("#inv-no").val(item.No);
                    $("#inv-position").val(item.Position);
                    $("#inv-date").val(formatDate(item.DateTime));
                    $("#inv-time").val(item.Time);
                    $("#inv-area").val(item.Area);
                    $("#inv-activity").val(item.Activity);
                    $("#inv-occurenceReason").val(item.OccurenceReasonId);
                    $("#inv-occurenceType").val(item.OccurenceTypeId);
                    $("#inv-wheatherType").val(item.WheatherTypeId);
                    $("#inv-ground").val(item.GroundTypeId);
                    $("#inv-groundCondition").val(item.GroundConditionTypeId);
                    $("#inv-illumination").val(item.IlluminationTypeId);
                    $("#inv-contact").val(item.ContactTypeId);
                    $("#inv-injury").val(item.InjuryTypeId);
                    $("#inv-ilness").val(item.IlnessTypeId);
                    $("#inv-bodily").val(item.BodilyLocationTypeId);
                    $("#inv-injuredAction").val(item.InjuredActionTypeId);
                    $("#inv-release").val(item.ReleaseTypeId);
                    $("#inv-releaseToType").val(item.ReleasedToTypeId);
                    $("#inv-safeFact").val(item.UnSafeFactType.UnSafeFactTypeId);
                    $("#inv-safeCondition").val(item.UnSafeConditionType.UnSafeConditionTypeId);
                    $("#descriptionIncident").val(item.DescriptionIncident);
                    $("#inv-descriptionImmediate").val(item.DescriptionImmediate);
                    DeliverMaterialLineFill_edit(item.Id);
                    DeliverLineFill_edit(item.Id);
                    FilesFill_edit(item.Id);
                    $("#ModalHide").modal('show');
                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function DeliverMaterialLineFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                mline_id: ID
            },
            url: "/Investigate/DeliverMaterialLineFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#material-body");
                delivery_table.html("");

                function MaterialLine(Id, Release, Release_text, Category, Category_text, Duration, Pollution, Recovered, QRelease) {
                    this.Id = Id;
                    this.Release = Release;
                    this.Release_text = Release_text;
                    this.Category = Category;
                    this.Category_text = Category_text;
                    this.Duration = Duration;
                    this.Pollution = Pollution;
                    this.Recovered = Recovered;
                    this.QRelease = QRelease;
                }

                $(JSON.parse(result)).each(function (index, item) {
                    var dlvline = new MaterialLine(item.Id, item.MaterialReleasedId, item.MaterialReleased.Name, item.MaterialCategoryId, item.MaterialCategory.Name, item.Duration, item.Pollution, item.QuantityRecovered, item.QuantityReleased);
                    DELIVERY.push(dlvline);

                    const i = DELIVERY.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=material-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=material-body" + i + ">";
                    }
                    row += "<td style='display:none;class=''>" + DELIVERY[i].Id + "</td>";
                    row += "<td class='release-m' style='display: none'>" + DELIVERY[i].Release + "</td>";
                    row += "<td>" + DELIVERY[i].Release_text + "</td>";
                    row += '<td class="category-m" style="display:none">' + DELIVERY[i].Category + "</td>";
                    row += "<td>" + DELIVERY[i].Category_text + "</td>";
                    row += "<td class='duration-m'>" + DELIVERY[i].Duration + "</td>";
                    row += '<td class="pollution-m">' + DELIVERY[i].Pollution + "</td>";
                    row += '<td class="recovered-m">' + DELIVERY[i].Recovered + "</td>";
                    row += '<td  class="quantity-released-m">' + DELIVERY[i].QRelease + "</td>";
                    row += "<td class='edit' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);


                    $(`#material-body${i} .edit a#editline`).on("click", () => EditMasterLine(i));
                    $(`#material-body${i} .edit a#removeline`).on("click", () => RemoveMasterLine(i));
                    $(`#material-body${i} .update a#cancelline`).on("click", () => CancelMasterLine(i));
                    $(`#material-body${i} .update a#updateline`).on("click", () => UpdateMasterLine(i));

                    $('.update').hide();
                    ClearLine();

                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function DeliverLineFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                mline_id: ID
            },
            url: "/Investigate/DeliverLineFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#line-body");
                delivery_table.html("");

                function InvestigateLine(Id, Name, Position, Organization, LineTypeId, Type_text) {
                    this.Id = Id;
                    this.Name = Name;
                    this.Position = Position;
                    this.Organization = Organization;
                    this.LineTypeId = LineTypeId;
                    this.Type_text = Type_text;
                }

                $(JSON.parse(result)).each(function (index, item) {

                    var dlvline = new InvestigateLine(item.Id, item.Name, item.Position, item.Organization, item.LineTypeId, item.LineType.Name);
                    DELIVERYLINE.push(dlvline);
                    const i = DELIVERYLINE.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=line-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=line-body" + i + ">";
                    }
                    row += "<td style='display:none';>" + DELIVERYLINE[i].Id + "</td>";
                    row += "<td class='name-l'>" + DELIVERYLINE[i].Name + "</td>";
                    row += "<td class='position-l'>" + DELIVERYLINE[i].Position + "</td>";
                    row += "<td class='organization-l'>" + DELIVERYLINE[i].Organization + "</td>";
                    row += "<td class='type-l' style='display:none'>" + DELIVERYLINE[i].LineTypeId + "</td>";
                    row += "<td>" + DELIVERYLINE[i].Type_text + "</td>";
                    row += "<td class='edit-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-l' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "</tr>";

                    delivery_table.append(row);

                    $(`#line-body${i} .edit-l a#editline`).on("click", () => EditLine(i));
                    $(`#line-body${i} .edit-l a#removeline`).on("click", () => RemoveLine(i));
                    $(`#line-body${i} .update-l a#cancelline`).on("click", () => CancelLine(i));
                    $(`#line-body${i} .update-l a#updateline`).on("click", () => UpdateLine(i));

                    $('.update-l').hide();
                    ClearLine();

                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function FilesFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                files_id: ID
            },
            url: "/Investigate/FilesFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#image-body");
                delivery_table.html("");

                function FilesLine(Id, Document, Document_text, Document_name, Attachment) {
                    this.Id = Id;
                    this.Document = Document;
                    this.Document_text = Document_text;
                    this.Document_name = Document_name;
                    this.Attachment = new File([Attachment], `../images/${Attachment}`);
                }

                $(JSON.parse(result)).each(function (index, item) {

                    var dlvline = new FilesLine(item.Id, item.DocumentTypeId, item.DocumentType.Name, item.DocumentName, item.Attachment);
                    FILES.push(dlvline);

                    const i = FILES.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=image-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=image-body" + i + ">";
                    }
                    row += "<td style='display:none';>" + FILES[i].Id + "</td>";
                    row += "<td class='document-i'  style='display:none'>" + FILES[i].Document + "</td>";
                    row += "<td>" + FILES[i].Document_text + "</td>";
                    row += '<td class="document-n">' + FILES[i].Document_name + "</td>";
                    row += "<td class='image-n'><img id='myImage' style='width: 40px; height: 40px' src=" + FILES[i].Attachment.name + " /></td > ";
                    row += "<td class='edit-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-i' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);

                    $(`#image-body${i} .edit-i a#editline`).on("click", () => EditImageLine(i));
                    $(`#image-body${i} .edit-i a#removeline`).on("click", () => RemoveImageLine(i));
                    $(`#image-body${i} .update-i a#cancelline`).on("click", () => CancelImageLine(i));
                    $(`#image-body${i} .update-i a#updateline`).on("click", () => UpdateImageLine(i));

                    $(`#image-body${i} #myImage`).on("click", () => openWin(i));

                    $('.update-i').hide();
                    ClearLine();

                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }

    //**************************************DELETE (cahnge status from 1 to 0)
    function DelData() {
        $.ajax({
            type: "Get",
            data: {
                doc_id: ID
            },
            url: "/Investigate/Delete/" + ID,
            success: function (result) {
                alert("Are you sure to delete this record?");
                window.location.replace('/Investigate/Index');
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }

    function CompleteData() {
        $.ajax({
            type: "Get",
            data: {
                doc_id: ID
            },
            url: "/Investigate/CompleteIncident/" + ID,
            beforeSend: function () {
                $('.spinner-border').removeClass('d-none');
            },
            success: function (result) {
                alert("Are you sure to complete and save changes for this report?");
                window.location.replace('/Investigate/Index');
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }


});