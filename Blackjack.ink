VAR setting = ""
VAR character = ""
VAR story_start = ""
VAR story_conflict = ""
VAR story_end = ""
VAR win = 0

// Sample framework without the blackjack game
// In each round randomly determines the player's win or loss. The available cards selection is designated in this sample framework, which should be based on the winner's cards in the final version.
// Two to Four different settings/characters/backstories are available in each round for this sample framework. Should support a total of thirteen settings/characters/backstories in the final version
// Total of 5 rounds (provisional)

// You wake up on a unknown location. 


// "Play Blackjack with a man wearing a Gucci basketball hat in the Casino." 

You are playing Blackjack with a man wearing a Gucci basketball hat.

You don't remember who you are and why you are here.

As you play the Blackjack you will retrieve your memory.

+[Start] -> Round1
== Casino
You entered a gorgeous casino.

+[Round 1] -> Round1
== Round1
// First round A, J, 3, 6 available

{~You lost the first round of Blackjack. ->Lost1|You won the first round of Blackjack! ->Won1}

== Lost1
~ setting = "{~A|J|3|6}"

Your opponent has won. He picked {setting} from your cards.
-> next1

== Won1
~win++
You have four cards in your hand and you chose:

* A {set_setting("A")} 
->next1
* J {set_setting("J")} 
->next1
* 3 {set_setting(3)} 
->next1
* 6 {set_setting(6)} 
->next1

==function set_setting(x)
~ setting = x


== next1
// Narrative transition related to the selected setting

{ setting:
- "A": 	You are in a casino.
- "J": 	You are in a movie theatre.
- 3: 	You are in an amusement park.
- 6: You are in a coffee shop.
}

How did you get here?

+[Keep playing to find out] -> Round2


== Round2
// Second round 2, 10, 7  available

{~You lost the second round of Blackjack. ->Lost2|You won the second round of Blackjack. ->Won2}

== Lost2
~ character = "{~2|10|7}"

Your opponent has won. He picked {character} from your cards.
-> next2

== Won2
~win++
You have three cards in your hand and you chose:

* 2 {set_character(2)} 
->next2
* 10 {set_character(10)} 
->next2
* 7 {set_character(7)} 
->next2
==function set_character(x)
~ character = x

== next2

{ character:
- 2: 	You are a doctor in your late thirties.
- 10: 	You are a lift operator.
- 7: You are a NCSU student
}

+[Round 3]-> Round3


== Round3
// Third round 4, 5, 7, A available

{~You lost the third round. ->Lost3|You won the third round. ->Won3}
== Lost3
~ story_start = "{~4|5|7|A}"

Your opponent has won. He picked {story_start} from your cards.
-> next3
== Won3
~win++
You have four cards in your hand and you chose:

* 4 {set_start(4)} 
->next3
* 5 {set_start(5)} 
->next3
* 7 {set_start(7)} 
->next3
* A {set_start("A")} 
->next3

==function set_start(x)
~ story_start = x
== next3

{ character:
- 2: 	You are a doctor in your late thirties. <>
    { story_start:
        - 4: 	 You were born in X, the youngest of Y siblings.
        - 5: 	You were born in Y, in a family of Z.
        - 7:    You were born in New York, a secret bastard child of Donald Trump.
        - "A": 	You were born in A.
    }
- 10: 	You are a lift operator. <>
    { story_start:
        - 4: 	 You were born in X, the youngest of Y siblings.
        - 5: 	You were born in Y, in a family of Z.
        - 7:    You were born in New York, a secret bastard child of Donald Trump.
        - "A": 	You were born in A.
    }
- 7: You are a NCSU student <>
    { story_start:
        - 4: 	 You were born in X, the youngest of Y siblings.
        - 5: 	You were born in Y, in a family of Z.
        - 7:    You were born in New York, a secret bastard child of Donald Trump.
        - "A": 	You were born in A.
    }
}



+[Round 4]-> Round4


== Round4
// Fourth round k, 8 available
You Played the Blackjack. 

{~You lost. ->Lost4|You won. ->Won4}

== Lost4
~ story_conflict = "{~K|8}"

Your opponent has won. He has two cards in his hand and he has chosen: {story_conflict}.
-> next4
== Won4
~win++
You have two cards in your hand and you chose:

* K {set_conflict("K")} 
->next4
* 8 {set_conflict(8)} 
->next4


==function set_conflict(x)
~ story_conflict = x
== next4
+[Round 5]-> Round5


== Round5
// Fifth round 2, 4, A, Q available
You Played the Blackjack. 

{~You lost. ->Lost5|You won. ->Won5}

== Lost5
~ story_end = "{~2|4|A|Q}"

Your opponent has won. He has four cards in his hand and he has chosen: {story_end}.
-> next5

== Won5
~win++
You have four cards in your hand and you chose:

* 2 {set_end(2)} 
->next5
* 4 {set_end(4)} 
->next5
* A {set_end("A")} 
->next5
* Q {set_end("Q")} 
->next5

==function set_end(x)
~ story_end = x

== next5
+[End] -> End

== End
You retrieve your memory:

{setting}
{character}
{story_start}
{story_conflict}
{story_end}

-> END








