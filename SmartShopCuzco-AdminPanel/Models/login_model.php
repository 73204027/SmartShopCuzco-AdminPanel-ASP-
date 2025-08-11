<?php

require_once '../config/database.php';

class login {
    private $xcon;

    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->Conectar();
    }

    public function autenticar($usuario, $password) {
        $sql = "SELECT * FROM Empleado WHERE USUARIO=? AND CLAVE=? AND ESTADO=1";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('ss', $usuario, $password);
        $stmt->execute();
        return $stmt->get_result()->fetch_assoc();
    }
}

?>