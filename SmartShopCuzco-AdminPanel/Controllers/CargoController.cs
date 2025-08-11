<?php
require_once '../models/cargo_model.php';
require_once '../config/export.php'; 
class cargo_controller {
    private $modelo;
    public function __construct() {
        $this->modelo = new Cargo();
    }
    public function listar() {
        $limit = 10;
        $page = isset($_GET['page'])? max(1,(int)$_GET['page']) : 1;
        $offset = ($page-1)*$limit;
        $total = $this->modelo->contarActivos();
        $items = $this->modelo->listarPaginado($offset, $limit);
        $totalPages = ceil($total/$limit);
        require_once '../views/cargo/listar_cargo.php';
    }
    public function listarTodo() {
        $limit = 10;
        $page = isset($_GET['page'])? max(1,(int)$_GET['page']) : 1;
        $offset = ($page-1)*$limit;
        $total = $this->modelo->contarTotal();
        $items = $this->modelo->listarTodoPaginado($offset, $limit);
        $totalPages = ceil($total/$limit);
        require_once '../views/cargo/habilitar_cargo.php';
    }
    public function cargarRegistrar() {
        require_once '../views/cargo/registrar_cargo.php';
    }
    public function cargarActualizar() {
        if(isset($_GET['id'])) {
            $item = $this->modelo->buscarPorId($_GET['id']);
            require_once '../views/cargo/actualizar_cargo.php';
        } else {
            header('Location: index.php?controller=cargo&action=listar'); exit;
        }
    }
    public function registrar() {
        if($_SERVER['REQUEST_METHOD']==='POST' && isset($_POST['NOMBRE'])) {
            $this->modelo->registrar($_POST['NOMBRE']);
        }
        header('Location: index.php?controller=cargo&action=listar'); exit;
    }
    public function actualizar() {
        if($_SERVER['REQUEST_METHOD']==='POST' && isset($_POST['ID'],$_POST['NOMBRE'])) {
            $this->modelo->actualizar($_POST['ID'],$_POST['NOMBRE']);
        }
        header('Location: index.php?controller=cargo&action=listar'); exit;
    }
    public function deshabilitar() {
        if(isset($_GET['id'])) $this->modelo->deshabilitar($_GET['id']);
        header('Location: index.php?controller=cargo&action=listar'); exit;
    }
    public function habilitar() {
        if(isset($_GET['id'])) $this->modelo->habilitar($_GET['id']);
        header('Location: index.php?controller=cargo&action=listarTodo'); exit;
    }
public function exportar() {
        $tablaHtml = $_POST['tablaHtml'];
        $formato = $_REQUEST['formato'] ?? 'pdf';


        if ($formato === 'excel') {
            export::exportToExcel($tablaHtml); 
        } elseif ($formato === 'pdf') {
            export::exportToPdf($tablaHtml); 
        } else {
            echo "Formato no soportado";
        }
    }
}
?>
