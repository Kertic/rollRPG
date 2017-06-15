using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVar
{

   public static Player mainPlayer;//The protagonist
    

    /// <summary>
    /// This will roll a dice with (numOfSides) sides, and return the result
    /// </summary>
    /// <param name="numOfSides">The number of sides the dice has</param>
    /// <returns></returns>
	public static int Roll(int numOfSides)
    {
        return (int)((Random.value * 100) % numOfSides) + 1;
    }


}
