<!doctype html>
<html lang="es">
<head>
  <meta charset="utf-8">
  <title>Habilitar Distritos</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="container mt-4">
<?php include __DIR__ . '/../main_view.php'; ?>
  <div class="mt-2"></div>
  <h1>Habilitar / Deshabilitar Distritos</h1>
  <a href="index.php?controller=distrito&action=listar" class="btn btn-secondary">Volver</a>
  <div class="mb-3"></div>
  <table class="table table-striped table-hover table-bordered">
    <thead class="table-dark">
      <tr><th>ID</th><th>Nombre</th><th>Estado</th><th>Habilitar</th><th>Deshabilitar</th></tr>
    </thead>
    <tbody>
      <?php while($row = $items->fetch_assoc()): ?>
      <tr>
        <td><?= $row['ID'] ?></td>
        <td><?= $row['NOMBRE'] ?></td>
        <td><?= $row['ESTADO']==1?'Activo':'Inactivo' ?></td>
        <td><a href="index.php?controller=distrito&action=habilitar&id=<?= $row['ID'] ?>" class="btn btn-warning btn-sm" onclick="return confirm('¿Seguro que quieres habilitar?');">Habilitar</a></td>
        <td><a href="index.php?controller=distrito&action=deshabilitar&id=<?= $row['ID'] ?>" class="btn btn-danger btn-sm" onclick="return confirm('¿Seguro que quieres deshabilitar?');">Deshabilitar</a></td>
      </tr>
      <?php endwhile; ?>
    </tbody>
  </table>
  <nav><ul class="pagination">
    <?php for($i=1;$i<=$totalPages;$i++): ?>
    <li class="page-item <?= $i==$page?'active':'' ?>"><a class="page-link" href="index.php?controller=distrito&action=listarTodo&page=<?= $i ?>"><?= $i ?></a></li>
    <?php endfor; ?>
  </ul></nav>
  <script src="../public/static/loadBg_views.js"></script>
</body>
</html>
