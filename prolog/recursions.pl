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


product_up(N, N):- N < 10, !.
product_up(N, Product):-
    N >= 10,
    LastDigit is N mod 10,         
    NewN is N div 10,              
    product_up(NewN, NewDig),  
    Product is LastDigit * NewDig.


product_down(N, Product):- product_down(N, 1, Product).
product_down(0, CurrentProduct, CurrentProduct):- !.
product_down(N, CurrentProduct, Product):-
    N > 0,
    Digit is N mod 10,            
    NewProduct is CurrentProduct * Digit, 
    Next is N div 10,              
    product_down(Next, NewProduct, Product). 


max_not_div3_up(N, N):- 
    N < 10,
    N mod 3 =\= 0, !.

max_not_div3_up(N, Max):-
    N < 10,
    N mod 3 =:= 0,
    Max = -1, !. 

max_not_div3_up(N, Max):-
    N >= 10,
    LastDigit is N mod 10,
    Rest is N div 10,
    max_not_div3_up(Rest, RestMax),
    (LastDigit mod 3 =\= 0 ->
        (RestMax =:= -1 -> Max is LastDigit  
        ; Max is max(LastDigit, RestMax))    
    ; Max is RestMax). 


max_not_div3_down(N, Max):-
    max_not_div3_down(N, -1, Max).  

max_not_div3_down(0, CurrentMax, CurrentMax):- !.

max_not_div3_down(N, CurrentMax, Max):-
    N > 0,
    Digit is N mod 10,
    (Digit mod 3 =\= 0 ->
        NewMax is max(Digit, CurrentMax)  
        ; NewMax is CurrentMax),         
    Next is N div 10,
    max_not_div3_down(Next, NewMax, Max).


/*
divisors_count_up(N, Count):-
    N > 0,
    count_divisors_up(N, N, Count).

count_divisors_up(1, _, 1) :- !.
count_divisors_up(N, D, Count) :-
    D > 1,
    (N mod D =:= 0 -> 
        NextD is D - 1,
        count_divisors_up(N, NextD, TempCount),
        Count is TempCount + 1
    ;
        NextD is D - 1,
        count_divisors_up(N, NextD, Count)).


divisors_count_down(N, Count) :-
    N > 0,
    count_divisors_down(N, N, 0, Count).

count_divisors_down(1, _, Acc, Acc1) :-
    Acc1 is Acc + 1, !.

count_divisors_down(N, D, Acc, Count) :-
    D > 1,
    (N mod D =:= 0 ->
        NewAcc is Acc + 1
    ;
        NewAcc is Acc
    ),
    NextD is D - 1,
    count_divisors_down(N, NextD, NewAcc, Count).
*/

find_decreasing_indices(List, Indices) :-
    add_indices(List, 0, Indexed),
    predsort(compare_pairs, Indexed, Sorted),
    extract_indices(Sorted, Indices).


compare_pairs(Order, [V1,_], [V2,_]) :-
    compare(Order, V2, V1).  

add_indices([], _, []).
add_indices([H|T], I, [[H,I]|Rest]) :-
    NextI is I + 1,
    add_indices(T, NextI, Rest).


extract_indices([], []).
extract_indices([[_,I]|T], [I|Rest]) :-
    extract_indices(T, Rest).


print_indices(Indices) :-
    write('Indices: '),
    write(Indices),
    nl.




