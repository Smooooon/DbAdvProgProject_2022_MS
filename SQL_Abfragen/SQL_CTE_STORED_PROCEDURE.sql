CREATE PROCEDURE ArticleGroups @higherLAG int
AS

;WITH CTE_ArticleGroups (
	Id, name, HigherLevelArticleGroupId, ProductLevel )
AS (
	SELECT	Id ,
			name,
            HigherLevelArticleGroupId ,
            1 AS ProductLevel
    FROM dbo.ArticleGroups
    WHERE HigherLevelArticleGroupId IS NULL
    UNION ALL
    SELECT	pn.Id ,
			pn.name,
            pn.HigherLevelArticleGroupId ,
            p1.ProductLevel + 1
    FROM dbo.ArticleGroups AS pn
    INNER JOIN CTE_ArticleGroups AS p1
		ON p1.Id = pn.HigherLevelArticleGroupId
)

SELECT	Id ,
		name,
        HigherLevelArticleGroupId ,
        ProductLevel
FROM CTE_ArticleGroups
ORDER BY ProductLevel;
GO

EXEC ArticleGroups @higherLAG = 1 ;




Drop Procedure If Exists ArticleGroups ;

