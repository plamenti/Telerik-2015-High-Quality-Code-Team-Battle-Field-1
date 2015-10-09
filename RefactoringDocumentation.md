From method Run() removed unneenеd code:

Before: …

                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            battleField[0, col] = "0";
                        }
                        else
                        {
                            battleField[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
…
After:…

                    if (col % 2 == 0)
                    {
                        battleField[0, col] = Convert.ToString((col - 2) / 2);
                    }
                    else
                    {
                        battleField[0, col] = " ";
                    }

##### Tectonik

Added contract IGameEngine in folder contracts, file IGameEngine.cs
<!--  -->
Before:
```csharp
public class GameEngine
```

After:
```csharp
public class GameEngine : IGameEngine
```
