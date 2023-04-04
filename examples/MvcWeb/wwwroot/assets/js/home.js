
var pathName = location.pathname;
$(document).ready(function () {

    $("#relation-menu a").on('click', function (event) {
        debugger;
        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {
            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;

            var headerHeight = $('.header').height();

            var heightMenu = $('#relation-menu').height();

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
            var scrollTo = $(hash).offset().top
            if (!$('#relation-menu').attr('class').includes('sticky')) {
                $('body, html').animate({ scrollTop: scrollTo - (heightMenu * 2 - headerHeight) }, 800);
            } else {
                $('body, html').animate({ scrollTop: scrollTo - heightMenu }, 800);
            }

        } // End if
    });


    var tableNoti = $("#tbl-noti").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , sDom: 'lrtip'
        ,"ordering": false
        , "lengthChange": false
        ,"columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilter =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilter).appendTo("#tbl-noti thead");
    $("#tbl-noti thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');
        
        tableNoti.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableNoti.column(i).search() !== this.value) {
                    tableNoti
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableNoti.column(i).search(val ? val : '', true, false).draw();
            });
    });

    var tableReportFin = $("#tbl-report-fin").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterRF =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterRF).appendTo("#tbl-report-fin thead");
    $("#tbl-report-fin thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableReportFin.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableReportFin.column(i).search() !== this.value) {
                    tableReportFin
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableReportFin.column(i).search(val ? val : '', true, false).draw();
            });
    });

    var tableReportYear = $("#tbl-report-year").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterRY =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterRY).appendTo("#tbl-report-year thead");
    $("#tbl-report-year thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableReportYear.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableReportYear.column(i).search() !== this.value) {
                    tableReportYear
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableReportYear.column(i).search(val ? val : '', true, false).draw();
            });
    });

    var tableInfo = $("#tbl-info").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterInfo =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterInfo).appendTo("#tbl-info thead");
    $("#tbl-info thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableInfo.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableInfo.column(i).search() !== this.value) {
                    tableInfo
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableInfo.column(i).search(val ? val : '', true, false).draw();
            });
    });

    var tableRegu = $("#tbl-regu").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterRegu =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterRegu).appendTo("#tbl-regu thead");
    $("#tbl-regu thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableRegu.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableRegu.column(i).search() !== this.value) {
                    tableRegu
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableRegu.column(i).search(val ? val : '', true, false).draw();
            });
    });

    var tableManager = $("#tbl-manager").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterManager =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterManager).appendTo("#tbl-manager thead");
    $("#tbl-manager thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableManager.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableManager.column(i).search() !== this.value) {
                    tableManager
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableManager.column(i).search(val ? val : '', true, false).draw();
            });
    });

    var tableReport = $("#tbl-report").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterReport =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterReport).appendTo("#tbl-report thead");
    $("#tbl-report thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableReport.column(3).data().unique().sort(function(a, b){return b-a}).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableReport.column(i).search() !== this.value) {
                    tableReport
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableReport.column(i).search(val ? val : '', true, false).draw();
            });
    });


    var tableResolution = $("#tbl-resolution").DataTable({
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Hiển thị _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Sau",
                "sLast": "Cuối"
            }
        }
        , "ordering": false
        , sDom: 'lrtip'
        , "lengthChange": false
        , "columnDefs": [
            {
                "targets": [3],
                "visible": false
            },
            { "width": "20%", "targets": [1] },
            { "width": "10%", "targets": [2] },
        ]
    });

    var columnFilterResolution =
        "<tr><th>Tên báo cáo</th><th>Mã văn bản</th><th>Tải về</th></tr >";
    $(columnFilterResolution).appendTo("#tbl-resolution thead");
    $("#tbl-resolution thead tr:eq(1) th").each(function (i) {
        var title = $(this).text();
        var select = $('<select class="form-control"><option value="">Tất cả</option></select>');

        tableResolution.column(3).data().unique().sort(function (a, b) { return b - a }).each(function (d, j) {
            select.append('<option value="' + d + '">' + d + '</option>');
        });

        i === 1 ? $(this).html(select) : $(this).html('<input type="text" class="form-control" placeholder="' + title + '" />');

        $("input", this).on("keyup change",
            function () {
                if (tableResolution.column(i).search() !== this.value) {
                    tableResolution
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        $("select", this).on("change",
            function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );

                tableResolution.column(i).search(val ? val : '', true, false).draw();
            });
    });

    new WOW().init();

    $('.share-social').click(function () {
        $(this).children().first().toggle();
    });

    $('[data-toggle="tooltip"]').tooltip();

    $('.autoplay').slick({
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        infinite: true,
        autoplaySpeed: 2000,
        dots: true,
        arrows: false,
        responsive: [
            {
                breakpoint: 568,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }
        ]
    });

    $(".img-bottom-left").hover(function () {

        $(this).next('.img-container-des').css("display", "block");
    },
        function () {
            $(this).next('.img-container-des').css("display", "none");
        });

    $('#body-content').find('img').addClass("img-fluid");

    $('[data-toggle=search-form]').click(function () {
        $('.search-form-wrapper').toggleClass('open');
        $('.search-form-wrapper .search').focus();
        $('html').toggleClass('search-form-open');
    });
    $('[data-toggle=search-form-close]').click(function () {
        $('.search-form-wrapper').removeClass('open');
        $('html').removeClass('search-form-open');
    });
    $('.search-form-wrapper .search').keypress(function (event) {
        if ($(this).val() == "Search") $(this).val("");
    });

    $('.search-close').click(function (event) {
        $('.search-form-wrapper').removeClass('open');
        $('html').removeClass('search-form-open');
    });

    $("#searchKey").on("keyup", (e) => {
        if (e.keyCode === 13) {
            var keyword = $("#searchKey").val();
//            window.location.href = "/tim-kiem?keyword=" + keyword;
            if (pathName.includes('/en')) {
                window.location.href = "/en/search?keyword=" + keyword;
            } else {
                window.location.href = "/vi/tim-kiem?keyword=" + keyword;
            }
        }
    });

    $("#searchright").on("keyup", (e) => {
        if (e.keyCode === 13) {
            var keyword = $("#searchright").val();
            if (pathName.includes('/en')) {
                window.location.href = "/en/search?keyword=" + keyword;
            } else {
                window.location.href = "/vi/tim-kiem?keyword=" + keyword;
            }
        }
    });

    $('select').on('change', function (e) {

        var optionSelected = $("option:selected", this);
        var valueSelected = this.value;
        var nameSelected = this.name;
        var id = $('#Id').val();
        var data = {
            Year: valueSelected,
            Id: id
        };
//        if (nameSelected === 'InfoYear') {
//            window.location.href = "/quan-he-co-dong?id=" + id + "&infoYear=" + valueSelected;
//        }
//        if (nameSelected === 'ReportFin') {
//            window.location.href = "/quan-he-co-dong?id=" + id + "&reportFin=" + valueSelected;
//        }
//        if (nameSelected === 'ReportYear') {
//            window.location.href = "/quan-he-co-dong?id=" + id + "&reportYear=" + valueSelected;
//        }
//        if (nameSelected === 'Noti') {
//            window.location.href = "/quan-he-co-dong?id=" + id + "&noti=" + valueSelected;
//        }
        if (pathName.includes('/en')){
            if (nameSelected === 'InfoYear') {
                window.location.href = "/en/investors?id=" + id + "&infoYear=" + valueSelected;
            }
            if (nameSelected === 'ReportFin') {
                window.location.href = "/en/investors?id=" + id + "&reportFin=" + valueSelected;
            }
            if (nameSelected === 'ReportYear') {
                window.location.href = "/en/investors?id=" + id + "&reportYear=" + valueSelected;
            }
            if (nameSelected === 'Noti') {
                window.location.href = "/en/investors?id=" + id + "&noti=" + valueSelected;
            }
        } else {
            if (nameSelected === 'InfoYear') {
                window.location.href = "/vi/quan-he-co-dong?id=" + id + "&infoYear=" + valueSelected;
            }
            if (nameSelected === 'ReportFin') {
                window.location.href = "/vi/quan-he-co-dong?id=" + id + "&reportFin=" + valueSelected;
            }
            if (nameSelected === 'ReportYear') {
                window.location.href = "/vi/quan-he-co-dong?id=" + id + "&reportYear=" + valueSelected;
            }
            if (nameSelected === 'Noti') {
                window.location.href = "/vi/quan-he-co-dong?id=" + id + "&noti=" + valueSelected;
            }
        }

        //        fetch(`/Search/GetFile?year=${data.Year}&id=${data.Id}`)
        //            .then((res) => res.json())
        //            .then((res) => {
        //                alert(res);
        //            });

        //        fetch("/api/postgetfile", {
        //            method: "post",
        //            headers: {
        //                "Content-Type": "application/json"
        //            },
        //            body: JSON.stringify(data)
        //        })
        //            .then(function (response) { return response.json(); })
        //            .then(res => {
        //                alert(res);
        //            });
    });

    $('#add-contact').click(function(e) {
		e.preventDefault();
        var contactName = $('#contact-name').val();
        var contactEmail = $('#contact-email').val();
        var contactTitle = $('#contact-title').val();
        var contactContent = $('#contact-content').val();
        var contact = {
            ContactName: contactName,
            ContactEmail: contactEmail,
            ContactTitle: contactTitle,
            ContactContent: contactContent
        };

        if (contactName === "" || contactEmail === "" || contactTitle === "" || contactContent === "") {
            alert("Bạn vui lòng nhập đầy đủ thông tin!");
            return;
        }

        fetch('/Api/AddContact', {
                method: 'POST', // or 'PUT'
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(contact)
            })
            .then((response) => response.json())
            .then((data) => {
                alert('Gửi yêu cầu thành công');
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    });

    $('#apply-cv').click(function (e) {
		e.preventDefault();
        var applyName = $('#apply-name').val();
        var applyEmail = $('#apply-email').val();
        var applyMobile = $('#apply-mobile').val();
        var applyJob = $('#apply-job').val();
        var applyIntro = $('#apply-intro').val();
        var fileUpload = $("#customFile").get(0);
        var files = fileUpload.files;

        if (applyName === "" || applyEmail === "" || applyMobile === "" || applyJob === "" || files.length === 0) {
            alert("Bạn vui lòng nhập đầy đủ thông tin!");
            return;
        }

        if (!files[0].name.includes('.doc') && !files[0].name.includes('.docx') && !files[0].name.includes('.pdf')) {
            alert("Website chỉ hỡ trợ upload *.doc, *.docx, *.pdf");
            return;
        }
        if (files[0].size > 20000) {
            alert("Website chỉ hỡ trợ upload tối đá 2MB");
            return;
        }

        var data = new FormData();

        data.append(files[0].name, files[0]);
        data.append("applyName", applyName);
        data.append("applyEmail", applyEmail);
        data.append("applyPhone", applyMobile);
        data.append("applyJob", applyJob);
        data.append("applyIntro", applyIntro);

        $.ajax({

            type: "POST",

            url: "/api/UploadFile",

            contentType: false,

            processData: false,

            data: data,

            async: false,

            success: function (message) {
                alert('Gửi yêu cầu thành công');
            },

            error: function () {
                alert("Error!");
            }
        });
    });
});
