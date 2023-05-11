INCLUDE ../../DevScenes/FredrikScene/Dialogue/GlobalVariables.ink


{ qabil_quest_finished: -> finishQuest }

{ qabil_first: -> main }

{ qabil_accept: -> comebackAccepted | -> comebackDecline }

=== main ===

 ~ qabil_first = false
 
A thousand curses upon that foul feline fool! Where did he put it?!  #speaker:Qabil #portrait:mentor #layout:right

Can I help you with something, Qabil? #speaker:Nim #portrait:mentor #layout:left

Oh, greetings Nim.  #speaker:Qabil #portrait:mentor #layout:right

I'm looking for my abacus, my brother Habil used it earlier to... I don't know, count sheep before his nap or something!  #speaker:Qabil #portrait:mentor #layout:right

Now I can't find the blasted thing!... 
Say, you're good at tracking down stuff! How bout you lend me a hand, eh? I'll give you a fine discount on my wares.  #speaker:Qabil #portrait:mentor #layout:right

* [Yes]

Sure, I'll try to find your abacus. #speaker:Nim #portrait:mentor #layout:left 

-> acceptQuest

* [No]

Maybe later, I'm a little busy right now #speaker:Nim #portrait:mentor #layout:left 

Well, get back to me when you have the time!  #speaker:Qabil #portrait:mentor #layout:right

-> END

=== comebackAccepted ===
The abacus should be around the camp somewhere. Just imagine the profit I'm losing over this!  #speaker:Qabil #portrait:mentor #layout:right

-> END

=== comebackDecline ===
Finally, have you decided to help me?  #speaker:Qabil #portrait:mentor #layout:right

* [Yes]

Yes, let's find that abacus #speaker:Nim #portrait:mentor #layout:left 

-> acceptQuest

* [No]

Sorry, I still don't have the time! #speaker:Nim #portrait:mentor #layout:left 

-> END

=== acceptQuest ===
~ qabil_accept = true 

May fortune smile upon you, Nim! I think the abacus should be somewhere around camp. #speaker:Qabil #portrait:mentor #layout:right

I will try to find it for you, Qabil. #speaker:Nim #portrait:mentor #layout:left 

-> END

=== finishQuest ===
Blessings and fortunes upon you, my dear Nim! Now I can accurately calculate what my brother Habil owes me from the last time i paid for his meal. #speaker:Qabil #portrait:mentor #layout:right

That scoundrel will pay me back! #speaker:Qabil #portrait:mentor #layout:right 

-> END