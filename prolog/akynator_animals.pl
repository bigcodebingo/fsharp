question1(X1):- write("Is the animal a mammal? (1 - Yes, 0 - No)"), nl, read(X1).
question2(X2):- write("Does the animal live in water? (1 - Yes, 0 - No)"), nl, read(X2).
question3(X3):- write("Is the animal a predator? (1 - Yes, 0 - No)"), nl, read(X3).
question4(X4):- write("Does the animal have stripes or spots? (1 - Yes, 0 - No)"), nl, read(X4).
question5(X5):- write("Is the animal domesticated? (1 - Yes, 0 - No)"), nl, read(X5).
question6(X6):- write("Is the animal larger than a human? (1 - Yes, 0 - No)"), nl, read(X6).

animal(lion,     1, 0, 1, 0, 0, 1).
animal(tiger,    1, 0, 1, 1, 0, 1).
animal(elephant, 1, 0, 0, 0, 0, 1).
animal(giraffe,  1, 0, 0, 1, 0, 1).
animal(zebra,    1, 0, 0, 1, 0, 0).
animal(dog,      1, 0, 1, 0, 1, 0).
animal(cat,      1, 0, 1, 0, 1, 0).
animal(cow,      1, 0, 0, 0, 1, 1).
animal(horse,    1, 0, 0, 0, 1, 1).
animal(wolf,     1, 0, 1, 0, 0, 0).
animal(fox,      1, 0, 1, 0, 0, 0).
animal(bear,     1, 0, 1, 0, 0, 1).
animal(panda,    1, 0, 0, 1, 0, 1).
animal(monkey,   1, 0, 0, 0, 0, 0).
animal(dolphin,  1, 1, 1, 0, 0, 1).
animal(whale,    1, 1, 0, 0, 0, 1).
animal(shark,    0, 1, 1, 0, 0, 1).
animal(eagle,    0, 0, 1, 0, 0, 0).
animal(crocodile,0, 1, 1, 0, 0, 1).
animal(snake,    0, 0, 1, 1, 0, 0).
animal(frog,     0, 1, 1, 0, 0, 0).
animal(penguin,  0, 1, 0, 0, 0, 0).
animal(ostrich,  0, 0, 0, 0, 0, 1).
animal(parrot,   0, 0, 0, 1, 1, 0).
animal(spider,   0, 0, 1, 0, 0, 0).
animal(butterfly,0, 0, 0, 1, 0, 0).

guess_animal :-
    question1(X1), question2(X2), question3(X3),
    question4(X4), question5(X5), question6(X6),
    animal(Name, X1, X2, X3, X4, X5, X6),
    nl, write("The animal is: "), write(Name), nl.