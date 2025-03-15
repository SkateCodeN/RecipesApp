-- Create the recipes table
CREATE TABLE recipes (
  id SERIAL PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  description TEXT,
  createddate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  lastuseddate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Insert sample data
INSERT INTO recipes (name, description, createddate, lastuseddate)
VALUES
  ('Spaghetti Bolognese', 'A classic Italian pasta dish with rich meat sauce', NOW(), NOW()),
  ('Chicken Curry', 'Spicy and flavorful chicken curry', NOW(), NOW()),
  ('Vegetable Stir Fry', 'Quick and healthy mixed vegetable stir fry', NOW(), NOW());
