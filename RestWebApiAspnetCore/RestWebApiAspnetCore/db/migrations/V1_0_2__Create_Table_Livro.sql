CREATE TABLE IF NOT EXISTS `Livro` (
  `idLivro` INT NOT NULL AUTO_INCREMENT,
  `Autor` VARCHAR(100) NOT NULL,
  `DataLancamento` DATETIME NOT NULL,
  `Titulo` VARCHAR(45) NOT NULL,
  `Preco` DECIMAL(65,2) NOT NULL,
  PRIMARY KEY (`idLivro`))
ENGINE = InnoDB DEFAULT Charset = Latin1