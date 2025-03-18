using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCompany
{
    public class ListViewItemComparer : IComparer
    {
        private readonly int column;

        private readonly SortOrder order;

        public ListViewItemComparer(int column, SortOrder order)
        {
            this.column = column;
            this.order = order;
        }

        public int Compare(object? x, object? y)
        {
            try
            {
                ListViewItem? itemX = (ListViewItem?)x;
                ListViewItem? itemY = (ListViewItem?)y;

                string textX = itemX.SubItems[column].Text;
                string textY = itemY.SubItems[column].Text;

                int result;

                if (column == 0)
                {
                    bool isNumericX = int.TryParse(textX, out int idX);
                    bool isNumericY = int.TryParse(textY, out int idY);

                    result = isNumericX && isNumericY ? idX.CompareTo(idY) : string.Compare(textX, textY);
                }
                else
                {
                    result = string.Compare(textX, textY);
                }

                if (order == SortOrder.Descending)
                {
                    result = -result;
                }

                return result;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
