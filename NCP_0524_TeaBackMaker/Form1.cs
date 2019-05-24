using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace NCP_0524_TeaBackMaker
{
    public partial class Form1 : Form
    {
        string[] teaList = new string[] { "홍차", "녹차", "루이보스차", "국화차" };
        int[] timeList = new int[] { 2*60, 3*60, 5*60, 2*0 };  //분 단위
        string selectTea = "";  //선택한 차 저장
        int timeCount = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i=0; i<teaList.Length; i++)
            {
                this.cbTea.Items.Add(teaList[i]);
            }
            this.selectTea = cbTea.Text;
            if (cbTea.Items.Count > 0)
            {
                this.cbTea.SelectedIndex = 0;
            }
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            for (int i=0; i<teaList.Length; i++)
            {
                if (cbTea.Text.Equals(this.teaList[i]))
                {
                    this.timeCount = this.timeList[i];
                    this.timer.Enabled = true;
                    break;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeCount < 1)
            {
                this.timer.Enabled = false;
                MessageBox.Show("티백을 건지세요!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbTea.Focus();
            }
            else
            {
                this.timeCount--;
                this.lbTime.Text = Convert.ToString(this.timeCount/60) + "분 " + Convert.ToString(this.timeCount%60) + "초 남았습니다!";
            }
        }
    }
}
