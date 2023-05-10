INCLUDE ../../DevScenes/FredrikScene/Dialogue/GlobalVariables.ink


{ bolani_quest_finished: -> finishQuest }

{ bolani_first: -> main }

{ bolani_accept: -> comebackAccepted | -> comebackDecline }

=== main ===

~ bolani_first = false

Ah! May the Jinns guide you, young Nim. I could use your help for our dinner this evening.  #speaker:Bolani #portrait:mentor #layout:right

Of course Bolani, what is it that I can do for you? #speaker:Nim #portrait:mentor #layout:left

It seems like our stockpile of Cacti meat is running out. #speaker:Bolani #portrait:mentor #layout:right

Cacti meat is a very nutritious ingredient that we can use in many dishes so it would be smart of us to resupply it while we still have the chance. #speaker:Bolani #portrait:mentor #layout:right

Could you go and get some for us? #speaker:Bolani #portrait:mentor #layout:right

* [Yes]

-> acceptQuest

* [No]

I will get back to you, I promised Chief Turum that I would speak to the people in camp. #speaker:Nim #portrait:mentor #layout:left


Understandable young Nim, let me know if you happen to have some time later to help me. #speaker:Bolani #portrait:mentor #layout:right

-> END

=== comebackAccepted ===

The Cacti should be somewhere around to the south of here. Don’t forget that I need 5 of them. #speaker:Bolani #portrait:mentor #layout:right

-> END

=== comebackDecline ===

Ah Nim, are you able to help me harvest Cacti now? #speaker:Bolani #portrait:mentor #layout:right

* [Yes]

-> acceptQuest

* [NO]

-> END

=== acceptQuest ===

~ bolani_accept = true

 Yes, I will go and see if I can find any for you. #speaker:Nim #portrait:mentor #layout:left

Oh thank you so much Nim, I think I saw some Cacti to the south of here. Harvesting 5 of them should be enough to last us for a while. #speaker:Bolani #portrait:mentor #layout:right

I will be back once I have gotten the Cacti meat. #speaker:Nim #portrait:mentor #layout:left

May the Jinns bless your path, young Nim. #speaker:Bolani #portrait:mentor #layout:right

-> END

=== finishQuest ===

Oh thank you so much, this is precisely what I needed. Now let me cook up a hearty meal for you and the others. #speaker:Bolani #portrait:mentor #layout:right

Maybe someone else still needs help around the camp? #speaker:Bolani #portrait:mentor #layout:right

-> END