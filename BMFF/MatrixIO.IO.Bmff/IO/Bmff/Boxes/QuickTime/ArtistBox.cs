﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MatrixIO.IO.Bmff.Boxes
{
    /// <summary>
    /// Artist Atom ("\xA9ART")
    /// </summary>
    [Box(new char[] { '\xA9', 'A', 'R', 'T' }, "Artist Atom")]
    public class ArtistBox : Box, ISuperBox
    {
        public ArtistBox() : base() { }
        public ArtistBox(Stream stream) : base(stream) { }

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
