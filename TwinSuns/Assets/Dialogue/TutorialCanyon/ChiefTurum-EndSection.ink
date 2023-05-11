INCLUDE ../../DevScenes/FredrikScene/Dialogue/GlobalVariables.ink

//När nim rapporterar till chief turum, signalerar att sectionen är slut.


{ Tutorial_EndSection: -> main | -> accepted }

-> fallback

===main===

~ Tutorial_EndSection = false

Chief, I have finished helping our people now.  #speaker:Nim #portrait:mentor #layout:left

Oh you have? Thank you Nim, We are leaving early tomorrow so you should get ready to sleep so we can rise nice and early tomorrow. #speaker:Chief Turum #portrait:mentor #layout:right

Ok Chief, I will see you tomorrow. #speaker:Nim #portrait:mentor #layout:left

-> END

===accepted=== 

Nim, you have helped enough already. You should take it easy and rest in one of the tents now.  #speaker:Chief Turum #portrait:mentor #layout:right 

-> END


=== fallback ===

Please go and help the others in the camp Nim. They are gonna need your help getting the camp ready #speaker:Chief Turum #portrait:mentor #layout:right 

-> END