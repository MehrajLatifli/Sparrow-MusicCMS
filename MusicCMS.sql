CREATE DATABASE [MusicCMS]


USE [MusicCMS]


CREATE TABLE [Music]
(
IdMusic INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
MusicName NVARCHAR(max) NOT NULL,
isPopularMusic bit NOT NULL,
ImageMusic NVARCHAR(max) NOT NULL,
MusicFile NVARCHAR(max) NOT NULL,
)


CREATE TABLE [UserAccount]
(
IdUserAccount INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Username NVARCHAR(max) NOT NULL,
UserEmail NVARCHAR(max) NOT NULL,
UserPassword NVARCHAR(max) NOT NULL,
)


CREATE TABLE [Notification]
(
IdNotification INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Messageactivity TEXT NOT NULL,
NotificationDatetime NVARCHAR(max) NOT NULL,

FromUserAccountId_forNotification int NOT NULL,
ToUserAccountId_forNotification int NOT NULL,

Constraint FK_FromUserAccountId Foreign key (FromUserAccountId_forNotification) References UserAccount (IdUserAccount) On Delete CASCADE On Update CASCADE,
Constraint FK_ToUserAccountId Foreign key (ToUserAccountId_forNotification) References UserAccount (IdUserAccount) On Delete NO ACTION On Update NO ACTION
)


CREATE TABLE [Playlist]
(
IdPlaylist INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
PlaylistName NVARCHAR(max) NOT NULL,
PlaylistDescription NVARCHAR(max) NOT NULL,
PlaylistDatetime NVARCHAR(max) NOT NULL,
ImagePlaylist NVARCHAR(max) NOT NULL,

UserAccountId_forPlaylist int NOT NULL,


Constraint FK_UserAccountId Foreign key (UserAccountId_forPlaylist) References UserAccount (IdUserAccount) On Delete NO ACTION On Update NO ACTION
)


CREATE TABLE [Artist]
(
IdArtist INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
ArtistName NVARCHAR(max) NOT NULL,
ImageArtist NVARCHAR(max) NOT NULL,
)


CREATE TABLE [Album]
(
IdAlbum INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
AlbumName NVARCHAR(max) NOT NULL,
ImageAlbum NVARCHAR(max) NOT NULL,
)


CREATE TABLE [Radio]
(
IdRadio INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
RadioName NVARCHAR(max) NOT NULL,
ImageRadio NVARCHAR(max) NOT NULL,
RadioFile NVARCHAR(max) NOT NULL,
RadioDescription NVARCHAR(max) NOT NULL,
RadioCountry NVARCHAR(max) NOT NULL,
)


CREATE TABLE [PlaylistMusic]
(
IdPlaylistMusic INT PRIMARY KEY IDENTITY (1,1) NOT NULL,

PlaylistId_forPlaylistMusic int NOT NULL,
MusicId_forPlaylistMusic int NOT NULL,

Constraint FK_PlaylistId_forPlaylistMusic Foreign key (PlaylistId_forPlaylistMusic) References Playlist (IdPlaylist) On Delete CASCADE On Update CASCADE,
Constraint FK_MusicId_forPlaylistMusic Foreign key (MusicId_forPlaylistMusic) References Music (IdMusic) On Delete CASCADE On Update CASCADE
)


CREATE TABLE [ArtistAlbum]
(
IdArtistAlbum INT PRIMARY KEY IDENTITY (1,1) NOT NULL,

ArtistId_forArtistAlbum int NOT NULL,
AlbumId_forArtistAlbum int NOT NULL,

Constraint FK_ArtistId_forArtistAlbum Foreign key (ArtistId_forArtistAlbum) References Artist (IdArtist) On Delete CASCADE On Update CASCADE,
Constraint FK_AlbumId_forArtistAlbum Foreign key (AlbumId_forArtistAlbum) References Album (IdAlbum) On Delete CASCADE On Update CASCADE
)


CREATE TABLE [MusicAlbum]
(
IdMusicAlbum INT PRIMARY KEY IDENTITY (1,1) NOT NULL,

MusicId_forMusicAlbum int NOT NULL,
AlbumId_forMusicAlbum int NOT NULL,

Constraint FK_MusicId_forMusicAlbum Foreign key (MusicId_forMusicAlbum) References Music (IdMusic) On Delete NO ACTION On Update NO ACTION,
Constraint FK_AlbumId_forMusicAlbum Foreign key (AlbumId_forMusicAlbum) References Album (IdAlbum) On Delete NO ACTION On Update NO ACTION
)







--Get All

Select * FROM MusicCMSCustomUserDB.dbo.AspNetUsers

SELECT *FROM Music

SELECT *FROM Radio

SELECT *FROM UserAccount

SELECT *FROM Playlist

SELECT *FROM PlaylistMusic

SELECT *FROM Artist

SELECT *FROM Album

SELECT *FROM ArtistAlbum

SELECT *FROM MusicAlbum

SELECT 
m.MusicName,
p.PlaylistName
FROM PlaylistMusic
Inner join Playlist as p
ON p.IdPlaylist=PlaylistMusic.PlaylistId_forPlaylistMusic
Inner join Music as m
ON m.IdMusic=PlaylistMusic.MusicId_forPlaylistMusic
where PlaylistMusic.PlaylistId_forPlaylistMusic=1


SELECT 
a1.ArtistName,
a2.AlbumName
FROM ArtistAlbum
Inner join Artist as a1
ON a1.IdArtist=ArtistAlbum.ArtistId_forArtistAlbum
Inner join Album as a2
ON a2.IdAlbum=ArtistAlbum.AlbumId_forArtistAlbum
where ArtistAlbum.ArtistId_forArtistAlbum=1


--DELETE FROM ArtistAlbum WHERE ArtistAlbum.AlbumId_forArtistAlbum=4;


SELECT 
Music.MusicName,
Album.AlbumName
FROM MusicAlbum 
Inner join Music 
ON Music.IdMusic=MusicAlbum.MusicId_forMusicAlbum
Inner join Album 
ON Album.IdAlbum=MusicAlbum.AlbumId_forMusicAlbum




Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Akif İslamzadə - Neyləyim Ala gözlüm',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1665424817/MusicCMS/Music/Akif_%C4%B0slamzad%C9%99_-_Neyl%C9%99yim_Ala_g%C3%B6zl%C3%BCm_thitau.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Barış Akarsu - Vurdum En Dibe Kadar',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1665453284/MusicCMS/Music/Bar%C4%B1%C5%9F_Akarsu_-_Vurdum_En_Dibe_Kadar_mzt6vz.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'{NCS Release} Ahrix - Nova',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1666711456/MusicCMS/Music/NCS_Release_Ahrix_-_Nova_jvkuoc.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Şövkət Ələkbərova - Gedək üzü küləyə',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1666828806/MusicCMS/Music/%C5%9E%C3%B6vk%C9%99t_%C6%8Fl%C9%99kb%C9%99rova_-_Ged%C9%99k_%C3%BCz%C3%BC_k%C3%BCl%C9%99y%C9%99_adzyzk.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Azər Zeynalov - Bahar çiçəyim',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1665424817/MusicCMS/Music/Akif_%C4%B0slamzad%C9%99_-_Neyl%C9%99yim_Ala_g%C3%B6zl%C3%BCm_thitau.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Barış Manço - Ahmet beyin çeketi',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1673627396/MusicCMS/Music/Bar%C4%B1%C5%9F_Man%C3%A7o_-_Ahmet_beyin_%C3%A7eketi_y4azkl.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Esmeray - Bir Gün Gelecek',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1673627911/MusicCMS/Music/Esmeray_-_Bir_G%C3%BCn_Gelecek_voyein.mp3');

Insert into [MusicCMS].dbo.[Music](MusicName,isPopularMusic,ImageMusic,MusicFile)
values
(N'Mirzə Babayev - Pəncərəmə qondu çiçək',1,N'../../../Asserts/Images/Images/music_fsq5k7.png',N'https://res.cloudinary.com/sociala/video/upload/v1673628182/MusicCMS/Music/Mirz%C9%99_Babayev_-_P%C9%99nc%C9%99r%C9%99m%C9%99_qondu_%C3%A7i%C3%A7%C9%99k_z1qbhs.mp3');





Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'radio.de',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'http://metafiles.gl-systemhaus.de/hr/hr3_2.m3u',N'This radio streaming from Germany',N'Germany');

Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'Xezer',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'http://s40.myradiostream.com:22546/listen.mp3?nocache=1667073460',N'Xəzər FM radiosu 10 may 2008-ci ildə 103 mHz tezliyində yayıma başlayıb. ',N'Azerbaijan');

Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'CBC Radio One',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'https://cbcradiolive.akamaized.net/hls/live/2041036/ES_R1ETR/master.m3u8',N'CBC Radio One - CBLA-FM is a broadcast radio station in Toronto, Ontario, Canada, providing Public Broadcasting News, Information and Entertainment as the flagship radio station of the Canadian Broadcasting Corporation.',N'Canada');

Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'Qazaq radiosy',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'https://radio-streams.kaztrk.kz/qazradio/qazradio/icecast.audio',N'Qazaq radiosy',N'Kazakhstan');

Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'NPR ',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'https://npr-ice.streamguys1.com/live.mp3',N'National Public Radio',N'USA');

Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'Gugak FM',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'https://mgugaklive.nowcdn.co.kr/gugakradio/gugakradio.stream/chunklist_w632544988.m3u8',N'Gugak FM is a South Korean radio broadcasting station specializing in Korean traditional music (gugak) and culture. Its coverage extends through Seoul, Gyeonggi-do, and Jeollado, and Gyeongsang, and Gangwon Province.',N'South Korean');

Insert into [MusicCMS].dbo.Radio(RadioName,ImageRadio,RadioFile,RadioDescription,RadioCountry)
values
(N'MusicCMS Radio',N'../../../Asserts/Images/Images/radio_wqoalt.png',N'http://shaincast.caster.fm:19364/listen.mp3?authne9acb24f234c90223f7253811237aed2',N'MusicCMS Radio',N'Azerbaijan');





--Insert into [MusicCMS].dbo.Artist(ArtistName,ImageArtist)
--values
--(N'No Artist',N'https://res.cloudinary.com/sociala/image/upload/v1675949427/MusicCMS/User/artist_rd9jux.png')

--Insert into [MusicCMS].dbo.Artist(ArtistName,ImageArtist)
--values
--(N'Artist 1',N'https://res.cloudinary.com/sociala/image/upload/v1675949427/MusicCMS/User/artist_rd9jux.png')



--Insert into [MusicCMS].dbo.Album(AlbumName,ImageAlbum)
--values
--(N'No Album',N'https://res.cloudinary.com/sociala/image/upload/v1674240025/MusicCMS/User/album_wbzwwp.png')

--Insert into [MusicCMS].dbo.Album(AlbumName,ImageAlbum)
--values
--(N'Album 1',N'https://res.cloudinary.com/sociala/image/upload/v1674240025/MusicCMS/User/album_wbzwwp.png')





--Insert into [MusicCMS].dbo.MusicAlbum(MusicId_forMusicAlbum,AlbumId_forMusicAlbum)
--values
--(1, 1)

--Insert into [MusicCMS].dbo.ArtistAlbum(AlbumId_forArtistAlbum,ArtistId_forArtistAlbum)
--values
--(1, 1)

--Insert into [MusicCMS].dbo.ArtistAlbum(AlbumId_forArtistAlbum,ArtistId_forArtistAlbum)
--values
--(2, 2)

--Insert into [MusicCMS].dbo.MusicAlbum(MusicId_forMusicAlbum,AlbumId_forMusicAlbum)
--values
--(2, 2)

--Insert into [MusicCMS].dbo.MusicAlbum(MusicId_forMusicAlbum,AlbumId_forMusicAlbum)
--values
--(4, 1)

--Insert into [MusicCMS].dbo.ArtistAlbum(AlbumId_forArtistAlbum,ArtistId_forArtistAlbum)
--values
--(1, 2)



------------------------------------------------------------------------

CREATE or Alter PROCEDURE PlaylistMusicStoredProcedure @pl int
AS
SELECT 
m.MusicName,
p.PlaylistName
FROM PlaylistMusic
Inner join Playlist as p
ON p.IdPlaylist=PlaylistMusic.PlaylistId_forPlaylistMusic
Inner join Music as m
ON m.IdMusic=PlaylistMusic.MusicId_forPlaylistMusic
where p.IdPlaylist=@pl
GO



EXEC PlaylistMusicStoredProcedure @pl = 1; 


--Insert into [MusicCMS].dbo.[UserAccount](Username,UserEmail, UserPassport, UsserImage, UserBehaviorStatus,UserRole)
--values
--(N'User_1234',N'User_1234@MusicCMS.com',N'User_1234',N'https://res.cloudinary.com/sociala/image/upload/v1665425666/MusicCMS/User/defaultUserimage_kenwvp.png',N'unblocked',N'user');


--Insert into [MusicCMS].dbo.[Playlist](PlaylistName,PlaylistDescription, PlaylistDatetime, ImagePlaylist, UserAccountId_forPlaylist)
--values
--(N'AnyPlaylist',N'AnyPlaylist Description',N'2022-07-26 15:48:49',N'https://res.cloudinary.com/sociala/image/upload/v1673464721/MusicCMS/User/playlist_v0uatj.png',1);

--Insert into [MusicCMS].dbo.[Playlist](PlaylistName,PlaylistDescription, PlaylistDatetime, ImagePlaylist, UserAccountId_forPlaylist)
--values
--(N'AnyPlaylist2',N'AnyPlaylist Description',N'2022-07-26 15:48:49',N'https://res.cloudinary.com/sociala/image/upload/v1666303691/MusicCMS/Music/AnyPlaylist_lpuj37.jpg',1);