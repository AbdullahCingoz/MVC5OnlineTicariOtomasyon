USE [DB_Eticaret_Proje]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admins](
	[Admin_ID] [int] IDENTITY(1,1) NOT NULL,
	[Admin_KullaniciAd] [varchar](40) NOT NULL,
	[Admin_Sifre] [varchar](8000) NULL,
	[Admin_Yetki] [char](1) NULL,
 CONSTRAINT [PK_dbo.Admins] PRIMARY KEY CLUSTERED 
(
	[Admin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Caris]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Caris](
	[Cari_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cari_Ad] [varchar](40) NOT NULL,
	[Cari_Soyad] [varchar](40) NULL,
	[Cari_Sehir] [varchar](15) NULL,
	[Cari_Mail] [varchar](8000) NULL,
	[Cari_Durum] [bit] NOT NULL DEFAULT ((0)),
	[Cari_Sifre] [varchar](20) NULL,
 CONSTRAINT [PK_dbo.Caris] PRIMARY KEY CLUSTERED 
(
	[Cari_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departmen]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departmen](
	[Departman_ID] [int] IDENTITY(1,1) NOT NULL,
	[Departman_Ad] [varchar](8000) NOT NULL,
	[Durum] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Departmen] PRIMARY KEY CLUSTERED 
(
	[Departman_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Detays]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detays](
	[Detay_ID] [int] IDENTITY(1,1) NOT NULL,
	[Urun_Ad] [varchar](30) NULL,
	[UrunBilgisi] [varchar](2000) NULL,
 CONSTRAINT [PK_dbo.Detays] PRIMARY KEY CLUSTERED 
(
	[Detay_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FaturaKalems]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FaturaKalems](
	[FaturaKalem_ID] [int] IDENTITY(1,1) NOT NULL,
	[FaturaKalem_Aciklama] [varchar](8000) NOT NULL,
	[FaturaKalem_Miktar] [int] NOT NULL,
	[FaturaKalem_BirimFiyat] [decimal](18, 2) NOT NULL,
	[FaturaKalem_Tutar] [decimal](18, 2) NOT NULL,
	[Fatura_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.FaturaKalems] PRIMARY KEY CLUSTERED 
(
	[FaturaKalem_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faturas]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faturas](
	[Fatura_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fatura_SıraNo] [varchar](9) NULL,
	[Fatura_SeriNo] [char](1) NULL,
	[Fatura_Tarih] [datetime] NOT NULL,
	[Fatura_Saat] [char](5) NULL,
	[Fatura_VergiDairesi] [varchar](50) NULL,
	[Fatura_TeslimAlan] [varchar](50) NULL,
	[Fatura_TeslimEden] [varchar](50) NULL,
	[Toplam] [decimal](18, 2) NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Faturas] PRIMARY KEY CLUSTERED 
(
	[Fatura_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Giders]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Giders](
	[Gider_ID] [int] IDENTITY(1,1) NOT NULL,
	[Gider_Aciklama] [varchar](100) NOT NULL,
	[Gider_Tarih] [datetime] NOT NULL,
	[Gider_Tutar] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Giders] PRIMARY KEY CLUSTERED 
(
	[Gider_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KargoDetays]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KargoDetays](
	[KargoID] [int] IDENTITY(1,1) NOT NULL,
	[Aciklama] [varchar](300) NULL,
	[TakipKodu] [varchar](10) NULL,
	[Personel] [varchar](20) NULL,
	[Alici] [varchar](20) NULL,
	[Tarih] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.KargoDetays] PRIMARY KEY CLUSTERED 
(
	[KargoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KargoTakips]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KargoTakips](
	[KargoTakipID] [int] IDENTITY(1,1) NOT NULL,
	[KargoTakipKodu] [varchar](10) NULL,
	[Aciklama] [varchar](100) NULL,
	[TarihZaman] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.KargoTakips] PRIMARY KEY CLUSTERED 
(
	[KargoTakipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kategoris]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kategoris](
	[Kategori_ID] [int] IDENTITY(1,1) NOT NULL,
	[Kategori_Ad] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.Kategoris] PRIMARY KEY CLUSTERED 
(
	[Kategori_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mesajlars]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mesajlars](
	[Mesaj_ID] [int] IDENTITY(1,1) NOT NULL,
	[Gonderici] [varchar](50) NULL,
	[Alici] [varchar](50) NULL,
	[Konu] [varchar](50) NULL,
	[Icerik] [varchar](2000) NULL,
	[Tarih] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_dbo.Mesajlars] PRIMARY KEY CLUSTERED 
(
	[Mesaj_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personels]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personels](
	[Personel_ID] [int] IDENTITY(1,1) NOT NULL,
	[Personel_Ad] [varchar](40) NOT NULL,
	[Personel_Soyad] [varchar](40) NULL,
	[Personel_Gorsel] [nvarchar](max) NULL,
	[Departman_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Personels] PRIMARY KEY CLUSTERED 
(
	[Personel_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SatisHarekets]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisHarekets](
	[SatisHareket_ID] [int] IDENTITY(1,1) NOT NULL,
	[SatisHareket_Tarih] [datetime] NOT NULL,
	[SatisHareket_Adet] [int] NOT NULL,
	[SatisHareket_Fiyat] [decimal](18, 2) NOT NULL,
	[SatisHareket_ToplamTutar] [decimal](18, 2) NOT NULL,
	[Cari_ID] [int] NOT NULL,
	[Personel_ID] [int] NOT NULL,
	[Urun_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SatisHarekets] PRIMARY KEY CLUSTERED 
(
	[SatisHareket_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uruns]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Uruns](
	[Urun_ID] [int] IDENTITY(1,1) NOT NULL,
	[Urun_Ad] [varchar](40) NOT NULL,
	[Urun_Marka] [varchar](40) NULL,
	[Urun_Stok] [smallint] NOT NULL,
	[Urun_AlisFiyati] [decimal](18, 2) NOT NULL,
	[Urun_SatisFiyati] [decimal](18, 2) NOT NULL,
	[Urun_Durum] [bit] NOT NULL,
	[Urun_Gorsel] [varchar](8000) NULL,
	[Kategori_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Uruns] PRIMARY KEY CLUSTERED 
(
	[Urun_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Yapilacaks]    Script Date: 19.11.2022 21:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Yapilacaks](
	[Yapilacak_ID] [int] IDENTITY(1,1) NOT NULL,
	[Baslik] [varchar](100) NULL,
	[Durum] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Yapilacaks] PRIMARY KEY CLUSTERED 
(
	[Yapilacak_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[FaturaKalems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FaturaKalems_dbo.Faturas_Fatura_ID] FOREIGN KEY([Fatura_ID])
REFERENCES [dbo].[Faturas] ([Fatura_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaturaKalems] CHECK CONSTRAINT [FK_dbo.FaturaKalems_dbo.Faturas_Fatura_ID]
GO
ALTER TABLE [dbo].[Personels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Personels_dbo.Departmen_Departman_ID] FOREIGN KEY([Departman_ID])
REFERENCES [dbo].[Departmen] ([Departman_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personels] CHECK CONSTRAINT [FK_dbo.Personels_dbo.Departmen_Departman_ID]
GO
ALTER TABLE [dbo].[SatisHarekets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SatisHarekets_dbo.Caris_Cari_ID] FOREIGN KEY([Cari_ID])
REFERENCES [dbo].[Caris] ([Cari_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SatisHarekets] CHECK CONSTRAINT [FK_dbo.SatisHarekets_dbo.Caris_Cari_ID]
GO
ALTER TABLE [dbo].[SatisHarekets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SatisHarekets_dbo.Personels_Personel_ID] FOREIGN KEY([Personel_ID])
REFERENCES [dbo].[Personels] ([Personel_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SatisHarekets] CHECK CONSTRAINT [FK_dbo.SatisHarekets_dbo.Personels_Personel_ID]
GO
ALTER TABLE [dbo].[SatisHarekets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SatisHarekets_dbo.Uruns_Urun_ID] FOREIGN KEY([Urun_ID])
REFERENCES [dbo].[Uruns] ([Urun_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SatisHarekets] CHECK CONSTRAINT [FK_dbo.SatisHarekets_dbo.Uruns_Urun_ID]
GO
ALTER TABLE [dbo].[Uruns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Uruns_dbo.Kategoris_Kategori_ID] FOREIGN KEY([Kategori_ID])
REFERENCES [dbo].[Kategoris] ([Kategori_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Uruns] CHECK CONSTRAINT [FK_dbo.Uruns_dbo.Kategoris_Kategori_ID]
GO
