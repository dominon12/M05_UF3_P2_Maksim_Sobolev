-- SQLite
-- DROP TABLE [Company];

-- CREATE TABLE [Company] (
--     [Id] INTEGER PRIMARY KEY,
--     [Name] NVARCHAR(50) NULL,
--     [Icon] NTEXT NULL,
--     [IconBackground] NVARCHAR(7) DEFAULT ('#FFF') NULL,
--     [CIF] NVARCHAR(50) NULL,
--     [Address] NTEXT NULL,
--     [Web] NTEXT NULL,
--     [Email] NTEXT NULL
-- )

-- DROP TABLE Product;

-- CREATE TABLE [Product] (
--     [Id] INTEGER PRIMARY KEY,
--     [Type] TINYINT NULL DEFAULT 0,
--     [Summary] NTEXT NULL,
--     [Icon] NTEXT NULL,
--     [Banner] NTEXT NULL,
--     [Trailer] NTEXT NULL,
--     [Price] FLOAT NULL DEFAULT 0,
--     [Publishing] DATETIME2 NULL DEFAULT CURRENT_TIMESTAMP,
--     [Size] FLOAT NULL DEFAULT 0,
--     [Developer] INTEGER NULL,
--     [Editor] INTEGER NULL
-- );

-- DROP TABLE Game;

-- CREATE TABLE [Game] (
--     [Id] INTEGER PRIMARY KEY,
--     [Product_Id] INTEGER NULL,
--     [Rating] FLOAT NULL,
--     [Version] NVARCHAR(50) NULL
-- )
-- ;
-- INSERT INTO Game VALUES (2, 3, NULL, NULL);

-- SELECT * FROM Game WHERE Product_Id = 2;

