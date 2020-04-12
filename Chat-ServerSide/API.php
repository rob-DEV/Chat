<?php

require_once('Constants.php');
require_once('Database.php');

class API 
{
    private $database;

    public function __construct() {
        $this->database = new Database();
    }

    public function getClientIdentifier() {
        
        //return uniqueID, token, shortID
        //database to store these attrribute

        $uniqueID = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 32);
        $token = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 16);
        $shortID = substr(base64_encode(md5(mt_rand())), 0, 8);

        $this->database->insert('client', ['unique_id', 'token_hash', 'short_id'], [$uniqueID, hash('sha256', $token), $shortID]);

        $responseArray = ['TYPE' => RESPONSE_CLIENT_INDENTIFIER, 'CLIENT_UNIQUE_ID' => $uniqueID, 'CLIENT_TOKEN' => $token, 'CLIENT_SHORT_ID' => $shortID];

        return json_encode($responseArray);
        
    }

    public function clientCreateChat($requestJson) {
        
        //return uniqueID, token, shortID
        //database to store these attrribute

        $uniqueID = $requestJson['CLIENT_UNIQUE_ID'];
        $token = $requestJson['CLIENT_TOKEN'];
        
        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueID], ['token_hash', '=', hash('sha256', $token)]]);

        if(count($result) != 1) {
            exit("FAILED TO FIND CLIENT DETAILS");
        }

        $uniqueChatID = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 16);
        $shortID = substr(base64_encode(md5(mt_rand())), 0, 6);

        $this->database->insert('chat', ['unique_id', 'short_id'], [$uniqueChatID, $shortID]);

        
        $responseArray = ['TYPE' => RESPONSE_CLIENT_CREATE_CHAT, 'CLIENT_UNIQUE_ID' => $uniqueID, 'CHAT_UNIQUE_ID' => $uniqueChatID, 'CHAT_SHORT_ID' => $shortID];

        return json_encode($responseArray);
        
    }

    public function sendMessage($requestJson) {
        
        $uniqueClientID = $requestJson['CLIENT_UNIQUE_ID'];
        $clientToken = $requestJson['CLIENT_TOKEN'];

        $uniqueID = $requestJson['CLIENT_UNIQUE_ID'];
        $uniqueChatID = $requestJson['CHAT_UNIQUE_ID'];
        $messageSender = $requestJson['MESSAGE_SENDER'];
        $messageContent = $requestJson['MESSAGE_CONTENT'];

        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueClientID], ['token_hash', '=', hash('sha256', $clientToken)]]);

        if(count($result) != 1) {
            exit("FAILED TO FIND CLIENT DETAILS");
        }

        $messageUniqueID = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 16);
        $this->database->insert('message', ['unique_id', 'unique_chat_id', 'message_sender', 'message_content'], [$messageUniqueID, $uniqueChatID, $$messageSender, $messageContent]);

        
        $responseArray = ['TYPE' => RESPONSE_CLIENT_SEND_CHAT_MESSAGE, 'ERRORS' => 0];

        return json_encode($responseArray);
        
    }

}


// chat id : 6 length base 64 word
// create client : client PK : pub_key_enc(uniqueID)
// create chat   : client id, client PK : pub_key_enc(uniqueChatID)
// join chat     : client id, client PK :
// leave chat    :




?>