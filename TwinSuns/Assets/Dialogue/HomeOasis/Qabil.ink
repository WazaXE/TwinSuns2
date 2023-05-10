INCLUDE ../../DevScenes/FredrikScene/Dialogue/GlobalVariables.ink

 { MQ2B_Oasis_Qabil_quest_finished: -> finishQuest }
 
 { MQ2B_Oasis_Qabil_first: -> main }
 
 { MQ2B_Oasis_Qabil_accept: -> comebackAccepted | -> comebackDecline }
 
 
 === main === 
 
 Nim! Just the person I need. #speaker:Qabil #portrait:mentor #layout:right
 
 Greetings Qabil, Turum mentioned that you needed help? #speaker:Nim #portrait:mentor #layout:left
 
 I passed this Oasis last year with my brother. As he was mining metals in the cave to the north, I took the opportunity to hide some, ahem, retirement funds there. #speaker:Qabil #portrait:mentor #layout:right
 
 * [Yes]

 Alright, I'll get your hidden dinars for you.  #speaker:Nim #portrait:mentor #layout:right 

-> acceptQuest

* [No]

I don't really have time for that right now. #speaker:Nim #portrait:mentor #layout:right 

B-But...My dinars?  #speaker:Qabil #portrait:mentor #layout:right

 -> END
 
 === comebackAccepted === 

Have you found all 4 of the escaped animals yet? #speaker:Kulan #portrait:mentor #layout:right 

-> END

=== comebackDecline ===

Did you get my dinars yet? They're in the cave to north #speaker:Qabil #portrait:mentor #layout:right

* [Yes]

Yes! #speaker:Nim #portrait:mentor #layout:right 

-> acceptQuest

* [No]

No, not yet. #speaker:Nim #portrait:mentor #layout:right 

-> END

=== acceptQuest === 
~MQ2B_Oasis_Qabil_accept = true 

Great! I'll teach you the way us merchants use dinars to acquire goods and services! #speaker:Qabil #portrait:mentor #layout:right

Sounds good, Qabil #speaker:Nim #portrait:mentor #layout:right 

-> END

=== finishQuest ===

Most excellent! Here, have some dinars for yourself. Now if you wanna learn how to spend them, talk to me and I will teach you! Hehehe... #speaker:Qabil #portrait:mentor #layout:right

-> END