<?php

require_once('Constants.php');
require_once('Database.php');

class API 
{
    private $database;

    public function __construct() {
        $this->database = new Database();
    }

    public function getClientIdentifier($requestJson) {
        
        $clientPublicKey = $requestJson['CLIENT_PUBLIC_KEY'];

        $clientUniqueID = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 32);
        $token = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 16);
        $shortID = substr(base64_encode(md5(mt_rand())), 0, 8);

        $this->database->insert('client', ['unique_id', 'token_hash', 'short_id', 'public_key'], [$clientUniqueID, hash('sha256', $token), $shortID, $clientPublicKey]);

        $responseArray = ['TYPE' => RESPONSE_CLIENT_INDENTIFIER, 'CLIENT_UNIQUE_ID' => $clientUniqueID, 'CLIENT_TOKEN' => $token, 'CLIENT_SHORT_ID' => $shortID];

        return json_encode($responseArray);
        
    }

    public function clientCreateChat($requestJson) {
        
        //return uniqueID, token, shortID
        //database to store these attrribute

        $uniqueClientID = $requestJson['CLIENT_UNIQUE_ID'];
        $token = $requestJson['CLIENT_TOKEN'];
        $password = $requestJson['CHAT_PASSWORD'];
        
        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueClientID], ['token_hash', '=', hash('sha256', $token)]]);

        if(count($result) != 1) {
            $responseArray = ['TYPE' => RESPONSE_CLIENT_CREATE_CHAT, 'Errors' => ['FAILED TO FIND A CLIENT WITH THAT ID OR TOKEN!']];
            return json_encode($responseArray);
        }

        $uniqueChatID = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 16);
        $shortID = substr(base64_encode(md5(mt_rand())), 0, 6);

        $this->database->insert('chat', ['unique_id', 'short_id', 'password_hash'], [$uniqueChatID, $shortID, password_hash($password, PASSWORD_DEFAULT)]);
        $this->database->insert('chat_client', ['unique_client_id', 'unique_chat_id'], [$uniqueClientID, $uniqueChatID]);

        
        $responseArray = ['TYPE' => RESPONSE_CLIENT_CREATE_CHAT, 'CLIENT_UNIQUE_ID' => $uniqueClientID, 'CHAT_UNIQUE_ID' => $uniqueChatID, 'CHAT_SHORT_ID' => $shortID];

        return json_encode($responseArray);
        
    }

    public function clientJoinChat($requestJson) {
        
        //return uniqueID, token, shortID
        //database to store these attrribute

        $uniqueClientID = $requestJson['CLIENT_UNIQUE_ID'];
        $token = $requestJson['CLIENT_TOKEN'];

        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueClientID], ['token_hash', '=', hash('sha256', $token)]]);

        if(count($result) != 1) {
            $responseArray = ['TYPE' => RESPONSE_CLIENT_JOIN_CHAT, 'Errors' => ['FAILED TO FIND A CLIENT WITH THAT ID OR TOKEN!']];
            return json_encode($responseArray);
        }

        $chatShortID = $requestJson['CHAT_SHORT_ID'];
        $chatPassword = $requestJson['CHAT_PASSWORD'];

        //TODO: validate password for chat member authentication

        $result = $this->database->select('chat', ['unique_id', 'short_id', 'password_hash'], [['short_id', '=', $chatShortID]]);

        if(count($result) != 1) {
            $responseArray = ['TYPE' => RESPONSE_CLIENT_JOIN_CHAT, 'Errors' => ['FAILED TO FIND A CHAT WITH THAT SHORT ID!']];
            return json_encode($responseArray);
        }

        $passwordHash = $result[0]['password_hash'];

        if(!password_verify($chatPassword, $passwordHash)) {
            $responseArray = ['TYPE' => RESPONSE_CLIENT_JOIN_CHAT, 'Errors' => ['PASSWORD VERIFICATION FAILED!']];
            return json_encode($responseArray);
        }

        //insert client into chat_client
        $this->database->insert('chat_client', ['unique_client_id', 'unique_chat_id'], [$uniqueClientID, $result[0]['unique_id']]);


        $responseArray = ['TYPE' => RESPONSE_CLIENT_CREATE_CHAT, 'CLIENT_UNIQUE_ID' => $uniqueClientID, 'CHAT_UNIQUE_ID' => $result[0]['unique_id'], 'CHAT_SHORT_ID' => $chatShortID];

        return json_encode($responseArray);
        
    }

    public function chatGetConnectedClients($requestJson) {
        
        $uniqueClientID = $requestJson['CLIENT_UNIQUE_ID'];
        $clientToken = $requestJson['CLIENT_TOKEN'];
        $uniqueChatID = $requestJson['CHAT_UNIQUE_ID'];
    
        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueClientID], ['token_hash', '=', hash('sha256', $clientToken)]]);

        if(count($result) != 1) {
            $responseArray = ['TYPE' => RESPONSE_CLIENT_SEND_CHAT_MESSAGE, 'Errors' => ['FAILED TO FIND A CLIENT WITH THAT ID OR TOKEN!']];
            return json_encode($responseArray);
        }

        $params = [];
        $params []= $uniqueChatID;

        //SQL INJECTION VUNERABILITY FIX TODO:
        $sql = "SELECT unique_client_id, public_key FROM `chat_client` inner join client on chat_client.unique_client_id = client.unique_id where unique_chat_id = '". $uniqueChatID."'";

        $connectedClients = $this->database->query($sql, []);

        $responseArray = ['TYPE' => RESPONSE_CHAT_CONNECTED_CLIENTS, 'CONNECTED_CLIENTS' => json_encode($connectedClients, true)];

        return json_encode($responseArray);
        
    }

    public function sendMessage($requestJson) {
        
        $uniqueClientID = $requestJson['CLIENT_UNIQUE_ID'];
        $clientToken = $requestJson['CLIENT_TOKEN'];
        $uniqueChatID = $requestJson['CHAT_UNIQUE_ID'];

        $clientMessages = json_decode($requestJson['CHAT_CLIENT_MESSAGES'], true);

        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueClientID], ['token_hash', '=', hash('sha256', $clientToken)]]);

        if(count($result) != 1) {
            $responseArray = ['TYPE' => RESPONSE_CLIENT_SEND_CHAT_MESSAGE, 'Errors' => ['FAILED TO FIND A CLIENT WITH THAT ID OR TOKEN!']];
            return json_encode($responseArray);
        }

        
        //$messageUniqueID = substr(base_convert(sha1(uniqid(mt_rand())),16,36), 0, 16);

        foreach($clientMessages as $message) {

            $this->database->insert('message', ['unique_client_id', 'unique_chat_id','crypt_aes_key','crypt_aes_iv', 'message_content'], [$message['unique_client_id'], $message['unique_chat_id'], $message['crypt_aes_key'], $message['crypt_aes_iv'],$message['message_content']]);


        }
        
        $responseArray = ['TYPE' => RESPONSE_CLIENT_SEND_CHAT_MESSAGE, 'ERRORS' => 0];

        return json_encode($responseArray);
        
    }

    public function checkForMessages($requestJson) {
        
        $uniqueClientID = $requestJson['CLIENT_UNIQUE_ID'];
        $clientToken = $requestJson['CLIENT_TOKEN'];
        $uniqueChatID = $requestJson['CHAT_UNIQUE_ID'];

        //check the request details and send created chat details
        $result = $this->database->select('client', ['unique_id', 'token_hash'], [['unique_id', '=', $uniqueClientID], ['token_hash', '=', hash('sha256', $clientToken)]]);

        if(count($result) != 1) {
            $responseArray = ['TYPE' => RESPONSE_CHAT_CHECK_MESSAGE, 'Errors' => ['FAILED TO FIND A CLIENT WITH THAT ID OR TOKEN!']];
            return json_encode($responseArray);
        }

        $result = $this->database->select('message', ['unique_client_id', 'unique_chat_id','crypt_aes_key','crypt_aes_iv', 'message_content'], [['unique_client_id', '=', $uniqueClientID],['unique_chat_id', '=', $uniqueChatID]]);

        
        $responseArray = ['TYPE' => RESPONSE_CHAT_CHECK_MESSAGE, 'MESSAGES' => json_encode($result, true)];

        return json_encode($responseArray);
        
    }

}


// chat id : 6 length base 64 word
// create client : client PK : pub_key_enc(uniqueID)
// create chat   : client id, client PK : pub_key_enc(uniqueChatID)
// join chat     : client id, client PK :
// leave chat    :




?>