INCLUDE GlobalVariables.ink

{ first_dialogue: -> main | -> second }

=== main ===

~ first_dialogue = false

Have you <i>never</i> seen a temple before? #speaker:Mentor #portrait:mentor #layout:left

Let me think #speaker:Nim #portrait:player #layout:right

* No I have already

Aight FAM #speaker:Mentor #portrait:mentor #layout:left

* [A what?]

Bruh bruh bing bong

** [I said a what]
"Be careful, temples are full of dangers" #speaker:Mentor #portrait:mentor #layout:left

- Great conversation

    -> END

=== second ===

You have already had this dialogue #speaker:Mentor #portrait:mentor #layout:left

-> END