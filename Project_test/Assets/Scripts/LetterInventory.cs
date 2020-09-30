using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterInventory
{
   private List<Letter> letterList;

   public LetterInventory(){

       letterList = new List<Letter>();

       Debug.Log("Inventory");
   }
}
