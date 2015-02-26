using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MatrixIO.IO.Bmff.Boxes
{
    /// <summary>
    /// Name Atom ("name")
    /// </summary>
    [Box("name", "Name Atom")]
    public class NameBox : FullBox, IContentBox
    {
        public NameBox() : base() { }
        public NameBox(Stream stream) : base(stream) { }

        // TODO: We should look in to parsing the contents of iods and name which are specified in ISO 14496-1
    }
}
