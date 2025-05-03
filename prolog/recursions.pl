max(X,Y,X) :- X>Y, !.
max(_,Y,Y).
max(X,Y,Z,N):- max(X,Y,V), max(V,Z,N).

max3(X,Y,Z,N):- X>Y, X>Z, !.
max3(_, Y, Z, Y):- Y>Z, !.
max3(_, _, Z, Z).

sum_digits(0,0):- !.
sum_digits(N,S):- 
	Digit is N mod 10, 
	N1 is N div 10, 
	sum_digits(N1,S1), 
	S is S1 + Digit.

sum_digits_down(N,S):- sum_digits_down(N,0,S).
sum_digits_down(0,Sum,Sum):- !.
sum_digits_down(N, CurSum, Sum):- 
	Digit is N mod 10,
	N1 is N div 10, 
	NewCurSum is CurSum + Digit,
	sum_digits_down(N1, NewCurSum, Sum).	

fact(0, 1):- !.  
fact(N, X):-
    N > 0,
    PrevN is N - 1,
    fact(PrevN, PrevX),  
    X is N * PrevX.        

fact_down(N, X):- fact_down(N, 1, X).  
fact_down(0, Acc, Acc):- !.  
fact_down(N, Acc, X):-
    N > 0,
    NewAcc is Acc * N,     
    NextN is N - 1,
    fact_down(NextN, NewAcc, X).  

square_free(N):-
    N > 1,
    \+ (between(2, N, D), 
        Sqr is D * D,
        Sqr =< N,
        0 is N mod Sqr).  

read_list(List):-
    write('write list...'),
    read(List).  

write_list([]):- !. 
write_list([H | T]):- 
	write(H), 
	nl, 
	write_list(T).

sum_list_down([H | T], S):- sum_list_down([H | T], 0, S).
sum_list_down([], Sum, Sum):- !.
sum_list_down([H | T], CurSum, Sum):- 
	NewCurSum is CurSum + H, 
	sum_list_down(T, NewCurSum, Sum).

sum_list_up([], 0).  
sum_list_up([H | T], Sum) :-
    sum_list_up(T, SumTail),  
    Sum is H + SumTail.

remove_with_sum([], _, []).
remove_with_sum([H|T], Sum, Result):-
    sum_digits_down(H, DSum),   
    DSum = Sum, !,                       
    remove_with_sum(T, Sum, Result).  

remove_with_sum([H|T], Sum, [H|Result]):- remove_with_sum(T, Sum, Result).