<?php

header("Content-Type: application/json; charset=UTF-8");

$requestInput = file_get_contents("php://input");

if(strlen($requestInput) < 10) {
    exit("Invalid Request");
}

//parse incoming JSON requests and send to the appropriate API function

require_once('API.php');
$api = new API();

$json = json_decode($requestInput, true);

//REQUEST CLIENT ID
if($json['TYPE'] == REQUEST_GET_CLIENT_IDENTIFIER) {

    echo $api->getClientIdentifier();

}
//REQUEST CLIENT CREATE CHAT
else if($json['TYPE'] == REQUEST_CLIENT_CREATE_CHAT) {

    echo $api->clientCreateChat($json);

}
//REQUEST CLIENT JOIN CHAT
else if($json['TYPE'] == REQUEST_CLIENT_JOIN_CHAT) {

    echo $api->clientJoinChat($json);

}
//REQUEST CLIENT SEND MESSAGE TO CHAT
else if($json['TYPE'] == REQUEST_CLIENT_SEND_CHAT_MESSAGE) {

    echo $api->sendMessage($json);

}
//REQUEST CHAT CHECK FOR MESSAGES
else if($json['TYPE'] == REQUEST_CHAT_CHECK_MESSAGE) {

    echo $api->checkForMessages($json);

}





?>




