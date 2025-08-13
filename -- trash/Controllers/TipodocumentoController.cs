<?php
require_once '../models/tipo_documento_model.php';
require_once '../config/export.php';
class tipodocumento_controller {
    private $modelo;
    public function __construct() {
        $this->modelo = new TipoDocumento();
    }
    public function listar() {
        $limit = 10;
        $page = isset($_GET['page'])? max(1,(int)$_GET['page']) : 1;
        $offset = ($page-1)*$limit;
        $total = $this->modelo->contarActivos();
        $items = $this->modelo->listarPaginado($offset, $limit);
        $totalPages = ceil($total/$limit);
        require_once '../views/tipo_documento/listar_tipo_documento.php';
    }
    public function listarTodo() {
        $limit = 10;
        $page = isset($_GET['page'])? max(1,(int)$_GET['page']) : 1;
        $offset = ($page-1)*$limit;
        $total = $this->modelo->contarTotal();
        $items = $this->modelo->listarTodoPaginado($offset, $limit);
        $totalPages = ceil($total/$limit);
        require_once '../views/tipo_documento/habilitar_tipo_documento.php';
    }
    public function cargarRegistrar() {
        require_once '../views/tipo_documento/registrar_tipo_documento.php';
    }
    public function cargarActualizar() {
        if(isset($_GET['id'])) {
            $item = $this->modelo->buscarPorId($_GET['id']);
            require_once '../views/tipo_documento/actualizar_tipo_documento.php';
        } else {
            header('Location: index.php?controller=tipodocumento&action=listar'); exit;
        }
    }
    public function registrar() {
        if($_SERVER['REQUEST_METHOD']==='POST' && isset($_POST['NOMBRE'])) {
            $this->modelo->registrar($_POST['NOMBRE']);
        }
        header('Location: index.php?controller=tipodocumento&action=listar'); exit;
    }
    public function actualizar() {
        if($_SERVER['REQUEST_METHOD']==='POST' && isset($_POST['ID'],$_POST['NOMBRE'])) {
            $this->modelo->actualizar($_POST['ID'],$_POST['NOMBRE']);
        }
        header('Location: index.php?controller=tipodocumento&action=listar'); exit;
    }
    public function deshabilitar() {
        if(isset($_GET['id'])) $this->modelo->deshabilitar($_GET['id']);
        header('Location: index.php?controller=tipodocumento&action=listar'); exit;
    }
    public function habilitar() {
        if(isset($_GET['id'])) $this->modelo->habilitar($_GET['id']);
        header('Location: index.php?controller=tipodocumento&action=listarTodo'); exit;
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
