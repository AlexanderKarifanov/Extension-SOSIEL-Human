// This file is part of the Social Human extension for LANDIS-II.

using Landis.Core;
using Landis.SpatialModeling;
using Landis.Library.BiomassCohorts;

namespace Landis.Extension.SOSIELHuman
{
    public class SiteVars
    {
        private static ISiteVar<ISiteCohorts> biomassCohorts;
        public static ISiteVar<string> PrescriptionName { get; set; }
        //---------------------------------------------------------------------

        public static void Initialize()
        {

            biomassCohorts = PlugIn.ModelCore.GetSiteVar<ISiteCohorts>("Succession.BiomassCohorts");

            if (biomassCohorts == null)
            {
                string mesg = string.Format("Cohorts are empty.  Please double-check that this extension is compatible with your chosen succession extension.");
                throw new System.ApplicationException(mesg);
            }

            PrescriptionName = PlugIn.ModelCore.Landscape.NewSiteVar<string>();
            PlugIn.ModelCore.RegisterSiteVar(SiteVars.PrescriptionName, "Harvest.PrescriptionName");
            SiteVars.PrescriptionName.SiteValues = "SOSIEL";

        }

        // ----------------------------------------------------

        /// <summary>
        /// Biomass cohorts at each site.
        /// </summary>
        public static ISiteVar<ISiteCohorts> Cohorts
        {
            get
            {
                return biomassCohorts;
            }
            set
            {
                biomassCohorts = value;
            }
        }
    }
}
