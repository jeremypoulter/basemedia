#!/bin/sh

for i in `grep ilst MetadataItemListBox_atoms.txt `
do
  fourcc=`echo $i | sed -E 's/^ilst-(.*)=com.*$/\1/g' | sed s/u00/x/`
  box=`echo $i | sed -E 's/^ilst-(.*)=com.*\.Apple(.*)$/\2/g'`
  name=`echo $box | sed -E 's/([A-Z])/ \1/g' | sed 's/Box/Atom/' | sed 's/^ //'`
  echo $fourcc $box $name
  
  cp MetadataItemListBox.cs $box.cs
  sed "s/MetadataItemListBox/$box/" -i $box.cs
  sed "s/ilst/${fourcc//\\/\\\\}/" -i $box.cs
  sed "s/Metadata Item List Atom/$name/" -i $box.cs

#  cp ElementaryStreamDescriptorBox.cs $box.cs
#  sed "s/ElementaryStreamDescriptorBox/$box/" -i $box.cs
#  sed "s/esds/${fourcc//\\/\\\\}/" -i $box.cs
#  sed "s/Elementary Stream Descriptor Atom/$name/" -i $box.cs

done

for i in `grep -E '^-----' MetadataItemListBox_atoms.txt `
do
  fourcc=`echo "$i" | sed -E 's/^-----(.*)=com.*$/\1/g'`
  box=`echo "$i" | sed -E 's/^-----(.*)=com.*\.Apple(.*)$/\2/g'`
  name=`echo $box | sed -E 's/([A-Z])/ \1/g' | sed 's/Box/Atom/' | sed 's/^ //'`
  echo $fourcc $box $name
  
  cp ElementaryStreamDescriptorBox.cs $box.cs
  sed "s/ElementaryStreamDescriptorBox/$box/" -i $box.cs
  sed "s/esds/${fourcc//\\/\\\\}/" -i $box.cs
  sed "s/Elementary Stream Descriptor Atom/$name/" -i $box.cs
done
