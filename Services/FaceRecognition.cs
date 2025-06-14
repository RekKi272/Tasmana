using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Emgu.CV.Face.FaceRecognizer;


namespace Services
{
    public class FaceRecognition
    {
        private readonly double distance = 1E+19;

        private readonly CascadeClassifier CascadeClassifier = new CascadeClassifier(Environment.CurrentDirectory + "/Haarcascade/haarcascade_frontalface_alt.xml");

        private Image<Bgr, byte> Frame = null;

        private Capture camera;

        private readonly Mat mat = new Mat();

        private readonly List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();

        private readonly List<int> PersonLabs = new List<int>();

        private bool isEnable_SaveImage = false;

        private string ImageName;

        private PictureBox PictureBox_Frame;

        private PictureBox PictureBox_smallFrame;

        private string personName;

        public bool isTrained = false;

        private readonly List<string> Names = new List<string>();

        private EigenFaceRecognizer eigenFaceRecognizer;

        public FaceRecognition()
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "\\FacesImage"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\FacesImage");
            }
        }

        public void GetPersonName(Control control)
        {
            Timer timer = new Timer();
            timer.Tick += timer_getPersonName_Tick;
            timer.Interval = 100;
            timer.Start();
            void timer_getPersonName_Tick(object sender, EventArgs e)
            {
                control.Text = personName;
            }
        }

        public void OpenCamera(PictureBox pictureBox_Camera, PictureBox pictureBox_Trained)
        {
            PictureBox_Frame = pictureBox_Camera;
            PictureBox_smallFrame = pictureBox_Trained;
            camera = new Capture();
            camera.ImageGrabbed += Camera_ImageGrabbed;
            camera.Start();
        }

        public void Save_IMAGE(string imageName)
        {
            ImageName = imageName;
            isEnable_SaveImage = true;
        }

        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            camera.Retrieve(mat);
            Frame = mat.ToImage<Bgr, byte>().Resize(PictureBox_Frame.Width, PictureBox_Frame.Height, Inter.Cubic);
            DetectFace();
            PictureBox_Frame.Image = Frame.Bitmap;
        }

        private void DetectFace()
        {
            Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
            Mat mat = new Mat();
            CvInvoke.CvtColor(Frame, mat, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(mat, mat);
            Rectangle[] array = CascadeClassifier.DetectMultiScale(mat, 1.1, 4);
            if (array.Length != 0)
            {
                Rectangle[] array2 = array;
                foreach (Rectangle rectangle in array2)
                {
                    CvInvoke.Rectangle(Frame, rectangle, new Bgr(Color.LimeGreen).MCvScalar, 2);
                    SaveImage(rectangle);
                    image.ROI = rectangle;
                    TrainedImage();
                    CheckName(image, rectangle);
                }
            }
            else
            {
                personName = "";
            }
        }

        private void SaveImage(Rectangle face)
        {
            if (isEnable_SaveImage)
            {
                Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
                image.ROI = face;
                image.Resize(100, 100, Inter.Cubic).Save(Environment.CurrentDirectory + "\\FacesImage\\" + ImageName + ".jpg");
                isEnable_SaveImage = false;
                TrainedImage();
            }
        }

        private void TrainedImage()
        {
            try
            {
                int num = 0;
                trainedFaces.Clear();
                PersonLabs.Clear();
                Names.Clear();
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\FacesImage", "*.jpg", SearchOption.AllDirectories);
                string[] array = files;
                foreach (string text in array)
                {
                    Image<Gray, byte> item = new Image<Gray, byte>(text);
                    trainedFaces.Add(item);
                    PersonLabs.Add(num);
                    Names.Add(text);
                    num++;
                }

                eigenFaceRecognizer = new EigenFaceRecognizer(num, distance);
                eigenFaceRecognizer.Train(trainedFaces.ToArray(), PersonLabs.ToArray());
            }
            catch
            {
            }
        }
        FaceRecognizer.PredictionResult predictionResult;
        private void CheckName(Image<Bgr, byte> resultImage, Rectangle face)
        {
            try
            {
                if (isTrained)
                {
                    Image<Gray, byte> image = resultImage.Convert<Gray, byte>().Resize(100, 100, Inter.Cubic);
                    CvInvoke.EqualizeHist(image, image);
                    predictionResult = eigenFaceRecognizer.Predict(image);
                    if (predictionResult.Label != -1 && predictionResult.Distance < distance)
                    {
                        PictureBox_smallFrame.Image = trainedFaces[predictionResult.Label].Bitmap;
                        // Ẩn đi tên của khuôn mặt trên khuôn hình vuông khi detect
                        personName = Names[predictionResult.Label].Replace(Environment.CurrentDirectory + "\\FacesImage\\", "").Replace(".jpg", "");
                        CvInvoke.PutText(Frame, personName, new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.LimeGreen).MCvScalar);
                    }
                    else
                    {
                        CvInvoke.PutText(Frame, "Unknown", new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.OrangeRed).MCvScalar);
                    }
                }
            }
            catch
            {
            }
        }
        public string GetCredential()
        {
            return personName;
        }
    }
}
