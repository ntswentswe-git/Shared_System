-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 11, 2016 at 02:59 PM
-- Server version: 5.6.20
-- PHP Version: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `nyangara`
--

-- --------------------------------------------------------

--
-- Table structure for table `cash_in`
--

CREATE TABLE IF NOT EXISTS `cash_in` (
  `id` bigint(20) DEFAULT NULL,
  `transaction_date` varchar(200) NOT NULL,
  `date_recorded` varchar(200) NOT NULL,
  `transaction_information` varchar(200) NOT NULL,
  `amount` varchar(200) NOT NULL,
  `recorded_by` varchar(200) NOT NULL,
  `transaction_type` varchar(200) NOT NULL,
  `payment_form` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cash_in`
--

INSERT INTO `cash_in` (`id`, `transaction_date`, `date_recorded`, `transaction_information`, `amount`, `recorded_by`, `transaction_type`, `payment_form`) VALUES
(NULL, '07/05/2016', 'DATE', 'loan from world bank', '200', 'Tinashe Mahlabvani', 'OTHER', 'CASH'),
(NULL, '07/05/2016', 'DATE', 'Loan from world bank', '300', 'Tinashe Mahlabvani', 'OTHER', 'CASH'),
(NULL, '07/05/2016', 'DATE', 't.Moyo', '2000', 'Tinashe Mahlabvani', 'OTHER', 'CASH');

-- --------------------------------------------------------

--
-- Table structure for table `cash_out`
--

CREATE TABLE IF NOT EXISTS `cash_out` (
`id` bigint(20) NOT NULL,
  `transaction_date` varchar(200) NOT NULL,
  `date_recorded` varchar(200) NOT NULL,
  `transaction_information` varchar(200) NOT NULL,
  `amount` varchar(200) NOT NULL,
  `recorded_by` varchar(200) NOT NULL,
  `transaction_type` varchar(200) NOT NULL,
  `payment_form` varchar(200) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `cash_out`
--

INSERT INTO `cash_out` (`id`, `transaction_date`, `date_recorded`, `transaction_information`, `amount`, `recorded_by`, `transaction_type`, `payment_form`) VALUES
(1, '07/05/2016', 'DATE', 'Purchase of office equip', '20', 'Tinashe Mahlabvani', 'PETTY CASH', 'CASH'),
(2, '09/09/2016', 'DATE', 'tyyyyy', '10', 'Tinashe Mahlabvani', 'EXPENSES', 'CASH');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE IF NOT EXISTS `employees` (
`id` int(11) NOT NULL,
  `fullname` varchar(200) NOT NULL,
  `sex` varchar(300) NOT NULL,
  `address` varchar(200) NOT NULL,
  `position` varchar(200) NOT NULL,
  `email` varchar(200) NOT NULL,
  `contact` varchar(200) NOT NULL,
  `start_date` varchar(200) NOT NULL,
  `salary_entitled` varchar(200) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `fullname`, `sex`, `address`, `position`, `email`, `contact`, `start_date`, `salary_entitled`) VALUES
(1, 'rdrdrd', 'MALE', 'tryer gtgthh\r\ngftftf', 'Administration', 'ntswe@gmail.com', '(+263) 667-667777', '08/09/2016', '09/09/2016'),
(2, 'rtyu', 'MALE', 'qwerty\r\nkeyboard', 'Administration', 'ntswe@gmail.com', '(+263) 778-778778', '08/09/2016', '09/09/2015');

-- --------------------------------------------------------

--
-- Table structure for table `purchases`
--

CREATE TABLE IF NOT EXISTS `purchases` (
`id` bigint(20) NOT NULL,
  `date_purchased` varchar(200) NOT NULL,
  `product_name` varchar(200) NOT NULL,
  `product_price` varchar(200) NOT NULL,
  `product_barcode` varchar(200) NOT NULL,
  `quantity` varchar(200) NOT NULL,
  `total_purchase_price` varchar(200) NOT NULL,
  `supplier_name` varchar(200) NOT NULL,
  `supplier_code` varchar(200) NOT NULL,
  `supplier_description` varchar(200) NOT NULL,
  `discount_received` varchar(200) NOT NULL,
  `recorded_by` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE IF NOT EXISTS `sales` (
`id` bigint(20) NOT NULL,
  `date` varchar(200) NOT NULL,
  `product_name` varchar(200) NOT NULL,
  `selling_price` varchar(200) NOT NULL,
  `quantity` varchar(200) NOT NULL,
  `total_sale_amount` varchar(200) NOT NULL,
  `customer_name` varchar(200) NOT NULL,
  `product_barcode` varchar(200) NOT NULL,
  `recorded_by` varchar(200) NOT NULL,
  `type` varchar(200) NOT NULL,
  `discount_allowed` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
`id` int(11) NOT NULL,
  `full_name` text NOT NULL,
  `gender` text NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `user_role` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `contact` varchar(50) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `full_name`, `gender`, `username`, `password`, `user_role`, `email`, `contact`) VALUES
(1, 'Tinashe Mahlabvani', 'Male', 'Tinashe', 'ntswentswe', 'ADMIN', 'ntswentswe95@gmail.com', '0771702859'),
(2, 'Tanaka Mahlabvani', 'Female', 'tanaka', 'tanaka', 'OTHER', 'tanaka@gmail.com', '0779499636');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cash_out`
--
ALTER TABLE `cash_out`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchases`
--
ALTER TABLE `purchases`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cash_out`
--
ALTER TABLE `cash_out`
MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `purchases`
--
ALTER TABLE `purchases`
MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
