# Project Wanderer

# What is this #
The C# scripts that I have either modified or worte myself for my stealth based game called Project Wanderer.

# Running the game #
In order to play the game, find the zipped .exe file which is the current build of the game. Downlaod and unzip the file to begin the demo.

# How to play #
The game has basic WASD controllers and works from a 3rd person perspective. Additionally, holding down C will put the character into a crouch animation and allow the player to crouch walk with C held down in order to void enemy sight. 

The objective of the game is simple, sneak past the thugs on the highway and make it to the escape helicopter at the other end.

# How it is different #
Originally, this game began as a lab assignment for my Artifical Intelligence class, however it evolved into my final project for the class with my own added feature. When you are spotted, the enemy will chase you down and try to capture you. If you break the line of sight, the enemy will remember where he last saw you and create a new randomized patrol route, based off that last sighted position in a 10 by 10 radius that us unknown to the player.

# Planned future work #
In the future, I plan on fixing a few bugs that occasionally come up, such as a new waypoint being formed inside if an obstable which creates a problem for the enemy since it cannot reach it. I will try to set a condition, that if a waypoint cannot be reached in a certain amount of time, it will be removed from the list of waypoints so the enemy is not stuck in one place.

Additionally, I will be working on a way to remove the old waypoints that are no longer being used in the scene as to optimize the performance of the game.
