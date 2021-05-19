
drop table Stock
drop table LineItems
drop table Orders
drop table Locations
drop table Customers
drop table Products

create table Customers
(
    id int identity primary key,
    name nvarchar(50) not null,
    username nvarchar(50) unique not null,
    password nvarchar(50) not null
);

create table Locations
(
    id int identity primary key,
    city nvarchar(50) not null,
    state nvarchar(50) not null,
    manager int not null foreign key references Customers(id)
);

create table Products
(
    id int identity primary key,
    name nvarchar(50) not null,
    price float not null,
    description nvarchar(240)
);

create table Orders
(
    id int identity primary key,
    customer int not null foreign key references Customers(id),
    location int not null foreign key references Locations(id),
    total float not null,
    time DATETIME not null
)

create table LineItems 
(
    id int identity primary key,
    orderid int not null foreign key references Orders(id),
    product int not null foreign key references Products(id),
    quantity int not null
);

create table Stock
(
    id int identity primary key,
    product int not null foreign key references Products(id),
    location int not null foreign key references Locations(id),
    quantity int not null
);



insert into Customers (name, username, password) VALUES
('Kolby McDaniel', 'kolbym', 'kolby'),
('Marielle Nolasco', 'trainer', 'p@$$word');

insert into Locations (city, state, manager) values 
('Jacksonville', 'Florida', 1),
('New York', 'New York', 1)

insert into Products (name, price, description) values 
('Red', 10.00, 'The color of tomatoes'),
('Blue', 9.00, 'The color of the sky'),
('Yellow', 7.50, 'The color of bananas');

insert into Orders (customer, location, total, time) values 
(1, 1, 27.50, '2021-05-16 12:30:00');

insert into LineItems (orderid, product, quantity) values 
(1, 1, 2),
(1, 3, 1);

insert into Stock (product, location, quantity) values 
(1, 1, 8),
(1, 2, 5),
(2, 1, 10),
(2, 2, 5),
(3, 1, 9),
(3, 2, 5);

