INCLUDE ../../DevScenes/FredrikScene/Dialogue/GlobalVariables.ink

 { MQ2C_Oasis_Kulan_quest_finished: -> finishQuest }
 
 { MQ2C_Oasis_Kulan_first: -> main }
 
 { MQ2C_Oasis_Kulan_accept: -> comebackAccepted | -> comebackDecline }


=== main ===

May the Jinns bless your path, Nim! You are just the one I need right now. #speaker:Kulan #portrait:mentor #layout:right 

Oh, what do you need Kulan? #speaker:Nim #portrait:mentor #layout:left

Some of my animals have escaped their enclosures! I need you to pick them up and throw them back into the enclosure, quickly! #speaker:Kulan #portrait:mentor #layout:right 

* [Yes]

 I'm on it!  #speaker:Nim #portrait:mentor #layout:right 

-> acceptQuest

* [No]

Can't help you right now. #speaker:Nim #portrait:mentor #layout:right 

Well get back to me as soon as you can help! #speaker:Kulan #portrait:mentor #layout:right

-> END 

=== comebackAccepted === 

Have you found all 4 of the escaped animals yet? #speaker:Kulan #portrait:mentor #layout:right 

-> END

=== comebackDecline ===

Are you ready to help me gather the escaped animals? #speaker:Kulan #portrait:mentor #layout:right 

* [Yes]

Yes, let's do this! #speaker:Nim #portrait:mentor #layout:right 

-> acceptQuest

* [No]

Sorry, not yet! #speaker:Nim #portrait:mentor #layout:right 

-> END

=== acceptQuest === 
~MQ2C_Oasis_Kulan_accept = true 

Thank the Jinns! There's 4 of them, and they ran to the south of the settlement. #speaker:Kulan #portrait:mentor #layout:right 

-> END

=== finishQuest ===

Oh thank you so much Nim! I don't know what I would have done without you. As soon as the camels have rested, I'll show you how to travel to other places in the desert! #speaker:Kulan #portrait:mentor #layout:right 

-> END