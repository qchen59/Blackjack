VAR setting = ""
VAR character = ""
VAR story_start = ""
VAR setting_related_choices = ""
VAR story_conflict = ""
VAR story_end = ""
VAR win = 0
VAR story = ""
VAR random_choice = 0 
VAR born = ""

VAR trivia_1 = "In which city were the 1992 Summer Olympics held?"
VAR trivia_1_1 = "Atlanta"
VAR trivia_1_2 = "Barcelona"    // Correct
VAR trivia_1_3 = "Las Vegas"
VAR trivia_1_4 = "Sydney"

VAR trivia_2 = "Approximately how many times does a smartphone user touch their screen per day?"
VAR trivia_2_1 = "100"      
VAR trivia_2_2 = "1150"    
VAR trivia_2_3 = "2700"         // Correct
VAR trivia_2_4 = "7000"


VAR trivia_3 = "How many stars does the Australian flag have?"
VAR trivia_3_1 = "4"      
VAR trivia_3_2 = "5"            // Correct
VAR trivia_3_3 = "7"         
VAR trivia_3_4 = "9"


VAR trivia_4 = "How many seconds are in a day? YOU CAN'T USE A CALCULATOR!"
VAR trivia_4_1 = "86400"      // Correct
VAR trivia_4_2 = "84400"            
VAR trivia_4_3 = "84600"         
VAR trivia_4_4 = "64600"


VAR trivia_5 = "In what year was McDonald's founded?"
VAR trivia_5_1 = "1895"      
VAR trivia_5_2 = "1915"            
VAR trivia_5_3 = "1955"             // Correct
VAR trivia_5_4 = "1965"

VAR r1_1 = "You were born in Ecuador, the youngest of 13 siblings. "
VAR r1_2 = "You were born in Egypt, in a family of 6. "
VAR r1_3 = "You were born in New York, a secret bastard child of Donald Trump. "
VAR r1_4 = "You were born in an airplane while it was flying above the Atlantic Ocean. "

VAR r2_1 = "You are a doctor in your late thirties, with a specialization in colonoscopy. "
VAR r2_2 = "You are a lift operator in a building in Manhattan. "
VAR r2_3 = "You are bodyguard for Barack Obama. "
VAR r2_4 = "You play a clown on a TV show, watched by millions around the world. "

VAR r3_1 = "Your right hand was cut in an accident ten years ago. "
VAR r3_2 = "You lost all your money in a gambling addiction five years ago. "
VAR r3_3 = "You won a lottery worth 100 million dollars three years ago, but lost your sense of hearing the next day. "


VAR r4_1 = "Unbeknownst to everyone, you have discovered the secret to immortality. "
VAR r4_2 = "Unbeknownst to everyone, you have invented the true general artificial intelligence. "
VAR r4_3 = "Unbeknownst to everyone, you have invented a time travelling machine that can take you to future. "


You wake up.
You don't remember who you are and where you are! But, there is a man nearby wearing a Gucci basketball hat holding a bunch of trivia cards.

+[Ask the man where you are.] -> askwhere
+[Ask the man who he is.] -> askwho
== askwho
"----------------------"
"I am an evil genius, holding all your memory! I can also ALTER your PAST!"
+[How?!] -> askhow

== askwhere
"----------------------"
"Hehe, I won't tell you that. 
But I will tell you that I am an evil genius, holding all your memory. I can also ALTER your PAST!"
+[How?!] -> askhow

== askhow
"----------------------"
"Good question!", says the man as he shows you the trivia cards.
"Answer the questions on these cards for me. If you get them right, you will be able to alter your past in any way you like!"
"If you get them wrong, I will choose your past for you >:D "

+[Play the game] -> Round1
+[Ignore the offer] -> Ignore

==function add_story(x)
~ story = story + x

== Ignore
"----------------------"
The man leaves. You stay at the same place for another eighty years, never learning about your past, and never able to leave the room, before eventually dying. 
-> END

+[Round 1] -> Round1
== Round1
"----------------------"
"Okay, good luck!", says the man. "Here is your first question."
{trivia_1}
+[{trivia_1_1}] -> Lost1
+[{trivia_1_2}] -> Won1
+[{trivia_1_3}] -> Lost1
+[{trivia_1_4}] -> Lost1

== Lost1
~ random_choice = RANDOM(1,4)
{ random_choice:
    - 1: {add_story(r1_1)}
    - 2: {add_story(r1_2)}
    - 3: {add_story(r1_3)}
    - 4: {add_story(r1_4)}
}
"----------------------"
\*Evil laugh*.
"Incorrect answer! Now I get to choose one of your past memories."
+[Check your past] -> next1

== Won1
"----------------------"
"Nice, I didn't expect you to be good at this", says the man in a \*passive agressive\* tone.
"Go ahead and select from one of these memories, and they will be yours."

The man recites four options.

+[{r1_1}] {add_story(r1_1)} ->next1
+[{r1_2}] {add_story(r1_2)} ->next1
+[{r1_3}] {add_story(r1_3)} ->next1
+[{r1_4}] {add_story(r1_4)} ->next1

== next1
"----------------------"
"Okay, here you go. Here is the past that you have created so far for yourself", says the man, and then starts reciting.
\***
{story}
\***

"Alright, get ready for the next question. It will decide who you are!", says the man.


+[Next question] -> Round2


== Round2
"----------------------"
"Here is the question. Think it through!"
{trivia_2}
+[{trivia_2_1}] -> Lost2
+[{trivia_2_2}] -> Lost2
+[{trivia_2_3}] -> Won2
+[{trivia_2_4}] -> Lost2

== Lost2
~ random_choice = RANDOM(1,4)
{ random_choice:
    - 1: {add_story(r2_1)}
    - 2: {add_story(r2_2)}
    - 3: {add_story(r2_3)}
    - 4: {add_story(r2_4)}
}
"----------------------"
\*Evil laugh*.
"Incorrect answer! Now I get to choose one of your past memories."
+[Check your past] -> next2

== Won2
"----------------------"
"Okay, gotta admit, that was a nice answer."
"Go ahead and select from one of these memories, and they will be yours."

The man recites four options.

+[{r2_1}] {add_story(r2_1)} ->next2
+[{r2_2}] {add_story(r2_2)} ->next2
+[{r2_3}] {add_story(r2_3)} ->next2
+[{r2_4}] {add_story(r2_4)} ->next2

== next2
"----------------------"
"Okay, here you go. Here is the past that you have created so far for yourself", says the man, and then starts reciting.
\***
{story}
\***

"This next is question is not easy!", says the man in a teasing tone. 
+[Next question] -> Round3


== Round3
"----------------------"
The man recites the question.
{trivia_3}
+[{trivia_3_1}] -> Lost3
+[{trivia_3_2}] -> Won3
+[{trivia_3_3}] -> Lost3
+[{trivia_3_4}] -> Lost3

== Lost3
~ random_choice = RANDOM(1,3)
{ random_choice:
    - 1: {add_story(r3_1)}
    - 2: {add_story(r3_2)}
    - 3: {add_story(r3_3)}
}
"----------------------"
\*Evil laugh*.
"Incorrect answer! Now I get to choose one of your past memories."
+[Check your past] -> next3

== Won3
"----------------------"
"Correct. As much I hate saying it, I have got to give you credit for this!", says the man.
"Go ahead and select from one of these memories, and they will be yours."

+[{r3_1}] {add_story(r3_1)} ->next3
+[{r3_2}] {add_story(r3_2)} ->next3
+[{r3_3}] {add_story(r3_3)} ->next3

== next3
"----------------------"
"Okay, here you go. Here is the past that you have created so far for yourself", says the man, and then starts reciting.
\***
{story}
\***

"Ready for next question?", asks the man. 
+[Next question] -> Round4


== Round4
"----------------------"
{trivia_4}
+[{trivia_4_1}] -> Won4
+[{trivia_4_2}] -> Lost4
+[{trivia_4_3}] -> Lost4
+[{trivia_4_4}] -> Lost4

== Lost4
~ random_choice = RANDOM(1,3)
{ random_choice:
    - 1: {add_story(r4_1)}
    - 2: {add_story(r4_2)}
    - 3: {add_story(r4_3)}
}
"----------------------"
\*Evil laugh*.
"Incorrect answer! Now I get to choose one of your past memories."
+[Check your past] -> next4

== Won4
"----------------------"
"Correct. I didn't expect you to know this :\\", says the man.
"Go ahead and select from one of these memories, and they will be yours."

+[{r4_1}] {add_story(r4_1)} ->next4
+[{r4_2}] {add_story(r4_2)} ->next4
+[{r4_3}] {add_story(r4_3)} ->next4

== next4
"----------------------"
"Okay, here you go. Here is the past that you have created so far for yourself", says the man, and then starts reciting.
\***
{story}
\***

The man is now silent.

+ [Ask about the next question] -> asknext
+ [Ask for a permission to leave] -> askleave

== asknext
"Uhmm", nods the man, "I don't have any more questions left."
The room lights up.
The man signals towards the door asking you to leave.
As you approach the door, he stops you for a moment.
"Remember: you can never tell any one about this!".


-> END

== askleave
"----------------------"
"How dare you ask that question?", shouts the man.
The man leaves with you locked in the room. 
You stay at the same place for another eighty years, never able to leave the room, before eventually dying. 
-> END









