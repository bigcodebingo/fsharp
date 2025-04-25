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