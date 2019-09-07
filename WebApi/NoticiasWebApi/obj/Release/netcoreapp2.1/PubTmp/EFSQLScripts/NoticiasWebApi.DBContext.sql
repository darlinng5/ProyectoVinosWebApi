IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814000229_CrearDB')
BEGIN
    CREATE TABLE [Autor] (
        [AutorID] int NOT NULL IDENTITY,
        [Nombre] nvarchar(50) NULL,
        [Apellido] nvarchar(50) NULL,
        CONSTRAINT [PK_Autor] PRIMARY KEY ([AutorID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814000229_CrearDB')
BEGIN
    CREATE TABLE [Finca] (
        [idFinca] int NOT NULL IDENTITY,
        [nombre] nvarchar(20) NULL,
        [descripcion] nvarchar(150) NULL,
        [departamento] nvarchar(25) NULL,
        [municipio] nvarchar(25) NULL,
        [estado] nvarchar(15) NULL,
        CONSTRAINT [PK_Finca] PRIMARY KEY ([idFinca])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814000229_CrearDB')
BEGIN
    CREATE TABLE [Nombres] (
        [NombreID] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Nombres] PRIMARY KEY ([NombreID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814000229_CrearDB')
BEGIN
    CREATE TABLE [Productos] (
        [idProducto] int NOT NULL IDENTITY,
        [nombre] nvarchar(max) NULL,
        [descripcion] nvarchar(max) NULL,
        [tipoSemilla] nvarchar(max) NULL,
        [estado] nvarchar(max) NULL,
        CONSTRAINT [PK_Productos] PRIMARY KEY ([idProducto])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814000229_CrearDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190814000229_CrearDB', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814002436_AgregandoTablaProcesoFinca')
BEGIN
    CREATE TABLE [FincaProceso] (
        [idProceso] int NOT NULL IDENTITY,
        [nombre] nvarchar(20) NULL,
        [fechaInicio] Datetime NOT NULL,
        [estado] nvarchar(25) NULL,
        CONSTRAINT [PK_FincaProceso] PRIMARY KEY ([idProceso])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814002436_AgregandoTablaProcesoFinca')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190814002436_AgregandoTablaProcesoFinca', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814003704_RelacionandoTablaFincaConProcesoFinca')
BEGIN
    ALTER TABLE [FincaProceso] ADD [idFinca] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814003704_RelacionandoTablaFincaConProcesoFinca')
BEGIN
    CREATE INDEX [IX_FincaProceso_idFinca] ON [FincaProceso] ([idFinca]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814003704_RelacionandoTablaFincaConProcesoFinca')
BEGIN
    ALTER TABLE [FincaProceso] ADD CONSTRAINT [FK_FincaProceso_Finca_idFinca] FOREIGN KEY ([idFinca]) REFERENCES [Finca] ([idFinca]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814003704_RelacionandoTablaFincaConProcesoFinca')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190814003704_RelacionandoTablaFincaConProcesoFinca', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814011751_AgregadaTablaLLamadaAFinca')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190814011751_AgregadaTablaLLamadaAFinca', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814012428_AgregadoTablaLLamadasaFincaFinal')
BEGIN
    CREATE TABLE [LlamadasAFinca] (
        [idLLamada] int NOT NULL IDENTITY,
        [fechaLLamada] Datetime NOT NULL,
        [Observacion] nvarchar(20) NULL,
        [fechaVisita] Datetime NOT NULL,
        [idProceso] int NOT NULL,
        CONSTRAINT [PK_LlamadasAFinca] PRIMARY KEY ([idLLamada]),
        CONSTRAINT [FK_LlamadasAFinca_FincaProceso_idProceso] FOREIGN KEY ([idProceso]) REFERENCES [FincaProceso] ([idProceso]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814012428_AgregadoTablaLLamadasaFincaFinal')
BEGIN
    CREATE INDEX [IX_LlamadasAFinca_idProceso] ON [LlamadasAFinca] ([idProceso]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190814012428_AgregadoTablaLLamadasaFincaFinal')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190814012428_AgregadoTablaLLamadasaFincaFinal', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190815031853_AgregadaTablaFincaEvaluacion')
BEGIN
    CREATE TABLE [FincaEvaluacion] (
        [idEvaluacion] int NOT NULL IDENTITY,
        [fechaEvaluacion] Datetime NOT NULL,
        [valoracionTerreno] nvarchar(20) NULL,
        [fechaInspeccion] Datetime NOT NULL,
        [idProceso] int NOT NULL,
        CONSTRAINT [PK_FincaEvaluacion] PRIMARY KEY ([idEvaluacion]),
        CONSTRAINT [FK_FincaEvaluacion_FincaProceso_idProceso] FOREIGN KEY ([idProceso]) REFERENCES [FincaProceso] ([idProceso]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190815031853_AgregadaTablaFincaEvaluacion')
BEGIN
    CREATE INDEX [IX_FincaEvaluacion_idProceso] ON [FincaEvaluacion] ([idProceso]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190815031853_AgregadaTablaFincaEvaluacion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190815031853_AgregadaTablaFincaEvaluacion', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    DROP TABLE [Autor];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    DROP TABLE [Nombres];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    EXEC sp_rename N'[FincaEvaluacion].[fechaEvaluacion]', N'fechaVisita', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LlamadasAFinca]') AND [c].[name] = N'Observacion');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [LlamadasAFinca] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [LlamadasAFinca] ALTER COLUMN [Observacion] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    ALTER TABLE [FincaEvaluacion] ADD [Observacion] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    CREATE TABLE [FincaInspeccion] (
        [idInspeccion] int NOT NULL IDENTITY,
        [Observacion] nvarchar(max) NULL,
        [fechaVisita] Datetime NOT NULL,
        [fechaCompra] Datetime NOT NULL,
        [estado] nvarchar(20) NULL,
        [idProceso] int NOT NULL,
        CONSTRAINT [PK_FincaInspeccion] PRIMARY KEY ([idInspeccion]),
        CONSTRAINT [FK_FincaInspeccion_FincaProceso_idProceso] FOREIGN KEY ([idProceso]) REFERENCES [FincaProceso] ([idProceso]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    CREATE INDEX [IX_FincaInspeccion_idProceso] ON [FincaInspeccion] ([idProceso]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820051656_Agregada Tabla FincaInspeccion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190820051656_Agregada Tabla FincaInspeccion', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Productos]') AND [c].[name] = N'tipoSemilla');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Productos] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Productos] DROP COLUMN [tipoSemilla];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Productos]') AND [c].[name] = N'nombre');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Productos] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Productos] ALTER COLUMN [nombre] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Productos]') AND [c].[name] = N'estado');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Productos] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Productos] ALTER COLUMN [estado] nvarchar(15) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Productos]') AND [c].[name] = N'descripcion');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Productos] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Productos] ALTER COLUMN [descripcion] nvarchar(150) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    ALTER TABLE [Productos] ADD [idProceso] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    ALTER TABLE [FincaProceso] ADD [idProducto] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    CREATE TABLE [Semilla] (
        [idSemilla] int NOT NULL IDENTITY,
        [nombre] nvarchar(40) NULL,
        [descripcion] nvarchar(150) NULL,
        [estado] nvarchar(15) NULL,
        CONSTRAINT [PK_Semilla] PRIMARY KEY ([idSemilla])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    CREATE INDEX [IX_Productos_idProceso] ON [Productos] ([idProceso]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    CREATE INDEX [IX_FincaProceso_idProducto] ON [FincaProceso] ([idProducto]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    ALTER TABLE [FincaProceso] ADD CONSTRAINT [FK_FincaProceso_Productos_idProducto] FOREIGN KEY ([idProducto]) REFERENCES [Productos] ([idProducto]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    ALTER TABLE [Productos] ADD CONSTRAINT [FK_Productos_Semilla_idProceso] FOREIGN KEY ([idProceso]) REFERENCES [Semilla] ([idSemilla]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820061713_AddDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190820061713_AddDB', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820160829_Actualizada tabla FincaEvaluacion')
BEGIN
    ALTER TABLE [FincaEvaluacion] ADD [estado] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820160829_Actualizada tabla FincaEvaluacion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190820160829_Actualizada tabla FincaEvaluacion', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820173212_correcion de error en tabla producto')
BEGIN
    ALTER TABLE [Productos] DROP CONSTRAINT [FK_Productos_Semilla_idProceso];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820173212_correcion de error en tabla producto')
BEGIN
    EXEC sp_rename N'[Productos].[idProceso]', N'idSemilla', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820173212_correcion de error en tabla producto')
BEGIN
    EXEC sp_rename N'[Productos].[IX_Productos_idProceso]', N'IX_Productos_idSemilla', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820173212_correcion de error en tabla producto')
BEGIN
    ALTER TABLE [Productos] ADD CONSTRAINT [FK_Productos_Semilla_idSemilla] FOREIGN KEY ([idSemilla]) REFERENCES [Semilla] ([idSemilla]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190820173212_correcion de error en tabla producto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190820173212_correcion de error en tabla producto', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190821033314_NuevaBasedeDatos')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190821033314_NuevaBasedeDatos', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190825035815_Actualizando Datos')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190825035815_Actualizando Datos', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190828020105_AddTableFincaCompra')
BEGIN
    CREATE TABLE [ProductoPresentacion] (
        [idProductoPresentacion] int NOT NULL IDENTITY,
        [nombre] nvarchar(50) NULL,
        CONSTRAINT [PK_ProductoPresentacion] PRIMARY KEY ([idProductoPresentacion])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190828020105_AddTableFincaCompra')
BEGIN
    CREATE TABLE [FincaCompra] (
        [id] int NOT NULL IDENTITY,
        [valorUnitario] decimal NOT NULL,
        [cantidad] decimal NOT NULL,
        [esPagoAlContado] int NOT NULL,
        [Observacion] nvarchar(150) NULL,
        [idProceso] int NOT NULL,
        [idProductoPresentacion] int NOT NULL,
        CONSTRAINT [PK_FincaCompra] PRIMARY KEY ([id]),
        CONSTRAINT [FK_FincaCompra_FincaProceso_idProceso] FOREIGN KEY ([idProceso]) REFERENCES [FincaProceso] ([idProceso]) ON DELETE CASCADE,
        CONSTRAINT [FK_FincaCompra_ProductoPresentacion_idProductoPresentacion] FOREIGN KEY ([idProductoPresentacion]) REFERENCES [ProductoPresentacion] ([idProductoPresentacion]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190828020105_AddTableFincaCompra')
BEGIN
    CREATE INDEX [IX_FincaCompra_idProceso] ON [FincaCompra] ([idProceso]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190828020105_AddTableFincaCompra')
BEGIN
    CREATE INDEX [IX_FincaCompra_idProductoPresentacion] ON [FincaCompra] ([idProductoPresentacion]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190828020105_AddTableFincaCompra')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190828020105_AddTableFincaCompra', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190828234229_CreacionBaseDatosEdwin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190828234229_CreacionBaseDatosEdwin', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190901050803_anadiendoCompras')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190901050803_anadiendoCompras', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    ALTER TABLE [LlamadasAFinca] DROP CONSTRAINT [FK_LlamadasAFinca_FincaProceso_idProceso];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    ALTER TABLE [LlamadasAFinca] DROP CONSTRAINT [PK_LlamadasAFinca];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    EXEC sp_rename N'[LlamadasAFinca]', N'LLamadasAFinca';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    EXEC sp_rename N'[LLamadasAFinca].[IX_LlamadasAFinca_idProceso]', N'IX_LLamadasAFinca_idProceso', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    ALTER TABLE [LLamadasAFinca] ADD CONSTRAINT [PK_LLamadasAFinca] PRIMARY KEY ([idLLamada]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    ALTER TABLE [LLamadasAFinca] ADD CONSTRAINT [FK_LLamadasAFinca_FincaProceso_idProceso] FOREIGN KEY ([idProceso]) REFERENCES [FincaProceso] ([idProceso]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190905021632_ActuEdwin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190905021632_ActuEdwin', N'2.1.11-servicing-32099');
END;

GO

