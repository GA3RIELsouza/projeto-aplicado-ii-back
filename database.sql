-- 22/05/2025
-- Criação do banco de dados

DROP SCHEMA IF EXISTS projeto_aplicado_ii;
CREATE SCHEMA IF NOT EXISTS projeto_aplicado_ii;
USE projeto_aplicado_ii;

DROP USER IF EXISTS projeto_aplicado_ii;
CREATE USER IF NOT EXISTS projeto_aplicado_ii IDENTIFIED BY 'sesisenai';
GRANT ALL PRIVILEGES ON projeto_aplicado_ii.* TO projeto_aplicado_ii;
FLUSH PRIVILEGES;

DROP TABLE IF EXISTS user;

CREATE TABLE IF NOT EXISTS user (
	id INT UNSIGNED AUTO_INCREMENT,
    name VARCHAR(64) NOT NULL,
    email VARCHAR(254) NOT NULL UNIQUE,
    password_hash BINARY(32) NOT NULL,
    password_salt_hash BINARY(16) NOT NULL,
    is_admin BOOLEAN NOT NULL DEFAULT FALSE,
    inserted_at DATETIME NOT NULL,
    updated_at DATETIME NULL,
    PRIMARY KEY (id)
);
