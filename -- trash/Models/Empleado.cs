<?php
require_once '../config/database.php';
class Empleado {
    private $xcon;
    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->conectar();
    }
    public function mostrar() {
        $sql = "SELECT * FROM Empleado WHERE ESTADO=1";
        return $this->xcon->query($sql);
    }
    public function mostrarTodo() {
        $sql = "SELECT * FROM Empleado";
        return $this->xcon->query($sql);
    }
    public function registrar($nombre, $descripcion, $precio, $cantidad) {
        $sql = "INSERT INTO Empleado (NOMBRE, DESCRIPCION, PRECIO, CANTIDAD, ESTADO) VALUES (?, ?, ?, ?, 1)";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('ssdi', $nombre, $descripcion, $precio, $cantidad);
        return $stmt->execute();
    }
    public function actualizar($id, $nombre, $descripcion, $precio, $cantidad) {
        $sql = "UPDATE Empleado SET NOMBRE=?, DESCRIPCION=?, PRECIO=?, CANTIDAD=? WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('ssdii', $nombre, $descripcion, $precio, $cantidad, $id);
        return $stmt->execute();
    }
    public function contarActivos() {
        $sql = "SELECT COUNT(*) as total FROM Empleado WHERE ESTADO=1";
        $res = $this->xcon->query($sql);
        return $res->fetch_assoc()['total'];
    }
    public function listarPaginado($offset, $limit) {
        $sql = "SELECT * FROM Empleado WHERE ESTADO=1 LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
    public function contarTotal() {
        $sql = "SELECT COUNT(*) as total FROM Empleado";
        $res = $this->xcon->query($sql);
        return $res->fetch_assoc()['total'];
    }
    public function listarTodoPaginado($offset, $limit) {
        $sql = "SELECT * FROM Empleado LIMIT $limit OFFSET $offset";
        return $this->xcon->query($sql);
    }
    public function buscarPorId($id) {
        $sql = "SELECT * FROM Empleado WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        $stmt->execute();
        return $stmt->get_result()->fetch_assoc();
    }
    public function deshabilitar($id) {
        $sql = "UPDATE Empleado SET ESTADO=0 WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        return $stmt->execute();
    }
    public function habilitar($id) {
        $sql = "UPDATE Empleado SET ESTADO=1 WHERE ID=?";
        $stmt = $this->xcon->prepare($sql);
        $stmt->bind_param('i', $id);
        return $stmt->execute();
    }
}
?>
