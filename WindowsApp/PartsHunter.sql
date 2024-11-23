PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20241123113103_MyStock','8.0.10');
INSERT INTO __EFMigrationsHistory VALUES('20241123181824_UpdateSchema','8.0.10');
CREATE TABLE IF NOT EXISTS "Components" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Components" PRIMARY KEY AUTOINCREMENT,
    "Description" TEXT NULL,
    "Category" TEXT NULL,
    "SlotID" INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS "HardwareDevice" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_HardwareDevice" PRIMARY KEY AUTOINCREMENT,
    "IP" TEXT NULL,
    "blinky_ms" INTEGER NOT NULL,
    "brightness" INTEGER NOT NULL,
    "red" INTEGER NOT NULL,
    "green" INTEGER NOT NULL,
    "blue" INTEGER NOT NULL
);
COMMIT;
