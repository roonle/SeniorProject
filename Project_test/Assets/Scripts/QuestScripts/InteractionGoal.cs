using UnityEngine;
public class InteractionGoal : Goal
{
    public int NPCID;
    

    public override void Init()
    {
        Chad_interaction.InteractEvent += Interacted;
    }

    public void Interacted(Interactable npc)
    {
        if (npc.ID == NPCID)
        {
            Current++;
            evaluate();
        }
    }
    
    public int npcid
    {
        set => Current = value;
    }

}
