/****** Skript für SelectTopNRows-Befehl aus SSMS ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[HigherLevelArticleGroupId]
  FROM [MusterAG].[dbo].[ArticleGroups]

 INSERT INTO ArticleGroups
VALUES ('Wasser', 3 );

SELECT * FROM dbo.ArticleGroups;

use MusterAG;




