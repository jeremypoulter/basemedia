using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MatrixIO.IO.Bmff.Boxes
{
    /// <summary>
    /// Data Atom ("data")
    /// </summary>
    [Box("data", "Data Atom")]
    public class DataBox : FullBox, IContentBox
    {
        public DataBox() : base() { }
        public DataBox(Stream stream) : base(stream) { }

        // TODO: We should look in to parsing the contents of iods and data which are specified in ISO 14496-1
    }
}
