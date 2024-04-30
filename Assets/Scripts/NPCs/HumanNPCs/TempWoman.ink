INCLUDE ../Globals.ink

{ answered == "": -> Main | -> in_progress }

=== Main ===
May you fix my house wires?
  * [Yes]
     ty 
     -> Task("yes")
  * [No]
     ... 
     -> said_no
     
=== Task(answer) ===
Fix the wires by the Electric Tower.
~ answered = answer
-> END

=== in_progress ===
You already decided to say {answered}.
Fix the wires by the Electric Tower.
-> END

=== said_no ===
-> END

