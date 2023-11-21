using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace GSC_LAB5
{

    public partial class Form1 : Form
    {
        private GLControl glControl1;
        public Form1()
        {
            InitializeComponent();
            glControl1 = new GLControl();
            //создаются обработчики событий для glControl
            glControl1.Resize += GLControl_Resize; // события Resize
            glControl1.Load += GLControl_Load;
            glControl1.Paint += GLControl_Paint;
            glControl1.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(glControl1);
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
        }
        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(1, 1, 1, 1);

        }
        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            double k  = 0.00392156862;
            // очистка буферов цвета и глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            // настройка ортогональной проекции
            GL.Ortho(0.0, 30.0, 0.0, 30.0, -10, 10);
            //песок
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(242 * k, 208 * k, 39 * k);
            GL.Vertex2(0, 0);
            GL.Vertex2(0, 9);
            GL.Vertex2(30, 9);
            GL.Vertex2(30, 0);
            GL.End();
            //болото
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(10 * k, 154 * k, 173 * k);
            GL.Vertex2(0, 9);
            GL.Vertex2(0, 16.5);
            GL.Vertex2(30, 16.5);
            GL.Vertex2(30, 9);
            GL.End();
            //типо небо
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(84 * k, 235 * k, 255 * k);
            GL.Vertex2(0, 16.5);
            GL.Vertex2(0, 30);
            GL.Vertex2(30, 30);
            GL.Vertex2(30, 16.5);
            GL.End();
            //Солнце
            GL.Color3(252 * k, 229 * k, 23 * k);
            DrawCircle(4.5, 27, 2);
            //Облака
            GL.Color3(228 * k, 241 * k, 242 * k);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(9, 22.5);
            GL.Vertex2(9, 25.5);
            GL.Vertex2(15, 25.5);
            GL.Vertex2(15, 22.5);
            GL.End();
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(15, 25.5);
            GL.Vertex2(15, 28.5);
            GL.Vertex2(18, 28.5);
            GL.Vertex2(18, 25.5);
            GL.End();
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(19.5, 24);
            GL.Vertex2(19.5, 25.5);
            GL.Vertex2(22.5, 25.5);
            GL.Vertex2(22.5, 24);
            GL.End();
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(21, 27);
            GL.Vertex2(21, 28.5);
            GL.Vertex2(27, 28.5);
            GL.Vertex2(27, 27);
            GL.End();
            //Волны
            GL.LineWidth(4f);
            GL.Color3(230 * k, 247 * k, 242 * k);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(3, 13.5); GL.Vertex2(7.5, 13.5);
            GL.Vertex2(9, 12); GL.Vertex2(13.5, 12);
            GL.Vertex2(12, 15); GL.Vertex2(15, 15);
            GL.Vertex2(18, 10.5); GL.Vertex2(21, 10.5);
            GL.Vertex2(18, 13.5); GL.Vertex2(27, 13.5);
            GL.End();

            //Камни
            GL.Color3(0.8f, 0.8f, 0.8f);
            DrawCircle(3.75, 5.25, 1);
            GL.Color3(161 * k, 154 * k, 119 * k);
            DrawCircle(11.25, 6.75, 1);
            GL.Color3(161 * k, 154 * k, 119 * k);
            DrawCircle(12.75, 2.25, 1);
            GL.Color3(161 * k, 154 * k, 119 * k);
            DrawCircle(17.25, 6.75, 1);
            GL.Color3(161 * k, 154 * k, 119 * k);
            DrawCircle(18.75, 5.25, 1);
            GL.Color3(161 * k, 154 * k, 119 * k);
            DrawCircle(27.75, 6.75, 1);
            GL.PopMatrix();
            glControl1.SwapBuffers();
            glControl1.Invalidate();
        }

        private void DrawCircle(double xc, double yc, double r)
        {
            double x, y;
            GL.Begin(PrimitiveType.TriangleFan); 

            GL.Vertex2(xc + 0.8f, yc + 0.3);
            GL.Vertex2(xc + 1, yc);
            for (int i = 0; i <= 30; i++)
            {
                x = xc + r * Math.Sin(i * Math.PI / 15);
                y = yc + r * Math.Cos(i * Math.PI / 15);
                GL.Vertex2(x, y);
            }
            GL.End();
        }

    }
}