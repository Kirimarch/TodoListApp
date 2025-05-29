-- Script Date: 27/5/2568 19:38  - ErikEJ.SqlCeScripting version 3.5.2.95
CREATE TABLE [users] (
  [Id] INTEGER NOT NULL
, [username] TEXT NOT NULL
, [password] TEXT NOT NULL
, CONSTRAINT [PK_users] PRIMARY KEY ([Id])
);
