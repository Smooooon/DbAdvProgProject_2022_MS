CREATE PROCEDURE SelectAllCustomers @higherLAG int
AS

; WITH CTE_Articles ( Id, HigherLevelArticleGroupId)
AS (
SELECT Id, HigherLevelArticleGroupId FROM ArticleGroups

)

SELECT * FROM  CTE_Articles WHERE HigherLevelArticleGroupId = @HigherLAG
GO

EXEC SelectAllCustomers @higherLAG = 1 ;




Drop Procedure If Exists SelectAllCustomers ;

