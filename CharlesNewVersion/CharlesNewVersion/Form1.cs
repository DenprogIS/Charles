using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace CharlesNewVersion
{
    public partial class Form1 : Form
    {
        private string g_Command;
        private bool g_LearningActived=false;
        ArrayList UITools = new ArrayList();
        Recognition g_SpeechRecoginition = new Recognition();
        Mind g_MindFindingTools = new Mind();
        static WindowExplorer g_WindowShowingSolutionToUser = new WindowExplorer(@"C:\Users\user\Desktop\home");
        WindowExplorer g_WindowHelpingForTeacher = new WindowExplorer(g_WindowShowingSolutionToUser.getPath());
        Synthesizer g_SynthesSpeech = new Synthesizer();
        GetStandartData g_GettingStdData = new GetStandartData();

        const bool SWITCH_ON = true, SWITCH_OFF = false;
        const string PORT_CONTACT_ARDUINO = "COM7";
        const int BAUD_RATE_CONTACT_ARDUINO = 9600;

        //BEGIN appendix function
        private void cleanBaseTools()
        {
            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\toolsBase.txt");
            writer.Close();
        }

        private void InitializeArduino()
        {
            serialPortArduino.PortName = PORT_CONTACT_ARDUINO;
            serialPortArduino.BaudRate = BAUD_RATE_CONTACT_ARDUINO;
            serialPortArduino.Open();
        }

        private void setStationElectricBulb(bool station)
        {
            if (station)
                serialPortArduino.Write("1");
            else
                serialPortArduino.Write("0");
        }

        private string findSolution()
        {
            string command=g_Command;
            g_MindFindingTools.setCurrentPathContent(g_WindowShowingSolutionToUser.getPath(), g_WindowShowingSolutionToUser.getContent());
            g_MindFindingTools.setCommand(command);
            return g_MindFindingTools.findSolution();
        }

        private void applySolution(string solution)
        {
            g_WindowShowingSolutionToUser.Show();
            g_WindowShowingSolutionToUser.applySolution(solution);
            Thread.Sleep(500);//for complete applying
            g_WindowShowingSolutionToUser.updateCurrentPath();
            g_SynthesSpeech.Synthes("Есть");
        }

        private void startLearning()
        {
            g_WindowHelpingForTeacher.Show();
            Hook.LocalHook = false;
            Hook.InstallHook();
            buttonStartStopLearning.Text = "Закончить обучение";
            g_LearningActived = true;
        }

        private void stopLearning()
        {
            Hook.UnInstallHook();
            g_WindowHelpingForTeacher.updateCurrentPath();
            g_MindFindingTools.setEndCurrentPathContent(g_WindowHelpingForTeacher.getPath(), g_WindowHelpingForTeacher.getContent());
            g_MindFindingTools.addTool();
            UITool tool = new UITool();
            g_MindFindingTools.getUIPresentation(ref tool.name,ref tool.beginPath,ref tool.endPath,ref tool.beginContent,ref tool.endContent);
            UITools.Add(tool);
            UIToolsBox.Items.Add(tool.name);
            g_WindowHelpingForTeacher.Close();
            g_SynthesSpeech.Synthes("Спасибо я научился");
            buttonStartStopLearning.Text = "Начать обучение";
            g_LearningActived = false;
        }

        private void addHookHandler()
        {
            Hook.OnHookKeyPressEventHandler += new Hook.HookKeyPress(onHookKeyPressEventHandler);
        }

        private void func()
        {
                if ((g_Command.IndexOf("Привет") != -1) || (g_Command.IndexOf("привет") != -1))
                    g_SynthesSpeech.Synthes("Здравствуйте сэр!");
                else if ((g_Command.IndexOf("Сколько время") != -1) || (g_Command.IndexOf("сколько время") != -1))
                    g_SynthesSpeech.Synthes(Convert.ToString(DateTime.Now.Hour) + ":" + Convert.ToString(DateTime.Now.Minute));
                else if ((g_Command.IndexOf("Какая погода") != -1) || (g_Command.IndexOf("какая погода") != -1))
                    g_SynthesSpeech.Synthes(g_GettingStdData.getWeather());
                else if ((g_Command.IndexOf("Ты свободен") != -1) || (g_Command.IndexOf("ты свободен") != -1))
                {
                    this.Close();
                }
                else if (g_Command.IndexOf("очистить базу") != -1)
                {
                    cleanBaseTools();
                    g_SynthesSpeech.Synthes("Есть");
                }
                else if ((g_Command.IndexOf("Заварить чай") != -1) || (g_Command.IndexOf("заварить чай") != -1))
                {
                    setStationElectricBulb(SWITCH_ON);
                    g_SynthesSpeech.Synthes("Заварил как вы любите зеленый");
                }
                else if (g_Command.IndexOf("Выключи свет") != -1)
                {
                    setStationElectricBulb(SWITCH_OFF);
                }
                else
                {
                    string solution = findSolution();
                    if (solution == null)
                    {
                        g_SynthesSpeech.Synthes("Сэр я не знаю как этого сделать научите меня");
                    }
                    else
                    {
                        applySolution(solution);
                    }
                }
            
        }
        //END appendix function

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            //InitializeArduino();
            addHookHandler();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                g_Command = commandShow.Text;
                func();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortArduino.IsOpen) serialPortArduino.Close();
        } 

        private void recogButton_Click(object sender, EventArgs e)
        {
            if (g_SpeechRecoginition.recording)
            {
                g_SpeechRecoginition.stopRecord();
                recognitionTimer.Enabled = true;
            }
            else
            {
                g_SpeechRecoginition.startRecord();
            }
        }

        private void recognitionTimer_Tick(object sender, EventArgs e)
        {
            recognitionTimer.Enabled = false;
            g_Command = g_SpeechRecoginition.recognition();
            commandShow.Text = g_Command;
            func();
        }


        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!g_LearningActived)
            {
                startLearning();
            }
            else
            {
                stopLearning();
            }
        }

        void onHookKeyPressEventHandler(LLKHEventArgs e)
        {
            if (e.IsPressed)
            {
               g_MindFindingTools.addKey(e.Keys.ToString() + " "); 
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            g_WindowShowingSolutionToUser.back();
            g_WindowHelpingForTeacher.back();
        }

        //TODO
        private void selfLearning_Tick(object sender, EventArgs e)////////////////////////////////////////////////////////////////////////////////////////
        {
            selfLearning.Enabled = false;

        }

        private void UIToolsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (UITool tool in UITools)
            {
                if (UIToolsBox.SelectedItem==tool.name)
                {
                    showBeginPath.Text = tool.beginPath;
                    showEndPath.Text = tool.endPath;
                    showBeginContent.Text = tool.beginContent;
                    showEndContent.Text = tool.endContent;
                }
            }
        }
    }

    struct UITool
    {
        public string name, beginPath, endPath, beginContent, endContent;
    }
}