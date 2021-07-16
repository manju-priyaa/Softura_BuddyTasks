create database dbDLusingAjax
use dbDLusingAjax

-- Country Table
create table Country(
CountryId int identity(1,1),
CountryName varchar(50) not null,
constraint PK_country primary key (CountryID)
)

-- State Table

create table State(
StateId int identity(1,1),
CountryId int,
StateName varchar(50) not null,
constraint PK_state primary key (StateId),
constraint FK_country foreign key(CountryId)
references Country(CountryID)
)

-- District Table 
create table District(
DistrictId int identity(1,1),
StateId int,
DistrictName varchar(50) not null,
constraint PK_district primary key (DistrictID),
constraint FK_state foreign key(StateID)
references State(StateID)
)

select * from Country
select * from State
select * from District