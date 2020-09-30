using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
   public Transform questParent;
       public GameObject questUI;
   
       private QuestInventory questInventory;
   
       private QuestsSlot[] slots;
       
       // Start is called before the first frame update
       void Start()
       {
           questInventory = QuestInventory.instance;
           questInventory.onQuestChangedCallback += updateUI;
   
           slots = questParent.GetComponentsInChildren<QuestsSlot>();
       }
   
       // Update is called once per frame
       void Update()
       {
           if (Input.GetButtonDown("Quests"))
           {
               questUI.SetActive(!questUI.activeSelf);
           }
       }
   
       void updateUI()
       {
           for (int i = 0; i < slots.Length; i++)
           {
               if (i < questInventory.quests.Count)
               {
                   slots[i].addQuest(questInventory.quests[i]);
               }
               else
               {
                   slots[i].clearSlot();
               }
           }
       }
}
