/****** Skript für SelectTopNRows-Befehl aus SSMS ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[HigherLevelArticleGroupId]
  FROM [MusterAG].[dbo].[ArticleGroups]

 INSERT INTO ArticleGroups
VALUES ('Wasser', 3 );

SELECT * FROM dbo.ArticleGroups;

use MusterAG;



DELIMITER $
create procedure ArticelSort (IN name VARCHAR(50), OUT hello VARCHAR(50))
BEGIN
	Select HigherLevelArticleGroupId (ID, name, ProductLevel) into ArticelSort;
END$
DELIMITER ;


;WITH CTE_Products (
	Id, HigherLevelArticleGroupId, ProductLevel )
AS (
	SELECT	Id ,
            HigherLevelArticleGroupId ,
            0 AS ProductLevel
    FROM Muster..Artikelgruppe
    WHERE HigherLevelArticleGroupId IS NULL
    UNION ALL
    SELECT	pn.Id ,
            pn.HigherLevelArticleGroupId ,
            p1.ProductLevel + 1
    FROM Muster..Artikelgruppe AS pn
    INNER JOIN CTE_Products AS p1
		ON p1.Id = pn.HigherLevelArticleGroupId
)

SELECT	Id ,
        HigherLevelArticleGroupId,
        ProductLevel
FROM CTE_Products
ORDER BY HigherLevelArticleGroupId;
GO
