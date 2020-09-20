$(document).ready(function () {

    //*********************************************************** Common Jq


    $(`.itemAdminClick`).on("click", () => EditData());
    $(`.itemAdminAdd`).on("click", () => AddData());
    $(`.itemAdminDel`).on("click", () => DelData());
    $(`.itemPrint`).on("click", () => printData());
    $(`.CompleteStsAdmn`).on("click", () => CompleteDataAdmin());

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
            url: '/Investigate/GetAutoNomIncrement',
            dataType: "json",
            success: function (data) {
                $("#Uinv-no").val(data);
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
        $("#event-date").val(formatDate(now));
        $("#prevent-date").val(formatDate(now));
        $("#evalition-date").val(formatDate(now));
    }

    function resetAllControl() {
        $("#Uinv-id").val("0");
        $("#team-id").val("0");
        $("#event-id").val("0");
        $("#prevent-id").val("0");
        $("#evalition-id").val("0");
        $("#statetment-id").val("0");
        $("#inv-cause").val("0");
        $("#inv-people").val("0");
        $("#inv-property").val("0");
        $("#inv-enviroment").val("0");
        $("#inv-buisness").val("0");
        $("#inv-possiblePeople").val("0");
        $("#inv-possibleProperty").val("0");
        $("#inv-possibleEnviroment").val("0");
        $("#inv-possibleBuisness").val("0");
        $("#inv-possibleBuisness").val("0");
        $("#inv-lesson").val("0");
        $("#event-brief").val("");
        $("#event-explain").val("");
        $("#event-identity").val("");
        $("#event-date").val("");


        $("#team-name").val("");
        $("#team-position").val("");
        $("#team-organization").val("");
        $("#team-type").val("0");

        $("#event-time").val("");
        $("#event-descrption").val("");
        $("#event-comments").val("");
        $("#event-date").val("");


        $("#prevent-action").val("");
        $("#prevent-person").val("");

        $("#evalition-note").val("");

        $("#statetment-document").val("");
        $("#statetment-name").val("");

        $("#lbl_error_investigate_team").text("");
        $("#lbl_error_investigate_nom_line").text("");
        $("#lbl_error_event_line").text("");
        $("#lbl_error_prevent_line").text("");
        $("#lbl_error_evalition_line").text("");
        $("#lbl_error_statetment_image_line").text("");


        NOMINATED = [];
        EVENT = [];
        PREVENT = [];
        EVALUTION = [];
        STATEMENT = [];

        var nominate_table = $("#nominated-body");
        nominate_table.html("");
        var event_table = $("#event-body");
        event_table.html("");
        var prevent_table = $("#prevent-body");
        prevent_table.html("");
        var evalition_table = $("#evalition-body");
        evalition_table.html("");
        var statetment_table = $("#statetment-body");
        statetment_table.html("");
    }

    function ClearLine() {
        $("#team-id").val("");
        $("#team-name").val("");
        $("#team-position").val("");
        $("#team-organization").val("");
        $("#team-type").val("");

        $("#event-id").val("");
        $("#event-time").val("");
        $("#event-descrption").val("");
        $("#event-comment").val("");
        $("#event-date").val("");

        $("#prevent-id").val("");
        $("#prevent-action").val("");
        $("#prevent-person").val("");

        $("#evalition-id").val("");
        $("#evalition-note").val("");

        $("#statetment-id").val("");
        $("#statetment-document").val("");
        $("#statetment-name").val("");
        $("#statetmentFile").val("");
        $(".statetmentFile-file-label").text("");
    }

    //*********************************************************************Seed Nominate Table

    var NOMINATED = [];
    var NOMINATEDS = {};

    $(document).on("click", ".btn-nom-save", function () {

        if ($("#team-name").val() === 0 || $("#team-position").val() === 0 || $("#team-organization").val().length === 0
            || $("#team-type").val().length === null) {
            $("#lbl_error_investigate_nom_line").text("*** Fill out all starred fields");
            return false;
        }

        NOMINATEDS = {};

        var id = +$("#team-id").val();
        var name = $("#team-name").val();
        var position = $("#team-position").val();
        var organization = $("#team-organization").val();
        var team_type = +$("#team-type").val();
        var team_type_text = $("#team-type option:selected").text();

        NOMINATEDS.Id = id;
        NOMINATEDS.Name = name;
        NOMINATEDS.Position = position;
        NOMINATEDS.Organization = organization;
        NOMINATEDS.TeamType = team_type;
        NOMINATEDS.TeamType_text = team_type_text;


        NOMINATED.push(NOMINATEDS);


        var table = $("#nominated-body");

        const i = NOMINATED.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=nominated-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=nominated-body" + i + ">";
        }
        row += "<td style='display:none;'>" + NOMINATED[i].Id + "</td>";
        row += '<td class="name-n">' + NOMINATED[i].Name + "</td>";
        row += '<td class="position-n">' + NOMINATED[i].Position + "</td>";
        row += "<td class='organization-n'>" + NOMINATED[i].Organization + "</td>";
        row += "<td class='type-n' style='display: none'>" + NOMINATED[i].TeamType + "</td>";
        row += "<td>" + NOMINATED[i].TeamType_text + "</td>";
        row += "<td class='edit-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_investigate_nom_line").text("");

        $(`#nominated-body${i} .edit-n a#editline`).on("click", () => EditNominateLine(i));
        $(`#nominated-body${i} .edit-n a#removeline`).on("click", () => RemoveNominateLine(i));
        $(`#nominated-body${i} .update-n a#cancelline`).on("click", () => CancelNominateLine(i));
        $(`#nominated-body${i} .update-n a#updateline`).on("click", () => UpdateNominateLine(i));

        $('.update-n').hide();
        ClearLine();
    });

    //nominateLineEdit
    function EditNominateLine(i) {
        $('.edit-n').show();
        $('.update-n').hide();
        $('.update-n:eq(' + i + '), .edit-n:eq(' + i + ')').toggle();

        $("#team-id").val(NOMINATED[i].Id);
        $("#team-name").val(NOMINATED[i].Name);
        $("#team-position").val(NOMINATED[i].Position);
        $("#team-organization").val(NOMINATED[i].Organization);
        $("#team-type").val(NOMINATED[i].TeamType);
    }

    //nominateLineRemove
    function RemoveNominateLine(j) {

        if (NOMINATED.length >= 1) {
            NOMINATED.splice(j, 1);
        }
        else {
            NOMINATED = [];

        }
        var nominate_table = $("#nominated-body");
        nominate_table.html("");
        ClearLine();

        for (let i = 0; i < NOMINATED.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=nominated-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=nominated-body" + i + ">";
            }
            row += "<td style='display:none;'>" + NOMINATED[i].Id + "</td>";
            row += '<td class="name-n">' + NOMINATED[i].Name + "</td>";
            row += '<td class="position-n">' + NOMINATED[i].Position + "</td>";
            row += "<td class='organization-n'>" + NOMINATED[i].Organization + "</td>";
            row += "<td class='type-n' style='display: none'>" + NOMINATED[i].TeamType + "</td>";
            row += "<td>" + NOMINATED[i].TeamType_text + "</td>";
            row += "<td class='edit-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            nominate_table.append(row);

            $(`#nominated-body${i} .edit-n a#editline`).on("click", () => EditNominateLine(i));
            $(`#nominated-body${i} .edit-n a#removeline`).on("click", () => RemoveNominateLine(i));
            $(`#nominated-body${i} .update-n a#cancelline`).on("click", () => CancelNominateLine(i));
            $(`#nominated-body${i} .update-n a#updateline`).on("click", () => UpdateNominateLine(i));

            ClearLine();
            $('.update-n').hide();
        }
    }

    //nominateLineCancel
    function CancelNominateLine(i) {
        $('.update-n:eq(' + i + '), .edit-n:eq(' + i + ')').toggle();
        ClearLine();
    }

    //nominateLineUpdate
    function UpdateNominateLine(j) {
        NOMINATED[j].Name = $("#team-name").val();
        NOMINATED[j].Position = $("#team-position").val();
        NOMINATED[j].Organization = $("#team-organization").val();
        NOMINATED[j].TeamType = $("#team-type").val();
        NOMINATED[j].TeamType_text = $("#team-type option:selected").text();

        var nominate_table = $("#nominated-body");
        nominate_table.html("");


        for (let i = 0; i < NOMINATED.length; i++) {
            if (i % 2 === 0) {
                row = "<tr id=nominated-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=nominated-body" + i + ">";
            }
            row += "<td style='display:none;'>" + NOMINATED[i].Id + "</td>";
            row += '<td class="name-n">' + NOMINATED[i].Name + "</td>";
            row += '<td class="position-n">' + NOMINATED[i].Position + "</td>";
            row += "<td class='organization-n'>" + NOMINATED[i].Organization + "</td>";
            row += "<td class='type-n' style='display: none'>" + NOMINATED[i].TeamType + "</td>";
            row += "<td>" + NOMINATED[i].TeamType_text + "</td>";
            row += "<td class='edit-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            nominate_table.append(row);

            $(`#nominated-body${i} .edit-n a#editline`).on("click", () => EditNominateLine(i));
            $(`#nominated-body${i} .edit-n a#removeline`).on("click", () => RemoveNominateLine(i));
            $(`#nominated-body${i} .update-n a#cancelline`).on("click", () => CancelNominateLine(i));
            $(`#nominated-body${i} .update-n a#updateline`).on("click", () => UpdateNominateLine(i));

            ClearLine();
            $('.update-n').hide();
        }
    }


    //*********************************************************************Seed Evenet Table

    var EVENT = [];
    var EVENTS = {};

    $(document).on("click", ".btn-event-save", function () {

        if ($("#event-date").val() === 0 || $("#event-time").val() === 0 || $("#event-descrption").val().length === 0
            || $("#event-comment").val().length === null) {
            $("#lbl_error_event_line").text("*** Fill out all starred fields");
            return false;
        }

        EVENTS = {};

        var id = +$("#event-id").val();
        var date = $("#event-date").val();
        var time = $("#event-time").val();
        var descrption = $("#event-descrption").val();
        var comment = $("#event-comment").val();

        EVENTS.Id = id;
        EVENTS.Date = date;
        EVENTS.Time = time;
        EVENTS.Description = descrption;
        EVENTS.Comment = comment;


        EVENT.push(EVENTS);


        var table = $("#event-body");

        const i = EVENT.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=event-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=event-body" + i + ">";
        }
        row += "<td style='display:none;'>" + EVENT[i].Id + "</td>";
        row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
        row += '<td class="date-e">' + EVENT[i].Date + "</td>";
        row += '<td class="time-e">' + EVENT[i].Time + "</td>";
        row += "<td class='decription-e'>" + EVENT[i].Description + "</td>";
        row += "<td class='comment-e'>" + EVENT[i].Comment + "</td>";
        row += "<td class='edit-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_event_line").text("");

        $(`#event-body${i} .edit-e a#editline`).on("click", () => EditEventLine(i));
        $(`#event-body${i} .edit-e a#removeline`).on("click", () => RemoveEventLine(i));
        $(`#event-body${i} .update-e a#cancelline`).on("click", () => CancelEventLine(i));
        $(`#event-body${i} .update-e a#updateline`).on("click", () => UpdateEventLine(i));

        $('.update-e').hide();
        ClearLine();
    });

    //EventLineEdit
    function EditEventLine(i) {
        $('.edit-e').show();
        $('.update-e').hide();
        $('.update-e:eq(' + i + '), .edit-e:eq(' + i + ')').toggle();

        $("#event-id").val(EVENT[i].Id);
        $("#event-date").val(EVENT[i].Date.substr(0, 10));
        $("#event-time").val(EVENT[i].Time);
        $("#event-descrption").val(EVENT[i].Description);
        $("#event-comment").val(EVENT[i].Comment);

    }

    //eventLineRemove
    function RemoveEventLine(j) {

        if (EVENT.length >= 1) {
            EVENT.splice(j, 1);
        }
        else {
            EVENT = [];

        }
        var table = $("#event-body");
        table.html("");
        ClearLine();

        for (let i = 0; i < EVENT.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=event-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=event-body" + i + ">";
            }
            row += "<td style='display:none;'>" + EVENT[i].Id + "</td>";
            row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
            row += '<td class="date-e">' + EVENT[i].Date + "</td>";
            row += '<td class="time-e">' + EVENT[i].Time + "</td>";
            row += "<td class='decription-e'>" + EVENT[i].Description + "</td>";
            row += "<td class='comment-e'>" + EVENT[i].Comment + "</td>";
            row += "<td class='edit-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $(`#event-body${i} .edit-e a#editline`).on("click", () => EditEventLine(i));
            $(`#event-body${i} .edit-e a#removeline`).on("click", () => RemoveEventLine(i));
            $(`#event-body${i} .update-e a#cancelline`).on("click", () => CancelEventLine(i));
            $(`#event-body${i} .update-e a#updateline`).on("click", () => UpdateEventLine(i));

            ClearLine();
            $('.update-e').hide();
        }
    }

    //EventLineCancel
    function CancelEventLine(i) {
        $('.update-e:eq(' + i + '), .edit-e:eq(' + i + ')').toggle();
        ClearLine();
    }

    //eventLineUpdate
    function UpdateEventLine(j) {
        EVENT[j].Date = $("#event-date").val();
        EVENT[j].Time = $("#event-time").val();
        EVENT[j].Description = $("#event-descrption").val();
        EVENT[j].Comment = $("#event-comment").val();

        var table = $("#event-body");
        table.html("");


        for (let i = 0; i < EVENT.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=event-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=event-body" + i + ">";
            }
            row += "<td style='display:none;'>" + EVENT[i].Id + "</td>";
            row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
            row += '<td class="date-e">' + EVENT[i].Date + "</td>";
            row += '<td class="time-e">' + EVENT[i].Time + "</td>";
            row += "<td class='decription-e'>" + EVENT[i].Description + "</td>";
            row += "<td class='comment-e'>" + EVENT[i].Comment + "</td>";
            row += "<td class='edit-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $(`#event-body${i} .edit-e a#editline`).on("click", () => EditEventLine(i));
            $(`#event-body${i} .edit-e a#removeline`).on("click", () => RemoveEventLine(i));
            $(`#event-body${i} .update-e a#cancelline`).on("click", () => CancelEventLine(i));
            $(`#event-body${i} .update-e a#updateline`).on("click", () => UpdateEventLine(i));

            ClearLine();
            $('.update-e').hide();
        }
    }


    //*********************************************************************Seed Prevent Table

    var PREVENT = [];
    var PREVENTS = {};

    $(document).on("click", ".btn-prevent-save", function () {

        if ($("#prevent-action").val().length === 0 || $("#prevent-person").val().length === 0 || $("#prevent-date").val().length === 0) {
            $("#lbl_error_prevent_line").text("*** Fill out all starred fields");
            return false;
        }

        PREVENTS = {};

        var id = +$("#prevent-id").val();
        var action = $("#prevent-action").val();
        var person = $("#prevent-person").val();
        var date = $("#prevent-date").val();

        PREVENTS.Id = id;
        PREVENTS.Action = action;
        PREVENTS.Person = person;
        PREVENTS.Date = date;


        PREVENT.push(PREVENTS);



        var table = $("#prevent-body");

        const i = PREVENT.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=prevent-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=prevent-body" + i + ">";
        }
        row += "<td style='display:none;'>" + PREVENT[i].Id + "</td>";
        row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
        row += '<td class="action-p">' + PREVENT[i].Action + "</td>";
        row += '<td class="person-p">' + PREVENT[i].Person + "</td>";
        row += "<td class='date-p'>" + PREVENT[i].Date + "</td>";
        row += "<td class='edit-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_prevent_line").text("");

        $(`#prevent-body${i} .edit-p a#editline`).on("click", () => EditPreventLine(i));
        $(`#prevent-body${i} .edit-p a#removeline`).on("click", () => RemovePreventLine(i));
        $(`#prevent-body${i} .update-p a#cancelline`).on("click", () => CancelPreventLine(i));
        $(`#prevent-body${i} .update-p a#updateline`).on("click", () => UpdatePreventLine(i));

        $('.update-p').hide();
        ClearLine();
    });

    //PreventLineEdit
    function EditPreventLine(i) {
        $('.edit-p').show();
        $('.update-p').hide();
        $('.update-p:eq(' + i + '), .edit-p:eq(' + i + ')').toggle();

        $("#prevent-id").val(PREVENT[i].Id);
        $("#prevent-action").val(PREVENT[i].Action);
        $("#prevent-person").val(PREVENT[i].Person);
        $("#prevent-date").val(PREVENT[i].Date.substr(0, 10));
    }

    //preventLineRemove
    function RemovePreventLine(j) {

        if (PREVENT.length >= 1) {
            PREVENT.splice(j, 1);
        }
        else {
            PREVENT = [];

        }
        var table = $("#prevent-body");
        table.html("");
        ClearLine();

        for (let i = 0; i < PREVENT.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=prevent-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=prevent-body" + i + ">";
            }
            row += "<td style='display:none;'>" + PREVENT[i].Id + "</td>";
            row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
            row += '<td class="action-p">' + PREVENT[i].Action + "</td>";
            row += '<td class="person-p">' + PREVENT[i].Person + "</td>";
            row += "<td class='date-p'>" + PREVENT[i].Date + "</td>";
            row += "<td class='edit-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $("#lbl_error_prevent_line").text("");

            $(`#prevent-body${i} .edit-p a#editline`).on("click", () => EditPreventLine(i));
            $(`#prevent-body${i} .edit-p a#removeline`).on("click", () => RemovePreventLine(i));
            $(`#prevent-body${i} .update-p a#cancelline`).on("click", () => CancelPreventLine(i));
            $(`#prevent-body${i} .update-p a#updateline`).on("click", () => UpdatePreventLine(i));

            $('.update-p').hide();
            ClearLine();
        }
    }

    //PreventLineCancel
    function CancelPreventLine(i) {
        $('.update-p:eq(' + i + '), .edit-p:eq(' + i + ')').toggle();
        ClearLine();
    }

    //preventLineUpdate
    function UpdatePreventLine(j) {
        PREVENT[j].Action = $("#prevent-action").val();
        PREVENT[j].Person = $("#prevent-person").val();
        PREVENT[j].Date = $("#prevent-date").val();

        var table = $("#prevent-body");
        table.html("");


        for (let i = 0; i < PREVENT.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=prevent-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=prevent-body" + i + ">";
            }
            row += "<td style='display:none;'>" + PREVENT[i].Id + "</td>";
            row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
            row += '<td class="action-p">' + PREVENT[i].Action + "</td>";
            row += '<td class="person-p">' + PREVENT[i].Person + "</td>";
            row += "<td class='date-p'>" + PREVENT[i].Date + "</td>";
            row += "<td class='edit-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $("#lbl_error_prevent_line").text("");

            $(`#prevent-body${i} .edit-p a#editline`).on("click", () => EditPreventLine(i));
            $(`#prevent-body${i} .edit-p a#removeline`).on("click", () => RemovePreventLine(i));
            $(`#prevent-body${i} .update-p a#cancelline`).on("click", () => CancelPreventLine(i));
            $(`#prevent-body${i} .update-p a#updateline`).on("click", () => UpdatePreventLine(i));

            $('.update-p').hide();
            ClearLine();
        }
    }


    //*********************************************************************Seed Evalution Table

    var EVALUTION = [];
    var EVALUTIONS = {};

    $(document).on("click", ".btn-evalition-save", function () {

        if ($("#evalition-note").val().length === 0 || $("#evalition-date").val().length === 0) {
            $("#lbl_error_evalition_line").text("*** Fill out all starred fields");
            return false;
        }

        EVALUTIONS = {};

        var id = +$("#evalition-id").val();
        var note = $("#evalition-note").val();
        var date = $("#evalition-date").val();

        EVALUTIONS.Id = id;
        EVALUTIONS.Note = note;
        EVALUTIONS.Date = date;


        EVALUTION.push(EVALUTIONS);

        var table = $("#evalition-body");

        const i = EVALUTION.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=evalition-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=evalition-body" + i + ">";
        }
        row += "<td style='display:none;'>" + EVALUTION[i].Id + "</td>";
        row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
        row += '<td class="note-ev">' + EVALUTION[i].Note + "</td>";
        row += "<td class='date-ev'>" + EVALUTION[i].Date + "</td>";
        row += "<td class='edit-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_evalition_line").text("");

        $(`#evalition-body${i} .edit-ev a#editline`).on("click", () => EditEvalitionLine(i));
        $(`#evalition-body${i} .edit-ev a#removeline`).on("click", () => RemoveEvalitionLine(i));
        $(`#evalition-body${i} .update-ev a#cancelline`).on("click", () => CancelEvalitionLine(i));
        $(`#evalition-body${i} .update-ev a#updateline`).on("click", () => UpdateEvalitionLine(i));

        $('.update-ev').hide();
        ClearLine();
    });

    //evalitionLineEdit
    function EditEvalitionLine(i) {
        $('.edit-ev').show();
        $('.update-ev').hide();
        $('.update-ev:eq(' + i + '), .edit-ev:eq(' + i + ')').toggle();

        $("#evalition-id").val(EVALUTION[i].Id);
        $("#evalition-note").val(EVALUTION[i].Notes);
        $("#evalition-date").val(EVALUTION[i].Date.substr(0, 10));
    }
    //evalitionLineRemove
    function RemoveEvalitionLine(j) {

        if (EVALUTION.length >= 1) {
            EVALUTION.splice(j, 1);
        }
        else {
            EVALUTION = [];

        }
        var table = $("#evalition-body");
        table.html("");
        ClearLine();

        for (let i = 0; i < EVALUTION.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=evalition-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=evalition-body" + i + ">";
            }
            row += "<td style='display:none;'>" + EVALUTION[i].Id + "</td>";
            row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
            row += '<td class="note-ev">' + EVALUTION[i].Note + "</td>";
            row += "<td class='date-ev'>" + EVALUTION[i].Date + "</td>";
            row += "<td class='edit-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $("#lbl_error_evalition_line").text("");

            $(`#evalition-body${i} .edit-ev a#editline`).on("click", () => EditEvalitionLine(i));
            $(`#evalition-body${i} .edit-ev a#removeline`).on("click", () => RemoveEvalitionLine(i));
            $(`#evalition-body${i} .update-ev a#cancelline`).on("click", () => CancelEvalitionLine(i));
            $(`#evalition-body${i} .update-ev a#updateline`).on("click", () => UpdateEvalitionLine(i));

            $('.update-ev').hide();
            ClearLine();
        }
    }
    //evalitionLineCancel
    function CancelEvalitionLine(i) {
        $('.update-ev:eq(' + i + '), .edit-ev:eq(' + i + ')').toggle();
        ClearLine();
    }
    //evalitionLineUpdate
    function UpdateEvalitionLine(j) {
        EVALUTION[j].Note = $("#evalition-note").val();
        EVALUTION[j].Date = $("#evalition-date").val();

        var table = $("#evalition-body");
        table.html("");

        for (let i = 0; i < EVALUTION.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=evalition-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=evalition-body" + i + ">";
            }
            row += "<td style='display:none;'>" + EVALUTION[i].Id + "</td>";
            row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
            row += '<td class="note-ev">' + EVALUTION[i].Note + "</td>";
            row += "<td class='date-ev'>" + EVALUTION[i].Date + "</td>";
            row += "<td class='edit-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $("#lbl_error_evalition_line").text("");

            $(`#evalition-body${i} .edit-ev a#editline`).on("click", () => EditEvalitionLine(i));
            $(`#evalition-body${i} .edit-ev a#removeline`).on("click", () => RemoveEvalitionLine(i));
            $(`#evalition-body${i} .update-ev a#cancelline`).on("click", () => CancelEvalitionLine(i));
            $(`#evalition-body${i} .update-ev a#updateline`).on("click", () => UpdateEvalitionLine(i));

            $('.update-ev').hide();
            ClearLine();
        }
    }


    //*********************************************************************Seed Image Table
    var STATEMENT = [];
    var STATEMENTS = {};
    var currentFile;

    //openImageAnotherWindow
    function openWinStatetment() {
        window.open($("img#myStatetmentImage").attr("src"), "_blank");
    }

    $(document).on("click", ".btn-statetment-image-save", function () {

        if ($("#statetment-document").val() === null || $("#statetment-name").val().length === 0 || $("#statetmentFile").val().length === 0) {
            $("#lbl_error_statetment_image_line").text("*** Fill out all starred fields");
            return false;
        }

        STATEMENTS = {};

        var id = +$("#statetment-id").val();
        var statetment = +$("#statetment-document").val();
        var statetment_text = $("#statetment-document option:selected").text();
        var statetment_name = $("#statetment-name").val();
        var statetment_attachment = $("#statetmentFile")[0].files[0];


        STATEMENTS.Id = id;
        STATEMENTS.Document = statetment;
        STATEMENTS.Document_text = statetment_text;
        STATEMENTS.Document_name = statetment_name;
        STATEMENTS.Attachment = statetment_attachment;

        var table = $("#statetment-body");
        STATEMENT.push(STATEMENTS);

        const i = STATEMENT.length - 1;

        if (i % 2 === 0) {
            row = "<tr id=statetment-body" + i + ">";
        }
        else {
            row = "<tr style='background-color:#F2F2F2' id=statetment-body" + i + ">";
        }
        row += "<td style='display:none';>" + STATEMENT[i].Id + "</td>";
        row += "<td class='document-st'  style='display:none'>" + STATEMENT[i].Document + "</td>";
        row += "<td>" + STATEMENT[i].Document_text + "</td>";
        row += '<td class="document-name-st">' + STATEMENT[i].Document_name + "</td>";
        row += "<td class='document-file-st'><img id='myStatetmentImage' style='width: 40px; height: 40px; object-fit: cover' src = " + URL.createObjectURL(STATEMENT[i].Attachment) + " /></td > ";
        row += "<td class='edit-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
        row += "<td class='update-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

        row += "</tr>";

        table.append(row);

        $("#lbl_error_statetment_image_line").text("");

        $(`#statetment-body${i} .edit-st a#editline`).on("click", () => EditStatetmentImageLine(i));
        $(`#statetment-body${i} .edit-st a#removeline`).on("click", () => RemoveStatetmentImageLine(i));
        $(`#statetment-body${i} .update-st a#cancelline`).on("click", () => CancelStatetmentImageLine(i));
        $(`#statetment-body${i} .update-st a#updateline`).on("click", () => UpdateStatetmentImageLine(i));

        $(`#statetment-body${i} #myStatetmentImage`).on("click", () => openWinStatetment(i));

        $('.update-st').hide();
        ClearLine();

    });

    //insertNameonBrowser
    $('input[type="file"]').change(function (e) {
        var selectedstatetmentFileName = e.target.files[0].name;
        $(".statetment-file-label").text(selectedstatetmentFileName);
        //  readURL(this);
    });

    //ImageLineEdit
    function EditStatetmentImageLine(i) {
        $('.edit-st').show();
        $('.update-st').hide();
        $('.update-st:eq(' + i + '), .edit-st:eq(' + i + ')').toggle();

        // $(".custom-file-label").text(FILES[i].Attachment.name);
        currentFile = STATEMENT[i].Attachment;
        $("#statetment-document").val(STATEMENT[i].Document);
        $("#statetment-name").val(STATEMENT[i].Document_name);
    }

    //ImageLineRemove
    function RemoveStatetmentImageLine(j) {

        if (STATEMENT.length >= 1) {
            STATEMENT.splice(j, 1);
        }
        else {
            STATEMENT = [];

        }
        var delivery_table = $("#statetment-body");
        delivery_table.html("");
        ClearLine();

        for (let i = 0; i < STATEMENT.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=statetment-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=statetment-body" + i + ">";
            }
            row += "<td style='display:none';>" + STATEMENT[i].Id + "</td>";
            row += "<td class='statetment-sr'  style='display:none'>" + STATEMENT[i].Document + "</td>";
            row += "<td>" + STATEMENT[i].Document_text + "</td>";
            row += '<td class="statetment-st">' + STATEMENT[i].Document_name + "</td>";
            row += "<td class='statetment-st'><img id='myStatetmentImage' style='width: 40px; height: 40px; object-fit: cover' src = " + URL.createObjectURL(STATEMENT[i].Attachment) + " /></td > ";
            row += "<td class='edit-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            table.append(row);

            $("#lbl_error_statetment_image_line").text("");

            $(`#statetment-body${i} .edit-st a#editline`).on("click", () => EditStatetmentImageLine(i));
            $(`#statetment-body${i} .edit-st a#removeline`).on("click", () => RemoveStatetmentImageLine(i));
            $(`#statetment-body${i} .update-st a#cancelline`).on("click", () => CancelStatetmentImageLine(i));
            $(`#statetment-body${i} .update-st a#updateline`).on("click", () => UpdateStatetmentImageLine(i));

            $(`#statetment-body${i} #myStatetmentImage`).on("click", () => openWinStatetment(i));

            $('.update-st').hide();
            ClearLine();
        }
    }

    //ImageLineCancel
    function CancelStatetmentImageLine(i) {
        $('.update-st:eq(' + i + '), .edit-st:eq(' + i + ')').toggle();
        ClearLine();
    }

    //ImageLineUpdate
    function UpdateStatetmentImageLine(j) {
        STATEMENT[j].Document = $("#statetment-document").val();
        STATEMENT[j].Document_text = $("#statetment-document option:selected").text();
        STATEMENT[j].Document_name = $("#statetment-name").val();
        STATEMENT[j].Attachment = $("#statetmentFile")[0].files[0] || currentFile;

        var delivery_table = $("#statetment-body");
        delivery_table.html("");

        for (let i = 0; i < STATEMENT.length; i++) {

            if (i % 2 === 0) {
                row = "<tr id=statetment-body" + i + ">";
            }
            else {
                row = "<tr style='background-color:#F2F2F2' id=statetment-body" + i + ">";
            }
            row += "<td style='display:none';>" + STATEMENT[i].Id + "</td>";
            row += "<td class='document-st'  style='display:none'>" + STATEMENT[i].Document + "</td>";
            row += "<td>" + STATEMENT[i].Document_text + "</td>";
            row += '<td class="document-name-st">' + STATEMENT[i].Document_name + "</td>";
            row += "<td class='document-file-st'><img id='myStatetmentImage' style='width: 40px; height: 40px; object-fit: cover' src = " + URL.createObjectURL(STATEMENT[i].Attachment) + " /></td > ";
            row += "<td class='edit-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
            row += "<td class='update-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

            row += "</tr>";

            delivery_table.append(row);

            $("#lbl_error_statetment_image_line").text("");

            $(`#statetment-body${i} .edit-st a#editline`).on("click", () => EditStatetmentImageLine(i));
            $(`#statetment-body${i} .edit-st a#removeline`).on("click", () => RemoveStatetmentImageLine(i));
            $(`#statetment-body${i} .update-st a#cancelline`).on("click", () => CancelStatetmentImageLine(i));
            $(`#statetment-body${i} .update-st a#updateline`).on("click", () => UpdateStatetmentImageLine(i));

            $(`#statetment-body${i} #myStatetmentImage`).on("click", () => openWinStatetment(i));

            $('.update-st').hide();
            ClearLine();
        }
    }

    //*********************************************************************FORM SUBMIT SEND DATA TO DB
    $('#incident-form').submit((e) => {
        if ($("#inv-cause").val().length === 0 || $("#inv-people").val().length === 0 || $("#inv-property").val().length === 0 || $("#inv-enviroment").val().length === 0
            || $("#inv-buisness").val().length === 0 || $("#inv-possiblePeople").val().length === 0 || $("#inv-possibleProperty").val().length === 0
            || $("#inv-possibleEnviroment").val().length === 0 || $("#inv-possibleBuisness").val().length === 0 || $("#inv-possibleBuisness").val().length === 0
            || $("#inv-groundCondition").val().length === 0 || $("#inv-illumination").val().length === 0 || $("#inv-contact").val().length === 0
            || $("#inv-lesson").val().length === 0 || $("#event-brief").val().length === 0 || $("#event-explain").val().length === 0
            || $("#event-identity").val().length === 0) {
            $("#lbl_error_investigate_team").text("*** Fill out all starred fields");
            return false;
        }

        e.preventDefault();

        const formData = GetFormData();

        $.ajax({
            url: '/Investigate/CreateIncident',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            beforeSend: function () {
                $('.spinner-border').removeClass('d-none');
            },
            success: (response) => {
                $("#adminModal").modal('hide');
                location.reload();
            },
            error: (error) => {
                console.log(error);
            }
        });
    });

    function GetFormData() {
        let formData = new FormData();

        formData.append('model.Id', $('#Uinv-id').val());
        formData.append('model.no', $('#Uinv-no').val());
        formData.append('model.OccurenceCauseId', $('#inv-cause').val());
        formData.append('model.OutcomePeopleId', $('#inv-people').val());
        formData.append('model.OutcomePropertyId', $('#inv-property').val());
        formData.append('model.OutcomeEnviromentId', $('#inv-enviroment').val());
        formData.append('model.OutcomeBuisnessId', $('#inv-buisness').val());
        formData.append('model.PossiblePeopleId', $('#inv-possiblePeople').val());
        formData.append('model.PossiblePropertyId', $('#inv-possibleProperty').val());
        formData.append('model.PossibleEnviromentId', $('#inv-possibleEnviroment').val());
        formData.append('model.PossibleBuisnessId', $('#inv-possibleBuisness').val());
        formData.append('model.LessonLearnedId', $('#inv-lesson').val());
        formData.append('model.BriefDecription', $('#event-brief').val());
        formData.append('model.ReasonDescription', $('#event-explain').val());
        formData.append('model.IdentifyDescription', $('#event-identity').val());

        for (var i = 0; i < $("#event-body tr").length; i++) {
            formData.append(`model.EventLines[${i}].Date`, $(".date-e").eq(i).text());
            formData.append(`model.EventLines[${i}].Time`, +$(".time-e").eq(i).text());
            formData.append(`model.EventLines[${i}].Description`, +$(".description-e").eq(i).text());
            formData.append(`model.EventLines[${i}].Comment`, $(".comment-e").eq(i).text());
        }

        for (i = 0; i < $("#prevent-body tr").length; i++) {
            formData.append(`model.PreventLines[${i}].Action`, $(".action-p").eq(i).text());
            formData.append(`model.PreventLines[${i}].Person`, $(".person-p").eq(i).text());
            formData.append(`model.PreventLines[${i}].Date`,  $(".date-p").eq(i).text());
        }

        for (i = 0; i < $("#evalition-body tr").length; i++) {
            formData.append(`model.EvaluationLines[${i}].Notes`, $(".note-ev").eq(i).text());
            formData.append(`model.EvaluationLines[${i}].Date`, $(".date-ev").eq(i).text());
        }

        for (i = 0; i < $("#nominated-body tr").length; i++) {
            formData.append(`model.NominateLines[${i}].Name`, $(".name-n").eq(i).text());
            formData.append(`model.NominateLines[${i}].Position`, $(".position-n").eq(i).text());
            formData.append(`model.NominateLines[${i}].Organization`, $(".organization-n").eq(i).text());
            formData.append(`model.NominateLines[${i}].TeamTypeId`, +$(".type-n").eq(i).text());
        }


        for (i = 0; i < $("#statetment-body tr").length; i++) {
            formData.append(`model.Images[${i}].DocumentTypeId`, +$(".document-st").eq(i).text());
            formData.append(`model.Images[${i}].DocumentName`, $(".document-name-st").eq(i).text());
            formData.append(`model.Images[${i}].Photo`, STATEMENT[i].Attachment);
        }

        return formData;



    }
    //*********************************************************************FORM EDIT
    var ID;
    $('.clicks-table').on('click', 'tbody tr', function (event) {
        $(this).toggleClass('selected').siblings().removeClass("selected");
        ID = $(this).data('id');
        $("#Uinv-id").val(ID);
    });

    function EditData() {
        var inv_id = $("#Uinv-id").val();
        if (inv_id === "" || inv_id === "0") {
            alert("You must choose the row!");
            return false;
        }
        $.ajax({
            type: "Post",
            url: "/Investigate/EditIncident/" + inv_id,
            success: function (result) {
                $(JSON.parse(result)).each(function (index, item) {
                    $("#Uinv-id").val(item.Id);
                    $("#Uinv-no").val(item.No);
                    $("#inv-cause").val(item.OccurenceCauseId);
                    $("#inv-people").val(item.OutcomePeopleId);
                    $("#inv-property").val(item.OutcomePropertyId);
                    $("#inv-enviroment").val(item.OutcomeEnviromentId);
                    $("#inv-buisness").val(item.OutcomeBuisnessId);
                    $("#inv-possiblePeople").val(item.PossiblePeopleId);
                    $("#inv-possibleProperty").val(item.PossiblePropertyId);
                    $("#inv-possibleEnviroment").val(item.PossibleEnviromentId);
                    $("#inv-possibleBuisness").val(item.PossibleBuisnessId);
                    $("#inv-lesson").val(item.LessonLearnedId);
                    $("#event-brief").val(item.BriefDecription);
                    $("#event-explain").val(item.ReasonDescription);
                    $("#event-identity").val(item.IdentifyDescription);
                    DeliverNominatedLineFill_edit(item.Id);
                    DeliverEventLineFill_edit(item.Id);
                    DeliverPreventLineFill_edit(item.Id);
                    DeliverEvalutionFill_edit(item.Id);
                    FilesFillLine_edit(item.Id);
                    $("#adminModal").modal('show');
                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function DeliverNominatedLineFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                mline_id: ID
            },
            url: "/Investigate/DeliverNominatedLineFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#nominated-body");
                delivery_table.html("");

                function NominatedLine(Id, Name, Position, Organization, TeamTypeId, Type_text) {
                    this.Id = Id;
                    this.Name = Name;
                    this.Position = Position;
                    this.Organization = Organization;
                    this.TeamType = TeamTypeId;
                    this.TeamType_text = Type_text;
                }

                $(JSON.parse(result)).each(function (index, item) {
                    var dlvline = new NominatedLine(item.Id, item.Name, item.Position, item.Organization, item.TeamTypeId, item.TeamType.Name);
                    NOMINATED.push(dlvline);


                    const i = NOMINATED.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=nominated-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=nominated-body" + i + ">";
                    }
                    row += "<td style='display:none;'>" + NOMINATED[i].Id + "</td>";
                    row += '<td class="name-n">' + NOMINATED[i].Name + "</td>";
                    row += '<td class="position-n">' + NOMINATED[i].Position + "</td>";
                    row += "<td class='organization-n'>" + NOMINATED[i].Organization + "</td>";
                    row += "<td class='type-n' style='display: none'>" + NOMINATED[i].TeamType + "</td>";
                    row += "<td>" + NOMINATED[i].TeamType_text + "</td>";
                    row += "<td class='edit-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-n' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);

                    $("#lbl_error_investigate_nom_line").text("");

                    $(`#nominated-body${i} .edit-n a#editline`).on("click", () => EditNominateLine(i));
                    $(`#nominated-body${i} .edit-n a#removeline`).on("click", () => RemoveNominateLine(i));
                    $(`#nominated-body${i} .update-n a#cancelline`).on("click", () => CancelNominateLine(i));
                    $(`#nominated-body${i} .update-n a#updateline`).on("click", () => UpdateNominateLine(i));

                    $('.update-n').hide();
                    ClearLine();
                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function DeliverEventLineFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                mline_id: ID
            },
            url: "/Investigate/DeliverEventLineFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#event-body");
                delivery_table.html("");

                function EventLine(Id, Date, Time, Description, Comment) {
                    this.Id = Id;
                    this.Date = Date;
                    this.Time = Time;
                    this.Description = Description;
                    this.Comment = Comment;
                }

                $(JSON.parse(result)).each(function (index, item) {
                    var dlvline = new EventLine(item.Id, item.Date, item.Time, item.Description, item.Comment);
                    EVENT.push(dlvline);


                    const i = EVENT.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=event-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=event-body" + i + ">";
                    }
                    row += "<td style='display:none;'>" + EVENT[i].Id + "</td>";
                    row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
                    row += '<td class="date-e">' + EVENT[i].Date.substr(0, 10) + "</td>";
                    row += '<td class="time-e">' + EVENT[i].Time + "</td>";
                    row += "<td class='decription-e'>" + EVENT[i].Description + "</td>";
                    row += "<td class='comment-e'>" + EVENT[i].Comment + "</td>";
                    row += "<td class='edit-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-e' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);

                    $("#lbl_error_event_line").text("");

                    $(`#event-body${i} .edit-e a#editline`).on("click", () => EditEventLine(i));
                    $(`#event-body${i} .edit-e a#removeline`).on("click", () => RemoveEventLine(i));
                    $(`#event-body${i} .update-e a#cancelline`).on("click", () => CancelEventLine(i));
                    $(`#event-body${i} .update-e a#updateline`).on("click", () => UpdateEventLine(i));

                    $('.update-e').hide();
                    ClearLine();
                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function DeliverPreventLineFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                mline_id: ID
            },
            url: "/Investigate/DeliverPreventLineFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#prevent-body");
                delivery_table.html("");

                function PreventLine(Id, Action, Person, Date) {
                    this.Id = Id;
                    this.Action = Action;
                    this.Person = Person;
                    this.Date = Date;
                }

                $(JSON.parse(result)).each(function (index, item) {
                    var dlvline = new PreventLine(item.Id, item.Action, item.Person, item.Date);
                    PREVENT.push(dlvline);


                    const i = PREVENT.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=prevent-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=prevent-body" + i + ">";
                    }
                    row += "<td style='display:none;'>" + PREVENT[i].Id + "</td>";
                    row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
                    row += '<td class="action-p">' + PREVENT[i].Action + "</td>";
                    row += '<td class="person-p">' + PREVENT[i].Person + "</td>";
                    row += "<td class='date-p'>" + PREVENT[i].Date.substr(0, 10) + "</td>";
                    row += "<td class='edit-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-p' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);

                    $("#lbl_error_prevent_line").text("");

                    $(`#prevent-body${i} .edit-p a#editline`).on("click", () => EditPreventLine(i));
                    $(`#prevent-body${i} .edit-p a#removeline`).on("click", () => RemovePreventLine(i));
                    $(`#prevent-body${i} .update-p a#cancelline`).on("click", () => CancelPreventLine(i));
                    $(`#prevent-body${i} .update-p a#updateline`).on("click", () => UpdatePreventLine(i));

                    $('.update-p').hide();
                    ClearLine();
                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function DeliverEvalutionFill_edit() {
        $.ajax({
            type: "Post",
            data: {
                mline_id: ID
            },
            url: "/Investigate/DeliverEvalutionFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#evalition-body");
                delivery_table.html("");

                function EvalutionLine(Id, Notes, Date) {
                    this.Id = Id;
                    this.Notes = Notes;
                    this.Date = Date;
                }

                $(JSON.parse(result)).each(function (index, item) {
                    var dlvline = new EvalutionLine(item.Id, item.Notes, item.Date);
                    EVALUTION.push(dlvline);


                    const i = EVALUTION.length - 1;

                    if (i % 2 === 0) {
                        row = "<tr id=evalition-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=evalition-body" + i + ">";
                    }
                    row += "<td style='display:none;'>" + EVALUTION[i].Id + "</td>";
                    row += "<td id='nm' >" + parseInt(i + 1) + "</td>";
                    row += '<td class="note-ev">' + EVALUTION[i].Notes + "</td>";
                    row += "<td class='date-ev'>" + EVALUTION[i].Date.substr(0, 10) + "</td>";
                    row += "<td class='edit-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-ev' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);

                    $("#lbl_error_evalition_line").text("");

                    $(`#evalition-body${i} .edit-ev a#editline`).on("click", () => EditEvalitionLine(i));
                    $(`#evalition-body${i} .edit-ev a#removeline`).on("click", () => RemoveEvalitionLine(i));
                    $(`#evalition-body${i} .update-ev a#cancelline`).on("click", () => CancelEvalitionLine(i));
                    $(`#evalition-body${i} .update-ev a#updateline`).on("click", () => UpdateEvalitionLine(i));

                    $('.update-ev').hide();
                    ClearLine();
                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }
    function FilesFillLine_edit() {
        $.ajax({
            type: "Post",
            data: {
                files_id: ID
            },
            url: "/Investigate/FilesFill_edit/" + ID,
            success: function (result) {
                var delivery_table = $("#statetment-body");
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
                    STATEMENT.push(dlvline);

                    const i = STATEMENT.length - 1;


                    if (i % 2 === 0) {
                        row = "<tr id=statetment-body" + i + ">";
                    }
                    else {
                        row = "<tr style='background-color:#F2F2F2' id=statetment-body" + i + ">";
                    }
                    row += "<td style='display:none';>" + STATEMENT[i].Id + "</td>";
                    row += "<td class='document-st'  style='display:none'>" + STATEMENT[i].Document + "</td>";
                    row += "<td>" + STATEMENT[i].Document_text + "</td>";
                    row += '<td class="document-name-st">' + STATEMENT[i].Document_name + "</td>";
                    row += "<td class='document-file-st'><img id='myStatetmentImage' style='width: 40px; height: 40px; object-fit: cover' src = " + STATEMENT[i].Attachment.name  + " /></td > ";
                    row += "<td class='edit-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='editline'><i class='fa fa-edit' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='removeline'><i class='fa fa-remove' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";
                    row += "<td class='update-st' class='filterable-cell' style='width: 9.3%;'>" + "<a href='#' name='fa' class='btn-link' id='updateline'><i class='fa fa-chevron-down' style='font-size:18px;padding-right:10px;'></i></a><a href='#' name='fa' class='btn-link' id='cancelline'><i class='fa fa-backward' style='font-size:18px;padding-right:10px;'></i></a>" + "</td>";

                    row += "</tr>";

                    delivery_table.append(row);

                    $("#lbl_error_statetment_image_line").text("");

                    $(`#statetment-body${i} .edit-st a#editline`).on("click", () => EditStatetmentImageLine(i));
                    $(`#statetment-body${i} .edit-st a#removeline`).on("click", () => RemoveStatetmentImageLine(i));
                    $(`#statetment-body${i} .update-st a#cancelline`).on("click", () => CancelStatetmentImageLine(i));
                    $(`#statetment-body${i} .update-st a#updateline`).on("click", () => UpdateStatetmentImageLine(i));

                    $(`#statetment-body${i} #myStatetmentImage`).on("click", () => openWinStatetment(i));

                    $('.update-st').hide();
                    ClearLine();

                });
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }


    //*********************************************************************Print DAta
    function printData() {
        var inv = $("#Uinv-id").val();
        if (inv === "" || inv === "0") {
            alert("You must choose the row!");
            return false;
        }
        window.open('/Investigate/Print?Id=' + ID);
    }

    function CompleteDataAdmin() {
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