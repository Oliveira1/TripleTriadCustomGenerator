# TripleTriadCustomGenerator
Create Triple Triad Similar cards based on the given images


This solution enables the creation of cards with random numbers assigned to each one of the four sides in order to print and play Final Fantasy like triple triad game.
In order to use currently you need to change the file path for each variable and point it to your folders.
Common folder = contains images of cards that are to be random generated as common cards.
Rare folder = contains images of cards that are to be random generated as rare cards.
Legendary folder = contains images of cards that are to be random generated as common cards.
Common cards are generated  with a sum in the range of [18,22].
Rare cards are generated  with a sum in the range of [21,25].
Legendary cards are generated  with a sum in the range of [24,29].
The algorithm finds the sums unique combinations , randomly assigns a combination to a card and shifts right the assigned value so the next assignment gives diferent poles to the same combination

Common card example with a sum of 20

-------------------
|        5        |
|                 |
| 5             5 |
|                 |
|        5        |
-------------------
