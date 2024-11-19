# MineSweeper Game Development Showcase Overview Document

## Purpose

In order to land myself a job, I created this project to showcase my skills in developing a video game with Unity.
I chose to develop MineSweeper, MineSweeper, as it is a classic game with simple and easy-to-understand rules.

## Contents

Skills to showcase include

1. Documentation -> I primarily document the code itself to ensure clarity and ease of collaboration. While I typically prefer using tools like Jira and Confluence for broader project documentation, this project focuses on code documentation.
2. Unity UI Toolkit -> I used Unity UI Toolkit mainly for the main menu. Although it’s a small part of the project, it demonstrates my ability to implement the latest UI technology in Unity
3. Design Patterns -> I applied the Visitor, State, Singleton, and Observer design patterns to solve common problems in the game development process, improving maintainability and flexibility.
4. S.O.L.I.D. principles -> I self-review my code using the S.O.L.I.D. principles to ensure high-quality software architecture and maintainability.
5. .Net & Unity C# -> MonoBehaviour is more performance-consuming compared to plain .NET C#. I coded the State pattern in plain C# to demonstrate a more performance-efficient approach before applying it in Unity C#
6. Building Game with Unity Command Line Interface -> I interested in making CI/CD and automation process. In this project, I wrote a small build script to fulfill my curiosity.

## Audience

This project is primarily aimed at programmers due to its depth in technical subjects, but it can also appeal to hiring managers looking for a developer with strong coding and design principles

## Shoutout

[P'Kwang] (https://www.linkedin.com/in/kwangz-santad-4a601197/), a senior I deeply respect, whose insights are always full of valuable experience

[Meji], a friend of mine, also an UX/UI designer, that playtest and helped me to find bugs.

[Ice], another friend of mine, that also playtest and bug reports to me.

[Nub], a mobile app programmer, also a game programmer, that playtest and review my game.

[P'O], a playtester that I regularly work with as an IELTs invigilator.

## What I learn

1. Manage your garbage collection wisely. Specifically, your .Net C# that cycle is not garbaged collected with monobehavior. Or end up leaking your memory

2. Weak references are your friend when you want to have static variable but also want it to be GC(garbage collected) with mono

3. There are no perfect code. There are only trades-off.

4. Playtesters may not know programming but they surely help you catching unexpected bugs. Also very good feedback.

5. Regularly update documents. Do it while it samll. You don't have to write a lot. You just mark down importants thoughts.

6. Unity CLI is somewhat lacking in documentations but community can help.

7. Scripting definition symbol is so good in debugging and testing in different player environment
