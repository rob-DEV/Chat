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

if($json['REQUEST_TYPE'] == REQUEST_GET_CLIENT_IDENTIFIER) {

    echo $api->getClientIdentifier();

}
else if($json['REQUEST_TYPE'] == REQUEST_CLIENT_CREATE_CHAT) {

    echo $api->clientCreateChat($json);

}





?>




