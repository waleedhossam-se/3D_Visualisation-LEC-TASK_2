using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Lec
{
    public partial class Form1 : Form
    {
        Bitmap off;


        _3D_Model plane1 = new _3D_Model();
        _3D_Model plane2 = new _3D_Model();
        _3D_Model plane3 = new _3D_Model();


        _3D_Model plane1a = new _3D_Model();
        _3D_Model plane2a = new _3D_Model();
        _3D_Model plane3a = new _3D_Model();



        _3D_Model plane1b = new _3D_Model();
        _3D_Model plane2b = new _3D_Model();
        _3D_Model plane3b = new _3D_Model();



        _3D_Model bs1 = new _3D_Model();
        _3D_Model bs2 = new _3D_Model();
        _3D_Model bs3 = new _3D_Model();
        _3D_Model bs4 = new _3D_Model();
        _3D_Model bs5 = new _3D_Model();
        _3D_Model bs6 = new _3D_Model();        
        _3D_Model bs7 = new _3D_Model();
        _3D_Model bs8 = new _3D_Model();
        _3D_Model bs9 = new _3D_Model();
        _3D_Model bs10 = new _3D_Model();
        _3D_Model bs11 = new _3D_Model();
        _3D_Model bs12 = new _3D_Model();

        _3D_Model door1 = new _3D_Model();
        _3D_Model door2 = new _3D_Model();


        _3D_Model bsm1 = new _3D_Model();
        _3D_Model bsm2 = new _3D_Model();
        _3D_Model ss1 = new _3D_Model();
        _3D_Model ss2 = new _3D_Model();
        //_3D_Model smll_plane = new _3D_Model();
       
        List<_3D_Model> smallCubes = new List<_3D_Model>();



     

        Camera Cam;

        Timer tt = new Timer();
        int ctTick = 0;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            tt.Tick += tt_Tick;
             tt.Interval = 16;
            tt.Start();
        }
        void dosomething()
        {
            for (int i = 0; i < smallCubes.Count; i++)
            {
                if (smallCubes[i].moving)
                {
                    Transformation.TranslateY(smallCubes[i].L_3D_Pts, -5);
                    if (smallCubes[i].L_3D_Pts[0].Y <= plane2a.L_3D_Pts[0].Y)
                    {
                        smallCubes[i].moving = false;
                    }
                }
            }


            if (ctTick % 15 == 0)
            {
                _3D_Model pnn = new _3D_Model();

                CreateCube(pnn, 0, 646, 90);
                smallCubes.Add(pnn);
            }
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                for (int i = 0; i < bs1.L_3D_Pts.Count; i++)
                {
                    bs1.L_3D_Pts[i].Z -=  10;
                    bs2.L_3D_Pts[i].Z -=  10;
                    bs3.L_3D_Pts[i].Z -=  10;
                    bs4.L_3D_Pts[i].Z -=  10;
                    bs5.L_3D_Pts[i].Z -=  10;
                    bs6.L_3D_Pts[i].Z -=  10;
                    bs7.L_3D_Pts[i].Z -=  10;
                    bs8.L_3D_Pts[i].Z -=  10;
                    bs9.L_3D_Pts[i].Z -=  10;
                    bs10.L_3D_Pts[i].Z -= 10;
                    bs11.L_3D_Pts[i].Z -= 10;
                    bs12.L_3D_Pts[i].Z -= 10;

                    bsm1.L_3D_Pts[i].Z -= 10;
                    bsm2.L_3D_Pts[i].Z -= 10;
                    ss1.L_3D_Pts[i].Z -=  10;
                    ss2.L_3D_Pts[i].Z -=  10;
                }
            }
        }
        void GoBackwrd()
        {
            float diffX = Cam.lookAt.X - Cam.cop.X;
            float diffY = Cam.lookAt.Y - Cam.cop.Y;
            float diffZ = Cam.lookAt.Z - Cam.cop.Z;

            float step = 0.01f;

            Cam.cop.X -= diffX * step;
            Cam.cop.Y -= diffY * step;
            Cam.cop.Z -= diffZ * step;

            Cam.BuildNewSystem();



        }
        void GoTowrd()
        {
            float diffX = Cam.lookAt.X - Cam.cop.X;
            float diffY = Cam.lookAt.Y - Cam.cop.Y;
            float diffZ = Cam.lookAt.Z - Cam.cop.Z;

            float step = 0.01f;

            Cam.cop.X += diffX * step;
            Cam.cop.Y += diffY * step;
            Cam.cop.Z += diffZ * step;

            Cam.BuildNewSystem();



        }
        void GoUpDown()
        {

            //float step = 0.01f;

            //Cam.cop.Y += step;
            //Cam.BuildNewSystem();

        }
        void Rotaty()
        {
            float th = (float)(2 * Math.PI / 180);
            float x_ = (float)(Cam.cop.Z * Math.Sin(th) + Cam.cop.X * Math.Cos(th));
            float y_ = Cam.cop.Y;
            float z_ = (float)(Cam.cop.Z * Math.Cos(th) - Cam.cop.X * Math.Sin(th));

            Cam.cop.X = x_;
            Cam.cop.Z = z_;
            Cam.BuildNewSystem();

        }

        void Rotatz()
        {
            float th = (float)(2 * Math.PI / 180);

            float x_ = (float)(Cam.cop.X * Math.Cos(th) - Cam.cop.Y * Math.Sin(th));
            float y_ = (float)(Cam.cop.X * Math.Sin(th) + Cam.cop.Y * Math.Cos(th));
            float z_ = Cam.cop.Z;

            Cam.cop.X = x_;
            Cam.cop.Y = y_;

            Cam.BuildNewSystem();

        }

        void Rotatx(float th2)
        {
            float th = (float)(th2 * Math.PI / 180);
            float x_ = Cam.cop.X;
            float y_ = (float)(Cam.cop.Y * Math.Cos(th) - Cam.cop.Z * Math.Sin(th));
            float z_ = (float)(Cam.cop.Y * Math.Sin(th) + Cam.cop.Z * Math.Cos(th));


            Cam.cop.Y = y_;
            Cam.cop.Z = z_;
            Cam.BuildNewSystem();

        }
        void RotatPlane(_3D_Model pln, int i, int j)
        {
            _3D_Point v1 = new _3D_Point(pln.L_3D_Pts[i]);
            _3D_Point v2 = new _3D_Point(pln.L_3D_Pts[j]);

            Transformation.RotateArbitrary(pln.L_3D_Pts, v1, v2, 5f);
        }
        void tt_Tick(object sender, EventArgs e)
        {
            if (ctTick < 24)
            {
                bsm1.RotateAroundEdge(0, 2);

                _3D_Point v1 = new _3D_Point(bsm1.L_3D_Pts[0]);
                _3D_Point v2 = new _3D_Point(bsm1.L_3D_Pts[1]);
                Transformation.RotateArbitrary(ss1.L_3D_Pts, v1, v2, 2);

                bsm2.RotateAroundEdge(2, 2);

                v1 = new _3D_Point(bsm2.L_3D_Pts[2]);
                v2 = new _3D_Point(bsm2.L_3D_Pts[3]);
                Transformation.RotateArbitrary(ss2.L_3D_Pts, v1, v2, 2);
                //   ss2.RotateAroundEdge(1, 5); 

                //           plane1.RotateAroundEdge(3, 5);
                //           plane3.RotateAroundEdge(1, 5);
            }
           else if (ctTick < 60)
            {
                door1.RotateAroundEdge(1, 2);
                door2.RotateAroundEdge(3, 2);

     //           _3D_Point v1 = new _3D_Point(plane1.L_3D_Pts[1]);
     //           _3D_Point v2 = new _3D_Point(plane1.L_3D_Pts[2]);
     //
     //           Transformation.RotateArbitrary(plane1.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3.L_3D_Pts, v1, v2, 5);
            }
            else if (ctTick < 100)
            {
                GoTowrd();
     //           CreatePlane(plane1a, 200, 0, 0);
     //           CreatePlane(plane2a, 0, 0, 0);
     //           CreatePlane(plane3a, -200, 0, 0);
            }
            else if (ctTick < 100 + 24)
            {
                bs1.RotZ(-2);
                bs2.RotZ(-2);
                bs3.RotZ(-2);
                bs4.RotZ(-2);
                bs5.RotZ(-2);
                bs6.RotZ(-2);

                bs7.RotZ(-2);
                bs8.RotZ(-2);
                bs9.RotZ(-2);
                bs10.RotZ(-2);
                bs11.RotZ(-2);
                bs12.RotZ(-2);

                door1.RotZ(-2);
                door2.RotZ(-2);

                bsm1.RotZ(-2);
                bsm2.RotZ(-2);
                ss1.RotZ(-2);
                ss2.RotZ(-2);

                //  Rotatz();
                //
                //           plane1a.RotateAroundEdge(3, 5);
                //           plane3a.RotateAroundEdge(1, 5);
                //
            }
     //       else if (ctTick < 61 + 24 + 12)
     //       {
     //           _3D_Point v1 = new _3D_Point(plane1.L_3D_Pts[1]);
     //           _3D_Point v2 = new _3D_Point(plane1.L_3D_Pts[2]);
     //
     //           Transformation.RotateArbitrary(plane1a.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2a.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3a.L_3D_Pts, v1, v2, 5);
     //       }
     //       else if (ctTick < 61 + 24 + 12 + 12)
     //       {
     //           _3D_Point v1 = new _3D_Point(plane1.L_3D_Pts[1]);
     //           _3D_Point v2 = new _3D_Point(plane1.L_3D_Pts[2]);
     //
     //
     //           Transformation.RotateArbitrary(plane1.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3.L_3D_Pts, v1, v2, 5);
     //
     //           Transformation.RotateArbitrary(plane1a.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2a.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3a.L_3D_Pts, v1, v2, 5);
     //       }
     //       else if (ctTick < 110)
     //       {
     //           CreatePlane(plane1b, 200, 0, 0);
     //           CreatePlane(plane2b, 0, 0, 0);
     //           CreatePlane(plane3b, -200, 0, 0);
     //       }
     //       else if (ctTick < 110 + 24)
     //       {
     //
     //           plane1b.RotateAroundEdge(3, 5);
     //           plane3b.RotateAroundEdge(1, 5);
     //
     //       }
     //       else if (ctTick < 110 + 24 + 12)
     //       {
     //           _3D_Point v1 = new _3D_Point(plane1.L_3D_Pts[1]);
     //           _3D_Point v2 = new _3D_Point(plane1.L_3D_Pts[2]);
     //
     //
     //           Transformation.RotateArbitrary(plane1.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3.L_3D_Pts, v1, v2, 5);
     //
     //           Transformation.RotateArbitrary(plane1a.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2a.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3a.L_3D_Pts, v1, v2, 5);
     //
     //           Transformation.RotateArbitrary(plane1b.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane2b.L_3D_Pts, v1, v2, 5);
     //           Transformation.RotateArbitrary(plane3b.L_3D_Pts, v1, v2, 5);
     //       }
     //       else if (ctTick < 230)
     //       {
     //
     //
     //           dosomething();
     //
     //
     //
     //       }
     //       else if (ctTick < 260)
     //       {
     //           dosomething();
     //           GoBackwrd();
     //
     //       }
     //       else if (ctTick < 295)
     //       {
     //           dosomething();
     //           Rotatx(2);
     //
     //       }
     //       else if (ctTick < 310)
     //       {
     //           dosomething();
     //           Rotatx(-2);
     //
     //       }
     //       else if (ctTick < 315)
     //       {
     //           dosomething();
     //           Rotaty();
     //
     //       }
     //       else if (ctTick < 325)
     //       {
     //           dosomething();
     //           GoTowrd();
     //       }
     //       else
     //       {
     //           dosomething();
     //
     //       }

            
            ctTick++;
            DrawDubb(this.CreateGraphics());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        void CreatePlane(_3D_Model pln, float XS, float YS, float ZS)
        {
            float[] vert = 
                            { 
                                -100  ,  0  , 25  ,
                                100   , 0   , 25 ,
                                100   , 0   , -25,
                                -100  ,  0  , -25 
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 4; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                pln.AddPoint(pnn);
            }


            int[] Edges = {
                              0,1 ,
                              1,2 ,
                              2,3 ,
                              3,0
                          };
            j = 0;
            Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 4; i++)
            {
                pln.AddEdge(Edges[j], Edges[j + 1], Color.Red);

                j += 2;
            }
            pln.cam = Cam;
        }

        void Createdoor(_3D_Model M, float XS, float YS, float ZS, Color vvv)
        {
            float[] vert = 
                            { 
                                100  ,  100  , -25 ,
                                230   , 100   , -25,
                                230   , 500   , -25,
                                100  ,  500  , -25 
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 4; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                              0,1 ,
                              1,2 ,
                              2,3 ,
                              3,0
                          };
            j = 0;
            Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 4; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], Color.Red);

                j += 2;
            }
            M.cam = Cam;
        }

        void Createbsquare(_3D_Model M, float XS, float YS, float ZS, Color vvv)
        {
            float[] vert = 
                            { 
                                100,100, 25,  //0
                                100,100,-25,  //1
                                75 ,100, -25,  //2
                                75 ,100,  25,  //3
                                100,180, 25,  //4
                                100,180,-25,  //5
                                75 ,180, -25,  //6
                                75 ,180,  25,  //7
              
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            //Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], vvv); //cl[i % 4]);

                j += 2;
            }

            M.cam = Cam;
        }

        void Createssquare(_3D_Model M, float XS, float YS, float ZS, Color vvv)
        {
            float[] vert = 
                            { 
                                100,100, 25,  //0
                                100,100,-25,  //1
                                75 ,100, -25,  //2
                                75 ,100,  25,  //3
                                100,110, 25,  //4
                                100,110,-25,  //5
                                75, 110, -25,  //6
                                75, 110,  25,  //7
              
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            //Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], vvv); //cl[i % 4]);

                j += 2;
            }

            M.cam = Cam;
        }

        void CreateCube(_3D_Model cb, float XS, float YS, float ZS)
        {
            float[] vert = 
                            { 
                                -10  ,  0   ,  -80  ,
                                 10   , 0   ,  -80 ,
                                 10   , 0   , -100,
                                -10  ,  0   , -100 ,

                                -10  ,  20   ,  -80  ,
                                 10   , 20   ,  -80 ,
                                 10   , 20   , -100,
                                -10  ,  20   , -100
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                cb.AddPoint(pnn);
            }


            int[] Edges = {
                              0,1 ,
                              1,2 ,
                              2,3 ,
                              3,0 , 

                              4,5,
                              5,6,
                              6,7,
                              7,4,

                              0,4,
                              1,5,
                              2,6,
                              3,7

                          };
            j = 0;
            Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                cb.AddEdge(Edges[j], Edges[j + 1], cl[0]);

                j += 2;
            }
            cb.moving = true;
            cb.cam = Cam;
        }

        void CreateCamera()
        {
            Cam = new Camera();

            Cam.cxScreen = this.ClientSize.Width / 2;
            Cam.cyScreen = this.ClientSize.Height / 2;

            Cam.ceneterX = this.ClientSize.Width  / 2;
            Cam.ceneterY = this.ClientSize.Height / 2;

            Cam.BuildNewSystem();

        }
        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);

            CreateCamera();
            // CreatePlane(plane1, 200, 0, 0);
            // CreatePlane(plane2, 0, 0, 0);
            // CreatePlane(plane3, -200, 0, 0);

            Createssquare(bs1, -250, 100, 300, Color.Yellow);
            Createbsquare(bs2, -250, 0, 300, Color.Red);

            Createssquare(bs3, -250, -40, 300, Color.Yellow);
            Createbsquare(bs4, -250, -140, 300, Color.Red);

            Createssquare(bs5, -250, -180, 300, Color.Yellow);
            Createbsquare(bs6, -250, -280, 300, Color.Red);




            Createssquare(bs7, 50, 100, 300, Color.Yellow);
            Createbsquare(bs8, 50, 0, 300, Color.Red);

            Createssquare(bs9, 50, -40, 300, Color.Yellow);
            Createbsquare(bs10, 50, -140, 300, Color.Red);

            Createssquare(bs11, 50, -180, 300, Color.Yellow);
            Createbsquare(bs12, 50, -280, 300, Color.Red);


            Createdoor(door1, -110, -300, 300, Color.Black);
            Createdoor(door2, -240, -300, 300, Color.Black);

            Createbsquare(bsm1, -250, 120, 300, Color.Red);
            Createssquare(ss1, -250, 220, 300, Color.Yellow);
            Createbsquare(bsm2, 50, 120, 300, Color.Red);
            Createssquare(ss2, 50, 220, 300, Color.Yellow);



        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            plane1.DrawYourSelf(g);
            plane2.DrawYourSelf(g);
            plane3.DrawYourSelf(g);

            plane1a.DrawYourSelf(g);
            plane2a.DrawYourSelf(g);
            plane3a.DrawYourSelf(g);

            plane1b.DrawYourSelf(g);
            plane2b.DrawYourSelf(g);
            plane3b.DrawYourSelf(g);

            for (int i = 0; i < smallCubes.Count; i++)
            {
                smallCubes[i].DrawYourSelf(g);
            }



            bs1.DrawYourSelf(g);
            bs2.DrawYourSelf(g);
            bs3.DrawYourSelf(g);
            bs4.DrawYourSelf(g);
            bs5.DrawYourSelf(g);
            bs6.DrawYourSelf(g);



            bs7.DrawYourSelf(g);
            bs8.DrawYourSelf(g);
            bs9.DrawYourSelf(g);
            bs10.DrawYourSelf(g);
            bs11.DrawYourSelf(g);
            bs12.DrawYourSelf(g);


            door1.DrawYourSelf(g);
            door2.DrawYourSelf(g);

            bsm1.DrawYourSelf(g);
            bsm2.DrawYourSelf(g);
            ss1.DrawYourSelf(g);
            ss2.DrawYourSelf(g);
        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
