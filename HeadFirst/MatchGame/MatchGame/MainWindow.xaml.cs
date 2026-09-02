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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int TotalMatches = 8;                                                     // 찾아야 하는 짝의 총 개수

        DispatcherTimer timer = new DispatcherTimer();                                  // 타이머 생성
        Random random = new Random();                                                   // 임의의 숫자를 만들어내는 생성기
        int tenthsOfSecondsElapsed;                                                     // 경과 시간
        int matchesFound;                                                                // 매치 개수

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            TimeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == TotalMatches)
            {
                timer.Stop();
                TimeTextBlock.Text = TimeTextBlock.Text + " - Play again?";
            }
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

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())      // mainGrid에 포함된 모든 TextBlock을 찾아 각 TextBlock마다 명령
            {
                if (textBlock.Name != "TimeTextBlock")                                  // 가장 밑의 timeTextBlock은 해당 사항에 포함되지 않게 예외처리
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);                         // 0부터 이모지 목록에 남은 이모지 개수 중 임의의 숫자를 택해 index에 이름을 붙임
                    string nextemoji = animalEmoji[index];                              // index라는 이름이 붙은 임의의 숫자를 사용해 목록에서 임의의 이모지를 생성
                    textBlock.Text = nextemoji;                                         // TextBlock의 텍스트를 이모지 목록으로 변경
                    animalEmoji.RemoveAt(index);                                        // 목록에서 이모지를 제거
                }
            }
            tenthsOfSecondsElapsed = 0;                                                 // 경과 시간과 매치 개수, 클릭 상태를 초기화한 뒤 타이머 시작
            matchesFound = 0;
            lastTextBlockClicked = null;
            findingMatch = false;
            timer.Start();
        }

        TextBlock? lastTextBlockClicked;                                                // 전에 클릭한 이모지 변수명 저장. 아직 클릭 전이면 null
        bool findingMatch = false;                                                      // 플레이어가 첫번째 동물을 클릭하고 맞는 짝을 찾는 중인지 여부를 저장

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not TextBlock textBlock) return;                              // sender가 TextBlock이 아니면 아무것도 하지 않음
            if (findingMatch == false)                                                   // 플레이어가 첫 번째 동물을 클릭하면 화면에 보이지 않게 만든 다음, 클릭한 이모지를 저장
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (lastTextBlockClicked is TextBlock lastClicked                      // 다시 클릭한 이모지가 전에 클릭한 이모지 정보와 맞다면 숨김
                     && textBlock.Text == lastClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;                               // 짝을 먼저 숨겨야 아래 필터에서 제외됨
                lastTextBlockClicked = null;
                findingMatch = false;

                // 아직 찾지 못한(화면에 보이는) TextBlock만 모음. 이미 찾아서 숨긴 TextBlock은 제외
                List<TextBlock> remainingTextBlocks = mainGrid.Children.OfType<TextBlock>()
                    .Where(tb => tb.Name != "TimeTextBlock")                            // TimeTextBlock은 List에서 제외    
                    .Where(tb => tb.Visibility == Visibility.Visible)                   // Visibility.Visible로 되어있는 속성만 리스트에 추가
                    .ToList();

                List<string> pool = remainingTextBlocks.Select(tb => tb.Text).ToList(); // 남은 TextBlock의 이모지만 풀로 복사

                foreach (TextBlock remainText in remainingTextBlocks)                   // 남은 TextBlock에만 풀의 이모지를 임의 순서로 다시 배치
                {
                    int index = random.Next(pool.Count);
                    remainText.Text = pool[index];
                    pool.RemoveAt(index);                                               // 풀에서 사용한 이모지 제거
                }
            }
            else                                                                        // 그게 아니면 전에 클릭한 이미지 정보 다시보이게 함
            {
                if (lastTextBlockClicked is not null)
                {
                    lastTextBlockClicked.Visibility = Visibility.Visible;
                }
                lastTextBlockClicked = null;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == TotalMatches)                                            // 8쌍의 동물을 모두 맞추면 게임을 리셋
            {
                SetUpGame();
            }
        }
    }
}