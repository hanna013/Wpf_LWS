using DerivedCoef1;
using System.Windows.Controls;
using System.Windows.Media;



namespace Wpf_LWS
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        //DB DataBase = new DB(); // 프로퍼티도 쓰려면 이렇게 객체 생성해야 함. // 맨 위에 생성해줘야 매번 새로 생성해서 db란 이름을 가진 새로운 주소? 혹은 덮어쓰기가 되지 않음.
        //DB class 자체를 static으로 만들어서 객체 생성없이 바로 사용함.
        int cnt = 0;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            Scanner_X.Text = "";
            Scanner_X.Foreground = Brushes.Black;
        }

        private void TextBox_GotFocus_1(object sender, System.Windows.RoutedEventArgs e)
        {
            Scanner_Y.Text = "";
            Scanner_Y.Foreground = Brushes.Black;
        }

        private void Camera_X_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            Camera_X.Text = "";
            Camera_X.Foreground = Brushes.Black;
        }

        private void Camera_Y_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            Camera_Y.Text = "";
            Camera_Y.Foreground = Brushes.Black;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            DerivedCoef derived = new DerivedCoef();
            (double derivedScnX, double derivedScnY) = derived.CalOffset(double.Parse(Scanner_X.Text), double.Parse(Scanner_Y.Text), int.Parse(Camera_X.Text), int.Parse(Camera_Y.Text)); // 계산은 여기서, 함수 불러서

            DB.DB_Scn_X.Add(double.Parse(Scanner_X.Text));
            DB.DB_Scn_Y.Add(double.Parse(Scanner_Y.Text));
            DB.DB_Cmr_X.Add(int.Parse(Camera_X.Text));
            DB.DB_Cmr_Y.Add(int.Parse(Camera_Y.Text));
            DB.Derived_X.Add(derivedScnX);
            DB.Derived_Y.Add(derivedScnY);

            if (DB.Derived_X.Count >= 2)
            {
                (double a, double b, double c, double d) = DB.Cal_Print();
                Txt_DervCoef_X.Text = $"X = {a}x + {b}";
                Txt_DervCoef_Y.Text = $"X = {c}x + {d}";    
            }
            
            cnt++;
        }

    }
}
