create database Restoreo;


go
use Restoreo;


Delete Orders

Delete DishesGroups

create table Users(
Login varchar(30) primary key,
Password varchar(30) unique,
Role varchar(30),
Name varchar(30),
FirstName varchar(30),
Number varchar(15),
Gender varchar(5),
Img varchar(200),
Adress varchar(30)
);

create table Tables(
	Id int primary key,
	CanvasLeft int,
	CanvasTop int,
	PathImgFree varchar(200),
	PathImgNoFree varchar(200),
	PathImgSelect varchar(200),
	Sizes int,
	Places int,
	Vip varchar(5)
)



insert into Tables
values
(0,135,340, '/Sources/YgolTableFree.png', '/Sources/YgolTableNotFree.png', '/Sources/YgolTableSelect.png', 50,3,'false'),
(1,73, 343, '/Sources/FreeTableWallReverse.png', '/Sources/NotFreeTableWallReverse.png', '/Sources/TableWallSelectReverse.png', 50,4,'false'),
(2,13, 341, '/Sources/YgolTableFreeLeft.png', '/Sources/YgolTableNotFreeLeft.png', '/Sources/YgolTableSelectLefr.png', 50, 3, 'false'),
(3,13, 280, '/Sources/YgolTableFreeTop.png', '/Sources/YgolTableNotFreeTop.png', ' /Sources/YgolTableSelectTop.png', 50, 3, 'false'),
(4,30, 195, '/Sources/FreeTableFor4.png', '/Sources/NotFreeTableFor4.png', '/Sources/TableFor4Select.png', 50, 4, 'true'),
(5,158, 177, '/Sources/FreeTableFor4.png', '/Sources/NotFreeTableFor4.png', '/Sources/TableFor4Select.png', 50, 4, 'false'),
(6,221, 130, '/Sources/FreeTableFor4.png', '/Sources/NotFreeTableFor4.png', '/Sources/TableFor4Select.png', 50, 4, 'false'),
(7,284, 176, '/Sources/FreeTableFor4.png', '/Sources/NotFreeTableFor4.png', '/Sources/TableFor4Select.png', 50, 4, 'false'),
(8,510, 238, '/Sources/FreeBigTable.png', '/Sources/NotFreBigTable.png', '/Sources/BigTableSelect.png', 130, 12, 'true'),
(9,447, 340, '/Sources/YgolTableFree.png', '/Sources/YgolTableNotFree.png', '/Sources/YgolTableSelect.png', 50, 3, 'false'),
(10,380, 343, '/Sources/FreeTableWallReverse.png', '/Sources/NotFreeTableWallReverse.png', '/Sources/TableWallSelectReverse.png', 50, 4, 'false'),
(11,415, 220, '/Sources/FreeTableFor4.png', '/Sources/NotFreeTableFor4.png', '/Sources/TableFor4Select.png', 50, 4, 'false'),
(12,222, 220, '/Sources/FreeTableFor4.png', '/Sources/NotFreeTableFor4.png', '/Sources/TableFor4Select.png', 50, 4, 'false')

select * from Tables


create table Orders(
Id int primary key,
UserLogin varchar(30) References Users(Login),
TableId int References Tables(Id),
Date varchar(30),
Time varchar(30),
)

drop table Orders

go

use Restoreo
declare @time DateTime = GetDate();
print @time
print Charindex('.',@time)

select * from Orders

select Orders.TableId, Tables.Places,Orders.Date, Orders.Time  from Orders inner join Tables on Orders.TableId = Tables.Id
where (DATEPART(HOUR,GETDATE()) >= CAST(Substring(Orders.Time,0,CHARINDEX(':',Orders.Time))as int) and DATEPART(DAY,GETDATE()) = CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
or (DATEPART(DAY,GETDATE()) > CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
and DATEPART(MONTH,GETDATE()) >=CAST(SUBSTRING(Orders.Date,Charindex('.',Orders.date)+1,charindex('.',Orders.Date,charindex('.',Orders.Date))-2)as int)
and DATEPART(YEAR,GETDATE()) >=cast (SUBSTRING(Orders.Date,CHARINDEX('.',Orders.Date,Charindex('.',Orders.Date)+1) +1, DATALENGTH(Orders.Date)) as int )
and Orders.UserLogin = 'Nikita'

select * from Tables

create table DishesGroups(
Id int primary key,
NumberOrder int References Orders(Id),
NumberDish int References Dishes(Id)
)

Select * from Orders


create table Dishes(
Id int primary key,
Name varchar(40) not null,
Description varchar(200)not null,
Coast varchar(10) not null)



insert into Dishes values
(0,'яичница','€йца','12'),
(1,'омлет','€йца,молоко','22'),
(2,'чай','вода','6'),
(3,'кофе','вода','8'),
(4,'стейк гов€жий','гов€дина','40'),
(5,'салат летний','помидоры','10')



go
create procedure FormingOrder @login varchar(50), @tableid int, @date varchar(50), @time varchar(50)
as begin
declare @id int = (select top(1) Id from Orders order by(ID) desc);
set @id +=1;
insert into Orders values(@id,@login,@tableid,@date,@time);
SELECT SCOPE_IDENTITY()
end

go
create procedure InsertDish @name varchar(50), @description varchar(50), @coast varchar(50)
as begin
declare @id int = (select top(1) Id from Dishes order by(ID) desc);
if	@id is null
	set @id = 0
else 
	set @id +=1;
insert into Dishes values(@id,@name,@description,@coast);
SELECT SCOPE_IDENTITY()
end


select * from Dishes



declare @j int;
exec @j = FormingOrder 'Nikita', 1,'12.05.2023','12:12';
print @j

select * from Orders

insert into Users values('admin','admin','admin','','','','','','');

select * from Users

select Orders.TableId, Tables.Places,Orders.Date, Orders.Time  from Orders inner join Tables on Orders.TableId = Tables.Id
where (DATEPART(HOUR,GETDATE()) <= CAST(Substring(Orders.Time,0,CHARINDEX(':',Orders.Time))as int) and DATEPART(DAY,GETDATE()) = CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
or (DATEPART(DAY,GETDATE()) < CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
and DATEPART(MONTH,GETDATE()) <=CAST(SUBSTRING(Orders.Date,Charindex('.',Orders.date)+1,charindex('.',Orders.Date,charindex('.',Orders.Date))-2)as int)
and DATEPART(YEAR,GETDATE()) <=cast (SUBSTRING(Orders.Date,CHARINDEX('.',Orders.Date,Charindex('.',Orders.Date)+1) +1, DATALENGTH(Orders.Date)) as int )
and Orders.UserLogin = 'Nikita'


select * from Orders

drop procedure FormingDishList

go
create procedure FormingDishList @numberOrder int, @numberDish int
as begin
declare @id int = (select top(1) Id from DishesGroups order by(ID) desc);
if @id is null
	set @id = 0;
else 
	set @id +=1;

insert into DishesGroups values(@id,@numberOrder,@numberDish);
SELECT SCOPE_IDENTITY()
end


select * from Orders

drop procedure GetAllOrders

go
create procedure GetAllOrders
as begin
declare @dishes varchar(200) = '',@login varchar(40) = '' , @firstName varchar(30) = '', @number varchar(30) = '',@date varchar(30) = '', @time varchar(30) = '',@tableid int, @nameDish varchar(30),
@login1 varchar(40) , @firstName1 varchar(30), @number1 varchar(30),@date1 varchar(30), @time1 varchar(30),@tableid1 int, @nameDish1 varchar(30);
declare curs cursor local static for select distinct Users.Login,Users.FirstName,Users.Number,Orders.Date ,Orders.Time,Orders.TableId,Dishes.Name
from orders inner join Users on USERs.Login = Orders.UserLogin
full join DishesGroups on Orders.Id = DishesGroups.NumberOrder
left join Dishes on Dishes.Id = DishesGroups.NumberDish where (DATEPART(HOUR,GETDATE()) <= CAST(Substring(Orders.Time,0,CHARINDEX(':',Orders.Time))as int) and DATEPART(DAY,GETDATE()) = CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
or (DATEPART(DAY,GETDATE()) < CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
and DATEPART(MONTH,GETDATE()) <=CAST(SUBSTRING(Orders.Date,Charindex('.',Orders.date)+1,charindex('.',Orders.Date,charindex('.',Orders.Date))-2)as int)
and DATEPART(YEAR,GETDATE()) <=cast (SUBSTRING(Orders.Date,CHARINDEX('.',Orders.Date,Charindex('.',Orders.Date)+1) +1, DATALENGTH(Orders.Date)) as int )

create table #table(
Login varchar(30),
FirstName varchar(30),
Number varchar(30),
Date varchar(30),
Time varchar(30),
TableId int,
Dishes varchar(200)
)


open curs
fetch curs into @login, @firstName,@number,@date,@time,@tableid,@nameDish
set @login1 = @login;
set @firstName1 = @firstName;
set @number1 = @number;
set @date1 = @date;
set @time1 = @time;
set @tableid1 = @tableid;
set @nameDish1 = @nameDish;
if @nameDish is null
begin
set @nameDish1 = ' ';
end
set @dishes +=@nameDish1;


while @@FETCH_STATUS = 0
begin
fetch curs into @login, @firstName,@number,@date,@time,@tableid,@nameDish
if @login = @login1
begin 
if	@nameDish is null
	set @nameDish = ' '
set @dishes += ', '+ @nameDish
print @dishes +'if'
end
if @login != @login1
begin
	insert into #table values( @login1,@firstName1,@number1,@date1,@time1,@tableid1,@dishes)
set @login1 = @login;
set @firstName1 = @firstName;
set @number1 = @number;
set @date1 = @date;
set @time1 = @time;
set @tableid1 = @tableid;
set @nameDish1 = @nameDish;
set @dishes = '';
if @nameDish1 is null
begin
set @nameDish1 = ' ';
end

set @dishes +=  ', '+ @nameDish1 ;
print @dishes +'iffff'
end
end

	insert into #table values( @login1,@firstName1,@number1,@date1,@time1,@tableid1,@dishes);

	select * from #table;
	drop table #table

end

declare @rc int;
exec GetAllOrders

select * from DishesGroups

select * from Orders 
full outer join DishesGroups on Orders.Id = DishesGroups.NumberOrder
inner join Dishes on Dishes.Id = DishesGroups.NumberDish
inner join Users on Users.Login = Orders.UserLogin


select Users.Login,Users.FirstName,Users.Number,Orders.Date ,Orders.Time,Orders.TableId,Dishes.Name
from orders inner join Users on USERs.Login = Orders.UserLogin
full join DishesGroups on Orders.Id = DishesGroups.NumberOrder
left join Dishes on Dishes.Id = DishesGroups.NumberDish where (DATEPART(HOUR,GETDATE()) <= CAST(Substring(Orders.Time,0,CHARINDEX(':',Orders.Time))as int) and DATEPART(DAY,GETDATE()) = CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
or (DATEPART(DAY,GETDATE()) < CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))
and DATEPART(MONTH,GETDATE()) <=CAST(SUBSTRING(Orders.Date,Charindex('.',Orders.date)+1,charindex('.',Orders.Date,charindex('.',Orders.Date))-2)as int)
and DATEPART(YEAR,GETDATE()) <=cast (SUBSTRING(Orders.Date,CHARINDEX('.',Orders.Date,Charindex('.',Orders.Date)+1) +1, DATALENGTH(Orders.Date)) as int ) order by (  CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))




