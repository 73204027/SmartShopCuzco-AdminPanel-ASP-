<?php
require_once '../config/database.php';
class Cargo {
    private $xcon;
    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->conectar();
    }
    public function mostrar() {
        $sql = "SELECT * FROM Cargo WHERE ESTADO=1";
        return $this->xcon->query($sql);
    }
    public function mostrarTodo() {
        $sql = "SELECT * FROM Cargo";
        return $this->xcon->query($sql);
    }
    public function registrar($nombre) {
        $sql = "INSERT INTO Cargo (NOMBRE, ESTADO) VALUES (?, 1)";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('s', $nombre);
        return $stmt->execute();
    }
    public function actualizar($id, $nombre) {
        $sql = "UPDATE Cargo SET NOMBRE=? WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('si', $nombre, $id);
        return $stmt->execute();
    }
    public function contarActivos() {
        $sql = "SELECT COUNT(*) as total FROM Cargo WHERE ESTADO=1";
        $res = $this->xcon->query($sql);
        return $res->fetch_assoc()['total'];
    }
    public function listarPaginado($offset, $limit) {
        $sql = "SELECT * FROM Cargo WHERE ESTADO=1 LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
    public function contarTotal() {
        $sql = "SELECT COUNT(*) as total FROM Cargo";
        $res = $this->xcon->query($sql);
        return $res->fetch_assoc()['total'];
    }
    public function listarTodoPaginado($offset, $limit) {
        $sql = "SELECT * FROM Cargo LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
    public function buscarPorId($id) {
        $sql = "SELECT * FROM Cargo WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        $stmt->execute();
        return $stmt->get_result()->fetch_assoc();
    }
    public function deshabilitar($id) {
        $sql = "UPDATE Cargo SET ESTADO=0 WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        return $stmt->execute();
    }
    public function habilitar($id) {
        $sql = "UPDATE Cargo SET ESTADO=1 WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        return $stmt->execute();
    }
}
?>
