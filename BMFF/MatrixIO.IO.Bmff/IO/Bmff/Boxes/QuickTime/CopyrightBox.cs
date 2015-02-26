using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MatrixIO.IO.Bmff.Boxes
{
    /// <summary>
    /// Copyright Atom ("cprt")
    /// </summary>
    [Box("cprt", "Copyright Atom")]
    public class CopyrightBox : Box, ISuperBox
    {
        public CopyrightBox() : base() { }
        public CopyrightBox(Stream stream) : base(stream) { }

        private IList<Box> _Children = Portability.CreateList<Box>();
        public IList<Box> Children
        {
            get { return _Children; }
        }

        internal override ulong CalculateSize()
        {
            return base.CalculateSize();
        }

        protected override void SaveChildrenToStream(Stream stream)
        {
            base.SaveChildrenToStream(stream);
        }

        public IEnumerator<Box> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
