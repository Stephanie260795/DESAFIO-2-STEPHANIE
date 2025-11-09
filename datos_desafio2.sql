-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-11-2025 a las 21:39:12
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `datos_desafio2`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumno`
--

CREATE TABLE `alumno` (
  `AlumnoID` int(6) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Apellido` varchar(20) NOT NULL,
  `Fecha_nacimiento` varchar(10) NOT NULL,
  `Grado` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `alumno`
--

INSERT INTO `alumno` (`AlumnoID`, `Nombre`, `Apellido`, `Fecha_nacimiento`, `Grado`) VALUES
(2, 'CARLOS', 'VILLALTA', '2003-11-22', 'QUINDER'),
(3, 'EMERSON', 'CRUZ', '2001-02-02', 'PRIMERO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `expediente`
--

CREATE TABLE `expediente` (
  `ExpedienteID` int(6) NOT NULL,
  `AlumnoID` int(6) NOT NULL,
  `MateriaID` int(6) NOT NULL,
  `Notal_Final` decimal(3,0) NOT NULL,
  `Observaciones` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `expediente`
--

INSERT INTO `expediente` (`ExpedienteID`, `AlumnoID`, `MateriaID`, `Notal_Final`, `Observaciones`) VALUES
(1, 2, 4, 6, 'raspado'),
(2, 3, 2, 10, 'la excelencia hace al profecional');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `materia`
--

CREATE TABLE `materia` (
  `MateriaID` int(6) NOT NULL,
  `Nombre_Materia` varchar(30) NOT NULL,
  `Docente` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `materia`
--

INSERT INTO `materia` (`MateriaID`, `Nombre_Materia`, `Docente`) VALUES
(2, 'FISICA', 'TARIO'),
(3, 'PROBABILITY', 'TOBBY'),
(4, 'ARTISTICA', 'MIRNA');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `alumno`
--
ALTER TABLE `alumno`
  ADD PRIMARY KEY (`AlumnoID`);

--
-- Indices de la tabla `expediente`
--
ALTER TABLE `expediente`
  ADD PRIMARY KEY (`ExpedienteID`),
  ADD KEY `AlumnoID` (`AlumnoID`,`MateriaID`),
  ADD KEY `MateriaID` (`MateriaID`);

--
-- Indices de la tabla `materia`
--
ALTER TABLE `materia`
  ADD PRIMARY KEY (`MateriaID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `alumno`
--
ALTER TABLE `alumno`
  MODIFY `AlumnoID` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `expediente`
--
ALTER TABLE `expediente`
  MODIFY `ExpedienteID` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `materia`
--
ALTER TABLE `materia`
  MODIFY `MateriaID` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `expediente`
--
ALTER TABLE `expediente`
  ADD CONSTRAINT `expediente_ibfk_1` FOREIGN KEY (`AlumnoID`) REFERENCES `alumno` (`AlumnoID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `expediente_ibfk_2` FOREIGN KEY (`MateriaID`) REFERENCES `materia` (`MateriaID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
