BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "Artists" (
	"Id"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL,
	"Country"	TEXT NOT NULL,
	CONSTRAINT "PK_Artists" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Albums" (
	"Id"	INTEGER NOT NULL,
	"Title"	TEXT NOT NULL,
	"Year"	INTEGER NOT NULL,
	CONSTRAINT "PK_Albums" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "AlbumArtist" (
	"AlbumsId"	INTEGER NOT NULL,
	"ArtistsId"	INTEGER NOT NULL,
	CONSTRAINT "PK_AlbumArtist" PRIMARY KEY("AlbumsId","ArtistsId"),
	CONSTRAINT "FK_AlbumArtist_Albums_AlbumsId" FOREIGN KEY("AlbumsId") REFERENCES "Albums"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_AlbumArtist_Artists_ArtistsId" FOREIGN KEY("ArtistsId") REFERENCES "Artists"("Id") ON DELETE CASCADE
);
INSERT INTO "__EFMigrationsHistory" VALUES ('20230920100557_InitialCreate','7.0.11');
INSERT INTO "__EFMigrationsHistory" VALUES ('20230922082724_UpdateCreate','7.0.11');
INSERT INTO "__EFMigrationsHistory" VALUES ('20230922135922_UpdatedTables','7.0.11');
INSERT INTO "__EFMigrationsHistory" VALUES ('20230925120439_NewArtistTable','7.0.11');
INSERT INTO "__EFMigrationsHistory" VALUES ('20230927084413_UpdatedAlbumTable','7.0.11');
INSERT INTO "Artists" VALUES (3,'The Japanese House','UK');
INSERT INTO "Artists" VALUES (23,'Post Malone','USA');
INSERT INTO "Artists" VALUES (26,'Lana del Rey','USA');
INSERT INTO "Artists" VALUES (28,'Charli XCX','UK');
INSERT INTO "Artists" VALUES (30,'Lorde','New Zeeland');
INSERT INTO "Artists" VALUES (32,'Jay-Z','USA');
INSERT INTO "Artists" VALUES (33,'Kanye West','USA');
INSERT INTO "Artists" VALUES (36,'Cleo','Swe');
INSERT INTO "Albums" VALUES (1,'Melodrama',2017);
INSERT INTO "Albums" VALUES (9,'Born To Die',2012);
INSERT INTO "Albums" VALUES (10,'Did you know there is an tunnel under Ocean Blvd',2023);
INSERT INTO "Albums" VALUES (13,'Watch the throne',2011);
INSERT INTO "Albums" VALUES (14,'Crash',2022);
INSERT INTO "Albums" VALUES (15,'Austin',2023);
INSERT INTO "Albums" VALUES (17,'In the end it always does',2023);
INSERT INTO "AlbumArtist" VALUES (1,30);
INSERT INTO "AlbumArtist" VALUES (9,26);
INSERT INTO "AlbumArtist" VALUES (10,26);
INSERT INTO "AlbumArtist" VALUES (13,32);
INSERT INTO "AlbumArtist" VALUES (13,33);
INSERT INTO "AlbumArtist" VALUES (14,28);
INSERT INTO "AlbumArtist" VALUES (15,23);
INSERT INTO "AlbumArtist" VALUES (17,3);
CREATE INDEX IF NOT EXISTS "IX_AlbumArtist_ArtistsId" ON "AlbumArtist" (
	"ArtistsId"
);
COMMIT;
