# Debugging Process Document

![Cell color is not resetted](../Images/Cells%20color%20does%20not%20match%20with%20its%20state.png "San Juan Mountains")

## 1. Problem Identification

Issue Summary: Cell color does not match its state. For example, cell that is not bomb is colored Red.

Environment Details: Editor, Window64 shipped product.

Impact Assessment: Confuse player if they have clicked the bomb or not.

## 2. Reproduction Steps

Steps to Reproduce: List each step needed to replicate the issue. Be as specific as possible, like:

1. Flag a bomb cell.
2. Click other bomb cell to fail the game.
3. Reset the game.
4. Click at previously flagged bomb cell.

Expected Outcome: The cell should be in grey/white color.

Actual Outcome: The cell is red.

## 3. Investigation and Analysis

Initial Hypothesis: Color changing function is not called.

Testing the Hypothesis: Adding break point for function that is responsible for changing cell color.

Example Test: Check if break point is hit.

Gathering Logs and Data: Mine Cell Property at breakpoint

Tools Used: Visual Studio breakpoint and debugger.

## 4. Resolution

Root Cause Identified: Function is called but color variable is set to red in that context.

Solution: Change from color red to white in that specific context.

Code Changes: RevealedMineCell.cs -> Implementation of IMineCellState,Exit()

Testing the Fix: Reproduce the steps 2.

## 5. Documentation and Review

Solution Summary: Refactor color changing function.

Follow-Up Action: Adding automated tests if possible. Try [rubber-duck](https://en.wikipedia.org/wiki/Rubber_duck_debugging) method to self-review the code.

Peer Review: Not applicable, solo development.

## 6. Post-Mortem and Improvement Suggestions

Lessons Learned: Debugger is your friend. Be careful of .Net C# garbage collection cycle.

Preventive Measures: Adding unity unit test for changing color.

Suggestions for Debugging Process Improvement: Use debugger, conditional breakpoint or other breakpoint as well if possible.
