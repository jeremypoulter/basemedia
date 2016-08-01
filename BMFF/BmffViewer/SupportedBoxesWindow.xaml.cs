using MatrixIO.IO.Bmff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BmffViewer
{
    /// <summary>
    /// Interaction logic for SupportedBoxes.xaml
    /// </summary>
    public partial class SupportedBoxesWindow : Window
    {
        SortedDictionary<string, string> SupportedBoxesList = new SortedDictionary<string, string>();

        public SupportedBoxesWindow()
        {
            InitializeComponent();

            foreach (KeyValuePair<BoxType, Type> boxTypeInfo in Box.AvailableBoxTypes)
            {
                string typeName = boxTypeInfo.Key.ToString();
                string description = "";
                foreach (BoxAttribute boxAttribute in boxTypeInfo.Value.GetCustomAttributes(typeof(BoxAttribute), true))
                {
                    if (boxTypeInfo.Key == boxAttribute.Type)
                    {
                        description = boxAttribute.Description;
                        break;
                    }
                }

                SupportedBoxesList.Add(typeName, description);
            }

            BoxList.ItemsSource = SupportedBoxesList;
            CountBox.Text = "Count=" + SupportedBoxesList.Count();
        }
    }
}
