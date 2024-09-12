using MMALigaSumulation.Shared.Fighters;
using MMALigaSumulation.Shared.Fights;

namespace MMALigaSumulation.Shared.FightEngine.FighterUtils
{
    public static class FighterUtil
    {

        public static int GetFighterAction(Fight fight, Fighter Act, Fighter Pas)
        {
            // Se ambos os lutadores estão em pé e não estão no clinch, pode não haver ação
            if (new Random().Next(ApplicationUtils.ACTIONFREQUENCY) < Act.Attributes.Aggressiveness + Act.FightAttributes.Rush
                || fight.Attributes.InTheClinch || Act.FightAttributes.OnTheGround || Pas.FightAttributes.OnTheGround)
            {
                if (Act.FightAttributes.OnTheGround && Pas.FightAttributes.OnTheGround)
                {
                    return GetGroundAction(Act, Pas);
                }
                else if (!Act.FightAttributes.OnTheGround && Pas.FightAttributes.OnTheGround)
                {
                    return GetStandToGroundAction(Act, Pas);
                }
                else if (Act.FightAttributes.OnTheGround && !Pas.FightAttributes.OnTheGround)
                {
                    return GetGroundToStandAction(Act, Pas);
                }
                else if (fight.Attributes.InTheClinch)
                {
                    return GetClinchAction(Act, Pas);
                }
                else
                {
                    return GetStandUpAction(Act, Pas);
                }
            }
            else
            {
                return ACT_NOACTION;
            }
        }


    }
}
