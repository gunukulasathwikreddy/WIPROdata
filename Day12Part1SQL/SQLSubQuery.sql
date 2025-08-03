use sqlpractice
Go

-- Display matching records from Agent and AgentPolicy Tables 

select * from Agent WHERE AgentId = ANY(select AgentId from AgentPolicy) 

-- Display Matching records from Policy and AgentPolicy Tables 

select * from Policy WHERE PolicyId = ANY (select PolicyId from AgentPolicy) 
GO

-- Display Idle Agents (AgentId Exists in Agent Table, but not in AgentPolicy Table) 

select * from Agent where AgentId <> ALL(select AgentId from AgentPolicy) 
GO

-- Display Idle Policies (PolicyId exists in Policy Table, but not in AgentPolicy Table) 

select * from Policy WHERE PolicyId <> ALL(select PolicyId from AgentPolicy) 
GO