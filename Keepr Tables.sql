
CREATE TABLE users (
    id int NOT NULL AUTO_INCREMENT,
    username VARCHAR(20) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY email (email)
);

CREATE TABLE vaults (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(255) NOT NULL,
    userId int,
    INDEX userId (userId),
    FOREIGN KEY (userId)
        REFERENCES users(id)
        ON DELETE CASCADE,  
    PRIMARY KEY (id)
);

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );
-- My Keeps (miller)
CREATE TABLE keeps (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(255) NOT NULL,
    imgurl  varchar(255),
    articleurl varchar(255),
    tags varchar(255),
    ispublic tinyint(1) DEFAULT 0,
    userId int,
    INDEX userId (userId),
    FOREIGN KEY (userId)
        REFERENCES users(id)
        ON DELETE CASCADE,  
    PRIMARY KEY (id)
);
CREATE TABLE vaultkeeps (
    id int NOT NULL AUTO_INCREMENT,
    vaultId int NOT NULL,
    keepId int NOT NULL,
    userId int NOT NULL,

    PRIMARY KEY (id),
    INDEX (vaultId, keepId),
    INDEX (userId),

    FOREIGN KEY (userId)
        REFERENCES users(id)
        ON DELETE CASCADE,

    FOREIGN KEY (vaultId)
        REFERENCES vaults(id)
        ON DELETE CASCADE,

    FOREIGN KEY (keepId)
        REFERENCES keeps(id)
        ON DELETE CASCADE
);
-- alter table keepr.keeps
-- add column nbrkeeps int after nbrviews


-- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = 2)
