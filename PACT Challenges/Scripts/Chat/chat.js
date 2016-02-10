// Detect enter key press
$("#message").keyup(function (e) {
    if (event.keyCode == 13) {
        $("#sendmessage").click();
    }
});

$(function () {
    var chat = $.connection.chatHub;
    chat.client.addNewMessageToPage = function (name, message) {
        $('#discussion').append('<li><strong>' + htmlEncode(name)
            + '</strong>: ' + htmlEncode(message) + '</li>');
    };
    // Get and store username to messages
    $('#displayname').val(prompt('Enter your name:', ''));
    // Set initial focus to message input box.
    $('#message').focus();
    // Start connection
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method to the hub
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus
            $('#message').val('').focus();
        });
    });
});
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}