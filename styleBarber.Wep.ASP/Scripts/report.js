$(function () {

    var pageItems = 7;
    var start = moment().subtract(29, 'days');
    var end = moment();
    var datas =[]

    function cb(start, end) {
        $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        getAppointment(start.format('L'), end.format('L'));
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

    //Requset
    function getAppointment(start, end) {
        $.ajax({
            type: "GET", url: "/Admin/Home/GetAppoitmentByDate",
            contentType: "application/json;charset=utf-8",
            data: {start: start, end: end },
            dataType: "json"
        }).done(data => {
            displayData(data)
        }).catch(er => console.log(er));
    }

    function getTopBarber() {
        $.ajax({
            method: "GET", url: "/Admin/Home/GetTopBarber",
            dataType:'JSON'
        }).done(data => {
            let container = $("#vt-topbarbers-contaniner");
            container.empty();
            if (data != null || data.length == 0) {
                data.forEach(item => container.append(crtHTMLTopBarber(item)));
            }
            else
                container.append(crtEmptyTopBarber());
        })
    }

    // Create HTML
    function crtHTMLAppoitment(item)
    {
        let checked = item.Status ? "checked" : "";
        return `
            <tr>
                <td>${item.DateCheckOut}</td>
                <td>${item.Time}</td>
                <td>${item.Name}</td>
                <td>${item.Phone}</td>
                <td>${item.BarberName}</td>
                <td>
                    <div class="form-check">
                        <input type="checkbox" vt-status data-itemid=${item.ID} class="form-check-input" id="materialUnchecked" ${checked}>
                        <label class="form-check-label" for="materialUnchecked"></label>
                    </div>
                </td>
            </tr>`
    }

    function crtEmptyAppointment() {
        return ` <tr>
                    <td colspan="7" class="text-center">Không có dữ liệu</td>
                </tr>`
    }

    function crtHTMLTopBarber(item) {
        return `<tr>
                    <td>${item.Barber}</td>
                    <td class="text-right">${item.Count}</td>
                </tr>`
    }

    function crtEmptyTopBarber() {
        return ` <tr>
                    <td colspan="2" class="text-center">Không có dữ liệu</td>
                </tr>`
    } 

    //Event 
    function onChangeStatus() {
        $("input[vt-status]").on("change", function () {
            $.ajax({
                method: "POST", url: "/Admin/Home/UpdateStatus",
                data: { id: $(this).data("itemid"), status: $(this).prop("checked")}
            });
        });
    }

    //Pagination
    function getPage(page) {
        let start = (page - 1) * pageItems;
        let end = start + (pageItems - 1);
        showData(datas.slice(start, end));
    }

    function displayData(data) {
        let len = data.length
        if (len > 0) {
            datas = data;
            $('#vt-total').text(len);
            $('#vt-pagination').show();
            showPages(len, pageItems, number => getPage(number));
            getPage(1);
            firstPageOnlyView();
        }
        else {
            $('#vt-total').text(0);
            $('#vt-pagination').hide();
            let container = $('#data-container-apppointment');
            container.empty();
            container.append(crtEmptyAppointment())
        }
       
    }

    function showData(data) {
        let container = $('#data-container-apppointment');
        container.empty();
        data.forEach(item => container.append(crtHTMLAppoitment(item)));
        onChangeStatus();
    }

    function calPages(length, pageItems) {
        if (length % pageItems != 0) return parseInt(length / pageItems) + 1;
        return length / pageItems;
    }

    function onChangePage(handler) {
        $('.page-link').on('click', function () {
            $("html,body").animate({ scrollTop: "0" }, 500);
            $('#vt-pagination').children('.active').removeClass('active');
            $(this).parent().addClass('active');
            handler($(this).text());
        });
    }

    var showPages = function (length, pageItems, handler) {
        let containter = $('#vt-pagination');
        containter.empty();
        let pages = calPages(length, pageItems);
        for (let index = 1; index <= pages; index++) {
            containter.append(`<li class="page-item"><a class="page-link" href="#">${index}</a></li>`);
        }
        //Attach when click page
        onChangePage(handler);
    }

    var firstPageOnlyView = () => {
        $('#vt-pagination').children('.active').removeClass('active');
        $(`#vt-pagination .page-item:first-child`).addClass('active');
    }
    //End
    cb(start, end);
    getTopBarber();
});
