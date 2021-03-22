create database db_accounts collate utf8mb4_general_ci;

use db_accounts;

create table accounts(
	account_id int unsigned not null auto_increment,
    vorname varchar(1000) not null,
    nachname varchar(1000) not null,
    username varchar(20) not null,
    email varchar(345) null,
    passwort varchar (1000) not null,
     geburtsdatum date null,
     istModerator boolean not null,
    constraint account_id_PK primary key(account_id)
)engine=InnoDb;


insert into accounts values(null,'Manuel','Repetschnig','admin','repetschnigmanuel@gmail.com',(sha2('admin',512)),null,'1');
select * from accounts;
drop table accounts;



