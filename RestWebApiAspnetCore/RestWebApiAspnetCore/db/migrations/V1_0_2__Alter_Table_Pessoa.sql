CREATE TABLE `rest_with_aspnet_udemy`.`usuario` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Login` VARCHAR(45) NOT NULL,
  `Senha` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE);