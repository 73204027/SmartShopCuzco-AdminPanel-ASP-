<!doctype html>
<html lang="es">
<head>
  <meta charset="utf-8">
  <title>Actualizar Insumo</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="container mt-4">
<?php include __DIR__ . '/../main_view.php'; ?>
  <div class="mt-2"></div>
  <h1>Actualizar Insumo</h1>
  <form method="post" action="index.php?controller=insumo&action=actualizar">
    <input type="hidden" name="ID" value="<?= $item['ID'] ?>">
    <div class="mb-3"><label>Nombre:</label><input type="text" class="form-control" name="NOMBRE" value="<?= $item['NOMBRE'] ?>" required></div>
    <div class="mb-3"><label>Descripción:</label><input type="text" class="form-control" name="DESCRIPCION" value="<?= $item['DESCRIPCION'] ?>" required></div>
    <div class="mb-3"><label>Precio:</label><input type="number" step="0.01" class="form-control" name="PRECIO" value="<?= $item['PRECIO'] ?>" required></div>
    <div class="mb-3"><label>Cantidad:</label><input type="number" class="form-control" name="CANTIDAD" value="<?= $item['CANTIDAD'] ?>" required></div>
    <button class="btn btn-success">Actualizar</button>
    <a href="index.php?controller=insumo&action=listar" class="btn btn-secondary">Volver</a>
  </form>
  <script src="../public/static/loadBg_views.js"></script>
</body>
</html>
