<!doctype html>
<html lang="es">
<head>
  <meta charset="utf-8">
  <title>Listar Tipos Documento</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="container mt-4">
<?php include __DIR__ . '/../main_view.php'; ?>
  <div class="mt-2"></div>
  <h1>Lista de Tipos Documento</h1>
  <a href="index.php?controller=tipodocumento&action=cargarRegistrar" class="btn btn-primary">Registrar</a>
  <a href="index.php?controller=tipodocumento&action=listarTodo" class="btn btn-warning">Habilitar/Deshabilitar</a>
<a href="" class="btn btn-primary" id="aExportar">Exportar</a>
  <label>a: </label>
  <select class="select" id="selectExportar">
    <option value="pdf" selected>pdf</option>
    <option value="excel">excel</option>
  </select>
  <div class="mb-3"></div>
  <table class="table table-striped table-hover table-bordered" id="tabla">
    <thead class="table-dark">
      <tr><th>ID</th><th>Nombre</th><th>Estado</th><th>Editar</th><th>Eliminar</th></tr>
    </thead>
    <tbody>
      <?php while($row = $items->fetch_assoc()): ?>
      <tr>
        <td><?= $row['ID'] ?></td>
        <td><?= $row['NOMBRE'] ?></td>
        <td><?= $row['ESTADO']==1?'Activo':'Inactivo' ?></td>
        <td><a href="index.php?controller=tipodocumento&action=cargarActualizar&id=<?= $row['ID'] ?>" class="btn btn-success btn-sm">Editar</a></td>
        <td><a href="index.php?controller=tipodocumento&action=deshabilitar&id=<?= $row['ID'] ?>" class="btn btn-danger btn-sm" onclick="return confirm('¿Seguro?');">Eliminar</a></td>
      </tr>
      <?php endwhile; ?>
    </tbody>
  </table>
  <nav><ul class="pagination">
    <?php for($i=1;$i<=$totalPages;$i++): ?>
    <li class="page-item <?= $i==$page?'active':'' ?>"><a class="page-link" href="index.php?controller=tipodocumento&action=listar&page=<?= $i ?>"><?= $i ?></a></li>
    <?php endfor; ?>
  </ul></nav>
  <script src="../public/static/loadBg_views.js"></script>
<script>
    window.totalPages = <?= $totalPages ?>;
  </script>
  <script src="../public/static/AddEventListeners.js"></script>
</body>
</html>