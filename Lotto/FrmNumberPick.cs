using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class FrmNumberPick : Form
    {
        public FrmNumberPick()
        {
            InitializeComponent();
        }

        // 추천해주는 로또 번호
        List<Lotto> lottos;
        // 확률만큼 담을 번호 컬렉션
        List<int> num = new List<int>();
        // 확률을 계산해 주기 위한 컬렉션
        List<LoTNum> lst = new List<LoTNum>();

        private void FrmNumberPick_Load(object sender, EventArgs e)
        {
            // 최대 10만원 100번 콤보박스 리스트 초기화
            for (int i = 0; i < 100; i++)
            {
                this.comboBox1.Items.Add(i+1);
            }

            // 컬렉션 초기화
            for (int i = 0; i < 45; i++)
            {
                lst.Add(new LoTNum { Name = (i + 1)});
            }

            lottos = new List<Lotto>();
        }

        private void btnRecom_Click(object sender, EventArgs e)
        {
            // 초기화
            this.dataGridView1.DataSource = null;

            // 등장 횟수 카운트
            foreach (var item in Form1.lottoList)
            {
                CountNum(item.Num1);
                CountNum(item.Num2);
                CountNum(item.Num3);
                CountNum(item.Num4);
                CountNum(item.Num5);
                CountNum(item.Num6);
                CountNum(item.BonusNum);
            }

            //확률만큼 담아줌
            SetCounting();
            // 확률 랜덤 뽑기?
            AddList();

            // 추천번호 등록
            this.dataGridView1.DataSource = lottos;
        }

        private void AddList()
        {
            int[] selNum = new int[6];
            List<int> sel = new List<int>();
            sel.AddRange(num);
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int random = ran.Next(0, sel.Count);
                selNum[i] = sel[random];
                for (int j = 0; j < sel.Count; j++)
                {
                    if (sel[j] == selNum[i])
                    {
                        sel.RemoveAt(j);
                        j--;
                    }
                }
                Thread.Sleep(100);
            }
            // 정렬
            Sort(selNum);
            lottos.Add(new Lotto { Num1 = selNum[0], Num2 = selNum[1], Num3 = selNum[2], Num4 = selNum[3], Num5 = selNum[4], Num6 = selNum[5] });
        }

        private void Sort(int[] selNum)
        {
            for (int i = 0; i < selNum.Length; i++)
            {
                for (int j = i+1; j < selNum.Length; j++)
                {
                    if (selNum[i] > selNum[j])
                    {
                        int temp = selNum[j];
                        selNum[j] = selNum[i];
                        selNum[i] = temp;
                    }
                }
            }
        }

        private void SetCounting()
        {
            int percent = 0;
            float totalCount = Form1.newTurnNum * 7;
            foreach (var item in lst)
            {
                percent = (int)((item.Number / totalCount) * 100);
                if (percent != 0)
                {
                    for (int i = 0; i < percent; i++)
                    {
                        num.Add(item.Name);
                    }
                }
                else
                {
                    num.Add(item.Name);
                }
            }
        }

        private void CountNum(int num)
        {
            lst[num-1].Number++;
        }
    }
}
