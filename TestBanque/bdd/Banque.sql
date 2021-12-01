SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";
use Banque;

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `Banque`
--

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `sqlDynTable`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sqlDynTable` (IN `asTable` VARCHAR(50))  begin
declare cmd varchar(255);
set @leSql = concat("select * from ",asTable);
prepare cmd from @leSql;
execute cmd;
deallocate prepare cmd;
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `Client`
--

DROP TABLE IF EXISTS Client;
CREATE TABLE IF NOT EXISTS Client (
  `id` int(6) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `adresse` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `Client`
--

INSERT INTO Banque.Client (`id`, `nom`, `prenom`) VALUES
(1, 'AMARA', 'Sacha'),
(2, 'TEST', 'Sacha'),
(3, 'DFDS', 'Sacha'),
(4, 'ADFDSF', 'Sacha'),
(5, 'AMADSF', 'Sacha'),
(6, 'AMFSFA', 'Sacha'),
(7, 'AMFSF', 'Sacha'),
(8, 'AMAFSFD', 'Sacha'),
(9, 'AMQSD', 'Sacha'),
(10,'AMAZEG', 'Sacha');

-- --------------------------------------------------------

--
-- Structure de la table `Compte`
--

DROP TABLE IF EXISTS Compte;
CREATE TABLE IF NOT EXISTS Compte (
  `id` int(4) NOT NULL,
  `id_client` integer NOT NULL,
  `decouvert` float DEFAULT NULL,
  `solde` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`id_client`) REFERENCES Client (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `Compte`
--

INSERT INTO Banque.Compte (`id`, `id_client`, `decouvert`, `solde`) VALUES
(1, 10, 100, 342523.43),
(2, 9, 100, 342523.43),
(3, 8, 100, 342523.43),
(4, 7, 100, 342523.43),
(5, 6, 100, 342523.43),
(6, 5, 100, 342523.43),
(7, 4, 100, 342523.43),
(8, 3, 100, 342523.43),
(9, 2, 100, 342523.43),
(10, 1, 100, 342523.43);
