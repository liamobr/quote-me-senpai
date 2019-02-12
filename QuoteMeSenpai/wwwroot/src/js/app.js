$(document).ready(function () {

    $('#generate-button').click(function () {
        getQuote();
    });

    getQuote();
});

function getQuote() {
    var antiForgeryToken = $('input[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: "/getquote",
        type: "POST",
        dataType: "json",
        data: { '__RequestVerificationToken': antiForgeryToken },
        success: function (data) {
            var content = data.content;
            var citation = data.citation;
            console.log(content);
            $('#quote-content').html(content);
            $('#quote-cite').html(citation);
        },
        error: function (err) {
            console.log(err);
        }
    });
}