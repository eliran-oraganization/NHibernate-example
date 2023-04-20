
    drop table chefs cascade constraints

    drop table Dishes cascade constraints

    drop table Restaurants cascade constraints

    drop table RestaurantChef cascade constraints

    create table chefs (
        id RAW(16) not null,
       FullName VARCHAR2(255),
       DateOfBirth TIMESTAMP(7),
       YearsOfExperience NUMBER(10,0),
       primary key (id)
    )

    create table Dishes (
        Id RAW(16) not null,
       Name VARCHAR2(255),
       Description VARCHAR2(255),
       Image VARCHAR2(255),
       Price NUMBER(19,5),
       RestaurantId RAW(16),
       primary key (Id)
    )

    create table Restaurants (
        Id RAW(16) not null,
       Name VARCHAR2(255),
       Rating DOUBLE PRECISION,
       primary key (Id)
    )

    create table RestaurantChef (
        RestaurantId RAW(16) not null,
       ChefId RAW(16) not null,
       primary key (RestaurantId, ChefId)
    )

    alter table Dishes 
        add constraint FK_AAF75D5 
        foreign key (RestaurantId) 
        references Restaurants

    alter table RestaurantChef 
        add constraint FK_BA89B1E 
        foreign key (ChefId) 
        references chefs

    alter table RestaurantChef 
        add constraint FK_F216AFBE 
        foreign key (RestaurantId) 
        references Restaurants
