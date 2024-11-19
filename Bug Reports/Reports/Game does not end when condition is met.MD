# Debugging Process Document

![Game does not end!](../Images/Game%20does%20not%20end%20when%20win%20condition%20is%20met.png)

## 1. Problem Identification

Issue Summary: Game does not end when player reveal all the clean cells.

Environment Details: Editor, Window64 shipped product.

Impact Assessment: Prevent player from ending the game.

## 2. Reproduction Steps

Steps to Reproduce: List each step needed to replicate the issue. Be as specific as possible, like:

1. Click cells that are not bombs until there is none left.

Expected Outcome: Game won text should be displayed. And player should not be able to continue the game.

Actual Outcome: Player can continue the game but cannot end it. Leaving player in hard-stuck condition.

## 3. Investigation and Analysis

Initial Hypothesis: Game won event is not called.

Testing the Hypothesis: Going to code that is responsible to check if game win or lose.

Example Test: Look for code that call the event.

Gathering Logs and Data: None

Tools Used: Visual Studio IDE or any text editor.

## 4. Resolution

Root Cause Identified: Function for checking is called but the invokation is not written into code.

Solution: Write the invokation into code

Code Changes: MineSweeperController.cs -> CheckIfBomb()

Testing the Fix: Reproduce the steps 2.

## 5. Documentation and Review

Solution Summary: Write the code to invoke event.

Follow-Up Action: Adding automated tests if possible. Try [rubber-duck](https://en.wikipedia.org/wiki/Rubber_duck_debugging) method to self-review the code.

Peer Review: Not applicable, solo development.

## 6. Post-Mortem and Improvement Suggestions

Lessons Learned: Don't forget to write down the code. You may do phantom-coding.

Preventive Measures: Self-review and automate testing.

Suggestions for Debugging Process Improvement: Sometime, it is a simple thing we overlook. Goes from top to bottom and keep narrowing it down.
