using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EditingCollections.Enum
{
    public enum MyType
    {
        [Description("None")]
        None,
        [Description("String")]
        String,
        [Description("Percentage")]
        Percentage,
        [Description("Currency")]
        Currency,
    }
}
