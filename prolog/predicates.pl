man :- man(X), print(X), nl, fail.
woman :- woman(X), print(X), nl, fail.

children(X) :- parent(X, Y), print(Y), nl, fail.

mother(X,Y) :- parent(X,Y), woman(X).
mother(X) :- mother(Y,X), print(Y).

father(X, Y) :- parent(X, Y), man(X).
father(X) :- father(Y, X), print(Y).

brother(X, Y) :- father(F, X), father(F, Y), mother(M, X), mother(M, Y), man(X), X\=Y.
brothers(X) :- father(F, X), mother(M, X), father(F, Brother), mother(M, Brother), man(Brother), X \= Brother, print(Brother), nl, fail.

b_s(X, Y) :- father(F, X), father(F, Y), mother(M, X), mother(M, Y), X \= Y.
b_s(X) :- b_s(X, Y), print(Y), nl, fail.

wife(X, Y) :- woman(X), man(Y), parent(X, C), parent(Y, C), !.
wife(X) :- wife(Y, X), print(Y).

grand_da(X,Y) :- woman(X), parent(F, X), parent(Y,F).

grand_dats(X) :- parent(X, F),  parent(F, Y), woman(Y), print(Y), nl, fail.
grand_dats(X) :- grand_da(D, X), print(D), nl, fail.

grand_pa_and_da(X,Y) :- (man(X), grand_da(Y,X)) ; (man(Y), grand_da(X,Y)).
grand_pa_and_da(X,Y) :- (man(X), woman(Y), parent(F,Y), parent(X,F)) ; (man(Y), woman(X), parent(F, X), parent(Y,F)).

aunt(X, Y) :- b_s(X, F), parent(F, Y), woman(X).
aunts(X) :- aunt(Y, X), print(Y), nl, fail.

