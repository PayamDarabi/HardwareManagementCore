$(document).ready(function () {

    document.querySelector('div.box-body').setAttribute('dir', 'rtl');
    $('#example1').DataTable();

    $("#addbtn").click(function () {
        $('#myModal').modal('show');
    });

    $("#btnSavePerson").click(function () {
        let p = {
            PersonId: $("#PersonId").val(),
            Name : $("#Name").val(),
            Phone : $("#Phone").val(),
            Unit : $("#Unit").val(),
            RoomNo : $("#RoomNo").val(),
            Status : $("#Status").val(),
            Note : $("#Note").val()
        }
        debugger
        $.ajax({
            url: '/Persons/SavePerson',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(p), // Send person object directly
            type: 'POST',
            success: function (data) {
                // success
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });

    });
});