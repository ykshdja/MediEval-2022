

var connection = null;
var connectedUsers = [];

$(function () {
    if (connection === null) {
        connection = new signalR.HubConnectionBuilder()
            .withUrl("/hubs/chat")
            .build();

        connection.on("Broadcast", function (response) {
            $("#chatRoom").append(
                '<div class="media w-50 ml-auto mb-3">' +
                '<img src="~/Images/icon-chat3.png" alt="user" width="50" class="rounded-circle">' +
                '<div class="media-body">' +
                '<div class="bg-primary rounded py-2 px-3 mb-2">' +
                '<p class="text-small mb-0 text-white">' + response.messageBody + '</p>' +
                '</div>' +
                '<p class="small text-muted">' + response.fromUser + '</p>' +
                '<p class="small text-muted">' + response.messageDtTm + '</p>' +
                '</div>' +
                '</div>'
            );

            $('#chatRoom').stop().animate({
                scrollTop: $('#chatRoom')[0].scrollHeight
            });
        });

        connection.on("UserConnected", function (response) {
            if (userid == response.connectionId) {
                return;
            }
            else if (connectedUsers.indexOf(response.connectionId) >= 0) {
                return;

            }

            connectedUsers.push(response.connectionId);

            $("#chatUsers").append(
                '<a class="list-group-item list-group-item-action active text-white rounded-0">' +
                '<div class= "media">' +
                '<img src="/Images/chat-photo.png" alt="user" width="50" class="rounded-circle">' +
                '<div class="media-body ml-4">' +
                '<div class="d-flex align-items-center justify-content-between mb-1">' +
                '<h6 class="mb-0">' + response.userName + '</h6><small class="small font-weight-bold">' + response.connectionDtTm + '</small>' +
                '</div>' +
                '<p class="font-italic mb-0 text-small">' + response.connectionId + '</p>' +
                '</div>' +
                '</div>' +
                '</a>'
            );

            $("#chatRoom").append(
                '<div class="media w-50 mb-3">' +
                '<img src="/Images/icon-chat2.png" alt="user" width="50" class="rounded-circle">' +
                '<div class="media-body ml-3">' +
                '<div class="bg-light rounded py-2 px-3 mb-2">' +
                '<p class="text-small mb-0 text-muted">Welcome to the Chat Room!</p>' +
                '</div>' +
                '<p class="small text-muted">' + response.messageDtTm + '</p>' +
                '</div>'
            );
        });

        connection.on("UserDisconnected", function (message) {
           
            alert(message);
        });

        connection.on("HubError", function (response) {
            alert(response.error);
        });

        connection.start().then(function () {
            document.getElementById('sendButton').onclick = function () {
                var message = document.getElementById("messageInput").value;
                connection.invoke("BroadcastFromClient", message)
                    .catch(function (err) {
                        return console.error(err.toString());
                    });
            };
        });
    }
});



/*********************** Basic - Chat ****************************************************/

//var connectionChat = new signalR.HubConnectionBuilder().withUrl("/hubs/chat").build();

//document.getElementById("sendMessage").disabled = true;

//connectionChat.on("MessageReceived", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    li.textContent = `${user} - ${message}`;
//});

///******************************************************/
//document.getElementById("sendMessage").addEventListener("click", function (event) {
//    var sender = document.getElementById("senderEmail").value;
//    var message = document.getElementById("chatMessage").value;
//    var receiver = document.getElementById("receiverEmail").value;

//    if (receiver.length > 0) {
//        connectionChat.send("SendMessageToReceiver", sender, receiver, message);
//    }
//    else {
//        //send message to all of the users
//        connectionChat.send("SendMessageToAll", sender, message).catch(function (err) {
//            return console.error(err.toString());
//        });
//    }
//    event.preventDefault();
//});
///******************************************************/



//connectionChat.start().then(function () {
//    document.getElementById("sendMessage").disabled = false;
//});

/***********************Basic - Chat ****************************************************/
