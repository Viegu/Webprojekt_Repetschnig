create database db_shop collate utf8mb4_general_ci;

use db_shop;

create table articles(
	article_id int unsigned not null auto_increment,
    name varchar(200) not null,
    price decimal(6,2) not null,
    description varchar(5000) null,
    genre int not null,
    username varchar(200) not null,
    
    constraint article_id_PK primary key(article_id)
)engine=InnoDb;

  insert into articles values(null, "I will make you a good beat", 50, "I will make you a good beat for your Song. Just tell me which type of song you want to 
sing and how the beat shold sound Like. It usally takes me one week to finish my project", 0,"LilShrimp");
  insert into articles values(null, "I'll do some background Singing", 30, "Hi, my name is Allie and I am a Student in Tirol. In my freetime I really like to sing
a lot and so I sell my Voice on this Plattform to get some extra money", 0,"Allie_120304");
  insert into articles values(null, "I'll make your website look sexy with css/js", 120, "Hello, my name is Sebastian R. and I am a student in Innsbruck. 
I love desiging websites with js and css and thats why I sell my knowledge on this website. For the 120 Euros i will design and decorate your website", 1,"Noxus_Darius");
  insert into articles values(null, "Logo-Design", 15, "I will design your own Logo in Photoshop for you", 1,"Adrian_03");
  insert into articles values(null, "I'll coach you in League Of Legends", 10000, "Hello, my name is Faker and I am a pro-Esport player in League of legends. for the money I will give you
10 Lessons which are about 1 hour long", 2,"SKTT1_Faker");
  insert into articles values(null, "Give me money, Im poor", 1, "Thanks for your support", 7,"HomelessGuy");
  insert into articles values(null, "Draw Cartoon-Characters", 20, "I'll draw Cartoon-characters for 20€", 4,"Donald_The_Creative_Duck");
  insert into articles values(null, "Fitness-Plan", 100, "I'll make your personal Fitness-Plan with Workouts to do and food recommendations", 6,"Sascha_H");




select * from articles;

