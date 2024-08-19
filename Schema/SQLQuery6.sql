
insert into Users(Email,Password,FirstName,LastName)
values('akram@gmail.com','$2a$12$rnD2n4HV6kMlqSGpb.SImOHPzesoorXtYe597.s/.0bm43bhiPaOW','muhammad','akram');

select * from Users


insert into Events(Title,Description,Date,Time,VenueId,Status,UserId)
values('event 1','dvent 1 description',GETDATE(),SYSDATETIME(),2,'active',1)

insert into Venue (Name, Address) values ('venue 2' , 'islamabad pakistan')