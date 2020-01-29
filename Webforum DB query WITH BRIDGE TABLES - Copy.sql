USE WebForumDB;

CREATE TABLE UserRoles (    
	role_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
	_role varchar (50)
);
CREATE TABLE Categories (
    category_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
	category_description nvarchar (200),
    
);
CREATE TABLE Threads (
    thread_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
    thread_date smalldatetime,
	thread_title nvarchar (200), 
	category_id int NOT NULL FOREIGN KEY REFERENCES Categories(category_id)
);
CREATE TABLE Posts (
    post_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
    date_posted smalldatetime,
	post_description nvarchar (4000), 
	thread_id int NOT NULL FOREIGN KEY REFERENCES Threads(thread_id)
);
CREATE TABLE UserAccounts (
    user_account_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
    account_name varchar(50) NOT NULL UNIQUE,
    account_password varchar (400) NOT NULL,
	salt varchar (10) NOT NULL,
	role_id int NOT NULL FOREIGN KEY REFERENCES UserRoles(role_id),
);
CREATE TABLE UserPosts (
	up_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
    user_account_id int FOREIGN KEY REFERENCES UserAccounts(user_account_id),
	post_id int FOREIGN KEY REFERENCES Posts(post_id)
);
CREATE TABLE UserThreads (
	ut_id int PRIMARY KEY NOT NULL IDENTITY (1,1),
    user_account_id int FOREIGN KEY REFERENCES UserAccounts(user_account_id),
	thread_id int FOREIGN KEY REFERENCES Threads(thread_id)
);



