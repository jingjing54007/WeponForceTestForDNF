using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WeponForceTestForDNF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double FORCERATE = 34;
        double currentRate = 0;
        double myOwnCoins = 60000000;//初始资源
        int MaxValue = 100;
        int MinValue = 1;
        bool humanDisturb = false;
        bool useAdvanceC = false;
        List<Wepon> InitWeponInfoList = null;
        List<Wepon> WeponInfoList = null;//目前拥有的列表
        List<Wepon> SucceedWeponInfoList = null;
        List<Wepon> DestoryWeponInfoList = null;
        Random rnd = new Random();
        public int totalFalseCount = 0;
        public int totalSucceedCount = 0;
        public static int totalTired = 1;//完全失败个数
        public static Dictionary<int, string> FStatic = new Dictionary<int, string>();//完全失败个数
        private void button1_Click(object sender, EventArgs e)
        {
            BeginTest();
        }
        /// <summary>
        /// 开始测试
        /// </summary>
        private InvokeResult  BeginTest()
        {
            var iResult =new  InvokeResult();
            this.ResultShow.Text += "---------------------------------------------------\n";
            InitialBasicParam();
            WeponInfoList = WeponInfoList.OrderBy(c => c.Level).ToList();
            for (var i = 0; i < WeponInfoList.Count(); )
            {
                if (i >= WeponInfoList.Count())
                {
                    break;
                }
                var wepon = WeponInfoList[i];
                iResult = CaculateResult(wepon);
                this.ResultShow.Text += iResult.message + "\n";
                WeponInfoList.Remove(wepon);
                if (iResult.success == true)
                {
                    InitialBasicParam();
                    this.ResultShow.Text += "---------------------------------------------------\n";
                    return iResult;
                }
                else
                {
                }
            }
            this.ResultShow.Text += "各种爆啊你妹" + "\n\r";
            this.ResultShow.Text += "---------------------------------------------------\n";
            totalTired++;
            if(!FStatic.ContainsKey(totalTired))
            {
                FStatic.Add(totalTired, iResult.message);
            }
           
           MessageBox.Show("死心吧混蛋");
            InitialBasicParam();
            this.ResultShow.Text += "---------------------------------------------------\n";
            this.label1.Text = totalTired.ToString();
            return iResult;
            //TestRate();
        }



        /// <summary>
        /// 获取装备价值
        /// </summary>
        /// <returns></returns>
        public double GetWeponValue()
        {
            return WeponInfoList.Where(c=>c.status==1).Select(c => c.curCost).Sum();

        }

        /// <summary>
        /// 测试概率
        /// </summary>
        public void TestRate()
        {
            for (var i = 0; i <= 7; i++)
            {
                var result=GetResult();
                if (result.success == true)
                {
                    totalSucceedCount++;
                }
                else
                {
                    totalFalseCount++;
                }
            }
            MessageBox.Show(string.Format("succeed:{0},false{1} 概率：{2}", totalSucceedCount, totalFalseCount, decimal.Round(decimal.Parse(totalSucceedCount.ToString()) / (totalSucceedCount + totalFalseCount) * 100, 2))); 
      
        }
        /// <summary>
        /// 计算结果
        /// </summary>
        /// <returns></returns>
        public InvokeResult CaculateResult(Wepon wepon)
        {
            Thread.Sleep(10);  
            var result = new InvokeResult();
            string operateInfo=string.Empty;
            wepon.curForceLevel+=1;
            myOwnCoins -= wepon.forceCost;
          
            var cresult = GetResult();
            if (cresult.success == true)//成功失败
            {
                result.success = true;
                wepon.status = 0;
                myOwnCoins+=wepon.nextForceLevelCost;
                wepon.curCost = wepon.nextForceLevelCost;
                SucceedWeponInfoList.Add(wepon);
                var WeponValue = GetWeponValue();
                operateInfo += string.Format("【{7}】强化{0} +{1}成功 强化费用{4} 成功赚取{2} 当前拥有{3} 装备{5} 总价值：{6}", wepon.name, wepon.curForceLevel, wepon.nextForceLevelCost, myOwnCoins, wepon.forceCost, WeponValue, WeponValue + myOwnCoins, cresult.value);
            }
            else
            {
                result.success = false;
                wepon.status=0;
                var WeponValue = GetWeponValue();
                operateInfo += string.Format("【{6}】强化{0} +{1} 失败  强化费用{2}        当前拥有{3}  装备{4} 总价值：{5}", wepon.name, wepon.curForceLevel, wepon.forceCost, myOwnCoins, WeponValue, WeponValue + myOwnCoins, cresult.value);
                DestoryWeponInfoList.Add(wepon);
            }
            result.message = operateInfo;
            return result;
        }


        /// <summary>
        /// 是否成功 ，成功概率为34%
        /// </summary>
        /// <returns></returns>
        public InvokeResult GetResult()
        {
            InvokeResult result = new InvokeResult();
            if (useAdvanceC)
            {
                currentRate = FORCERATE * 1.1;
            }
            var getNumber = rnd.Next(MinValue, MaxValue);
            result.value = getNumber;
           // MessageBox.Show(currentRate.ToString());
            if (getNumber <= currentRate)
            {
                result.success = true;
                result.message = (getNumber.ToString() + "成功");
              //  MessageBox.Show(getNumber.ToString()+"成功");
               // this.ResultShow.Text += getNumber.ToString() + "成功";
                return result;
            }
            else
            {
                result.success = false;
                result.message = (getNumber.ToString() + "失败");
              //  MessageBox.Show(getNumber.ToString() + "失败");
               // this.ResultShow.Text += getNumber.ToString() + "失败";
                return result;
            }
        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        public void InitialBasicParam()
        {
            currentRate = FORCERATE;
            if (WeponInfoList == null)
            {
                WeponInfoList = new List<Wepon>();
            }
            SucceedWeponInfoList = new List<Wepon>();
            DestoryWeponInfoList = new List<Wepon>();
            if (CanHuamDisturb.Checked)
            {
                humanDisturb = true;
            }
            else
            {
                humanDisturb = false;
            }

            if (CanUserAdvanceC.Checked)
            {
                useAdvanceC = true;
            }
            else
            {
                useAdvanceC = false;
            }
            var ownWeponQuery=WeponInfoList.Select(c=>c.name);
            var hitQuery = InitWeponInfoList.Where(c => !ownWeponQuery.Contains(c.name));
            double totolaCost = 0;
            foreach (var wepon in InitWeponInfoList)
            {
                if (!string.IsNullOrEmpty(wepon.name.Trim()))
                {
                
                    if (WeponInfoList.Where(c => c.name.Trim() == wepon.name.Trim()).Count() <= 0)
                    {
                        var newCopyOne =InitialWepon(wepon.initialStr);
                        WeponInfoList.Add(newCopyOne);
                        if (myOwnCoins-wepon.curCost <= 0)
                        {
                            this.ResultShow.Text += "弱爆了 你没钱了";
                            break;
                        }
                        myOwnCoins -= wepon.curCost;
                        totolaCost += wepon.curCost;
                        this.ResultShow.Text += string.Format("花费{0}买了+{1} {2} 剩余：{3}\r\n", wepon.curCost, wepon.curForceLevel, wepon.name, myOwnCoins);
                    }
                }
            }
            var weaponValue = GetWeponValue();
            this.ResultShow.Text += string.Format("此次花费{0} 余额{1} 目前装备总价：{2} 总计：{3}\n\r", totolaCost, myOwnCoins, weaponValue, weaponValue + myOwnCoins);
                
            
         
        }


        /// <summary>
        /// 名称|等级|价格|下一级价格
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public Wepon InitialWepon(string weponInfo)
        {
            
            var curWepon=new Wepon();
            if (string.IsNullOrEmpty(weponInfo))
            {
                return curWepon;
            }
            try{

                var strArray = weponInfo.Split('|');
                if(strArray.Length>=3)
                {
                  curWepon.name=strArray[0];
                  curWepon.status = 1;
                  curWepon.curForceLevel = 10;
                  curWepon.Level = int.Parse(strArray[1]);
                  curWepon.curCost = double.Parse(strArray[2]);
                  curWepon.initialStr = weponInfo;
                  if (strArray.Length >= 4)
                  {
                      curWepon.nextForceLevelCost = double.Parse(strArray[3]);
                  }
                  else
                  {
                      curWepon.nextForceLevelCost = 2 * curWepon.curCost;
                  }
                  if (strArray.Length >= 5)
                  {
                      curWepon.forceCost = double.Parse(strArray[4]);
                  }
                  else
                  {
                      if (curWepon.Level <= 10)
                      {
                          curWepon.forceCost = curWepon.Level * 300;
                      }
                      else if (curWepon.Level > 10 && curWepon.Level <40)
                      {
                          curWepon.forceCost = curWepon.Level * 800;
                      }
                      else if (curWepon.Level >= 40)
                      {
                          curWepon.forceCost = curWepon.Level * 3000;
                      }
                  }
                  
                }
            }
            catch (InvalidCastException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return curWepon;
        
        }

         /// <summary>
        /// 
        /// </summary>
        public class Wepon
        {
          public  string name { get; set; }//名称
          public double curCost { get; set; }//当前花费
          public int curForceLevel { get; set; }//当前force等级
          public int Level { get; set; }//wepon等级
          public double nextForceLevelCost { get; set; }//下一级价格
          public int status { get; set; }//状态
          public double forceCost { get; set; }//force费用
          public string initialStr { get; set; }
          public string order { get; set; }
          //public Wepon Copy()
          //{
          //    return new Wepon() { name = name, curCost = curCost, curForceLevel = curForceLevel, forceCost = forceCost, status = status, nextForceLevelCost = nextForceLevelCost, Level=Level };
          //}
       }

        public class InvokeResult
        {
             public string message { get; set; }
             public object value { get; set; }
             public bool success { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                totalFalseCount = 0;
                totalSucceedCount = 0;
                InitWeponInfoList = new List<Wepon>();
                if (string.IsNullOrEmpty(this.WeponSourceList.Text))
                this.WeponSourceList.Text = "粗布拖鞋|0|120000|240000  \r\n 破旧的太|1|130000|300000 \r\n 蓝太|30|300000|600000 \r\n  锋利的长|40|600000|1200000 \r\n 影虎|45|1200000|2400000 \r\n 55蓝|55|3000000|6000000 \r\n 60紫|60|6000000|12000000 \r\n 65紫|65|12000000|24000000 \r\n  60粉|66|24000000|48000000  ";
                var weponStr = this.WeponSourceList.Text.Trim();

                var weponStrArray = weponStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                 var InitWeponInfoQuery= InitWeponInfoList.Select(c=>c.name);
                foreach (var weponInfo in weponStrArray)
                {
                    if (!string.IsNullOrEmpty(weponInfo.Trim()))
                    {
                        var wepon = InitialWepon(weponInfo);
                        if (!InitWeponInfoQuery.Contains(wepon.name))
                        {
                            InitWeponInfoList.Add(wepon);
                        }
                       // myOwnCoins -= wepon.curCost;
                       //this.ResultShow.Text += string.Format("花费{0}买了+{1} {2} 剩余：{3}\r\n", wepon.curCost, wepon.curForceLevel, wepon.name, myOwnCoins);
                       
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            totalTired = 0;
           
           
            Form1_Load( sender,  e);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            currentRate = FORCERATE;
            if (CanHuamDisturb.Checked)
            {
                humanDisturb = true;
            }
            else
            {
                humanDisturb = false;
            }

            if (CanUserAdvanceC.Checked)
            {
                useAdvanceC = true;
            }
            else
            {
                useAdvanceC = false;
            }
            var times = 10;
            var sCount = 8;
            try
            {
             times =int.Parse( this.Round.Text.Trim());
             sCount = int.Parse(this.securityCount.Text.Trim());
            }
            catch (Exception ex)
            { 
               
            }
            var testBool=false;
            var errorTimes = 0;
            for (var i = 0; i < times; i++)
            {
                var errorStr = string.Empty;
                for (var j = 1; j <= sCount; j++)
                {
                    var result=GetResult();
                    errorStr += result.message;
                    if (result.success == true)
                    {
                        testBool = true;
                        break;
                    }
                }
                if (testBool == false)
                {
                   // this.ResultShow.Text += errorStr;
                   // this.ResultShow.Text += "\n\r";
                    errorTimes++;
                }
                testBool = false;
                
            }

            string curShowText = string.Format("总共执行{0}此,完全失败个数{1}概率为{2}% \r\n", times, errorTimes, decimal.Round(decimal.Parse(errorTimes.ToString()) / times * 100, 2));
             MessageBox.Show(curShowText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            var resultText = new StringBuilder();
            this.ResultShow.Text += "红球区:";
            for (var i = 0; i <= 5; i++)
            { 
                var redNumber = ChanceTicke(1,33);
                resultText.Append(redNumber);
                if (i != 5)
                {
                    resultText.Append(',');
                }
            }
            this.ResultShow.Text += resultText.ToString();
            rnd = new Random();
            this.ResultShow.Text += "蓝球球区:";
            var blueNumber = ChanceTicke(1, 16);
            this.ResultShow.Text += blueNumber;
           
        }

        public int ChanceTicke(int min,int max)
        {
            var getNumber = rnd.Next(min, max);
            return getNumber;
        }

        




    }
}
