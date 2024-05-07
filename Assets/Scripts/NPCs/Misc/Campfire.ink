INCLUDE ../Globals.ink

{ gathered == "": -> FirstInt }
{ gathered == "no": -> FurtherInt("no") }
{ gathered == "yes": -> Completed }
=== FirstInt ===
[...]
[This seems to have been ___]
[Can't start a fire without anything to start a fire with]
-> FurtherInt("no")

=== FurtherInt(task) ===
[Gather some firewood]
~ gathered = task
-> END

=== Completed ===
[You've gathered all 5 firewood]
-> END