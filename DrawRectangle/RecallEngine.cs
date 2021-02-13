using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrawRectangle
{
    public class RecallEngine
    {

        private List<Aircraft> m_DeployedAircraft;

        private RectangleShape m_Shape;

        public RecallEngine(List<Aircraft> DeployedAircraft, RectangleShape shape)
        {
            m_DeployedAircraft = DeployedAircraft;
            m_Shape = shape;

        }

        public bool ConfirmSelectedAircraft()
        {

            for (int i = 0; i < m_DeployedAircraft.Count; i++)
            {
                if (CheckAircraft(m_DeployedAircraft[i]) == false)
                {
                    return false;
                }
            }

            return true;


        }

        private bool CheckAircraft(Aircraft aircraft)
        {
            return m_Shape.GraphicRectangle.Contains(new Point(aircraft.startingLocation.X, aircraft.startingLocation.Y));
        }
    }

}
