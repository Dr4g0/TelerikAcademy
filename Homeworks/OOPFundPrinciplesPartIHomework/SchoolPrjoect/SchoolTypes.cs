using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    enum SchoolType
    {
        [Description("From I to IV grade incl.")]
        PrimarySchool,
        [Description("From I to VII grade incl.")]
        GrammarSchool,
        [Description("From IX to XII grade incl.")]
        HighSchool,
        SchoolSports,
        SpirituallySchool
    }
}
