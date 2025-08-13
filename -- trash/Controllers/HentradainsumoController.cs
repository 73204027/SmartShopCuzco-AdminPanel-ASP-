<?php
require_once '../models/hentradaproducto_model.php';
require_once '../config/export.php';
class hentradaproducto_controller {
    private $modelo;
    public function __construct() {
        $this->modelo = new HEntradaProducto();
    }
    public function listar() {
        $limit = 10;
        $page = isset($_GET['page'])? max(1,(int)$_GET['page']) : 1;
        $offset = ($page-1)*$limit;
        $total = $this->modelo->contarActivos();
        $items = $this->modelo->listarPaginado($offset, $limit);
        $totalPages = ceil($total/$limit);
        require_once '../views/hentradaproducto/listar_hentradaproducto.php';
    }
    public function listarTodo() {
        $limit = 10;
        $page = isset($_GET['page'])? max(1,(int)$_GET['page']) : 1;
        $offset = ($page-1)*$limit;
        $total = $this->modelo->contarTotal();
        $items = $this->modelo->listarTodoPaginado($offset, $limit);
        $totalPages = ceil($total/$limit);
        require_once '../views/hentradaproducto/habilitar_hentradaproducto.php';
    }
    public function cargarRegistrar() {
        require_once '../views/hentradaproducto/registrar_hentradaproducto.php';
    }
    public function cargarActualizar() {
        if(isset($_GET['id'])) {
            $item = $this->modelo->buscarPorId($_GET['id']);
            require_once '../views/hentradaproducto/actualizar_hentradaproducto.php';
        } else {
            header('Location: index.php?controller=hentradaproducto&action=listar'); exit;
        }
    }
    public function registrar() {
        if($_SERVER['REQUEST_METHOD']==='POST') {
            $this->modelo->registrar($_POST['NOMBRE'], $_POST['DESCRIPCION'], $_POST['PRECIO'], $_POST['CANTIDAD']);
        }
        header('Location: index.php?controller=hentradaproducto&action=listar'); exit;
    }
    public function actualizar() {
        if($_SERVER['REQUEST_METHOD']==='POST') {
            $this->modelo->actualizar($_POST['ID'], $_POST['NOMBRE'], $_POST['DESCRIPCION'], $_POST['PRECIO'], $_POST['CANTIDAD']);
        }
        header('Location: index.php?controller=hentradaproducto&action=listar'); exit;
    }
    public function deshabilitar() {
        if(isset($_GET['id'])) $this->modelo->deshabilitar($_GET['id']);
        header('Location: index.php?controller=hentradaproducto&action=listar'); exit;
    }
    public function habilitar() {
        if(isset($_GET['id'])) $this->modelo->habilitar($_GET['id']);
        header('Location: index.php?controller=hentradaproducto&action=listarTodo'); exit;
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
