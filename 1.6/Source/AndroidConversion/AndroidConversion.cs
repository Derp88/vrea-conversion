using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace AndroidConversion
{
    public class IngestionOutcomeDoer_ChangeXenotype : IngestionOutcomeDoer
    {
        public XenotypeDef destinationXenotype;
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            foreach (Gene gene in pawn.genes?.GenesListForReading)
            {
                //Check if pawn is an android
                if (gene.def.defName == "VREA_Power")
                {
                    //If pawn is an android, spawn a replacement serum and give warning.
                    Messages.Message("This item does not work on androids." , pawn, MessageTypeDefOf.RejectInput, historical: false);
                    ThingDef replacementSerum = ThingDef.Named("ConversionSerum");
                    GenSpawn.Spawn(replacementSerum, pawn.Position, pawn.Map);
                    return;
                }
            }
            foreach (Gene gene in pawn.genes?.GenesListForReading)
            {
                pawn.genes?.RemoveGene(gene);
            }
            pawn.genes?.SetXenotype(destinationXenotype);
        }
    }
}
