-- SQLite
-- DROP TABLE [Company];

CREATE TABLE [Company] (
    [Id] INTEGER PRIMARY KEY,
    [Name] NVARCHAR(50) NULL,
    [Icon] NTEXT NULL,
    [IconBackground] NVARCHAR(7) DEFAULT ('#FFF') NULL,
    [CIF] NVARCHAR(50) NULL,
    [Address] NTEXT NULL,
    [Web] NTEXT NULL,
    [Email] NTEXT NULL
)

CREATE TABLE [Product] (
    [Id] INTEGER PRIMARY KEY,
    [Type] TINYINT NULL DEFAULT 0,
    [Summary] NTEXT NULL,
    [Icon] NTEXT NULL,
    [Banner] NTEXT NULL,
    [Trailer] NTEXT NULL,
    [Price] FLOAT NULL DEFAULT 0,
    [Publishing] DATETIME2 NULL DEFAULT GETDATE(),
    [Size] FLOAT NULL DEFAULT 0,
    [Developer] INTEGER NULL,
    [Editor] INTEGER NULL
)