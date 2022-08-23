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

        List<int> selected = new List<int>();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //삭제 버튼
            selected.Sort();
            selected.Reverse(); // 인덱스 역방향으로 정렬. 순서 섞여서 중간 인덱스부터 삭제되면 나머지 삭제해야 할 데이터의 인덱스가 달라져서 오류 생김.



            foreach (int i in selected)
            {
                DB.DB_Scn_X.RemoveAt(i);
                DB.DB_Scn_Y.RemoveAt(i);
                DB.DB_Cmr_X.RemoveAt(i);
                DB.DB_Cmr_Y.RemoveAt(i);
                DB.Derived_X.RemoveAt(i);
                DB.Derived_Y.RemoveAt(i);
            }
            
            selected.Clear();

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            selected.Add(dataGrid.SelectedIndex); // foreach로 해서 중간 것 삭제하면 index가 바뀌면서 예외처리로 넘어감.
            lb1.Content = dataGrid.SelectedIndex; // selected.Last(); // 체크박스할 때 추가되는지 확인용.
            //lb1.
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            selected.Remove(dataGrid.SelectedIndex); // remove를 써야 그 내용에 해당하는 값을 지움. removeAt 말고!
            
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
