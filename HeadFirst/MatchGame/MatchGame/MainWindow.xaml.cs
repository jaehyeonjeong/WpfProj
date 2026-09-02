using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🦝","🦝",
                "🐮","🐮",
                "🐷","🐷",
                "🐗","🐗",
                "🐭","🐭",
                "🐹","🐹",
                "🐰","🐰",
                "🐻","🐻",
            };

            Random random = new Random();                                               // 임의의 숫자를 만들어내는 생성기
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())      // mainGrid에 포함된 모든 TextBlock을 찾아 각 TextBlock마다 명령
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);                         // 0부터 이모지 목록에 남은 이모지 개수 중 임의의 숫자를 택해 index에 이름을 붙임
                    string nextemoji = animalEmoji[index];                              // index라는 이름이 붙은 임의의 숫자를 사용해 목록에서 임의의 이모지를 생성
                    textBlock.Text = nextemoji;                                         // TextBlock의 텍스트를 이모지 목록으로 변경
                    animalEmoji.RemoveAt(index);                                        // 목록에서 이모지를 제거 
                }
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;                                                      // 플레이어가 첫번째 동물을 클릭하고 맞는 짝을 찾는 중인지 여부를 저장

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)                                                   // 플레이어가 첫 번째 동물을 클릭하면 화면에 보이지 않게 만든 다음, 클릭한 이모지를 저장
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)                       // 다시 클릭한 이모지가 전에 클릭한 이모지 정보와 맞다면 숨김
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else                                                                        // 그게 아니면 전에 클릭한 이미지 정보 다시보이게 함
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}