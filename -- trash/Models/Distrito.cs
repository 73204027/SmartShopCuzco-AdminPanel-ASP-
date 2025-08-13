<?php
require_once '../config/database.php';
class Distrito {
    private $xcon;
    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->conectar();
    }
    public function mostrar() {
        $sql = "SELECT * FROM Distrito WHERE ESTADO=1";
        return $this->xcon->query($sql);
    }
    public function mostrarTodo() {
        $sql = "SELECT * FROM Distrito";
        return $this->xcon->query($sql);
    }
    public function registrar($nombre) {
        $sql = "INSERT INTO Distrito (NOMBRE, ESTADO) VALUES (?, 1)";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('s', $nombre);
        return $stmt->execute();
    }
    public function actualizar($id, $nombre) {
        $sql = "UPDATE Distrito SET NOMBRE=? WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('si', $nombre, $id);
        return $stmt->execute();
    }
    public function contarActivos() {
        $sql = "SELECT COUNT(*) as total FROM Distrito WHERE ESTADO=1";
        $res = $this->xcon->query($sql);
        return $res->fetch_assoc()['total'];
    }
    public function listarPaginado($offset, $limit) {
        $sql = "SELECT * FROM Distrito WHERE ESTADO=1 LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
    public function contarTotal() {
        $sql = "SELECT COUNT(*) as total FROM Distrito";
        $res = $this->xcon->query($sql);
        return $res->fetch_assoc()['total'];
    }
    public function listarTodoPaginado($offset, $limit) {
        $sql = "SELECT * FROM Distrito LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
    public function buscarPorId($id) {
        $sql = "SELECT * FROM Distrito WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        $stmt->execute();
        return $stmt->get_result()->fetch_assoc();
    }
    public function deshabilitar($id) {
        $sql = "UPDATE Distrito SET ESTADO=0 WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        return $stmt->execute();
    }
    public function habilitar($id) {
        $sql = "UPDATE Distrito SET ESTADO=1 WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        return $stmt->execute();
    }
}
?>
