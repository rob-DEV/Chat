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

        $responseArray = ['CLIENT_UNIQUE_ID' => $uniqueID, 'CLIENT_TOKEN' => $token, 'CLIENT_SHORT_ID' => $shortID];

        return json_encode($responseArray);
        
    }

    public function clientCreateChat($requestJson) {
        
        //return uniqueID, token, shortID
        //database to store these attrribute

        
        

        return json_encode($responseArray);
        
    }

}


// chat id : 6 length base 64 word
// create client : client PK : pub_key_enc(uniqueID)
// create chat   : client id, client PK : pub_key_enc(uniqueChatID)
// join chat     : client id, client PK :
// leave chat    :




?>