INCLUDE ../Globals.ink

{ answered == "": -> Main }
{ answered == "yes": -> in_progress }
{ answered == "no": -> ChangeOfMind }
=== Main ===
//1
[The woman seems wary of your presence].
//2
What could you possibly want with me?
//3
[You explain that you're conflicted with your morality and existence].
//4
As much as I ponder, with all due respect I have more to worry about than first world problems. Especially when you caused these problems.
//5
[You ask what problems they have].
//6
Well I have many, but for one the lights in my house are out. There's only one possible cause for this and its the wires in the singular eletric tower.
//7
[You explain that tower is quite old and could use some tinkering]
-> Main_Question

=== Main_Question ===
Well if you're so knowlegeable may you fix my house wires?
  * [Yes]
    Maybe they haven't got to you yet...
     -> Task("yes")
  * [No]
     ... 
     -> no
     
 === ChangeOfMind ===
     You decide to change your mind?
     -> Main_Question
     
=== Task(answer) ===
[Fix the wires by the Electric Tower].
~ answered = answer
-> END

=== no ===
~ answered = "no"
-> END

=== in_progress ===
You already decided to say {answered}.
[Fix the wires by the Electric Tower].
-> END



