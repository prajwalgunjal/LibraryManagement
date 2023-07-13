create Database library;

use library;

create table Books(
	book_id int primary key,
	title VARCHAR(50),
    author  VARCHAR(50),
    genre VARCHAR(50),
    --borrowed  VARCHAR(50)
	 borrowed  bit
	)


	-------------------------------------------
	create table Borrower(
	Id int Identity(1,1) primary key,
	book_id int foreign key references Books(book_id),
	Name_Of_Borrower varchar(50)
	)




	--------------------------------------
	ALTER TABLE Books
ALTER COLUMN borrowed bit;

delete from Books where borrowed=0 

	insert into Books values('1','a','a','a','a','411034','India','maharashtra')

	SELECT * FROM Books;




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

ALTER PROCEDURE DisplayBooks
AS
BEGIN
	--DECLARE @BookCount int
	--SELECT @BookCount = COUNT(title) from Books

	--SELECT @BookCount AS TOTALBooks
	SELECT * FROM Books;
	END

	EXEC DisplayBooks

	------------------------------Display Avaliable Books -------------------------------

alter PROCEDURE DisplayAvaliableBooks
AS
BEGIN
	SELECT * FROM Books where borrowed =  0;
	END

	EXEC DisplayAvaliableBooks
-----insert into Books values(9,'i','i','i',1),(10,'u','u','u',1)
		------------------------------Display Borrowed Books -------------------------------

alter PROCEDURE DisplayBorrowedeBooks
AS
BEGIN
		SELECT c.book_id,c.title,c.author,c.genre,p.Name_Of_Borrower From Books AS c JOIN Borrower As p ON c.book_id = p.book_id where c.borrowed =1 
	END

	EXEC DisplayBorrowedeBooks

			-----------------------------get_books_by_author-------------------------------

CREATE PROCEDURE get_books_by_author
@author varchar(50)
AS
BEGIN
	SELECT * FROM Books where author =  @author;
	END

	EXEC get_books_by_author 'i'
	
			-----------------------------get_books_by_genre-------------------------------

CREATE PROCEDURE get_books_by_genre
@genre varchar(50)
AS
BEGIN
	SELECT * FROM Books where genre =  @genre;
	END

	EXEC get_books_by_genre 'i'

				-----------------------------get_books_by_book_id-------------------------------

CREATE PROCEDURE get_books_by_book_id
@book_id int
AS
BEGIN
	SELECT * FROM Books where book_id =  @book_id;
	END

	EXEC get_books_by_book_id 8



	------------------------------borrow book
	SELECT * From Books AS c JOIN Borrower As p ON c.book_id = p.book_id 
		SELECT c.book_id,c.title,c.genre,p.Name_Of_Borrower From Books AS c JOIN Borrower As p ON c.book_id = p.book_id	where p.book_id =1 

alter PROCEDURE usp_Borrow_Book
(
	@bookid int,
	@BoorowerName varchar(50)
)
as
begin
	if exists (select * from Books where book_id = @bookid and borrowed = 0)
	begin

		insert into Borrower (book_id,Name_Of_Borrower)
		values (@bookid,@BoorowerName)

		update Books
		set borrowed = 1
		where book_id = @bookid
	end
	else
	begin
	print 'Book Not Found or Issued By Someone'
	end
end

usp_Borrow_Book 2,'Patil'

-----------------------------------return book

CREATE PROCEDURE Return_Book
(
	@bookid int
)
as
begin
	if exists (select * from Books where book_id = @bookid and borrowed = 1)
	begin
		delete Borrower where book_id = @bookid;
		update Books
		set borrowed = 0
		where book_id = @bookid
	end
	else
	begin
	print 'Book returned'
	end
end

Return_Book 2

