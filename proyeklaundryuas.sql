-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 06 Jan 2023 pada 16.00
-- Versi server: 10.4.22-MariaDB
-- Versi PHP: 8.0.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `proyeklaundryuas`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `member`
--

CREATE TABLE `member` (
  `id` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `alamat` text NOT NULL,
  `jenis_kelamin` varchar(10) NOT NULL,
  `nomor_telepon` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `member`
--

INSERT INTO `member` (`id`, `nama`, `alamat`, `jenis_kelamin`, `nomor_telepon`) VALUES
(2, 'Wawan Andriyan', 'Rawakuda', 'Laki-Laki', '088888888888'),
(3, 'Agung Nur Fauzi', 'Sukamantri', 'Laki-Laki', '08555555'),
(4, 'Agun Gunawan', 'Rengas Dengklok', 'Laki-Laki', '082222222222'),
(5, 'Sultan Aditia', 'Pebayuran', 'Laki-Laki', '085695320323');

-- --------------------------------------------------------

--
-- Struktur dari tabel `paket`
--

CREATE TABLE `paket` (
  `id` int(11) NOT NULL,
  `jenis` varchar(50) NOT NULL,
  `nama_paket` varchar(100) NOT NULL,
  `harga` int(11) NOT NULL,
  `persen_diskon` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `paket`
--

INSERT INTO `paket` (`id`, `jenis`, `nama_paket`, `harga`, `persen_diskon`) VALUES
(14, 'Kiloan', 'Cuci + Lipat', 6000, 0),
(15, 'Kiloan', 'Cuci + Lipat + Setrika', 7000, 0),
(16, 'Kiloan', 'Setrika', 5000, 0),
(17, 'Satuan', 'Bed Cover Kecil', 10000, 0),
(18, 'Satuan', 'Bed Cover Besar/Selimut Tebal', 12000, 0),
(19, 'Satuan', 'Boneka Besar', 20000, 0),
(20, 'Satuan', 'Boneka Ekstra Besar', 30000, 0),
(21, 'Satuan', 'Sweater/jaket tipis', 5000, 0),
(22, 'Satuan', 'Jaket Tebal', 8000, 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE `transaksi` (
  `id` int(11) NOT NULL,
  `kode_invoice` varchar(100) NOT NULL,
  `id_member` int(11) NOT NULL,
  `tanggal` datetime NOT NULL,
  `deadline` datetime NOT NULL,
  `tanggal_bayar` date NOT NULL,
  `biaya_tambahan` double NOT NULL,
  `diskon` double NOT NULL,
  `status` varchar(20) NOT NULL,
  `dibayar` varchar(20) NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`id`, `kode_invoice`, `id_member`, `tanggal`, `deadline`, `tanggal_bayar`, `biaya_tambahan`, `diskon`, `status`, `dibayar`, `id_user`) VALUES
(2, '10/12/20222', 3, '2022-12-10 15:33:55', '2022-12-11 15:33:55', '2022-12-11', 0, 0, 'Diambil', 'Dibayar', 6),
(3, '10/12/20223', 5, '2022-12-10 15:36:33', '2022-12-12 15:36:33', '2022-12-10', 0, 0, 'Diambil', 'Dibayar', 6),
(4, '11/12/20224', 4, '2022-12-11 14:17:26', '2022-12-13 14:17:26', '2022-12-11', 4000, 0, 'Diambil', 'Dibayar', 6),
(5, '11/12/20225', 2, '2022-12-11 22:51:47', '2022-12-12 22:51:47', '2022-12-16', 5000, 0, 'Diambil', 'Dibayar', 6),
(6, '16/12/20226', 2, '2022-12-16 16:48:21', '2022-12-17 16:48:21', '2022-12-16', 5000, 0, 'Diambil', 'Dibayar', 6),
(7, '16/12/20227', 5, '2022-12-16 16:49:01', '2022-12-17 16:49:01', '2022-12-16', 0, 0, 'Selesai', 'Belum Bayar', 6),
(8, '20/12/20228', 4, '2022-12-20 09:27:57', '2022-12-21 09:27:57', '2022-12-20', 5000, 0, 'Diambil', 'Dibayar', 6);

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi_detail`
--

CREATE TABLE `transaksi_detail` (
  `id` int(11) NOT NULL,
  `id_transaksi` int(11) NOT NULL,
  `id_paket` int(11) NOT NULL,
  `qty` double NOT NULL,
  `harga` double NOT NULL,
  `diskon` double NOT NULL,
  `keterangan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `transaksi_detail`
--

INSERT INTO `transaksi_detail` (`id`, `id_transaksi`, `id_paket`, `qty`, `harga`, `diskon`, `keterangan`) VALUES
(35, 2, 18, 1, 12000, 0, ''),
(36, 2, 16, 1, 5000, 0, ''),
(37, 3, 19, 1, 20000, 0, ''),
(38, 3, 18, 2, 12000, 0, ''),
(39, 4, 21, 2, 5000, 0, ''),
(40, 4, 22, 1, 8000, 0, ''),
(41, 4, 19, 1, 20000, 0, ''),
(42, 4, 15, 1, 7000, 0, ''),
(43, 5, 14, 1, 6000, 0, ''),
(44, 5, 21, 2, 5000, 0, ''),
(45, 5, 22, 3, 8000, 0, ''),
(46, 5, 16, 1, 5000, 0, ''),
(47, 6, 21, 2, 5000, 0, ''),
(48, 6, 22, 2, 8000, 0, ''),
(49, 6, 16, 1, 5000, 0, ''),
(50, 7, 15, 1, 7000, 0, ''),
(51, 8, 14, 2, 6000, 0, '');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` text NOT NULL,
  `role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id`, `nama`, `username`, `password`, `role`) VALUES
(6, 'Aditya Lucis Caelum', 'adit22', 'sss', 'Admin'),
(8, 'Sultan Aditia', 'aAdit', 'ass', 'Kasir'),
(9, 'Agun', 'agunss', 'sa12', 'Kasir'),
(10, 'Agung', 'aAgung', 's123', 'Owner');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `member`
--
ALTER TABLE `member`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `paket`
--
ALTER TABLE `paket`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_member` (`id_member`) USING BTREE,
  ADD KEY `id_user` (`id_user`) USING BTREE;

--
-- Indeks untuk tabel `transaksi_detail`
--
ALTER TABLE `transaksi_detail`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_paket` (`id_paket`),
  ADD KEY `id_transaksi` (`id_transaksi`,`id_paket`) USING BTREE;

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `member`
--
ALTER TABLE `member`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT untuk tabel `paket`
--
ALTER TABLE `paket`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT untuk tabel `transaksi_detail`
--
ALTER TABLE `transaksi_detail`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD CONSTRAINT `transaksi_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `transaksi_ibfk_2` FOREIGN KEY (`id_member`) REFERENCES `member` (`id`);

--
-- Ketidakleluasaan untuk tabel `transaksi_detail`
--
ALTER TABLE `transaksi_detail`
  ADD CONSTRAINT `transaksi_detail_ibfk_1` FOREIGN KEY (`id_transaksi`) REFERENCES `transaksi` (`id`),
  ADD CONSTRAINT `transaksi_detail_ibfk_2` FOREIGN KEY (`id_paket`) REFERENCES `paket` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
