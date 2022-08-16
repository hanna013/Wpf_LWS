using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;


namespace Wpf_LWS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            // 여기에 저장하고 context 리셋하는 것 하면 됨. wpf 콘트롤이 텍스트로 잡은 걸 넘기면 알아서 해당 프로퍼티에 맞는 데이터형으로 바꿔준다 함.
        }

        private void UserControl2_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
