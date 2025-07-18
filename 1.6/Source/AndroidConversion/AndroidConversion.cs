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
                pawn.genes?.RemoveGene(gene);
            }
            pawn.genes?.SetXenotype(destinationXenotype);
        }
    }
}
