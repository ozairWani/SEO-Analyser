$(function () {
    $("#tabs").tabs();
});

$(function () {
    $('#errorDisplay').hide();
});

reset = function () {

    $('#SpotWords').prop("checked", true);
    $('#Words').prop("checked", true);
    $('#MetaTags').prop("checked", true);
    $('#externalLinks').prop("checked", true);
    $('#txtSreach').val('');
};

$("#btnShow").click(function (e) {

    $('#errorDisplay').hide();

    var searchtext = $("#txtSreach").val();
    if ($.trim(searchtext) == "") {
        alert('Please enter Text or URL for Analysis!');
        return;
    }

    var model = {
        IsStopWord: $('#SpotWords').is(':checked'),
        IsWordCount: $('#Words').is(':checked'),
        IsMetaTags: $('#MetaTags').is(':checked'),
        IsExternalLinks: $('#externalLinks').is(':checked'),
        SearchText: $("#txtSreach").val()
    }


    $.ajax({
        url: 'SEOAnalyser/AnalyseData',
        type: 'Get',
        data: model,
        success: function (data) {
            //$.noConflict();
            if (data.ResponseCode) {
                var content = data.Content;
                var jsonData = $.parseJSON(data.Content);
                var WordsCount = jsonData.WordsCount;
                var MetatagsCount = jsonData.MetatagsCount;
                var LinksCount = jsonData.LinksCount;

                $('#WordsCount tbody').empty();
                $('#MetaTag tbody').empty();
                $('#ExternalLinks tbody').empty();

                $.each(WordsCount, function (i, item) {
                    var rows = "<tr>" + "<td>" + i + "</td>" + "<td>" + item + "</td>" + "</tr>";
                    $('#WordsCount tbody').append(rows);
                });
                $.each(LinksCount, function (i, item) {
                    var rows = "<tr>" + "<td>" + i + "</td>" + "<td>" + item + "</td>" + "</tr>";
                    $('#ExternalLinks tbody').append(rows);
                });

                $.each(MetatagsCount, function (i, item) {
                    var rows = "<tr>" + "<td>" + i + "</td>" + "<td>" + item + "</td>" + "</tr>";
                    $('#MetaTag tbody').append(rows);
                });

                $('#WordsCount').DataTable();
                $('#ExternalLinks').DataTable();
                $('#MetaTag').DataTable();
            }
            else {
                console.log(data.Content);
                $('#errorDisplay').show();
                $('#error').text(data.Content);
            }
        }
    });
});
