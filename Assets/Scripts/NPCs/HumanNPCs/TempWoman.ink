INCLUDE ../Globals.ink


-> Main
=== Main ===
May you fix my house wires?
  * [Yes]
     ~ playPuzzle("puzzle1")
     ty #answer: Yes
     -> Task
  * [No]
     ... #answer: No
     -> Task
     
=== Task ===
-> END