CREATE TABLE IF NOT EXISTS `pessoa` (
	`id` INT(11) NOT NULL,
	`nome` VARCHAR(50) NOT NULL DEFAULT '',
	`sobrenome` VARCHAR(50) NOT NULL DEFAULT '',
	`endereco` VARCHAR(100) NOT NULL DEFAULT '',
	`genero` VARCHAR(50) NOT NULL DEFAULT '',
	`atualizacao` datetime
)
COLLATE='utf8mb4_0900_ai_ci'
ENGINE=InnoDB
;