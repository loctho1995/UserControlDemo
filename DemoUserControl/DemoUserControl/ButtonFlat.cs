using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QuanLyHocSinh
{
    [DefaultEvent("Click")]
    public partial class ButtonFlat : UserControl
    {
        #region - ENUMS, ATTRIBUTES. PROPERTIES - 
        public enum MouseStates
        {
            Hover, Down, Up, Enter, Leave
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get;
            set;
        }

        MouseStates m_mouseState = MouseStates.Leave;
        MouseStates MouseState
        {
            get { return m_mouseState; }
            set { m_mouseState = value; }
        }

        public enum BTTextAlignment
        {
            Center, Top, Bot
        }
        BTTextAlignment m_textAlignment = BTTextAlignment.Bot;
        public BTTextAlignment TextAlignment
        {
            get { return m_textAlignment; }
            set { m_textAlignment = value; this.Invalidate(); }
        }        

        //do trong suot toi da, dung cho hieu ung sang cua button khi mouse hover, default = 20
        int m_alphaGlow;
        public int AlphaGlow
        {
            get { return m_alphaGlow; }
            set { m_alphaGlow = value; this.Invalidate(); }
        }

        //do bien thien alphaGlow theo thoi gian
        int m_deltaAlphaGlow;
        public int DeltaAlphaGlow
        {
            get { return m_deltaAlphaGlow; }
            set { m_deltaAlphaGlow = value; this.Invalidate(); }
        }

        //do trong suot toi da
        int m_alphaGlowValue;
        public int AlphaGlowValue
        {
            get { return m_alphaGlowValue; }
            set { m_alphaGlowValue = value; this.Invalidate(); }
        }

        //mau dung cua user control
        Color m_backColor;
        public Color RealBackColor
        { 
            get { return m_backColor; }
            set { m_backColor = value; }
        }


        Timer m_timer;
        bool m_isMouseDowning; // chuot luc nay dang nhap chua co up, luc nay phai bo su kien Hover
        
        #endregion

        #region -INIT AND TIMER-
        public ButtonFlat()
        {
            #region -INIT- 
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            m_backColor = Color.AliceBlue;

            m_alphaGlow = 40;
            m_deltaAlphaGlow = 8;

            m_timer = new Timer();
            m_timer.Interval = 50;
            m_timer.Tick += m_timer_Tick;
            m_timer.Enabled = true;
            m_timer.Stop();
            #endregion
        }


        void m_timer_Tick(object sender, EventArgs e)
        {
            switch (m_mouseState)
            {
                case MouseStates.Hover:

                    if (m_alphaGlowValue < m_alphaGlow)
                    {
                        m_alphaGlowValue += m_deltaAlphaGlow;
                    }
                    else
                    {
                        m_alphaGlowValue = m_alphaGlow;
                        m_timer.Stop();
                    }

                    this.Invalidate();
                    break;

                case MouseStates.Leave:

                    if (m_alphaGlowValue > 0)
                    {
                        m_alphaGlowValue -= m_deltaAlphaGlow;
                    }
                    else
                    {
                        m_alphaGlowValue = 0;
                        m_timer.Stop();
                    }

                    this.Invalidate();
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region -DRAW EVENTS-
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //set region
            GraphicsPath graphicspath = new GraphicsPath();
            graphicspath.AddEllipse(this.ClientRectangle);
            this.Region = new System.Drawing.Region(graphicspath);

            Rectangle fakeRect = new Rectangle(2, 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4);
            Bitmap bm = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            Graphics gp = Graphics.FromImage(bm);

            gp.SmoothingMode = SmoothingMode.AntiAlias;

            // draw face
            gp.FillEllipse(new SolidBrush(m_backColor), fakeRect);

            switch (m_mouseState)
            {
                case MouseStates.Down:
                    //cho nen control toi lai
                    gp.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.Black)), fakeRect);
                    break;

                case MouseStates.Leave:
                case MouseStates.Hover:
                    gp.FillEllipse(new SolidBrush(Color.FromArgb(m_alphaGlowValue, Color.White)), fakeRect);
                    break;

                default:
                    break;
            }
            
            e.Graphics.DrawImage(bm, new Point(0, 0));

            SizeF textSize1 = e.Graphics.MeasureString(this.Text, this.Font);

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor),
                                    new PointF(this.Width / 2 - textSize1.Width / 2, this.Height / 2 - textSize1.Height / 2));

            base.OnPaint(e);
        }
        #endregion

        #region -MOUSE EVENTS-
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!m_isMouseDowning)
            {
                m_mouseState = MouseStates.Hover;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_mouseState = MouseStates.Enter;

            base.OnMouseEnter(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (!m_isMouseDowning)
            {
                m_mouseState = MouseStates.Hover;
                m_timer.Start();
            }

            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_isMouseDowning = false;
            m_mouseState = MouseStates.Leave;
            m_timer.Start();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_mouseState = MouseStates.Down;
            m_isMouseDowning = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            m_mouseState = MouseStates.Up;
            m_isMouseDowning = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }
        #endregion
    }
}
