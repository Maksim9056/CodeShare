﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Language" (
    "Id_Programming_language" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Programming_language" text NOT NULL,
    CONSTRAINT "PK_Language" PRIMARY KEY ("Id_Programming_language")
);

CREATE TABLE "Rate" (
    "RateId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Name_Rate" text NOT NULL,
    CONSTRAINT "PK_Rate" PRIMARY KEY ("RateId")
);

CREATE TABLE "Roles" (
    "RolesId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "NameRole" text NOT NULL,
    CONSTRAINT "PK_Roles" PRIMARY KEY ("RolesId")
);

CREATE TABLE "Users" (
    "UsersId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "UsersName" text NOT NULL,
    "RoleId" bigint NOT NULL,
    "Phone" text NOT NULL,
    "Email" text NOT NULL,
    "Password" text NOT NULL,
    "CreateAt" text NOT NULL,
    "UpdatedAt" text NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("UsersId"),
    CONSTRAINT "FK_Users_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Roles" ("RolesId") ON DELETE RESTRICT
);

CREATE TABLE "Changes_in_the_system" (
    "Changes_in_the_systemId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Text_update" text NOT NULL,
    "Action_Type" text NOT NULL,
    "UserId" bigint NOT NULL,
    "CreateAt" text NOT NULL,
    CONSTRAINT "PK_Changes_in_the_system" PRIMARY KEY ("Changes_in_the_systemId"),
    CONSTRAINT "FK_Changes_in_the_system_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UsersId") ON DELETE CASCADE
);

CREATE TABLE "CodeSnippets" (
    "CodeSnippetsId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Title" text NOT NULL,
    "Code" text NOT NULL,
    "UserId" bigint NOT NULL,
    "Description" text NOT NULL,
    "IsAdmin" bigint NOT NULL,
    "CreateAt" text NOT NULL,
    "UpdateAt" text NOT NULL,
    "Programming_language" bigint NOT NULL,
    CONSTRAINT "PK_CodeSnippets" PRIMARY KEY ("CodeSnippetsId"),
    CONSTRAINT "FK_CodeSnippets_Language_Programming_language" FOREIGN KEY ("Programming_language") REFERENCES "Language" ("Id_Programming_language") ON DELETE RESTRICT,
    CONSTRAINT "FK_CodeSnippets_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UsersId") ON DELETE CASCADE
);

CREATE TABLE "Comment" (
    "CommentId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Name_Comment" text NOT NULL,
    "Selected_Range" text NOT NULL,
    "RatingId" bigint NOT NULL,
    "SnippetsId" bigint NOT NULL,
    "UserId" bigint NOT NULL,
    "CreateAt" text NOT NULL,
    "Comment_Text" text NOT NULL,
    "IsHidden" boolean NOT NULL,
    CONSTRAINT "PK_Comment" PRIMARY KEY ("CommentId"),
    CONSTRAINT "FK_Comment_CodeSnippets_SnippetsId" FOREIGN KEY ("SnippetsId") REFERENCES "CodeSnippets" ("CodeSnippetsId") ON DELETE CASCADE,
    CONSTRAINT "FK_Comment_Rate_RatingId" FOREIGN KEY ("RatingId") REFERENCES "Rate" ("RateId") ON DELETE RESTRICT,
    CONSTRAINT "FK_Comment_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UsersId") ON DELETE CASCADE
);

CREATE TABLE "History" (
    "HistoryId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Change_date" text NOT NULL,
    "SnippetId" bigint NOT NULL,
    "Year" text NOT NULL,
    CONSTRAINT "PK_History" PRIMARY KEY ("HistoryId"),
    CONSTRAINT "FK_History_CodeSnippets_SnippetId" FOREIGN KEY ("SnippetId") REFERENCES "CodeSnippets" ("CodeSnippetsId") ON DELETE CASCADE
);

CREATE TABLE "Setting" (
    "SettingId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Visibility_Setting" text NOT NULL,
    "Hide" text NOT NULL,
    "Prohibition" boolean NOT NULL,
    "Block" boolean NOT NULL,
    "SnippetId" bigint NOT NULL,
    CONSTRAINT "PK_Setting" PRIMARY KEY ("SettingId"),
    CONSTRAINT "FK_Setting_CodeSnippets_SnippetId" FOREIGN KEY ("SnippetId") REFERENCES "CodeSnippets" ("CodeSnippetsId") ON DELETE CASCADE
);

CREATE TABLE "Image" (
    "ImageId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "ImageDate" text NOT NULL,
    "LogotypeId" bigint,
    "UserId" bigint,
    "CreateAt" text NOT NULL,
    CONSTRAINT "PK_Image" PRIMARY KEY ("ImageId"),
    CONSTRAINT "FK_Image_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UsersId") ON DELETE CASCADE
);

CREATE TABLE "Logotype" (
    "LogotypeId" bigint GENERATED BY DEFAULT AS IDENTITY,
    "Name_Logotype" text NOT NULL,
    "ImageId" bigint NOT NULL,
    "Active" boolean NOT NULL,
    "Inactive" boolean NOT NULL,
    "Realtime" boolean NOT NULL,
    CONSTRAINT "PK_Logotype" PRIMARY KEY ("LogotypeId"),
    CONSTRAINT "FK_Logotype_Image_ImageId" FOREIGN KEY ("ImageId") REFERENCES "Image" ("ImageId") ON DELETE CASCADE
);

INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (1, 'C#');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (2, 'Python');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (3, 'Java');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (4, 'Go');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (5, 'PHP');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (6, 'JavaScript');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (7, 'C++');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (8, 'C');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (9, 'TypeScript');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (10, 'Swift');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (11, 'Kotlin');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (12, 'Rust');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (13, 'Ruby');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (14, 'Dart');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (15, 'Scala');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (16, 'Objective-C');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (17, 'Perl');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (18, 'Lua');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (19, 'Haskell');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (20, 'Elixir');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (21, 'F#');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (22, 'R');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (23, 'Julia');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (24, 'SQL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (25, 'Bash');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (26, 'Shell');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (27, 'PowerShell');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (28, 'MATLAB');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (29, 'COBOL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (30, 'Fortran');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (31, 'Ada');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (32, 'Lisp');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (33, 'Scheme');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (34, 'Prolog');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (35, 'Smalltalk');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (36, 'Erlang');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (37, 'APL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (38, 'Awk');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (39, 'Groovy');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (40, 'Tcl');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (41, 'Racket');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (42, 'ML');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (43, 'OCaml');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (44, 'Forth');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (45, 'Delphi');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (46, 'D');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (47, 'Crystal');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (48, 'FoxPro');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (49, 'REXX');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (50, 'Clipper');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (51, 'PL/SQL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (52, 'T-SQL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (53, 'ABAP');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (54, 'XQuery');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (55, 'VHDL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (56, 'Verilog');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (57, 'ActionScript');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (58, 'Modula-2');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (59, 'PostScript');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (60, 'Eiffel');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (61, 'J');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (62, 'IDL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (63, 'IDL (CORBA)');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (64, 'Logo');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (65, 'X10');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (66, 'Nim');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (67, 'Zig');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (68, 'Hack');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (69, 'J#');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (70, 'VBScript');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (71, 'QBasic');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (72, 'Fantom');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (73, 'RPG');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (74, 'Chapel');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (75, 'IDL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (76, 'Haxe');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (77, 'Transact-SQL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (78, 'Sed');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (79, 'Pike');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (80, 'IDL (IDL4)');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (81, 'OpenCL');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (82, 'IDL (Interactive Data Language)');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (83, 'IDL (Industrial Design Language)');
INSERT INTO "Language" ("Id_Programming_language", "Programming_language")
VALUES (84, 'IDL (Interface Definition Language)');

INSERT INTO "Rate" ("RateId", "Name_Rate")
VALUES (1, 'Плохо');
INSERT INTO "Rate" ("RateId", "Name_Rate")
VALUES (2, 'Средне');
INSERT INTO "Rate" ("RateId", "Name_Rate")
VALUES (3, 'Хорошо');
INSERT INTO "Rate" ("RateId", "Name_Rate")
VALUES (4, 'Отлично');

INSERT INTO "Roles" ("RolesId", "NameRole")
VALUES (1, 'Админ');
INSERT INTO "Roles" ("RolesId", "NameRole")
VALUES (2, 'Пользователь');

INSERT INTO "Users" ("UsersId", "CreateAt", "Email", "Password", "Phone", "RoleId", "UpdatedAt", "UsersName")
VALUES (1, '2025-01-10 12:00:00', 'Admin@mail.ru', 'Admin', '', 1, '2025-01-10 12:00:00', 'Admin');

CREATE INDEX "IX_Changes_in_the_system_UserId" ON "Changes_in_the_system" ("UserId");

CREATE INDEX "IX_CodeSnippets_Programming_language" ON "CodeSnippets" ("Programming_language");

CREATE INDEX "IX_CodeSnippets_UserId" ON "CodeSnippets" ("UserId");

CREATE INDEX "IX_Comment_RatingId" ON "Comment" ("RatingId");

CREATE INDEX "IX_Comment_SnippetsId" ON "Comment" ("SnippetsId");

CREATE INDEX "IX_Comment_UserId" ON "Comment" ("UserId");

CREATE INDEX "IX_History_SnippetId" ON "History" ("SnippetId");

CREATE INDEX "IX_Image_LogotypeId" ON "Image" ("LogotypeId");

CREATE INDEX "IX_Image_UserId" ON "Image" ("UserId");

CREATE INDEX "IX_Logotype_ImageId" ON "Logotype" ("ImageId");

CREATE INDEX "IX_Setting_SnippetId" ON "Setting" ("SnippetId");

CREATE INDEX "IX_Users_RoleId" ON "Users" ("RoleId");

ALTER TABLE "Image" ADD CONSTRAINT "FK_Image_Logotype_LogotypeId" FOREIGN KEY ("LogotypeId") REFERENCES "Logotype" ("LogotypeId") ON DELETE CASCADE;

SELECT setval(
    pg_get_serial_sequence('"Language"', 'Id_Programming_language'),
    GREATEST(
        (SELECT MAX("Id_Programming_language") FROM "Language") + 1,
        nextval(pg_get_serial_sequence('"Language"', 'Id_Programming_language'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"Rate"', 'RateId'),
    GREATEST(
        (SELECT MAX("RateId") FROM "Rate") + 1,
        nextval(pg_get_serial_sequence('"Rate"', 'RateId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"Roles"', 'RolesId'),
    GREATEST(
        (SELECT MAX("RolesId") FROM "Roles") + 1,
        nextval(pg_get_serial_sequence('"Roles"', 'RolesId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"Users"', 'UsersId'),
    GREATEST(
        (SELECT MAX("UsersId") FROM "Users") + 1,
        nextval(pg_get_serial_sequence('"Users"', 'UsersId'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250224182855_InitialCreatms12122', '9.0.0');

COMMIT;

