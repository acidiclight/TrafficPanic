# Traffic Panic!

"Traffic Panic!" is one of my college final projects for a Unity game development course. It's based off the idea of a LittleBigPlanet level of the same name, which was based off an old mobile game by...you  guessed it, the same name.

The game is simple. You're given a birds' eye view of a traffic intersection of two one-way roads. Cars are driving down these roads and it's your job to control t he intersection's traffic light so that  nobody crashes. Don't cause a  pileup!

Score is given  for every car that safely travels  north-bound  through  the  intersection. You can only control the light for thenorth-bound road. The game   ends as  soon as any car crashes, so be careful!

## Controls

If you  have a keyboard,  and you know how to press the Spacebar, then you know the controls. Pressing Space toggles the traffic light between red and green.

## Build instructions

 - You'll need **Unity Hub,** a Unity license (personal is fine), and **Unity 2020.3.17f1.** I trust that you know how to install  that.
 - Clone the repository with **Git**, or download it as a ZIP **and extract it somewhere.**
 - Open the project in Unity.
 - If you aren't already in the **Bootstrap** scene, please open that scene. It's  in `/Scenes/Bootstrap`.
 - You can play the game in-editor, or you can choose to build it as standalone. I haven't set up build indexes yet though.

### I want to play a standalone build

First of all, why. There are so many better games, even written by me, that you could be trying to compile yourself.  I don't plan to actually release this so it's really  not set up  to be properly built.

WITH  THAT IN MIND, I  can't control what you do - but I can tell you how to do it yourself.

 - Make sure that you set up build indexes for both the **Bootstrap** and **TheIntersection** scenes. Bootstrap **MUST** be Index 0, likewise, TheIntersection **MUST** be Index 1. See `SceneNames.cs` for why.
 - You may run into compile errors because of editor-only code being used. If you do, then I apologize, I haven't gone through and stripped anything I may have added by accident using code-completion.

## Missing stuff/future plans

1. **Art** - I originally agreed to have DeRose, the lead modeller of Restitched, help out with car models and other art assets that I can't do on my own. But we Restitched folk are really busy with...Restitched, and so I didn't want to bog the team down on one of my personal projects. That being said, maybe I may come back in the future and art-pass this game. For now though, it's all just a bunch of cubes and default Unity UI.
2. **Leaderboards** - There's  a high-score  feature in the game, but it gets wiped  when you close the game. Eventually I'd like to set up a local leaderboard system, similar to old arcade games.
3. **Pedestrian Carnage!** - I wanted to add a feature where pedestrians would cross the street occasionally. Hitting them would cause a negative point penalty.
4. **Police** - In the LBP level this is based off of, cars would  occasionally stop in mid-traffic. A police car would then  spawn in to chase the rogue car away. But this is too complex of a system for me to write for a college project, so that's missing.
5. **Multiple levels** - There's only one level in the game, but it wouldn't be too hard to build out new levels in the future. Maybe even ones with  multiple intersections?
6. **Different vehicles** -  There's a car pool system in the game - for randomly spawning different vehicles with different attributes. But  there's only one "cubic-mobile" car in the game. Eventually  I'd like to add new vehicle types.

## Is this affiliated with Trixel Creative?

ABSOLUTELY not.  Like I said above, this is a college project. That being said,  the LBP level that this game is based off of, was made  by Trixel. And I am a Restitched project lead. So  you're close...but...not  quite!  :)