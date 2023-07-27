﻿$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/event/getall' },
        "columns": [
            { data: 'eventId', "width": "25%" },
            { data: 'eventName', "width": "15%" },
            { data: 'eventDescription', "width": "10%" },
            { data: 'eventDate', "width": "20%" },
            { data: 'location', "width": "15%" },
            { data: 'availableSeats', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="event/editpage?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a href="event/delete?id=${data}" class="btn btn-primary mx-2 "> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}