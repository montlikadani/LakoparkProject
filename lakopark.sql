-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Jan 23. 10:23
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lakopark`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hazak`
--

CREATE TABLE `hazak` (
  `id` int(11) NOT NULL,
  `lakopark` varchar(300) NOT NULL,
  `utca` int(11) NOT NULL,
  `hazszam` int(11) NOT NULL,
  `emelet` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `hazak`
--

INSERT INTO `hazak` (`id`, `lakopark`, `utca`, `hazszam`, `emelet`) VALUES
(1, 'Puskás Ferenc', 1, 1, 2),
(2, 'Puskás Ferenc', 1, 2, 1),
(3, 'Puskás Ferenc', 1, 3, 1),
(4, 'Puskás Ferenc', 1, 6, 3),
(5, 'Puskás Ferenc', 1, 7, 1),
(6, 'Puskás Ferenc', 2, 2, 1),
(7, 'Puskás Ferenc', 2, 3, 2),
(8, 'Puskás Ferenc', 2, 6, 2),
(9, 'Puskás Ferenc', 2, 8, 2),
(10, 'Puskás Ferenc', 3, 2, 1),
(11, 'Puskás Ferenc', 3, 3, 3),
(12, 'Puskás Ferenc', 3, 4, 1),
(13, 'Puskás Ferenc', 3, 5, 3),
(14, 'Puskás Ferenc', 3, 6, 2),
(15, 'Puskás Ferenc', 3, 7, 1),
(16, 'Puskás Ferenc', 3, 8, 1),
(17, 'Puskás Ferenc', 4, 3, 2),
(18, 'Puskás Ferenc', 4, 5, 3),
(19, 'Puskás Ferenc', 4, 6, 2),
(20, 'Puskás Ferenc', 4, 8, 3),
(21, 'Puskás Ferenc', 4, 9, 3),
(22, 'Puskás Ferenc', 5, 1, 1),
(23, 'Puskás Ferenc', 5, 4, 1),
(24, 'Puskás Ferenc', 1, 7, 1),
(25, 'Puskás Ferenc', 5, 8, 3),
(26, 'Van Gogh', 1, 1, 1),
(27, 'Van Gogh', 1, 3, 3),
(28, 'Van Gogh', 1, 5, 2),
(29, 'Van Gogh', 2, 1, 3),
(30, 'Van Gogh', 2, 3, 3),
(31, 'Van Gogh', 2, 4, 3),
(32, 'Van Gogh', 2, 5, 2),
(33, 'Van Gogh', 3, 1, 1),
(34, 'Van Gogh', 3, 2, 3),
(35, 'Van Gogh', 3, 5, 2),
(36, 'Vivaldi', 1, 2, 3),
(37, 'Vivaldi', 1, 3, 1),
(38, 'Vivaldi', 1, 7, 3),
(39, 'Vivaldi', 2, 1, 2),
(40, 'Vivaldi', 2, 2, 2),
(41, 'Vivaldi', 2, 7, 2),
(42, 'Vivaldi', 3, 2, 1),
(43, 'Vivaldi', 3, 5, 1),
(44, 'Vivaldi', 3, 7, 3),
(45, 'Vivaldi', 4, 1, 2),
(46, 'Vivaldi', 4, 2, 3),
(47, 'Vivaldi', 4, 3, 2),
(48, 'Vivaldi', 4, 5, 3),
(49, 'Vivaldi', 4, 6, 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `lakopark`
--

CREATE TABLE `lakopark` (
  `id` int(11) NOT NULL,
  `nev` varchar(300) NOT NULL,
  `utcakSzama` int(11) NOT NULL,
  `hazakSzama` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `lakopark`
--

INSERT INTO `lakopark` (`id`, `nev`, `utcakSzama`, `hazakSzama`) VALUES
(1, 'Puskás Ferenc', 5, 10),
(2, 'Van Gogh', 3, 5),
(3, 'Vivaldi', 4, 7);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `statistics`
--

CREATE TABLE `statistics` (
  `id` int(11) NOT NULL,
  `lakopark` varchar(300) NOT NULL,
  `datum` date NOT NULL,
  `beepitett` tinyint(1) NOT NULL,
  `beepitettseg` double NOT NULL DEFAULT 0,
  `bevetel` double NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `hazak`
--
ALTER TABLE `hazak`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `lakopark`
--
ALTER TABLE `lakopark`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `statistics`
--
ALTER TABLE `statistics`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `hazak`
--
ALTER TABLE `hazak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT a táblához `lakopark`
--
ALTER TABLE `lakopark`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `statistics`
--
ALTER TABLE `statistics`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
