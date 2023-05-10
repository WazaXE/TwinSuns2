INCLUDE ../../DevScenes/FredrikScene/Dialogue/GlobalVariables.ink



{ chief_quest_finished: -> finishQuest }

{ chief_first: -> main | -> comebackAccepted }

=== main ===

~ chief_first = false
 
Qabil, be careful with that thing... Oh Nim, good you're here! #speaker:Chief Turum #portrait:mentor #layout:right

Do you need my help? #speaker:Nim #portrait:mentor #layout:left

Yes, we need to clear up a place where we can stay the night. #speaker:Chief Turum #portrait:mentor #layout:right

Can you scout further ahead and see if you can find a suitable place to set up the camp? #speaker:Chief Turum #portrait:mentor #layout:right

* [Yes]

Ofcourse I can! #speaker:Nim #portrait:mentor #layout:left

~ chief_accept = true 

Good! Please hurry, the storm is starting to pick up speed. #speaker:Chief Turum #portrait:mentor #layout:right

-> END

* [No]

Can't you ask Habil or Qabil? #speaker:Nim #portrait:mentor #layout:left

~ chief_accept = true 

Those two have other chores that they must do right now. Talk to me again when a camp site is cleared. #speaker:Chief Turum #portrait:mentor #layout:right

-> END

=== comebackAccepted ===


 Nim, we don't have all the time in the world. #speaker:Chief Turum #portrait:mentor #layout:right

We can't place out our tents if the area is not secure. #speaker:Chief Turum #portrait:mentor #layout:right

-> END

=== finishQuest ===

Great work! Now if you will excuse me... #speaker:Chief Turum #portrait:mentor #layout:right

All right people, let's move it! #speaker:Chief Turum #portrait:mentor #layout:right

-> END