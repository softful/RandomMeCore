DROP DATABASE IF EXISTS users;
CREATE DATABASE IF NOT EXISTS users;
USE users;

SELECT 'CREATING DATABASE STRUCTURE' as 'INFO';

DROP TABLE IF EXISTS NameBlock,
                     Photo,
                     Country;

CREATE TABLE Country (
    id                INT             NOT NULL AUTO_INCREMENT,
    country_name      VARCHAR(15)     NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE NameBlock (
    id          INT                                     NOT NULL AUTO_INCREMENT,
    block_type  ENUM ('Title','FirstName','LastName')   NOT NULL,
    name        VARCHAR(20)                             NOT NULL,    
    gender      ENUM ('M','F')                          NULL,
    country_id  INT                                     NULL,
    PRIMARY KEY (id)
    FOREIGN KEY (country_id) REFERENCES Countries (Countries) ON DELETE CASCADE
);

CREATE TABLE Photo (
    id          INT                                     NOT NULL AUTO_INCREMENT,    
    file_path        VARCHAR(20)                             NOT NULL,    
    gender      ENUM ('M','F')                          NULL,   
    PRIMARY KEY (id)    
);

INSERT INTO Country VALUES
   ('NZ');

INSERT INTO NameBlock VALUES
('Title','Mr. ','M',1),
('Title','Mrs. ','F',1),
('Title','Miss. ','F',1);

INSERT INTO NameBlock VALUES
('FirstName','aaron','M',1),
('FirstName','adam','M',1),
('FirstName','aidan','M',1),
('FirstName','aiden','M',1),
('FirstName','alex','M',1),
('FirstName','alexander','M',1),
('FirstName','angus','M',1),
('FirstName','archer','M',1),
('FirstName','archie','M',1),
('FirstName','arlo','M',1),
('FirstName','arthur','M',1),
('FirstName','asher','M',1),
('FirstName','ashton','M',1),
('FirstName','austin','M',1),
('FirstName','beau','M',1),
('FirstName','benjamin','M',1),
('FirstName','blake','M',1),
('FirstName','braxton','M',1),
('FirstName','caleb','M',1),
('FirstName','abigail','F',1),
('FirstName','addison','F',1),
('FirstName','alexandra','F',1),
('FirstName','alexis','F',1),
('FirstName','alice','F',1),
('FirstName','amber','F',1),
('FirstName','amelia','F',1),
('FirstName','anna','F',1),
('FirstName','annabelle','F',1),
('FirstName','aria','F',1),
('FirstName','ariana','F',1),
('FirstName','aurora','F',1),
('FirstName','ava','F',1),
('FirstName','ayla','F',1),
('FirstName','bella','F',1),
('FirstName','brooke','F',1),
('FirstName','brooklyn','F',1),
('FirstName','caitlin','F',1);

INSERT INTO LastNames(block_type, name, country_id) VALUES
('LastName','anderson',1),
('LastName','brown',1),
('LastName','chen',1),
('LastName','clarke',1),
('LastName','cooper',1),
('LastName','davies',1),
('LastName','edwards',1),
('LastName','evans',1),
('LastName','green',1),
('LastName','hall',1),
('LastName','harris',1),
('LastName','hughes',1),
('LastName','jackson',1),
('LastName','johnson',1),
('LastName','jones',1),
('LastName','king',1),
('LastName','kumar',1),
('LastName','lee',1),
('LastName','lewis',1);

CREATE USER 'user'@'localhost' IDENTIFIED WITH mysql_native_password BY 'simplepwd';
GRANT ALL ON employees.* TO 'user'@'localhost';

flush logs;
