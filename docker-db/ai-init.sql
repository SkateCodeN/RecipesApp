CREATE TABLE airecipes (
  id SERIAL PRIMARY KEY,
  jsondata JSON,
  recipe_count integer
);

-- Insert sample data
INSERT INTO airecipes (jsondata,recipe_count)
VALUES
  (
  $json$
  [{
    "name": "Spaghetti Carbonara",
    "description": "A classic Italian pasta dish featuring a creamy egg sauce, crispy pancetta, and a generous amount of Parmesan cheese.",
    "ingredients": [
      { "ingredient": "Spaghetti", "amount": "400g" },
      { "ingredient": "Pancetta or Bacon", "amount": "150g, diced" },
      { "ingredient": "Eggs", "amount": "4 large" },
      { "ingredient": "Parmesan Cheese", "amount": "100g, grated" },
      { "ingredient": "Black Pepper", "amount": "to taste" },
      { "ingredient": "Salt", "amount": "to taste" }
    ],
    "prep_time": "10 minutes",
    "cook_time": "20 minutes",
    "instructions": [
      "Cook spaghetti in salted boiling water until al dente.",
      "While the pasta cooks, fry the pancetta until crispy.",
      "In a bowl, beat the eggs and mix in grated Parmesan cheese and black pepper.",
      "Drain the pasta and return it to the pot off the heat.",
      "Quickly stir in the egg mixture, allowing the residual heat to form a creamy sauce without scrambling the eggs.",
      "Season with salt and additional pepper as needed, then serve immediately."
    ]
  },
  {
    "name": "Chicken Stir-Fry",
    "description": "A quick and healthy dish loaded with tender chicken, crisp vegetables, and a savory soy-based sauce.",
    "ingredients": [
      { "ingredient": "Chicken Breast", "amount": "500g, thinly sliced" },
      { "ingredient": "Broccoli", "amount": "1 head, cut into florets" },
      { "ingredient": "Bell Pepper", "amount": "1 large, sliced" },
      { "ingredient": "Carrots", "amount": "2 medium, julienned" },
      { "ingredient": "Soy Sauce", "amount": "3 tablespoons" },
      { "ingredient": "Garlic", "amount": "3 cloves, minced" },
      { "ingredient": "Ginger", "amount": "1 tablespoon, minced" },
      { "ingredient": "Olive Oil", "amount": "2 tablespoons" }
    ],
    "prep_time": "15 minutes",
    "cook_time": "15 minutes",
    "instructions": [
      "Heat olive oil in a large pan or wok over medium-high heat.",
      "Add garlic and ginger and sauté until fragrant.",
      "Add the chicken slices and cook until lightly browned.",
      "Stir in the vegetables and cook for 5-7 minutes until tender-crisp.",
      "Pour in the soy sauce and toss to coat evenly.",
      "Cook for another 2 minutes, then serve hot with rice or noodles."
    ]
  },
  {
    "name": "Classic Beef Stew",
    "description": "A hearty, warming stew loaded with tender beef, potatoes, carrots, and a rich, savory broth perfect for chilly days.",
    "ingredients": [
      { "ingredient": "Beef Chuck", "amount": "1kg, cut into chunks" },
      { "ingredient": "Potatoes", "amount": "3 medium, diced" },
      { "ingredient": "Carrots", "amount": "3 large, sliced" },
      { "ingredient": "Onion", "amount": "1 large, chopped" },
      { "ingredient": "Beef Broth", "amount": "4 cups" },
      { "ingredient": "Tomato Paste", "amount": "2 tablespoons" },
      { "ingredient": "Garlic", "amount": "3 cloves, minced" },
      { "ingredient": "Thyme", "amount": "1 teaspoon dried" },
      { "ingredient": "Bay Leaf", "amount": "1" },
      { "ingredient": "Salt and Pepper", "amount": "to taste" },
      { "ingredient": "Olive Oil", "amount": "2 tablespoons" }
    ],
    "prep_time": "20 minutes",
    "cook_time": "2 hours",
    "instructions": [
      "Season beef chunks with salt and pepper.",
      "Heat olive oil in a large pot and brown the beef on all sides.",
      "Add the chopped onion and garlic; cook until softened.",
      "Mix in tomato paste, then add beef broth, thyme, and bay leaf.",
      "Bring to a simmer, cover, and cook for 1 hour.",
      "Add potatoes and carrots, and continue simmering for another hour until all ingredients are tender.",
      "Remove the bay leaf, adjust seasoning, and serve hot."
    ]
  },
  {
    "name": "Vegetarian Chili",
    "description": "A robust and flavorful chili packed with a mix of beans, tomatoes, and spices for a satisfying vegetarian meal.",
    "ingredients": [
      { "ingredient": "Kidney Beans", "amount": "1 can (15 oz), drained and rinsed" },
      { "ingredient": "Black Beans", "amount": "1 can (15 oz), drained and rinsed" },
      { "ingredient": "Chickpeas", "amount": "1 can (15 oz), drained and rinsed" },
      { "ingredient": "Diced Tomatoes", "amount": "1 can (14.5 oz)" },
      { "ingredient": "Onion", "amount": "1 large, chopped" },
      { "ingredient": "Bell Pepper", "amount": "1 large, chopped" },
      { "ingredient": "Garlic", "amount": "3 cloves, minced" },
      { "ingredient": "Chili Powder", "amount": "2 tablespoons" },
      { "ingredient": "Cumin", "amount": "1 tablespoon" },
      { "ingredient": "Olive Oil", "amount": "2 tablespoons" },
      { "ingredient": "Salt and Pepper", "amount": "to taste" }
    ],
    "prep_time": "15 minutes",
    "cook_time": "40 minutes",
    "instructions": [
      "Heat olive oil in a large pot over medium heat.",
      "Sauté the onion, garlic, and bell pepper until softened.",
      "Add chili powder and cumin and stir for about 1 minute.",
      "Stir in the beans and diced tomatoes with their juices.",
      "Bring the mixture to a simmer and cook for 30-40 minutes, stirring occasionally.",
      "Season with salt and pepper, and serve hot with your favorite toppings."
    ]
  },
  {
    "name": "Lemon Garlic Salmon",
    "description": "A fresh and flavorful salmon dish marinated in lemon and garlic, then baked to perfection for a healthy and delicious meal.",
    "ingredients": [
      { "ingredient": "Salmon Fillets", "amount": "4 (6 oz each)" },
      { "ingredient": "Lemon Juice", "amount": "1/4 cup" },
      { "ingredient": "Garlic", "amount": "4 cloves, minced" },
      { "ingredient": "Olive Oil", "amount": "2 tablespoons" },
      { "ingredient": "Salt", "amount": "to taste" },
      { "ingredient": "Black Pepper", "amount": "to taste" },
      { "ingredient": "Fresh Dill", "amount": "2 tablespoons, chopped" }
    ],
    "prep_time": "10 minutes",
    "cook_time": "15 minutes",
    "instructions": [
      "Preheat your oven to 400°F (200°C).",
      "Place the salmon fillets on a baking tray lined with parchment paper.",
      "Mix lemon juice, garlic, olive oil, salt, and pepper in a small bowl.",
      "Brush the mixture evenly over the salmon fillets.",
      "Bake for 12-15 minutes or until the salmon flakes easily with a fork.",
      "Garnish with fresh dill and serve immediately."
    ]
  },
  {
    "name": "Caprese Salad",
    "description": "A simple and fresh Italian salad featuring ripe tomatoes, fresh mozzarella, basil, and a drizzle of balsamic glaze.",
    "ingredients": [
      { "ingredient": "Tomatoes", "amount": "3 large, sliced" },
      { "ingredient": "Fresh Mozzarella", "amount": "250g, sliced" },
      { "ingredient": "Fresh Basil Leaves", "amount": "a handful" },
      { "ingredient": "Olive Oil", "amount": "2 tablespoons" },
      { "ingredient": "Balsamic Glaze", "amount": "2 tablespoons" },
      { "ingredient": "Salt and Pepper", "amount": "to taste" }
    ],
    "prep_time": "10 minutes",
    "cook_time": "0 minutes",
    "instructions": [
      "Arrange tomato and mozzarella slices on a serving platter, alternating between them.",
      "Scatter fresh basil leaves on top.",
      "Drizzle olive oil and balsamic glaze evenly over the salad.",
      "Season with salt and pepper, and serve immediately."
    ]
  },
  {
    "name": "Chocolate Chip Cookies",
    "description": "Classic, chewy chocolate chip cookies with crisp edges and soft centers, perfect for any occasion.",
    "ingredients": [
      { "ingredient": "All-purpose Flour", "amount": "2 1/4 cups" },
      { "ingredient": "Baking Soda", "amount": "1 teaspoon" },
      { "ingredient": "Salt", "amount": "1/2 teaspoon" },
      { "ingredient": "Unsalted Butter", "amount": "1 cup (2 sticks), softened" },
      { "ingredient": "Granulated Sugar", "amount": "3/4 cup" },
      { "ingredient": "Brown Sugar", "amount": "3/4 cup, packed" },
      { "ingredient": "Vanilla Extract", "amount": "1 teaspoon" },
      { "ingredient": "Eggs", "amount": "2 large" },
      { "ingredient": "Chocolate Chips", "amount": "2 cups" }
    ],
    "prep_time": "15 minutes",
    "cook_time": "10-12 minutes",
    "instructions": [
      "Preheat your oven to 375°F (190°C) and line baking sheets with parchment paper.",
      "Whisk together flour, baking soda, and salt in a bowl.",
      "In another bowl, beat the butter with granulated sugar and brown sugar until creamy.",
      "Add eggs and vanilla extract to the butter mixture and mix until well combined.",
      "Gradually incorporate the dry ingredients, then fold in the chocolate chips.",
      "Drop rounded tablespoons of dough onto the prepared baking sheets.",
      "Bake for 10-12 minutes until the edges are golden brown.",
      "Allow the cookies to cool on the baking sheet for a few minutes before transferring to a wire rack."
    ]
  }
  ]
  $json$, 7);
  