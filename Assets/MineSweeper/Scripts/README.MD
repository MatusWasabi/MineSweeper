# Scripts

They will be sectioned into directories based on the following convention.

- Core -> Pure .Net C# or Unity C# that can be reused in other projects. This include CLI implementation and another Unity Project.
- Gameplay -> Specific scripts that is concrete and couple to this project context specifically.
- Interfaces -> Dedicated to high-level interfaces. Low-level interfaces will be included within the same directory as its implementation
- UI -> Scripts for UIToolkit and general UGUI that can be used in any project.

# Naming Convention

[Source](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)

## Casing Terminology

- Local and Method parameters appear in camelCase
- Class, method names, public fields in PascalCase

## Variable

- Use nouns for variable names
- Prefix Booleans with a verb
- PascalCase for public fields
- camelCase for private and local variable
