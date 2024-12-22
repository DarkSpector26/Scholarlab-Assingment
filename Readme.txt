
This project includes two scenes: Lab (Assignment 1) and Quiz (Assignment 2). The builds of both scenes function flawlessly on both Windows and Android. 
There are no further dependencies or setup requirements needed.

There are two scenes in this Unity project:

Lab Scene: An interactive virtual laboratory where participants conduct chemical experiments.
Users drag and drop creatures into classified baskets in this entertaining and instructive animal sorting quiz.

1. Laboratory Scene
uses interactive elements to simulate chemical experiments.
Mixing chemicals allows users to see logical and visual results.
C# scripts direct each experiment to guarantee precise simulation.

2. Scene of the Quiz
An animal classification knowledge exam using a drag-and-drop game.
Different categories are represented by two baskets (e.g., Herbivores vs. Carnivores).
Users drop an animal card into the appropriate basket after dragging it.
instantaneous feedback on right or wrong responses.    

Script for AnimalQuizManager
This script controls the Quiz Scene's operation, including user interactions, score updates, and game flow. Below is a summary of its main characteristics:

Quiz Categories: A predetermined set of categories (Flying, Insect, Diet, Social, and Reproduction) are chosen at random by the game. Users are required to classify animals into appropriate groupings (such as Flying vs. Non-Flying) based on this category.

Animal Sorting: The script determines whether an animal was successfully placed in the red or blue bucket (which symbolize distinct categories) when users drag it into one. The score is updated if it is accurate.

UI Updates: The script adds the user's score, the category name that is now in use, and the headline text that describes what the user is sorting to the user interface. After the quiz is over, a progress message is displayed and the names of the animals are added to a list if the user places them incorrectly.

End Game: After every animal has been sorted, the game is over. In addition to providing feedback based on the player's performance, the script gives the final score and a list of animals that were sorted wrongly.


Test Tube Script 
Users can interact with the test tube by "pouring" a liquid when they click or tap on the screen thanks to the TestTube Script, which controls the functionality for the Test Tube object in the Lab Scene.

Pouring Mechanism: The script determines whether the input is on the test tube object when the user touches the screen or clicks the mouse. If so, an audio clip is played and the "pouring" animation is triggered.

Visual Feedback: By altering the fill amount (using a material attribute) and animating the pouring motion, the script refreshes the test tube's visual representation.

Flask Interaction: Using Flask.instance, the script causes the Flask object to tremble after pouring.Shake()), which initiates a further animation sequence to finish the experiment.

Sound Effects: Throughout the pouring procedure, the script plays sound effects and pauses them when necessary.
