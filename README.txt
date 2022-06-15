Let me provide some comments regarding this project.

=== 1. ABOUT THE GIT FLOW ===
As you could see I used only one master branch to develop all features.
I understand that in general such an approach is not good for several reasons and when I develop in a team I use a set of git branches like develop, master, feature, etc.
This time I used only one branch for these 3 reasons:
- fast development
- the project is simple
- only one developer

=== 2. KNOWN BUGS AND ISSUES ===
1. Music does not stop playing after finishing the game and returning to the menu. I didn't have time to fix it.
→ fixed by rearranging the scene structure.
2. When the paddle approaches the border at high speed it can slightly overlap it. I don't know whether it is this project bug or a Unity issue.
→ fixed.
3. There are probably issues with the coding standards.