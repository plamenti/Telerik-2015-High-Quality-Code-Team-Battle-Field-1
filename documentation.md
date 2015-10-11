**Refactoring Documentation for Project “Battle-Field-1”**
------------------------------------------------------

1. Reformated code
2. Change solution name
3. Fix style cop warrnings
4. Renamed ugly named variables
5. Fixed assebly names and default namespaces
6. Extract `RandomNumberGenerator` class
7. Fix namespaces
8. Introduced `Playfield`, `Position` and `Validator` classes
9. Introduced `GlobalConstants` class
10. Introduced `Contracts` folder for interfaces
11. Add `FillPlayfield` method
12. Introduced `ConsoleRenderer` class
13. Introduced `ConsoleReader` class
14. Refactored `GameEngine` class
15. Refactor for decoupling `Playfield` and `RandomNumberGenerator`
16. Implements `OneHitted`, `TwoHitted`, `ThreeHitted`, `FourHitted` and `FiveHitted`
17. Implements score
18. Added unit tests for `Validator` class
19. Mocked few tests
20. Added unit tests for `Playfield` class
21. Introduced `Template method` design pattern with `SmallPlayfield`, `MediumPlayfield` and `LargePlayfield` classes
22. Implements `Simple Factory` design pattern for Playfields
23. Changed `Simple Factory` with `Factory Method` design pattern
24. Introduced commands in game
25. Added unit tests for `Position` class
26. Added unit tests for `RandomNumberGenerator` class
27. Added unit tests for `ConsoleRenderer` class
28. Added unit tests for `GameEngine` class
29. Added unit tests for `PlayfieldFactory` class
30. Added unit tests for `GlobalConstatns` class
31. Introduced `Memento` design pattern
32. Added new feature `Save` and `Load` game
33. Added unit tests for `Memento` class
34. Renamed `PlayfieldTests` to `SmallPlayfieldTests` and added unit tests for `MediumPlayfield` and `LargePlayfield` classes
35. Added XML documentation for all public classes and their public methods
36. Added cmh documentation for project