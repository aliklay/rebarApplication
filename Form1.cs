using System;
using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using tsmui = Tekla.Structures.Model.UI;
using System.Windows.Forms;
using Tekla.Structures.Model.UI;

namespace rebarApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRebars_Click(object sender, EventArgs e)
        {
            try
            {
                Model model = new Model();
                ModelObjectEnumerator myEnum = new tsmui.ModelObjectSelector().GetSelectedObjects();
                while (myEnum.MoveNext())
                {
                    Beam beam = myEnum.Current as Beam;
                    if (beam != null)
                    {
                        TransformationPlane currentPlane = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
                        TransformationPlane localPlane = new TransformationPlane(beam.GetCoordinateSystem());
                        model.GetWorkPlaneHandler().SetCurrentTransformationPlane(localPlane);

                        Solid solid = beam.GetSolid() as Solid;

                        double myLength = 0.0;
                        double myHeight = 0.0;
                        double myWidth = 0.0;

                        beam.GetReportProperty("HEIGHT", ref myHeight);
                        beam.GetReportProperty("LENGTH", ref myLength);
                        beam.GetReportProperty("WIDTH", ref myWidth);

                        Polygon pol1 = new Polygon();
                        pol1.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z));
                        pol1.Points.Add(new Point(solid.MinimumPoint.X, solid.MaximumPoint.Y, solid.MaximumPoint.Z));

                        Polygon pol2 = new Polygon();
                        pol2.Points.Add(new Point(solid.MaximumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z));
                        pol2.Points.Add(new Point(solid.MaximumPoint.X, solid.MaximumPoint.Y, solid.MaximumPoint.Z));




                        RebarGroup bar = new RebarGroup();
                        bar.Polygons.Add(pol1);
                        bar.Polygons.Add(pol2);
                        bar.RadiusValues.Add(40.0);
                        bar.SpacingType = BaseRebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_SPACE_FLEX_AT_END;
                        bar.Spacings.Add(200.0);
                        bar.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_NONE;
                        bar.Father = beam;
                        bar.Name = "RebarGroup";
                        bar.Class = 3;
                        bar.Size = "12";
                        bar.NumberingSeries.StartNumber = 0;
                        bar.NumberingSeries.Prefix = "Group";
                        bar.Grade = "K500C-T";

                        double Mycc = double.Parse(cc.Text);
                        bar.OnPlaneOffsets.Add(myWidth / 2 + Mycc / 2);
                        //bar.OnPlaneOffsets.Add(70.0);
                        //bar.OnPlaneOffsets.Add(70.0);
                        bar.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                        bar.StartPointOffsetValue = 32;
                        bar.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                        bar.EndPointOffsetValue = 32;
                        bar.FromPlaneOffset = 40;
                        bar.Insert();

                        pol1.Points.Clear();
                        pol1.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));
                        pol1.Points.Add(new Point(solid.MinimumPoint.X, solid.MaximumPoint.Y, solid.MinimumPoint.Z));

                        pol2.Points.Clear();
                        pol2.Points.Add(new Point(solid.MaximumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));
                        pol2.Points.Add(new Point(solid.MaximumPoint.X, solid.MaximumPoint.Y, solid.MinimumPoint.Z));


                        RebarGroup bar2 = new RebarGroup();
                        bar2.Polygons.Add(pol1);
                        bar2.Polygons.Add(pol2);
                        bar2.RadiusValues.Add(40.0);
                        bar2.SpacingType = BaseRebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_SPACE_FLEX_AT_END;
                        bar2.Spacings.Add(200.0);
                        bar2.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_NONE;
                        bar2.Father = beam;
                        bar2.Name = "RebarGroup";
                        bar2.Class = 3;
                        bar2.Size = "12";
                        bar2.NumberingSeries.StartNumber = 0;
                        bar2.NumberingSeries.Prefix = "Group";
                        bar2.Grade = "K500C-T";

                        bar2.OnPlaneOffsets.Add(-myWidth / 2 - Mycc / 2);
                        //bar2.OnPlaneOffsets.Add(70.0);
                        //bar2.OnPlaneOffsets.Add(70.0);
                        bar2.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                        bar2.StartPointOffsetValue = 32;
                        bar2.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                        bar2.EndPointOffsetValue = 32;
                        bar2.FromPlaneOffset = 40;
                        bar2.Insert();


                        model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlane);
                    }

                }
                model.CommitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnMesh_Click(object sender, EventArgs e)
        {
            try
            {
                Model model = new Model();
                ModelObjectEnumerator myEnum = new tsmui.ModelObjectSelector().GetSelectedObjects();
                while (myEnum.MoveNext())
                {
                    Beam beam = myEnum.Current as Beam;
                    if (beam != null)
                    {
                        TransformationPlane currentPlane = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
                        TransformationPlane localPlane = new TransformationPlane(beam.GetCoordinateSystem());
                        model.GetWorkPlaneHandler().SetCurrentTransformationPlane(localPlane);

                        Solid solid = beam.GetSolid() as Solid;


                        RebarMesh mesh = new RebarMesh();
                        Polygon polygon = new Polygon();
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z));
                        polygon.Points.Add(new Point(solid.MaximumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z));
                        polygon.Points.Add(new Point(solid.MaximumPoint.X, solid.MaximumPoint.Y, solid.MaximumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MaximumPoint.Y, solid.MaximumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z));

                        double myLength = 0.0;
                        double myHeight = 0.0;
                        double myWidth = 0.0;

                        beam.GetReportProperty("HEIGHT", ref myHeight);
                        beam.GetReportProperty("LENGTH", ref myLength);
                        beam.GetReportProperty("WIDTH", ref myWidth);


                        mesh.MeshType = RebarMesh.RebarMeshTypeEnum.RECTANGULAR_MESH;
                        mesh.Father = beam;
                        mesh.Polygon = polygon;
                        mesh.CatalogName = "MyCatalog";
                        mesh.LongitudinalSize = "8";
                        mesh.CrossSize = "6";
                        mesh.LeftOverhangCross = 20;
                        mesh.LeftOverhangLongitudinal = 40;
                        mesh.RightOverhangCross = 30;
                        mesh.RightOverhangLongitudinal = 20;
                        mesh.LongitudinalSpacingMethod = RebarMesh.RebarMeshSpacingMethodEnum.SPACING_TYPE_SAME_DISTANCE;
                        mesh.LongitudinalDistances.Add(150.0);
                        mesh.CrossDistances.Add(150.0);
                        mesh.Name = "Mesh";
                        mesh.Class = 7;
                        mesh.NumberingSeries.StartNumber = 0;
                        mesh.NumberingSeries.Prefix = "Mesh";
                        mesh.Grade = "NK500AB-W";
                        mesh.OnPlaneOffsets.Add(50.0);
                        mesh.FromPlaneOffset = -50;
                        mesh.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                        mesh.StartPointOffsetValue = 50;
                        mesh.CutByFatherPartCuts = false;
                        mesh.CrossBarLocation = RebarMesh.RebarMeshCrossBarLocationEnum.LOCATION_TYPE_ABOVE;

                        mesh.Length = myLength - 100;
                        mesh.Width = myHeight - 100;

                        mesh.Insert();


                        polygon.Points.Clear();
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));
                        polygon.Points.Add(new Point(solid.MaximumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));
                        polygon.Points.Add(new Point(solid.MaximumPoint.X, solid.MaximumPoint.Y, solid.MinimumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MaximumPoint.Y, solid.MinimumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));

                        mesh.Polygon = polygon;
                        mesh.FromPlaneOffset = 50;
                        mesh.Insert();

                        model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlane);
                    }
                }
                model.CommitChanges();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.ToString());
            }
        }
    }
}
