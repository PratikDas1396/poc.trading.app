use tradingdb;
CREATE TABLE users (
    id VARCHAR(36) NOT NULL PRIMARY KEY,
    username VARCHAR(20) NOT NULL,
    firstname VARCHAR(255) NOT NULL,
    lastname VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);

insert into users(id,  username, firstname, lastname, email, password)
select '2290ca93-5e08-4263-a8f3-30032c41bc8a', 'pratikdas1396' ,'Pratik', 'Das', 'pratikdas.social@gmail.com', 'pass@123'
union
select 'cff6678b-3c3f-40e2-8b1b-af148910347e', 'rohinikuperkar2396' ,'Rohini', 'Kuperkar', 'kuperkarrohini@gmail.com', 'pass@123'
union
select '8cfcdc13-0543-4e2d-85bc-33e9161d48bd', 'adarshverma9999','Adarsh', 'Verma', 'adarshverma99@gmail.com', 'pass@123';

CREATE TABLE userrole (
    id CHAR(36) NOT NULL PRIMARY KEY,
    userid CHAR(36) NOT NULL references users(id),
    role VARCHAR(255) NOT NULL
);

insert into userrole(id, userid, role)
select '4f24d34c-0255-43d4-8516-60188e358aeb', '8cfcdc13-0543-4e2d-85bc-33e9161d48bd', 'ADMIN'
UNION
select '72e63c0c-5d75-4610-b02c-6d8cc0c6f397', 'cff6678b-3c3f-40e2-8b1b-af148910347e', 'USER'
UNION
select '3e763275-ff18-400b-9166-d25ccbc1e5e0', '2290ca93-5e08-4263-a8f3-30032c41bc8a', 'USER';

CREATE TABLE stocks (
    id varchar(36) NOT NULL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    price DOUBLE NOT NULL,
    availablequantity bigint NOT NULL default 0,
    totalquantity integer NOT NULL default 0
);

insert into stocks(id, name, price, availablequantity, totalquantity)
select 'c3dd155e-dcee-474f-9348-e3bf5a9f754a', 'TATA MOTERS', 199.10, 9921, 84939
UNION 
select 'bf6c99bd-6d8e-4e0c-8cce-3272586a1ea1', 'RELIANCE', 199.10, 9921, 9921
UNION
select '0531bed3-9f4d-478e-87c2-0c52772ad3af', 'SUN PHARMA', 199.10, 0, 100
UNION
select '7f49f093-07ba-4de0-8e26-2caac5c62080', 'GODREJ', 199.10, 9921, 89201
UNION
select '5c86c211-6a98-42ac-b634-eb6331a9f238', 'EICHER MOTORS', 199.10, 9921, 64810
UNION
select '6a2e1f38-b458-43b0-a23a-1b5873134d2f', 'LNT', 199.10, 10, 99919
UNION
select '5a382057-86ab-40d2-bc90-7f0eb0c405b8', 'TCS', 199.10, 902, 100000000
UNION
select '171d9ec5-0ba5-4eb0-abbc-4ddaa0402cdb', 'GAIL', 199.10, 190, 100000000
UNION
select '660840c6-f528-4744-9eab-7163c19f614a', 'TATA POWER', 892, 9921, 100000000
UNION
select 'e0ba7c24-2978-4a4b-b9e1-ff735749b200', 'ADANI POWER', 1000, 9921, 100000000;

CREATE TABLE watchlist(
    userid CHAR(36) NOT NULL references users(id),
    stockid CHAR(36) NOT NULL references stocks(id)
);

CREATE TABLE orders (
    id CHAR(36) NOT NULL PRIMARY KEY,
    stockid CHAR(36) NOT NULL references stocks(id),
    userid CHAR(36) NOT NULL references users(id),
    totalprice DOUBLE NOT NULL,
    quantity integer NOT NULL default 0
);
-- drop table stocks;
-- drop table users;
-- drop table userrole;
-- drop table watchlist;
-- drop table orders;
-- select * from users;
-- select * from userrole; 
-- select * from stocks;
-- select * from watchlist;
-- select * from orders;
