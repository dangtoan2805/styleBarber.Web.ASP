$(function() {
    $('input[name="appointment"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format('YYYY'), 10)
    }, function (start, end, label) {
            getAppointment(start.format('L'));
    });

    var start = moment().subtract(29, 'days');
    var end = moment();

    function cb(start, end) {
        $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
    }

    $('#reportrange').daterangepicker({
        startDate: start,
        endDate: end,
        ranges: {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        }
    }, cb);

    cb(start, end);

    function getAppointment(date) {
        $.ajax({
            type: "GET", url: "/Admin/Home/GetAppoitmentByDate",
            contentType: "application/json;charset=utf-8",
            data: { date: date },
            dataType: "json"
        }).done(data => {
            let container = $('#data-container-apppointment');
            container.empty();
            if (Array.isArray(data)) {
                if (data.length == 0)
                    container.append(crtEmpty())
                else
                    data.forEach(item => container.append(crtHTMLAppoitment(item)))
            }
        }).catch(er => console.log(er));
    }
    getAppointment("5/5/2020");

    function crtHTMLAppoitment(item)
    {
        let date = item.date;
        let checked = item.staus ? "checked" : "";
        return `
            <tr>
                <td>${item.Date}</td>
                <td>${item.Time}</td>
                <td>${item.FirstName} ${item.LastName}</td>
                <td >${item.Phone}</td>
                <td >${item.BarberName}</td>
                <td >
                    <p style ="white-space: nowrap;  overflow: hidden; text-overflow: ellipsis;">${item.Note} </p>
                </td>
                <td>
                    <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="materialUnchecked" ${checked}>
                        <label class="form-check-label" for="materialUnchecked"></label>
                    </div>
                </td>
            </tr>`
    }

    function crtEmpty() {
        return ` <tr>
                    <td colspan="7" class="text-center">Không có dữ liệu</td>
                </tr>`
    }
});
