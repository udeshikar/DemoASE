using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProgrammingLanguage;
using System.Drawing;



namespace ProgrammingLanguageTests
{
    [TestClass]
    public class ProgrammingLTests
    {
        Bitmap OutputBitmap = new Bitmap(640, 480);
        Graphics g;
        int XCanvasSize = 493;
        int YCanvasSize = 425;
        Pen pen;
        int xPos, yPos;
        int toX = 0;
        int toY = 0;
        int radius, width, height;
        public bool draw = true;
        int currentX, currentY;
        Color color = Color.Black;
        String shape;
        Canvas MyCanvas;
        Parser parser;
        ProgramWindowHandler program;


        [TestMethod]
        public void GetDetailsForCircleSingleCommand()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("circle 50", true);
            Assert.AreEqual(MyCanvas.getRadius(), 50);
            Assert.AreEqual(MyCanvas.getShape(), "circle");

        }

        [TestMethod]
        public void IncorrectRadiusForCircle()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("circle -50", true);
            Assert.AreEqual(MyCanvas.getRadius(), 0);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "invalid size for radius");

        }

        [TestMethod]
        public void InvalidNoofParametersFOrCircle()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("circle 50, 60", true);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "Invalid number of parameters for circle");

        }

        [TestMethod]
        public void GetDetailsForRectangleSingleCommand()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("rect 60,70", true);
            Assert.AreEqual(MyCanvas.getHeight(), 70);
            Assert.AreEqual(MyCanvas.getWidth(), 60);
            Assert.AreEqual(MyCanvas.getShape(), "rect");

        }

        [TestMethod]
        public void IncorrectNumberOfParametersForRectangle()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("rect 60", true);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "Invalid number of parameters for Rectangle");

        }

        [TestMethod]
        public void InvalidWidthForRectangle()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("rect 0,50", true);
            Assert.AreEqual(MyCanvas.getHeight(), 0);
            //Assert.AreEqual(MyCanvas.getWidth(), 50);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "invalid rectangle size");

        }

        [TestMethod]
        public void InvalidHeightForRectangle()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("rect 50,0", true);
            //Assert.AreEqual(MyCanvas.getHeight(), 50);
            Assert.AreEqual(MyCanvas.getWidth(), 0);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "invalid rectangle size");

        }

        [TestMethod]
        public void InvalidNumberofParametersForTraingle()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            parser.ParseCommand("triangle 30,20", true);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "Invalid number of parameters for Triangle");
        }

        [TestMethod]
        public void GetDetailsForMoveToSingleCommand()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("moveto 100,50", true);
            Assert.AreEqual(MyCanvas.getxPos(), 100);
            Assert.AreEqual(MyCanvas.getyPos(), 50);

        }

        [TestMethod]
        public void InvalidMoveToParameters()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("moveto -100,50", true);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "Invalid Screen Position");
        }

        [TestMethod]
        public void InvalidDrawToParameters()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            parser.ParseCommand("drawto 100", true);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "Invalid number of parameters for Line");
        }

        [TestMethod]
        public void GetDetailsForDrawToCommand()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("drawto 100,50", true);
            Assert.AreEqual(MyCanvas.getxPos(), 100);
            Assert.AreEqual(MyCanvas.getyPos(), 50);
        }

        [TestMethod]
        public void InvalidColorForPenCommand()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);

            //program = new ProgramWindowHandler(parser);
            parser.ParseCommand("pen pink", true);
            Assert.AreEqual(MyCanvas.getErrorMessage(), "Value is not accepted for given colors");
        }



        //Tests for part two

        [TestMethod]
        public void DefineMethodTest()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);
            program = new ProgramWindowHandler(parser);

            String[] text = { "x=10", "y=20" };
           
            var map = new Dictionary<string, string>();
            map.Add("x", "10");
            map.Add("y", "20");
            var result = program.DefineVariables(text);

            Assert.AreEqual(result.ContainsKey("x").ToString(), map.ContainsKey("x").ToString());

        }

        [TestMethod]
        public void GeneratingCommandsTest()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);
            program = new ProgramWindowHandler(parser);

            String[] text = new String[3];
            text[0] = "x=10";
            text[1] = "circle x";
            text[2] = "y=20";
            var map = new Dictionary<string, string>();
            map.Add("x", "10");
            map.Add("y", "20");

            String[] result = program.GeneratingCommands(text, map);

            Assert.AreEqual("circle 10", result[1].ToString());
        }

        [TestMethod]
        public void IfHandlerTest()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);
            program = new ProgramWindowHandler(parser);

            String[] text = { "x=10", "if x==10", "circle x", "end" };
            var map = new Dictionary<string, string>();
            map.Add("x", "10");

            String[] result = program.IfHandler(text, map);

            Assert.AreEqual("x=10", result[0].ToString());
        }

        [TestMethod]
        public void IfMethodBodyTest()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);
            program = new ProgramWindowHandler(parser);

            String[] text = { "x=10", "if x==10", "circle x", "end" };

            String[] result = program.IfMethodBody(text);

            Assert.AreEqual("if x==10", result[0].ToString());
            Assert.AreEqual("circle x", result[1].ToString());
            Assert.AreEqual("end", result[2].ToString());
        }

        [TestMethod]
        public void LoopMethodBodyTest()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Parser parser = new Parser(MyCanvas);
            program = new ProgramWindowHandler(parser);

            String[] text = { "x=10", "while x<10", "circle x", "endloop" };

            String[] result = program.LoopMethodBody(text);

            Assert.AreEqual("while x<10", result[0].ToString());
            Assert.AreEqual("circle x", result[1].ToString());
            Assert.AreEqual("endloop", result[2].ToString());
        }

    }
}