CREATE TABLE `posts` (
  `idposts` INT NOT NULL AUTO_INCREMENT,
  `txtPost` VARCHAR(255) NOT NULL,
  `titulo` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idposts`)
);

CREATE TABLE `comment` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `txt_comment` VARCHAR(255) NOT NULL,
  `post_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`post_id`) REFERENCES `posts`(`idposts`) ON DELETE CASCADE
);
