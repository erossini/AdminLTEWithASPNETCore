function readExcelFile(url, tablename, filename, maxVisibleColumns = 0) {
    $.ajax({
        url: url,
        data: 'filename=' + filename,
        dataType: 'json'
    })
        .fail(function (err) {
            alert(err);
        })
        .done(function (data) {
            console.log(data);
            var columns = '[';
            var tbl = '<thead><tr>';
            $.each(data.Headers, function (i, txt) {
                tbl += '<th class="'
                if (i > maxVisibleColumns) tbl += 'none'; else tbl += 'all';
                tbl += '">' + txt + '</th>';
                if (columns.length > 1) columns += ',';
                columns += "{ 'data': '" + txt + "'"
                if (i > maxVisibleColumns) columns += ", 'visible': false";
                columns += " }";
            })
            columns += "]";
            tbl += '<th class="all"></th></tr></thead>';
            tbl += '<tbody>';
            $.each(data.Rows, function (index, obj) {
                tbl += '<tr>';
                var num = 0;
                $.each(obj, function (_, text) {
                    tbl += '<td>' + text + '</td>';
                    num++;
                });
                if (num < data.Headers.length)
                    for (var i = 0; i < data.Headers.length - num; i++) {
                        tbl += '<td></td>';
                    }
                tbl += "<td></td></tr>";
            });
            tbl += '</tbody>';

            $('#' + tablename).append(tbl);
            var table = $('#' + tablename).DataTable({
                dom: 'Blfrtip',
                "buttons": ["pageLength", "colvis"],
                "lengthChange": false,
                "order": [[0, "asc"]],
                "responsive": {
                    details: {
                        type: 'column',
                        target: 'tr'
                    }
                },
                "columnDefs": [{
                    className: 'control',
                    orderable: false,
                    targets: -1
                }]
            });
        });
}

function setMetadata(url, filename, text) {
    var json = { "filename": filename, "text": text};
    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(json),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json'
    })
}

function startProcess(url, filename) {
    $.ajax({
        url: url,
        data: 'filename=' + filename,
        dataType: 'json'
    })
}