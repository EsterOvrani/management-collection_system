using System;
using System.Windows;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OrAhemet.Controls
{

    public class FieldsInputPanel : Grid
    {
        public int LastRowIndex { get { return this.RowDefinitions.Count - 1; } }

        enum eUIElementType { Init, Title, Field, PlaceHolder, GroupHeader }
        eUIElementType _LastElement = eUIElementType.Init;

        public int MinRowHeight
        {
            get { return (int)GetValue(MinRowHeightProperty); }
            set { SetValue(MinRowHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinRowHeightProperty =
            DependencyProperty.Register("MinRowHeight", typeof(int), typeof(FieldsInputPanel), new PropertyMetadata(20, refresh));


        public int DistanceRowHeight
        {
            get { return (int)GetValue(DistanceRowHeightProperty); }
            set { SetValue(DistanceRowHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DistanceRowHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistanceRowHeightProperty =
            DependencyProperty.Register("DistanceRowHeight", typeof(int), typeof(FieldsInputPanel), new PropertyMetadata(10, refresh));


        public int GroupHeaderColumnWidth
        {
            get { return (int)GetValue(GroupHeaderColumnWidthProperty); }
            set { SetValue(GroupHeaderColumnWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GroupHeaderColumnWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupHeaderColumnWidthProperty =
            DependencyProperty.Register("GroupHeaderColumnWidth", typeof(int), typeof(FieldsInputPanel), new PropertyMetadata(0, refresh));



        public int TitleColumnWidth
        {
            get { return (int)GetValue(TitleColumnWidthProperty); }
            set { SetValue(TitleColumnWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleColumnWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleColumnWidthProperty =
            DependencyProperty.Register("TitleColumnWidth", typeof(int), typeof(FieldsInputPanel), new PropertyMetadata(100, refresh));


        public int FieldColumnWidth
        {
            get { return (int)GetValue(FieldColumnWidthProperty); }
            set { SetValue(FieldColumnWidthProperty, value); }
        }


        // Using a DependencyProperty as the backing store for FieldColumnWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FieldColumnWidthProperty =
            DependencyProperty.Register("FieldColumnWidth", typeof(int), typeof(FieldsInputPanel), new PropertyMetadata(200, refresh));




        public FieldsInputPanel()
        {
            // השורה הבאה נועדה לוודא כי הגריד לא יהיה מתוח
            // הסיבה היא כי בגובה שורה הגדרתי מינימום אך לא גובה קבוע
            // וכברירת מחדל הגריד נמתח ולכן יגובה יהיה אוטומטית מתוח
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = HorizontalAlignment.Left;

            
        }




        //protected override void OnPropertyChanged1(DependencyPropertyChangedEventArgs e)
        //{

        //    base.OnPropertyChanged(e);

        //    RebuildGrid();
        //}
        private static void refresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as FieldsInputPanel).RebuildGrid();
        }
        void RebuildGrid()
        {
            //Reset          
            _LastElement = eUIElementType.Init;
            this.RowDefinitions.Clear();
            this.ColumnDefinitions.Clear();
            AddColumns();

            //Build
            for (int i = 0; i < this.Children.Count; i++)
            {
                FrameworkElement uie = (FrameworkElement)this.Children[i];
                eUIElementType currentElementType;

                // יישור הפקד לצד שמאל
                // במקרה שנקבע לפקד רוחב
                // במקרה שלא נקבע רוחב, הוא ימתח ע"פ כל הרוחב כברירת מחדל
                if (this.Children[i].GetType().IsSubclassOf(typeof(FrameworkElement)))
                {
                    FrameworkElement fe = this.Children[i] as FrameworkElement;

                    if (fe.Width > 0)
                    {
                        fe.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                }
                    
                

                if (uie is GroupHeader)
                {
                    currentElementType = eUIElementType.GroupHeader;
                }
                else if (uie is PlaceHolder)
                {
                    currentElementType = eUIElementType.PlaceHolder;
                }
                else
                {
                    switch (_LastElement)
                    {
                        case eUIElementType.Init:
                        case eUIElementType.Field:
                        case eUIElementType.PlaceHolder:
                        case eUIElementType.GroupHeader:
                            currentElementType = eUIElementType.Title;
                            break;

                        case eUIElementType.Title:
                            currentElementType = eUIElementType.Field;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                _LastElement = currentElementType;



                switch (currentElementType)
                {
                    case eUIElementType.GroupHeader:
                        AddRow();
                        Grid.SetRow(uie, LastRowIndex);
                        Grid.SetColumn(uie, 0);
                        Grid.SetColumnSpan(uie, 10);
                        break;

                    case eUIElementType.Title:
                        AddRow();
                        Grid.SetRow(uie, LastRowIndex);
                        Grid.SetColumn(uie, 1);
                        break;

                    case eUIElementType.PlaceHolder:
                        AddRow(false);
                        Grid.SetRow(uie, LastRowIndex);
                        Grid.SetColumn(uie, 1);
                        break;

                    case eUIElementType.Field:
                        Grid.SetRow(uie, LastRowIndex);
                        Grid.SetColumn(uie, 2);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }

        }

        private void AddColumns()
        {
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(this.GroupHeaderColumnWidth) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(this.TitleColumnWidth) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(this.FieldColumnWidth) });
        }


        private void AddRow()
        {
            AddRow(true);
        }
        private void AddRow(bool addDistanceRow)
        {
            if (addDistanceRow)
            {
                if (this.RowDefinitions.Count > 0)
                {
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(this.DistanceRowHeight) });
                }
            }
            this.RowDefinitions.Add(new RowDefinition { MinHeight = MinRowHeight, Height = new GridLength(1, GridUnitType.Auto) });
        }

        protected override Size MeasureOverride(Size constraint)
        {
            RebuildGrid();

            return base.MeasureOverride(constraint);
        }

    }

    public class PlaceHolder : FrameworkElement
    {
        public PlaceHolder()
        {
            //Focusable = false;
        }
    }

    public class GroupHeader : ContentControl
    {
        public GroupHeader()
        {
            //Focusable = false;
        }
    }
}
