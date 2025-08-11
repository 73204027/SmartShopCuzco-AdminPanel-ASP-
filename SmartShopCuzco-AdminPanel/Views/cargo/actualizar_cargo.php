<!doctype html>
<html lang="es">
<head>
  <meta charset="utf-8">
  <title>Actualizar Cargo</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="container mt-4">
<?php include __DIR__ . '/../main_view.php'; ?>
  <div class="mt-2"></div>
  <h1>Actualizar Cargo</h1>
  <form method="post" action="index.php?controller=cargo&action=actualizar">
    <input type="hidden" name="ID" value="<?= $item['ID'] ?>">
    <div class="mb-3"><label>Nombre:</label><input type="text" class="form-control" name="NOMBRE" value="<?= $item['NOMBRE'] ?>" required></div>
    <button class="btn btn-success">Actualizar</button>
    <a href="index.php?controller=cargo&action=listar" class="btn btn-secondary">Volver</a>
  </form>
  <script src="../public/static/loadBg_views.js"></script>
</body>
</html>
