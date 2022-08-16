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
using DerivedCoef1;

namespace Wpf_LWS
{
    /// <summary>
    /// UserControl2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl2 : UserControl
    {

        public UserControl2()
        {
            InitializeComponent();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Display> list = new List<Display>(); // 얘는 또 클래스 맨 처음에 선언하니까 error throw 하더라. 이렇게 datagrid가 loaded될 때마다 새로 생성해서 add 해줘야 충돌이 없는지..?

            //list.Add(new Display { Num = 0, Disp_Scn_X = 1, Disp_Scn_Y = 2, Disp_Cmr_X = 3, Disp_Cmr_Y = 4, Disp_Derived_X = 5, Disp_Derived_Y = 6 });

            for (int i = 0; i < DB.DB_Scn_X.Count; i++)
            {
                list.Add(new Display { Num = i+1, Disp_Scn_X = DB.DB_Scn_X[i], Disp_Scn_Y = DB.DB_Scn_Y[i], Disp_Cmr_X = DB.DB_Cmr_X[i], Disp_Cmr_Y = DB.DB_Cmr_Y[i], Disp_Derived_X = DB.Derived_X[i], Disp_Derived_Y = DB.Derived_Y[i] });
            }

            dataGrid.ItemsSource = list;    // datagrid와 list를 이렇게 연결해줘야 함.
        }

    }

    public class Display
    {
        public int Num { get; set; }
        public double Disp_Scn_X { get; set; }
        public double Disp_Scn_Y { get; set; }
        public int Disp_Cmr_X { get; set; }
        public int Disp_Cmr_Y { get; set; }
        public double Disp_Derived_X { get; set; }
        public double Disp_Derived_Y { get; set; }
    }

}
