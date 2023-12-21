using System;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace gggg
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void LB1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if(e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                   

                    ListBoxItem selectedItem = (ListBoxItem)LB1.SelectedItem;
                    LB1.Items.Remove(selectedItem);
                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);
                    if(selectedItem.Parent == null ) 
                    {
                        LB2.Items.Add(selectedItem);
                    }
                }
                catch { }
            }    
        }
        private void LB2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {


                    ListBoxItem selectedItem = (ListBoxItem)LB2.SelectedItem;
                    LB2.Items.Remove(selectedItem);
                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);
                    if (selectedItem.Parent == null)
                    {
                        LB1.Items.Add(selectedItem);
                    }
                }
                catch { }
            }
        }
        private void LB1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void LB2_MouseMove(object sender, MouseEventArgs e)
        {

        }
        
        private void LB1_Drop(object sender, DragEventArgs e) 
        {
           if (e.Data.GetData(DataFormats.FileDrop) is ListBox listItem)
            {
                LB1.Items.Add(listItem);
            }    
        }

        private void LB2_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is ListBox listItem)
            {
                LB2.Items.Add(listItem);
            }
        }


    }

}
