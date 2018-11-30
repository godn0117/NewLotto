using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lotto
{
    public partial class FrmColor : Form
    {
        // 뽑아갈 갯수
        int num = 0;
        // 색상 통계를 담을 컬렉션
        List<LottoStatistics> ls = new List<LottoStatistics>();
        // 번호별 통계를 담을 리스트

        public FrmColor()
        {
            InitializeComponent();
        }

        // 조회버튼 클릭
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int startNum = Int32.Parse(this.cboSta.Text);
            int endNum = Int32.Parse(this.cboEnd.Text);
            if (startNum > endNum)
            {
                MessageBox.Show("앞자리 숫자가 뒤자리 숫자보다 클수 없습니다.");
                return;
            }
        }

        private void FrmColor_Load(object sender, EventArgs e)
        {
            // 원 그래프
            this.pieChart.Titles.Add("Title");
            this.pieChart.Titles[0].Text = "색상 통계";

            pieChart.Series[0].ChartType = SeriesChartType.Pie;

            // 컬렉션 초기화
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    ls.Add(new LottoStatistics(i + 1 + " 번대"));
                }
                else
                {
                    ls.Add(new LottoStatistics((i * 10) + " 번대"));
                }
            }

            // 처음은 5회차
            num = 5;
            InputNum(num);

            pieChart.Series[0].Points.DataBind(ls, "Name", "Num", null);





            // col 그래프
            this.colChart.Titles.Add("Title");
            this.colChart.Titles[0].Text = "번호별 통계";
            this.colChart.Series[0].ChartType = SeriesChartType.Column;
        }

        private void InputNum(int num)
        {
            for (int i = Form1.lottoList.Count - num; i < Form1.lottoList.Count; i++)
            {
                Switching(Form1.lottoList[i].Num1, ls);
                Switching(Form1.lottoList[i].Num2, ls);
                Switching(Form1.lottoList[i].Num3, ls);
                Switching(Form1.lottoList[i].Num4, ls);
                Switching(Form1.lottoList[i].Num5, ls);
                Switching(Form1.lottoList[i].Num6, ls);
            }
        }

        private void Switching(int num1, List<LottoStatistics> ls)
        {
            switch (num1/10)
            {
                case 0:
                    ls[0].Num++;
                    break;
                case 1:
                    ls[1].Num++;
                    break;
                case 2:
                    ls[2].Num++;
                    break;
                case 3:
                    ls[3].Num++;
                    break;
                default:
                    ls[4].Num++;
                    break;
            }
        }
    }
}
