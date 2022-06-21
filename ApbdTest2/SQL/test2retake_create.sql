-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-06-21 08:26:56.8

-- tables
-- Table: Action
CREATE TABLE Action (
    IdAction int  NOT NULL,
    StartTime datetime  NOT NULL,
    EndTime datetime  NULL,
    NeedSpecialEquipment bit  NOT NULL,
    CONSTRAINT Action_pk PRIMARY KEY  (IdAction)
);

-- Table: Firefighter
CREATE TABLE Firefighter (
    IdFirefighter int  NOT NULL,
    FirstName nvarchar(30)  NOT NULL,
    LastName nvarchar(50)  NOT NULL,
    CONSTRAINT Firefighter_pk PRIMARY KEY  (IdFirefighter)
);

-- Table: Firefighter_Action
CREATE TABLE Firefighter_Action (
    IdFirefighter int  NOT NULL,
    IdAction int  NOT NULL,
    CONSTRAINT Firefighter_Action_pk PRIMARY KEY  (IdFirefighter,IdAction)
);

-- Table: Firetruck
CREATE TABLE Firetruck (
    IdFireTruck int  NOT NULL,
    OperationalNumber nvarchar(10)  NOT NULL,
    SpecialEquipment bit  NOT NULL,
    CONSTRAINT Firetruck_pk PRIMARY KEY  (IdFireTruck)
);

-- Table: Firetruck_Action
CREATE TABLE Firetruck_Action (
    IdFireTruckAction int  NOT NULL,
    AssignmentDate datetime  NOT NULL,
    IdFireTruck int  NOT NULL,
    IdAction int  NOT NULL,
    CONSTRAINT Firetruck_Action_pk PRIMARY KEY  (IdFireTruckAction)
);

-- foreign keys
-- Reference: Firefighter_Action_Action (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Firefighter_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: Firefighter_Action_Firefighter (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Firefighter_Action_Firefighter
    FOREIGN KEY (IdFirefighter)
    REFERENCES Firefighter (IdFirefighter);

-- Reference: Firetruck_Action_Action (table: Firetruck_Action)
ALTER TABLE Firetruck_Action ADD CONSTRAINT Firetruck_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: Firetruck_Action_Firetruck (table: Firetruck_Action)
ALTER TABLE Firetruck_Action ADD CONSTRAINT Firetruck_Action_Firetruck
    FOREIGN KEY (IdFireTruck)
    REFERENCES Firetruck (IdFireTruck);

-- End of file.

-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-06-21 08:26:56.8

-- tables
-- Table: Action
CREATE TABLE Action (
    IdAction int  NOT NULL,
    StartTime datetime  NOT NULL,
    EndTime datetime  NULL,
    NeedSpecialEquipment bit  NOT NULL,
    CONSTRAINT Action_pk PRIMARY KEY  (IdAction)
);

-- Table: Firefighter
CREATE TABLE Firefighter (
    IdFirefighter int  NOT NULL,
    FirstName nvarchar(30)  NOT NULL,
    LastName nvarchar(50)  NOT NULL,
    CONSTRAINT Firefighter_pk PRIMARY KEY  (IdFirefighter)
);

-- Table: Firefighter_Action
CREATE TABLE Firefighter_Action (
    IdFirefighter int  NOT NULL,
    IdAction int  NOT NULL,
    CONSTRAINT Firefighter_Action_pk PRIMARY KEY  (IdFirefighter,IdAction)
);

-- Table: Firetruck
CREATE TABLE Firetruck (
    IdFireTruck int  NOT NULL,
    OperationalNumber nvarchar(10)  NOT NULL,
    SpecialEquipment bit  NOT NULL,
    CONSTRAINT Firetruck_pk PRIMARY KEY  (IdFireTruck)
);

-- Table: Firetruck_Action
CREATE TABLE Firetruck_Action (
    IdFireTruckAction int  NOT NULL,
    AssignmentDate datetime  NOT NULL,
    IdFireTruck int  NOT NULL,
    IdAction int  NOT NULL,
    CONSTRAINT Firetruck_Action_pk PRIMARY KEY  (IdFireTruckAction)
);

-- foreign keys
-- Reference: Firefighter_Action_Action (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Firefighter_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: Firefighter_Action_Firefighter (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Firefighter_Action_Firefighter
    FOREIGN KEY (IdFirefighter)
    REFERENCES Firefighter (IdFirefighter);

-- Reference: Firetruck_Action_Action (table: Firetruck_Action)
ALTER TABLE Firetruck_Action ADD CONSTRAINT Firetruck_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: Firetruck_Action_Firetruck (table: Firetruck_Action)
ALTER TABLE Firetruck_Action ADD CONSTRAINT Firetruck_Action_Firetruck
    FOREIGN KEY (IdFireTruck)
    REFERENCES Firetruck (IdFireTruck);

-- End of file.

INSERT INTO Firetruck VALUES (1, '1ndso01', 0);
INSERT INTO Firetruck VALUES (2, '1ndso02', 1);

Select * from Firetruck;

INSERT INTO Firefighter VALUES (1, 'John', 'Impact');
INSERT INTO Firefighter VALUES (2, 'John', 'Doom');

Select * from Firefighter;

INSERT INTO Action VALUES (1, '1999-01-01', '1999-01-02', 0);
INSERT INTO Action VALUES (2, '1999-01-03', '1999-01-04', 1);

Select * from Action;

INSERT INTO Firefighter_Action VALUES (1, 2);
INSERT INTO Firetruck_Action VALUES (1, '1999-01-01', 2, 1);