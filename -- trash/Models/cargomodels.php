<?php
require_once '../config/database.php';

class Cargo {
    private $xcon;

    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->Conectar();
    }


    public function MostrarCargo() {
        $sql = "SELECT * FROM Cargo WHERE estcar = 1";
        return $this->xcon->query($sql);
    }

  
    public function MostrarCargoTodo() {
        $sql = "SELECT * FROM Cargo";
        return $this->xcon->query($sql);
    }

    public function RegistrarCargo($nombre) {
        $sql = "INSERT INTO Cargo (nomcar, estcar) VALUES (?, 1)";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('s', $nombre);
        return $stmt->execute();
    }


    public function ActualizarCargo($id, $nombre) {
        $sql = "UPDATE Cargo SET nomcar = ? WHERE codcar = ?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('si', $nombre, $id);
        return $stmt->execute();
    }

    
    public function CambiarEstadoCargo($id, $estado) {
        $sql = "UPDATE Cargo SET estcar = ? WHERE codcar = ?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('ii', $estado, $id);
        return $stmt->execute();
    }


    public function ContarCargos() {
        $sql = "SELECT COUNT(*) as total FROM Cargo";
        $result = $this->xcon->query($sql);
        return $result->fetch_assoc()['total'];
    }

   
    public function ListarConPaginacion($offset, $limit) {
        $sql = "SELECT * FROM Cargo LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
}
?>
