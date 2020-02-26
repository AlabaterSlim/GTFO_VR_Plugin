# GTFO_VR_Plugin
A BepInEx GTFO plugin to make GTFO work in VR almost as well as Subnautica VR!

Active trello board (upcoming features and ongoing work) - https://trello.com/b/zSk7bBMS/gtfovr

Requires a BepInEx installation - https://github.com/BepInEx/BepInEx/releases 

Grab the newest version from here! https://github.com/DSprtn/GTFO_VR_Plugin/releases

If you can't get the installation to work, double check with this video - https://www.youtube.com/watch?v=lrx90XxlyfU 
It's up to date up to 02:34.
(Thanks Whisper!)

Try to get used to the game in Non-VR mode first before using! 

## Installation: 

 	1. Download and extract BepInEx into your GTFO game folder (SteamLibrary\steamapps\common\GTFO\) 
	from https://github.com/BepInEx/BepInEx/releases
	
	2. Launch the game once and close it
	
	3. Download the latest version of the plugin from https://github.com/DSprtn/GTFO_VR_Plugin/releases and 
	extract it into the same folder (SteamLibrary\steamapps\common\GTFO\)
	
	4. Make sure 'use desktop game theatre' is off in the properties of GTFO in the steam library 
	(or in general steam settings)
	
	5. Start SteamVR
	
	6. Launch the game from within the library or from within SteamVR and you're in!
	(Ignore the "GTFO does not support VR" warning and/or that it says launch in theatre mode in SteamVR!)
	
	If your controllers don't do anything in-game you might have to setup an input scheme. You can do so under 
	SteamVR -> Settings -> Controllers -> Show old binding UI -> GTFO [Testing]
	
	You should be able to download bindings from there if anyone made them or create them yourself. Remember to set
	an action pose! (Tip works best most of the time)
	
	Note: When you save your binding SteamVR might not grab the latest action poses, in that cases just create 
	another binding, switch to that one and switch back and it will update correctly.
	
## Usage notes:

#### CONFIGURATION 
	
	There are configurable options for:
	-	Experimental performance tweaks 
	-	Left handed mode 
	-	No VR controller mode 
	- 	IRL Crouching detection 
	They can be found in a config file which is created after starting the game at least once with 
	the VR mod installed. It can be found under "GTFO\BepInEx\config\com.github.dsprtn.gtfovr.cfg"

#### PERFORMANCE

	Lower your render resolution and in-game settings, GTFO VR is a BIG resource hog!
	
	If you don't mind small artifacting on lights in exchange for a bit of extra performance
	set light rendering mode to '2' in GTFO\BepInEx\config\com.github.dsprtn.gtfovr.cfg
	
####	MISC ACTIONS
	
	Remember to bind openmenu and openmap too! They work in-game correctly as you'd expect.
	
	Menu and map UI is controlled by the 'movement', 'crouch' (for re-orienting), 'fire' and 'interact' actions.

	Using the 'aim' action toggles UI (gives FPS too!), it doesn't do anything else!
	
####	STEAM_VR DESKTOP 
	
	
	If you'd like to use SteamVR desktop set the game to windowed mode (unless you have multiple monitors) 
	If you 'tab out' with SteamVR desktop remember to tab back in (by clicking on the game icon in the taskbar) 
	to get game sound
	
	
####	TERMINAL
	
	Shortcuts exist as uppercase letters on the virtual keyboard. To use simply, set the keyboard to uppercase 
	and it will autofill the text based on the uppercase letters you type in.
	
	The shortcuts return the following:
	
		case ("L"): 	returns "LIST "
		
		case ("Q"):	returns "QUERY "
		
		case ("P"):	returns "PING "
		
		case ("A"):	returns "AMMOPACK"
		
		case ("T"):	returns "TOOL_REFILL"
		
		case ("M"):	returns "MEDIPACK"
		
		case ("R"):	returns "REACTOR"
		
		case ("V"):	returns "REACTOR_VERIFY "
		

	If you'd like to have custom bindable shortcuts let me know! 
				
## Features:
	Mostly correctly working VR UI and gameplay (also works in multiplayer, with others not having the mod!)
	
	Full SteamVR_Input binding support, you can play with all VR controllers, 
	provided they have enough buttons for all the actions in GTFO!
	
	Full VR controller based aiming (including fancy laserpointer)
	
	Main menu, map UI and terminal working correctly in VR
	
## Known issues: 
	
	Oculus integration seems to be working for at least the Rift S, but if it isn't working for you 
	try to disable controllers in config to play with head aiming and let me know which HMD you have.
	You can disable controllers in GTFO\BepInEx\config\com.github.dsprtn.gtfovr.cfg
	
	In-game HUD is crappy looking --- intel, objectives, ammo info (except in map) 
	or not positioned correctly  --- enemy markings, teammate name/stats (except in map)
	
	Hacking tool minigame isn't rendered correctly for VR

## Want to contribute?

Give me a holler on Discord and I'll bring you up to speed - Spartan#8541 
