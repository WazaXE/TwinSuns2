
~ temp dialogue_choice = RANDOM(1,4)

{ dialogue_choice:
- 1: -> main
- 2: -> second
- 3: -> third
- 4: -> forth
- else: -> main
}

=== main === 

The sandy wind rages on, sharp as a storm of daggers… I must wait for it to subside.  #speaker:Nim #portrait:mentor #layout:left

 -> END
 
 === second ===
 
 A sandstorm is deadly to face unprepared. It would be wise to wait for its passing. #speaker:Nim #portrait:mentor #layout:left

 -> END
 
 === third ===
 
 Even the Jinns themselves hide from the dreadful sandstorms. I will have to wait until it passes. #speaker:Nim #portrait:mentor #layout:left
 
 -> END
 
 === forth ===
 
Only a fool would want to go out in a sandstorm. It's better for me to stay here. #speaker:Nim #portrait:mentor #layout:left
 
 -> END