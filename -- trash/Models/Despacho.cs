<?php
require_once '../config/database.php';

class Despacho {
    private $xcon;


    public function __construct() {
        $db = new Conexion();
        $this->xcon = $db->Conectar();
    }


    public function MostrarDespacho() {
        $sql = "SELECT * FROM despacho WHERE estado = 1";
        return $this->xcon->query($sql);
    }

   
    public function MostrarDespachoTodo() {
        $sql = "SELECT * FROM despacho";
        return $this->xcon->query($sql);
    }


    public function BuscarDespachoXCodigo($codigo) {
        $sql = "SELECT * FROM despacho WHERE coddes = $codigo";
        return $this->xcon->query($sql);
    }


    public function RegistrarDespacho($producto, $destino, $fecha, $estado) {
        $sql = "INSERT INTO despacho(producto, destino, fecha, estado) 
                VALUES('$producto', '$destino', '$fecha', $estado)";
        return $this->xcon->query($sql);
    }

    
    public function ActualizarDespacho($coddes, $producto, $destino, $fecha, $estado) {
        $sql = "UPDATE despacho 
                SET producto = '$producto', destino = '$destino', fecha = '$fecha', estado = $estado 
                WHERE coddes = $coddes";
        return $this->xcon->query($sql);
    }

    
    public function EliminarDespacho($coddes) {
        $sql = "UPDATE despacho SET estado = 0 WHERE coddes = $coddes";
        return $this->xcon->query($sql);
    }

    
    public function HabilitarDespacho($coddes) {
        $sql = "UPDATE despacho SET estado = 1 WHERE coddes = $coddes";
        return $this->xcon->query($sql);
    }
}
?>
