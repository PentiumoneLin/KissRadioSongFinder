using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KissSongFinder
{
    /// <summary>
    /// 這裡的安排是以一個主體視窗為主，其他子視窗互相不干擾
    /// </summary>
    class FormMovingControl
    {
        #region Property
        /// <summary>
        /// 呼叫此類別的FORM
        /// </summary>
        public Form Controler
        {
            get { return m_Controler; }
            set
            {
                m_Controler = value;
            }
        }

        
        /// <summary>
        /// 用於設置其他窗體的Location
        /// </summary>
        private Point tmp = new Point();
        /// <summary>        
        /// 設置或獲取Form左邊x作標
        /// </summary>
        public int LeftX
        {
            get { return this.leftX; }
            set { this.leftX = value; }
        }
        /// <summary>
        /// 設置或獲取Form右邊x作標
        /// </summary>
        public int RightX
        {
            get { return this.rightX; }
            set { this.rightX = value; }
        }
        /// <summary>
        /// 設置或獲取Form上方x作標
        /// </summary>
        public int TopY
        {
            get { return this.topY; }
            set { this.topY = value; }
        }
        /// <summary>
        /// 設置或獲取Form下方x作標
        /// </summary>
        public int BottomY
        {
            get { return this.bottomY; }
            set { this.bottomY = value; }
        }
        public bool MoveSelf
        {
            get { return this.moveSelf; }
            set { this.moveSelf = value; }
        }
        #endregion

        #region Field
        private Form m_Controler = null;

        private int leftX;
        private int rightX;
        private int topY;
        private int bottomY;
        private int HorizonLength; //計算發生重疊的水平長度
        private int VerticalLength;//計算發生重疊的垂直長度
        private bool moveSelf;        

        #endregion

        public FormMovingControl(Form thisForm)
        {
            m_Controler = thisForm;

            m_Controler.Move += new EventHandler(m_Controler_Move);            
        }

        void m_Controler_Move(object sender, EventArgs e)
        {
            this.LeftX = m_Controler.Location.X;
            this.RightX = m_Controler.Location.X + m_Controler.Width;
            this.TopY = m_Controler.Location.Y;
            this.BottomY = m_Controler.Location.Y + m_Controler.Height;
            //OthersFormMoving();
        }

        /// <summary>
        /// 設置其他窗體移動
        /// </summary>
        //private void OthersFormMoving()
        //{
        //    foreach (MagneticForm form in this.FormList)
        //    {
        //        HorizonLength = 0;
        //        VerticalLength = 0;
        //        ///判断是从哪个方向靠近费了很大力气没有上面两个变量就没法区分发生重叠时候从哪个方向靠近

        //        //从左边靠近
        //        if ((this.RightX >= form.LeftX && this.leftX < form.LeftX) && !(this.TopY >= form.BottomY || this.BottomY <= form.TopY))
        //        {

        //            //tmp.X = this.RightX+form.Width;方法一
        //            //tmp.Y = this.TopY; 方法一
        //            //form.Moving(tmp); 方法一

        //            //以下为方法二
        //            VerticalLength = (this.BottomY < form.BottomY ? this.BottomY : form.BottomY) - (this.topY < form.TopY ? form.TopY : this.TopY);
        //            HorizonLength = this.RightX - form.LeftX;
        //            ///重叠的水平长度大于等垂直长度说明是从左靠近
        //            if (VerticalLength >= HorizonLength) //不成立则是上下靠近
        //            {
        //                //方法二 移动自己
        //                if (this.MoveSelf == true)
        //                {
        //                    tmp.X = form.LeftX - this.Width;
        //                    tmp.Y = form.TopY;
        //                    this.Moving(tmp);
        //                }
        //                else //方法一移动其他的
        //                {
        //                    tmp.X = this.Left + this.Width;
        //                    tmp.Y = this.TopY;
        //                    form.Moving(tmp);

        //                }
        //                continue;
        //            }
        //        }

        //        //从右边靠近
        //        if ((this.RightX > form.RightX && this.leftX <= form.RightX) && !(this.TopY >= form.BottomY || this.BottomY <= form.TopY))
        //        {
        //            // 方法一
        //            //tmp.X = this.LeftX - form.Width;
        //            //tmp.Y = form.TopY;
        //            //form.Moving(tmp); 方法一
        //            // //方法二
        //            VerticalLength = (this.BottomY < form.BottomY ? this.BottomY : form.BottomY) - (this.topY < form.TopY ? form.TopY : this.TopY);
        //            HorizonLength = form.RightX - this.LeftX;
        //            ///重叠的水平长度大于等垂直长度说明是从右靠近
        //            if (VerticalLength >= HorizonLength) //不成立则是上下靠近
        //            {
        //                if (this.MoveSelf) //方法二
        //                {
        //                    tmp.X = form.RightX;
        //                    tmp.Y = form.TopY;
        //                    this.Moving(tmp);
        //                }
        //                else //一
        //                {
        //                    tmp.X = this.LeftX - form.Width;
        //                    tmp.Y = this.TopY;
        //                    form.Moving(tmp);
        //                }
        //                continue;
        //            }
        //        }

        //        //往上边靠近
        //        if ((this.TopY <= form.BottomY && this.BottomY > form.BottomY) && !(this.RightX <= form.LeftX || this.Left >= form.RightX))
        //        {
        //            //方法一
        //            //tmp.X = this.LeftX;
        //            //tmp.Y = this.BottomY;
        //            //form.Moving(tmp);
        //            //方法二
        //            if (this.MoveSelf)
        //            {
        //                tmp.X = form.LeftX;
        //                tmp.Y = form.BottomY;
        //                this.Moving(tmp);
        //            }
        //            else
        //            {
        //                tmp.X = this.LeftX;
        //                tmp.Y = this.TopY - form.Height;
        //                form.Moving(tmp);
        //            }
        //            continue;
        //        }

        //        //往下边靠近
        //        if ((this.BottomY >= form.TopY && this.TopY < form.TopY) && !(this.RightX <= form.LeftX || this.Left >= form.RightX))
        //        {
        //            //方法一
        //            //tmp.X = this.LeftX;
        //            //tmp.Y = this.TopY-form.Height;
        //            //form.Moving(tmp);  

        //            //方法二
        //            if (this.MoveSelf)
        //            {
        //                tmp.X = form.LeftX;
        //                tmp.Y = form.TopY - this.Height;
        //                this.Moving(tmp);
        //            }
        //            else
        //            {
        //                tmp.X = this.LeftX;
        //                tmp.Y = this.BottomY;
        //                form.Moving(tmp);
        //            }
        //            continue;
        //        }
        //        /**/
        //        //左右翻转模式 得把上面的全 注释了
        //        //if ((this.RightX >= form.LeftX) && !(this.TopY > form.BottomY || this.BottomY < form.TopY))
        //        //{
        //        // tmp.X = this.RightX;
        //        // tmp.Y = this.TopY;
        //        // form.Moving(tmp);
        //        // continue;
        //        //}
        //    }
        //}

        /// <summary>
        /// 窗體移動
        /// </summary>
        /// <param name="pt">要移動的座標，左上角</param>
        public void Moving(Point pt)
        {
            //方法二移動自己
            if (this.MoveSelf)
            {
                m_Controler.Location = pt;
            }
            else
            {
                //方法一一動其他窗體如果不這樣先處理的話會造成死鎖。
                m_Controler.Move -= new System.EventHandler(this.m_Controler_Move);
                m_Controler.Location = pt;
                m_Controler.Move += new System.EventHandler(this.m_Controler_Move);
            }


        }
    }
}
