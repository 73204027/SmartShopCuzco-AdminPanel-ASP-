<?php
require_once '../config/database.php';

class Cliente {
    private $xcon;

    // Constructor
    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->Conectar();
    }

    // Listamos los clientes habilitados
    public function MostrarCliente() {
        $sql = "SELECT * FROM cliente WHERE estcli = 1";
        return $this->xcon->query($sql);
    }

    // Listamos todos los clientes
    public function MostrarClienteTodo() {
        $sql = "SELECT * FROM cliente";
        return $this->xcon->query($sql);
    }

    // Buscamos cliente por codigo
    public function BuscarClienteXCodigo($codigo) {
        $sql = "SELECT * FROM cliente WHERE codcli = $codigo";
        return $this->xcon->query($sql);
    }

    // Registramos un cliente
    public function RegistrarCliente($nomcli, $apecli, $dnicli, $estcli) {
        $sql = "INSERT INTO cliente(nomcli, apecli, dnicli, estcli)
                VALUES('$nomcli', '$apecli', '$dnicli', $estcli)";
        return $this->xcon->query($sql);
    }

    // Actualizamos un cliente
    public function ActualizarCliente($codcli, $nomcli, $apecli, $dnicli, $estcli) {
        $sql = "UPDATE cliente SET
                    nomcli = '$nomcli',
                    apecli = '$apecli',
                    dnicli = '$dnicli',
                    estcli = $estcli
                WHERE codcli = $codcli";
        return $this->xcon->query($sql);
    }


    public function EliminarCliente($codcli) {
        $sql = "UPDATE cliente SET estcli = 0 WHERE codcli = $codcli";
        return $this->xcon->query($sql);
    }

    public function HabilitarCliente($codcli) {
        $sql = "UPDATE cliente SET estcli = 1 WHERE codcli = $codcli";
        return $this->xcon->query($sql);
    }
}
?>
