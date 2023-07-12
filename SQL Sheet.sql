create Database library;

use library;

create table Books(
	book_id int primary key,
	title VARCHAR(50),
    author  VARCHAR(50),
    genre VARCHAR(50),
    borrowed  VARCHAR(50)
	)

	ALTER TABLE Books
ALTER COLUMN borrowed bit;

delete from Books where book_id =1 

	insert into Books values('1','a','a','a','a','411034','India','maharashtra')

	SELECT * FROM Books;
create table Borrower(
	Id int Identity(1,1) primary key,
	book_id int foreign key references Books(book_id),
	Name_Of_Borrower varchar(50)
	)

------------------------------ ADD BOOK ------------------------------ 
alter PROCEDURE AddBook
	@book_id int,
	@title VARCHAR(50),
    @author  VARCHAR(50),	
    @genre VARCHAR(50),
    @borrowed  bit
AS
BEGIN 
	BEGIN TRANSACTION
	BEGIN TRY
	INSERT INTO Books VALUES(@book_id,@title,@author,@genre,@borrowed)
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION
	END CATCH 
END
EXEC AddBook

------------------------------ ADD BOOK ------------------------------ 
-- only while doing borrow book use borrower name 






------------------------------Display Books -------------------------------

CREATE PROCEDURE DisplayBooks
AS
BEGIN
	SELECT * FROM Books;
	END

	EXEC DisplayBooks