<?php

/**
 * Database short summary.
 *
 * Database description.
 *
 * @version 1.0
 * @author Robert
 */
 require_once('DatabaseConfig.php');

class Database
{
    /**
     * @var \PDO
     */
    private $pdo;

    private $bConnected = false;


    public function __construct() {

        $this->connect(DatabaseConfig::$hostname, DatabaseConfig::$database, DatabaseConfig::$username, DatabaseConfig::$password);
        $this->parameters = array();

    }

    private function connect($hostname, $database, $username, $password) {

        $dsn = 'mysql:dbname='.$database.';host='.$hostname;
        $options = [
            \PDO::ATTR_EMULATE_PREPARES   => false, // turn off emulation mode for "real" prepared statements
            \PDO::ATTR_ERRMODE            => \PDO::ERRMODE_EXCEPTION, //turn on errors in the form of exceptions
            \PDO::ATTR_DEFAULT_FETCH_MODE => \PDO::FETCH_ASSOC, //make the default fetch be an associative array
        ];

        try {
            $this->pdo = new \PDO($dsn, $username, $password, $options);
            $this->bConnected = true;
        }
        catch (\PDOException $e) {
            echo $e->getMessage();
            die();
        }

    }

    public function close(){

        $this->pdo = null;

    }

    public function query($query, array $params) {

        $stmt = $this->pdo->prepare($query);
        $stmt->execute();
        $arr = $stmt->fetchAll(\PDO::FETCH_ASSOC);

        $stmt = null;


        return $arr;
    }

    public function select($table, $columns, array $clauses) {

        //TODO:sanitise and prepare

        $sql = "SELECT ";

        if($columns != null && count($columns) > 0) {
            $last = end($columns);
            foreach ($columns as $column => $value) {

                if($value != $last) {
                    $sql .= "`".$value."`, ";
                }
                else {
                    $sql .= "`".$value . "` FROM ".$table." ";
                }
            }
        }else {
            $sql .= "* FROM `".$table."` ";
        }

        //parse the clauses and build the query
        //[['id', '=', '1']]
        if($clauses != null && count($clauses) > 0) {

            $sql .= "WHERE ";
            $last = end($clauses);
            foreach ($clauses as $clause => $value) {

                if($value != $last)
                    $sql .= "`".$value[0]."` ". $value[1]. " \"".$value[2]."\" AND ";
                else
                    $sql .= "`".$value[0]."` ". $value[1]. " \"".$value[2]."\" ";
            }
        }else {
            $sql .= "* FROM`".$table."` ";
        }


        $stmt = $this->pdo->prepare($sql);
        $stmt->execute();
        $arr = $stmt->fetchAll(\PDO::FETCH_ASSOC);
        $stmt = null;

        return $arr;

    }

    public function insert($table, $columns, array $values) {

        $sql = "INSERT INTO `".$table."` (";

        $last = end($columns);
        foreach ($columns as $column=>$value) {

            if($value != $last) {
                $sql .= "`".$value."`, ";
            }
            else {
                $sql .= "`".$value . "`) ";
            }

        }

        $sql.= "VALUES(";
        foreach ($columns as $column)  {

            if($column != $last) {
                $sql .= "?,";
            }
            else {
                $sql .= "?) ";
            }

        }

        $stmt = $this->pdo->prepare($sql);
        $stmt->execute($values);

        $stmt = null;

    }

    public function update($table, array $columns, array $values, $id) {

        $sql = "UPDATE `".$table."` SET ";

        $last = end($columns);
        foreach ($columns as $column=>$value) {

            if($value != $last) {
                $sql .= "`".$value."`=?, ";
            }
            else {
                $sql .= "`".$value . "`=? ";
            }

        }

        $sql.= "WHERE id = ?";

        $values[] = $id;

        $stmt = $this->pdo->prepare($sql);
        $stmt->execute($values);

        $stmt = null;

    }
    
    

    public function exec($query, array $params) {

        $stmt = $this->pdo->prepare($query);
        $stmt->execute($params);

    }

    public function errorCode() {

        return $this->pdo->errorCode();

    }

    public function errorInfo() {

        return $this->pdo->errorInfo();

    }

}