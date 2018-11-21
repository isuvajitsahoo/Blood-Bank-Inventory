create proc BBank.uspGetBloodBanks
as
begin
	select * from BBank.BloodInventory
end


create proc BBank.uspDeleteBloodInventory
(
@ExpiryDate Date
)
as
begin
	delete from BBank.BloodInventory
	where ExpiryDate = @ExpiryDate
end


create proc BBank.uspEditBloodInventory
(
@bId int,
@bloodGroup varchar(255),
@noOfBottles int,
@bloodBankId int,
@expiryDate date,
@hid int
)
as
begin
	update BBank.BloodInventory
	set BloodGroup = @bloodGroup,NumberOfBottle=@noOfBottles,
	BloodBankId=@bloodBankId,ExpiryDate=@expiryDate,HospitalId=@hid
	where BloodInventoryId = @bId
end



create proc BBank.uspSearchBloodInventory
(
@bId int
)
as
begin
	select * from BBank.BloodInventory
	where BloodInventoryId = @bId
end



select * from BBank.BloodInventory

insert into BBank.BloodInventory values(2,'B +ve', 12345,44,1/1/2019,4)
