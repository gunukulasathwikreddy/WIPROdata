create view viewAgentPolicy 
AS
select 
	A.AgentId, FirstName, LastName, City, State,
		P.PolicyId, AppNumber, AppDate, ModalPremium, AnnualPremium
from Agent A INNER JOIN AgentPolicy AP
ON A.AgentId = AP.AgentID 
INNER JOIN Policy P 
ON P.PolicyId = AP.PolicyID
GO

select * from viewAgentPolicy 
GO