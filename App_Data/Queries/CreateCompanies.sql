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