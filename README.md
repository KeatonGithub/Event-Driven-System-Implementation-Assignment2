# Event-Driven-System-Implementation-Assignment2
 
Document Design Rationale and Gameplay Impact 

Describe the design and event flow of the system:
The design is simple: you pick up the key which opens the door allowing you to proceed to the next level. The event flow would be the player walks towards key then puts key into the inventory then moves to the next level.

Explains how events improve modularity and gameplay responsiveness:
The events of having inventory systems and management are the responsiveness of having multiple elements working together simultaneously. Like, when you pick up the item and it shows up on the UI that you have it while also deleting the object in game. Allowing you to easily have a function that interacts or depends on the equipped item later. In this case I just had it so that a key item once picked up unlocks a door and puts the key into the players inventory.

Reflects on challenges and solutions during development:
Getting the key to unlock the door proved to be very challenging, I wrote a lot of if statements involving if the player had collected the key, the one at the end is the one that worked somewhat. I would have liked to have made it so that the key was removed from the inventory too. But, that proved challenging as the syntax was interfering with other elements.
