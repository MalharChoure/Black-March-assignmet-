# Black March assignmet 
 3D Tactics Game


It includes 4 scenes 

home scene
![image](https://github.com/user-attachments/assets/2408610d-4e14-4ef0-a87a-00d4c8a382bf)

Ingame Editor Scene
![image](https://github.com/user-attachments/assets/d034528d-5c77-47e1-b7fa-bc64ed15151d)

Save loader
![image](https://github.com/user-attachments/assets/4ef8f081-b445-4cd5-bace-05f3850f74dd)

Play scene
![image](https://github.com/user-attachments/assets/3b8461a6-4245-434a-8927-135ddc99e71d)

You play as orange and can move anywhere.
The purple ones are enemies.
You cannot walk on water or the red obstacles neither can they.



/*
 * 
 This project uses 2022.3.11f1
  
 This is a read me file for clarification

all private variables and functions begin with an underscore 

any public member begins with capital or small letter directly.

any local variable also begins small letter.
 
 */

/*
 Since my editor and game are two different scenes and scriptable objects cannot be passed through scenes while saving data without using setDirty() which
is an UnityEditor method. The build of this game does not work.
 */

/*
Playing the game:

Step 1: Edit a map of choice.

Step 2: Save the map.

Step 3: Load the save in play mode.

Step 4: First place the player with left click.

Step 5: Place the enemies with left click.

Step 6: rigth click to move player. Then it will switch to enemy. Then back to player and the next enemy.
 */
