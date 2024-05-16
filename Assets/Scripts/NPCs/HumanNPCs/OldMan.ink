INCLUDE ../Globals.ink

{ collectTask == "": -> Main }
{ collectTask == "yes": -> in_progress }
{ collectTask == "no": -> Main_Question}
=== Main ===
//1
You remind me of me.

//2
[?]

//3
Say, you help me out and I can tell you a little something boyo.

//4
I've been trying to do something for the community for a while

//5
But with old age and all...
->Main_Question

=== Main_Question ===
Do you accept?
*[Yes]
Thank you boyo.
-> Task("yes")
*[No]
Alright boyo. Tell me if you ever change your mind.
->Saidno

=== Task(collected) ===
[Collect 5 firewood.]
~ collectTask = collected
-> END

=== Saidno ===
~ collectTask = "no"
->END

=== in_progress ===
[Collect 5 firewood.]
->END