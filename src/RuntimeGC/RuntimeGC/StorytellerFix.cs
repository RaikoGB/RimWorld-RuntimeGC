using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace RuntimeGC
{
    public static class StorytellerFix {

        private static void StorytellerFix_ClearQueue ()
        {
            Find.Storyteller.incidentQueue.Clear();
        }

        private static int StorytellerFix_QueueLength ()
        {
           return Find.Storyteller.incidentQueue.Count;
        }

        private static string StorytellerFix_BrowseQueue ()
        {
            return Find.Storyteller.incidentQueue.DebugQueueReadout;
        }

        public static void StorytellerFix_GetInfoButton()
        {

                string teller = Find.Storyteller.def.label;
                string difficulty = Find.Storyteller.difficulty.label;
                int queueLength = StorytellerFix_QueueLength();
                string queue = StorytellerFix_BrowseQueue();


                Find.WindowStack.Add(new Dialog_MessageBox("STFteller".Translate(teller) + "\n\n" +
                                                         "STFdifficulty".Translate(difficulty) + "\n\n" + 
                                                         "SFTlength".Translate(queueLength).ToString() + "\n\n" +
                                                          queue));

        }

        public static void StorytellerFix_ClearButton()
        {
                int currentQueueLength = StorytellerFix_QueueLength();
                if (currentQueueLength != 0)
                {
                    StorytellerFix_ClearQueue();
                }
                int newQueueLength = StorytellerFix_QueueLength();

                bool cleared = newQueueLength != currentQueueLength;

                Find.WindowStack.Add(new Dialog_MessageBox("STFcurrent".Translate(currentQueueLength).ToString() + 
                                                         (cleared ? "\n\n" + "STFjobdone".Translate(newQueueLength) + "\n" : "\n\n" + "STFjobNOTdone".Translate(newQueueLength) + "\n")
                                                         ));

        }

    }

}