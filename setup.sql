USE castleknights1;

-- CREATE TABLE castle
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255),
--     description VARCHAR(255) DEFAULT "Your Typical Castle",
--     age VARCHAR(255),

--     PRIMARY KEY (id)

-- );

-- INSERT INTO castle
-- (name, description, age)
-- VALUES
-- ("Camelot", "A silly place", 500)
-- DROP TABLE knight;
-- CREATE TABLE knight
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255),
--     description VARCHAR(255) DEFAULT "Your Typical Castle",
--     color VARCHAR(255),
--     castleId INT NOT NULL,

--     PRIMARY KEY (id),

--     FOREIGN KEY (castleId)
--         REFERENCES castle (id)
--         ON DELETE CASCADE
-- );


-- INSERT INTO castle
-- (name, description, age)
-- VALUES
-- ("Camelot", "A silly place", "Green")