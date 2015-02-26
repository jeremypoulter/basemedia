using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MatrixIO.IO.Bmff.Boxes
{
    /// <summary>
    /// Mean Atom ("mean")
    /// </summary>
    [Box("mean", "Mean Atom")]
    public class MeanBox : FullBox, IContentBox
    {
        public MeanBox() : base() { }
        public MeanBox(Stream stream) : base(stream) { }

        // TODO: We should look in to parsing the contents of iods and mean which are specified in ISO 14496-1
    }
}
