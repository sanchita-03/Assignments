Create Database PolicyManagement

use PolicyManagement

Create Table Policies(
	PolicyId int identity(1,1) Primary Key,
	PolicyHolderName Varchar(20) not null,
	PolicyType int not null,
	StartDate Date not null,
	EndDate Date not null
)
truncate table policies 


select * from Policies
public int PolicyId { get; set; }
public string PolicyHolderName { get; set; }
public PolicyType PolicyType { get; set; }
public DateTime StartDate { get; set; }
public DateTime EndDate { get; set; }