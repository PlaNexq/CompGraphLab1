using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace compGraphLab1
{
    public partial class Form1 : Form
    {
        Pen meshPen;
        Surface surface;
        float RotationX = 0f;
        float RotationY = 0f;
        float RotationZ = 0f;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            meshPen = new Pen(Color.Black, 1);
            GraphicsEngine.RecalcGeneral(RotationX, RotationY, RotationZ);

            List<Vector3> points = new List<Vector3> { { new Vector3(50, 50, 2) }, { new Vector3(25, 25, 2) }, { new Vector3(50, 25, 2) } };
            List<int> polys = new List<int> { 0, 1, 2 };


            surface = new Surface(points, polys);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            surface.DrawMesh(e.Graphics, meshPen);
        }

        private void trackBarX_ValueChanged(object sender, EventArgs e)
        {
            RotationX = (float)(Math.PI/180) * trackBarX.Value;
            GraphicsEngine.RecalcGeneral(RotationX, RotationY, RotationZ);
            pictureBox1.Refresh();

        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            RotationY = (float)(Math.PI / 180) * trackBarY.Value;
            GraphicsEngine.RecalcGeneral(RotationX, RotationY, RotationZ);
            pictureBox1.Refresh();

        }

        private void trackBarZ_ValueChanged(object sender, EventArgs e)
        {
            RotationZ = (float)(Math.PI / 180) * trackBarZ.Value;
            GraphicsEngine.RecalcGeneral(RotationX, RotationY, RotationZ);
            pictureBox1.Refresh();

        }
    }
    static class Equations
    {
        public static List<List<Vector3>> GetTris(double R, double r, int u_count, int v_count, double limit_u, double limit_v)
        {
            var du = 360 / limit_u;
            var dv = 360 / limit_v;
            return new List<List<Vector3>> { };
        }
        public static List<List<Vector3>> Sphere()
        {
            return null;
        }
    }

    class Surface
    {
        public List<Vector3> m_Points;
        List<Vector3> m_TransformedPoints;
        public List<PointF> m_ScreenPoints;
        List<Polygon> m_Polygons;

        Color InsideColour = Color.Red;
        Color OutsideColour = Color.Blue;
        public Surface(List<Vector3> points, List<int> polys)
        {
            m_Points = points;
            m_Polygons = new List<Polygon>();
            for (int i = 0; i < polys.Count / 3; i++)
            {
                var buf = new Polygon(polys.GetRange(i * 3, 3), this);
                m_Polygons.Add(buf);
            }
            Calculate();
        }
        public void DrawMesh(Graphics g, Pen pen)
        {
            Calculate();

            foreach (var tri in m_Polygons)
            {
                tri.DrawMesh(g, pen);
            }
        }
        public void FillColour()
        {

        }

        void Calculate()
        {
            m_TransformedPoints = new List<Vector3>();
            for (int i = 0; i < m_Points.Count; i++)
            {
                var point = GraphicsEngine.General.Multiply(new Vector4(m_Points[i], 1));
                m_TransformedPoints.Add(new Vector3(point.X, point.Y, point.Z));
            }
            m_ScreenPoints = new List<PointF>();

            for (var i = 0; i < m_TransformedPoints.Count; i++)
            {
                m_ScreenPoints.Add(Project(m_TransformedPoints[i]));
            }
        }

        PointF Project(Vector3 b)
        {
            var projMat = new Matrix4();


            return new PointF(b.X, b.Y);
        }
    }

    class Polygon
    {
        List<int> PointIndexes;
        Surface parent;

        public Polygon(List<int> pointIndexes, Surface parent)
        {
            PointIndexes = pointIndexes;
            this.parent = parent;
        }

        public void DrawMesh(Graphics g, Pen pen)
        {
            var p = new PointF[3] { parent.m_ScreenPoints[PointIndexes[0]], parent.m_ScreenPoints[PointIndexes[1]], parent.m_ScreenPoints[PointIndexes[2]] };

            g.DrawPolygon(pen, p);
        }

        void FillColour()
        {

        }
    }

    class Matrix4
    {
        public float[,] contents;
        public Matrix4()
        {
            this.contents = new float[4, 4] { {0,0,0,0}, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        }
        public Matrix4(float[,] contents)
        {
            this.contents = contents;
        }
        public Vector4 Multiply(Vector4 b)
        {
            return new Vector4(
                b.X * contents[0, 0] + b.Y * contents[0, 1] + b.Z * contents[0, 2] + b.W * contents[0, 3],
                b.X * contents[1, 0] + b.Y * contents[1, 1] + b.Z * contents[1, 2] + b.W * contents[1, 3],
                b.X * contents[2, 0] + b.Y * contents[2, 1] + b.Z * contents[2, 2] + b.W * contents[2, 3],
                b.X * contents[3, 0] + b.Y * contents[3, 1] + b.Z * contents[3, 2] + b.W * contents[3, 3]);
        }
        public Matrix4 Multiply(Matrix4 m)
        {
            float[,] buf = contents;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    buf[i, j] = calcCell(i, j, m.contents);
            return new Matrix4(buf);
        }
        private float calcCell(int row, int column, in float[,] secondMat)
        {
            return contents[row, 0] * secondMat[0, column] + contents[row, 1] * secondMat[1, column] + contents[row, 2] * secondMat[2, column] + contents[row, 3] * secondMat[3, column];
        }
    }

    static class GraphicsEngine
    {
        public static Matrix4 General = new Matrix4(new float[4, 4] { { 1, 0, 0, 0 },
                                                                      { 0, 1, 0, 0 },
                                                                      { 0, 0, 1, 0 },
                                                                      { 0, 0, 0, 1 }}
        );

        public static void RecalcGeneral(float rotX, float rotY, float rotZ)
        {
            General = new Matrix4(new float[4, 4] { { 1, 0, 0, 0 },
                                                    { 0, 1, 0, 0 },
                                                    { 0, 0, 1, 0 },
                                                    { 0, 0, 0, 1 }}
            );
            var Rx = new Matrix4();
            Rx.contents[0, 0] = 1;
            Rx.contents[1, 1] = (float)Math.Cos(rotX); Rx.contents[1, 2] = (float)Math.Sin(rotX);
            Rx.contents[2, 1] = -(float)Math.Sin(rotX); Rx.contents[2, 2] = (float)Math.Cos(rotX);
            Rx.contents[3, 3] = 1;

            var Ry = new Matrix4();
            Ry.contents[0, 0] = (float)Math.Cos(rotY); Ry.contents[0, 2] = -(float)Math.Sin(rotY);
            Ry.contents[1, 1] = 1;
            Ry.contents[2, 0] = (float)Math.Sin(rotY); Ry.contents[2, 2] = (float)Math.Cos(rotY);
            Ry.contents[3, 3] = 1;

            var Rz = new Matrix4();
            Rz.contents[0, 0] = (float)Math.Cos(rotZ); Rz.contents[0, 1] = (float)Math.Sin(rotZ);
            Rz.contents[1, 0] = -(float)Math.Sin(rotZ); Rz.contents[1, 1] = (float)Math.Cos(rotZ);
            Rz.contents[2, 2] = 1;
            Rz.contents[3, 3] = 1;

            General = General.Multiply(Rx);
            General = General.Multiply(Ry);
            General = General.Multiply(Rz);

        }

        public static Vector3 Newell(Polygon p)
        {
            return Vector3.Zero;
        }
    }
}

