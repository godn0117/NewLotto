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
        // 색상 통계를 담을 컬렉션
        List<LottoStatistics> ls = new List<LottoStatistics>();
        // 번호별 통계를 담을 배열
        List<int> number = new List<int>();
        List<string> numName = new List<string>();

        public FrmColor()
        {
            InitializeComponent();
        }

        // 조회버튼 클릭
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int startNum = Int32.Parse(this.cboSta.Text);
            int endNum = Int32.Parse(this.cboEnd.Text);
            List<Lotto> forGridView = new List<Lotto>();
            // 그리드뷰
            for (int i = startNum; i <= endNum; i++)
            {
                foreach (Lotto item in Form1.lottoList)
                {
                    if (i == item.TurnNumber)
                    {
                        forGridView.Add(item);
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = forGridView;
            // 색상 통계, 원 그래프
            ls.Clear();
            CollectReset();
            if (startNum > endNum)
            {
                InputNum(endNum, startNum);
            }
            else
            {
                InputNum(startNum, endNum);
            }
            
            pieChart.Series[0].Points.DataBind(ls, "Name", "Num", null);

            // 번호별 통계, Bar 그래프
            ArrClear();
            if (startNum > endNum)
            {
                CountBarNum(endNum, startNum);
            }
            else
            {
                CountBarNum(startNum, endNum);
            }
            RemoveNum(number, numName);
            this.colChart.Series[0].Points.DataBindXY(numName, number);
        }

        private void FrmColor_Load(object sender, EventArgs e)
        {
            this.Text = "색상 통계";
            for (int i = 0; i < Form1.newTurnNum; i++)
            {
                this.cboSta.Items.Add(i + 1);
                this.cboEnd.Items.Add(i + 1);
            }

            colChart.ChartAreas[0].AxisX.Interval = 1;
            // 원 그래프
            this.pieChart.Titles.Add("Title");
            this.pieChart.Titles[0].Text = "색상 통계";

            pieChart.Series[0].ChartType = SeriesChartType.Pie;

            // 컬렉션 초기화
            CollectReset();

            // 처음은 5회차
            int staNum = Form1.lottoList.Count - 5;
            int endNum = Form1.lottoList.Count;
            cboSta.Text = staNum.ToString();
            cboEnd.Text = endNum.ToString();

            InputNum(staNum, endNum);

            pieChart.Series[0].Points.DataBind(ls, "Name", "Num", null);


            // bar 그래프
            this.colChart.Titles.Add("Title");
            this.colChart.Titles[0].Text = "번호별 통계";
            this.colChart.Series[0].ChartType = SeriesChartType.Bar;

            // 배열 초기화
            ArrClear();

            // 해당 구 수정중.....
            // 해당 구에 대한 출현횟수
            CountBarNum(staNum,endNum);

            // 한번도 나오지 않은 구 제외
            RemoveNum(number, numName);

            // 차트 표시
            //foreach (var item in number)
            //{
            //MessageBox.Show(item.ToString());
            //}

            this.colChart.Series[0].Points.DataBindXY(numName, number);
            this.colChart.Series[0].LegendText = "해당 구 출현횟수";
        }

        private void CollectReset()
        {
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
        }

        private void ArrClear()
        {
            number.Clear();
            numName.Clear();

            for (int i = 0; i < 45; i++)
            {
                number.Add(0);
                numName.Add((i + 1) + "번째 구");
            }
        }

        private void RemoveNum(List<int> number, List<string> numName)
        {
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] == 0)
                {
                    number.RemoveAt(i);
                    numName.RemoveAt(i);
                    i= i - 1;
                }
            }
        }

        private void CountBarNum(int startNum, int endNum)
        {
            for (int i = startNum; i <= endNum; i++)
            {
                CountNum(Form1.lottoList[i - 1].Num1, number);
                CountNum(Form1.lottoList[i - 1].Num2, number);
                CountNum(Form1.lottoList[i - 1].Num3, number);
                CountNum(Form1.lottoList[i - 1].Num4, number);
                CountNum(Form1.lottoList[i - 1].Num5, number);
                CountNum(Form1.lottoList[i - 1].Num6, number);
            }
        }

        private void CountNum(int num1, List<int> number)
        {
            number[(num1-1)]++;
        }


        private void InputNum(int startNum, int endNum)
        {
            for (int i = startNum; i <= endNum; i++)
            {
                Switching(Form1.lottoList[i - 1].Num1, ls);
                Switching(Form1.lottoList[i - 1].Num2, ls);
                Switching(Form1.lottoList[i - 1].Num3, ls);
                Switching(Form1.lottoList[i - 1].Num4, ls);
                Switching(Form1.lottoList[i - 1].Num5, ls);
                Switching(Form1.lottoList[i - 1].Num6, ls);
            }
        }
        //private void InputNum(int num)
        //{
        //    for (int i = Form1.lottoList.Count - num; i < Form1.lottoList.Count; i++)
        //    {
        //        Switching(Form1.lottoList[i].Num1, ls);
        //        Switching(Form1.lottoList[i].Num2, ls);
        //        Switching(Form1.lottoList[i].Num3, ls);
        //        Switching(Form1.lottoList[i].Num4, ls);
        //        Switching(Form1.lottoList[i].Num5, ls);
        //        Switching(Form1.lottoList[i].Num6, ls);
        //    }
        //}

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

        private void cboSta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(this.cboSta.Text);

            }
            catch (Exception)
            {
                if (this.cboSta.Text == String.Empty)
                {
                    return;
                }
                MessageBox.Show("숫자만 입력하세요.");
                this.cboSta.Focus();
            }
        }

        private void cboEnd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(this.cboEnd.Text);

            }
            catch (Exception)
            {
                if (this.cboEnd.Text == String.Empty)
                {
                    return;
                }
                MessageBox.Show("숫자만 입력하세요.");
                this.cboEnd.Focus();
            }
        }
    }
}
