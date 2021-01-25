create database db_accounts collate utf8mb4_general_ci;

use db_accounts;

create table accounts(
	account_id int unsigned not null auto_increment,
    vorname varchar(1000) not null,
    nachname varchar(1000) not null,
    username varchar(20) not null,
    email varchar(345) null,
    passwort varchar (100) not null,
     geburtsdatum date null,
     istModerator boolean not null,
    constraint account_id_PK primary key(account_id)
)engine=InnoDb;

insert into accounts values(0,"Manuel","Repetschnig","admin","repetschnigmanuel@gmail.com","admin","2003-03-12",true);
insert into accounts values(1,"Niklas","SChneider","Fridoulin","Schneidli@gmail.com","123321","2003-03-12",false);
select * from accounts;