# Code Review from P'Kwang 17/11/24

- State pattern transition is a little strange
- If you have state for cell, why not do controller as well?
- Default variables in places where they would be overwritten can cause confusion.
- Personally, why there is intersection between controller and .Net code. They have some duplication
- Hashset with low amount of elements can be somewhat overkill as dictionary can be used and it is more common to programmers.
- If unityevent won't be used on inspector, event or delegate would be more prefreable. Even more, if there is only one subscriber, just use call back action.
- Be careful of cyclic dependency.
- In mobile platform, be mindful when creating and destroying object. It can prevent you from getting published as it fail qualitification.
- Overall is ok.
- Naming convention is somewhat confusing.
- Get some art from open game art. The game looks pretty unrefined at the moment.
