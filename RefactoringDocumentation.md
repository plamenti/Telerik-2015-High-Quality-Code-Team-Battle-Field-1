From method Run() removed unneend code:
In method Run
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
