using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HMSApp
{
    class NavigationManager
    {
        private Frame _frame;
        private TabControl _tabControl;
        private Stack<(Page Page, int TabIndex)> _history = new Stack<(Page, int)>();

        public delegate void TabSelectionHandler(int tabIndex);
        public event TabSelectionHandler OnTabSelection;

        public NavigationManager(Frame frame, TabControl tabControl)
        {
            _frame = frame;
            _tabControl = tabControl;
        }


        public void NavigateTo(Page page, int tabIndex)
        {
            // Lưu trạng thái hiện tại vào history
            if (_frame.Content != null)
            {
                _history.Push((_frame.Content as Page, _tabControl.SelectedIndex));
            }

            // Chuyển đến page và tab mới
            _frame.Navigate(page);
            _tabControl.SelectedIndex = tabIndex;
        }

        public void GoBack()
        {
            if (_history.Count > 0)
            {
                var (previousPage, previousTabIndex) = _history.Pop();
                _frame.Navigate(previousPage);
                _tabControl.SelectedIndex = previousTabIndex;
            }
        }

        public bool CanGoBack => _history.Count > 0;
    }
}
